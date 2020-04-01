using Eureka.Core.Domain.Security;
using Eureka.Forms.Views.Controls;
using Eureka.Forms.Views.Security;
using Eureka.Froms.Presentations.Security;
using Eureka.Services;
using KimtToo.VisualReactive;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace Eureka.Froms.Views
{
    public partial class MainForm : MetroForm, IMainView
    {        
        private MainPresenter _presenter;
        private readonly ISecuritieSrv _repository;

        public MainForm()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            _repository = new SecuritieSrv();
            _presenter = new MainPresenter(this, _repository);

            this.menuItems.Item_Click += new MenuEventHandler(this.MenuItem_Click);
            //this.dgvBudget.RowPrePaint
            //        += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(
            //            this.dgvBudget_RowPrePaint);
        }

        private void MenuItem_Click(object sender, MenuEventArgs args)
        {
            if (Item_Click != null)
                Item_Click(sender, args);
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
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
        public string ConnectionState
        {
            get { return tsbConnectionState.Text; }
            set { tsbConnectionState.Text = value; }
        }

        public string LogOnName
        {
            get { return lblLogOn.Text; }
            set { lblLogOn.Text = value; }
        }
        
        public MenuButtonCtrl menuList
        {
            get { return menuItems; }
            set { menuItems = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler Monitoring;
        public event EventHandler Menu_Click;
        public event EventHandler ParentMenu_Click;
        public event MenuEventHandler Item_Click;

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void metroPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Monitoring != null)
                Monitoring(sender, e);
        }

        public void SetTimer(bool enableTimer)
        {
            timer1.Interval = 1000;
            timer1.Enabled = enableTimer;
        }

        private void butBudgetCtrl_Click(object sender, EventArgs e)
        {
            if (Menu_Click != null)
                Menu_Click(sender, e);
        }

        private void butPurchaseOrder_Click(object sender, EventArgs e)
        {
            if (Menu_Click != null)
                Menu_Click(sender, e);
        }

        private void butPOReceiving_Click(object sender, EventArgs e)
        {
            if (Menu_Click != null)
                Menu_Click(sender, e);
        }

        private void butMaterialIssue_Click(object sender, EventArgs e)
        {
            if (Menu_Click != null)
                Menu_Click(sender, e);
        }

        private void butPOBalance_Click(object sender, EventArgs e)
        {
            if (Menu_Click != null)
                Menu_Click(sender, e);
        }

        private void butRequisition_Click(object sender, EventArgs e)
        {
            if (Menu_Click != null)
                Menu_Click(sender, e);
        }

        private void butRequisitionFinaly_Click(object sender, EventArgs e)
        {
            if (Menu_Click != null)
                Menu_Click(sender, e);
        }

        private void butMaterialReturn_Click(object sender, EventArgs e)
        {
            if (Menu_Click != null)
                Menu_Click(sender, e);
        }

        private void butPurchaseOrder1_Click(object sender, EventArgs e)
        {
            if (Menu_Click != null)
                Menu_Click(sender, e);       
        }

        private void Parent_Click(object sender, EventArgs e)
        {
            if (ParentMenu_Click != null)
                ParentMenu_Click(sender, e);
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            ChangPassword frm = new ChangPassword();
            frm.ShowDialog();
        }
    }
}