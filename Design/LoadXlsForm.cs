using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using DevExpress.XtraTab;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Base;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Data.SqlClient;

namespace Design
{
    public partial class LoadXlsForm : DevExpress.XtraEditors.XtraUserControl
    {
        List<object[][]> list;
        ContextMenu menu;
        int timeColumn;
        Dictionary<int, string> objectColumns;
        List<int> paramColumns;
        Dictionary<string, int> param;
        Dictionary<string, int> objects;


        public LoadXlsForm()
        {
            InitializeComponent();
            xlsFileDialog.DefaultExt = "xls";
            xlsFileDialog.Filter = "Excel Files(*.xls)|*.XLS|Excel 2007 Files(*.xlsx; *.xlsm)|*.XLSX; *.XLSM|All files (*.*)|*.*";
            closeButton.Click += OnCloseClick;
            fileNamebuttonEdit.ButtonClick += OnButtonClick;
            xlsFileDialog.FileOk += OnSelectFileToLoad;

            param = new Dictionary<string, int>();
            objects = new Dictionary<string, int>();

            list = new List<object[][]>();

            menu = new ContextMenu();
            menu.MenuItems.Add(0, new MenuItem("Учитывать параметром", AddColumnParameter));
            menu.MenuItems.Add(1, new MenuItem("Учитывать как время", AddColumnTime));

            List<MenuItem> objectMenu = new List<MenuItem>();
            foreach (var g1 in DataHelper.GetObjectsWithGroups().GroupBy(o => o[3]))
            {
                objectMenu.Add(new MenuItem((string)g1.Key, g1.GroupBy(t => t[4]).
                            Select(t2 => new MenuItem((string)t2.Key, 
                            t2.Select(t3 => new MenuItem((string)t3[1], (_,__) => AddColumnObject((string)t3[1]))).ToArray())).ToArray()));
            }
            menu.MenuItems.Add(2, new MenuItem("Учитывать как объект", objectMenu.ToArray()));
            
            menu.MenuItems.Add(3, new MenuItem("Сбросить объекты", ClearColumnObject));
            menu.MenuItems.Add(4, new MenuItem("Сбросить параметры", ClearColumnParameter));
            menu.MenuItems.Add(5, new MenuItem("Сбросить время", ClearColumnTime));

            paramShName.Click += OnParamShNameClick;
            timeShName.Click += OnTimeShNameClick;
            paramManual.Click += ParamManualClick;
            timeManual.Click += TimeManualClick;

            loadButton.Click += OnLoadButtonClick;

            timeColumn = -1;
            objectColumns = new Dictionary<int, string>();
            paramColumns = new List<int>();

            tbParamEnter.Properties.Items.AddRange( DataHelper.GetParameters().Select(p1 => p1[1]).ToArray());
        }

        private void ParamManualClick(object sender, EventArgs e)
        {
            tbParamEnter.Text = string.Empty;
            tbParamEnter.Enabled = true;
            paramColumns.Clear();
            var v = GetActiveView();
            if (v == null) { return; }
            v.RefreshData();
        }


        private void TimeManualClick(object sender, EventArgs e)
        {
            tbTimeEnter.Text = string.Empty;
            tbTimeEnter.Enabled = true;
            timeColumn = -1;
            var v = GetActiveView();
            if (v == null) { return; }
            v.RefreshData();
        }

        private void OnLoadButtonClick(object sender, EventArgs e)
        {
            if (timeShName.Checked == false && timeColon.Checked == false && timeManual.Checked == false)
            {
                MessageBox.Show("Не определен источник данных 'О времени замеров'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (paramShName.Checked == false && paramColon.Checked == false && paramManual.Checked == false)
            {
                MessageBox.Show("Не определен источник данных 'О типах замеров'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(tbObjectEnter.Text))
            {
                MessageBox.Show("Не определен источник данных 'Об объектах замеров'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<Triplet> triplets = new List<Triplet>();
            using (var con = DataHelper.OpenOrCreateDb())
            {
                triplets = PrepareTriplets(con);
                DataHelper.LoadTriplets(triplets, con);
            }
            MessageBox.Show(string.Format("Загружено {0} измерений.", triplets.Count), "Загрузка звершена.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Dispose();
        }

        private List<Triplet> PrepareTriplets(SqlConnection con)
        {
            List<Triplet> result = new List<Triplet>();
            int gridId = tabBar.SelectedTabPageIndex;

            string timeObject = string.Empty;
            string parameter = string.Empty;
            string entity = string.Empty;

            decimal value = 0;
            bool fixTime = timeManual.Checked || timeShName.Checked;
            bool fixParam = paramManual.Checked || paramShName.Checked;


            if (!fixTime || !fixParam)
            {
                if (list[gridId].Length > 1)
                {
                    for (var i = 1; i < list[gridId].Length; i++)
                    {
                        timeObject = fixTime ? tbTimeEnter.Text : ((string)list[gridId][i][timeColumn - 1]).PadLeft(8, '0');

                        object[] t = GetDatas((string[])list[gridId][i], fixParam, (string[])list[gridId][0]);
                        foreach (object[] o in t)
                        {
                            result.Add(new Triplet(GetObject((string)o[0], con),
                                                   GetParameter((string)o[1], con),
                                                   timeObject,
                                                   (decimal)o[2]));
                        }
                    }
                }
            }
            else
            {
                result.Add(new Triplet(GetObject(tbObjectEnter.Text, con), GetParameter(tbParamEnter.Text, con),
                                       tbTimeEnter.Text, value));
            }

            // list[gridId][e.ListSourceRowIndex][e.Column.AbsoluteIndex];
            return result;
        }

        private object[] GetDatas(string[] data, bool fixParam, string[] titles)
        {
            List<object[]> result = new List<object[]>();
            int count;
            decimal value = 0;
            if (objectColumns.Count == 1)
            {
                if (paramColumns.Count > 0)
                {
                    var stringObject = data[objectColumns.First().Key - 1];
                    for (int i = 0; i < paramColumns.Count; i++)
                    {
                        count = paramColumns[i] - 1;
                        if (!Decimal.TryParse(data[count], out value))
                        {
                            value = 0;
                        }
                        result.Add(new object[] { stringObject, titles[count], value });
                    }
                    return result.ToArray();
                }
                else
                {
                    foreach (var key in  objectColumns.Keys)
                    {
                        if (!Decimal.TryParse(data[key - 1], out value))
                        {
                            value = 0;
                        }
                        result.Add(new object[] { objectColumns[key], tbParamEnter.Text, value });
                    }
                    return result.ToArray();
                }
            }
            if (fixParam || paramColumns.Count == 1)
            {
                if (objectColumns.Count > 0)
                {
                    var stringParam = !fixParam ? data[paramColumns[0] - 1] : tbParamEnter.Text;
                    foreach(int key in objectColumns.Keys)
                    {
                        if (!Decimal.TryParse(data[key - 1], out value))
                        {
                            value = 0;
                        }

                        result.Add(new object[] { objectColumns[key], stringParam, value });
                    }
                    return result.ToArray();
                }
                else
                {
                    for (var i = 0; i < paramColumns.Count; i++)
                    {
                        count = paramColumns[i] - 1;
                        if (!Decimal.TryParse(data[count], out value))
                        {
                            value = 0;
                        }
                        result.Add(new object[] { tbObjectEnter.Text, titles[count], value });
                    }
                    return result.ToArray();
                }
            }
            return result.ToArray();
        }

        private int GetParameter(string key, SqlConnection con)
        {
            if (param.ContainsKey(key))
            {
                return param[key];
            }
            return DataHelper.GetParameter(key, con);
        }

        private int GetObject(string key, SqlConnection con)
        {
            if (objects.ContainsKey(key))
            {
                return objects[key];
            }
            return DataHelper.GetObject(key, con);
        }

        private void OnTimeShNameClick(object sender, EventArgs e)
        {
            if (tabBar.TabPages.Count == 0) { return; }

            tbTimeEnter.Text = tabBar.SelectedTabPage.Text;
            tbTimeEnter.Enabled = false;
            if (paramShName.Checked)
            {
                tbParamEnter.Text = string.Empty;
                tbParamEnter.Enabled = false;
                paramShName.Checked = false;
            }
            timeColumn = -1;
            GetActiveView().RefreshData();

        }

        private void OnParamShNameClick(object sender, EventArgs e)
        {
            if (tabBar.TabPages.Count == 0) { return; }

            tbParamEnter.Text = tabBar.SelectedTabPage.Text;
            tbParamEnter.Enabled = false;
            if (timeShName.Checked)
            {
                tbTimeEnter.Text = string.Empty;
                tbTimeEnter.Enabled = false;
                timeShName.Checked = false;
            }
            paramColumns.Clear();
            GetActiveView().RefreshData();
        }

        private void ClearColumnTime(object sender, EventArgs e)
        {
            tbTimeEnter.Enabled = false;
            tbTimeEnter.Text = string.Empty;
            timeColon.Checked = false;
            timeColumn = -1;
            GetActiveView().RefreshData();
        }

        private void ClearColumnParameter(object sender, EventArgs e)
        {
            tbParamEnter.Enabled = false;
            tbParamEnter.Text = string.Empty;
            paramColon.Checked = false;
            paramColumns.Clear();
            GetActiveView().RefreshData();
        }

        private void ClearColumnObject(object sender, EventArgs e)
        {
            tbObjectEnter.Enabled = false;
            tbObjectEnter.Text = string.Empty;
            objectColumns.Clear();
            GetActiveView().RefreshData();
        }

        private void AddColumnObject(string objectName)
        {
            var view = GetActiveView();
            if (view == null) { return; }
            var cells = view.FocusedColumn;

            if (cells == null) { return; }
            string index = (cells.AbsoluteIndex + 1) + " ";

            if ( tbParamEnter.Text.IndexOf(index) > -1)
            {
                tbParamEnter.Enabled = false;
                tbParamEnter.Text = string.Empty;
            }

            if (timeColon.Checked && tbTimeEnter.Text.IndexOf(index) > -1)
            {
                tbTimeEnter.Text = string.Empty;
                tbTimeEnter.Enabled = false;
                timeColon.Checked = false;
            }

            if (string.IsNullOrEmpty(tbObjectEnter.Text) || paramColumns.Count > 1)
            {
                tbObjectEnter.Text = objectName;
                objectColumns.Clear();
                objectColumns.Add(cells.AbsoluteIndex + 1, objectName);
                view.RefreshData();
                return;
            }
            if (objectColumns.ContainsKey(cells.AbsoluteIndex + 1))
            {
                return;
            }
            tbObjectEnter.Text += " " + objectName;
            objectColumns.Add(cells.AbsoluteIndex + 1, objectName);
            view.RefreshData();
        }

        private GridView GetActiveView()
        {
            try
            {
                return ((GridControl)(tabBar.SelectedTabPage.Controls[0])).MainView as GridView;
            }
            catch { return null; }
        }

        private void AddColumnTime(object sender, EventArgs e)
        {
            var view = GetActiveView();
            if (view == null) { return; }
            var cells = view.FocusedColumn;

            if (cells == null) { return; }
            string index = (cells.AbsoluteIndex + 1).ToString();

            if (paramColon.Checked && tbParamEnter.Text.IndexOf(index) > -1)
            {
                tbParamEnter.Enabled = false;
                tbParamEnter.Text = string.Empty;
                paramColon.Checked = false;
            }

            if (tbObjectEnter.Text.IndexOf(index) > -1)
            {
                tbObjectEnter.Text = string.Empty;
                tbObjectEnter.Enabled = false;
            }

            tbTimeEnter.Enabled = false;
            timeColon.Checked = true;
            tbTimeEnter.Text = index;
            timeColumn = cells.AbsoluteIndex + 1;
            view.RefreshData();
        }

        private void AddColumnParameter(object sender, EventArgs e)
        {
            var view = GetActiveView();
            if (view == null) { return; }
            var cells = view.FocusedColumn;

            if (cells == null) { return; }
            string index = (cells.AbsoluteIndex + 1).ToString() + " ";

            if (timeColon.Checked && tbTimeEnter.Text.IndexOf(index) > -1)
            {
                tbTimeEnter.Enabled = false;
                tbTimeEnter.Text = string.Empty;
                timeColon.Checked = false;
            }

            if (tbObjectEnter.Text.IndexOf(index) > -1)
            {
                tbObjectEnter.Text = string.Empty;
                tbObjectEnter.Enabled = false;
            }

            tbParamEnter.Enabled = false;
            paramColon.Checked = true;
            if (string.IsNullOrEmpty(tbParamEnter.Text) || objectColumns.Count > 1)
            {
                tbParamEnter.Text = index;
                paramColumns.Clear();
                paramColumns.Add(cells.AbsoluteIndex + 1);
                view.RefreshData();
                return;
            }
            if (tbParamEnter.Text.IndexOf(index) > -1)
            {
                return;
            }
            tbParamEnter.Text += index;
            paramColumns.Add(cells.AbsoluteIndex + 1);
            view.RefreshData();
        }

        private void OnButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            xlsFileDialog.ShowDialog(this);
            if (!string.IsNullOrEmpty(xlsFileDialog.FileName))
            {
                fileNamebuttonEdit.Text = xlsFileDialog.FileName;
            }
        }

        private void OnSelectFileToLoad(object sender, CancelEventArgs e)
        {
            if (tabBar.TabPages.Count > 0 &&
                DialogResult.Yes != MessageBox.Show("Система уже работает с файлом данных. \n\r Продолжить загрузку выбранного",
                "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            paramShName.Enabled = false;
            timeShName.Enabled = false;
            tbObjectEnter.Text = string.Empty;
            tbParamEnter.Text = string.Empty;
            tbTimeEnter.Text = string.Empty;
            tbObjectEnter.Enabled = false;
            tbParamEnter.Enabled = false;
            tbTimeEnter.Enabled = false;
            paramColon.Checked = false;
            paramManual.Checked = false;
            paramShName.Checked = false; 

            using (var odbcCon = new OleDbConnection(DataHelper.GetConnectionString(xlsFileDialog.FileName)))
            {
                try
                {
                    odbcCon.Open();
                }
                catch
                {
                    MessageBox.Show("Проверьте входные данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                tabBar.TabPages.Clear();

                var schemaTable = odbcCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                                                        new object[] { null, null, null, "TABLE" });
                list.Clear();
                int index = 0;
                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    try
                    {
                        var sheet1 = (string)schemaTable.Rows[i].ItemArray[2];
                        string select = String.Format("SELECT * FROM [{0}]", sheet1);
                        var ad = new OleDbDataAdapter(select, odbcCon);
                        var ds = new DataSet("EXCEL");
                        ad.Fill(ds);
                        DataTable tb = ds.Tables[0];
                        if (tb.Rows == null || tb.Rows.Count < 4)
                        {
                            continue;
                        }
                        var data = tb.Rows.OfType<DataRow>().Select(r => r.ItemArray.
                                    Select(col => col == null ? string.Empty : col.ToString()).
                                    ToArray()).ToArray();
                        list.Add(data);

                        var tabPage = new XtraTabPage() { Text = sheet1, Tag = index };

                        var grid = new GridControl();
                        var gridView = new GridView();
                        gridView.OptionsView.ShowColumnHeaders = false;
                        gridView.OptionsView.ShowGroupedColumns = false;
                        gridView.OptionsView.ShowGroupPanel = false;
                        grid.Dock = DockStyle.Fill;

                        grid.MainView = gridView;
                        grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                            gridView});
                        gridView.GridControl = grid;

                        gridView.MouseUp += OnViewMouseUp;
                        gridView.CustomDrawCell += CustomDrawCell;

                        for (int j = 0; j < tb.Columns.Count; j++)
                        {
                            GridColumn unbColumn = gridView.Columns.AddField("col" + j);
                            unbColumn.VisibleIndex = gridView.Columns.Count;
                            unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                            unbColumn.OptionsColumn.AllowEdit = false;
                            unbColumn.AppearanceCell.BackColor = Color.LemonChiffon;
                        }

                        grid.DataSource = data;

                        gridView.CustomUnboundColumnData += (_, ev) => CustomUnboundColumnData(
                           (int)tabPage.Tag, ev);
                        index++;

                        tabPage.Controls.Add(grid);
                        tabBar.TabPages.Add(tabPage);
                    }
                    catch
                    {
                    }
                }
                odbcCon.Close();
            }
            if (tabBar.TabPages.Count > 0)
            {
                paramShName.Enabled = true;
                timeShName.Enabled = true;
            }
        }

        private void CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {

            if (e.Column.AbsoluteIndex + 1 == timeColumn)
            {
                e.Column.AppearanceCell.BackColor = Color.FromArgb(214, 251, 254);
                return;
            }
            if (objectColumns.ContainsKey(e.Column.AbsoluteIndex + 1))
            {
                e.Column.AppearanceCell.BackColor = Color.FromArgb(253, 223, 239);
                return;
            }
            if (paramColumns.Contains(e.Column.AbsoluteIndex + 1))
            {
                e.Column.AppearanceCell.BackColor = Color.FromArgb(194, 206, 252);
                return;
            }
            e.Column.AppearanceCell.BackColor = Color.LemonChiffon;
        }

        private void OnViewMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) { return; }

            GridView view = sender as GridView;
            if (view == null) { return; }

            GridHitInfo info = view.CalcHitInfo(e.Location);
            if (!info.InRowCell && !info.InRow)
            {
                return;
            }
            menu.Show(tabBar, e.Location);
        }

        private void CustomUnboundColumnData(int gridId, CustomColumnDataEventArgs e)
        {
            e.Value = list[gridId][e.ListSourceRowIndex][e.Column.AbsoluteIndex];
        }

        private void OnCloseClick(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы действительно хотите закрыть форму загрузки?",
                "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Dispose();
            }
        }
    }
}
