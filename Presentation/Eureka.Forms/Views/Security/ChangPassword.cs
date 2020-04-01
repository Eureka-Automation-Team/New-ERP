using Eureka.Core.Domain.Security;
using Eureka.Forms.Presentations.Security;
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

namespace Eureka.Forms.Views.Security
{
    public partial class ChangPassword : MetroForm, IChangePasswordView
    {
        private ChangePasswordPresenter _presenter;
        public ChangPassword()
        {
            InitializeComponent();

            _presenter = new ChangePasswordPresenter(this);
        }

        public string OldPassword
        {
            get { return txtOld.Text; }
            set { txtOld.Text = value; }
        }

        public string NewPassword
        {
            get { return txtNew.Text; }
            set { txtNew.Text = value; }
        }

        public string ConfirmPassword
        {
            get { return txtConfirm.Text; }
            set { txtConfirm.Text = value; }
        }

        public bool Confirmed
        {
            get { return NewPassword == ConfirmPassword; }
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public event EventHandler Save;

        public void CloseMe()
        {
            this.Close();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (Save != null)
                Save(sender, e);
        }
    }
}
