using Eureka.Core.Domain.Security;
using Eureka.Froms.Presentations.Security;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Views
{
    public partial class Login : MetroForm, ILoginView
    {
        private LoginPresenter _presenter;

        public Login()
        {
            InitializeComponent();
            _presenter = new LoginPresenter(this);
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public string UserName
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler LogIn;

        private void Login_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            if (LogIn != null)
                LogIn(sender, e);

            if (EpiSession.isLoggedIn)
                this.Close();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtUsername.Text))
                    txtPassword.Focus();
            }
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    if (LogIn != null)
                        LogIn(sender, e);

                    if (EpiSession.isLoggedIn)
                        this.Close();
                }
            }
        }
    }
}
