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
        private object[][] dataMetrixs;
        List<string> supportTimes;

        public SwitchReportForm()
        {
            InitializeComponent();

            objects = DataHelper.GetObjectsWithGroups();
            parameters = DataHelper.GetParameters();
            object[] dg = parameters.FirstOrDefault(p => p[1].ToString() == "Дебит газа");
            if (dg != null) { dg[2] = true; }

            objectsList.DataSource = objects;
            objectsView.CustomUnboundColumnData += new CustomColumnDataEventHandler((sender, e) => UnboundColumnData(sender, e, objects));
            objectsView.Columns["cLicField"].GroupIndex = 0;
            objectsView.Columns["cBranch"].GroupIndex = 1;
            objectsView.FocusedRowChanged += OnObjectSelected;

            parametersList.DataSource = parameters;
            parametersView.CustomUnboundColumnData += new CustomColumnDataEventHandler((sender, e) => UnboundColumnData(sender, e, parameters));
            parametersView.CellValueChanging += OnParameterSelected;
            parametersView.FocusedRowChanged += CheckRowChanged;
            parametersView.FocusedColumnChanged += CheckColumnChanged;
           
            runButton.Click += OnRunButtonClick;
            closeButton.Click += OnCloseButtonClick;
            importButton.Click += OnImportButtonClick;

            mainView.CustomUnboundColumnData += OnMainViewCustomUnboundData;

            initTimeIntervals();
        }

        private void OnMainViewCustomUnboundData(object sender, CustomColumnDataEventArgs e)
        {
            try
            {
                e.Value = dataMetrixs[e.ListSourceRowIndex][e.Column.AbsoluteIndex];
            }
            catch { e.Value = string.Empty; }
        }

        private void CheckRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            view.OptionsBehavior.Editable = parameters[view.FocusedRowHandle][1].ToString() != "Дебит газа";
        }

        private void CheckColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            view.OptionsBehavior.Editable = parameters[view.FocusedRowHandle][1].ToString() != "Дебит газа";
        }

        private void OnParameterSelected(object sender, CellValueChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            parameters[view.FocusedRowHandle][2] = (bool)e.Value;
        }

        private void OnObjectSelected(object sender, FocusedRowChangedEventArgs e)
        {
            object[] o = (object[])objectsView.GetRow(e.FocusedRowHandle);
            List<string> allTimes = DataHelper.GetAllDistinctMetrixObject((int)o[0]);

            supportTimes = allTimes.Count < 6 ? allTimes : allTimes.Where((s, i) => i % 6 == 0 || i == allTimes.Count - 1).ToList();

            timeInterval.TickCount = supportTimes.Count();
            if (timeInterval.TickCount >= 2)
            {
                timeInterval.Up = timeInterval.TickCount - 2;
                timeInterval.Down = timeInterval.TickCount - 1;
            }
        }

        void OnTimeIntervalChanged(object sender, int min, int max)
        {
            if (min == -1 || max == -1) return;
            intervalLabel.Text = "Интервал времени: [" + supportTimes[min] + "; " + supportTimes[max] + "]";
        }

        private void initTimeIntervals()
        {
            timeInterval.OnIntervalChanged += OnTimeIntervalChanged;
            object[] o = (object[])objectsView.GetFocusedRow();
            List<string> allTimes = DataHelper.GetAllDistinctMetrixObject((int)o[0]);
            supportTimes = allTimes.Where((s, i) => i % 30 == 0 || i == allTimes.Count - 1).ToList();

            timeInterval.TickCount = supportTimes.Count();
            if (timeInterval.TickCount >= 2)
            {
                timeInterval.Up = timeInterval.TickCount - 2;
                timeInterval.Down = timeInterval.TickCount - 1;
            }
        }

        private void OnImportButtonClick(object sender, EventArgs e)
        {
            if (dataMetrixs == null || dataMetrixs.Length == 0)
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

                object[] o = (object[])objectsView.GetFocusedRow();
                object[][] selParams = parameters.Where(p => (bool)((object[])p)[2]).ToArray();

                object[] group = DataHelper.GetObjectWithGroups((int)o[0]);

                objWorkSheet = (Worksheet)objWorkBook.Worksheets.get_Item(1);
                objWorkSheet.Name = "Титульный лист";

                objWorkSheet.Range[objWorkSheet.Cells[1, 1], objWorkSheet.Cells[1, 7]].Merge();

                Range r = (Range)objWorkSheet.Cells[1, 1];
                r.Value2 = "Отчет по событиям на скважине";
                r.ColumnWidth = 130;
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                objWorkSheet.Range[objWorkSheet.Cells[2, 2], objWorkSheet.Cells[2, 7]].Merge();
                r = (Range)objWorkSheet.Cells[2, 2];
                r.Value2 = group[0];
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                objWorkSheet.Range[objWorkSheet.Cells[3, 2], objWorkSheet.Cells[3, 7]].Merge();
                r = (Range)objWorkSheet.Cells[3, 2];
                r.Value2 = group[1];
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                objWorkSheet.Range[objWorkSheet.Cells[4, 2], objWorkSheet.Cells[4, 7]].Merge();
                r = (Range)objWorkSheet.Cells[4, 2];
                r.Value2 = (string)o[1];
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                objWorkSheet.Range[objWorkSheet.Cells[5, 2], objWorkSheet.Cells[5, 7]].Merge();
                r = (Range)objWorkSheet.Cells[5, 2];
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r.Value2 = timeInterval.Down < timeInterval.Up
                        ? "c " + supportTimes[timeInterval.Down] + "   по   " + supportTimes[timeInterval.Up]
                        : "c " + supportTimes[timeInterval.Up] + "   по   " + supportTimes[timeInterval.Down];

                r = (Range)objWorkSheet.Cells[2, 1];
                r.Value2 = "Лицензионный участок";
                r.ColumnWidth = 25;

                r = (Range)objWorkSheet.Cells[3, 1];
                r.Value2 = "Куст";

                r = (Range)objWorkSheet.Cells[4, 1];
                r.Value2 = "Скважина";

                r = (Range)objWorkSheet.Cells[5, 1];
                r.Value2 = "Отчетный период";

                r = (Range)objWorkSheet.Range[objWorkSheet.Cells[1, 1], objWorkSheet.Cells[5, 7]];
                Microsoft.Office.Interop.Excel.Borders borders = r.Borders;
                borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                borders[ Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle =  Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                borders[ Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle =  Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                borders[ Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle =  Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                borders[ Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle =  Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                borders = null;

                objWorkSheet = (Worksheet)objWorkBook.Worksheets.get_Item(2);
                objWorkSheet.Name = "Значения параметров";

                objWorkSheet.Range[objWorkSheet.Cells[1, 1], objWorkSheet.Cells[1, 10]].Merge();
                r = (Range)objWorkSheet.Cells[1, 1];
                r.Value2 = "Вычисленные и замеренные дебиты за отчетный период";
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                objWorkSheet.Range[objWorkSheet.Cells[2, 1], objWorkSheet.Cells[3, 1]].Merge();
                r = (Range)objWorkSheet.Cells[2, 1];
                r.Value2 = "Дата";
                r.ColumnWidth = 10;
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                objWorkSheet.Range[objWorkSheet.Cells[2, 2], objWorkSheet.Cells[3, 2]].Merge();
                r = (Range)objWorkSheet.Cells[2, 2];
                r.Value2 = "Время";
                r.ColumnWidth = 10;
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                objWorkSheet.Range[objWorkSheet.Cells[2, 3], objWorkSheet.Cells[2, 6]].Merge();
                r = (Range)objWorkSheet.Cells[2, 3];
                r.Value2 = "Вычисленные параметры";
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                objWorkSheet.Range[objWorkSheet.Cells[2, 7], objWorkSheet.Cells[2, 10]].Merge();
                r = (Range)objWorkSheet.Cells[2, 7];
                r.Value2 = "PhaseWatcher Vx";
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                objWorkSheet.Range[objWorkSheet.Cells[3, 3], objWorkSheet.Cells[3, 4]].Merge();
                r = (Range)objWorkSheet.Cells[3, 3];
                r.Value2 = "Q газа";
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                objWorkSheet.Range[objWorkSheet.Cells[3, 5], objWorkSheet.Cells[3, 6]].Merge();
                r = (Range)objWorkSheet.Cells[3, 5];
                r.Value2 = "Q конденсата";
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                objWorkSheet.Range[objWorkSheet.Cells[3, 7], objWorkSheet.Cells[3, 8]].Merge();
                r = (Range)objWorkSheet.Cells[3, 7];
                r.Value2 = "Q газа";
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                objWorkSheet.Range[objWorkSheet.Cells[3, 9], objWorkSheet.Cells[3, 10]].Merge();
                r = (Range)objWorkSheet.Cells[3, 9];
                r.Value2 = "Q конденсата";
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                int index = 4;
                int qg = 0;
                int qcon = 0;
                while(qg < selParams.Length && selParams[qg][1].ToString() != "Дебит газа") {
                    qg++;
                }

                while (qcon < selParams.Length && selParams[qcon][1].ToString() != "Дебит конодецата")
                {
                    qcon++;
                }

                foreach (object[] do1 in dataMetrixs)
                {
                    DateTime data = (DateTime)do1[0];
                    
                    r = (Range)objWorkSheet.Cells[index, 1];
                    r.Value2 = data.ToShortDateString();

                    r = (Range)objWorkSheet.Cells[index, 2];
                    r.Value2 = data.ToShortTimeString();

                    objWorkSheet.Range[objWorkSheet.Cells[index, 3], objWorkSheet.Cells[index, 4]].Merge();
                    r = (Range)objWorkSheet.Cells[index, 3];
                    r.Value2 = qg >= selParams.Length ? "нет замера" : do1[qg + 1];
                    r.HorizontalAlignment = qg >= selParams.Length
                        ? Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        : Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;


                    objWorkSheet.Range[objWorkSheet.Cells[index, 5], objWorkSheet.Cells[index, 6]].Merge();
                    r = (Range)objWorkSheet.Cells[index, 5];
                    r.Value2 = qcon >= selParams.Length ? "нет замера" : do1[qcon + 1];
                    r.HorizontalAlignment = qcon >= selParams.Length
                        ? Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                        : Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

                    objWorkSheet.Range[objWorkSheet.Cells[index, 7], objWorkSheet.Cells[index, 8]].Merge();
                    r = (Range)objWorkSheet.Cells[index, 7];
                    r.Value2 = "нет замера";
                    r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    objWorkSheet.Range[objWorkSheet.Cells[index, 9], objWorkSheet.Cells[index, 10]].Merge();
                    r = (Range)objWorkSheet.Cells[index, 9];
                    r.Value2 = "нет замера";
                    r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                    index++;
                }

                r = (Range)objWorkSheet.Range[objWorkSheet.Cells[1, 1], objWorkSheet.Cells[index - 1, 10]];
                borders = r.Borders;
                borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                borders = null;

                objWorkSheet.Activate();

                objWorkSheet.Application.ActiveWindow.SplitRow = 3;
                objWorkSheet.Application.ActiveWindow.FreezePanes = true;

                objWorkSheet = (Worksheet)objWorkBook.Worksheets.get_Item(3);
                objWorkSheet.Name = "Графики";

                Worksheet objWorkSheet1 = (Worksheet)objWorkBook.Worksheets.Add(Type.Missing, objWorkSheet, Type.Missing, Type.Missing);
                objWorkSheet1.Name = "Данные замеров";

                for (int i = 0; i < selParams.Length + 1; i++ )
                {
                    
                    r = (Range)objWorkSheet1.Cells[1, i + 1];
                    r.Value2 = i == 0 ? "Время" : selParams[i - 1][1];
                    for (int row = 0; row < dataMetrixs.Length; row++)
                    {                        
                        r = (Range)objWorkSheet1.Cells[row + 2, i + 1];
                        if (i == 0)
                        {
                            r.Value2 = ((DateTime)dataMetrixs[row][i]).ToString();
                            r.ColumnWidth = 10;
                        }
                        else
                        {
                            r.Value2 = (decimal)dataMetrixs[row][i];
                        }
                    }
                }

                objWorkSheet = (Worksheet)objWorkBook.Worksheets.get_Item(3);
                objWorkSheet.Activate();

                shapes = objWorkSheet.Shapes;
                for (int i = 0; i < selParams.Length; i++)
                {
                    shapes.AddChart(XlChartType: XlChartType.xlLine,
                        Left: 0, Top: 10 + i*320, Width: 500,
                        Height: 300).Select();

                    chart = objExcel.ActiveChart;
                    string letter = GetLetterBy(2 + i);
                    var collection = (Microsoft.Office.Interop.Excel.SeriesCollection)chart.SeriesCollection();
                    var series = collection.NewSeries();
                    series.Name = selParams[i][1].ToString();
                    series.Values = objWorkSheet1.get_Range(letter + 2, letter + (dataMetrixs.Length));
                    series.XValues = objWorkSheet1.get_Range("A2", "A" + (dataMetrixs.Length));
                }

                objWorkSheet1 = (Worksheet)objWorkBook.Worksheets.Add(Type.Missing, objWorkSheet, Type.Missing, Type.Missing);
                objWorkSheet1.Name = "События";
                objWorkSheet1.Activate();

                objWorkSheet1.Range[objWorkSheet1.Cells[1, 1], objWorkSheet1.Cells[1, 9]].Merge();
                r = (Range)objWorkSheet1.Cells[1, 1];
                r.Value2 = "Отчет по событиям за отчетный период";
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                r = (Range)objWorkSheet1.Cells[2, 1];
                r.Value2 = "Дата";                

                objWorkSheet1.Range[objWorkSheet1.Cells[2, 2], objWorkSheet1.Cells[2, 5]].Merge();
                r = (Range)objWorkSheet1.Cells[2, 2];
                r.Value2 = "Событие";
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                objWorkSheet1.Range[objWorkSheet1.Cells[2, 6], objWorkSheet1.Cells[2, 9]].Merge();
                r = (Range)objWorkSheet1.Cells[2, 6];
                r.Value2 = "Комментарий";
                r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                object[][] events = timeInterval.Down < timeInterval.Up
                        ? DataHelper.GetAllEventsByObjects(new List<int>(){(int)o[0]}, 
                                                           supportTimes[timeInterval.Down], supportTimes[timeInterval.Up])
                       : DataHelper.GetAllEventsByObjects(new List<int>(){(int)o[0]}, 
                                                           supportTimes[timeInterval.Up], supportTimes[timeInterval.Down]);

                for (int i = 0; i < events.Length; i++)
                {
                    r = (Range)objWorkSheet1.Cells[3 + i, 1];
                    r.Value2 = events[i][0];
                    r.ColumnWidth = 12;
                    r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                    for (int j = 2; j < 6; j++)
                    {
                        r = (Range)objWorkSheet1.Cells[3 + i, j];
                        r.Value2 = events[i][j];
                        if (j < 4)
                        {
                            r.ColumnWidth = 12;
                            r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        }
                        else
                        {
                            r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        }
                    }
                    objWorkSheet1.Range[objWorkSheet1.Cells[3 + i, 6], objWorkSheet1.Cells[3 + i, 9]].Merge();
                }
                r = (Range)objWorkSheet1.Range[objWorkSheet1.Cells[1, 1], objWorkSheet1.Cells[2 + events.Length, 9]];
                borders = r.Borders;
                borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                borders = null;


                objWorkSheet = (Worksheet)objWorkBook.Worksheets.get_Item(1);
                objWorkSheet.Activate();

                objWorkBook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                   XlSaveAsAccessMode.xlShared, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                MessageBox.Show("Файл - " + fileName + " успешно сохранен");
            }
            finally { 
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
            if (DialogResult.Yes != MessageBox.Show("Вы действительно хотите закрыть форму?",
                "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }
            Dispose();
        }

        private void OnRunButtonClick(object sender, EventArgs e)
        {
            object[] o = (object[])objectsView.GetFocusedRow();
            object[][] selParams = parameters.Where(p => (bool)((object[])p)[2]).ToArray();

            chartsTabControl.TabPages.Clear();
            mainView.Columns.Clear();

            try
            {
                dataMetrixs = timeInterval.Down < timeInterval.Up
                   ? DataHelper.GetMetrixByAllConditions(selParams, (int)o[0], supportTimes[timeInterval.Down], supportTimes[timeInterval.Up])
                   : DataHelper.GetMetrixByAllConditions(selParams, (int)o[0], supportTimes[timeInterval.Up], supportTimes[timeInterval.Down]);
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
            
            for (int j = 0; j < selParams.Length + 1; j++)
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
                    unbColumn.Caption = selParams[j-1][1].ToString();
                    TabPage page = new TabPage();
                    page.Size = new System.Drawing.Size(645, 246);
                    page.Text = unbColumn.Caption;
                    chartsTabControl.TabPages.Add(page);

                    System.Windows.Forms.DataVisualization.Charting.Chart chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
                    chart.BorderlineColor = System.Drawing.Color.Gray;
                    chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
                    chart.BorderlineWidth = 2;
                    System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
                    System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
                    chartArea1.Name = "ChartArea1";
                    chart.ChartAreas.Add(chartArea1);
                    chart.Dock = System.Windows.Forms.DockStyle.Fill;
                    legend1.Name = "Legend1";
                    chart.Legends.Add(legend1);
                    chart.Location = new System.Drawing.Point(3, 3);
                    chart.Margin = new System.Windows.Forms.Padding(2);
                    chart.Size = new System.Drawing.Size(639, 240);
                    chart.Palette = ChartColorPalette.Berry;
                    page.Controls.Add(chart);

                    var s = new System.Windows.Forms.DataVisualization.Charting.Series();
                    s.Name = unbColumn.Caption;
                    s.ChartType = SeriesChartType.FastLine;

                    chart.Series.Add(s);

                    for (int i = 0; i < dataMetrixs.Length; i++)
                    {
                        DateTime strValue = (DateTime)dataMetrixs[i][0];
                        s.Points.AddXY(strValue, dataMetrixs[i][j]);
                    }

                }
            }

            mainView.BeginDataUpdate();
            grid.DataSource = dataMetrixs;
            mainView.EndDataUpdate();
            mainView.RefreshData();

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

        private void UnboundColumnData(object sender, CustomColumnDataEventArgs e, object[][] data)
        {
            e.Value = data[e.ListSourceRowIndex][e.Column.AbsoluteIndex];
        }
    }
}
