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

namespace Design
{
    public partial class SettingsForm : UserControl
    {
        private bool modified;
        private bool modifiedDate;

        public SettingsForm()
        {
            InitializeComponent();

            decimal numberCount = DataHelper.GetSettingValue("ScaleData");
            int scheduleRange = Convert.ToInt32(DataHelper.GetSettingValue("RangeSchedule"));
            decimal numCase1 = DataHelper.GetSettingValue("CriticalValue");
            decimal dost = DataHelper.GetSettingValue("RowDost");

            scaleDatas.Value = numberCount == null || numberCount == 0 ? 10 : numberCount;
            npdShedule.Value = scheduleRange == null || scheduleRange == 0 ? 20 : scheduleRange;
            npDost.Value = dost == null || dost == 0 ? 90 : dost;
            npCase1.Value = numCase1 == null || numCase1 == 0 ? 3 : numCase1;

            npCase1.ValueChanged += OnValueChanged;
            npDost.ValueChanged += OnValueChanged;
            scaleDatas.ValueChanged += OnValueChanged;
            npdShedule.ValueChanged += OnValueChanged;

            cancelButton.Click += OnCancelButtonClick;
            saveButton.Click += OnSaveButtonClick;
            modified = false;
            modifiedDate = false;

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
            if (modified)
            {
                DataHelper.SaveSettings(scaleDatas.Value, npDost.Value, npCase1.Value, npdShedule.Value);
            }
            modified = false;
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            modified = true;
            cancelButton.Text = "Отмена";
        }


    }
}
