
using Eureka.CNC.Presentations.Security;
using Eureka.Core.Domain.Security;
using MaterialSkin.Controls;
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

namespace Eureka.CNC.Views
{
    public partial class Login : MaterialForm, ILoginView
    {
        private LoginPresenter _presenter;

        public Login()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager manager = MaterialSkin.MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue300, MaterialSkin.Primary.Blue500, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.LightBlue400, MaterialSkin.TextShade.WHITE);
            _presenter = new LoginPresenter(this);
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

        public Session EpiSession
        {
            get { return Session.Instance; }
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
                //if (!string.IsNullOrEmpty(txtUsername.Text))
                //    txtPassword.Focus();
            }
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (!string.IsNullOrEmpty(txtPassword.Text))
                //{
                //    if (LogIn != null)
                //        LogIn(sender, e);

                //    if (EpicSession.isLoggedIn)
                //        this.Close();
                //}
            }
        }

        private void txtUsername_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtUsername.Text))
                    txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown_1(object sender, KeyEventArgs e)
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

        private void butLogin_Click_1(object sender, EventArgs e)
        {
            if (LogIn != null)
                LogIn(sender, e);

            if (EpiSession.isLoggedIn)
                this.Close();
        }

        private void Login_Load_1(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }
    }
}
