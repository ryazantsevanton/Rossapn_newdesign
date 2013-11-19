using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using Design.Infrastructure;

namespace Design
{
    public partial class EditObjectControl : UserControl
    {

        private object[][] data;
        private bool modified;

        public EditObjectControl()
        {
            InitializeComponent();

            lTitle.Text =  "Редактор Объектов";
            data = DataHelper.GetObjectStatistic();

            GridColumn unbColumn = mainView.Columns.AddField("titles");
            unbColumn.VisibleIndex = 0;
            unbColumn.Caption = "Объекты";
            unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            //Allow edit only to admin
            unbColumn.OptionsColumn.AllowEdit = Account.Current.hasPermission(Account.Actions.EditSystemEntities);
            unbColumn.AppearanceCell.BackColor = Color.LemonChiffon;

            unbColumn = mainView.Columns.AddField("counts");
            unbColumn.VisibleIndex = 1;
            unbColumn.Caption = "Связанных значений";
            unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            unbColumn.OptionsColumn.AllowEdit = false;
            unbColumn.AppearanceCell.BackColor = Color.LemonChiffon;

            unbColumn = mainView.Columns.AddField("actions");
            unbColumn.VisibleIndex = -1;
            unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            unbColumn.OptionsColumn.AllowEdit = true;
            unbColumn.AppearanceCell.BackColor = Color.LemonChiffon;

            unbColumn = mainView.Columns.AddField("Месторождение");
            unbColumn.VisibleIndex = 2;
            unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            unbColumn.OptionsColumn.AllowEdit = true;
            unbColumn.AppearanceCell.BackColor = Color.LemonChiffon;

            unbColumn = mainView.Columns.AddField("Куст");
            unbColumn.VisibleIndex = 3;
            unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            unbColumn.OptionsColumn.AllowEdit = true;
            unbColumn.AppearanceCell.BackColor = Color.LemonChiffon;

            grid.DataSource = data;

            mainView.CustomUnboundColumnData += CustomUnboundColumnData;
            mainView.RowCellStyle += OnRowStyle;
            mainView.CellValueChanged += OnValueChanged;
            mainView.ValidatingEditor += OnValidatingEditor;
            cancelButton.Click += OnCancelButtonClick;
            deleteButton.Click += OnDeleteButtonClick;
            saveButton.Click += OnSaveButtonClick;
            beAddEntity.ButtonClick += OnAddEntityButtonClick;

            //Allow edit only to admin
            cancelButton.Enabled = Account.Current.hasPermission(Account.Actions.EditSystemEntities);
            deleteButton.Enabled = Account.Current.hasPermission(Account.Actions.EditSystemEntities);
            saveButton.Enabled = Account.Current.hasPermission(Account.Actions.EditSystemEntities);

            modified = false;
        }

        private void OnRowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if ((EditAction)data[e.RowHandle][2] == EditAction.Modified)
            {
                e.Appearance.BackColor = Color.FromArgb(255, 224, 192);
                return;
            }
            if ((EditAction)data[e.RowHandle][2] == EditAction.Delete)
            {
                e.Appearance.BackColor = Color.FromArgb(224, 224, 224);
                return;
            }
            e.Appearance.BackColor = Color.LemonChiffon;
        }
        
        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            if (modified && DialogResult.Yes != MessageBox.Show("Есть несохранненные данные. Закрыть форму?",
                "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }
            Dispose();
        }

        private void OnValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {

            if (e.Value == null) return;

            for(int i =0; i< data.Length; i++)
            {
                if (data[i][0].ToString().ToLower() == e.Value.ToString().ToLower() && i != mainView.FocusedRowHandle)
                {
                    e.ErrorText = "Такой object уже существует.";
                    e.Valid = false;
                    return;
                }
            }
            e.ErrorText = string.Empty;
            e.Valid = true;
        }

        private void OnValueChanged(object sender, CellValueChangedEventArgs e)
        {
            var v = (ColumnView)sender;
            if (data[mainView.FocusedRowHandle][0].ToString().ToLower().
                Equals(v.EditingValue.ToString().ToLower())) { return; }
            data[mainView.FocusedRowHandle][2] = EditAction.Modified;
            if (e.Column.AbsoluteIndex >= 3)
            {
                var val = ((ColumnView)sender).EditingValue.ToString();
                if (String.IsNullOrWhiteSpace(val)) val = null;
                data[mainView.FocusedRowHandle][e.Column.AbsoluteIndex+2] = val; 
            }
            else
            {
                data[mainView.FocusedRowHandle][e.Column.AbsoluteIndex] = ((ColumnView)sender).EditingValue.ToString(); 
            }
            
            modified = true;
            mainView.RefreshData();
        }

        private void OnDeleteButtonClick(object sender, EventArgs e)
        {
            data[mainView.FocusedRowHandle][2] = EditAction.Delete;
            modified = true;
            mainView.RefreshData();
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            if (!modified) { return; }
            using(var con = DataHelper.OpenOrCreateDb()) {
                foreach (var d in data.Where(d1 => ((EditAction)d1[2]) != EditAction.None)) 
                {
                    if (((EditAction)d[2]) == EditAction.Delete) {
                        DataHelper.DeleteObject(d[4].ToString(), con, false);
                    }
                    else {
                        DataHelper.UpdateObject(d[0].ToString(), d[4].ToString(), con, false);
                        DataHelper.UpdateEntityGrouping((int)d[7], d[6], d[5], con);
                    }
                }
            }
            Dispose();
        }

        private void OnAddEntityButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (String.IsNullOrEmpty(beAddEntity.Text)) { return; }
            if (data.Any(d => (string)d[0] == beAddEntity.Text))
            {
                MessageBox.Show("Такой object уже существует.", "Проверка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
             using(var con = DataHelper.OpenOrCreateDb()) {
                 DataHelper.AddObject(beAddEntity.Text, con, false, 0);
             }
             data = DataHelper.GetObjectStatistic();
             grid.DataSource = data;
             grid.Refresh();
             beAddEntity.Text = string.Empty;
        }

        private void CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.AbsoluteIndex >= 3)
            {
                e.Value = data[e.ListSourceRowIndex][e.Column.AbsoluteIndex+2];
            }
            else
            {
                e.Value = data[e.ListSourceRowIndex][e.Column.AbsoluteIndex];
            }
        
        }

    }
}
