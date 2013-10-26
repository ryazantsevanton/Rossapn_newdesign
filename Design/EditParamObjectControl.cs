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
    public partial class EditParamObjectControl : UserControl
    {
        private bool type;
        private object[][] data;
        private bool modified;

        public EditParamObjectControl(bool type)
        {
            InitializeComponent();
            this.type = type;
            lTitle.Text = type ? "Редактор Параметров" : "Редактор Объектов";
            data = type ? DataHelper.GetParamStatistic() : DataHelper.GetObjectStatistic();

            GridColumn unbColumn = mainView.Columns.AddField("titles");
            unbColumn.VisibleIndex = 0;
            unbColumn.Caption = type ? "Параметры" : "Объекты";
            unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            unbColumn.OptionsColumn.AllowEdit = true;
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

            grid.DataSource = data;

            mainView.CustomUnboundColumnData += CustomUnboundColumnData;
            mainView.RowCellStyle += OnRowStyle;
            mainView.CellValueChanged += OnValueChanged;
            mainView.ValidatingEditor += OnValidatingEditor; 
            cancelButton.Click += OnCancelButtonClick;
            deleteButton.Click += OnDeleteButtonClick;
            saveButton.Click += OnSaveButtonClick;

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
            for(int i =0; i< data.Length; i++)
            {
                if (i == mainView.FocusedRowHandle)
                {
                    continue;
                }
                if (data[i][0].ToString().ToLower() == e.Value.ToString().ToLower())
                {
                    e.ErrorText = "Такой " + (type ? "параметр" : "object") + " уже существует.";
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
            data[mainView.FocusedRowHandle][0] = ((ColumnView)sender).EditingValue.ToString(); 
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
                        DataHelper.DeleteObject(d[3].ToString(), con, type);
                    }
                    else {
                        DataHelper.UpdateObject(d[0].ToString(), d[3].ToString(), con, type);
                    }
                }
            }
            Dispose();
        }

        private void CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            e.Value = data[e.ListSourceRowIndex][e.Column.AbsoluteIndex];
        }

    }
}
