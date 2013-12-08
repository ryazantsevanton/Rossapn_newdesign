using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using System.Windows.Forms.DataVisualization.Charting;

namespace Design
{
    public partial class CalcForm : UserControl
    {
        private object[][] objects;
        private object[][] parameters;
        private List<string> sourceTitles;
        CalcFormula formula;
        List<object[]> itogData;
        List<object[]> sourceData;
        List<object[]> eventData;
        bool formed;
        DateTime minDate;

        public CalcForm()
        {
            InitializeComponent();

            objects = DataHelper.GetObjectsWithGroups();
            parameters = DataHelper.GetParameters();

            objectsList.DataSource = objects;
            objectsView.CustomUnboundColumnData += new CustomColumnDataEventHandler((sender, e) => UnboundColumnData(sender, e, objects));           
            objectsView.CellValueChanging += OnObjectSelected;

            viewEvents.CustomUnboundColumnData += UnboundEventData;

            cbParameters.Items.Clear();
            cbParameters.Items.AddRange(DataHelper.CustomFormulas.Select(p => p.Name).ToArray());

            runButton.Click += OnRunButtonClick;
            closeButton.Click += OnCloseButtonClick;
            saveButton.Click += OnSaveButtonClick;
            sourceTitles = new List<string>();
            itogData = new List<object[]>();
            sourceData = new List<object[]>();
            eventData = new List<object[]>();
            formed = false;

            SetMinDate();
            cbParameters.TextChanged += (_,__) => SetMinDate();
            trackBar.ValueChanged += OnTrackValueChanged;
        }

        private void UnboundEventData(object sender, CustomColumnDataEventArgs e)
        {
            try
            {
                object[] o = (object[])viewEvents.GetRow(e.ListSourceRowIndex);
                e.Value = ((object[])o)[e.Column.AbsoluteIndex];
            }
            catch
            {
                e.Value = string.Empty;
            }
        }

        private void OnTrackValueChanged(object sender, EventArgs e)
        {
            DateTime d = minDate.AddDays(trackBar.Value);
            lStartDate.Text = string.Format("{0}.{1}.{2} {3}:{4}:{5}", d.Day, d.Month, d.Year, d.Hour, d.Minute, d.Second);            
        }

        private void SetMinDate()
        {
            minDate = GetMinDateForCalc();
            if (minDate == DateTime.Today)
            {
                trackBar.Minimum = 0;
                trackBar.Maximum = 1;
                trackBar.Value = 0;
            }
            else
            {
                trackBar.Minimum = 0;
                TimeSpan ts = DateTime.Today - minDate;
                trackBar.Maximum = ts.Days;
                trackBar.Value = 0;
            }
            lStartDate.Text = string.Format("{0}.{1}.{2} {3}:{4}:{5}",
                                minDate.Day, minDate.Month, minDate.Year, minDate.Hour, minDate.Minute, minDate.Second);
        }

        private DateTime GetMinDateForCalc()
        {
            if (string.IsNullOrEmpty(cbParameters.Text) || objects == null)
            {
                return DateTime.Today;
            }
            int[] selObj = objects.Where(o => (bool)((object[])o)[2]).Select(o=> (int)((object[])o)[0]).ToArray();
            if (selObj.Length == 0)
            {
                return DateTime.Today;
            }

            formula = DataHelper.CustomFormulas.FirstOrDefault(f => f.Name == cbParameters.Text);
            if (formula == null)
            {
                return DateTime.Today;
            }

            DateTime? minDate = DataHelper.GetMinDate(selObj, formula.InitPredicates());
            return minDate == null ? new DateTime(1990, 1, 1) : minDate.Value;
        }


        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            object[][] selObj = objects.Where(o => (bool)((object[])o)[2]).ToArray();
            using (var con = DataHelper.OpenOrCreateDb())
            {
                int formPredicateId = DataHelper.GetParameter(cbParameters.Text, con, true);

                foreach (var d in itogData)
                {
                    for (int i = 1; i < d.Length; i++)
                    {
                        Triplet t = new Triplet((int)selObj[i - 1][0], formPredicateId, d[0].ToString(), (decimal)d[i]);
                        DateTime dat;
                        if (DateTime.TryParse(d[0].ToString(), out dat))
                        {
                            t.MetrixDate = dat;
                        }
                        DataHelper.SetMetrix(t, con);
                    }
                }
            }
            MessageBox.Show("Сохранено " + itogData.Count + " объектов");
        }

   
        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            if (formed && DialogResult.Yes != MessageBox.Show("Есть несохраненные данные.\r\nВы действительно хотите закрыть форму?",
                "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }
            Dispose();
        }

        private void OnRunButtonClick(object sender, EventArgs e)
        {
            if (formed && DialogResult.Yes != MessageBox.Show("Есть несохраненные данные.\r\nВы действительно хотите рассчитать форму?",
                "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            if (cbParameters.Text == string.Empty)
            {
                MessageBox.Show("Выберите параметр измерения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var selectedObj = objects.Where(o => (bool)((object[])o)[2]).Select(o => (int)((object[])o)[0]).ToArray();
            if (selectedObj.Count() == 0)
            {
                MessageBox.Show("Выберите объект измерений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            formula = DataHelper.CustomFormulas.FirstOrDefault(f => f.Name == cbParameters.Text);
            if (formula == null)
            {
                MessageBox.Show("Для параметра - '" + cbParameters.Text + "' не определено рассчетных формул",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sourceTitles.Clear();
            itogData.Clear();
            sourceData.Clear();

            string[] predicates = formula.InitPredicates();
            object[][] selObj = objects.Where(o => (bool)((object[])o)[2]).ToArray();
            object[][] param  = null;

            using (var con = DataHelper.OpenOrCreateDb())
            {
                try
                {
                    List<object> data = new List<object>();
                    List<object> rdata = new List<object>();
                    List<object> edata = new List<object>();
                    decimal eventInterval = DataHelper.GetSettingValue("RangeSchedule");

                    for (var i = trackBar.Value; i <= trackBar.Maximum; i++)
                    {
                        DateTime d = minDate.AddDays(i);
                        data.Clear();
                        data.Add(d);
                        rdata.Clear();
                        rdata.Add(d);
                        edata.Clear();

                        for (var s = 0; s < selObj.Length; s++)
                        {
                            try
                            {
                                int entityId = (int)selObj[s][0];
                                param =  predicates.Select(p => new object[] {p, DataHelper.GetAvgMetrix(entityId, p, d, con)}).ToArray();
                                data.AddRange(param.Select(p => p[1]));

                                decimal value = formula.Calc(param);

                                rdata.Add(value);
                               
                                if (sourceTitles.Count == s * predicates.Length)
                                {
                                    sourceTitles.AddRange(predicates.Select(p => (string)selObj[s][1] + "/" + p));
                                }

                                //обработка на событие

                                DataHelper.ClearEvent(entityId, d, con);
                                bool alreadyMarked = DataHelper.IsAlreadyMarked(entityId, d, eventInterval, con);
                                if (!alreadyMarked)
                                {
                                    foreach (object[] c in DataHelper.FindEventConditions(entityId, con))
                                    {
                                        EventChecker checker = DataHelper.EventCheckers.FirstOrDefault(ev => ev.Name == c[1].ToString());
                                        if (checker == null)
                                        {
                                            continue;
                                        }
                                        var o = checker.IsEventExists(c, d, con);
                                        if (o != null)
                                        {
                                            object[] result = (object[])o;
                                            if ((bool)result[0])
                                            {
                                                DataHelper.AddEvent(entityId, c[0], checker.Name, d, (double)result[1], (double)result[2], con);
                                                edata.Add(new object[] {
                                                    d,
                                                    (string)c[5],
                                                    (string)c[4],
                                                    checker.Name,
                                                    (double)result[1], 
                                                    (double)result[2]
                                                });
                                            }
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Ошибка обработки данных для '" + (string)selObj[s][1] + "'. Обратитесь к разработчику");
                                continue;
                            }
                        }
                        sourceData.Add(data.ToArray());
                        itogData.Add(rdata.ToArray());
                        if (edata.Count > 0)
                        {
                            foreach (object[] ed in edata)
                            {
                                eventData.Add(ed);
                            }
                        }
                    }
                }
                finally { con.Close(); }
                PrepareViews();
                formed = true;
            }
        }

        private void PrepareViews()
        {
            mainView.Columns.Clear();
            viewSource.Columns.Clear();
            chartControl.Series.Clear();
            chartSource.Series.Clear();

            Series s = null;
            
            object[][] selObj = objects.Where(o => (bool)((object[])o)[2]).ToArray();

            for (int j = 0; j <= selObj.Length; j++)
            {
                GridColumn unbColumn = mainView.Columns.AddField("col" + j);
                unbColumn.VisibleIndex = mainView.Columns.Count;
                unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                unbColumn.OptionsColumn.AllowEdit = false;
                unbColumn.AppearanceCell.BackColor = Color.LemonChiffon;
                unbColumn.Caption = j == 0 ? "Время" : (string)selObj[j - 1][1];
                mainView.CustomUnboundColumnData += CustomUnboundColumnDataMainView;

                if (j > 0)
                {
                    s = new Series();
                    s.Name = unbColumn.Caption;
                    s.ChartType = SeriesChartType.FastLine;
                    chartControl.Series.Add(s);
                }
            }

            for (int j = 0; j <= sourceTitles.Count; j++)
            {
                GridColumn unbColumn = viewSource.Columns.AddField("col" + j);
                unbColumn.VisibleIndex = viewSource.Columns.Count;
                unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                unbColumn.OptionsColumn.AllowEdit = false;
                unbColumn.AppearanceCell.BackColor = Color.LemonChiffon;
                unbColumn.Caption = j == 0 ? "Время" : sourceTitles.ElementAt(j -1);
                viewSource.CustomUnboundColumnData += CustomUnboundColumnDataViewSource;

                if (j > 0)
                {
                    s = new Series();
                    s.Name = unbColumn.Caption;
                    s.ChartType = SeriesChartType.FastLine;
                    chartSource.Series.Add(s);
                }
            }

            for (int i = 0; i < itogData.Count; i++)
            {
                string strValue = itogData[i][0].ToString();
                int j = 1;
                foreach (var ss in chartControl.Series)
                {
                    ss.Points.AddXY(strValue, itogData[i][j]);
                    j++;
                }
                j = 1;
                foreach (var ss in chartSource.Series)
                {
                    ss.Points.AddXY(strValue, sourceData[i][j]);
                    j++;
                }
            }

            grid.DataSource = itogData;
            gridSource.DataSource = sourceData;
            gridEvents.DataSource = eventData;

        }

        private void CustomUnboundColumnDataMainView(object sender, CustomColumnDataEventArgs e)
        {
            try
            {
                e.Value = itogData[e.ListSourceRowIndex][e.Column.AbsoluteIndex];
            }
            catch { e.Value = string.Empty; }
        }

        private void CustomUnboundColumnDataViewSource(object sender, CustomColumnDataEventArgs e)
        {
            try
            {
                e.Value = sourceData.ElementAt(e.ListSourceRowIndex)[e.Column.AbsoluteIndex];
            }
            catch { e.Value = string.Empty; }
        }


        private void OnObjectSelected(object sender, CellValueChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            objects[view.FocusedRowHandle][2] = (bool)e.Value;
            SetMinDate();
        }

        private void UnboundColumnData(object sender, CustomColumnDataEventArgs e, object[][] data)
        {
            e.Value = data[e.ListSourceRowIndex][e.Column.AbsoluteIndex];
        }

    }
}
