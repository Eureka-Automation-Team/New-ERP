using Eureka.Core.Domain.Projects;
using Eureka.Core.Domain.Purchasing;
using Eureka.Core.Domain.Security;
using Eureka.Froms.Presentations.Purchasing;
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

namespace Eureka.Froms.Views.Purchasing
{
    public partial class POReceiptForm : MetroForm, IPOReceiptView
    {
        private POReceiptPresenter _presenter;

        private BindingSource bindingHead;
        private BindingSource bindingLine;

        private POReceiptHeaderModel _headSeleted;
        private POReceiptLineModel _lineInspection;
        private POReceiptLineModel _lineSeleted;
        private IEnumerable<POReceiptHeaderModel> _receipts;
        private IEnumerable<POReceiptLineModel> _rcvLines;
        private IEnumerable<CostGroupModel> _costs;

        public POReceiptForm()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            _presenter = new POReceiptPresenter(this);

            bindingHead = new BindingSource();
            bindingLine = new BindingSource();
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public POReceiptHeaderModel headSeleted
        {
            get
            {
                if(_headSeleted != null)
                {
                    _headSeleted.ReceiptDate = dtpReceiptDate.Value;
                    _headSeleted.InvoiceNum = txtInvoiceNum.Text;
                    _headSeleted.Comments = txtComments.Text;
                    _headSeleted.ReceiptMethod = cboReceiveMethod.Text;
                }
                return _headSeleted;
            }
            set
            {
                _headSeleted = value;

                txtReceiptNum.Text = _headSeleted.ReceiptNum;
                dtpReceiptDate.Value = _headSeleted.ReceiptDate;
                txtSourceType.Text = _headSeleted.SourceType;
                txtReceivedBy.Text = _headSeleted.ReceivedByName;
                chkQCInspectionFlag.Checked = _headSeleted.QCInspectionFlag;
                cboInspectionStatus.Text = _headSeleted.InspectionStatus;
                cboReceiveMethod.Text = _headSeleted.ReceiptMethod;
                txtVendorNum.Text = _headSeleted.VendorCode;
                txtVendorName.Text = _headSeleted.VendorName;
                txtInvoiceNum.Text = _headSeleted.InvoiceNum;
                txtComments.Text = _headSeleted.Comments;
                tnvReceived.Enabled = !_headSeleted.ReceivedFlag;
                txtSelectGRN.Enabled = !_headSeleted.ReceivedFlag;
                butGetPO.Enabled = !_headSeleted.ReceivedFlag;
                metroLabel4.Text = _headSeleted.ReceiptMethod == "RECEIVE" ? "Receipt No.:" : "Return No.:";
                butGenReceiptNo.Visible = _headSeleted.ReceiptMethod == "RECEIVE" ? true : false;
                txtSelectGRN.Visible = _headSeleted.ReceiptMethod == "RECEIVE" ? false : true;
                butGetPO.Visible = _headSeleted.ReceiptMethod == "RECEIVE" ? true : false;

                if (string.IsNullOrEmpty(_headSeleted.ReceiptNum))
                {
                    cboReceiveMethod.Enabled = true;
                    dtpReceiptDate.Enabled = true;
                }
                else
                {
                    cboReceiveMethod.Enabled = false;
                    dtpReceiptDate.Enabled = false;
                }                    
            }
        }
        public POReceiptLineModel lineInspection
        {
            get
            {
                _lineInspection.QcInspectionStatus = cboQCStatus.SelectedIndex + 1;
                return _lineInspection;
            }
            set
            {
                _lineInspection = value;
                if(_lineInspection != null)
                {
                    txtProjectNum.Text = _lineInspection.ProjectNum;
                    txtCostCode.Text = _lineInspection.CostCode;
                    txtItemCode.Text = _lineInspection.ItemCode;
                    cboQCStatus.Text = _lineInspection.InspectionName;
                    butQCConfirm.Enabled = true;
                }
                else
                {
                    txtProjectNum.Text = string.Empty;
                    txtCostCode.Text = string.Empty;
                    txtItemCode.Text = string.Empty;
                    cboQCStatus.Text = string.Empty;
                    butQCConfirm.Enabled = false;
                }

            }
        }
        public IEnumerable<POReceiptHeaderModel> receipts
        {
            get { return _receipts; }
            set { _receipts = value; }
        }
        public IEnumerable<POReceiptLineModel> rcvLines
        {
            get { return _rcvLines; }
            set
            {
                _rcvLines = value;

                txtSumQuantity.Text = _rcvLines.Sum(s => s.QuantityShipped).ToString("#,##0");
                txtSumTotalPrice.Text = _rcvLines.Sum(s => s.TotalPrice).ToString("#,##0.00");

            }
        }

        public IEnumerable<CostGroupModel> costs
        {
            get { return _costs; }
            set { _costs = value; }
        }
        
        public POReceiptLineModel lineSeleted
        {
            get { return _lineSeleted; }
            set { _lineSeleted = value; }
        }

        public string grnFileter
        {
            get { return txtSelectGRN.Text; }
            set { txtSelectGRN.Text = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler Filter_Click;
        public event EventHandler Save_Click;
        public event EventHandler New_Click;
        //public event EventHandler Refresh_Click;
        public event EventHandler Find_Vendor;
        public event EventHandler GenerateGRN;
        public event EventHandler GetPO;
        public event EventHandler Seleted_RCV;
        public event EventHandler Seleted_Line;
        public event EventHandler Confirm_QC;
        public event EventHandler Received_Click;
        public event EventHandler Delete_Row;
        public event EventHandler Test_Object;
        public event EventHandler Print_Received;
        public event EventHandler Method_Change;
        public event EventHandler Get_GRN;

        public void BindingRcvHead(IEnumerable<POReceiptHeaderModel> list)
        {
            if (list != null)
            {
                try
                {
                    bindingHead.DataSource = list;
                    bindingNav.BindingSource = bindingHead;
                    dgvRcv.DataSource = bindingHead;

                    SetRcvGrid();
                }
                catch
                {
                    SetRcvGrid();
                    return;
                }
            }
        }

        private void SetRcvGrid()
        {
            dgvRcv.Columns[0].Visible = false;
            //dgvRcv.Columns[1].Visible = false;
            //dgvRcv.Columns[2].Visible = false;
            dgvRcv.Columns[3].Visible = false;
            dgvRcv.Columns[4].Visible = false;
            dgvRcv.Columns[5].Visible = false;
            dgvRcv.Columns[6].Visible = false;
            dgvRcv.Columns[7].Visible = false;
            dgvRcv.Columns[8].Visible = false;
            dgvRcv.Columns[9].Visible = false;
            dgvRcv.Columns[10].Visible = false;
            //dgvRcv.Columns[11].Visible = false;
            dgvRcv.Columns[12].Visible = false;
            dgvRcv.Columns[13].Visible = false;
            dgvRcv.Columns[14].Visible = false;
            dgvRcv.Columns[15].Visible = false;
            dgvRcv.Columns[16].Visible = false;
            dgvRcv.Columns[17].Visible = false;
            dgvRcv.Columns[18].Visible = false;
            dgvRcv.Columns[19].Visible = false;
            dgvRcv.Columns[20].Visible = false;
            dgvRcv.Columns[21].Visible = false;
            dgvRcv.Columns[22].Visible = false;
            dgvRcv.Columns[23].Visible = false;
            dgvRcv.Columns[24].Visible = false;
            dgvRcv.Columns[25].Visible = false;
            dgvRcv.Columns[26].Visible = false;
            dgvRcv.Columns[27].Visible = false;
            dgvRcv.Columns[28].Visible = false;
            dgvRcv.Columns[29].Visible = false;
            dgvRcv.Columns[30].Visible = false;
            dgvRcv.Columns[31].Visible = false;
            dgvRcv.Columns[32].Visible = false;
            dgvRcv.Columns[33].Visible = false;
            dgvRcv.Columns[34].Visible = false;
            dgvRcv.Columns[35].Visible = false;
            dgvRcv.Columns[36].Visible = false;
            dgvRcv.Columns[37].Visible = false;
            dgvRcv.Columns[38].Visible = false;
            dgvRcv.Columns[39].Visible = false;
            dgvRcv.Columns[40].Visible = false;
            dgvRcv.Columns[41].Visible = false;
            dgvRcv.Columns[42].Visible = false;
            dgvRcv.Columns[43].Visible = false;
            dgvRcv.Columns[44].Visible = false;
            dgvRcv.Columns[45].Visible = false;
            dgvRcv.Columns[46].Visible = false;
            dgvRcv.Columns[47].Visible = false;
            dgvRcv.Columns[48].Visible = false;
            dgvRcv.Columns[49].Visible = false;
            dgvRcv.Columns[50].Visible = false;
            dgvRcv.Columns[51].Visible = false;
            dgvRcv.Columns[52].Visible = false;
            dgvRcv.Columns[53].Visible = false;
            dgvRcv.Columns[54].Visible = false;
            dgvRcv.Columns[55].Visible = false;
            dgvRcv.Columns[56].Visible = false;
            dgvRcv.Columns[57].Visible = false;
            dgvRcv.Columns[58].Visible = false;
            dgvRcv.Columns[59].Visible = false;
            dgvRcv.Columns[60].Visible = false;
            dgvRcv.Columns[61].Visible = false;
            dgvRcv.Columns[62].Visible = false;
            dgvRcv.Columns[63].Visible = false;

            dgvRcv.Columns[2].DefaultCellStyle.Format = "dd-MMM-yyyy";

            dgvRcv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRcv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRcv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRcv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvRcv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvRcv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvRcv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvRcv.MultiSelect = true;
            dgvRcv.RowHeadersVisible = true;

            dgvRcv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRcv.AllowUserToResizeColumns = true;
            dgvRcv.Columns[1].ReadOnly = true;
            dgvRcv.Columns[2].ReadOnly = true;
            dgvRcv.Columns[10].ReadOnly = true;
        }

        public void BindingRcvLines(IEnumerable<POReceiptLineModel> list)
        {
            if (list != null)
            {
                try
                {
                    bindingLine.DataSource = list;
                    bindingLine.ResetBindings(false);
                    dgvLine.DataSource = bindingLine;

                    SetLineGrid();
                }
                catch
                {
                    SetLineGrid();
                    return;
                }
            }
        }

        private void SetLineGrid()
        {
            dgvLine.Columns[0].Visible = false;
            dgvLine.Columns[1].Visible = false;
            dgvLine.Columns[2].Visible = false;
            dgvLine.Columns[3].Visible = false;
            dgvLine.Columns[4].Visible = false;
            dgvLine.Columns[5].Visible = false;
            dgvLine.Columns[6].Visible = false;
            dgvLine.Columns[7].Visible = false;
            //dgvLine.Columns[8].Visible = false;
            //dgvLine.Columns[9].Visible = false;
            dgvLine.Columns[10].Visible = false;
            //dgvLine.Columns[11].Visible = false;
            //dgvLine.Columns[12].Visible = false;
            //dgvLine.Columns[13].Visible = false;
            //dgvLine.Columns[14].Visible = false;
            //dgvLine.Columns[15].Visible = false;
            //dgvLine.Columns[16].Visible = false;
            //dgvLine.Columns[17].Visible = false;
            //dgvLine.Columns[18].Visible = false;
            //dgvLine.Columns[19].Visible = false;
            //dgvLine.Columns[20].Visible = false;
            //dgvLine.Columns[21].Visible = false;
            //dgvLine.Columns[22].Visible = false;
            //dgvLine.Columns[23].Visible = false;
            //dgvLine.Columns[24].Visible = false;
            dgvLine.Columns[25].Visible = false;
            dgvLine.Columns[26].Visible = false;
            dgvLine.Columns[27].Visible = false;
            dgvLine.Columns[28].Visible = false;
            dgvLine.Columns[29].Visible = false;
            dgvLine.Columns[30].Visible = false;
            dgvLine.Columns[31].Visible = false;
            dgvLine.Columns[32].Visible = false;
            dgvLine.Columns[33].Visible = false;
            dgvLine.Columns[34].Visible = false;
            dgvLine.Columns[35].Visible = false;
            dgvLine.Columns[36].Visible = false;
            dgvLine.Columns[37].Visible = false;
            dgvLine.Columns[38].Visible = false;
            dgvLine.Columns[39].Visible = false;
            dgvLine.Columns[40].Visible = false;
            dgvLine.Columns[41].Visible = false;
            dgvLine.Columns[42].Visible = false;
            dgvLine.Columns[43].Visible = false;
            dgvLine.Columns[44].Visible = false;
            dgvLine.Columns[45].Visible = false;
            dgvLine.Columns[46].Visible = false;
            dgvLine.Columns[47].Visible = false;
            dgvLine.Columns[48].Visible = false;
            dgvLine.Columns[49].Visible = false;
            dgvLine.Columns[50].Visible = false;
            dgvLine.Columns[51].Visible = false;
            dgvLine.Columns[52].Visible = false;
            dgvLine.Columns[53].Visible = false;
            dgvLine.Columns[54].Visible = false;
            dgvLine.Columns[55].Visible = false;
            dgvLine.Columns[56].Visible = false;
            dgvLine.Columns[57].Visible = false;
            dgvLine.Columns[58].Visible = false;
            dgvLine.Columns[59].Visible = false;
            dgvLine.Columns[60].Visible = false;
            dgvLine.Columns[61].Visible = false;
            dgvLine.Columns[62].Visible = false;
            dgvLine.Columns[63].Visible = false;
            dgvLine.Columns[64].Visible = false;
            dgvLine.Columns[65].Visible = false;
            dgvLine.Columns[66].Visible = false;
            dgvLine.Columns[67].Visible = false;
            //dgvLine.Columns[68].Visible = false;
            dgvLine.Columns[69].Visible = false;
            //dgvLine.Columns[70].Visible = false;
            dgvLine.Columns[71].Visible = false;
            dgvLine.Columns[72].Visible = false;
            dgvLine.Columns[73].Visible = false;
            dgvLine.Columns[74].Visible = false;
            dgvLine.Columns[75].Visible = false;
            dgvLine.Columns[76].Visible = false;
            dgvLine.Columns[77].Visible = false;
            dgvLine.Columns[78].Visible = false;
            dgvLine.Columns[79].Visible = false;
            dgvLine.Columns[80].Visible = false;

            dgvLine.Columns[15].DefaultCellStyle.Format = "#,##0";
            dgvLine.Columns[16].DefaultCellStyle.Format = "#,##0";
            dgvLine.Columns[17].DefaultCellStyle.Format = "#,##0";
            dgvLine.Columns[19].DefaultCellStyle.Format = "#,##0.00";
            dgvLine.Columns[20].DefaultCellStyle.Format = "#,##0.00";

            dgvLine.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLine.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLine.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLine.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLine.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvLine.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvLine.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvLine.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvLine.MultiSelect = true;
            dgvLine.RowHeadersVisible = true;

            dgvLine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLine.AllowUserToResizeColumns = true;
            //dgvLine.ReadOnly = true;
            dgvLine.Columns[8].ReadOnly = true;
            dgvLine.Columns[9].ReadOnly = true;
            dgvLine.Columns[11].ReadOnly = true;
            dgvLine.Columns[12].ReadOnly = true;
            dgvLine.Columns[13].ReadOnly = true;
            dgvLine.Columns[14].ReadOnly = true;
            dgvLine.Columns[15].ReadOnly = false;
            dgvLine.Columns[16].ReadOnly = true;
            dgvLine.Columns[17].ReadOnly = true;
            dgvLine.Columns[18].ReadOnly = true;
            dgvLine.Columns[19].ReadOnly = true;
            dgvLine.Columns[20].ReadOnly = true;
            dgvLine.Columns[21].ReadOnly = true;
            dgvLine.Columns[22].ReadOnly = true;
            dgvLine.Columns[23].ReadOnly = true;
            dgvLine.Columns[24].ReadOnly = true;
            dgvLine.Columns[68].ReadOnly = true;
            dgvLine.Columns[70].ReadOnly = true;
        }

        private void bindingNavigatorFilter_Click(object sender, EventArgs e)
        {
            if (Filter_Click != null)
                Filter_Click(sender, e);
        }

        private void POReceiptForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void bindingNavigatorNew_Click(object sender, EventArgs e)
        {
            if (New_Click != null)
                New_Click(sender, e);
        }

        private void txtVendorNum_ButtonClick(object sender, EventArgs e)
        {
            if (Find_Vendor != null)
                Find_Vendor(sender, e);
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            dgvLine.EndEdit();

            if (Save_Click != null)
                Save_Click(sender, e);
        }

        private void butGenReceiptNo_Click(object sender, EventArgs e)
        {
            if (GenerateGRN != null)
                GenerateGRN(sender, e);
        }

        private void butGetPO_Click(object sender, EventArgs e)
        {
            if (GetPO != null)
                GetPO(sender, e);
        }

        private void dgvRcv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRcv.CurrentRow == null) return;
            if (dgvRcv.CurrentRow.Index == -1) return;

            if (Seleted_RCV != null)
                Seleted_RCV(sender, e);
        }

        private void dgvLine_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            double newInteger = 0;
            if(e.ColumnIndex == 15)
            {
                if(headSeleted.ReceiptMethod == "RECEIVE")
                {
                    if (!double.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger < 0)
                    {
                        MessageBox.Show("Invalid input number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                else if (headSeleted.ReceiptMethod == "RETURN")
                {
                    if (!double.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger > 0)
                    {
                        MessageBox.Show("Invalid input number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }

                if (!headSeleted.ReceivedFlag)
                {
                    double receivedQty = newInteger;
                    var row = (POReceiptLineModel)dgvLine.CurrentRow.DataBoundItem;
                    if (newInteger > (row.QuantityOrdered - row.QuantityReceived))
                    {
                        MessageBox.Show("Receive qty. must less than or equal remainning balance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
            }

        }

        private void dgvLine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLine.CurrentRow == null) return;
            if (dgvLine.CurrentRow.Index == -1) return;

            if (Seleted_Line != null)
                Seleted_Line(sender, e);
        }

        private void butQCConfirm_Click(object sender, EventArgs e)
        {
            if (Confirm_QC != null)
                Confirm_QC(sender, e);
        }

        public void LineRefresh()
        {
            dgvLine.Refresh();
        }

        private void tnvReceived_Click(object sender, EventArgs e)
        {
            if (Received_Click != null)
                Received_Click(sender, e);
        }

        private void dgvLine_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {
            string strSortDirection = e.Column.SortMode.ToString();
        }

        private void dgvLine_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLine.CurrentRow == null) return;
            if (dgvLine.CurrentRow.Index == -1) return;

            if (Seleted_Line != null)
                Seleted_Line(sender, e);
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Delete_Row != null)
                Delete_Row(sender, e);
        }

        private void bindingNavigatorDelete_Click(object sender, EventArgs e)
        {
            //
            if (Test_Object != null)
                Test_Object(sender, e);
        }

        private void printPurchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Print_Received != null)
                Print_Received(sender, e);
        }

        private void cboReceiveMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Method_Change != null)
                Method_Change(sender, e);
        }

        private void txtSelectGRN_ButtonClick(object sender, EventArgs e)
        {
            if (Get_GRN != null)
                Get_GRN(sender, e);
        }

        private void txtSelectGRN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Get_GRN != null)
                    Get_GRN(sender, e);
            }
        }

        private void dgvRcv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRcv.CurrentRow == null) return;
            if (dgvRcv.CurrentRow.Index == -1) return;

            if (Seleted_RCV != null)
                Seleted_RCV(sender, e);
        }
    }
}
