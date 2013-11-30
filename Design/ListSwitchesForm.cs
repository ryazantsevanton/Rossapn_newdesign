using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;

namespace Design
{
    public partial class ListSwitchesForm : UserControl
    {
        private object[] metrixs;
        private object[][] selectedObjs;
        private bool formed;
        List<object[]> itogData;
        List<string> scheduleList;


        public ListSwitchesForm()
        {
            InitializeComponent();
            refTimeButton.Click += OnRefTimeButtonClick;
            closeButton.Click += OnCloseButtonClick;
            runButton.Click += OnRunButtonClick;
            importButton.Click += OnImportButtonClick;

            cbParameters.Items.Clear();
            cbParameters.Items.AddRange(DataHelper.CustomFormulas.Select(p => p.Name).ToArray());

            cbObjectGroup.Properties.Items.Clear();
            cbObjectGroup.Properties.Items.AddRange(DataHelper.GetEntityGroups());
            formed = false;
            itogData = new List<object[]>();
            scheduleList = new List<string>();
        }

        private void OnRefTimeButtonClick(object sender, EventArgs e)
        {
            if (!rbTime.Checked && !rbRelation.Checked)
            {
                MessageBox.Show("Выберите тип диапазона времени.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(cbObjectGroup.Text))
            {
                MessageBox.Show("Выберите объект измерений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedObjs == null || selectedObjs.Length == 0)
            {
                selectedObjs = DataHelper.GetEntityByGroup(cbObjectGroup.Text);
            }
            if (selectedObjs == null || selectedObjs.Length == 0)
            {
                MessageBox.Show("У группы '" + cbObjectGroup.Text + "' нет объектов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            metrixs = DataHelper.GetMetrixByTimeConditions(cbParameters.Text, 
                                                selectedObjs.Select(s => (int)s[0]).ToArray(), rbTime.Checked);
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
            if (itogData.Count == 0)
            {
                return;
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Workbook objWorkBook = null;
            Worksheet objWorkSheet = null;
            Range selectedRange = null;
            Shapes shapes = null;
            Microsoft.Office.Interop.Excel.Chart chart = null;
            ChartTitle chartTitle = null;
            try
            {
                string fileName = String.Empty;
                saveFileDialog1.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog1.FileName;
                }
                else
                    return;

                var f = new FileInfo(fileName);
                if (f.Exists)
                {
                    f.Delete();
                }

                objExcel = new Microsoft.Office.Interop.Excel.Application();

                objWorkBook = objExcel.Workbooks.Add(System.Reflection.Missing.Value);
                objWorkSheet = objExcel.ActiveSheet as Worksheet;
                objWorkSheet.Cells[1, 4] = "Журнал переключений по " + cbObjectGroup.Text;
                objWorkSheet.Cells[2, 4] = "за период с " + tbStart.Text + " по " + tbEnd.Text;
                objWorkSheet.Cells[3, 4] = "параметр -  " + cbParameters.Text;

                objWorkSheet.Cells[5, 1] = "Время";

                for (int i = 0; i < selectedObjs.Length; i++)
                {
                    objWorkSheet.Cells[5, 2 + i] = selectedObjs[i][1];
                }
                objWorkSheet.Cells[5, 2 + selectedObjs.Length] = "Переключение";

                for (int i = 0; i < itogData.Count; i++)
                {
                    for (int k = 0; k < itogData[i].Length; k++)
                        objWorkSheet.Cells[6 + i, 1 + k] = itogData[i][k];
                    objWorkSheet.Cells[6 + i, 1 + itogData[i].Length] = scheduleList[i];
                }

                try
                {

                    selectedRange = (Range)objWorkSheet.get_Range("B6", GetLetterBy(selectedObjs.Length + 1) + (5 + itogData.Count));
                    shapes = objWorkSheet.Shapes;
                    shapes.AddChart(XlChartType: XlChartType.xlLine,
                        Left: 450, Top: 70, Width: 750,
                        Height: 400).Select();

                    chart = objExcel.ActiveChart;
                    chart.SetSourceData(selectedRange); 
                }
                finally
                {
                    if (chartTitle != null) Marshal.ReleaseComObject(chartTitle);
                    if (chart != null) Marshal.ReleaseComObject(chart);
                    if (shapes != null) Marshal.ReleaseComObject(shapes);
                    if (selectedRange != null) Marshal.ReleaseComObject(selectedRange);
                } 

                objWorkBook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                   XlSaveAsAccessMode.xlShared, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                MessageBox.Show("Файл - " + fileName + " успешно сохранен");
                formed = false;
            }
            finally
            {
                saveFileDialog1.Dispose();

                if (objWorkSheet != null) { Marshal.ReleaseComObject(objWorkSheet); }
                if (objWorkBook != null) { objWorkBook.Close(); Marshal.ReleaseComObject(objWorkBook); }
                if (objExcel != null) { Marshal.ReleaseComObject(objExcel); }
            }
        }

        private string GetLetterBy(int p)
        {
            switch (p)
            {
                case 1: { return "A"; }
                case 2: { return "B"; }
                case 3: { return "C"; }
                case 4: { return "D"; }
                case 5: { return "E"; }
                case 6: { return "F"; }
                case 7: { return "G"; }
                case 8: { return "H"; }
                case 9: { return "I"; }
                case 10: { return "J"; }
                case 11: { return "K"; }
                case 12: { return "L"; }
                case 13: { return "M"; }
                case 14: { return "N"; }
                case 15: { return "O"; }
                case 16: { return "P"; }
                case 17: { return "Q"; }
            }
            return "B";
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
            if (formed && DialogResult.Yes != MessageBox.Show("Вы действительно хотите рассчитать форму?",
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

            if (String.IsNullOrEmpty(cbObjectGroup.Text))
            {
                MessageBox.Show("Выберите объект измерений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (metrixs == null || metrixs.Length == 0)
            {
                MessageBox.Show("Вначале необходимо выполнить расчеты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedObjs == null || selectedObjs.Length == 0)
            {
                selectedObjs = DataHelper.GetEntityByGroup(cbObjectGroup.Text);
            }
            if (selectedObjs == null || selectedObjs.Length == 0)
            {
                MessageBox.Show("У группы '" + cbObjectGroup.Text + "' нет объектов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            itogData.Clear();
            using (var con = DataHelper.OpenOrCreateDb())
            {
                try
                {
                    List<object> data = new List<object>();
                    for (var i = trackStart.Value; i <= trackEnd.Value; i++)
                    {
                        data.Clear();
                        data.Add(metrixs[i]);
                        data.AddRange(selectedObjs.Select(s => DataHelper.GetMetrix((int)s[0], cbParameters.Text,
                                                    metrixs[i], rbTime.Checked, con)));
                        itogData.Add(data.ToArray());
                    }
                }
                finally { con.Close(); }
            }
            formed = true;
            scheduleList.Clear();
            int pos = 0;
            int interval = (int)DataHelper.GetSettingValue("RangeSchedule");
            int stopInt = interval < 3? 3 : interval;
            for (var i = 0; i < itogData.Count; i++)
            {
                if (stopInt > 0)
                {
                    scheduleList.Add((string)selectedObjs[pos][1]);
                    stopInt--;
                    continue;
                }

                decimal delta = 0;
                int newpos = pos;
                for (int j = 1; j <= selectedObjs.Length; j++)
                {
                    try
                    {
                        if (j == pos) { continue; }
                        decimal d = 0;
                        decimal sum = 0;
                        for (int k = 1; k <= interval; k++)
                        {
                            sum = (decimal)itogData[i - k][j];
                        }
                        if ((decimal)itogData[i][j] == 0)
                        {
                            d = (decimal)itogData[i][j] != (decimal)itogData[i - 1][j] ? 1 : 0;
                            if (sum == 0)
                            {
                                newpos = 0;
                            }
                        }
                        else
                        {
                            d = ((decimal)itogData[i][j] - sum / interval) / (decimal)itogData[i][j];
                        }
                        if (delta < d && (double)d > 0.1)
                        {
                            newpos = j - 1;
                            delta = d;
                        }
                    }
                    catch { continue; }
                }

                if (newpos != pos) {
                    pos = newpos;
                    stopInt = interval;
                }
                scheduleList.Add((string)selectedObjs[pos][1]);
            }

            PrepareViews();
        }

        private void PrepareViews()
        {
            mainView.Columns.Clear();
            chartControl.Series.Clear();

            System.Windows.Forms.DataVisualization.Charting.Series s = null;

            for (int j = 0; j <= selectedObjs.Length + 1; j++)
            {
                GridColumn unbColumn = mainView.Columns.AddField("col" + j);
                unbColumn.VisibleIndex = mainView.Columns.Count;
                unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                unbColumn.OptionsColumn.AllowEdit = false;
                unbColumn.AppearanceCell.BackColor = Color.LemonChiffon;
                if (j > selectedObjs.Length)
                {
                    unbColumn.Caption = "Переключение";
                }
                else
                {
                    unbColumn.Caption = j == 0 ? "Время" : (string)selectedObjs[j - 1][1];
                }
                mainView.CustomUnboundColumnData += CustomUnboundColumnDataMainView;

                if (j > 0 && j <= selectedObjs.Length)
                {
                    s = new System.Windows.Forms.DataVisualization.Charting.Series();
                    s.Name = unbColumn.Caption;
                    s.ChartType = SeriesChartType.FastLine;
                    chartControl.Series.Add(s);
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
            }

            grid.DataSource = itogData;
        }

        private void CustomUnboundColumnDataMainView(object sender, CustomColumnDataEventArgs e)
        {
            try
            {
                e.Value = itogData.ElementAt(e.ListSourceRowIndex)[e.Column.AbsoluteIndex];
            }
            catch {
                try
                {
                    e.Value = scheduleList.ElementAt(e.ListSourceRowIndex);
                }
                catch { e.Value = string.Empty; }
            }
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

            tbEnd.Text = metrixs.Length <= trackEnd.Value ? "-" : metrixs[trackEnd.Value].ToString();
        }

    }
}
