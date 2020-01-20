using Eureka.Core.Domain.Inventory;
using Eureka.Core.Domain.Projects;
using Eureka.Core.Domain.Purchasing;
using Eureka.Core.Domain.Security;
using Eureka.Froms.Presentations.Purchasing;
using MetroFramework.Forms;
using PagedList;
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
    public partial class RequisitionEntryForm : MetroForm, IRequisitionEntryView
    {
        private readonly RequisitionEntryPresenter _presenter;
        private RequisitionHeaderModel _reqHead;
        private List<RequisitionLineModel> _reqLines;
        private List<ProjectCostModel> _projBudget;
        private List<ProjectCostModel> _projectCosts;
        private List<RequisitionLineModel> _reqLinesSelected;
        private List<RequisitionHeaderModel> _reqHeaderList;
        private List<ProjectModel> _projects;
        private ProjectModel _projHead;
        private List<ItemMasterModel> _items;

        public RequisitionEntryForm()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            _presenter = new RequisitionEntryPresenter(this);

            this.dgvLines.RowPrePaint
                += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(
                    this.dgvLines_RowPrePaint);

            this.dgvBudget.RowPrePaint
                += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(
                    this.dgvBudget_RowPrePaint);
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

        private void dgvLines_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (reqHead.PoConfirmedFlag)
            {
                dgvLines.Rows[e.RowIndex].Cells["colSubmitFlag"].ReadOnly = true;
            }
            else
            {
                dgvLines.Rows[e.RowIndex].Cells["colSubmitFlag"].ReadOnly = false;
            }

            bool rejectFlag = (bool)dgvLines.Rows[e.RowIndex].Cells["colRejectFlag1"].Value;
            if (rejectFlag)
            {
                dgvLines.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                dgvLines.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else if (!rejectFlag)
            {
                dgvLines.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgvLines.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }

            if (!reqHead.ApprovedFlag)
            {
                if ((bool)dgvLines.Rows[e.RowIndex].Cells["DupplicateFlag"].Value)
                {
                    dgvLines.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    dgvLines.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Red;
                }
            }
        }

        public RequisitionHeaderModel reqHead
        {
            get
            {
                if (_reqHead != null)
                {
                    _reqHead.RequisitionDate = dtpRequisitionDate.Value;
                    _reqHead.BomNumber = txtBomNumber.Text.Trim();

                    //try
                    //{
                    //    var costSelected = ((CostGroupModel)cboCostCode.SelectedItem);
                    //    //_reqHead.CostCode = costSelected.CostCode;
                    //    _reqHead.CostId = costSelected.Id;
                    //}
                    //catch { }
                }

                return _reqHead;
            }
            set
            {
                _reqHead = value;

                if(_reqHead != null)
                {
                    txtRequisitionNumber.Text = _reqHead.RequisitionNumber;
                    dtpRequisitionDate.Value = _reqHead.RequisitionDate;
                    txtSubinventoryCode.Text = _reqHead.ProjectNo;
                    txtApproverName.Text = _reqHead.ApproverName;
                    txtRequesterName.Text = _reqHead.RequesterName;
                    txtBomNumber.Text = _reqHead.BomNumber;

                    cboStatusCode.Text = _reqHead.Status;
                    cboCostCode.Text = _reqHead.CostCode;

                    chkPoConfirmedFlag.Checked = _reqHead.PoConfirmedFlag;
                    chkSubmitFlag.Checked = _reqHead.SubmitFlag;
                    chkApprovedFlag.Checked = _reqHead.ApprovedFlag;
                    chkCancelFlag.Checked = _reqHead.CancelFlag;
                    chkPurchasedFlag.Checked = _reqHead.PurchasedFlag;

                    tnvSubmit.Enabled = !_reqHead.SubmitFlag;
                    bindingNavRemove.Enabled = !_reqHead.SubmitFlag;
                    tnvUnSubmit.Enabled = _reqHead.SubmitFlag;
                    printPurchaseOrderToolStripMenuItem.Enabled = _reqHead.SubmitFlag;
                    bindingNavigatorSaveItem.Enabled = !_reqHead.SubmitFlag;
                    tnvConvertToPO.Enabled = false;// _reqHead.ApprovedFlag;

                    if (_reqHead.CancelFlag)
                    {
                        tnvSubmit.Enabled = false;
                        bindingNavRemove.Enabled = false;
                        tnvUnSubmit.Enabled = false;
                        tnvConvertToPO.Enabled = false;
                        bindingNavigatorSaveItem.Enabled = false;
                    }

                    chkApprovedFlag.Enabled = _reqHead.SubmitFlag;
                    tnvSubmit.Enabled = _reqHead.PoConfirmedFlag;
                    //chkPoConfirmedFlag.Enabled = !_reqHead.SentPoConfirmFlag;
                    sendToConfirmPriceToolStripMenuItem.Enabled = !_reqHead.PoConfirmedFlag;
                    if (_reqHead.SentPoConfirmFlag && !_reqHead.PoConfirmedFlag)
                    {
                        sendToConfirmPriceToolStripMenuItem.Text = "Send to Confirm price (Waitting Confirm...)";
                    }
                    else
                        sendToConfirmPriceToolStripMenuItem.Text = "Send to Confirm price";
                }
            }
        }
        public List<RequisitionLineModel> reqLines
        {
            get { return _reqLines; }
            set { _reqLines = value; }
        }
        public List<RequisitionHeaderModel> reqHeaderList
        {
            get { return _reqHeaderList; }
            set { _reqHeaderList = value; }
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public List<ProjectModel> projects
        {
            get { return _projects; }
            set { _projects = value; }
        }

        public ProjectModel projHead
        {
            get { return _projHead; }
            set { _projHead = value; }
        }

        public BindingSource bindingLine
        {
            get { return requisitionLineModelBindingSource; }
            set { requisitionLineModelBindingSource = value; }
        }

        public List<RequisitionLineModel> reqLinesSelected
        {
            get { return _reqLinesSelected; }
            set
            {
                _reqLinesSelected = value;

                #region Validate Submit permission
                mnuLineSubmit.Enabled = false;
                mnuLineUnSubmit.Enabled = false;
                mnuApprove.Enabled = false;
                mnuReject.Enabled = false;

                var grpLinesConfirmStatus = _reqLinesSelected.GroupBy(grp => grp.PriceConfirmedFlag)
                     .Select(group => new { ConfirmFlag = group.Key, lines = group.ToList() })
                     .ToList();

                if (grpLinesConfirmStatus.Count() == 1)
                {
                    if (grpLinesConfirmStatus.FirstOrDefault().ConfirmFlag)
                    {
                        var grpLinesStatus = _reqLinesSelected.GroupBy(grp => grp.SubmitFlag)
                                             .Select(group => new { SubmitFlag = group.Key, lines = group.ToList() })
                                             .ToList();

                        //If not multiple status.
                        if (grpLinesStatus.Count() == 1)
                        {
                            //If PR not submited all lines.
                            if (!grpLinesStatus.FirstOrDefault().SubmitFlag)
                            {
                                var grpLinesApprv = _reqLinesSelected.GroupBy(grp => grp.ApprovedFlag)
                                                 .Select(group => new { ApprvFlag = group.Key, lines = group.ToList() })
                                                 .ToList();
                                if (grpLinesApprv.Count() == 1)
                                {
                                    if (!grpLinesApprv.FirstOrDefault().ApprvFlag)
                                    {
                                        mnuLineSubmit.Enabled = true;
                                        mnuLineUnSubmit.Enabled = false;
                                    }
                                    else
                                        mnuLineSubmit.Enabled = false;
                                }
                            }
                            else
                            {
                                var grpLinesApprv = _reqLinesSelected.GroupBy(grp => grp.ApprovedFlag)
                                                 .Select(group => new { ApprvFlag = group.Key, lines = group.ToList() })
                                                 .ToList();
                                if (grpLinesApprv.Count() == 1)
                                {
                                    if (!grpLinesApprv.FirstOrDefault().ApprvFlag)
                                    {
                                        mnuLineUnSubmit.Enabled = true;
                                        mnuLineSubmit.Enabled = false;
                                    }
                                    else
                                        mnuLineUnSubmit.Enabled = false;
                                }
                            }
                        }
                    }
                }
                #endregion

                #region Validate Approve permission
                var grpLinesSubmitStatus = _reqLinesSelected.GroupBy(grp => grp.SubmitFlag)
                     .Select(group => new { SubmitFlag = group.Key, lines = group.ToList() })
                     .ToList();

                if (grpLinesSubmitStatus.Count() == 1)
                {
                    if (grpLinesSubmitStatus.FirstOrDefault().SubmitFlag)
                    {
                        var grpLinesStatus = _reqLinesSelected.GroupBy(grp => grp.ApprovedFlag)
                                             .Select(group => new { ApprovedFlag = group.Key, lines = group.ToList() })
                                             .ToList();

                        //If not multiple status.
                        if (grpLinesStatus.Count() == 1)
                        {
                            //If PR Not Approve all lines.
                            if (!grpLinesStatus.FirstOrDefault().ApprovedFlag)
                            {
                                mnuReject.Enabled = true;
                                mnuApprove.Enabled = true;
                            }
                            else
                            {
                                var grpLinesPurchased = _reqLinesSelected.GroupBy(grp => grp.PurchasedFlag)
                                                  .Select(group => new { PurchasedFlag = group.Key, lines = group.ToList() })
                                                  .ToList();
                                if (grpLinesPurchased.Count() == 1)
                                {
                                    if (!grpLinesPurchased.FirstOrDefault().PurchasedFlag)
                                    {
                                        mnuReject.Enabled = true;
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                #region Validate Duplicated list
                if(_reqLinesSelected.Count == 1)
                {
                    var grpLinesDuplicated = _reqLinesSelected.GroupBy(grp => grp.DupplicateFlag)
                                             .Select(group => new { DuplicateFlag = group.Key, lines = group.ToList() })
                                             .ToList();

                    if (grpLinesDuplicated.Count() == 1)
                    {
                        if (grpLinesDuplicated.FirstOrDefault().DuplicateFlag)
                        {
                            mnuDuplicated.Enabled = true;
                        }
                        else
                        {
                            mnuDuplicated.Enabled = false;
                        }
                    }
                }

                #endregion
            }
        }

        public List<ProjectCostModel> projectCosts
        {
            get { return _projectCosts; }
            set { _projectCosts = value; }
        }

        public List<ItemMasterModel> items
        {
            get { return _items; }
            set { _items = value; }
        }

        public BindingSource bindingBudgetLines
        {
            get { return projectCostModelBindingSource; }
            set { projectCostModelBindingSource = value; }
        }
        public List<ProjectCostModel> projBudget
        {
            get { return _projBudget; }
            set { _projBudget = value; }
        }

        public CostGroupModel costSelected
        {
            get { return (CostGroupModel)cboCostCode.SelectedItem; }
            set { cboCostCode.SelectedItem = value; }
        }

        public event EventHandler Form_Load;
        //public event EventHandler Filter_Click;
        public event EventHandler Save_Click;
        public event EventHandler New_Click;
        //public event EventHandler Print_PR;
        //public event EventHandler Type_Change;
        public event EventHandler Refresh_Click;
        public event EventHandler Find_Project;
        //public event EventHandler Find_User;
        public event EventHandler Find_Requester;
        public event EventHandler Find_Approver;
        public event EventHandler Find_Boms;
        public event EventHandler Selection_Change;
        //public event EventHandler ValidateLine;
        public event EventHandler ValidateCells;
        public event EventHandler New_Line;
        public event EventHandler BOM_Changed;
        public event EventHandler CostCode_Changed;
        public event EventHandler PasteStandard_Rows;
        public event EventHandler PasteMaking_Rows;
        public event EventHandler Delete_Row;
        public event EventHandler GetLine_Selected;
        public event EventHandler Submit_Click;
        public event EventHandler UnSubmit_Click;
        public event EventHandler Approved_Click;
        public event EventHandler ConvertPO_Click;
        public event EventHandler Find_Items;
        public event EventHandler Set_DueDate;
        public event EventHandler SendPOConfirm_Click;
        public event EventHandler SendLinePOConfirm_Click;
        public event EventHandler LineSubmit_Click;
        public event EventHandler LineUnSubmit_Click;
        public event EventHandler LineApprove_Click;
        public event EventHandler LineReject_Click;
        public event EventHandler DuplicateList_Click;

        public void ActiveJobFlag(string type)
        {
            throw new NotImplementedException();
        }

        public void BindingLines(List<RequisitionLineModel> list)
        {
            if (list != null)
            {
                if (list != null)
                {
                    try
                    {
                        dgvLines.Rows.Clear();
                        bindingLine.DataSource = null;
                        bindingLine.DataSource = reqLines;
                        navLines.BindingSource = bindingLine;
                        SetGrid();
                    }
                    catch
                    {
                        dgvLines.Rows.Clear();
                        return;
                    }
                }
            }
        }

        private void SetGrid()
        {
            dgvLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvLines.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvLines.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvLines.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvLines.MultiSelect = true;
            dgvLines.RowHeadersVisible = true;
            dgvLines.ReadOnly = reqHead.SubmitFlag;
        }

        public void BindingTree(List<ProjectModel> prjList, List<RequisitionHeaderModel> reqList)
        {
            if (prjList != null)
            {         
                tvProjectList.Nodes.Clear();
                
                foreach (var i in prjList.OrderBy(x => x.ProjectDate))
                {
                    TreeNode nodeChild = new TreeNode(i.ProjectNum);
                    nodeChild.Name = i.ProjectNum;
                    nodeChild.Tag = i;
                    nodeChild.ImageIndex = 0;
                    nodeChild.SelectedImageIndex = 0;
                    nodeChild.Tag = i;

                    tvProjectList.Nodes.Add(nodeChild);
                }
            }
        }

        private void SetReqHeadGrid()
        {
            throw new NotImplementedException();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void RequisitionEntryForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void bindingNavigatorFilter_Click(object sender, EventArgs e)
        {
            if (Find_Project != null)
                Find_Project(sender, e);
        }

        private void bindingNavigatorNew_Click(object sender, EventArgs e)
        {
            if (New_Click != null)
                New_Click(tvProjectList, e);
        }

        private void txtRequesterName_ButtonClick(object sender, EventArgs e)
        {
            if (Find_Requester != null)
                Find_Requester(sender, e);
        }

        private void txtApproverName_ButtonClick(object sender, EventArgs e)
        {
            if (Find_Approver != null)
                Find_Approver(sender, e);
        }

        private void txtBomNumber_ButtonClick(object sender, EventArgs e)
        {
            if (Find_Boms != null)
                Find_Boms(sender, e);
        }

        public void BindingComboCost(List<CostGroupModel> costs)
        {
            cboCostCode.DataSource = null;
            if(costs != null)
            {
                cboCostCode.Text = string.Empty;
                cboCostCode.DataSource = costs;
                cboCostCode.DisplayMember = "CostCode";
                cboCostCode.ValueMember = "Id";

                if(reqHead != null)
                {
                    cboCostCode.Text = reqHead.CostCode;
                }                
            }
        }

        private void bindingNavigatorRefreshItem_Click(object sender, EventArgs e)
        {
            if (Refresh_Click != null)
                Refresh_Click(sender, e);
        }

        public void DisableBomSelecting()
        {
            txtBomNumber.Enabled = false;
        }

        public void EnableBomSelecting()
        {
            txtBomNumber.Enabled = true;
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            dgvLines.Refresh();

            if (Save_Click != null)
                Save_Click(sender, e);
        }

        public delegate void FunctionDelegate(List<RequisitionHeaderModel> list, ProjectModel prj);
        public void BindingRequisitionByProject(List<RequisitionHeaderModel> list, ProjectModel prj)
        {
            if (list != null)
            {
                var grp = list.GroupBy(g => g.BomNumber)
                    .Select(p => new { Bom = p.Key, Items = p.ToList() })
                    .ToList();

                TreeNode temp = FindNode(tvProjectList, prj.ProjectNum);
                temp.Nodes.Clear();

                foreach (var b in grp)
                {
                    
                    TreeNode nodeChild = new TreeNode(b.Bom);
                    nodeChild.Name = b.Bom;
                    nodeChild.ImageIndex = 1;
                    nodeChild.SelectedImageIndex = 1;

                    if(temp != null)
                    {
                        if (InvokeRequired)
                        {
                            // We're not in the UI thread, so we need to call BeginInvoke
                            BeginInvoke(new FunctionDelegate(BindingRequisitionByProject), list, prj);
                            return;
                        }

                        //tvProjectList.BeginInvoke(new FunctionDelegate(new temp.Nodes.Add(nodeChild)));
                        temp.Nodes.Add(nodeChild);
                        foreach (var req in list.Where(x => x.BomNumber == b.Bom).OrderBy(o => o.RequisitionDate))
                        {
                            TreeNode nodeReq = new TreeNode(req.RequisitionNumber);
                            nodeReq.Name = req.RequisitionNumber;                            
                            nodeReq.Tag = req;
                            nodeReq.ImageIndex = 2;
                            nodeReq.SelectedImageIndex = 2;
                            nodeChild.Nodes.Add(nodeReq);
                        }
                    }
                }
            }
        }

        private TreeNode FindNode(TreeView root, String name)
        {
            foreach (TreeNode node in root.Nodes)
            {
                if (node.Name == name)
                    return node;
            }
            return null;
        }

        private void tvProjectList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Selection_Change != null)
                Selection_Change(sender, e);
        }

        private void dgvLines_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (ValidateLine != null)
            //    ValidateLine(sender, e);
        }

        private void dgvLines_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvLines.Rows[e.RowIndex].IsNewRow) { return; }

            if (ValidateCells != null)
                ValidateCells(sender, e);
        }

        private void requisitionLineModelBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            //if (reqHead == null)
            //    return;

            //if (New_Line != null)
            //    New_Line(requisitionLineModelBindingSource, e);
        }

        private void txtBomNumber_TextChanged(object sender, EventArgs e)
        {
            if (BOM_Changed != null)
                BOM_Changed(sender, e);
        }

        private void cboCostCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCostCode.SelectedIndex != -1)
            {
                if (CostCode_Changed != null)
                    CostCode_Changed(sender, e);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (New_Line != null)
                New_Line(sender, e);
        }

        private void mnuPasteRows_Click(object sender, EventArgs e)
        {
            if (PasteStandard_Rows != null)
                PasteStandard_Rows(sender, e);
        }

        private void pasteMakingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PasteMaking_Rows != null)
                PasteMaking_Rows(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Delete_Row != null)
                Delete_Row(dgvLines, e);
        }

        private void dgvLines_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLines.CurrentRow == null) return;
            if (dgvLines.CurrentRow.Index == -1) return;

            if (GetLine_Selected != null)
                GetLine_Selected(sender, e);
        }

        private void bindingNavAddNew_Click(object sender, EventArgs e)
        {
            if (reqHead == null)
                return;

            if (!string.IsNullOrEmpty(cboCostCode.Text))
                reqHead.CostCode = cboCostCode.Text;

            if (New_Line != null)
                New_Line(sender, e);
        }

        private void bindingNavRemove_Click(object sender, EventArgs e)
        {
            if (Delete_Row != null)
                Delete_Row(dgvLines, e);            
        }

        private void mnuSetDueDate_Click(object sender, EventArgs e)
        {
            if (Set_DueDate != null)
                Set_DueDate(dgvLines, e);
        }


        private void dgvLines_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgvLines_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dgvLines.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() +" / "+ e.FormattedValue);
        }

        private void tnvSubmit_Click(object sender, EventArgs e)
        {
            if (Submit_Click != null)
                Submit_Click(dgvLines, e);
        }

        private void tnvUnSubmit_Click(object sender, EventArgs e)
        {
            if (UnSubmit_Click != null)
                UnSubmit_Click(dgvLines, e);
        }

        private void tnvConvertToPO_Click(object sender, EventArgs e)
        {
            if (ConvertPO_Click != null)
                ConvertPO_Click(dgvLines, e);
        }

        private void chkApprovedFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (Approved_Click != null)
                Approved_Click(sender, e);
        }

        private void dgvLines_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Find_Items != null)
                Find_Items(sender, e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
     
        }

        public void RefreshGird()
        {
            dgvLines.Refresh();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchPR(sender, e);
            }
        }

        private void SearchPR(object sender, KeyEventArgs e)
        {
            TreeNode[] tns = tvProjectList.Nodes.Find(txtSearch.Text, true);
            if (tns.Length > 0)
            {

                tvProjectList.SelectedNode = tns[0];
                tvProjectList.Focus();
            }
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
                        bindingBudgetLines.DataSource = list;
                        SetBudgetGrid();
                    }
                    catch
                    {
                        dgvBudget.Rows.Clear();
                        return;
                    }
                }
            }

            dgvBudget.Refresh();
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

        private void sendToConfirmPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvLines.Refresh();

            if (Save_Click != null)
                Save_Click(sender, e);

            if (SendPOConfirm_Click != null)
                SendPOConfirm_Click(dgvLines, e);
        }

        private void mnuConfirmPrice_Click(object sender, EventArgs e)
        {
            //if (SendLinePOConfirm_Click != null)
            //    SendLinePOConfirm_Click(dgvLines, e);
        }

        private void mnuLineSubmit_Click(object sender, EventArgs e)
        {
            if (LineSubmit_Click != null)
                LineSubmit_Click(dgvLines, e);
        }

        private void mnuLineUnSubmit_Click(object sender, EventArgs e)
        {
            if (LineUnSubmit_Click != null)
                LineUnSubmit_Click(dgvLines, e);
        }

        private void mnuApprove_Click(object sender, EventArgs e)
        {
            if (LineApprove_Click != null)
                LineApprove_Click(dgvLines, e);
        }

        private void mnuReject_Click(object sender, EventArgs e)
        {
            if (LineReject_Click != null)
                LineReject_Click(dgvLines, e);
        }

        private void mnuDuplicated_Click(object sender, EventArgs e)
        {
            if (DuplicateList_Click != null)
                DuplicateList_Click(dgvLines, e);
        }
    }
}
