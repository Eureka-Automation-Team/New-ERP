using Eureka.Core.Domain.Commons;
using Eureka.Core.Domain.Security;
using Eureka.Froms.Presentations.Inventory;
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

namespace Eureka.Froms.Views.Inventory
{
    public partial class MaterialReturnEntryForm : MetroForm, IMaterialReturnEntryView
    {
        private readonly MaterialReturnEntryPresenter _presenter;
        private SequenceDocModel _rowDoc;
        private int _running;

        public MaterialReturnEntryForm()
        {
            InitializeComponent();
            _presenter = new MaterialReturnEntryPresenter(this);
        }

        public string returnNumber
        {
            get { return txtReturnNumber.Text; }
            set { txtReturnNumber.Text = value; }
        }

        public DateTime TransactionDate
        {
            get { return dtpTransactionDate.Value; }
            set { dtpTransactionDate.Value = value; }
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public SequenceDocModel rowDoc
        {
            get { return _rowDoc; }
            set { _rowDoc = value; }
        }
        public int running
        {
            get { return _running; }
            set { _running = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler OK_Click;
        public event EventHandler Cancel_Click;

        public void CloseForm()
        {
            this.Close();
        }

        private void MaterialReturnEntryForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (OK_Click != null)
                OK_Click(sender, e);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (Cancel_Click != null)
                Cancel_Click(sender, e);
        }
    }
}
