using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;

namespace Design
{
    public partial class DataControl : UserControl
    {
      
        object[][] objects;
        object[][] parameters;
        DisplayObjects displayObjects;

        public DataControl()
        {
            InitializeComponent();

            objects = DataHelper.GetObjects();
            parameters = DataHelper.GetParameters();

            objectsList.DataSource = objects;
            parametersList.DataSource = parameters;

            objectsView.CustomUnboundColumnData += new CustomColumnDataEventHandler((sender, e) => UnboundColumnData(sender, e, objects));        
            objectsView.CellValueChanging += OnObjectSelected;

            parametersView.CustomUnboundColumnData += new CustomColumnDataEventHandler((sender, e) => UnboundColumnData(sender, e, parameters));
            parametersView.CellValueChanging += OnParameterSelected;

            displayObjects = new DisplayObjects(dataTable, dataView, chartControl1);
           
            dataTable.DataSource = displayObjects.times;

            dataView.CustomUnboundColumnData += displayObjects.getUnboundColumnData;

        }

        private void UnboundColumnData(object sender, CustomColumnDataEventArgs e, object[][] data)
        {
            e.Value = data[e.ListSourceRowIndex][e.Column.AbsoluteIndex];
        }

        private void OnObjectSelected(object sender, CellValueChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            objects[view.FocusedRowHandle][2] = (bool)e.Value;

            if ((bool)e.Value == true)
                displayObjects.addObject((int)objects[view.FocusedRowHandle][0], (string)objects[view.FocusedRowHandle][1]);
            else
                displayObjects.removeObject((int)objects[view.FocusedRowHandle][0]);

        }

        private void OnParameterSelected(object sender, CellValueChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            parameters[view.FocusedRowHandle][2] = (bool)e.Value;

            if ((bool)e.Value == true)
                displayObjects.addParameter((int)parameters[view.FocusedRowHandle][0], (string)parameters[view.FocusedRowHandle][1]);
            else
                displayObjects.removeParameter((int)parameters[view.FocusedRowHandle][0]);
        }

        class DisplayObjects
        {
            public SortedSet<String> times = new SortedSet<String>();
            private List<DisplayObject> objects = new List<DisplayObject>();
            private List<int> paramIndexes = new List<int>();
            private Dictionary<string, DevExpress.XtraCharts.Series> series = new Dictionary<string, DevExpress.XtraCharts.Series>();

            private DevExpress.XtraGrid.GridControl dataTable;
            private DevExpress.XtraGrid.Views.Grid.GridView dataView;
            private DevExpress.XtraCharts.ChartControl chartControl;

            public DisplayObjects(DevExpress.XtraGrid.GridControl dataTable, DevExpress.XtraGrid.Views.Grid.GridView dataView, DevExpress.XtraCharts.ChartControl chartControl1)
            {
                this.dataTable = dataTable;
                this.dataView = dataView;
                this.chartControl = chartControl1;
            }

            internal void getUnboundColumnData(object sender, CustomColumnDataEventArgs e)
            {
                if (e.Column.AbsoluteIndex == 0)
                    e.Value = times.ElementAt(e.ListSourceRowIndex);
                else
                {
                    int paramCount = paramIndexes.Count;

                    if (paramCount == 0) return;

                    int objectIndex = (e.Column.VisibleIndex - 1) / paramCount;
                    int paramIndex = (e.Column.VisibleIndex - 1) % paramCount;

                    var time = times.ElementAt(e.ListSourceRowIndex);

                    if (objectIndex >= objects.Count) return;

                    e.Value = objects[objectIndex].paramValByIndex(time, paramIndex);

                }
            }

            internal void addObject(int objectId, string name)
            {

                if (objects.Count((o) => o.id == objectId) > 0)
                    return;

                DisplayObject obj = new DisplayObject(objectId, name);

                foreach (int pId in paramIndexes)
                {
                    obj.addParameter(pId, pId + "");
                    insertColumn(pId, pId + "", dataView.Columns.Count, obj);
                }

                objects.Add(obj);

                refreshTable();

            }

            internal void removeObject(int objectId)
            {
                DisplayObject target = objects.Find((o) => o.id == objectId);

                foreach (int pId in paramIndexes)
                {
                    removeColumn(pId, target);
                }

                objects.Remove(target);

                refreshTable();
            }

            internal void addParameter(int parameterId, string name)
            {

                if (paramIndexes.Contains(parameterId))
                    return;
                else
                    paramIndexes.Add(parameterId);

                for (int i = 0; i < objects.Count; i++)
                {

                    DisplayObject obj = objects[i];
                    joinTimes(obj.addParameter(parameterId, name));
                }

                for (int i = 0; i < objects.Count; i++)
                {
                    DisplayObject obj = objects[i];

                    insertColumn(parameterId, name, i * obj.parameters.Count + obj.parameters.Count, obj);
                }

                refreshTable();
            }

            private void insertColumn(int parameterId, string name, int vi, DisplayObject obj)
            {
                GridColumn unbColumn = dataView.Columns.AddField(obj.id + "_" + parameterId);
                unbColumn.VisibleIndex = vi;
                unbColumn.Caption = obj.name + ":" + name;
                unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                unbColumn.OptionsColumn.AllowEdit = true;
                unbColumn.AppearanceCell.BackColor = Color.FromArgb(0xFF, 0xFF, 0xFA - obj.id * 16, 0xCD - obj.id * 16);

                var s = new DevExpress.XtraCharts.Series();
                s.Name = unbColumn.Caption;
                s.ChangeView(DevExpress.XtraCharts.ViewType.SwiftPlot);
                (s.View as DevExpress.XtraCharts.SwiftPlotSeriesView).LineStyle.Thickness = 2;
                SortedDictionary<string, object[]> data = obj.getParameterById(parameterId).columnData;

                foreach (string time in data.Keys) 
                    s.Points.Add(new DevExpress.XtraCharts.SeriesPoint(time, data[time][2]));

                chartControl.Series.Add(s);

                series.Add(obj.id + "_" + parameterId, s);

            }

            internal void removeParameter(int parameterId)
            {

                paramIndexes.Remove(parameterId);

                for (int i = objects.Count - 1; i >= 0; i--)
                {
                    DisplayObject obj = objects[i];
                    removeColumn(parameterId, obj);
                }

                for (int i = objects.Count - 1; i >= 0; i--)
                {
                    DisplayObject obj = objects[i];
                    obj.parameters.RemoveAll((parameter) => parameter.id == parameterId);
                }

                refreshTable();
            }

            private void removeColumn(int parameterId, DisplayObject obj)
            {
                GridColumn column = dataView.Columns.ColumnByFieldName(obj.id + "_" + parameterId);
                dataView.Columns.Remove(column);


                chartControl.Series.Remove(series[obj.id + "_" + parameterId]);
                series.Remove(obj.id + "_" + parameterId);

            }

            private void refreshTable()
            {
                dataTable.DataSource = null;
                dataTable.DataSource = times;
            }

            internal DisplayParameter joinTimes(DisplayParameter parameter)
            {
                times.UnionWith(parameter.columnData.Keys);
                return parameter;
            }

        }

        class DisplayObject
        {
            internal int id;
            internal string name;
            internal List<DisplayParameter> parameters = new List<DisplayParameter>();
            
            public DisplayObject(int objectId, string name)
            {
                this.id = objectId;
                this.name = name;
            }

            public object paramValByIndex(string time, int parameterIndex)
            {
                return parameters[parameterIndex].val(time);
            }

            public DisplayParameter addParameter(int parameterId, string name)
            {
                DisplayParameter result;
                parameters.Add(result = new DisplayParameter(parameterId, this.id).load());
                return result;
            }

            public DisplayParameter getParameterById(int parameterId)
            {
                return parameters.Find(p => p.id == parameterId);
            }

        }

        class DisplayParameter
        {
            internal int objectId;
            internal int id;

            public SortedDictionary<string, object[]> columnData = new SortedDictionary<string, object[]>();

            public DisplayParameter(int parameterId, int objectId)
            {
                this.id = parameterId;
                this.objectId = objectId;
            }

            internal DisplayParameter load()
            {

                columnData = DataHelper.GetMetrix(objectId, id);

                return this;
            }

            internal object val(String time)
            {
                if (columnData.ContainsKey(time))
                    return (decimal)columnData[time][2];
                else
                    return null;
            }
        }



    }

}
