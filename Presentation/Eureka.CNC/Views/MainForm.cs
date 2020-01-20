using System;
using System.Windows.Forms;
using Eureka.CNC.Presentations.Security;
using Eureka.Core.Domain.Security;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using MaterialSkin;

namespace Eureka.CNC.Views
{
    public partial class MainForm : MaterialForm, IMainView
    {
        private MainPresenter _presenter;

        public MainForm()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager manager = MaterialSkin.MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue300, MaterialSkin.Primary.Blue500, MaterialSkin.Primary.Blue500, MaterialSkin.Accent.LightBlue400, MaterialSkin.TextShade.WHITE); 
            _presenter = new MainPresenter(this);
        }

        public string LogOnName
        {
            get { return EpiSession.User.UserName; }
            set { this.Text = "CNC [Log on by : " + value + "]"; }
        }
        public string HostName
        {
            get { return tsbHostName.Text; }
            set { tsbHostName.Text = value; }
        }
        public string DatabaseName
        {
            get { return tsbDatabaseName.Text; }
            set { tsbDatabaseName.Text = value; }
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public event EventHandler Form_Load;
        public event EventHandler Monitoring;
        public event EventHandler Menu_Click;

        public void SetTimer(bool enableTimer)
        {
            timer1.Interval = 1000;
            timer1.Enabled = enableTimer;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Menu_Click != null)
                Menu_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Menu_Click != null)
                Menu_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Menu_Click != null)
                Menu_Click(sender, e);
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            if (Form_Load != null)
                EpiSession.User = null; Form_Load(sender, e);
        }

        private void btnTestUpload_Click(object sender, EventArgs e)
        {
            if (Menu_Click != null)
                Menu_Click(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Monitoring != null)
                Monitoring(sender, e);
        }
    }
}
