using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System.Data.Linq;

namespace Design
{
    public partial class Form1 : RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            iExit.ItemClick += OnExitClick;
            loadButton.ItemClick += OnLoadClick;
            clearButton.ItemClick += OnClearButtonClick;
            paramButton.ItemClick += OnEditParamButtonClick;
            objectButton.ItemClick += OnEditObjectButtonClick;
            editData.ItemClick += OnEditDataButtonClick;
            bbiReport.ItemClick += OnBbiReportClick;
            bbiCalc.ItemClick += OnbbiCalItemCLick;
            bbiSettings.ItemClick += OnbbiSettingItemClick;
        }

        private void OnbbiSettingItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Account.Current.hasPermission(Account.Actions.ChangeSettings))
            {
                MessageBox.Show("Недостаточно прав для этой операции");
                return;
            }

            showControl("SettingsForm", new SettingsForm());
        }

        private void OnbbiCalItemCLick(object sender, ItemClickEventArgs e)
        {
            if (!Account.Current.hasPermission(Account.Actions.LoadMetrix))
            {
                MessageBox.Show("Недостаточно прав для этой операции");
                return;
            }

            showControl("CalcForm", new CalcForm());
        }

        private void OnBbiReportClick(object sender, ItemClickEventArgs e)
        {
            showControl("SwitchReportForm", new SwitchReportForm());                  
        }

        private void OnEditDataButtonClick(object sender, ItemClickEventArgs e)
        {
            showControl("DataControl", new DataControl());
        }

        private void OnEditParamButtonClick(object sender, ItemClickEventArgs e)
        {
            showControl("EditParamControl",new EditParamObjectControl(true));
        }

        private void OnEditObjectButtonClick(object sender, ItemClickEventArgs e)
        {
            showControl("EditObjectControl", new EditParamObjectControl(false));
        }

        private void OnLoadClick(object sender, EventArgs e)
        {
            if (!Account.Current.hasPermission(Account.Actions.LoadMetrix))
            {
                MessageBox.Show("Недостаточно прав для этой операции");
                return;
            }

            showControl("LoadXlsForm", new LoadXlsForm());
        }

        private void adminButtonClick(object sender, ItemClickEventArgs e)
        {
            if (Account.Current.Role != Account.Roles.Admin)
            {
                MessageBox.Show("Недостаточно прав для этой операции");
                return;
            }

            showControl("AdminControl", new AdminControl());
        }

        private void showControl(string key, Control form)
        {
            if (topPanel.Controls.ContainsKey(key))
            {
                return;
            }
            else
            {
                topPanel.Controls.Clear();
            }
            form.Name = key;
            topPanel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void OnClearButtonClick(object sender, ItemClickEventArgs e)
        {
            if (!Account.Current.hasPermission(Account.Actions.Wipe))
            {
                MessageBox.Show("Недостаточно прав для этой операции");
                return;
            }

            if (DialogResult.Yes == MessageBox.Show("Вы действительно хотите удалить все данные?", "Предупреждение",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                DataHelper.ClearData();
                DataHelper.logAction(Account.Actions.Wipe);
            }
        }

        private void OnExitClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            var lf = new LoginForm();
            lf.OnLogin += lf_OnLogin;
            lf.OnCancel += lf_OnCancel;

            lf.ShowDialog();
        }

        void lf_OnCancel(LoginForm sender)
        {
            Close();
        }

        void lf_OnLogin(LoginForm sender, string login, string password, out bool success)
        {
            try
            {
                Account.tryLogin(login, password);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            success = (Account.Current != null);

        }

    }
}