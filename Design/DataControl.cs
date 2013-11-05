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
using System.Windows.Forms.DataVisualization.Charting;
using Design.Infrastructure;

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

            objects = DataHelper.GetObjectsWithGroups();
            parameters = DataHelper.GetParameters();

            objectsList.DataSource = objects;
            parametersList.DataSource = parameters;

            objectsView.CustomUnboundColumnData += new CustomColumnDataEventHandler((sender, e) => UnboundColumnData(sender, e, objects));
            objectsView.CellValueChanging += OnObjectSelected;

            parametersView.CustomUnboundColumnData += new CustomColumnDataEventHandler((sender, e) => UnboundColumnData(sender, e, parameters));
            parametersView.CellValueChanging += OnParameterSelected;

            displayObjects = new DisplayObjects(dataTable, dataView, chartControl);
            displayObjects.DataChanged += EnableButton;

            dataTable.DataSource = displayObjects.times;

            dataView.CustomUnboundColumnData += displayObjects.getUnboundColumnData;
            dataView.CellValueChanged += displayObjects.OnCellValueChanged;
            dataView.RowCellStyle += displayObjects.OnRowCellStyle;
        }

        void EnableButton()
        {
            saveButton.Enabled = true;
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
                displayObjects.addParameter(new ParameterId((int)parameters[view.FocusedRowHandle][0], (string)parameters[view.FocusedRowHandle][1]));
            else
                displayObjects.removeParameter((int)parameters[view.FocusedRowHandle][0]);
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {

            DataHelper.SaveMetrixBundle(displayObjects.getSaveBundle(true));

            displayObjects.refreshTable();
            saveButton.Enabled = false;
        }
        
        class DisplayObjects
        {
            public SortedSet<String> times = new SortedSet<String>();
            private List<DisplayObject> objects = new List<DisplayObject>();
            public List<ParameterId> paramIds = new List<ParameterId>();
            private Dictionary<string, Series> series = new Dictionary<string, Series>();

            private DevExpress.XtraGrid.GridControl dataTable;
            private DevExpress.XtraGrid.Views.Grid.GridView dataView;
            private Chart chartControl;

            public delegate void DataChangedEvent();

            public event DataChangedEvent DataChanged;
            internal void onDataChanged()
            {
                if (DataChanged != null)
                    DataChanged();
            }

            public DisplayObjects(DevExpress.XtraGrid.GridControl dataTable, DevExpress.XtraGrid.Views.Grid.GridView dataView, Chart chartControl)
            {
                this.dataTable = dataTable;
                this.dataView = dataView;
                this.chartControl = chartControl;
            }

            internal void getUnboundColumnData(object sender, CustomColumnDataEventArgs e)
            {
                if (e.Column.AbsoluteIndex == 0)
                    e.Value = times.ElementAt(e.ListSourceRowIndex);
                else
                {
                    int paramCount = paramIds.Count;

                    if (paramCount == 0) return;

                    int objectIndex = (e.Column.VisibleIndex - 1) / paramCount;
                    int paramIndex = (e.Column.VisibleIndex - 1) % paramCount;

                    var time = times.ElementAt(e.ListSourceRowIndex);

                    if (objectIndex >= objects.Count) return;

                    e.Value = objects[objectIndex].paramValByIndex(time, paramIndex);

                }
            }

            internal void OnCellValueChanged(object sender, CellValueChangedEventArgs e)
            {
                if (e.Column.AbsoluteIndex == 0)
                    return;
                else
                {
                    int paramCount = paramIds.Count;

                    if (paramCount == 0) return;

                    int objectIndex = (e.Column.VisibleIndex - 1) / paramCount;
                    int paramIndex = (e.Column.VisibleIndex - 1) % paramCount;

                    var time = times.ElementAt(e.RowHandle);

                    if (objectIndex >= objects.Count) return;

                    string valStr = ((ColumnView)sender).EditingValue.ToString();
                    if (String.IsNullOrEmpty(valStr))
                    {
                        objects[objectIndex].delete(time, paramIndex);
                        this.onDataChanged();
                    }
                    else
                        try
                        {
                            decimal val = Decimal.Parse(valStr);
                            if (val == (decimal)e.Value) return;
                            objects[objectIndex].update(time, paramIndex, val);
                            this.onDataChanged();
                        }
                        catch (Exception ex) { }
                    
                }
            }

            internal void OnRowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
            {

                e.Appearance.BackColor = Color.LemonChiffon;
                if (e.Column.VisibleIndex == 0) return;

                int paramCount = paramIds.Count;

                if (paramCount == 0) return;

                int objectIndex = (e.Column.VisibleIndex - 1) / paramCount;
                int paramIndex = (e.Column.VisibleIndex - 1) % paramCount;

                var time = times.ElementAt(e.RowHandle);

                object[] mtx;
                if (!objects[objectIndex].parameters[paramIndex].columnData.TryGetValue(time, out mtx))
                {
                    e.Appearance.BackColor = Color.FromArgb(224, 224, 224);
                    return;
                }

                if ((EditAction)mtx[3] == EditAction.Modified)
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 224, 192);
                    return;
                }
                if ((EditAction)mtx[3] == EditAction.Delete)
                {
                    e.Appearance.BackColor = Color.FromArgb(224, 224, 224);
                    return;
                }
               
            }

            internal void addObject(int objectId, string name)
            {

                if (objects.Count((o) => o.id == objectId) > 0)
                    return;

                DisplayObject obj = new DisplayObject(objectId, name);

                foreach (ParameterId pId in paramIds)
                {
                    joinTimes(obj.addParameter(pId));
                    insertColumn(pId, dataView.Columns.Count, obj);
                }

                objects.Add(obj);

                refreshTable();

            }

            internal void removeObject(int objectId)
            {
                DisplayObject target = objects.Find((o) => o.id == objectId);

                foreach (ParameterId pId in paramIds)
                {
                    removeColumn(pId.id, target);
                }

                objects.Remove(target);

                refreshTable();
            }

            internal void addParameter(ParameterId parameterId)
            {

                if (paramIds.Find(id => id.id == parameterId.id) != null)
                    return;
                else
                    paramIds.Add(parameterId);

                for (int i = 0; i < objects.Count; i++)
                {

                    DisplayObject obj = objects[i];
                    joinTimes(obj.addParameter(parameterId));
                }

                for (int i = 0; i < objects.Count; i++)
                {
                    DisplayObject obj = objects[i];

                    insertColumn(parameterId, i * obj.parameters.Count + obj.parameters.Count, obj);
                }

                refreshTable();
            }

            private void insertColumn(ParameterId parameterId, int vi, DisplayObject obj)
            {
                GridColumn unbColumn = dataView.Columns.AddField(obj.id + "_" + parameterId.id);
                unbColumn.VisibleIndex = vi;
                unbColumn.Caption = obj.name + ":" + parameterId.name;
                unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                unbColumn.OptionsColumn.AllowEdit = true;
                unbColumn.AppearanceCell.BackColor = Color.FromArgb(0xFF, 0xFF, 0xFA - obj.id * 16, 0xCD - obj.id * 16);

                var s = new Series();
                s.Name = unbColumn.Caption;
                s.ChartType = SeriesChartType.FastLine;
                SortedDictionary<string, object[]> data = obj.getParameterById(parameterId.id).columnData;

                foreach (string time in data.Keys) 
                    s.Points.AddXY(time, data[time][2]);

                chartControl.Series.Add(s);

                series.Add(obj.id + "_" + parameterId.id, s);

            }

            internal void removeParameter(int parameterId)
            {

                paramIds.RemoveAll(id => id.id == parameterId);

                for (int i = objects.Count - 1; i >= 0; i--)
                {
                    DisplayObject obj = objects[i];
                    removeColumn(parameterId, obj);
                }

                for (int i = objects.Count - 1; i >= 0; i--)
                {
                    DisplayObject obj = objects[i];
                    obj.parameters.RemoveAll((parameter) => parameter.id.id == parameterId);
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

            internal void refreshTable()
            {
                dataTable.DataSource = null;
                dataTable.DataSource = times;
            }

            internal DisplayParameter joinTimes(DisplayParameter parameter)
            {
                times.UnionWith(parameter.columnData.Keys);
                return parameter;
            }


            internal List<object[]> getSaveBundle(bool apply)
            {
                List<object[]> metrix = new List<object[]>();

                objects.ForEach(obj => metrix.AddRange(obj.changesBundle(apply)));

                return metrix;
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

            public DisplayParameter addParameter(ParameterId parameterId)
            {
                DisplayParameter result;
                parameters.Add(result = new DisplayParameter(parameterId, this.id).load());
                return result;
            }

            public DisplayParameter getParameterById(int parameterId)
            {
                return parameters.Find(p => p.id.id == parameterId);
            }


            internal void update(string time, int paramIndex, decimal value)
            {
                parameters[paramIndex].update(time, value);
            }

            internal void delete(string time, int paramIndex)
            {
                parameters[paramIndex].delete(time);
            }

            internal List<object[]> changesBundle(bool apply)
            {
                List<object[]> metrix = new List<object[]>();

                parameters.ForEach(param => metrix.AddRange(param.changesBundle(apply)));

                return metrix;
            }
        }

        class DisplayParameter
        {
            internal int objectId;
            internal ParameterId id;

            public SortedDictionary<string, object[]> columnData = new SortedDictionary<string, object[]>();

            public DisplayParameter(ParameterId parameterId, int objectId)
            {
                this.id = parameterId;
                this.objectId = objectId;
            }

            internal DisplayParameter load()
            {

                columnData = DataHelper.GetMetrix(objectId, id.id);

                return this;
            }

            internal object val(string time)
            {
                if (columnData.ContainsKey(time))
                    return (decimal)columnData[time][2];
                else
                    return null;
            }

            internal void update(string time, decimal value)
            {
                columnData[time][2] = value;
                columnData[time][3] = EditAction.Modified;
            }

            internal void delete(string time)
            {
                columnData[time][3] = EditAction.Delete;
            }


            internal List<object[]> changesBundle(bool apply)
            {
                List<object[]> metrix = new List<object[]>();
                List<string> toRemove = new List<string>();

                foreach (object[] mtx in columnData.Values)
                    switch ((EditAction)mtx[3])
                    {
                        case EditAction.Modified:
                            metrix.Add(new object[]{mtx[0], mtx[1], mtx[2], mtx[3]});
                            mtx[3] = EditAction.None;
                            break;
                        case EditAction.Delete:
                            metrix.Add(new object[]{mtx[0], mtx[1], mtx[2], mtx[3]});
                            //columnData.Remove(mtx[1].ToString());
                            toRemove.Add(mtx[1].ToString());
                            break;
                    }

                foreach (string key in toRemove)
                    columnData.Remove(key);

                return metrix;
            }
        }

        class ParameterId
        {
            internal int id;
            internal string name;
            internal ParameterId(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
        }

    }

}
