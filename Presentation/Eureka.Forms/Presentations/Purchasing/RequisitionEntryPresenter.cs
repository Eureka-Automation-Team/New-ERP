using Eureka.Core.Domain.Inventory;
using Eureka.Core.Domain.Projects;
using Eureka.Core.Domain.Purchasing;
using Eureka.Forms.Views.Inventory;
using Eureka.Froms.Views.Controls;
using Eureka.Froms.Views.Inventory;
using Eureka.Froms.Views.Projects;
using Eureka.Froms.Views.Purchasing;
using Eureka.Froms.Views.Security;
using Eureka.Services.Inventory;
using Eureka.Services.Projects;
using Eureka.Services.Purchasing;
using MetroFramework.Controls;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Purchasing
{
    public class RequisitionEntryPresenter
    {
        private IRequisitionEntryView _view;
        private readonly IRequisitionSrv _repository;
        private readonly IProjectSrv _repoPrj;
        private readonly IItemMasterSrv _repoItem;

        public RequisitionEntryPresenter(IRequisitionEntryView view)
        {
            _view = view;
            _repository = new RequisitionSrv();
            _repoPrj = new ProjectSrv();
            _repoItem = new ItemMasterSrv();

            _view.Form_Load += Form_Load;
            _view.Find_Project += Find_Project;
            _view.New_Click += New_Click;
            _view.Find_Requester += Find_Requester;
            _view.Find_Approver += Find_Approver;
            _view.Find_Boms += Find_Boms;
            _view.Refresh_Click += Refresh_Click;
            _view.Save_Click += Save_Click;
            _view.Selection_Change += Selection_Change;
            //_view.ValidateLine += ValidateLine;
            _view.ValidateCells += ValidateCells;
            _view.New_Line += New_Line;
            _view.BOM_Changed += BOM_Changed;
            _view.CostCode_Changed += CostCode_Changed;
            _view.PasteStandard_Rows += PasteStandard_Rows;
            _view.PasteMaking_Rows += PasteMaking_Rows;
            _view.Delete_Row += Delete_Row;
            _view.GetLine_Selected += GetLine_Selected;
            _view.Find_Items += Find_Items;
            _view.Submit_Click += Submit_Click;
            _view.UnSubmit_Click += UnSubmit_Click;
            _view.ConvertPO_Click += ConvertPO_Click;
            _view.Approved_Click += Approved_Click;
            _view.Set_DueDate += Set_DueDate;
            _view.SendPOConfirm_Click += SendPOConfirm;
            _view.LineSubmit_Click += LineSubmit;
            _view.LineUnSubmit_Click += LineUnSubmit;
            _view.LineApprove_Click += LineApprove;
            _view.LineReject_Click += LineReject;
            _view.DuplicateList_Click += DuplicateList;
        }

        private void DuplicateList(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;
            List<ItemMasterModel> itemsDuplicate = new List<ItemMasterModel>();
            List<RequisitionLineModel> lines = new List<RequisitionLineModel>();
            RequisitionLineModel line = new RequisitionLineModel();
            if (grd.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow row in grd.SelectedRows)
                {
                    line = (RequisitionLineModel)row.DataBoundItem;
                }

                if(line != null)
                {
                    var item = _repoItem.GetItemByNumber(line.ItemCode.Trim());
                    var itemManu = _repoItem.GetItemByManuId(line.SpecModel.Trim());
                    if(item != null)
                        itemsDuplicate.Add(item);

                    if(itemManu != null)
                        itemsDuplicate.Add(itemManu);

                    using (ItemsDupplicateForm frm = new ItemsDupplicateForm(itemsDuplicate))
                    {
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void LineReject(object sender, EventArgs e)
        {
            if (_view.reqLinesSelected.Count() > 0)
            {
                DataGridView dgv = sender as DataGridView;

                RequisitionHeaderModel req = _view.reqHead;
                DialogResult dialogResult = MessageBox.Show("Are you sure to Reject this Requisition : " + req.RequisitionNumber, "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    List<RequisitionLineModel> list = _view.reqLinesSelected;
                    foreach (RequisitionLineModel item in list.OrderBy(o => o.CreationDate))
                    {
                        item.LastUpdatedBy = _view.EpiSession.User.Id;
                        item.LastUpdateDate = DateTime.Now;
                        item.ApprovedFlag = false;
                        item.RejectFlag = true;
                        item.CancelFlag = true;
                        item.Status = "REJECT";
                        item.RejectComment = "Reject by Requisition Line";

                        _repository.UpdatePRLine(item);
                    }
                    
                    //_view.reqLines = _repository.GetLinesByHeaderID(_view.reqHead.RequisitionHeaderId);
                    //_view.reqHead = _repository.GetHeadByID(req.RequisitionHeaderId);
                    Refresh_Click(null, null);
                    KeepLogging("REJECT REQUISITION");

                    _repoPrj.ProjectCost_Reset(_view.projHead.Id);
                    _view.projBudget = _repoPrj.GetProjectCostByProjID(_view.projHead.Id);
                    _view.BindingBudgetLines(_view.projBudget);
                }
            }
        }

        private void LineApprove(object sender, EventArgs e)
        {
            if (_view.reqLines.Count() > 0)
            {
                DataGridView dgv = sender as DataGridView;

                RequisitionHeaderModel req = _view.reqHead;
                DialogResult dialogResult = MessageBox.Show("Are you sure to Approve this Requisition : " + req.RequisitionNumber, "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    List<RequisitionLineModel> list = _view.reqLines;
                    foreach (RequisitionLineModel item in list.OrderBy(o => o.CreationDate))
                    {
                        if(item.Status == "SUBMITTED")
                        {
                            item.LastUpdatedBy = _view.EpiSession.User.Id;
                            item.LastUpdateDate = DateTime.Now;
                            item.ApprovedFlag = true;
                            item.Status = "APPROVED";
                            item.FinalUnitPrice = item.UnitPrice;

                            #region Update Encumbrance
                            double revAmount = item.ExtendedAmount;
                            if (item.EncumbranceFlag)
                                revAmount = item.ExtendedAmount - item.EncumbranceAmount;

                            //Get Cost remaining balance.
                            var budgetCost = _repoPrj.GetByProjectCost(req.ProjectNo, item.CostCode);

                            if (budgetCost.UfBudgetRemain >= revAmount)
                            {
                                //Set Encumbrance Flag/Amount for PR line.
                                item.EncumbranceFlag = true;
                                item.EncumbranceAmount = item.ExtendedAmount;
                            }
                            else
                            {
                                item.EncumbranceFlag = false;
                                item.EncumbranceAmount = 0;
                            }
                            #endregion

                            _repository.UpdatePRLine(item);
                        }
                    }

                    #region Validate Requisition Header 
                    //Get all lines by Requisition headers.
                    List<RequisitionLineModel> lines = _view.reqLines;

                    //Group by PR Submited Status.
                    var grpLinesStatus = lines.GroupBy(grp => grp.ApprovedFlag)
                                         .Select(group => new { status = group.Key, lines = group.ToList() })
                                         .ToList();

                    //If not multiple status.
                    if (grpLinesStatus.Count() == 1)
                    {
                        //If PR submited all lines.
                        if (grpLinesStatus.FirstOrDefault().status)
                        {
                            var reqh = _repository.GetHeadByID(req.RequisitionHeaderId);
                            reqh.ApprovedFlag = true;
                            _repository.UpdatePR(reqh);
                        }
                    }
                    #endregion

                    //_view.reqLines = _repository.GetLinesByHeaderID(_view.reqHead.RequisitionHeaderId);
                    //_view.reqHead = _repository.GetHeadByID(req.RequisitionHeaderId);
                    Refresh_Click(null, null);
                    KeepLogging("APPROVE REQUISITION");
                }
            }
        }

        private void LineUnSubmit(object sender, EventArgs e)
        {
            if (_view.reqLinesSelected.Count() > 0)
            {
                DataGridView dgv = sender as DataGridView;

                RequisitionHeaderModel req = _view.reqHead;
                DialogResult dialogResult = MessageBox.Show("Are you sure to Un-Submit this Requisition : " + req.RequisitionNumber, "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    List<RequisitionLineModel> list = _view.reqLinesSelected;
                    foreach (RequisitionLineModel item in list.OrderBy(o => o.CreationDate))
                    {
                        item.LastUpdatedBy = _view.EpiSession.User.Id;
                        item.LastUpdateDate = DateTime.Now;
                        item.SubmitFlag = false;
                        item.Status = "OPEN";
                        //item.FinalUnitPrice = item.UnitPrice;

                        _repository.UpdatePRLine(item);
                    }

                    #region Validate Requisition Header 
  
                    req.SubmitFlag = false;
                    _repository.UpdatePR(req);
     
                    #endregion

                    Refresh_Click(null, null);
                    KeepLogging("UN-SUBMIT REQUISITION");
                }
            }
        }

        private void LineSubmit(object sender, EventArgs e)
        {
            if (_view.reqLinesSelected.Count() > 0)
            {
                DataGridView dgv = sender as DataGridView;

                bool dataValid = ValidationLinesSelected(dgv);

                if (!dataValid)
                {
                    MessageBox.Show("Data Invalid. Cannot to submit PR.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                RequisitionHeaderModel req = _view.reqHead;
                DialogResult dialogResult = MessageBox.Show("Are you sure to Submit this Requisition : " + req.RequisitionNumber, "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    List<RequisitionLineModel> list = _view.reqLinesSelected;
                    foreach (RequisitionLineModel item in list.OrderBy(o => o.CreationDate))
                    {
                        item.LastUpdatedBy = _view.EpiSession.User.Id;
                        item.LastUpdateDate = DateTime.Now;
                        item.SubmitFlag = true;
                        item.Status = "SUBMITTED";
                        item.FinalUnitPrice = item.UnitPrice;

                        #region Update Encumbrance
                        double revAmount = item.ExtendedAmount;
                        if (item.EncumbranceFlag)
                            revAmount = item.ExtendedAmount - item.EncumbranceAmount;

                        //Get Cost remaining balance.
                        var budgetCost = _repoPrj.GetByProjectCost(req.ProjectNo, item.CostCode);

                        if (budgetCost.UfBudgetRemain >= revAmount)
                        {
                            //Set Encumbrance Flag/Amount for PR line.
                            item.EncumbranceFlag = true;
                            item.EncumbranceAmount = item.ExtendedAmount;
                        }
                        else
                        {
                            item.EncumbranceFlag = false;
                            item.EncumbranceAmount = 0;
                        }
                        #endregion

                        _repository.UpdatePRLine(item);
                    }

                    #region Validate Requisition Header 
                    //Get all lines by Requisition headers.
                    List<RequisitionLineModel> lines = _view.reqLines;

                    //Group by PR Submited Status.
                    var grpLinesStatus = lines.GroupBy(grp => grp.SubmitFlag)
                                         .Select(group => new { status = group.Key, lines = group.ToList() })
                                         .ToList();

                    //If not multiple status.
                    if (grpLinesStatus.Count() == 1)
                    {
                        //If PR submited all lines.
                        if (grpLinesStatus.FirstOrDefault().status)
                        {
                            var reqh = _repository.GetHeadByID(req.RequisitionHeaderId);
                            reqh.SubmitFlag = true;
                            _repository.UpdatePR(reqh);
                        }
                    }
                    #endregion

                    //_view.reqLines = _repository.GetLinesByHeaderID(_view.reqHead.RequisitionHeaderId);
                    //_view.reqHead = _repository.GetHeadByID(req.RequisitionHeaderId);
                    Refresh_Click(null, null);
                    KeepLogging("SUBMIT REQUISITION");
                }
            }
        }

        private bool ValidationLinesSelected(DataGridView dgv)
        {
            bool valid = true;
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow dgr in dgv.SelectedRows)
                {
                    RequisitionLineModel curr = (RequisitionLineModel)dgr.DataBoundItem;
                    DataGridViewRow row = dgv.Rows[dgr.Index];
                    DataGridViewCell balloneNo = row.Cells[dgv.Columns["BalloonNo"].Index];
                    DataGridViewCell costCode = row.Cells[dgv.Columns["colCostCode1"].Index];
                    DataGridViewCell itemCode = row.Cells[dgv.Columns["colItemCode1"].Index];
                    DataGridViewCell quantity = row.Cells[dgv.Columns["colQuantity1"].Index];
                    DataGridViewCell description = row.Cells[dgv.Columns["colItemDescription1"].Index];
                    DataGridViewCell unitPrice = row.Cells[dgv.Columns["colUnitPrice1"].Index];

                    //if (!IsZero(dgv, balloneNo))
                    //    valid = false;

                    if (!IsEmptyOrNull(dgv, itemCode))
                        valid = false;

                    if (curr.PriceConfirmedFlag)
                    {
                        if (!IsZero(dgv, unitPrice))
                            valid = false;
                    }

                    if (!IsZero(dgv, quantity))
                        valid = false;

                    row.Cells[dgv.Columns["colValidatedFlag1"].Index].Value = valid;
                }
            }

            _view.RefreshGird();
            return valid;
        }

        private void SendPOConfirm(object sender, EventArgs e)
        {
            if (!_view.reqHead.SubmitFlag && !_view.reqHead.SentPoConfirmFlag)
            {
                DataGridView dgv = sender as DataGridView;
                bool dataValid = ValidationLines(dgv);

                if (!dataValid)
                {
                    MessageBox.Show("Data Invalid. Cannot to sent to Comfirm.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var dupplicateCount = _view.reqLines.Where(x => x.DupplicateFlag).ToList();
                if (dupplicateCount.Count > 0)
                {
                    MessageBox.Show("Data Invalid. Cannot to Save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                RequisitionHeaderModel req = _view.reqHead;
                DialogResult dialogResult = MessageBox.Show("Are you sure to sent to Comfirm this Requisition : " + req.RequisitionNumber, "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    req.LastUpdatedBy = _view.EpiSession.User.Id;
                    req.LastUpdateDate = DateTime.Now;
                    req.SentPoConfirmFlag = true;
                    _repository.UpdatePR(req);
                    List<RequisitionLineModel> list = _view.reqLines;
                    int rowNum = 1;
                    foreach (RequisitionLineModel item in list.OrderBy(o => o.CreationDate))
                    {
                        item.LastUpdatedBy = _view.EpiSession.User.Id;
                        item.LastUpdateDate = DateTime.Now;
                        item.LineNum = rowNum;
                        item.SentPriceConfirmFlag = true;
                        //item.Status = "SUBMITTED";
                        item.FinalUnitPrice = item.UnitPrice;

                        rowNum++;
                        _repository.UpdatePRLine(item);
                    }

                    _view.reqLines = _repository.GetLinesByHeaderID(_view.reqHead.RequisitionHeaderId);
                    _view.reqHead = _repository.GetHeadByID(req.RequisitionHeaderId);
                    Refresh_Click(null, null);
                    //KeepLogging("SENT TO CONFIRM REQUISITION");
                }
            }
        }

        private void Set_DueDate(object sender, EventArgs e)
        {
            using (CalendaForm frm = new CalendaForm())
            {
                frm.ShowDialog();
                if (frm.dateSeleted != null)
                {
                    MetroGrid grd = sender as MetroGrid;
                    if (grd.SelectedRows.Count > 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure to set date = " + frm.dateSeleted.ToLongDateString(), "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow dgr in grd.SelectedRows)
                            {
                                RequisitionLineModel curr = (RequisitionLineModel)dgr.DataBoundItem;
                                try
                                {
                                    if (!curr.RejectFlag)
                                    {
                                        curr.RequestDate = frm.dateSeleted;
                                        _repository.UpdatePRLine(curr);
                                    }
                                }
                                catch
                                {
                                }
                            }
                            _view.RefreshGird();
                        }
                    }
                }
            }
        }

        private void Find_Items(object sender, EventArgs e)
        {
            if (_view.reqHead != null)
            {
                if (!_view.reqHead.SubmitFlag)
                {
                    DataGridView dgv = sender as DataGridView;
                    DataGridViewCellEventArgs arg = e as DataGridViewCellEventArgs;
                    if (arg.ColumnIndex == -1)
                        return;

                    string colName = dgv.Columns[arg.ColumnIndex].Name;
                    if (colName == "colItemCode1"
                        || colName == "colSpecModel1"  //MANU ID
                        || colName == "colItemDescription1"  //Item Description
                        || colName == "colBrandMaterail1")  //Brand/Material
                    {
                        dgv.CurrentCell.Value = GetItem(colName, dgv.CurrentCell.Value == null ? "" : dgv.CurrentCell.Value.ToString());
                        dgv.EndEdit();
                    }
                }
            }
        }

        private string GetItem(string value, string v)
        {
            string str = v;
            RequisitionLineModel curr = (RequisitionLineModel)_view.bindingLine.Current;

            using (ItemListForm frm = new ItemListForm(_view.items))
            {
                frm.ShowDialog();
                List<ItemMasterModel> items = new List<ItemMasterModel>();
                if (frm.itemSelected != null)
                {
                    int prjId = _view.projects.Where(x => x.ProjectNum == _view.reqHead.ProjectNo).FirstOrDefault().Id;

                    curr.ItemId = frm.itemSelected.InventoryItemId;
                    curr.ItemCode = frm.itemSelected.Segment1;
                    curr.ItemDescription = frm.itemSelected.Description;
                    curr.SpecModel = frm.itemSelected.Segment2;
                    curr.BrandMaterail = frm.itemSelected.Segment3;
                    curr.Uom = string.IsNullOrEmpty(frm.itemSelected.PrimaryUomCode) ? "PCS" : frm.itemSelected.PrimaryUomCode;
                    curr.UnitPrice = frm.itemSelected.CostPricePerUnit;

                    curr.RequisitionHeaderId = _view.reqHead.RequisitionHeaderId;
                    curr.RefProjectId = prjId;
                    curr.RefProjectNum = _view.reqHead.ProjectNo;
                    curr.LineType = "STANDARD";
                    curr.Status = "OPEN";
                    curr.CostId = _view.reqHead.CostId;
                    curr.CostCode = _view.reqHead.CostCode;
                    curr.BomId = _view.reqHead.BomId;
                    curr.BomNo = _view.reqHead.BomNumber;
                    curr.ValidatedFlag = true;

                    if (value == "colItemCode1")
                        str = frm.itemSelected.Segment1;
                    else if(value == "colSpecModel1")
                        str = frm.itemSelected.Segment2;
                    else if (value == "colItemDescription1")
                        str = frm.itemSelected.Description;
                    else if (value == "colBrandMaterail1")
                        str = frm.itemSelected.Segment3;

                    _view.RefreshGird();
                }
            }

            return str;
        }

        private void Approved_Click(object sender, EventArgs e)
        {
            MetroCheckBox chk = sender as MetroCheckBox;
            RequisitionHeaderModel req = _view.reqHead;
            var pox = _repository.GetHeadByID(req.RequisitionHeaderId);
            if (chk.Checked && !pox.ApprovedFlag)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to Approve this Requisition : " + req.RequisitionNumber, "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (req.ApproverId != _view.EpiSession.User.Id)
                    {
                        MessageBox.Show("You are not allowed to approve this Requisition.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        req.ApprovedFlag = false;
                        _view.reqHead = req;
                        return;
                    }

                    List<RequisitionLineModel> list = _view.reqLines;
                    foreach (RequisitionLineModel item in list.OrderBy(o => o.LineNum))
                    {
                        if(item.Status == "SUBMITTED")
                        {
                            item.LastUpdatedBy = _view.EpiSession.User.Id;
                            item.LastUpdateDate = DateTime.Now;
                            item.ApprovedFlag = true;
                            item.Status = "APPROVED";

                            #region Update Encumbrance
                            double revAmount = item.ExtendedAmount;
                            if (item.EncumbranceFlag)
                                revAmount = item.ExtendedAmount - item.EncumbranceAmount;

                            //Get Cost remaining balance.
                            var budgetCost = _repoPrj.GetByProjectCost(req.ProjectNo, item.CostCode);

                            if (budgetCost.UfBudgetRemain >= revAmount)
                            {
                                //Set Encumbrance Flag/Amount for PR line.
                                item.EncumbranceFlag = true;
                                item.EncumbranceAmount = item.ExtendedAmount;
                            }
                            else
                            {
                                item.EncumbranceFlag = false;
                                item.EncumbranceAmount = 0;
                            }
                            #endregion

                            _repository.UpdatePRLine(item);
                        }
                    }
                    _view.reqLines = _repository.GetLinesByHeaderID(_view.reqHead.RequisitionHeaderId);
                    req.ApprovedFlag = true;
                    _repository.UpdatePR(req);

                    req = _repository.GetHeadByID(req.RequisitionHeaderId);

                    KeepLogging("APPROVE REQUISITION");
                }
                else
                {
                    req.ApprovedFlag = false;
                }

                _view.reqHead = req;
                Refresh_Click(null, null);
            }            
        }

        private void ConvertPO_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UnSubmit_Click(object sender, EventArgs e)
        {
            if (!_view.reqHead.ApprovedFlag)
            {
                RequisitionHeaderModel req = _view.reqHead;
                DialogResult dialogResult = MessageBox.Show("Are you sure to Un-Submit this Requisition : " + req.RequisitionNumber, "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    req.SubmitFlag = false;
                    _repository.UpdatePR(req);
                    List<RequisitionLineModel> list = _view.reqLines;
                    int rowNum = 1;
                    foreach (RequisitionLineModel item in list.OrderBy(o => o.LineNum))
                    {
                        item.LastUpdatedBy = _view.EpiSession.User.Id;
                        item.LastUpdateDate = DateTime.Now;
                        item.Status = "OPEN";

                        rowNum++;
                        _repository.UpdatePRLine(item);
                    }
                    _view.reqLines = _repository.GetLinesByHeaderID(_view.reqHead.RequisitionHeaderId);
                    _view.reqHead = _repository.GetHeadByID(req.RequisitionHeaderId);
                    Refresh_Click(null, null);
                }
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (!_view.reqHead.ApprovedFlag)
            {
                DataGridView dgv = sender as DataGridView;
                bool dataValid = ValidationLines(dgv);           

                if (!dataValid)
                {
                    MessageBox.Show("Data Invalid. Cannot to submit PR.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                RequisitionHeaderModel req = _view.reqHead;
                DialogResult dialogResult = MessageBox.Show("Are you sure to Submit this Requisition : " + req.RequisitionNumber, "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    req.LastUpdatedBy = _view.EpiSession.User.Id;
                    req.LastUpdateDate = DateTime.Now;
                    req.SubmitFlag = true;
                    _repository.UpdatePR(req);
                    List<RequisitionLineModel> list = _view.reqLines;
                    int rowNum = 1;
                    foreach (RequisitionLineModel item in list.OrderBy(o => o.CreationDate))
                    {
                        item.LastUpdatedBy = _view.EpiSession.User.Id;
                        item.LastUpdateDate = DateTime.Now;
                        item.SubmitFlag = true;
                        item.Status = "SUBMITTED";
                        item.FinalUnitPrice = item.UnitPrice;

                        #region Update Encumbrance
                        double revAmount = item.ExtendedAmount;
                        if (item.EncumbranceFlag)
                            revAmount = item.ExtendedAmount - item.EncumbranceAmount;

                        //Get Cost remaining balance.
                        var budgetCost = _repoPrj.GetByProjectCost(req.ProjectNo, item.CostCode);

                        if (budgetCost.UfBudgetRemain >= revAmount)
                        {
                            //Set Encumbrance Flag/Amount for PR line.
                            item.EncumbranceFlag = true;
                            item.EncumbranceAmount = item.ExtendedAmount;
                        }
                        else
                        {
                            item.EncumbranceFlag = false;
                            item.EncumbranceAmount = 0;
                        }
                        #endregion

                        rowNum++;
                        _repository.UpdatePRLine(item);
                    }

                    _view.reqLines = _repository.GetLinesByHeaderID(_view.reqHead.RequisitionHeaderId);
                    _view.reqHead = _repository.GetHeadByID(req.RequisitionHeaderId);
                    Refresh_Click(null, null);
                    KeepLogging("SUBMIT REQUISITION");
                }
            }
        }

        private void KeepLogging(string action)
        {
            bool overBudget = false;
            string lineNotPass = string.Empty;

            if (_view.reqLines.Count > 0)
            {                
                foreach (var curr in _view.reqLines)
                {
                    var prjCosts = _repoPrj.GetByProjectCost(curr.RefProjectNum, curr.CostCode);
                    if(prjCosts != null)
                    {
                        if (prjCosts.RemainPercentage <= 0)
                        {
                            lineNotPass = lineNotPass + (string.IsNullOrEmpty(lineNotPass) ? "" : ", ")
                                + curr.LineNum.ToString() + " Cost Code : " + curr.CostCode;
                            overBudget = true;
                        }
                    }
                    else
                    {
                        lineNotPass = lineNotPass + "";
                    }
                }

                if (overBudget)
                {
                    POLoggingModel log = new POLoggingModel();
                    log.LogingSource = "REQUISITION";
                    log.ActionSource = action;
                    log.ActionBy = _view.EpiSession.User.Id;
                    log.CreatedBy = _view.EpiSession.User.Id;
                    log.CreationDate = DateTime.Now;
                    log.LastUpdatedBy = _view.EpiSession.User.Id;
                    log.LastUpdateDate = DateTime.Now;
                    log.RequisitionHeaderId = _view.reqHead.RequisitionHeaderId;
                    log.ActionDescription = string.Format("PR No. {0} /Over budget in lines [{1}]"
                        , _view.reqHead.RequisitionNumber
                        , lineNotPass);

                    _repository.KeepLogging(log);
                }
            }
        }

        private bool ValidationLines(DataGridView dgv)
        {
            bool valid = true;
            if (dgv.Rows.Count > 0)
            {
               foreach (DataGridViewRow dgr in dgv.Rows)
                {
                    RequisitionLineModel curr = (RequisitionLineModel)dgr.DataBoundItem;
                    DataGridViewRow row = dgv.Rows[dgr.Index];
                    DataGridViewCell balloneNo = row.Cells[dgv.Columns["BalloonNo"].Index];
                    DataGridViewCell costCode = row.Cells[dgv.Columns["colCostCode1"].Index];
                    DataGridViewCell itemCode = row.Cells[dgv.Columns["colItemCode1"].Index];
                    DataGridViewCell quantity = row.Cells[dgv.Columns["colQuantity1"].Index];
                    DataGridViewCell description = row.Cells[dgv.Columns["colItemDescription1"].Index];
                    DataGridViewCell unitPrice = row.Cells[dgv.Columns["colUnitPrice1"].Index];

                    //if (!IsZero(dgv, balloneNo))
                    //    valid = false;

                    if (!IsEmptyOrNull(dgv, itemCode))
                        valid = false;

                    if (curr.PriceConfirmedFlag)
                    {
                        if (!IsZero(dgv, unitPrice))
                            valid = false;
                    }

                    if (!IsZero(dgv, quantity))
                        valid = false;

                    row.Cells[dgv.Columns["colValidatedFlag1"].Index].Value = valid;
                }               
            }

            _view.RefreshGird();
            return valid;
        }

        private void ValidateLine(object sender, EventArgs e)
        {
            if (_view.reqHead.SubmitFlag)
                return;

            bool invalid = false;
            DataGridView dgv = sender as DataGridView;
            DataGridViewCellCancelEventArgs arg = e as DataGridViewCellCancelEventArgs;
            if (dgv.Rows[arg.RowIndex].IsNewRow) { return; }

            DataGridViewRow row = dgv.Rows[arg.RowIndex];
            DataGridViewCell balloneNo = row.Cells[dgv.Columns["BalloonNo"].Index];
            DataGridViewCell costCode = row.Cells[dgv.Columns["colCostCode1"].Index];
            DataGridViewCell itemCode = row.Cells[dgv.Columns["colItemCode1"].Index];
            DataGridViewCell quantity = row.Cells[dgv.Columns["colQuantity1"].Index];
            DataGridViewCell description = row.Cells[dgv.Columns["colItemDescription1"].Index];
            DataGridViewCell unitPrice = row.Cells[dgv.Columns["colUnitPrice1"].Index];

            if (!IsZero(dgv, balloneNo))
                invalid = true;

            if (!IsEmptyOrNull(dgv, itemCode))
                invalid = true;

            if (!IsZero(dgv, unitPrice))
                invalid = true;

            if (!IsZero(dgv, quantity))
                invalid = true;

            //if (!IsCostMatch(dgv, costCode))
            //    invalid = true;

            row.Cells[dgv.Columns["colValidatedFlag1"].Index].Value = !invalid;
            arg.Cancel = invalid;
        }

        private bool ValidateLines(object sender)
        {
            bool valid = true;
            DataGridView dgv = sender as DataGridView;

            foreach(DataGridViewRow row in dgv.Rows)
            {
                //if (dgv.Rows[arg.RowIndex].IsNewRow) { return; }

                //DataGridViewRow row = dgv.Rows[arg.RowIndex];
                DataGridViewCell balloneNo = row.Cells[dgv.Columns["BalloonNo"].Index];
                DataGridViewCell costCode = row.Cells[dgv.Columns["colCostCode1"].Index];
                DataGridViewCell itemCode = row.Cells[dgv.Columns["colItemCode1"].Index];
                DataGridViewCell quantity = row.Cells[dgv.Columns["colQuantity1"].Index];
                DataGridViewCell description = row.Cells[dgv.Columns["colItemDescription1"].Index];
                DataGridViewCell unitPrice = row.Cells[dgv.Columns["colUnitPrice1"].Index];

                if (!IsZero(dgv, balloneNo))
                    valid = false;

                if (!IsEmptyOrNull(dgv, itemCode))
                    valid = false;

                if (!IsZero(dgv, unitPrice))
                    valid = false;

                if (!IsZero(dgv, quantity))
                    valid = false;

                row.Cells[dgv.Columns["colValidatedFlag1"].Index].Value = !valid;
            }

            return valid;
        }

        private void GetLine_Selected(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;

            List<RequisitionLineModel> lines = new List<RequisitionLineModel>();
            RequisitionLineModel line = new RequisitionLineModel();
            if (grd.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in grd.SelectedRows)
                {
                    line = (RequisitionLineModel)row.DataBoundItem;

                    lines.Add(line);
                }
            }

            _view.reqLinesSelected = lines;
        }

        private void Delete_Row(object sender, EventArgs e)
        {
            if (_view.reqLinesSelected != null && !_view.reqHead.SubmitFlag)
            {
                MetroGrid grd = sender as MetroGrid;
                if (grd.SelectedRows.Count > 0)
                {
                    //DialogResult dialogResult = MessageBox.Show("Are you sure to delete this Line.", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (dialogResult == DialogResult.Yes)
                    //{
                        foreach(DataGridViewRow dgr in grd.SelectedRows)
                        {
                            //RequisitionLineModel curr = (RequisitionLineModel)_view.bindingLine.Current;
                            RequisitionLineModel curr = (RequisitionLineModel)dgr.DataBoundItem;
                            //_view.bindingLine.Remove(dgr);
                            grd.Rows.RemoveAt(dgr.Index);
                            if (curr.RequisitionLineId != 0)
                            {
                                ////Get Cost remaining balance.
                                //var budgetCost = _repoPrj.GetByProjectCost(curr.RefProjectNum, curr.CostCode);

                                //if (curr.EncumbranceFlag)
                                //{
                                //    //Minus Cost amount usage by PR Line.
                                //    budgetCost.FcstCostAmount = budgetCost.FcstCostAmount - curr.EncumbranceAmount;

                                //    //Update Budget cost to DB.
                                //    _repoPrj.UpdateProjCost(budgetCost);
                                //}

                                try
                                {
                                    _repository.DeletePRLine(curr);
                                }
                                catch
                                {
                                }
                            }
                        }
                        _repoPrj.ProjectCost_Reset(_view.projHead.Id);
                        //Refresh_Click(null, null);
                    //}
                }

                
            }
        }

        private void PasteStandard_Rows(object sender, EventArgs e)
        {
            if(_view.reqHead != null)
            {
                if (_view.reqHead.RequisitionHeaderId != 0)
                {
                    if (string.IsNullOrEmpty(_view.reqHead.ProjectNo))
                    {
                        MessageBox.Show("Please select default Project No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrEmpty(_view.reqHead.BomNumber))
                    {
                        MessageBox.Show("Please select default BOM No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrEmpty(_view.reqHead.CostCode))
                    {
                        MessageBox.Show("Please select default Cost Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DataObject o = (DataObject)Clipboard.GetDataObject();
                    if (o.GetDataPresent(DataFormats.Text))
                    {
                        List<RequisitionLineModel> lines = _view.reqLines;
                        List<RequisitionLineModel> list = new List<RequisitionLineModel>();

                        //string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                        string[] pastedRows = Regex.Split(o.GetText().ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                        list = AddLineStandard(pastedRows);

                        _view.reqLines = lines.Concat(list).ToList();
                        _view.BindingLines(_view.reqLines);
                        //CalculateLine();
                    }
                }
                else
                {
                    MessageBox.Show("Requisition Order is null! please select Requisition Order.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void PasteMaking_Rows(object sender, EventArgs e)
        {
            if (_view.reqHead != null)
            {
                if (_view.reqHead.RequisitionHeaderId != 0)
                {
                    if (string.IsNullOrEmpty(_view.reqHead.ProjectNo))
                    {
                        MessageBox.Show("Please select default Project No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrEmpty(_view.reqHead.BomNumber))
                    {
                        MessageBox.Show("Please select default BOM No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrEmpty(_view.reqHead.CostCode))
                    {
                        MessageBox.Show("Please select default Cost Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DataObject o = (DataObject)Clipboard.GetDataObject();
                    if (o.GetDataPresent(DataFormats.Text))
                    {
                        List<RequisitionLineModel> lines = _view.reqLines;
                        List<RequisitionLineModel> list = new List<RequisitionLineModel>();

                        //string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                        string[] pastedRows = Regex.Split(o.GetText().ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                        list = AddLineMaking(pastedRows);

                        _view.reqLines = lines.Concat(list).ToList();
                        _view.BindingLines(_view.reqLines);
                        //CalculateLine();
                    }
                }
                else
                {
                    MessageBox.Show("Requisition Order is null! please select Requisition Order.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CostCode_Changed(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (_view.reqHead != null)
            {
                try
                {
                    CostGroupModel CostCode = (CostGroupModel)comboBox.SelectedValue;
                    if (CostCode != null)
                    {
                        _view.reqHead.CostId = CostCode.Id;
                        _view.reqHead.CostCode = CostCode.CostCode;
                    }
                    else
                    {
                        _view.reqHead.CostId = 0;
                        _view.reqHead.CostCode = string.Empty;
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        private void BOM_Changed(object sender, EventArgs e)
        {
            MetroTextBox txt = sender as MetroTextBox;
            List<CostGroupModel> costs = new List<CostGroupModel>();
            BomNumberModel bom = _repoPrj.GetBomNumbersAll().Where(x => x.BomNumber.Trim() == txt.Text.Trim()).FirstOrDefault();

            if (bom != null)
            {
                var prj = _view.projHead;
                if(_view.projectCosts == null)
                    _view.projectCosts = _repoPrj.GetProjectCostByProjID(prj.Id);

                costs = _repoPrj.GetCostGropByBOMID(bom.BomId).Where(x => _view.projectCosts.Any(p => x.CostCode == p.CostCode)).ToList();
                //costs = _repoPrj.GetCostGropByBOMID(bom.BomId).Where(x => _view.projectCosts.Any(p => x.CostCode == p.CostCode)).ToList();
                _view.reqHead.BomId = bom.BomId;
                _view.reqHead.BomNumber = bom.BomNumber;
            }
            else
                costs = null;

            _view.BindingComboCost(costs);
        }

        private void New_Line(object sender, EventArgs e)
        {
            //BindingSource bd = sender as BindingSource;
            //AddingNewEventArgs arg = e as AddingNewEventArgs;
            if (_view.reqHead != null)
            {
                if (_view.reqHead.RequisitionHeaderId == 0)
                {
                    MessageBox.Show("Please save before add line.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!ValidCostCode(_view.reqHead.CostCode))
                {
                    MessageBox.Show(string.Format("Cost Code: {0} is not exist in Project: {1}."
                                                   , _view.reqHead.CostCode
                                                   , _view.reqHead.ProjectNo)
                                                   , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }

                if (string.IsNullOrEmpty(_view.reqHead.BomNumber))
                {
                    MessageBox.Show("Please select default BOM No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(_view.reqHead.CostCode))
                {
                    MessageBox.Show("Please select default Cost Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _view.bindingLine.AddNew();
                _view.bindingLine.MoveLast();
                RequisitionLineModel curr = (RequisitionLineModel)_view.bindingLine.Current;
                curr.Uom = "PCS";                
                curr.RequisitionHeaderId = _view.reqHead.RequisitionHeaderId;
                curr.Status = "OPEN";
                curr.LineType = "STANDARD";
                curr.BalloonNo = string.Empty;
                curr.PriceConfirmedFlag = true;
                curr.CostId = _view.reqHead.CostId;
                curr.RefProjectNum = _view.reqHead.ProjectNo;
                int prjId = _view.projects.Where(x => x.ProjectNum.Trim() == _view.reqHead.ProjectNo.Trim()).FirstOrDefault().Id;
                curr.RefProjectId = prjId;
                curr.CostCode = _view.reqHead.CostCode;
                curr.BomId = _view.reqHead.BomId;
                curr.BomNo = _view.reqHead.BomNumber;
            }

        }

        private Boolean ValidCostCode(string costCode)
        {
            if (_view.reqHead != null)
            {
                int prjId = _view.projects.Where(x => x.ProjectNum.Trim() == _view.reqHead.ProjectNo.Trim()).FirstOrDefault().Id;
                if (prjId == 0)
                    return false;

                List<ProjectCostModel>  costs = _repoPrj.GetProjectCostByProjID(prjId);
                int count = costs.Where(x => x.CostCode == costCode).Count();

                if (count == 0)
                    return false;
                else
                {
                    _view.reqHead.CostId = costs.Where(x => x.CostCode.Trim() == costCode.Trim()).FirstOrDefault().CostId;
                    return true;
                }
            }

            return true;
        }

        private void ValidateCells(object sender, EventArgs e)
        {
            if (_view.reqHead.SubmitFlag)
                return;

            DataGridView dgv = sender as DataGridView;
            DataGridViewCellValidatingEventArgs arg = e as DataGridViewCellValidatingEventArgs;

            dgv.Rows[arg.RowIndex].ErrorText = "";
            if (dgv.Rows[arg.RowIndex].IsNewRow) { return; }

            string headerText = dgv.Columns[arg.ColumnIndex].Name;
            string value = arg.FormattedValue.ToString();
            RequisitionLineModel curr = (RequisitionLineModel)_view.bindingLine.Current;
            if (headerText == "colItemCode1")  //Item Code
            {
                //curr.DupplicateFlag = false;
                var item = _repoItem.GetItemByNumber(value);
                if(item != null)
                {
                    curr.ItemId = item.InventoryItemId;
                    curr.ItemDescription = item.Description;
                    curr.SpecModel = item.Segment2;
                    curr.BrandMaterail = item.Segment3;
                    if(curr.RequisitionLineId == 0)
                    {
                        if(curr.UnitPrice == 0)
                            curr.UnitPrice = item.CostPricePerUnit;

                        curr.Uom = string.IsNullOrEmpty(item.PrimaryUomCode) ? "PCS" : item.PrimaryUomCode;
                    }
                }
                else
                {
                    curr.ItemId = 0;
                    var itemTemp = _view.reqLines.Where(x => x.ItemCode == value).FirstOrDefault();
                    if (itemTemp != null)
                    {
                        if(curr.SpecModel != null)
                        {
                            if (curr.SpecModel.Trim() != itemTemp.SpecModel.Trim())
                                curr.DupplicateFlag = true;
                        }

                        curr.ItemId = itemTemp.ItemId;
                        curr.ItemDescription = itemTemp.ItemDescription;
                        curr.SpecModel = itemTemp.SpecModel;
                        curr.BrandMaterail = itemTemp.BrandMaterail;
                        if (curr.RequisitionLineId == 0)
                        {
                            if (curr.UnitPrice == 0)
                                curr.UnitPrice = itemTemp.UnitPrice;
                            curr.Uom = string.IsNullOrEmpty(itemTemp.Uom) ? "PCS" : itemTemp.Uom;
                        }
                    }
                    else
                    {
                        DataGridViewRow row = dgv.Rows[arg.RowIndex];
                        DataGridViewCell manu = row.Cells[dgv.Columns["colSpecModel1"].Index];
                        if(manu.Value != null)
                        {
                            var itemM = _repoItem.GetItemByManuId(manu.Value.ToString());
                            if (itemM != null)
                            {
                                MessageBox.Show(string.Format("Cannot change Item Code.{2}This Item code : {0} is already in Master data, using Manu ID : {1}."
                                                                , value, itemM.Segment2, Environment.NewLine), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                arg.Cancel = true;
                            }
                        }
                    }
                }
            }

            if (headerText == "colSpecModel1")  //MANU ID
            {
                //curr.DupplicateFlag = false;
                if (!string.IsNullOrEmpty(value))
                {
                    var item = _repoItem.GetItemByManuId(value);
                    if (item != null)
                    {
                        if (!string.IsNullOrEmpty(curr.ItemCode))
                        {
                            if (curr.ItemCode.Trim() != item.Segment1.Trim())
                                curr.DupplicateFlag = true;
                        }

                        curr.ItemId = item.InventoryItemId;
                        curr.ItemCode = item.Segment1;
                        curr.ItemDescription = item.Description;
                        curr.SpecModel = item.Segment2;
                        curr.BrandMaterail = item.Segment3;
                        
                        if (curr.RequisitionLineId == 0)
                        {
                            if (curr.UnitPrice == 0)
                                curr.UnitPrice = item.CostPricePerUnit;
                            curr.Uom = string.IsNullOrEmpty(item.PrimaryUomCode) ? "PCS" : item.PrimaryUomCode;
                        }                            
                    }
                    else
                    {
                        curr.ItemId = 0;
                        var itemTemp = _view.reqLines.Where(x => x.SpecModel == value).FirstOrDefault();
                        if (itemTemp != null)
                        {
                            if (curr.ItemCode.Trim() != itemTemp.ItemCode.Trim())
                                curr.DupplicateFlag = true;

                            curr.ItemId = itemTemp.ItemId;
                            curr.ItemDescription = itemTemp.ItemDescription;
                            curr.ItemCode = itemTemp.ItemCode;
                            curr.BrandMaterail = itemTemp.BrandMaterail;                            

                            if (curr.RequisitionLineId == 0)
                            {
                                if (curr.UnitPrice == 0)
                                    curr.UnitPrice = itemTemp.UnitPrice;
                                curr.Uom = string.IsNullOrEmpty(itemTemp.Uom) ? "PCS" : itemTemp.Uom;
                            }                                
                        }
                        else
                        {
                            DataGridViewRow row = dgv.Rows[arg.RowIndex];
                            DataGridViewCell itemCode = row.Cells[dgv.Columns["colItemCode1"].Index];
                            var itemS = _repoItem.GetItemByNumber(itemCode.Value.ToString());
                            if (itemS != null)
                            {
                                MessageBox.Show(string.Format(" Cannot change MANU ID.{2}This Item code : {0} is already in Master data, using Manu ID : {1}."
                                                                , itemCode.Value.ToString(), itemS.Segment2, Environment.NewLine), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                arg.Cancel = true;
                            }
                            else
                            {
                                curr.ItemId = 0;
                            }
                        }
                    }
                }
            }

            if(headerText == "colCostCode1") //Cost Code
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (string.IsNullOrEmpty(curr.BomNo))
                    {
                        curr.BomNo = _view.reqHead.BomNumber;
                        curr.BomId = _view.reqHead.BomId;
                    }

                    var costs = _repoPrj.GetCostGropByBOMID(curr.BomId).Where(x => _view.projectCosts.Any(p => x.CostCode == p.CostCode)).ToList();
                    var cost = costs.Where(x => x.CostCode == value).FirstOrDefault();
                    if (cost != null)
                    {
                        curr.CostId = cost.Id;
                        curr.CostCode = cost.CostCode;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Cost Code : {0} dose not existing this Project Cost.", value), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        arg.Cancel = true;
                    }
                }                 
            }

            if (headerText == "colBomNo1") //Cost Code
            {
                //arg.Cancel = true;
            }

            _view.RefreshGird();
        }

        private Boolean IsCostMatch(DataGridView dgv, DataGridViewCell cell)
        {
            string value = cell.Value == null ? "" : cell.Value.ToString();
            if (!ValidCostCode(value))
            {
                cell.ErrorText = string.Format("Cost Code: {0} is not exist in Project: {1}."
                                                   , _view.reqHead.CostCode
                                                   , _view.reqHead.ProjectNo);
                dgv.Rows[cell.RowIndex].ErrorText = string.Format("Cost Code: {0} is not exist in Project: {1}."
                                                   , _view.reqHead.CostCode
                                                   , _view.reqHead.ProjectNo);
                return false;
            }
            return true;
        }

        private Boolean IsZero(DataGridView dgv, DataGridViewCell cell)
        {
            string value = cell.Value == null ? "" : cell.Value.ToString();
            if (value.Equals("0"))
            {
                cell.ErrorText = "Zero is not a valid.";
                //dgv.Rows[cell.RowIndex].ErrorText = "Zero is not a valid track";
                return false;
            }

            cell.ErrorText = string.Empty;
            return true;
        }

        private Boolean IsEmptyOrNull(DataGridView dgv, DataGridViewCell cell)
        {
            string value = cell.Value == null ? "" : cell.Value.ToString();
            if (string.IsNullOrEmpty(value))
            {
                cell.ErrorText = "Null is not a valid.";
                //dgv.Rows[cell.RowIndex].ErrorText = "Zero is not a valid track";
                return false;
            }

            cell.ErrorText = string.Empty;
            return true;
        }

        private Boolean IsDate(DataGridView dgv, DataGridViewCell cell)
        {
            if (cell.Value == null)
            {
                cell.ErrorText = "Missing date";
                //dgv.Rows[cell.RowIndex].ErrorText = "Missing date";
                return false;
            }
            else
            {
                try
                {
                    DateTime.Parse(cell.Value.ToString());
                }
                catch (FormatException)
                {
                    cell.ErrorText = "Invalid format";
                    dgv.Rows[cell.RowIndex].ErrorText = "Invalid format";

                    return false;
                }
            }
            return true;
        }

        private void Selection_Change(object sender, EventArgs e)
        {
            TreeView trv = sender as TreeView;
            TreeNode nodeSelected = trv.SelectedNode;
            TreeViewEventArgs erg = e as TreeViewEventArgs;
            string[] nodeCells = nodeSelected.FullPath.Split(new char[] { '\\'});
            string projectNo = nodeCells[0];

            if (!string.IsNullOrEmpty(projectNo))
                _view.projHead = _view.projects.Where(x => x.ProjectNum == projectNo).FirstOrDefault();
            else
                _view.projHead = null;

            if (erg.Node.Level == 2)
            {
                try
                {
                    //RequisitionHeaderModel head = (RequisitionHeaderModel)erg.Node.Tag;
                    //_view.reqHead = head;
                    _view.reqHead = (RequisitionHeaderModel)erg.Node.Tag;
                    Refresh_Click(null, null);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Refresh_Click(null, null);
                    return;
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if(_view.reqHead != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                RequisitionHeaderModel head = _view.reqHead;
                head.LastUpdatedBy = _view.EpiSession.User.Id;
                head.LastUpdateDate = DateTime.Now;
                head.CostId = _view.costSelected.Id;
                head.CostCode = _view.costSelected.CostCode;

                if (head.RequesterId == 0)
                {
                    MessageBox.Show("Requester is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (head.ApproverId == 0)
                {
                    MessageBox.Show("Approver is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(_view.reqHead.BomNumber))
                {
                    MessageBox.Show("Please select default BOM No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (head.RequisitionHeaderId == 0)
                {
                    head.CreatedBy = _view.EpiSession.User.Id;
                    head.CreationDate = DateTime.Now;
                    head.RequisitionNumber = _repository.GetDocNo("PURCHASE_PR");
                    head.Segment1 = head.RequisitionNumber;
                    head.SummaryFlag = "Y";
                    head.EnabledFlag = "Y";

                    head.RequisitionHeaderId = _repository.InsertPR(head);
                }
                else
                {
                    _repository.UpdatePR(head);
                }
                _view.reqHead = _repository.GetHeadByID(head.RequisitionHeaderId);

                var lines = _view.reqLines;
                if(lines.Count > 0)
                {
                    //if(lines.Where(x => x.ValidatedFlag == false).Count() > 0)
                    //{
                    //    MessageBox.Show("Have some line data is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}

                    foreach(var line in lines)
                    {
                        line.LastUpdateDate = DateTime.Now;
                        line.LastUpdatedBy = _view.EpiSession.User.Id;

                        //Skip PO Confirm Price
                        line.FinalUnitPrice = line.UnitPrice;

                        double revAmount = line.ExtendedAmount;

                        //
                        if (line.EncumbranceFlag)
                            revAmount = line.ExtendedAmount - line.EncumbranceAmount;

                        //Get Cost remaining balance.
                        var budgetCost = _repoPrj.GetByProjectCost(head.ProjectNo, line.CostCode);

                        if(budgetCost.UfBudgetRemain >= revAmount)
                        {
                            //Set Encumbrance Flag/Amount for PR line.
                            line.EncumbranceFlag = true;
                            line.EncumbranceAmount = line.ExtendedAmount;
                        }
                        else
                        {
                            line.EncumbranceFlag = false;
                            line.EncumbranceAmount = 0; 
                        }

                        if (line.RequisitionLineId == 0)
                        {                            
                            line.CreationDate = DateTime.Now;
                            line.CreatedBy = _view.EpiSession.User.Id;
                            _repository.InsertPRLine(line);
                        }
                        else
                        {
                            _repository.UpdatePRLine(line);
                        }                        
                    }
                    _repoPrj.ProjectCost_Reset(_view.projHead.Id);
                }                
                Refresh_Click(null, null);
                List<RequisitionHeaderModel> reqList = _repository.GetHeadByProjectNumber(_view.reqHead.ProjectNo);
                _view.BindingRequisitionByProject(reqList, _view.projHead);
                Cursor.Current = Cursors.Default;
            }
        }

        
        private void Reset_ProjectCost()
        {
            var budgetLines = _view.projBudget;
            if(budgetLines != null)
            {
                foreach (var line in budgetLines)
                {
                    var budgetUsage = _repoPrj.GetCostUsage(line.ProjectNum, line.CostCode);
                    line.FcstCostAmount = budgetUsage;
                    _repoPrj.UpdateProjCost(line);
                }

                _view.projBudget = _repoPrj.GetProjectCostByProjID(_view.projHead.Id);
                _view.BindingBudgetLines(_view.projBudget);
            }
        }

        private async void Refresh_Click(object sender, EventArgs e)
        {
            if(_view.reqHead != null)
            {
                RequisitionHeaderModel head = _repository.GetHeadByID(_view.reqHead.RequisitionHeaderId);
                List<RequisitionLineModel> lines = _repository.GetLinesByHeaderID(head.RequisitionHeaderId);
                List<CostGroupModel> costs = new List<CostGroupModel>();

                int prjId = _view.projects.Where(x => x.ProjectNum.Trim() == head.ProjectNo.Trim()).FirstOrDefault().Id;
                if (prjId != 0)
                    _view.projectCosts = _repoPrj.GetProjectCostByProjID(prjId);

                if (head.BomId != 0)
                    costs = _repoPrj.GetCostGropByBOMID(head.BomId).Where(x => _view.projectCosts.Any(p => x.CostCode == p.CostCode)).ToList();
                else
                    costs = null;

                if (lines.Count == 0)
                    _view.EnableBomSelecting();
                else if (lines.Count > 0)
                    _view.DisableBomSelecting();

                _view.reqHead = head;
                _view.reqLines = lines;

                _view.BindingComboCost(costs);
                _view.BindingLines(_view.reqLines.OrderBy(o => o.CreationDate).ToList());

                _view.projBudget = _repoPrj.GetProjectCostByProjID(_view.projHead.Id);
                _view.BindingBudgetLines(_view.projBudget);
                //_view.bindingBudgetLines.DataSource = _view.projBudget;

                _view.items = await GetItemListAsync();
            }
        }

        private void Find_Boms(object sender, EventArgs e)
        {
            if (_view.reqHead != null)
            {
                using (BomNumberListForm frm = new BomNumberListForm(null))
                {
                    frm.ShowDialog();
                    List<CostGroupModel> costs = new List<CostGroupModel>();
                    if (frm.bomSelected != null)
                    {
                        RequisitionHeaderModel req = _view.reqHead;
                        req.BomId = frm.bomSelected.BomId;
                        req.BomNumber = frm.bomSelected.BomNumber.ToString();
                        _view.reqHead = req;

                        costs = _repoPrj.GetCostGropByBOMID(req.BomId).Where(x => _view.projectCosts.Any(p => x.CostCode == p.CostCode)).ToList();
                        _view.BindingComboCost(costs);
                    }
                    else
                    {
                        _view.BindingComboCost(null);
                    }
                }
            }
        }

        private void Find_Approver(object sender, EventArgs e)
        {
            if (_view.reqHead != null)
            {
                using (UserListForm frm = new UserListForm(null))
                {
                    frm.ShowDialog();
                    if (frm.userSelected != null)
                    {
                        RequisitionHeaderModel req = _view.reqHead;
                        req.ApproverId = frm.userSelected.Id;
                        req.ApproverName = frm.userSelected.Description;

                        _view.reqHead = req;
                    }
                }
            }
        }

        private void Find_Requester(object sender, EventArgs e)
        {
            if(_view.reqHead != null)
            {
                using (UserListForm frm = new UserListForm(null))
                {
                    frm.ShowDialog();
                    if (frm.userSelected != null)
                    {
                        RequisitionHeaderModel req = _view.reqHead;
                        req.RequesterId = frm.userSelected.Id;
                        req.RequesterName = frm.userSelected.Description;

                        _view.reqHead = req;
                    }
                }
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            TreeView trv = sender as TreeView;
            TreeNode nodes = trv.SelectedNode;
            
            if(nodes != null)
            {

                if (_view.projHead == null)
                {
                    MessageBox.Show("Project is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                RequisitionHeaderModel head = new RequisitionHeaderModel();
                head.ProjectNo = _view.projHead.ProjectNum;                
                head.RequisitionDate = DateTime.Now;
                head.Status = "OPEN";
                head.RequesterId = _view.EpiSession.User.Id;
                head.RequesterName = _view.EpiSession.User.Description;
                head.ApproverId = _view.EpiSession.User.ApproverId;
                head.ApproverName = _view.EpiSession.User.ApproverName;
                head.PoConfirmedFlag = true;

                _view.EnableBomSelecting();
                _view.reqHead = head;

                int prjId = _view.projects.Where(x => x.ProjectNum.Trim() == head.ProjectNo.Trim()).FirstOrDefault().Id;
                if (prjId != 0)
                    _view.projectCosts = _repoPrj.GetProjectCostByProjID(prjId);

                _view.reqLines = new List<RequisitionLineModel>();            
                _view.BindingLines(_view.reqLines);
            }
        }

        private void Find_Project(object sender, EventArgs e)
        {
            //if (_view.reqHead != null)
            //{
                using (ProjectListForm frm = new ProjectListForm())
                {
                    frm.ShowDialog();
                    if (frm.projSelected != null)
                    {
                        _view.projects = frm.projSelected;
                        _view.BindingTree(_view.projects, null);
                        GetPagedListAsync(_view.projects);
                    }
                }
            //}
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            //New Click

            var prList = new List<RequisitionHeaderModel>();
            _view.reqLines = new List<RequisitionLineModel>();

            //_view.BindingReqHeadList(prList.ToPagedList(1, 50));
            _view.BindingLines(_view.reqLines);
            _view.items = await GetItemListAsync();
        }

        public async void GetPagedListAsync(List<ProjectModel> prjList)
        {
            await Task.Factory.StartNew(() =>
            {
                foreach (var prj in prjList)
                {
                    List<RequisitionHeaderModel> reqList = _repository.GetHeadByProjectNumber(prj.ProjectNum);
                    _view.BindingRequisitionByProject(reqList, prj);
                }
            });
        }

        private List<RequisitionLineModel> AddLineStandard(string[] pastedRows)
        {
            List<RequisitionLineModel> lines = new List<RequisitionLineModel>();
            int prjId = _view.projects.Where(x => x.ProjectNum == _view.reqHead.ProjectNo).FirstOrDefault().Id;
            foreach (string pastedRow in pastedRows)
            {
                RequisitionLineModel line = new RequisitionLineModel();
                bool itemExist = false;
                line.DupplicateFlag = false;
                string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });
                bool valid = true;
                for (int i = 0; i < pastedRowCells.Length; i++)
                {
                    line.RequisitionHeaderId = _view.reqHead.RequisitionHeaderId;
                    line.RefProjectId = prjId;
                    line.RefProjectNum = _view.reqHead.ProjectNo;
                    line.LineType = "STANDARD";
                    line.Status = "OPEN";
                    line.Uom = "PCS";
                    line.CostId = _view.reqHead.CostId;
                    line.CostCode = _view.reqHead.CostCode;
                    line.BomId = _view.reqHead.BomId;
                    line.BomNo = _view.reqHead.BomNumber;
                    line.ValidatedFlag = true;
                    line.PriceConfirmedFlag = true;

                    switch (i)
                    {
                        case 0:
                            line.BalloonNo = string.IsNullOrEmpty(pastedRowCells[i]) ? "" : pastedRowCells[i];
                            break;

                        case 1:
                            line.ItemCode = pastedRowCells[i];
                            if (!string.IsNullOrEmpty(line.ItemCode))
                            {
                                var item = _repoItem.GetItemByNumber(line.ItemCode.Trim());
                                if (item != null)
                                {
                                    //if (pastedRowCells[4] != item.Segment2)
                                    //    line.DupplicateManuFlag = true;
                                    if ((string.IsNullOrEmpty(pastedRowCells[4]) ? "" : pastedRowCells[4]).Trim() != (string.IsNullOrEmpty(item.Segment2) ? "" : item.Segment2).Trim())
                                    {
                                        line.DupplicateFlag = true;
                                        line.LineErrorMessage = "Item Code is dupplicated. But MANU ID dose not matching.";
                                    }
                                    else
                                    {
                                        line.LineErrorMessage = "";
                                    }

                                    itemExist = true;

                                    //Do not replace data when dupplicate is true
                                    if (!line.DupplicateFlag)
                                    {
                                        line.ItemId = item.InventoryItemId;
                                        line.ItemDescription = item.Description;
                                        line.SpecModel = item.Segment2;
                                        line.BrandMaterail = item.Segment3;
                                        line.UnitPrice = item.PricePerUnit;
                                        line.Uom = item.PrimaryUomCode;
                                    }
                                }
                                else
                                {
                                    //lines.Concat(list).ToList()
                                    var itemTemp = _view.reqLines.Concat(lines).Where(x => x.ItemCode == line.ItemCode).FirstOrDefault();
                                    if (itemTemp != null)
                                    {
                                        if ((string.IsNullOrEmpty(pastedRowCells[4]) ? "" : pastedRowCells[4]).Trim() != (string.IsNullOrEmpty(itemTemp.SpecModel) ? "" : itemTemp.SpecModel).Trim())
                                        {
                                            line.DupplicateFlag = true;
                                            line.LineErrorMessage = "Item Code is dupplicated in same PO. But MANU ID dose not matching.";
                                        }
                                        else
                                        {
                                            line.LineErrorMessage = "";
                                        }

                                        //Do not replace data when dupplicate is true
                                        itemExist = true;
                                        if (!line.DupplicateFlag)
                                        {
                                            line.ItemId = itemTemp.ItemId;
                                            line.ItemDescription = itemTemp.ItemDescription;
                                            line.SpecModel = itemTemp.SpecModel;
                                            line.BrandMaterail = itemTemp.BrandMaterail;
                                            line.UnitPrice = itemTemp.UnitPrice;
                                            line.Uom = itemTemp.Uom;
                                        }
                                    }
                                }                               
                            }
                            break;

                        case 2:
                            line.Quantity = InvalidNumber(string.IsNullOrEmpty(pastedRowCells[i]) ? "0" : pastedRowCells[i]);

                            if (line.Quantity == 0)
                                line.ValidatedFlag = false;

                            break;

                        case 3:
                            //if (!itemExist)
                                line.ItemDescription = pastedRowCells[i];
                            break;

                        case 4:
                            //if (!itemExist)
                            //{
                                line.SpecModel = pastedRowCells[i];
                                if (!string.IsNullOrEmpty(line.SpecModel))
                                {
                                    var item = _repoItem.GetItemByManuId(line.SpecModel.Trim());
                                    if (item != null)
                                    {
                                        if ((string.IsNullOrEmpty(line.ItemCode) ? "" : line.ItemCode).Trim() != (string.IsNullOrEmpty(item.Segment1) ? "" : item.Segment1).Trim())
                                        {
                                            line.LineErrorMessage = "MANU ID is dupplicated. But Item Code dose not matching.";
                                            line.DupplicateFlag = true;
                                            MessageBox.Show("Manu ID is existing with Item code : " + item.Segment1 + "", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                        else
                                        {
                                            line.LineErrorMessage = "";
                                        }

                                        //Do not replace data when dupplicate is true
                                        itemExist = true;
                                        if (!line.DupplicateFlag)
                                        {
                                            line.ItemId = item.InventoryItemId;
                                            line.ItemCode = item.Segment1;
                                            line.ItemDescription = item.Description;
                                            line.BrandMaterail = item.Segment3;
                                            line.UnitPrice = item.PricePerUnit;
                                            line.Uom = item.PrimaryUomCode;
                                        }
                                    }
                                    else
                                    {
                                        var itemTemp = _view.reqLines.Concat(lines).Where(x => x.SpecModel == line.SpecModel).FirstOrDefault();
                                        if (itemTemp != null)
                                        {
                                            if ((string.IsNullOrEmpty(line.ItemCode) ? "" : line.ItemCode).Trim() != (string.IsNullOrEmpty(itemTemp.ItemCode) ? "" : itemTemp.ItemCode).Trim())
                                            {
                                                line.DupplicateFlag = true;
                                                line.LineErrorMessage = "MANU ID is dupplicated in same PO. But Item Code dose not matching.";
                                            }
                                            else
                                            {
                                                line.LineErrorMessage = "";
                                            }

                                            //Do not replace data when dupplicate is true
                                            itemExist = true;
                                            if (!line.DupplicateFlag)
                                            {
                                                line.ItemId = itemTemp.ItemId;
                                                line.ItemCode = itemTemp.ItemCode;
                                                line.ItemDescription = itemTemp.ItemDescription;
                                                line.SpecModel = itemTemp.SpecModel;
                                                line.BrandMaterail = itemTemp.BrandMaterail;
                                                line.UnitPrice = itemTemp.UnitPrice;
                                                line.Uom = itemTemp.Uom;
                                            }
                                        }
                                    }
                                }
                            //}
                            break;

                        case 5:
                            //if (!itemExist)
                                line.BrandMaterail = pastedRowCells[i];
                            break;

                        //case 6:
                        //    line.CostCode = pastedRowCells[i];
                        //    if (!ValidCostGroup(line.CostCode))
                        //    {
                        //        MessageBox.Show("Cost Code : " + line.CostCode + " dose not existing.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        valid = false;
                        //    }
                        //    else
                        //    {
                        //        CostGroupModel cost = _view.costs.Where(x => x.CostCode == line.CostCode).FirstOrDefault();
                        //        if (_view.poHead.JobFlag && !cost.MakingFlag)
                        //        {
                        //            MessageBox.Show("Cost Code : " + line.CostCode + " dose not making job.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //            valid = false;
                        //        }
                        //    }
                        //    break;

                        //case 7:
                        //    line.BomNo = pastedRowCells[i];
                        //    break;

                        case 8:
                            line.SuplierSymbol = pastedRowCells[i];
                            break;

                        case 9:
                            double unitPriceT = InvalidNumber(string.IsNullOrEmpty(pastedRowCells[i]) ? "0.00" : pastedRowCells[i]);
                            if (!itemExist)
                            {
                                line.UnitPrice = unitPriceT;
                                line.FinalUnitPrice = line.UnitPrice;
                            }else if(itemExist && unitPriceT != 0)
                            {
                                line.UnitPrice = unitPriceT;
                                line.FinalUnitPrice = line.UnitPrice;
                            }
                            else 
                            {
                                line.FinalUnitPrice = line.UnitPrice;
                            }

                            break;

                        case 10:
                            line.DueDate = string.IsNullOrEmpty(pastedRowCells[i]) ? null : ValidateDateFormat(pastedRowCells[i]);
                            break;

                        case 11:
                            line.CsrNo = pastedRowCells[i];
                            break;

                        case 12:
                            line.LeadTime = 1;
                            break;

                        case 13:
                            line.LoadBomDate = ValidateDateFormat(pastedRowCells[i]);
                            break;

                        default:
                            break;
                    }
                }
                if (valid)
                    lines.Add(line);
            }
            return lines;
        }

        private double InvalidNumber(string number)
        {
            double myDouble;
            bool isNumerical = double.TryParse(number, out myDouble);
            return myDouble;
        }

        private DateTime? ValidateDateFormat(string v)
        {
            CultureInfo enUS = new CultureInfo("en-US");
            Nullable<DateTime> dateValue = null;
            if (!string.IsNullOrEmpty(v))
            {
                try
                {
                    dateValue = DateTime.ParseExact(v, "dd/MM/yy", enUS, DateTimeStyles.None);
                }
                catch (FormatException)
                {
                    MessageBox.Show(string.Format("'{0}' is not in an acceptable format for dd/MM/yy.", v),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    dateValue = null;
                }
            }
            return dateValue;
        }

        private List<RequisitionLineModel> AddLineMaking(string[] pastedRows)
        {
            List<RequisitionLineModel> lines = new List<RequisitionLineModel>();
            int prjId = _view.projects.Where(x => x.ProjectNum == _view.reqHead.ProjectNo).FirstOrDefault().Id;
            foreach (string pastedRow in pastedRows)
            {
                RequisitionLineModel line = new RequisitionLineModel();
                string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });
                bool valid = true;
                for (int i = 0; i < pastedRowCells.Length; i++)
                {
                    line.RequisitionHeaderId = _view.reqHead.RequisitionHeaderId;
                    line.RefProjectId = prjId;
                    line.RefProjectNum = _view.reqHead.ProjectNo;
                    line.LineType = _view.reqHead.TypeLookupCode;
                    line.Uom = "PCS";
                    line.LineType = "MAKING";
                    line.Status = "OPEN";
                    line.CostId = _view.reqHead.CostId;
                    line.CostCode = _view.reqHead.CostCode;
                    line.BomId = _view.reqHead.BomId;
                    line.BomNo = _view.reqHead.BomNumber;
                    line.ValidatedFlag = true;
                    line.PriceConfirmedFlag = true;

                    switch (i)
                    {
                        case 0:
                            line.BalloonNo = string.IsNullOrEmpty(pastedRowCells[i]) ? "" : pastedRowCells[i];
                            break;

                        case 1:
                            line.ItemCode = pastedRowCells[i];
                            if (!string.IsNullOrEmpty(line.ItemCode))
                            {
                                var item = _repoItem.GetItemByNumber(line.ItemCode.Trim());
                                if (item != null)
                                {
                                    if (line.SpecModel != item.Segment2)
                                        line.DupplicateFlag = true;

                                    //Do not replace data when dupplicate is true
                                    if (!line.DupplicateFlag)
                                    {
                                        line.ItemId = item.InventoryItemId;
                                        line.ItemDescription = item.Description;
                                        line.SpecModel = item.Segment2;
                                        line.BrandMaterail = item.Segment3;
                                        line.UnitPrice = item.PricePerUnit;
                                        line.Uom = item.PrimaryUomCode;
                                    }                             
                                }
                                else
                                {
                                    var itemTemp = _view.reqLines.Concat(lines).Where(x => x.ItemCode == line.ItemCode).FirstOrDefault();
                                    if (itemTemp != null)
                                    {
                                        if (line.SpecModel != itemTemp.SpecModel)
                                            line.DupplicateFlag = true;

                                        //Do not replace data when dupplicate is true
                                        if (!line.DupplicateFlag)
                                        {
                                            line.ItemId = itemTemp.ItemId;
                                            line.ItemDescription = itemTemp.ItemDescription;
                                            line.SpecModel = itemTemp.SpecModel;
                                            line.BrandMaterail = itemTemp.BrandMaterail;
                                            line.UnitPrice = itemTemp.UnitPrice;
                                            line.Uom = itemTemp.Uom;
                                        }
                                    }
                                }
                            }
                            break;

                        case 2:
                            line.Quantity = InvalidNumber(string.IsNullOrEmpty(pastedRowCells[i]) ? "0" : pastedRowCells[i]);
                            break;

                        case 3:
                            line.ItemDescription = pastedRowCells[i];
                            break;

                        case 4:
                            line.BrandMaterail = pastedRowCells[i];
                            break;

                        //case 5:
                        //    line.CostCode = pastedRowCells[i];
                        //    if (!ValidCostGroup(line.CostCode))
                        //    {
                        //        MessageBox.Show("Cost Code : " + line.CostCode + " dose not existing.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        valid = false;
                        //    }
                        //    else
                        //    {
                        //        CostGroupModel cost = _view.costs.Where(x => x.CostCode == line.CostCode).FirstOrDefault();
                        //        if (_view.poHead.JobFlag && !cost.MakingFlag)
                        //        {
                        //            MessageBox.Show("Cost Code : " + line.CostCode + " dose not making job.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //            valid = false;
                        //        }
                        //        //else if (!_view.poHead.JobFlag && cost.MakingFlag)
                        //        //{
                        //        //    MessageBox.Show("Cost Code : " + line.CostCode + " dose making job.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        //    valid = false;
                        //        //}
                        //    }
                        //    break;

                        //case 6:
                        //    line.BOM = pastedRowCells[i];
                        //    break;

                        case 7:
                            line.SuplierSymbol = pastedRowCells[i];
                            break;

                        case 8:
                            line.UnitPrice = InvalidNumber(string.IsNullOrEmpty(pastedRowCells[i]) ? "0" : pastedRowCells[i]);
                            line.FinalUnitPrice = line.UnitPrice;

                            break;

                        case 9:
                            line.DueDate = string.IsNullOrEmpty(pastedRowCells[i]) ? null : ValidateDateFormat(pastedRowCells[i]);
                            break;

                        case 10:
                            line.EcnNo = pastedRowCells[i];
                            break;

                        case 11:
                            line.LeadTime = 1;
                            break;

                        case 12:
                            line.LoadBomDate = DateTime.Now;
                            break;

                        default:
                            break;
                    }
                }
                if (valid)
                    lines.Add(line);
            }
            return lines;
        }

        public async Task<List<ItemMasterModel>> GetItemListAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                var result = _repoItem.GetItemAll();
                return result;
            });
        }
    }
}
