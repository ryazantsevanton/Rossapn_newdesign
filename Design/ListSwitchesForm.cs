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
        private List<int> selObjects;
        object[][] objects;
        List<string> supportTimes;
        object[][] journalEvents;

        public ListSwitchesForm()
        {
            InitializeComponent();
            objects = DataHelper.GetObjectsWithGroups();
            objectsList.DataSource = objects;
            objectsView.CustomUnboundColumnData += new CustomColumnDataEventHandler((sender, e) => UnboundColumnData(sender, e, objects));
            mainView.CustomUnboundColumnData += OnMainViewCustomUnboundData;
            objectsView.CellValueChanging += OnObjectSelected;

            runButton.Click += OnRunButtonClick;
            closeButton.Click += OnCloseButtonClick;
            importButton.Click += OnImportButtonClick;

            selObjects = new List<int>();
            journalEvents = new object[][] { };
            grid.DataSource = journalEvents;

            initTimeIntervals();
        }

        private void OnMainViewCustomUnboundData(object sender, CustomColumnDataEventArgs e)
        {
            try
            {
                e.Value = journalEvents[e.ListSourceRowIndex][e.Column.AbsoluteIndex];
            }
            catch {
                e.Value = string.Empty;
            }
        }

        private void OnRunButtonClick(object sender, EventArgs e)
        {
            journalEvents = timeInterval.Down < timeInterval.Up
                 ? DataHelper.GetAllEventsByObjects(selObjects, supportTimes[timeInterval.Down], supportTimes[timeInterval.Up])
                 : DataHelper.GetAllEventsByObjects(selObjects, supportTimes[timeInterval.Up], supportTimes[timeInterval.Down]);

            mainView.BeginDataUpdate();
            grid.DataSource = journalEvents;
            mainView.RefreshData();
            mainView.EndDataUpdate();

            chartControl.Series.Clear();

            System.Windows.Forms.DataVisualization.Charting.Series s = null;

            foreach(int j in selObjects)
            {
                object[] selObject = objects.First(o => (int)o[0] == j);
                s = new System.Windows.Forms.DataVisualization.Charting.Series();
                s.Name = selObject[1].ToString() + " полученное";
                s.ChartType = SeriesChartType.FastPoint;
                s.Tag = selObject[1].ToString();
              
                chartControl.Series.Add(s);
            }

            foreach (var g in journalEvents.ToArray().GroupBy(o => (string)o[0]))
            {
                string strValue = g.Key;
                foreach (var ss in chartControl.Series)
                {
                    var result = g.FirstOrDefault(v => v[1].ToString() == ss.Tag.ToString());
                    if (result != null)
                    {
                        ss.Points.AddXY(strValue, (decimal)result[5]);
                    }
                }
            } 
        }

        private void OnObjectSelected(object sender, CellValueChangedEventArgs e)
        {
            int id = (int)((object[])objectsView.GetRow(e.RowHandle))[0];
            if ((bool)e.Value)
            {
                if (!selObjects.Contains(id)) { selObjects.Add(id); }
            }
            else
            {
                if (selObjects.Contains(id)) { selObjects.Remove(id); }
            }
            List<string> allTimes = DataHelper.GetAllEventDatesByObjects(selObjects);
            supportTimes = allTimes.Count < 30 ? allTimes : allTimes.Where((s, i) => i % 30 == 0 || i == allTimes.Count - 1).ToList();

            timeInterval.TickCount = supportTimes.Count();
            if (timeInterval.TickCount >= 2)
            {
                timeInterval.Up = timeInterval.TickCount - 2;
                timeInterval.Down = timeInterval.TickCount - 1;
            }
            objects[e.RowHandle][2] = e.Value;
        }

        private void UnboundColumnData(object sender, CustomColumnDataEventArgs e, object[][] data)
        {
            e.Value = data[e.ListSourceRowIndex][e.Column.AbsoluteIndex];
        }

        private void OnImportButtonClick(object sender, EventArgs e)
        {
            if (journalEvents.Length == 0)
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

                string objectList = string.Empty;
                bool first = true;
                foreach (int j in selObjects)
                {
                    object[] selObject = objects.First(o => (int)o[0] == j);
                    if (!first) {objectList += ", "; }
                    objectList += selObject[1];
                    first = false;
                }

                objWorkSheet.Cells[1, 4] = "Журнал переключений по " + objectList;
                objWorkSheet.Cells[2, 4] = "за период с " + journalEvents.First()[0] + " по " + journalEvents.Last()[0];

                objWorkSheet.Cells[5, 1] = "   Время   ";
                objWorkSheet.Cells[5, 2] = "  Объект   ";
                objWorkSheet.Cells[5, 3] = " Измерение ";
                objWorkSheet.Cells[5, 4] = " Тип переключения ";
                objWorkSheet.Cells[5, 5] = "Ожидаемое значение";
                objWorkSheet.Cells[5, 6] = "Полученое значение";

                for (int i = 0; i < journalEvents.Length; i++)
                {
                    objWorkSheet.Cells[6 + i, 1] = journalEvents[i][0];
                    objWorkSheet.Cells[6 + i, 2] = journalEvents[i][1];
                    objWorkSheet.Cells[6 + i, 3] = journalEvents[i][2];
                    objWorkSheet.Cells[6 + i, 4] = journalEvents[i][3];
                    objWorkSheet.Cells[6 + i, 5] = journalEvents[i][4];
                    objWorkSheet.Cells[6 + i, 6] = journalEvents[i][5];
                }

                int curRow = journalEvents.Length + 10;
                int l = 0;
                foreach (var g in journalEvents.ToArray().GroupBy(o => (string)o[0]))
                {
                    DateTime pd = DateTime. Now;
                    if (DateTime.TryParse(g.Key, out pd)) {
                        objWorkSheet.Cells[curRow + l, 1] = pd;
                    }
                    else {
                        objWorkSheet.Cells[curRow + l, 1] = g.Key;
                    }
                    int k = 2;
                    foreach (var s in selObjects)
                    {
                        string selName = (string)objects.First(o => (int)o[0] == s)[1];
                        var result = g.FirstOrDefault(v => v[1].ToString() == selName);
                        if (result != null)
                        {
                            objWorkSheet.Cells[curRow + l, k] = (decimal)result[5];
                        }
                        k++;
                    }
                    l++;
                } 

                try
                {

                    shapes = objWorkSheet.Shapes;
                    shapes.AddChart(XlChartType: XlChartType.xlXYScatter,
                        Left: 0, Top: 14*curRow, Width: 750,
                        Height: 400).Select();

                    chart = objExcel.ActiveChart;
                    int let = 2;
                    var collection = (Microsoft.Office.Interop.Excel.SeriesCollection)chart.SeriesCollection();
                    foreach (var s in selObjects)
                    {
                        string letter = GetLetterBy(let);
                        var series = collection.NewSeries();
                        series.Name = (string)objects.First(o => (int)o[0] == s)[1];
                        series.Values = objWorkSheet.get_Range(letter + curRow, letter + (curRow + l - 1));
                        series.XValues = objWorkSheet.get_Range("A" + curRow, "A" + (curRow + l - 1));
                        let++;
                    }
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

        private void initTimeIntervals()
        {
            timeInterval.OnIntervalChanged += OnTimeIntervalChanged;

            List<string> allTimes = DataHelper.GetAllEventDatesByObjects(selObjects);
            supportTimes = allTimes.Where((s, i) => i % 30 == 0 || i == allTimes.Count - 1).ToList();

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

        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            Dispose();
        }

        private void PrepareViews()
        {
            mainView.Columns.Clear();
            chartControl.Series.Clear();

            System.Windows.Forms.DataVisualization.Charting.Series s = null;
        }
    }
}
