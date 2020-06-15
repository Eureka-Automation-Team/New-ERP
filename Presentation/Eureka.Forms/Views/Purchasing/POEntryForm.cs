using Eureka.Core.Domain.Projects;
using Eureka.Core.Domain.Purchasing;
using Eureka.Core.Domain.Security;
using Eureka.Froms.Presentations.Purchasing;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Purchasing
{
    public partial class POEntryForm : MetroForm, IPOEntryView
    {
        private POEntryPresenter _presenter;
        private BindingSource bindingLine;
        private List<POHeaderModel> _poList;
        private POHeaderModel _poHead;
        private List<POLineModel> _poLine;
        private POLineModel _poLineSelected;
        private List<CostGroupModel> _costs;
        private List<ProjectCostModel> _projBudget;

        public POEntryForm(POHeaderModel po)
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            _presenter = new POEntryPresenter(this);

            bindingLine = new BindingSource();

            this.dgvLine.RowPrePaint
                            += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(
                                this.dgvLine_RowPrePaint);

            this.dgvBudget.RowPrePaint
                            += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(
                                this.dgvBudget_RowPrePaint);

            if (po != null)
                poHead = po;
        }

        private void dgvBudget_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            double budgetRemaining = (double)dgvBudget.Rows[e.RowIndex].Cells["RemainPercentage"].Value;

            if (budgetRemaining > 25)
            {
                dgvBudget.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgvBudget.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
            else if (budgetRemaining <= 25 && budgetRemaining != 0)
            {
                dgvBudget.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;
                dgvBudget.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
            else
            {
                dgvBudget.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                dgvBudget.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void dgvLine_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (!poHead.ApprovedFlag)
            {
                if ((bool)dgvLine.Rows[e.RowIndex].Cells[42].Value)
                {
                    dgvLine.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    dgvLine.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;
                }
            }
        }

        public List<POHeaderModel> poList
        {
            get { return _poList; }
            set { _poList = value; }
        }

        public POHeaderModel poHead
        {
            get
            {
                if (_poHead != null)
                {
                    _poHead.Remarks = txtRemarks.Text;
                    _poHead.VendorNum = txtVendorNum.Text;
                    _poHead.TermCode = txtTermCode.Text;
                    _poHead.TaxCode = txtTaxCode.Text;
                    _poHead.ProjectNum = txtProjectNum.Text;
                    _poHead.Rate = Convert.ToDouble(string.IsNullOrEmpty(txtRate.Text) ? "0" : txtRate.Text);
                    _poHead.TypeLookupCode = cboTypeLookupCode.Text.Trim();
                    _poHead.ApprovedFlag = chkApprovedFlag.Checked;
                    _poHead.JobFlag = chkJobFlag.Checked;
                    _poHead.PODate = dtpPODate.Value;
                    _poHead.Discount = Convert.ToDouble(string.IsNullOrEmpty(txtDiscount.Text) ? "0" : txtDiscount.Text);
                    _poHead.Freight = Convert.ToDouble(string.IsNullOrEmpty(txtFreight.Text) ? "0" : txtFreight.Text);
                }

                return _poHead;
            }
            set
            {
                _poHead = value;
                if (value != null)
                {
                    txtPoNum.Text = value.PoNum;
                    cboTypeLookupCode.Text = value.TypeLookupCode;
                    dtpPODate.Value = value.PODate;
                    txtVendorNum.Text = value.VendorNum;
                    txtVendorName.Text = value.VendorName;
                    txtTermCode.Text = value.TermCode;
                    txtTermDesc.Text = value.TermDesc;
                    cboStatusCode.Text = value.StatusCode;
                    txtCurrencyCode.Text = value.CurrencyCode;
                    txtCurrencyCode1.Text = value.CurrencyCode;
                    txtCurrencyCode2.Text = value.CurrencyCode;
                    txtCurrencyCode3.Text = value.CurrencyCode;
                    txtCurrencyCode4.Text = value.CurrencyCode;
                    txtCurrencyCode5.Text = value.CurrencyCode;
                    txtRate.Text = value.Rate.ToString("#0.00000");
                    txtBuyerName.Text = value.BuyerName;
                    txtTaxCode.Text = value.TaxCode;
                    txtTaxRate.Text = value.TaxRate.ToString();
                    txtRemarks.Text = value.Remarks;
                    txtProjectNum.Text = value.ProjectNum;
                    chkJobFlag.Checked = value.JobFlag;
                    chkApprovedFlag.Checked = value.ApprovedFlag;
                    chkCancelFlag.Checked = value.CancelFlag;
                    chkReceivedFlag.Checked = value.ReceivedFlag;

                    revicseMenuItem.Enabled = value.ApprovedFlag;
                    tnvSubmitPO.Enabled = !value.SubmitFlag;
                    mnuDeleteRow.Enabled = !value.SubmitFlag;
                    tnvUnSubmitPO.Enabled = value.SubmitFlag;
                    printPurchaseOrderToolStripMenuItem.Enabled = value.SubmitFlag;
                    //bindingNavigatorSaveItem.Enabled = !value.SubmitFlag;
                    bindingNavigatorSaveItem.Enabled = !value.ReceivedFlag;
                    cancelRowToolStripMenuItem.Enabled = !value.ReceivedFlag;
                    tnvCancelPO.Enabled = !value.CancelFlag;
                    tnvUnSubmitPO.Enabled = !value.ApprovedFlag;

                    if (value.CancelFlag)
                    {
                        tnvSubmitPO.Enabled = false;
                        mnuDeleteRow.Enabled = false;
                        tnvUnSubmitPO.Enabled = false;
                        printPurchaseOrderToolStripMenuItem.Enabled = false;
                        bindingNavigatorSaveItem.Enabled = false;
                    }

                    chkApprovedFlag.Enabled = value.SubmitFlag;
                    if (value.CurrencyCode == "THB")
                    {
                        txtSubTotal.Text = value.SubTotal.ToString("#,##0.00");
                        txtDiscount.Text = value.Discount.ToString("#,##0.00");
                        txtTaxAmount.Text = value.TaxAmount.ToString("#,##0.00");
                        txtFreight.Text = value.Freight.ToString("#,##0.00");
                        txtTotalAmount.Text = value.TotalAmount.ToString("#,##0.00");
                    }
                    else
                    {
                        txtSubTotal.Text = value.SubTotal.ToString("#,##0.000");
                        txtDiscount.Text = value.Discount.ToString("#,##0.000");
                        txtTaxAmount.Text = value.TaxAmount.ToString("#,##0.000");
                        txtFreight.Text = value.Freight.ToString("#,##0.000");
                        txtTotalAmount.Text = value.TotalAmount.ToString("#,##0.000");
                    }
                        
                    if (string.IsNullOrEmpty(value.PoNum))
                        cboTypeLookupCode.Enabled = true;
                    else
                        cboTypeLookupCode.Enabled = false;
                }
            }
        }

        public List<POLineModel> poLine
        {
            get { return _poLine; }
            set { _poLine = value; }
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public List<CostGroupModel> costs
        {
            get { return _costs; }
            set { _costs = value; }
        }

        public POLineModel poLineSelected
        {
            get { return _poLineSelected; }
            set { _poLineSelected = value; }
        }

        public List<ProjectCostModel> projBudget
        {
            get { return _projBudget; }
            set { _projBudget = value; }
        }

        public BindingSource bindingBudgetLines
        {
            get { return projectCostModelBindingSource; }
            set { projectCostModelBindingSource = value; }
        }

        public BindingSource bindingHead
        {
            get { return pOHeaderModelBindingSource; }
            set { pOHeaderModelBindingSource = value; }
        }

        //public double poDiscount
        //{
        //    get { return Convert.ToDouble(string.IsNullOrEmpty(txtDiscount.Text) ? "0" : txtDiscount.Text); }
        //    set { txtDiscount.Text = value.ToString("#,##0.000"); }
        //}

        //public double poFreight
        //{
        //    get { return Convert.ToDouble(string.IsNullOrEmpty(txtFreight.Text) ? "0" : txtFreight.Text); }
        //    set { txtFreight.Text = value.ToString("#,##0.000"); }
        //}

        public event EventHandler Form_Load;

        public event EventHandler Filter_Click;

        public event EventHandler Save_Click;

        public event EventHandler New_Click;

        public event EventHandler SubmitPO_Click;

        public event EventHandler Find_Vendor;

        public event EventHandler Find_Term;

        public event EventHandler Find_Currency;

        public event EventHandler Find_TaxCode;

        public event EventHandler Find_Project;

        public event EventHandler Seleted_PO;

        public event EventHandler Paste_Rows;

        public event EventHandler Delete_Row;

        public event EventHandler Print_PO;

        public event EventHandler Type_Change;

        public event EventHandler Approved_Click;
        public event EventHandler UnSubmitPO_Click;
        public event EventHandler GetLine_Selected;
        public event EventHandler Refresh_Click;
        public event EventHandler Cancel_Click;
        public event EventHandler Cancel_Line;
        public event EventHandler LineAdjustment;

        public void BindingPO(List<POHeaderModel> list)
        {
            if (list != null)
            {
                try
                {
                    bindingHead.DataSource = list;
                    bindingNav.BindingSource = bindingHead;
                    dgvPOs.DataSource = bindingHead;

                    //dgvPOs.Columns.Add(CreateComboBoxWithEnums());

                    SetPOGrid();
                }
                catch
                {
                    SetPOGrid();
                    return;
                }
            }
        }

        DataGridViewComboBoxColumn CreateComboBoxWithEnums()
        {
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.DataSource = this.poList;
            combo.DataPropertyName = "PoNum";
            combo.Name = "PoNum";
            return combo;
        }

        private void SetPOGrid()
        {
            /*
            dgvPOs.Columns[0].Visible = false;
            //dgvPOs.Columns[1].Visible = false;
            //dgvPOs.Columns[2].Visible = false;
            dgvPOs.Columns[3].Visible = false;
            dgvPOs.Columns[4].Visible = false;
            dgvPOs.Columns[5].Visible = false;
            dgvPOs.Columns[6].Visible = false;
            dgvPOs.Columns[7].Visible = false;
            dgvPOs.Columns[8].Visible = false;
            dgvPOs.Columns[9].Visible = false;
            //dgvPOs.Columns[10].Visible = false;
            //dgvPOs.Columns[11].Visible = false;
            dgvPOs.Columns[12].Visible = false;
            dgvPOs.Columns[13].Visible = false;
            dgvPOs.Columns[14].Visible = false;
            dgvPOs.Columns[15].Visible = false;
            dgvPOs.Columns[16].Visible = false;
            dgvPOs.Columns[17].Visible = false;
            dgvPOs.Columns[18].Visible = false;
            dgvPOs.Columns[19].Visible = false;
            dgvPOs.Columns[20].Visible = false;
            dgvPOs.Columns[21].Visible = false;
            dgvPOs.Columns[22].Visible = false;
            dgvPOs.Columns[23].Visible = false;
            dgvPOs.Columns[24].Visible = false;
            dgvPOs.Columns[25].Visible = false;
            dgvPOs.Columns[26].Visible = false;
            dgvPOs.Columns[27].Visible = false;
            dgvPOs.Columns[28].Visible = false;
            dgvPOs.Columns[29].Visible = false;
            dgvPOs.Columns[30].Visible = false;
            dgvPOs.Columns[31].Visible = false;
            dgvPOs.Columns[32].Visible = false;
            dgvPOs.Columns[33].Visible = false;
            dgvPOs.Columns[34].Visible = false;
            dgvPOs.Columns[35].Visible = false;
            dgvPOs.Columns[36].Visible = false;
            dgvPOs.Columns[37].Visible = false;
            dgvPOs.Columns[38].Visible = false;
            dgvPOs.Columns[39].Visible = false;
            dgvPOs.Columns[40].Visible = false;
            dgvPOs.Columns[41].Visible = false;
            dgvPOs.Columns[42].Visible = false;
            dgvPOs.Columns[43].Visible = false;
            //dgvPOs.Columns[44].Visible = false;
            dgvPOs.Columns[45].Visible = false;
            dgvPOs.Columns[46].Visible = false;
            dgvPOs.Columns[47].Visible = false;
            //dgvPOs.Columns[48].Visible = false;
            
            dgvPOs.Columns[2].DefaultCellStyle.Format = "dd-MMM-yyyy";

            dgvPOs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPOs.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPOs.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            */
            dgvPOs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvPOs.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvPOs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvPOs.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvPOs.MultiSelect = false;
            dgvPOs.RowHeadersVisible = true;

            dgvPOs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPOs.AllowUserToResizeColumns = true;
        }

        private void POEntryForm_Leave(object sender, EventArgs e)
        {
        }

        private void POEntryForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void bindingNavigatorFilter_Click(object sender, EventArgs e)
        {
            if (Filter_Click != null)
                Filter_Click(sender, e);
        }

        private void metroLabel13_Click(object sender, EventArgs e)
        {
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (Save_Click != null)
                Save_Click(sender, e);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (New_Click != null)
                New_Click(sender, e);
        }

        private void bindingNavigatorNew_Click(object sender, EventArgs e)
        {
            if (New_Click != null)
                New_Click(sender, e);
        }

        private void tnvSubmitPO_Click(object sender, EventArgs e)
        {
            if (SubmitPO_Click != null)
                SubmitPO_Click(sender, e);
        }

        private void txtVendorNum_ButtonClick(object sender, EventArgs e)
        {
            if (Find_Vendor != null)
                Find_Vendor(sender, e);
        }

        private void txtTermCode_ButtonClick(object sender, EventArgs e)
        {
            if (Find_Term != null)
                Find_Term(sender, e);
        }

        private void txtTaxCode_ButtonClick(object sender, EventArgs e)
        {
            if (Find_TaxCode != null)
                Find_TaxCode(sender, e);
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtCurrencyCode_ButtonClick(object sender, EventArgs e)
        {
            if (Find_Currency != null)
                Find_Currency(sender, e);
        }

        private void txtProjectNum_ButtonClick(object sender, EventArgs e)
        {
            if (Find_Project != null)
                Find_Project(sender, e);
        }

        private void dgvPOs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPOs.CurrentRow == null) return;
            if (dgvPOs.CurrentRow.Index == -1) return;

            if (Seleted_PO != null)
                Seleted_PO(sender, e);
        }

        public void BindingLines(List<POLineModel> list)
        {
            if (list != null)
            {
                try
                {
                    bindingLine.DataSource = list;
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
            //dgvLine.Columns[2].Visible = false;
            //dgvLine.Columns[3].Visible = false;
            //dgvLine.Columns[4].Visible = false;
            //dgvLine.Columns[5].Visible = false;
            //dgvLine.Columns[6].Visible = false;
            //dgvLine.Columns[7].Visible = false;
            //dgvLine.Columns[8].Visible = false;
            //dgvLine.Columns[9].Visible = false;
            //dgvLine.Columns[10].Visible = false;
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
            dgvLine.Columns[22].Visible = false;
            dgvLine.Columns[23].Visible = false;
            dgvLine.Columns[24].Visible = false;
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
            //dgvLine.Columns[41].Visible = false;  //Cancel
            dgvLine.Columns[42].Visible = false;  //Dupplicat Flag
            dgvLine.Columns[43].Visible = false;
            dgvLine.Columns[44].Visible = false;
            dgvLine.Columns[46].Visible = false;

            //dgvLine.Columns[20].ty = DataGridViewComboBoxColumn
            dgvLine.Columns[14].DefaultCellStyle.Format = "dd/MM/yy";
            dgvLine.Columns[18].DefaultCellStyle.Format = "dd/MM/yy";

            if (poHead.CurrencyCode == "THB")
            {
                dgvLine.Columns[6].DefaultCellStyle.Format = "#,##0.00";
                dgvLine.Columns[13].DefaultCellStyle.Format = "#,##0.00";
                dgvLine.Columns[19].DefaultCellStyle.Format = "#,##0.00";
                dgvLine.Columns[45].DefaultCellStyle.Format = "#,##0.00";
            }                
            else
            {
                dgvLine.Columns[6].DefaultCellStyle.Format = "#,##0.000";
                dgvLine.Columns[13].DefaultCellStyle.Format = "#,##0.000";            
                dgvLine.Columns[19].DefaultCellStyle.Format = "#,##0.000";
                dgvLine.Columns[45].DefaultCellStyle.Format = "#,##0.000";
            }
                
            dgvLine.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLine.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLine.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLine.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLine.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLine.Columns[45].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvLine.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvLine.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvLine.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvLine.MultiSelect = true;
            dgvLine.RowHeadersVisible = true;

            dgvLine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLine.AllowUserToResizeColumns = true;
            dgvLine.Columns[2].ReadOnly = true;
            dgvLine.Columns[13].ReadOnly = true;
            dgvLine.Columns[45].ReadOnly = true;
        }

        private void mnuPasteRows_Click(object sender, EventArgs e)
        {
            if (Paste_Rows != null)
                Paste_Rows(sender, e);
        }

        public void PasteClipboard()
        {
            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {
                string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                foreach (string pastedRow in pastedRows)
                {
                    string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });

                    int myRowIndex = dgvLine.CurrentRow.Index;// - 1;

                    using (DataGridViewRow myDataGridViewRow = dgvLine.Rows[myRowIndex])
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            myDataGridViewRow.Cells[i + 1].Value = pastedRowCells[i];
                    }
                    dgvLine.Rows.Add();
                }
            }
        }

        private void dgvLine_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var grid = sender as DataGridView;
            //var rowIdx = (e.RowIndex + 1).ToString();

            //var centerFormat = new StringFormat()
            //{
            //    // right alignment might actually make more sense for numbers
            //    Alignment = StringAlignment.Center,
            //    LineAlignment = StringAlignment.Center
            //};

            //var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            //e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void printPurchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Print_PO != null)
                Print_PO(sender, e);
        }

        private void cboTypeLookupCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Type_Change != null)
                Type_Change(sender, e);
        }

        public void ActiveJobFlag(string type)
        {
            //POHeaderModel po = this.poHead;
            if (type == "MAKING" && string.IsNullOrEmpty(txtPoNum.Text))
            {
                chkJobFlag.Enabled = true;
            }
            else if (type == "STANDARD")
            {
                chkJobFlag.Enabled = false;
                chkJobFlag.Checked = false;
            }
            else
            {
                chkJobFlag.Enabled = false;
                chkJobFlag.Checked = false;
            }
        }

        private void chkApprovedFlag_CheckedChanged(object sender, EventArgs e)
        {
            //if (Approved_Click != null)
            //    Approved_Click(sender, e);
        }

        public string GetNote()
        {
            string note = string.Empty;
            try
            {
                note = txtRemarks.Text;
            }
            catch
            {
                note = string.Empty;
            }

            return note;
        }

        private void tnvUnSubmitPO_Click(object sender, EventArgs e)
        {
            if (UnSubmitPO_Click != null)
                UnSubmitPO_Click(sender, e);
        }

        private void mnuDeleteRow_Click(object sender, EventArgs e)
        {
            if (Delete_Row != null)
                Delete_Row(dgvLine, e);
        }

        private void dgvLine_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLine.CurrentRow == null) return;
            if (dgvLine.CurrentRow.Index == -1) return;

            if (GetLine_Selected != null)
                GetLine_Selected(sender, e);
        }

        private void bindingNavigatorRefreshItem_Click(object sender, EventArgs e)
        {
            if (Refresh_Click != null)
                Refresh_Click(sender, e);
        }

        private void dgvLine_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            //ProjectModel current = ((BindingList<ProjectModel>)dgvLine.DataSource)[e.RowIndex];
            //string key = current.Id.ToString();
            //string value = current.ProjectNum;
            //string cellValue = e.Value.ToString();

            //if (e.ColumnIndex == 20)
            //    key = cellValue;
            //else value = cellValue;
            //    ((BindingList<ProjectModel>)dgvLine.DataSource)[e.RowIndex] = new ProjectModel { Id = Convert.ToInt32(key), ProjectNum = value };
        }

        private void tnvCancelPO_Click(object sender, EventArgs e)
        {
            if (Cancel_Click != null)
                Cancel_Click(sender, e);
        }

        private void dgvPOs_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPOs.CurrentRow == null) return;
            if (dgvPOs.CurrentRow.Index == -1) return;

            if (Seleted_PO != null)
                Seleted_PO(sender, e);
        }

        private void dgvPOs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPOs.CurrentRow == null) return;
            if (dgvPOs.CurrentRow.Index == -1) return;

            if (Seleted_PO != null)
                Seleted_PO(sender, e);
        }

        public void BindingBudgetLines(List<ProjectCostModel> list)
        {
            if (list != null)
            {
                if (list != null)
                {
                    try
                    {
                        dgvBudget.Rows.Clear();
                        bindingBudgetLines.DataSource = null;
                        bindingBudgetLines.DataSource = projBudget;
                        SetBudgetGrid();
                    }
                    catch
                    {
                        dgvBudget.Rows.Clear();
                        return;
                    }
                }
            }
        }

        private void SetBudgetGrid()
        {
            dgvBudget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvBudget.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvBudget.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvBudget.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvBudget.MultiSelect = true;
            dgvBudget.RowHeadersVisible = true;
            dgvBudget.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        public void RefreshBudgetGrid()
        {
            dgvBudget.Refresh();
        }

        private void cancelRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLine.CurrentRow == null) return;
            if (dgvLine.CurrentRow.Index == -1) return;

            if (Cancel_Line != null)
                Cancel_Line(dgvLine, e);
        }

        private void mnuLineAdjustment_Click(object sender, EventArgs e)
        {
            if (LineAdjustment != null)
                LineAdjustment(sender, e);
        }
    }
}