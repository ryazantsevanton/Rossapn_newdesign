using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Design.Infrastructure;
using DevExpress.XtraGrid.Views.Base;

namespace Design
{
    public partial class SettingsForm : UserControl
    {
        private bool modified;
        private object[][] objects;
        private object[][] parameters;
        private object[][] eventObjects;

        public SettingsForm()
        {
            InitializeComponent();

            int scheduleRange = Convert.ToInt32(DataHelper.GetSettingValue("RangeSchedule"));

            npdShedule.Value = scheduleRange == null || scheduleRange == 0 ? 3 : scheduleRange;

            npdShedule.ValueChanged += OnValueChanged;

            cancelButton.Click += OnCancelButtonClick;
            saveButton.Click += OnSaveButtonClick;
            modified = false;

            objects = DataHelper.GetObjects();
            parameters = DataHelper.GetParameters();
            eventObjects = DataHelper.GetEvents();

            cbObjects.Items.AddRange(objects.Select(o => (string)o[1]).ToArray());
            cbParameters.Items.AddRange(parameters.Select(o => (string)o[1]).ToArray());
            cbEventCheckers.Items.AddRange(DataHelper.EventCheckers.Select(ec => ec.Name).ToArray());

            cbObjects.SelectedValueChanged += cbSelectedValueChanged;
            cbParameters.SelectedValueChanged += cbSelectedValueChanged;
            cbEventCheckers.SelectedValueChanged += cbSelectedValueChanged;
            mainView.CustomUnboundColumnData += CustomUnboundColumnData;
            mainView.FocusedRowChanged += OnFocusedRowChanged;

            grid.DataSource = eventObjects;
        }

        private void OnFocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            object[] row = (object[])mainView.GetRow(e.FocusedRowHandle);
            try
            {
                cbObjects.SelectedItem = (string)row[6];
                cbParameters.SelectedItem = (string)row[3];
                cbEventCheckers.SelectedItem = (string)row[4];
                tbArguments.Text = (string)row[5];
            }
            catch {
                cbObjects.SelectedIndex = -1;
                cbParameters.SelectedIndex = -1;
                cbEventCheckers.SelectedIndex = -1;
                tbArguments.Text = string.Empty;
            }
        }

        private void CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            e.Value = eventObjects[e.ListSourceRowIndex][e.Column.AbsoluteIndex];
        }

        void cbSelectedValueChanged(object sender, EventArgs e)
        {
            tbArguments.Text = "";

            if (cbObjects.SelectedIndex == -1 || cbParameters.SelectedIndex == -1 || cbEventCheckers.SelectedIndex == -1)
                return;

            int entityId = (int) objects[cbObjects.SelectedIndex][0];
            int predicateId = (int)parameters[cbParameters.SelectedIndex][0];
            string checkerName = DataHelper.EventCheckers[cbEventCheckers.SelectedIndex].Name;

          //?  tbArguments.Text = DataHelper.readEventCheckerArguments(entityId, predicateId, checkerName);

        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            if (modified && DialogResult.Yes != MessageBox.Show("Есть несохраненные данные. " +
                "Вы действительно хотите закрыть форму?", "Вопрос",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }
            Dispose(); 
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            DataHelper.SaveSettings(npdShedule.Value);
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            modified = true;
            cancelButton.Text = "Отмена";
        }

        private void OnHelpButtonClick(object sender, EventArgs e)
        {
            if (cbEventCheckers.SelectedIndex > -1)
                MessageBox.Show(DataHelper.EventCheckers[cbEventCheckers.SelectedIndex].Help, 
                                DataHelper.EventCheckers[cbEventCheckers.SelectedIndex].Name, 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnApplyButtonClick(object sender, EventArgs e)
        {
            if (cbObjects.SelectedIndex == -1 || cbParameters.SelectedIndex == -1 || cbEventCheckers.SelectedIndex == -1)
            {
                MessageBox.Show("Укажите объект, параметр и событие из выпадающих списков",
                                "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int entityId = (int)objects[cbObjects.SelectedIndex][0];
            int predicateId = (int)parameters[cbParameters.SelectedIndex][0];
            string checkerName = DataHelper.EventCheckers[cbEventCheckers.SelectedIndex].Name;

            DataHelper.writeEventCheckerArguments(entityId, predicateId, checkerName, tbArguments.Text.Trim());
            mainView.BeginDataUpdate();
            eventObjects = DataHelper.GetEvents();
            grid.DataSource = eventObjects;
            mainView.EndDataUpdate();
            mainView.RefreshData();

        }


    }
}
