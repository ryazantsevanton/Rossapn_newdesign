using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design
{
    public partial class LoginForm : Form
    {
        public LoginForm(string caption = "Пожалуйста, авторизуйтесь", string login = "", bool loginEnabled = true)
        {
            InitializeComponent();
            this.FormClosed += OnFormClosed;

            this.Text = caption;
            this.login.Text = login;
            this.login.Enabled = loginEnabled;
        }

        public delegate void LoginEvent(LoginForm sender, string login, string password, out bool success);
        public delegate void CancelEvent(LoginForm sender);

        public event LoginEvent OnLogin;
        public event CancelEvent OnCancel;

        private bool success = false;

        private void OnButtonClick(object sender, EventArgs e)
        {
            doLogin();
        }

        private void doLogin()
        {
            if (OnLogin != null)
                OnLogin(this, login.Text, password.Text, out success);

            password.Text = "";
            if (success) Close();
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if (!success && OnCancel != null)
                OnCancel(this);
        }

        private void OnLoginKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                password.Focus();
        }

        private void OnPasswordKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                doLogin();
        }

    }
}
