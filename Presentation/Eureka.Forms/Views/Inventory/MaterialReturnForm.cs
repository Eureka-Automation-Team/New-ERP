using Eureka.Core.Domain.Inventory;
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
    public partial class MaterialReturnForm : MetroForm, IMaterialReturnView
    {
        private readonly MaterialReturnPresenter _presenter;
        private List<ItemTransactionModel> _materialsIssue;
        private List<ItemTransactionModel> _materialsReturn;

        public MaterialReturnForm()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            _presenter = new MaterialReturnPresenter(this);

            this.dgvReturns.RowPrePaint
                        += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(
                            this.dgvReturns_RowPrePaint);
        }

        private void dgvReturns_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //try
            //{
            //    double transactionQuantity = (double)dgvReturns.Rows[e.RowIndex].Cells["TransactionQuantity"].Value;
            //    dgvReturns.Rows[e.RowIndex].Cells["returnQty"].Value = transactionQuantity * -1;
            //}
            //catch { return; }
        }

        public BindingSource bindingMaterialsTrans
        {
            get { return itemTransactionModelBindingSource; }
            set { itemTransactionModelBindingSource = value; }
        }
        public BindingSource bindingReturnLines
        {
            get { return itemTransactionModelBindingSource1; }
            set { itemTransactionModelBindingSource1 = value; }
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public string projNumber
        {
            get { return txtProjectNum.Text; }
            set { txtProjectNum.Text = value; }
        }
        public string itemFilter
        {
            get { return txtItemCode.Text; }
            set { txtItemCode.Text = value; }
        }

        public List<ItemTransactionModel> materialsTrans
        {
            get { return _materialsIssue; }
            set { _materialsIssue = value; }
        }

        public List<ItemTransactionModel> materialsReturn
        {
            get { return _materialsReturn; }
            set { _materialsReturn = value; }
        }

        public DateTime transDate
        {
            get { return dtpTransactionDate.Value; }
            set { dtpTransactionDate.Value = value; }
        }

        //public event EventHandler Form_Load;
        public event EventHandler Filter_Click;
        public event EventHandler Find_Project;
        //public event EventHandler Find_Item;
        public event EventHandler AddLine_Click;
        public event EventHandler Save_Click;
        public event EventHandler Delete_Click;

        private void txtProjectNum_ButtonClick(object sender, EventArgs e)
        {
            if (Find_Project != null)
                Find_Project(sender, e);
        }

        private void bdNavFilter_Click(object sender, EventArgs e)
        {
            if (Filter_Click != null)
                Filter_Click(sender, e);
        }

        public void BindingTrans()
        {
            try
            {
                bindingMatTransNav.BindingSource = this.bindingMaterialsTrans;
                SetTransGrid();
            }
            catch
            {
                SetTransGrid();
                return;
            }
        }

        private void SetTransGrid()
        {
            dgvTrans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvTrans.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvTrans.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvTrans.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvTrans.MultiSelect = true;
            dgvTrans.RowHeadersVisible = true;

            dgvTrans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrans.AllowUserToResizeColumns = true;
        }

        public void BindingReturns()
        {
            try
            {
                bindingMatReturnNav.BindingSource = this.bindingReturnLines;
                SetReturnsGrid();
            }
            catch
            {
                SetReturnsGrid();
                return;
            }
        }

        private void SetReturnsGrid()
        {
            dgvReturns.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvReturns.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvReturns.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvReturns.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvReturns.MultiSelect = true;
            dgvReturns.RowHeadersVisible = true;

            dgvReturns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReturns.AllowUserToResizeColumns = true;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvTrans.Rows)
            {
                row.Cells[0].Value = chkAll.Checked;
            }
        }

        private void butAddLine_Click(object sender, EventArgs e)
        {
            dgvTrans.EndEdit();

            if (AddLine_Click != null)
                AddLine_Click(dgvTrans, e);
        }

        private void dgvReturns_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            double newInteger;
            if (e.ColumnIndex == 0)
            {
                if (!double.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger < 0)
                {
                    MessageBox.Show("Invalid input number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

                //double receivedQty = newInteger;
                //double onhandQty = dgvReturns["TransactionQuantity", e.RowIndex].Value.AsDouble();
                //if (newInteger > onhandQty)
                //{
                //    MessageBox.Show("Return qty. must less than or equal Transaction Qty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    e.Cancel = true;
                //}
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            dgvReturns.EndEdit();

            if (Save_Click != null)
                Save_Click(dgvReturns, e);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (Delete_Click != null)
                Delete_Click(dgvReturns, e);
        }

        private void dgvReturns_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //double newVal;
            //if (e.ColumnIndex == 0)
            //{
            //    if (!double.TryParse(dgvReturns.CurrentRow.Cells["returnQty"].Value.ToString(), out newVal))
            //    {
            //        MessageBox.Show("Invalid input number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        dgvReturns.CurrentCell.Value = "0";
            //    }
            //}
        }
    }
}
