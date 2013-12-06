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
        List<object[]> events;

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
            bbiScheduleRep.ItemClick += OnScheduleReportClick;

            lastEventsView.CustomUnboundColumnData += ((s, e) => e.Value = events[e.ListSourceRowIndex][e.Column.AbsoluteIndex]);

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

        private void OnScheduleReportClick(object sender, ItemClickEventArgs e)
        {
            showControl("ListSwitchesForm", new ListSwitchesForm());                              
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
            showControl("EditObjectControl", new EditObjectControl());
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
                events = DataHelper.LastEventsForAccount(login);
                if (events.Count < 5)
                {                     
                    events = DataHelper.LastEvents(5);
                    labelEvents.Text = String.Format("Последние события({0}):", events.Count); 
                }
                else
                {
                    labelEvents.Text = String.Format("События со времени вашего последнего входа ({0}):", events.Count);   
                }
                
                gvLastEvents.DataSource = events;
                
                Account.tryLogin(login, password);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            success = (Account.Current != null);

            DataHelper.CustomFormulas = new List<CalcFormula>();
            DataHelper.CustomFormulas.Add(new QGasCalculation());

            using (var con = DataHelper.OpenOrCreateDb())
            {
                foreach (var d in DataHelper.CustomFormulas)
                {
                    foreach (var p in d.InitPredicates()) DataHelper.GetParameter(p, con, true);
                    DataHelper.GetParameter(d.Name, con, true);
                }
            }

        }
    }
}