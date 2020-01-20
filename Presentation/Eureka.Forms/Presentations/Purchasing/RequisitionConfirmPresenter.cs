using Eureka.Core.Domain.Commons;
using Eureka.Core.Domain.Payables;
using Eureka.Core.Domain.Projects;
using Eureka.Core.Domain.Purchasing;
using Eureka.Forms.Views.Purchasing;
using Eureka.Froms.Views.Controls;
using Eureka.Froms.Views.Payables;
using Eureka.Froms.Views.Projects;
using Eureka.Froms.Views.Purchasing;
using Eureka.Services.Inventory;
using Eureka.Services.Payables;
using Eureka.Services.Projects;
using Eureka.Services.Purchasing;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Purchasing
{
    public class RequisitionConfirmPresenter
    {
        private readonly IRequisitionConfirmView _view;
        private readonly IRequisitionSrv _repository;
        private readonly IProjectSrv _repoProj;
        private readonly IItemMasterSrv _repoItem;
        private readonly IPayablesSrv _repoPay;
        private readonly IPurchasingSrv _repoPO;

        public RequisitionConfirmPresenter(IRequisitionConfirmView view)
        {
            _view = view;

            _repository = new RequisitionSrv();
            _repoProj = new ProjectSrv();
            _repoPay = new PayablesSrv();            
            _repoItem = new ItemMasterSrv();
            _repoPO = new PurchasingSrv();

            _view.Form_Load += Form_Load;
            _view.Filter_Click += Filter;
            _view.Find_Project += Find_Project;
            _view.Find_Bom += Find_Bom;
            _view.Find_Requistion += Find_Requistion;
            _view.Save_Changed += Save_Changed;
            _view.Find_Vendor += Find_Vendor;
            //_view.Set_Vendor += Set_Vendor;
            _view.ConfirmPrice_Click += ConfirmPrice_Click;
            //_view.Reject_Click += Reject_Click;
            //_view.ConvertPO_Click += ConvertPO_Click;
            _view.Selection_Changed += Selection_Changed;
            _view.UnConfirmPrice_Click += UnConfirmPrice_Click;
            _view.Refresh_Lines += Refresh_Lines;
            _view.Sorting_Changed += Sorting;
            _view.Change_Cost += Change_Cost;
        }

        private void Sorting(object sender, EventArgs e)
        {
            List<RequisitionLineModel> lines = _view.reqLines;

            if(lines.Count > 0)
            {
                if (!string.IsNullOrEmpty(_view.SortBy))
                {
                    if (_view.SortBy == "Requisition No.")
                    {
                        if (_view.SortType == "Z-A")
                            lines = lines.OrderByDescending(o => o.RequisitionNumber).ToList();
                        else
                            lines = lines.OrderBy(o => o.RequisitionNumber).ToList();
                    }

                    if (_view.SortBy == "Line No.")
                    {
                        if (_view.SortType == "Z-A")
                            lines = lines.OrderByDescending(o => o.LineNum).ToList();
                        else
                            lines = lines.OrderBy(o => o.LineNum).ToList();
                    }

                    if (_view.SortBy == "Item No.")
                    {
                        if (_view.SortType == "Z-A")
                            lines = lines.OrderByDescending(o => o.ItemCode).ToList();
                        else
                            lines = lines.OrderBy(o => o.ItemCode).ToList();
                    }

                    if (_view.SortBy == "BOM No.")
                    {
                        if (_view.SortType == "Z-A")
                            lines = lines.OrderByDescending(o => o.BomNo).ToList();
                        else
                            lines = lines.OrderBy(o => o.BomNo).ToList();
                    }

                    if (_view.SortBy == "Brand")
                    {
                        if (_view.SortType == "Z-A")
                            lines = lines.OrderByDescending(o => o.BrandMaterail).ToList();
                        else
                            lines = lines.OrderBy(o => o.BrandMaterail).ToList();
                    }

                    if (_view.SortBy == "Manu ID")
                    {
                        if (_view.SortType == "Z-A")
                            lines = lines.OrderByDescending(o => o.SpecModel).ToList();
                        else
                            lines = lines.OrderBy(o => o.SpecModel).ToList();
                    }
                    _view.reqLines = lines;
                    _view.bindingLines.DataSource = lines;
                }
            }
        }

        private void Change_Cost(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_view.projectNumber))
            {
                MetroGrid grd = sender as MetroGrid;
                if(grd.SelectedRows.Count > 0)
                {
                    using (ProjectCostListForm frm = new ProjectCostListForm(_view.projectNumber))
                    {
                        frm.ShowDialog();
                        if (frm.projCostSelected != null)
                        {
                            var cost = frm.projCostSelected.FirstOrDefault();

                            if (grd.SelectedRows.Count > 0)
                            {
                                DialogResult dialogResult = MessageBox.Show("Are you sure to change cost?", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    foreach (DataGridViewRow dgr in grd.SelectedRows)
                                    {
                                        RequisitionLineModel curr = (RequisitionLineModel)dgr.DataBoundItem;
                                        try
                                        {
                                            if (!curr.RejectFlag)
                                            {
                                                curr.CostId = cost.CostId;
                                                curr.CostCode = cost.CostCode;
                                                _repository.UpdatePRLine(curr);
                                                _repoProj.ProjectCost_Reset(curr.RefProjectId);
                                            }
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    Filter(null, null);
                                }
                            }
                        }
                    }
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
                                        curr.DueDate = frm.dateSeleted;
                                        _repository.UpdatePRLine(curr);
                                    }
                                }
                                catch
                                {
                                }
                            }
                            Filter(null, null);
                        }
                    }
                }
            }
        }

        private void Refresh_Lines(object sender, EventArgs e)
        {
            Filter(null, null);
        }

        private void UnConfirmPrice_Click(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;
            if (grd.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to Un-Confirm Price.", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgr in grd.SelectedRows)
                    {
                        RequisitionLineModel curr = (RequisitionLineModel)dgr.DataBoundItem;
                        if (curr.FinalConfirmFlag)
                        {
                            curr.FinalConfirmFlag = false;
                            _repository.UpdatePRLine(curr);
                        }
                    }
                    _view.RefreshLinesGird();                    
                }
            }
        }

        private void Selection_Changed(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;

            List<RequisitionLineModel> lines = new List<RequisitionLineModel>();
            RequisitionLineModel line = new RequisitionLineModel();
            if (grd.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow row in grd.SelectedRows)
                {
                    line = (RequisitionLineModel)row.DataBoundItem;

                    lines.Add(line);
                }
            }

            _view.linesSelected = lines;
        }

        private void ConvertPO_Click(object sender, EventArgs e)
        {
            //_view.RefreshLinesGird();
            bool jobProcess = false;
            int vendorId = 0;
            string poTypeCode = string.Empty;

            if (_view.linesSelected.Count == 0)
                return;

            var reqLines = _view.linesSelected;

            //Validation multiple Vendors
            var resVendors = reqLines.GroupBy(x => x.VendorId)
                 .Select(group => new { Vendor = group.Key, lines = group.ToList() })
                 .ToList();
            if (resVendors.Count > 1)
            {
                MessageBox.Show("Lines seleted more than one Vendors, cannot convert PO to one by one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                vendorId = resVendors.FirstOrDefault().Vendor;
            }

            //Validation multiple Line Type
            var resTypes = reqLines.GroupBy(x => x.LineType)
                 .Select(group => new { LineType = group.Key, lines = group.ToList() })
                 .ToList();
            if (resTypes.Count > 1)
            {
                MessageBox.Show("Lines seleted more than one Type, cannot convert PO to one by one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                //Set PO Type Code.
                poTypeCode = resTypes.FirstOrDefault().LineType;

                var costs = _repoProj.GetCostGropAll();
                var str = (from c in _view.linesSelected
                                    select new { costCode = c.CostCode }).ToArray();

                var query = costs.Where(x => str.Any(a => a.costCode == x.CostCode)).ToList()
                            .GroupBy(p => p.MakingFlag)
                            .Select(group => new { makings = group.Key, glines = group.ToList() })
                            .ToList();
                if(query.Count > 1)
                {
                    MessageBox.Show("Lines seleted more than one Type, cannot convert PO to one by one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    //Set PO Job Process Flag.
                    jobProcess = query.ToList().FirstOrDefault().makings;
                }
                //var jobProcessCosts = costs.Where(x => costs)
            }

            var resUnConfirm = reqLines.Where(x => !x.FinalConfirmFlag).ToList();
            if (resUnConfirm.Count > 0)
            {
                MessageBox.Show("Some lines seleted is not Confirm price.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            POHeaderModel head = new POHeaderModel();
            head.ProjectId = _view.projectParam.Id;
            head.ProjectNum = _view.projectParam.ProjectNum;
            head.JobFlag = jobProcess;
            head.TypeLookupCode = poTypeCode;
            head.VendorId = vendorId;
            head.PODate = DateTime.Now;
            head.Status = "OPEN";
            head.StatusCode = "OPEN";
            head.BuyerId = _view.EpiSession.User.Id;
            head.BuyerName = _view.EpiSession.User.UserName;

            string typeLookup = string.Empty;
            if (head.TypeLookupCode == "STANDARD")
                typeLookup = "PURCHASE_PO";
            else if (head.TypeLookupCode == "MAKING")
            {
                if (head.JobFlag)
                    typeLookup = "PURCHASE_PD";
                else
                    typeLookup = "PURCHASE_PO";
            }
            //Combind Vendor Detail.
            head = CombindVendor(head);

            head.SubTotal = _view.linesSelected.Sum(x => x.ExtendedAmount);
            head.PoNum = _repoPO.GetDocNoByType(typeLookup);
            head.PoHeaderId = _repoPO.InsertPO(head);

            //Validate to Add Line
            if(head.PoHeaderId != 0)
            {
                try
                {
                    if (_view.linesSelected != null)
                    {
                        //List<POLineModel> list = _view.poLine;
                        foreach (RequisitionLineModel item in _view.linesSelected)
                        {
                            POLineModel pol = new POLineModel();
                            pol.PoHeaderId = head.PoHeaderId;
                            pol.LastUpdatedBy = _view.EpiSession.User.Id;
                            pol.CreatedBy = _view.EpiSession.User.Id;
                            pol.RefProjectId = _view.projectParam.Id;
                            pol.RefProjectNum = _view.projectParam.ProjectNum;
                            pol.LastUpdateDate = DateTime.Now;
                            pol.CreationDate = DateTime.Now;
                            pol.Status = "OPEN";
                            pol.BalloonNo = item.BalloonNo;
                            pol.ItemCode = item.ItemCode;
                            pol.Quantity = item.Quantity;
                            pol.ItemDescription = item.ItemDescription;
                            pol.Spec = item.SpecModel;
                            pol.BrandMaterail = item.BrandMaterail;                            
                            pol.CostCode = item.CostCode;                           
                            pol.BOM = item.BomNo;
                            pol.Suplier = item.SuplierSymbol;
                            pol.UnitPrice = item.FinalUnitPrice;
                            pol.DueDate = item.DueDate;
                            pol.ECN = item.EcnNo;
                            pol.CSR = item.CsrNo;
                            pol.Uom = item.Uom;
                            pol.LeadTime = item.LeadTime;
                            pol.LoadBomDate = item.LoadBomDate;

                            int lineId = _repoPO.InsertPOLine(pol);
                            if(lineId != 0)
                            {
                                item.PurchasedFlag = true;
                                item.PurchasedQuantity = item.Quantity;
                                item.PoLineId = lineId;
                                item.PoHeaderId = head.PoHeaderId;
                                _repository.UpdatePRLine(item);
                            }
                        }

                        //Update Purchased flag in Requisition Header
                        var grpHeads = _view.linesSelected.GroupBy(item => item.RequisitionHeaderId)
                                  .Select(group => new { reqHeaderId = group.Key, ReqLines = group.ToList() })
                                  .ToList();
                        foreach(var req in grpHeads)
                        {
                            _repository.UpdatePurchasedFlag(req.reqHeaderId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PO Lines is Error! " + Environment.NewLine
                        + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Filter(null, null);
                MessageBox.Show(string.Format("Convert to PO Number : {0} complete.", head.PoNum), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                POEntryForm POfrm = new POEntryForm(head);
                POfrm.Show();
            }
        }

        private POHeaderModel CombindVendor(POHeaderModel head)
        {
            POHeaderModel po = head;
            VendorModel vendor = _repoPay.GetVendorByID(po.VendorId);

                if (vendor != null)
                {
                    po.VendorId = vendor.VendorId;
                    po.VendorNum = vendor.VendorNumber;
                    po.VendorName = vendor.VendorName;

                    //Default Term by Vendor
                    if (!string.IsNullOrEmpty(vendor.TermCode))
                    {
                        TermModel term = _repoPay.GetTermByCode(vendor.TermCode);
                        if (term != null)
                        {
                            po.TermId = term.TermId;
                            po.TermCode = term.TermCode;
                            po.TermDesc = term.Description;
                        }
                    }

                    //Default Term by Currency
                    if (!string.IsNullOrEmpty(vendor.InvoiceCurrencyCode))
                    {
                        CurrencyModel curr = _repoPO.GetCurrencies().Where(x => x.CurrencyCode == vendor.InvoiceCurrencyCode).FirstOrDefault();
                        if (curr != null)
                        {
                            po.CurrencyCode = curr.CurrencyCode;
                            po.Rate = curr.ConversionRate;
                            po.RateDate = curr.ConversionDate;
                        }
                    }

                    //Default Term by Tax
                    if (!string.IsNullOrEmpty(vendor.VatCode))
                    {
                        TaxCodeModel tax = _repoPO.GetTaxCodes().Where(x => x.TaxCode == vendor.VatCode).FirstOrDefault();
                        if (tax != null)
                        {
                            po.TaxCode = tax.TaxCode;
                            po.TaxRate = tax.TaxRate;
                        }
                    }
                }

            return po;
        }

        private void Reject_Click(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;
            if (grd.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to Reject.", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgr in grd.SelectedRows)
                    {
                        RequisitionLineModel curr = (RequisitionLineModel)dgr.DataBoundItem;
                        if (!curr.FinalConfirmFlag)
                        {
                            curr.RejectFlag = true;
                            curr.CancelFlag = true;
                        }                            
                    }
                    _view.RefreshLinesGird();
                }
            }
        }

        private void ConfirmPrice_Click(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;
            if (grd.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to Confirm Price.", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgr in grd.SelectedRows)
                    {
                        RequisitionLineModel curr = (RequisitionLineModel)dgr.DataBoundItem;
                        if (!curr.RejectFlag)
                        {
                            curr.PriceConfirmedFlag = true;
                            _repository.UpdatePRLine(curr);
                        }                            
                    }

                    //Update Purchased flag in Requisition Header.
                    var grpHeads = _view.linesSelected.GroupBy(item => item.RequisitionHeaderId)
                              .Select(group => new { reqHeaderId = group.Key, ReqLines = group.ToList() })
                              .ToList();

                    //Loop by Requisition Headers.
                    foreach (var req in grpHeads)
                    {
                        //Get all lines by Requisition headers.
                        List<RequisitionLineModel> lines = _repository.GetLinesByHeaderID(req.reqHeaderId);

                        //Group by PO Confirm Status.
                        var grpLinesStatus = lines.GroupBy(grp => grp.PriceConfirmedFlag)
                                             .Select(group => new { status = group.Key, lines = group.ToList() })
                                             .ToList();

                        //If not multiple status.
                        if(grpLinesStatus.Count() == 1)
                        {
                            //If PO Confirm all lines.
                            if (grpLinesStatus.FirstOrDefault().status)
                            {
                                var reqh = _repository.GetHeadByID(req.reqHeaderId);
                                reqh.PoConfirmedFlag = true;
                                _repository.UpdatePR(reqh);
                            }
                        }                        
                    }

                    MessageBox.Show("Confirm price complete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Filter(null, null);
                    _view.RefreshLinesGird();
                }
            }
        }

        private void CheckAll_Click(object sender, EventArgs e)
        {
            Filter(null, null);
            _view.BindCheckBox();
        }

        private void Set_Vendor(object sender, EventArgs e)
        {
            using (VendorListForm frm = new VendorListForm())
            {
                frm.ShowDialog();
                if (frm.vendorSelected != null)
                {
                    //_view.vendorNum = frm.vendorSelected.VendorNumber;
                    MetroGrid grd = sender as MetroGrid;
                    if (grd.SelectedRows.Count > 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure to set this vendor.", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow dgr in grd.SelectedRows)
                            {
                                //RequisitionLineModel curr = (RequisitionLineModel)_view.bindingLine.Current;
                                RequisitionLineModel curr = (RequisitionLineModel)dgr.DataBoundItem;
                                try
                                {
                                    if (!curr.RejectFlag)
                                    {
                                        curr.VendorId = frm.vendorSelected.VendorId;
                                        curr.VendorName = frm.vendorSelected.VendorName;
                                        _repository.UpdatePRLine(curr);
                                    }
                                }
                                catch
                                {
                                }                 
                            }
                            //_view.RefreshLinesGird();
                            Filter(null, null);
                        }
                    }
                }
            }
        }

        private void Find_Vendor(object sender, EventArgs e)
        {
            using (VendorListForm frm = new VendorListForm())
            {
                frm.ShowDialog();
                if (frm.vendorSelected != null)
                {
                   //_view.vendorName = frm.vendorSelected.VendorName;
                    Filter(null, null);
                }
            }
        }

        private void Save_Changed(object sender, EventArgs e)
        {
            //bool Result = false;
            var lines = _view.reqLines;
            _view.bindingLines.EndEdit();
            MetroGrid grd = sender as MetroGrid;
            if (grd.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in grd.Rows)
                {
                    RequisitionLineModel line = (RequisitionLineModel)row.DataBoundItem;
                    line.LastUpdateDate = DateTime.Now;
                    line.LastUpdatedBy = _view.EpiSession.User.Id;

                    //Get Cost remaining balance.
                    var budgetCost = _repoProj.GetByProjectCost(line.RefProjectNum, line.CostCode);

                    if (budgetCost.UfBudgetRemain >= line.ExtendedAmount)
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

                    line.FinalUnitPrice = line.UnitPrice;
                    _repository.UpdatePRLine(line);
                }

                MessageBox.Show("Save price complete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _repoProj.ProjectCost_Reset(_view.projectParam.Id);
                Filter(null, null);
            }
 
        }

        private void Reset_ProjectCost()
        {
            var budgetLines = _view.projBudget;
            foreach(var line in budgetLines)
            {
                var budgetUsage = _repoProj.GetCostUsage(line.ProjectNum, line.CostCode);
                line.FcstCostAmount = budgetUsage;
                _repoProj.UpdateProjCost(line);
            }

            _view.projBudget = _repoProj.GetProjectCostByProjID(_view.projectParam.Id);
            _view.BindingBudgetLines(_view.projBudget);
        }

        private void Find_Requistion(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_view.requisitionNumber))
            {
                RequisitionHeaderModel reqhead = _repository.GetHeadByNumber(_view.requisitionNumber);
                if (reqhead != null)
                    _view.reqheadParam = reqhead;
                else
                    _view.reqheadParam = null;
            }
            else
                _view.reqheadParam = null;

            if (_view.reqheadParam != null)
            {
                _view.requisitionNumber = _view.reqheadParam.RequisitionNumber;
                return;
            }
            else
            {
                using (RequisitionListForm frm = new RequisitionListForm(null))
                {
                    frm.ShowDialog();
                    if (frm.prsSelected != null)
                    {
                        _view.reqheadParam = frm.prsSelected.FirstOrDefault();
                        _view.requisitionNumber = _view.reqheadParam.RequisitionNumber;
                    }
                    else
                        _view.reqheadParam = null;
                }
            }
        }

        private void Find_Bom(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_view.bomNumber))
            {
                BomNumberModel bom = _repoProj.GetBomNumbersAll().Where(x => x.BomNumber == _view.bomNumber).FirstOrDefault();
                if (bom != null)
                    _view.bomsParam = bom;
                else
                    _view.bomsParam = null;
            }
            else
                _view.bomsParam = null;

            if (_view.bomsParam != null)
            {
                _view.bomNumber = _view.bomsParam.BomNumber;
                return;
            }
            else
            {
                using (BomNumberListForm frm = new BomNumberListForm(null))
                {
                    frm.ShowDialog();
                    if (frm.bomSelected != null)
                    {
                        _view.bomsParam = frm.bomSelected;
                        _view.bomNumber = _view.bomsParam.BomNumber;
                    }
                    else
                        _view.bomsParam = null;
                }
            }
        }

        private void Find_Project(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_view.projectNumber))
            {
                ProjectModel prj = _repoProj.GetProjectByNumber(_view.projectNumber);
                if (prj != null)
                    _view.projectParam = prj;
                else
                    _view.projectParam = null;
            }
            else
                _view.projectParam = null;

            if(_view.projectParam != null)
            {
                _view.projectNumber = _view.projectParam.ProjectNum;
                return;
            }
            else
            {
                using (ProjectListForm frm = new ProjectListForm())
                {
                    frm.ShowDialog();
                    if (frm.projSelected != null)
                    {
                        _view.projectParam = frm.projSelected.FirstOrDefault();
                        _view.projectNumber = _view.projectParam.ProjectNum;
                    }
                    else
                        _view.projectParam = null;
                }
            }
        }

        private void Filter(object sender, EventArgs e)
        {
            if(_view.projectParam != null)
            {
                List<RequisitionLineModel> lines = _repository.GetLinesByProjectIDForConfirm(_view.projectParam.Id)
                                                              .OrderBy(o => o.RequisitionHeaderId)
                                                              .ThenBy(o => o.LineNum)
                                                              .ToList();

                if (!string.IsNullOrEmpty(_view.bomNumber)) lines = lines.Where(x => x.BomNo.ToUpper().Equals(_view.bomNumber.ToUpper())).ToList();
                if (!string.IsNullOrEmpty(_view.requisitionNumber)) lines = lines.Where(x => x.RequisitionNumber == (_view.requisitionNumber)).ToList();
                if (!string.IsNullOrEmpty(_view.itemNumber)) lines = lines.Where(x => x.ItemCode.ToUpper().Contains(_view.itemNumber.ToUpper())
                                                    || (string.IsNullOrEmpty(x.ItemDescription) ? "" : x.ItemDescription.ToUpper()).Contains(_view.itemNumber.ToUpper())
                                                    || (string.IsNullOrEmpty(x.SpecModel) ? "" : x.SpecModel.ToUpper()).Contains(_view.itemNumber.ToUpper())
                                                    || (string.IsNullOrEmpty(x.BrandMaterail) ? "" : x.BrandMaterail.ToUpper()).Contains(_view.itemNumber.ToUpper())).ToList();

                _view.reqLines = lines;
                _view.BindingLines(_view.reqLines);

                _view.projBudget = _repoProj.GetProjectCostByProjID(_view.projectParam.Id);
                _view.BindingBudgetLines(_view.projBudget);
                Sorting(sender, e);
            }
            else
            {
                MessageBox.Show("Please select Project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            _view.reqLines = new List<RequisitionLineModel>();
            _view.projBudget = new List<ProjectCostModel>();

            _view.BindingLines(_view.reqLines);
            _view.BindingBudgetLines(_view.projBudget);
        }
    }
}
