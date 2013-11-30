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
        private object[] metrixs;
        private List<string> sourceTitles;
        CalcFormula formula;
        List<object[]> itogData;
        List<object[]> sourceData;
        bool formed;


        public CalcForm()
        {
            InitializeComponent();

            objects = DataHelper.GetObjectsWithGroups();
            parameters = DataHelper.GetParameters();

            objectsList.DataSource = objects;
            objectsView.CustomUnboundColumnData += new CustomColumnDataEventHandler((sender, e) => UnboundColumnData(sender, e, objects));
            objectsView.CellValueChanging += OnObjectSelected;

            cbParameters.Items.Clear();
            cbParameters.Items.AddRange(DataHelper.CustomFormulas.Select(p => p.Name).ToArray());

            runButton.Click += OnRunButtonClick;
            closeButton.Click += OnCloseButtonClick;
            refTimeButton.Click += OnRefTimeButtonClick;
            saveButton.Click += OnSaveButtonClick;
            sourceTitles = new List<string>();
            itogData = new List<object[]>();
            sourceData = new List<object[]>();
            formed = false;
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

        private void OnRefTimeButtonClick(object sender, EventArgs e)
        {
            if (!rbTime.Checked && !rbRelation.Checked)
            {
                MessageBox.Show("Выберите тип диапазона времени.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedObj = objects.Where(o => (bool)((object[])o)[2]).Select(o => (int)((object[])o)[0]).ToArray();
            if (selectedObj.Count() == 0)
            {
                MessageBox.Show("Выберите объект измерений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            metrixs = DataHelper.GetMetrixByTimeConditions(string.Empty, selectedObj, rbTime.Checked);
            if (metrixs.Length > 0)
            {
                trackStart.Minimum = 0;
                trackStart.Maximum = metrixs.Length - 1;
                trackStart.Value = 0;
                trackStart.Enabled = true;

                trackEnd.Minimum = 0;
                trackEnd.Maximum = metrixs.Length - 1;
                trackEnd.Value = metrixs.Length - 1;
                trackEnd.Enabled = true;

                tbStart.Text = metrixs[trackStart.Value].ToString();
                tbEnd.Text = metrixs[trackEnd.Value].ToString();
            }
            else
            {
                trackStart.Minimum = 0;
                trackStart.Maximum = 1;
                trackStart.Value = 0;
                trackStart.Enabled = false;

                trackEnd.Minimum = 0;
                trackEnd.Maximum = 1;
                trackEnd.Value = 1;
                trackEnd.Enabled = false;

                tbStart.Text = "Нет данных";
                tbEnd.Text = "Нет данных";
            }
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

            if (!rbTime.Checked && !rbRelation.Checked)
            {
                MessageBox.Show("Выберите тип диапазона времени.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (trackStart.Value == 0 && trackEnd.Value == 1)
            {
                MessageBox.Show("Нет данных для выбранных измерений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    for (var i = trackStart.Value; i <= trackEnd.Value; i++)
                    {
                        data.Clear();
                        data.Add(metrixs[i]);

                        rdata.Clear();
                        rdata.Add(metrixs[i]);

                        for (var s = 0; s < selObj.Length; s++)
                        {
                            try
                            {
                                param = predicates.Select(p => new object[] {p, 
                                                    DataHelper.GetMetrix((int)selObj[s][0], p, metrixs[i], rbTime.Checked, con)}).ToArray();

                                data.AddRange(param.Select(p => p[1]));

                                decimal value = formula.Calc(param);

                                rdata.Add(value);
                               
                                if (sourceTitles.Count == s * predicates.Length)
                                {
                                    sourceTitles.AddRange(predicates.Select(p => (string)selObj[s][1] + "/" + p));
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
        }

        private void UnboundColumnData(object sender, CustomColumnDataEventArgs e, object[][] data)
        {
            e.Value = data[e.ListSourceRowIndex][e.Column.AbsoluteIndex];
        }

        private void trackStart_ValueChanged(object sender, EventArgs e)
        {
            trackEnd.Minimum = trackStart.Value;
            if (trackEnd.Value < trackEnd.Minimum)
            {
                trackEnd.Value = trackEnd.Minimum;
                tbEnd.Text = metrixs[trackEnd.Value].ToString();
            }
            tbStart.Text = metrixs[trackStart.Value].ToString();
        }

        private void trackEnd_ValueChanged(object sender, EventArgs e)
        {
            trackStart.Maximum = trackEnd.Value;
            if (trackStart.Value >= trackStart.Maximum)
            {
                trackStart.Value = trackStart.Maximum;
                tbStart.Text = metrixs[trackStart.Value].ToString();
            }
            
            tbEnd.Text = metrixs.Length <= trackEnd.Value ? "-" :   metrixs[trackEnd.Value].ToString();
        }

    }
}
