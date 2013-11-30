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
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Design
{
    public partial class SwitchReportForm : UserControl
    {
        private object[][] objects;
        private object[][] parameters;
        private bool formed;
        private object[] metrixs;
        private object[][] dataMetrixs;

        public SwitchReportForm()
        {
            InitializeComponent();

            objects = DataHelper.GetObjectsWithGroups();
            parameters = DataHelper.GetParameters();

            objectsList.DataSource = objects;
            objectsView.CustomUnboundColumnData += new CustomColumnDataEventHandler((sender, e) => UnboundColumnData(sender, e, objects));
            objectsView.CellValueChanging += OnObjectSelected;

            cbParameters.Items.Clear();
            cbParameters.Items.AddRange(parameters.Select(p => ((object[])p)[1]).ToArray());

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
            if (cbParameters.Text == string.Empty)
            {
                MessageBox.Show("Выберите параметр измерения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var selectedObj = objects.Where(o => (bool)((object[])o)[2]).Select(o => (int)((object[])o)[0]).ToArray();
            if (selectedObj.Count() != 1)
            {
                MessageBox.Show("Выберите один объект измерений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            metrixs = DataHelper.GetMetrixByTimeConditions(cbParameters.Text, selectedObj, rbTime.Checked);
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
            if (!formed)
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

                var selectedObj = objects.Where(o => (bool)((object[])o)[2]).Select(o => (string)((object[])o)[1]).FirstOrDefault();
                string title = String.IsNullOrEmpty(selectedObj) ? "Unknown" : selectedObj;

                objWorkBook = objExcel.Workbooks.Add(System.Reflection.Missing.Value);
                objWorkSheet = objExcel.ActiveSheet as Worksheet;
                objWorkSheet.Cells[1, 4] = "Отчет по скважине " + title;
                objWorkSheet.Cells[2, 4] = "за период с " + tbStart.Text + " по " + tbEnd.Text;
                objWorkSheet.Cells[3, 4] = "параметр -  " + cbParameters.Text;

                objWorkSheet.Cells[5, 1] = "Время";
                objWorkSheet.Cells[5, 2] = "Значение";

                for (int i = 0; i < dataMetrixs.Length; i++)
                {
                    long value = 0;
                    if (!Int64.TryParse(dataMetrixs[i][0].ToString(), out value))
                    {
                        value = -1;
                    }

                    string strValue = value == -1 ? (string)dataMetrixs[i][0] : value.ToString();

                    objWorkSheet.Cells[6 + i, 1] = strValue;
                    objWorkSheet.Cells[6 + i, 2] = dataMetrixs[i][1];                    
                }

                try
                {

                    selectedRange = (Range)objWorkSheet.get_Range("B6", "B" + (5 + dataMetrixs.Length));
                    shapes = objWorkSheet.Shapes;
                    shapes.AddChart(XlChartType: XlChartType.xlLine,
                        Left: 150, Top: 70, Width: 750,
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
            finally { 
                saveFileDialog1.Dispose();

                if (objWorkSheet != null) { Marshal.ReleaseComObject(objWorkSheet); }
                if (objWorkBook != null) { objWorkBook.Close(); Marshal.ReleaseComObject(objWorkBook); }
                if (objExcel != null) { Marshal.ReleaseComObject(objExcel); }
            }
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
                MessageBox.Show("Выберите один объект измерений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            chartControl.Series.Clear();
            mainView.Columns.Clear();
            System.Windows.Forms.DataVisualization.Charting.Series s = null;

            try
            {
                dataMetrixs = DataHelper.GetMetrixByAllConditions(cbParameters.Text, selectedObj, rbTime.Checked, metrixs[trackStart.Value], metrixs[trackEnd.Value]);
            }
            catch {
                dataMetrixs = new object[][] { };
                MessageBox.Show("Нет рассчитанных данных.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (dataMetrixs[0].Length == 0)
                {
                    MessageBox.Show("Нет рассчитанных данных.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch {
                MessageBox.Show("Нет рассчитанных данных.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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
                    var title = selectedObj[j-1].ToString();
                    object[] t = objects.FirstOrDefault(o => (int)o[0] == selectedObj[j-1]);
                    if (t != null)
                    {
                        title = t[1].ToString();
                    }
                    unbColumn.Caption = title;
                    s = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            tbEnd.Text = metrixs[trackEnd.Value].ToString();
        }

    }
}
