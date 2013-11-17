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
        private bool formed;
        private object[] metrixs;
        private object[][] dataMetrixs;

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
            importButton.Click += OnImportButtonClick;
            formed = false;
            refTimeButton.Click += OnRefTimeButtonClick;
        }

        private void OnRefTimeButtonClick(object sender, EventArgs e)
        {
            if (!rbTime.Checked && !rbRelation.Checked)
            {
                MessageBox.Show("Выберите тип диапазона времени.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedObj = objects.Where(o => (bool)((object[])o)[2]).Select(o => (int)((object[])o)[0]).ToArray();
            if (selectedObj.Count() != 1)
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

        private void OnImportButtonClick(object sender, EventArgs e)
        {
            formed = false;
        }

        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            if (formed && DialogResult.Yes != MessageBox.Show("Вы действительно хотите закрыть форму?",
                "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }
            Dispose();
        }

        private void OnRunButtonClick(object sender, EventArgs e)
        {
            formed = true;
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
            if (selectedObj.Count() != 1)
            {
                MessageBox.Show("Выберите объект измерений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataMetrixs = DataHelper.GetMetrixByAllConditions(cbParameters.Text, selectedObj, rbTime.Checked, metrixs[trackStart.Value], metrixs[trackEnd.Value]);

            decimal numberCount = DataHelper.GetSettingValue("ScaleData");
            if (numberCount == null || numberCount == 0)
            {
                numberCount = 10;
            }

            int scheduleRange = Convert.ToInt32(DataHelper.GetSettingValue("RangeSchedule"));
            if (scheduleRange == null || scheduleRange == 0)
            {
                scheduleRange = 30;
            }

            List<decimal[]> kritValues = new List<decimal[]>();

            for (int k = 1; k < dataMetrixs[0].Length; k++)
            {

                decimal minValue = dataMetrixs.Min(l => (decimal)l[k]);
                decimal maxValue = dataMetrixs.Max(l => (decimal)l[k]);
                kritValues.Add(new decimal[] { minValue, maxValue, (maxValue - minValue) / numberCount });
            }




            chartControl.Series.Clear();

            Series s = null;

            for (int j = 0; j < dataMetrixs[0].Length; j++)
            {
                GridColumn unbColumn = mainView.Columns.AddField("col" + j);
                unbColumn.VisibleIndex = mainView.Columns.Count;
                unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                unbColumn.OptionsColumn.AllowEdit = false;
                unbColumn.AppearanceCell.BackColor = Color.LemonChiffon;

                if (j == 0)
                {
                    unbColumn.Caption = "Время";
                }
                else
                {
                    var title = selectedObj[j - 1].ToString();
                    object[] t = objects.FirstOrDefault(o => (int)o[0] == selectedObj[j - 1]);
                    if (t != null)
                    {
                        title = t[1].ToString();
                    }
                    unbColumn.Caption = title;
                    s = new Series();
                    s.Name = unbColumn.Caption;
                    s.ChartType = SeriesChartType.FastLine;

                    chartControl.Series.Add(s);

                }
            }


            for (int i = 0; i < dataMetrixs.Length; i++)
            {
                long value = 0;
                if (!Int64.TryParse(dataMetrixs[i][0].ToString(), out value))
                {
                    value = -1;
                }

                string strValue = value == -1 ? (string)dataMetrixs[i][0] : value.ToString();
                int j = 1;
                foreach (var ss in chartControl.Series)
                {
                    ss.Points.AddXY(strValue, dataMetrixs[i][j]);
                    j++;
                }
            }

            mainView.CustomUnboundColumnData += CustomUnboundColumnData;

            grid.DataSource = dataMetrixs;

        }

        private void CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.AbsoluteIndex == 0)
            {
                long value = 0;
                string v = dataMetrixs[e.ListSourceRowIndex][e.Column.AbsoluteIndex].ToString();
                if (!Int64.TryParse(v, out value))
                {
                    value = -1;
                }
                e.Value = value == -1 ? v : value.ToString();
                return;
            }

            e.Value = dataMetrixs[e.ListSourceRowIndex][e.Column.AbsoluteIndex];
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
