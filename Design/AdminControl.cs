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

namespace Design
{
    public partial class AdminControl : UserControl
    {

        List<Account> users;
        List<object[]> log;

        public AdminControl()
        {
            InitializeComponent();
            repositoryItemComboBox1.Items.AddRange(Enum.GetValues(typeof(Account.Roles)));

            accountsView.CustomUnboundColumnData += UsersCustomUnboundColumnData;
            accountsView.FocusedRowChanged += FocusedRowChanged;
            accountsView.CellValueChanged += accountsCellValueChanged;
            refreshUserList();

            accountsView.PopupMenuShowing += AccountsPopupMenuShowing;

            closeButton.Click += OnCloseButtonClick;   
        }

        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            Dispose();
        }

        void accountsCellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.AbsoluteIndex == 0) return;

            Account selected = users[e.RowHandle];

            Account.Roles role = selected.Role;
            try
            {
                role = (Account.Roles)(sender as ColumnView).EditingValue;
            }
            catch (Exception ex)
            {
                return;
            }


            if (selected.Role != role)
                Account.changeRole(selected, role);
        }

        void AccountsPopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                accountsView.FocusedRowHandle = e.HitInfo.RowHandle;
                accountContextMenu.Show(accountsView.GridControl, e.Point);
            }
        }

        private void FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= users.Count) return;

            log = DataHelper.getAccountActions(users[e.FocusedRowHandle].Login);
            journalView.CustomUnboundColumnData += JournalCustomUnboundColumnData;
            journalTable.DataSource = log;
        }

        private void refreshUserList()
        {
            users = DataHelper.getAccounts();
            userList.DataSource = users;
        }

        void JournalCustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            e.Value = log[e.ListSourceRowIndex][e.Column.AbsoluteIndex];
        }

        void UsersCustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData) {
                switch (e.Column.AbsoluteIndex) {
                    case 0: e.Value = users[e.ListSourceRowIndex].Login; break;
                    case 1: e.Value = users[e.ListSourceRowIndex].Role; break;
                }
            }
        }

        void OnAddUser(LoginForm sender, string login, string password, out bool success)
        {
            try {
                success = Account.createAccount(login, password, Account.Roles.User) != null;
                refreshUserList();
            } catch (Exception e) {
                MessageBox.Show(e.Message, "Ошибка");
                success = false;
            }
            
        }

        private void addAccountMenuClick(object sender, EventArgs e)
        {
            var dialog = new LoginForm("Создание нового пользователя");
            dialog.OnLogin += OnAddUser;
            dialog.ShowDialog();
        }

        private void removeAccountMenuClick(object sender, EventArgs e)
        {
            int row = accountsView.FocusedRowHandle;
            Account selected = users[row];
            if (MessageBox.Show("Удалить пользователя " + selected.Login + "?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Account.removeOne(selected);

            refreshUserList();

        }

        private void changePasswordMenuClick(object sender, EventArgs e)
        {
            int row = accountsView.FocusedRowHandle;
            Account selected = users[row];
            var dialog = new LoginForm("Смена пароля", selected.Login, false);
            dialog.OnLogin += OnChangePassword;
            dialog.ShowDialog();
        }

        void OnChangePassword(LoginForm sender, string login, string password, out bool success)
        {
            try
            {
                int row = accountsView.FocusedRowHandle;
                Account selected = users[row];
                Account.changePassword(selected, password);
                success = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка");
                success = false;
            }

        }

    }
}
