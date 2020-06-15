using Eureka.Core.Domain.Commons;
using Eureka.Core.Domain.Inventory;
using Eureka.Core.Domain.Manufacturing;
using Eureka.Core.Domain.Payables;
using Eureka.Core.Domain.Projects;
using Eureka.Core.Domain.Purchasing;
using Eureka.Forms.Views.Purchasing;
using Eureka.Froms.Views.Controls;
using Eureka.Froms.Views.Payables;
using Eureka.Froms.Views.Projects;
using Eureka.Froms.Views.Purchasing;
using Eureka.Services;
using Eureka.Services.Inventory;
using Eureka.Services.Manufacturing;
using Eureka.Services.Payables;
using Eureka.Services.Projects;
using Eureka.Services.Purchasing;
using MetroFramework.Controls;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Purchasing
{
    public class POEntryPresenter
    {
        private readonly IProjectSrv _repoProj;
        private readonly IPayablesSrv _repoPay;
        private readonly IPurchasingSrv _repository;
        private readonly IPOEntryView _view;
        private readonly IItemMasterSrv _repoItem;
        private readonly IRequisitionSrv _repReq;
        private readonly ISecuritieSrv _repoUser;
        private readonly IJobEntitySrv _repoJob;

        public POEntryPresenter(IPOEntryView view)
        {
            _view = view;
            _repoProj = new ProjectSrv();
            _repoPay = new PayablesSrv();
            _repository = new PurchasingSrv();
            _repoItem = new ItemMasterSrv();
            _repReq = new RequisitionSrv();
            _repoUser = new SecuritieSrv();
            _repoJob = new JobEntitySrv();

            _view.Form_Load += Form_Load;
            _view.Filter_Click += Filter_Click;
            _view.Save_Click += Save_Click;
            _view.New_Click += New_Click;
            _view.Find_Vendor += Find_Vendor;
            _view.Find_Term += Find_Term;
            _view.Find_Currency += Find_Currency;
            _view.Find_TaxCode += Find_TaxCode;
            _view.Find_Project += Find_Project;
            _view.Seleted_PO += Seleted_PO;
            _view.Paste_Rows += Paste_Rows;
            _view.SubmitPO_Click += SubmitPO_Click;
            _view.Print_PO += Print_PO;
            _view.Type_Change += Type_Change;
            _view.Approved_Click += ValidateApproval;
            _view.UnSubmitPO_Click += UnSubmitPO_Click;
            _view.Delete_Row += Delete_Row;
            _view.GetLine_Selected += GetLine_Selected;
            _view.Refresh_Click += Refresh_Click;
            _view.Cancel_Click += Cancel_Click;
            _view.Cancel_Line += Cancel_Line;
            _view.LineAdjustment += LineAdjustment;
        }

        private void LineAdjustment(object sender, EventArgs e)
        {
            using (POLineAdjustment frm = new POLineAdjustment(_view.poLine))
            {
                frm.ShowDialog();

                _view.poLine = frm.poLines;
                _view.BindingLines(frm.poLines);

                POHeaderModel po = _view.poHead;
                po.SubTotal = _view.poLine.Where(x => x.CancelFlag == false).Sum(x => x.ExtendedAmount);
                _view.poHead = po;
                _repository.UpdatePO(po);

                var resProj = _view.poLine.GroupBy(x => x.RefProjectId)
                                     .Select(group => new { ProjectId = group.Key, lines = group.ToList() })
                                     .FirstOrDefault();
                _view.projBudget = _repoProj.GetProjectCostByProjID(resProj.ProjectId);
                _view.BindingBudgetLines(_view.projBudget);
            }
        }

        private void Cancel_Line(object sender, EventArgs e)
        {
            if (_view.poLineSelected != null)
            {
                MetroGrid grd = sender as MetroGrid;
                if (grd.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure to Cancel Lines.", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        var resProj = _view.poLine.GroupBy(x => x.RefProjectId)
                             .Select(group => new { ProjectId = group.Key, lines = group.ToList() })
                             .FirstOrDefault();
                        foreach (DataGridViewRow item in grd.SelectedRows)
                        {
                            try
                            {
                                POLineModel line = (POLineModel)item.DataBoundItem;

                                //if (_view.poHead.JobFlag)
                                //{
                                //    var jobStatus = _repoJob.GetExistingPO(line.PoLineId);
                                //    if(jobStatus != null)
                                //    {
                                //        if (jobStatus.ProcessFlag)
                                //        {
                                //            MessageBox.Show("Cannot cancel this PO. This line was Job processed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //            return;
                                //        }
                                //    }
                                //}

                                line.CancelFlag = true;
                                line.LastUpdateDate = DateTime.Now;
                                line.LastUpdatedBy = _view.EpiSession.User.Id;
                                _repository.UpdatePOLine(line);
                                //Cancel PR Line
                                CancelPRByLine(line);

                                //Keep logs
                                KeepLogging("CANCEL PO LINE", line);

                                var lineLoc = _repository.GetLineLocationByPOLineID(line.PoLineId).FirstOrDefault();
                                lineLoc.QuantityCancelled = line.Quantity;
                                _repository.UpdatePoLineLocation(lineLoc);
                            }
                            catch
                            {
                            }
                        }

                        _view.poLine = _repository.GetPOLineByPOID(_view.poHead.PoHeaderId);
                        _view.BindingLines(_view.poLine);
                        CalculateLine();
                        _repository.UpdatePO(_view.poHead);

                        _repoProj.ProjectCost_Reset(resProj.ProjectId);
                        _view.projBudget = _repoProj.GetProjectCostByProjID(resProj.ProjectId);
                        _view.BindingBudgetLines(_view.projBudget);
                    }
                }
            }
        }

        private void KeepLogging(string action, POLineModel line)
        {
                    POLoggingModel log = new POLoggingModel();
                    log.LogingSource = "PURCHASING";
                    log.ActionSource = action;
                    log.ActionBy = _view.EpiSession.User.Id;
                    log.CreatedBy = _view.EpiSession.User.Id;
                    log.CreationDate = DateTime.Now;
                    log.LastUpdatedBy = _view.EpiSession.User.Id;
                    log.LastUpdateDate = DateTime.Now;
                    log.PoHeaderId = line.PoHeaderId;
                    log.PoLineId = line.PoLineId;
                    log.ActionDescription = string.Format("User : {0} cancel line [{1}]"
                        , _view.EpiSession.User.UserName
                        , line.PoLineNum);

                    _repReq.KeepLogging(log);

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to Cacel this PO.", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                POHeaderModel po = new POHeaderModel();
                po = _repository.GetPOByID(_view.poHead.PoHeaderId);

                //Get PO Lines to Update PO Status ***Not support multi PO in same Receive.
                List<POLineModel> poLines = _repository.GetPOLineByPOID(po.PoHeaderId);

                var result = poLines.GroupBy(x => x.ReceivedStatus)
                                 .Select(group => new { ReceivedStatus = group.Key, Items = group.ToList() })
                                 .ToList();

                if (result.Count() == 1)
                {
                    if (result.FirstOrDefault().ReceivedStatus == "Pending")
                    {
                        //Validate Job Process for PO Job Process
                        /*
                        if (po.JobFlag)
                        {
                            bool cancelAble = ValidateAbleCancelLines(_view.poLine);
                            if (!cancelAble)
                            {
                                MessageBox.Show("Cannot cancel this PO. Has some line was Job processed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }*/

                        po.StatusCode = "CLOSED";
                        po.CancelFlag = true;
                        _view.poHead = po;

                        if (CancelPOLines(_view.poLine))
                        {
                            CancelPRLines(po);
                            _repository.UpdatePO(po);

                            var resProj = _view.poLine.GroupBy(x => x.RefProjectId)
                                             .Select(group => new { ProjectId = group.Key, lines = group.ToList() })
                                             .FirstOrDefault();
                            _repoProj.ProjectCost_Reset(resProj.ProjectId);
                        }                         
                    }
                    else
                    {
                        MessageBox.Show("PO lines received status must pending all.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("PO lines received status must pending all.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private bool ValidateAbleCancelLines(List<POLineModel> poLine)
        {
            bool cancelAble = true;

            foreach (POLineModel item in poLine.OrderBy(o => o.PoLineId))
            {
                var jobStatus = _repoJob.GetExistingPO(item.PoLineId);
                if (jobStatus != null)
                {
                    if (jobStatus.ProcessFlag)
                    {
                        cancelAble = false;
                    }
                }
            }

            return cancelAble;
        }
        
        private void CancelPRByLine(POLineModel pol)
        {
            var reqLines = _repReq.GetLinesByPOID(pol.PoHeaderId);
            var req = reqLines.Where(x => x.PoLineId == pol.PoLineId).FirstOrDefault();

            req.RejectFlag = true;
            req.CancelFlag = true;
            req.RejectComment = "Cancel From PO.";
            req.LastUpdatedBy = _view.EpiSession.User.Id;
            req.LastUpdateDate = DateTime.Now;
            _repReq.UpdatePRLine(req);

            //var projCosts = _repoProj.GetProjectCostByProjID(req.RefProjectId).Where(x => x.CostCode == req.CostCode).FirstOrDefault();
            //if (projCosts != null)
            //{
            //    var budgetUsage = _repoProj.GetCostUsage(req.RefProjectNum, req.CostCode);
            //    projCosts.FcstCostAmount = budgetUsage;
            //    _repoProj.UpdateProjCost(projCosts);
            //}
          

            //Update Cancel flag in Requisition Header
            //var grpHeads = reqLines.GroupBy(item => item.RequisitionHeaderId)
            //          .Select(group => new { reqHead = group.Key, ReqLines = group.ToList() })
            //          .ToList();
            //foreach (var r in grpHeads)
            //{
            //    _repReq.UpdateCancelFlag(r.reqHead);
            //}
        }

        private void CancelPRLines(POHeaderModel po)
        {
            var reqLines = _repReq.GetLinesByPOID(po.PoHeaderId);
            if (reqLines != null)
            {
                foreach (var req in reqLines)
                {
                    req.RejectFlag = true;
                    req.CancelFlag = true;
                    req.RejectComment = "Cancel From PO.";
                    req.LastUpdatedBy = _view.EpiSession.User.Id;
                    req.LastUpdateDate = DateTime.Now;
                    _repReq.UpdatePRLine(req);

                    var projCosts = _repoProj.GetProjectCostByProjID(req.RefProjectId).Where(x => x.CostCode == req.CostCode).FirstOrDefault();
                    if (projCosts != null)
                    {
                        var budgetUsage = _repoProj.GetCostUsage(req.RefProjectNum, req.CostCode);
                        projCosts.FcstCostAmount = budgetUsage;
                        _repoProj.UpdateProjCost(projCosts);
                    }

                }

                //Update Cancel flag in Requisition Header
                var grpHeads = reqLines.GroupBy(item => item.RequisitionHeaderId)
                          .Select(group => new { reqHeaderId = group.Key, ReqLines = group.ToList() })
                          .ToList();
                foreach (var req in grpHeads)
                {
                    _repReq.UpdateCancelFlag(req.reqHeaderId);
                }
            }
        }

        private bool CancelPOLines(List<POLineModel> poLine)
        {
            bool result = true;

            foreach (POLineModel item in poLine.OrderBy(o => o.PoLineId))
            {
                try
                {
                    item.LastUpdatedBy = _view.EpiSession.User.Id;
                    item.LastUpdateDate = DateTime.Now;
                    item.CancelFlag = true;
                    _repository.UpdatePOLine(item);
                    KeepLogging("CANCEL PO LINE", item);
                }
                catch
                {
                    result = false;
                }
            }

            return result;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            _view.costs = _repoProj.GetCostGropAll();

            POHeaderModel po = new POHeaderModel();
            po = _repository.GetPOByID(_view.poHead.PoHeaderId);

            _view.poHead = po;
            _view.poLine = _repository.GetPOLineByPOID(po.PoHeaderId);
            _view.BindingLines(_view.poLine);
            CalculateLine();
        }

        private void GetLine_Selected(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;

            POLineModel line = new POLineModel();

            try
            {
                line = (POLineModel)grd.CurrentRow.DataBoundItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _view.poLineSelected = line;
        }

        private void Delete_Row(object sender, EventArgs e)
        {
            if(_view.poLineSelected != null && !_view.poHead.SubmitFlag)
            {
                MetroGrid grd = sender as MetroGrid;
                if(grd.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure to delete this Line.", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        var resProj = _view.poLine.GroupBy(x => x.RefProjectId)
                             .Select(group => new { ProjectId = group.Key, lines = group.ToList() })
                             .FirstOrDefault();
                        foreach (DataGridViewRow item in grd.SelectedRows)
                        {
                            try
                            {
                                POLineModel line = (POLineModel)item.DataBoundItem;
                                _repository.DeletePOLine(line);
                            }
                            catch
                            {
                            }
                        }
                        
                        _view.poLine = _repository.GetPOLineByPOID(_view.poHead.PoHeaderId);
                        _view.BindingLines(_view.poLine);
                        CalculateLine();

                        _repoProj.ProjectCost_Reset(resProj.ProjectId);
                        _view.projBudget = _repoProj.GetProjectCostByProjID(resProj.ProjectId);
                        _view.BindingBudgetLines(_view.projBudget);
                    }
                }

            }
        }

        private void UnSubmitPO_Click(object sender, EventArgs e)
        {
            if (!_view.poHead.ApprovedFlag)
            {
                POHeaderModel po = _view.poHead;
                DialogResult dialogResult = MessageBox.Show("Are you sure to Un-Submit this PO: " + po.PoNum, "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    po.SubmitFlag = false;
                    _repository.UpdatePO(po);
                    List<POLineModel> list = _view.poLine;
                    int rowNum = 1;
                    foreach (POLineModel item in list.OrderBy(o => o.PoLineId))
                    {
                        item.LastUpdatedBy = _view.EpiSession.User.Id;
                        item.LastUpdateDate = DateTime.Now;
                        item.PoLineNum = rowNum;
                        item.Status = "OPEN";

                        rowNum++;
                        _repository.UpdatePOLine(item);
                    }
                    _view.poLine = _repository.GetPOLineByPOID(_view.poHead.PoHeaderId);

                    _view.poHead = _repository.GetPOByID(po.PoHeaderId);
                }
            }
        }

        private void ValidateApproval(object sender, EventArgs e)
        {
            //MetroCheckBox chk = sender as MetroCheckBox;
            POHeaderModel po = _view.poHead;
            var pox = _repository.GetPOByID(po.PoHeaderId);
            if (po.ApprovedFlag && !pox.ApprovedFlag)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to Approve this PO: " + po.PoNum, "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (po.ApproverId != _view.EpiSession.User.Id)
                    {
                        MessageBox.Show("You are not allowed to approve this PO.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        po.ApprovedFlag = false;
                        _view.poHead = po;
                        return;
                    }

                    List<POLineModel> list = _view.poLine;
                    foreach (POLineModel item in list.OrderBy(o => o.PoLineId))
                    {
                        item.LastUpdatedBy = _view.EpiSession.User.Id;
                        item.LastUpdateDate = DateTime.Now;
                        item.Status = "APPROVED";

                        var itemMaster = _repoItem.GetItemByNumber(item.ItemCode);
                        if (itemMaster == null)
                        {
                            item.ItemId = AddItemMaster(item);
                        }
                        else
                        {
                            item.ItemId = itemMaster.InventoryItemId;

                            //Update Last unit price to Item master
                            itemMaster.CostPricePerUnit = item.UnitPrice;
                            itemMaster.PricePerUnit = item.UnitPrice;
                            _repoItem.UpdateItem(itemMaster);
                        }



                        #region Update Encumbrance
                        //Get Cost remaining balance.
                        var budgetCost = _repoProj.GetByProjectCost(item.RefProjectNum, item.CostCode);
                        double amount = 0;

                        if (item.CurrencyCode != "THB")
                        {
                            amount = item.ExtendedAmount * item.CurrencyRate;
                        }
                        else
                        {
                            amount = item.ExtendedAmount;
                        }

                        if (budgetCost.UfBudgetRemain >= amount)
                        {
                            //Set Encumbrance Flag/Amount for PR line.
                            item.EncumbranceFlag = true;
                            item.EncumbranceAmount = amount;
                        }
                        else
                        {
                            item.EncumbranceFlag = false;
                            item.EncumbranceAmount = 0;
                        }
                        #endregion

                        _repository.UpdatePOLine(item);

                        //if (po.JobFlag)
                        //{
                        //    New_Job(item);
                        //}
                    }
                    _view.poLine = _repository.GetPOLineByPOID(_view.poHead.PoHeaderId);

                    po.ApprovedFlag = true;
                    _repository.UpdatePO(po);

                    po = _repository.GetPOByID(po.PoHeaderId);
                    KeepLogging("APPROVE PURCHASING");
                }
                else
                {
                    po.ApprovedFlag = false;
                }

                _view.poHead = po;
            }
        }

        private void New_Job(POLineModel poline)
        {
            JobEntityModel job = new JobEntityModel();
            job.JobEntiryDate = DateTime.Now;
            job.OpenStatus = true;
            job.CancelFlag = false;
            job.ProcessFlag = false;
            job.CompletedFlag = false;
            job.CreatedBy = _view.EpiSession.User.Id;
            job.LastUpdatedBy = _view.EpiSession.User.Id;

            job.JobEntityName = _repoJob.GetNewJobNumber();  //Auto generate Job Number
            job.PrimaryItemCode = poline.ItemCode;
            job.PrimaryItemId = poline.ItemId;
            job.PrimaryItemModel = poline.BrandMaterail;
            job.PoHeaderId = poline.PoHeaderId;
            job.PoLineId = poline.PoLineId;
            job.Description = poline.ItemDescription;
            job.JobEntiryDate = DateTime.Now;
            job.PrimaryQuantity = poline.Quantity;

            //Insert Header Job Entity
            job.JobEntityId = _repoJob.InsertJob(job);

            //New Task
            JobTaskModel task = new JobTaskModel();
            task.LastUpdateDate = DateTime.Now;
            task.LastUpdatedBy = _view.EpiSession.User.Id;
            task.JobNumber = job.JobEntityName;
            task.TaskNumber = "1";
            task.Description = task.TaskNumber;

            task.JobId = job.JobEntityId;
            task.CreationDate = DateTime.Now;
            task.CreatedBy = _view.EpiSession.User.Id;
            _repoJob.InsertTask(task);

            //MessageBox.Show(string.Format("Auto create Job : {0} Completed. {1} For PO Line no. {2}"
            //            , job.JobEntityName
            //            , Environment.NewLine
            //            , poline.PoLineNum.ToString()), "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int AddItemMaster(POLineModel item)
        {
            ItemMasterModel master = new ItemMasterModel();
            master.EnabledFlag = true;
            master.Description = item.ItemDescription;
            master.Segment1 = item.ItemCode;
            master.Segment2 = item.Spec;
            master.Segment3 = item.BrandMaterail;
            master.PurchasingEnabledFlag = true;
            master.ShippableItemFlag = true;
            master.CustomerOrderEnabledFlag = true;
            master.InventoryItemFlag = true;
            master.StockEnabledFlag = true;
            master.CostingEnabledFlag = true;
            master.InvoiceEnabledFlag = true;
            master.CostPricePerUnit = item.UnitPrice;

            return _repoItem.InsertItem(master);
        }

        private void Type_Change(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            string type = cbo.Text;

            _view.ActiveJobFlag(type);
        }

        private void Print_PO(object sender, EventArgs e)
        {
            /*
            if(_view.poHead.SubmitFlag && !_view.poHead.ApprovedFlag)
            {
                using (ReportPreviewForm frm = new ReportPreviewForm())
                {
                    List<POReportModel> result = _repository.GetReportByID(_view.poHead.PoHeaderId);
                    string buyerImageUrl = "Orataix";// result.FirstOrDefault().BuyerSignature;
                    string approverImageUrl = "Pawonrat";// result.FirstOrDefault().ApproverSignature;
                    ReportDataSource ds = new ReportDataSource("POSET", result);
                    ReportViewer rpt = frm.reportViewer2;
                    rpt.Reset();

                    rpt.LocalReport.DataSources.Clear();
                    rpt.LocalReport.DataSources.Add(ds);
                    if (_view.poHead.ApprovedFlag)
                        rpt.LocalReport.ReportPath = "Reports/PO001.rdlc";
                    else if (!_view.poHead.ApprovedFlag)
                        rpt.LocalReport.ReportPath = "Reports/PO001_DRAFT.rdlc";

                    rpt.LocalReport.EnableExternalImages = true;
                    ReportParameter buyerImag = new ReportParameter("buyerSignImageUrl", string.IsNullOrEmpty(buyerImageUrl) ? "xx" : buyerImageUrl);
                    ReportParameter approverImag = new ReportParameter("approverSignImageUrl", string.IsNullOrEmpty(approverImageUrl) ? "xx" : approverImageUrl);
                    rpt.LocalReport.SetParameters(new ReportParameter[] { buyerImag, approverImag });
                    rpt.RefreshReport();

                    frm.ShowDialog();
                }
            }*/
          
            List<POReportModel> result = _repository.GetReportByID(_view.poHead.PoHeaderId);
            string buyerImageUrl = result.FirstOrDefault().BuyerSignature;
            string approverImageUrl = result.FirstOrDefault().ApproverSignature;

            ReportDataSource ds = new ReportDataSource("POSET", result);
            ReportViewer rpt = new ReportViewer();

            rpt.Reset();
            rpt.LocalReport.DataSources.Clear();
            rpt.LocalReport.DataSources.Add(ds);
            if (_view.poHead.ApprovedFlag && _view.poHead.CurrencyCode == "THB")
                rpt.LocalReport.ReportPath = "Reports/PO001_THB.rdlc";
            else if (!_view.poHead.ApprovedFlag && _view.poHead.CurrencyCode == "THB")
                rpt.LocalReport.ReportPath = "Reports/PO001_DRAFT_THB.rdlc";
            else if (_view.poHead.ApprovedFlag && _view.poHead.CurrencyCode != "THB")
                rpt.LocalReport.ReportPath = "Reports/PO001.rdlc";
            else if (!_view.poHead.ApprovedFlag && _view.poHead.CurrencyCode != "THB")
                rpt.LocalReport.ReportPath = "Reports/PO001_DRAFT.rdlc";

            rpt.LocalReport.EnableExternalImages = true;
            ReportParameter buyerImag = new ReportParameter("buyerSignImageUrl", buyerImageUrl);
            ReportParameter approverImag = new ReportParameter("approverSignImageUrl", approverImageUrl);
            rpt.LocalReport.SetParameters(new ReportParameter[] { buyerImag, approverImag });
            rpt.RefreshReport();

            //frm.ShowDialog();

            if (_view.poHead.ApprovedFlag)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "PDF File|*.pdf";
                saveFileDialog1.Title = "Save an Image File";
                saveFileDialog1.FileName = _view.poHead.PoNum + ".PDF";
                //saveFileDialog1.ShowDialog();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FileName != "")
                    {
                        ProcessFile(saveFileDialog1.FileName, rpt);
                    }
                }
            }
            else
            {
                string subPath = Application.StartupPath + "\\Outputs\\" + DateTime.Now.ToString("ddMMyyyy");
                string fileName = string.Empty;

                bool exists = System.IO.Directory.Exists(subPath);

                if (!exists)
                    System.IO.Directory.CreateDirectory(subPath);

                fileName = subPath + "\\" + _view.poHead.PoNum + "_draft.PDF";

                ProcessFile(fileName, rpt);
            }         
        }

        private void ProcessFile(string fileName, ReportViewer rpt)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = rpt.LocalReport.Render(
                            "PDF", null, out mimeType, out encoding, out filenameExtension,
                            out streamids, out warnings);
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    ProcessStartInfo startInfo = new ProcessStartInfo(fileName);
                    Process.Start(startInfo);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void SubmitPO_Click(object sender, EventArgs e)
        {
            if (!_view.poHead.ApprovedFlag)
            {
                POHeaderModel po = _view.poHead;
                DialogResult dialogResult = MessageBox.Show("Are you sure to Submit this PO: " + po.PoNum, "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var dupplicateCount = _view.poLine.Where(x => x.DupplicateFlag).ToList();
                    if (dupplicateCount.Count > 0)
                    {
                        MessageBox.Show("Has some line is invalid. Cannot to submit PO.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    po.SubmitFlag = true;
                    _repository.UpdatePO(po);
                    List<POLineModel> list = _view.poLine;
                    int rowNum = 1;
                    foreach (POLineModel item in list.OrderBy(o => o.PoLineId))
                    {
                        item.LastUpdatedBy = _view.EpiSession.User.Id;
                        item.LastUpdateDate = DateTime.Now;
                        item.PoLineNum = rowNum;
                        item.Status = "SUBMITTED";

                        #region Update Encumbrance
                        //Get Cost remaining balance.
                        var budgetCost = _repoProj.GetByProjectCost(item.RefProjectNum, item.CostCode);
                        double amount = 0;

                        if (item.CurrencyCode != "THB")
                        {
                            amount = item.ExtendedAmount * item.CurrencyRate;
                        }
                        else
                        {
                            amount = item.ExtendedAmount;
                        }

                        if (budgetCost.UfBudgetRemain >= amount)
                        {
                            //Set Encumbrance Flag/Amount for PR line.
                            item.EncumbranceFlag = true;
                            item.EncumbranceAmount = amount;
                        }
                        else
                        {
                            item.EncumbranceFlag = false;
                            item.EncumbranceAmount = 0;
                        }
                        #endregion

                        rowNum++;
                        _repository.UpdatePOLine(item);
                    }
                    _view.poLine = _repository.GetPOLineByPOID(_view.poHead.PoHeaderId);

                    _view.poHead = _repository.GetPOByID(po.PoHeaderId);
                    KeepLogging("SUBMIT PURCHASING");
                }
            }
        }

        private void KeepLogging(string action)
        {
            bool overBudget = false;
            string lineNotPass = string.Empty;

            if (_view.poLine.Count > 0)
            {
                foreach (var curr in _view.poLine)
                {
                    var prjCosts = _repoProj.GetByProjectCost(curr.RefProjectNum, curr.CostCode);

                    if (prjCosts.RemainPercentage <= 0)
                    {
                        lineNotPass = lineNotPass + (string.IsNullOrEmpty(lineNotPass) ? "" : ", ")
                            + curr.PoLineNum.ToString() + " Cost Code : " + curr.CostCode;
                        overBudget = true;
                    }
                }

                if (overBudget)
                {
                    POLoggingModel log = new POLoggingModel();
                    log.LogingSource = "PURCHASING";
                    log.ActionSource = action;
                    log.ActionBy = _view.EpiSession.User.Id;
                    log.CreatedBy = _view.EpiSession.User.Id;
                    log.CreationDate = DateTime.Now;
                    log.LastUpdatedBy = _view.EpiSession.User.Id;
                    log.LastUpdateDate = DateTime.Now;
                    log.PoHeaderId = _view.poHead.PoHeaderId;
                    log.ActionDescription = string.Format("PO No. {0} /Over budget in lines [{1}]"
                        , _view.poHead.PoNum
                        , lineNotPass);

                    _repReq.KeepLogging(log);
                }
            }
        }

        private void Save_Lines()
        {
            try
            {
                if (_view.poLine != null)
                {
                    if(_view.poLine.Count > 0)
                    {
                        List<POLineModel> list = _view.poLine;
                        foreach (POLineModel item in list)
                        {
                            item.PoHeaderId = _view.poHead.PoHeaderId;
                            item.LastUpdatedBy = _view.EpiSession.User.Id;
                            item.CreatedBy = _view.EpiSession.User.Id;
                            item.LastUpdateDate = DateTime.Now;
                            item.CreationDate = DateTime.Now;
                            item.Status = "OPEN";
                            item.CurrencyCode = _view.poHead.CurrencyCode;
                            item.CurrencyRate = _view.poHead.Rate;
                               
                            //Get Cost remaining balance.
                            var budgetCost = _repoProj.GetByProjectCost(item.RefProjectNum, item.CostCode);
                            double amount = 0;

                            if (item.CurrencyCode != "THB")
                            {
                                amount = item.ExtendedAmount * item.CurrencyRate;
                            }
                            else
                            {
                                amount = item.ExtendedAmount;
                            }

                            if (budgetCost.UfBudgetRemain >= amount)
                            {
                                //Set Encumbrance Flag/Amount for PR line.
                                item.EncumbranceFlag = true;
                                item.EncumbranceAmount = amount;
                            }
                            else
                            {
                                item.EncumbranceFlag = false;
                                item.EncumbranceAmount = 0;
                            }

                            if (item.PoLineId == 0)
                                _repository.InsertPOLine(item);
                            else
                                _repository.UpdatePOLine(item);
                        }

                        var resProj = list.GroupBy(x => x.RefProjectId)
                                         .Select(group => new { ProjectId = group.Key, lines = group.ToList() })
                                         .FirstOrDefault();
                        _repoProj.ProjectCost_Reset(resProj.ProjectId);

                        _view.poLine = _repository.GetPOLineByPOID(_view.poHead.PoHeaderId);
                        _view.BindingLines(_view.poLine);
                        CalculateLine();

                        _view.projBudget = _repoProj.GetProjectCostByProjID(resProj.ProjectId);
                        _view.BindingBudgetLines(_view.projBudget);
                        //MessageBox.Show("Save PO lines is Completed.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PO Lines is Error! " + Environment.NewLine
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveApproved_Lines()
        {
            try
            {
                if (_view.poLine != null)
                {
                    if (_view.poLine.Count > 0)
                    {
                        List<POLineModel> list = _view.poLine;
                        foreach (POLineModel item in list)
                        {
                            var line = _repository.GetPOLineByID(item.PoLineId);

                            line.DueDate = item.DueDate;
                            line.LastUpdatedBy = _view.EpiSession.User.Id;
                            line.LastUpdateDate = DateTime.Now;

                            _repository.UpdatePOLine(line);
                        }

                        _view.poLine = _repository.GetPOLineByPOID(_view.poHead.PoHeaderId);
                        _view.BindingLines(_view.poLine);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PO Lines is Error! " + Environment.NewLine
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateLine()
        {
            POHeaderModel po = _view.poHead;
            po.SubTotal = _view.poLine.Where(x => x.CancelFlag == false).Sum(x => x.ExtendedAmount);

            _view.poHead = po;
        }

        private void Paste_Rows(object sender, EventArgs e)
        {
            if (_view.poHead.PoHeaderId != 0)
            {
                if (string.IsNullOrEmpty(_view.poHead.ProjectNum))
                {
                    MessageBox.Show("Please select default Project No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!string.IsNullOrEmpty(_view.poHead.ProjectNum))
                {
                    ProjectModel prj = _repoProj.GetProjectByNumber(_view.poHead.ProjectNum);
                    if (prj != null)
                        _view.poHead.ProjectId = prj.Id;
                    else
                    {
                        MessageBox.Show("Project No. : " + _view.poHead.ProjectNum +" dose not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                DataObject o = (DataObject)Clipboard.GetDataObject();
                if (o.GetDataPresent(DataFormats.Text))
                {
                    List<POLineModel> lines = _view.poLine;
                    List<POLineModel> list = new List<POLineModel>();

                    //string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                    string[] pastedRows = Regex.Split(o.GetText().ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");

                    if (_view.poHead.TypeLookupCode == "STANDARD")
                    {
                        list = AddLineStandard(pastedRows);
                    }
                    else if (_view.poHead.TypeLookupCode == "MAKING")
                    {
                        list = AddLineMaking(pastedRows);
                    }
                    else
                    {
                        MessageBox.Show("Please select PO Type.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    _view.poLine = lines.Concat(list).ToList();
                    _view.BindingLines(_view.poLine);
                    CalculateLine();
                }
            }
            else
            {
                MessageBox.Show("Purchase Order is null! please select Purchase Order.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private List<POLineModel> AddLineMaking(string[] pastedRows)
        {
            List<POLineModel> lines = new List<POLineModel>();
            foreach (string pastedRow in pastedRows)
            {
                POLineModel line = new POLineModel();
                string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });
                bool valid = true;
                for (int i = 0; i < pastedRowCells.Length; i++)
                {
                    line.RefProjectId = _view.poHead.ProjectId;
                    line.RefProjectNum = _view.poHead.ProjectNum;
                    line.LineType = _view.poHead.TypeLookupCode;
                    line.Uom = "PCS";

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
                                    line.ItemId = item.InventoryItemId;                               
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

                        case 5:
                            line.CostCode = pastedRowCells[i];
                            if (!ValidCostGroup(line.CostCode))
                            {
                                MessageBox.Show("Cost Code : " + line.CostCode + " dose not existing.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                valid = false;
                            }
                            else
                            {
                                CostGroupModel cost = _view.costs.Where(x => x.CostCode == line.CostCode).FirstOrDefault();
                                if (_view.poHead.JobFlag && !cost.MakingFlag)
                                {
                                    MessageBox.Show("Cost Code : " + line.CostCode + " dose not making job.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    valid = false;
                                }
                                //else if (!_view.poHead.JobFlag && cost.MakingFlag)
                                //{
                                //    MessageBox.Show("Cost Code : " + line.CostCode + " dose making job.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    valid = false;
                                //}
                            }
                            break;

                        case 6:
                            line.BOM = pastedRowCells[i];
                            break;

                        case 7:
                            line.Suplier = pastedRowCells[i];
                            break;

                        case 8:
                            line.UnitPrice = InvalidNumber(string.IsNullOrEmpty(pastedRowCells[i]) ? "0" : pastedRowCells[i]);
                            if (_view.poHead.CurrencyCode == "THB")
                                line.BaseUnitPrice = line.UnitPrice;
                            break;

                        case 9:
                            line.DueDate = string.IsNullOrEmpty(pastedRowCells[i]) ? null : ValidateDateFormat(pastedRowCells[i]);
                            break;

                        case 10:
                            line.ECN = pastedRowCells[i];
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

        private List<POLineModel> AddLineStandard(string[] pastedRows)
        {
            List<POLineModel> lines = new List<POLineModel>();

            foreach (string pastedRow in pastedRows)
            {
                POLineModel line = new POLineModel();
                bool itemExist = false;
                line.DupplicateFlag = false;
                string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });
                bool valid = true;
                for (int i = 0; i < pastedRowCells.Length; i++)
                {                    
                    line.RefProjectId = _view.poHead.ProjectId;
                    line.RefProjectNum = _view.poHead.ProjectNum;
                    line.LineType = _view.poHead.TypeLookupCode;
                    line.Uom = "PCS";

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
                                    line.ItemId = item.InventoryItemId;
                                    line.ItemDescription = item.Description;
                                    line.Spec = item.Segment2;
                                    line.BrandMaterail = item.Segment3;
                                    //line.UnitPrice = item.CostPricePerUnit;
                                    line.Uom = item.PrimaryUomCode;
                                }
                                else
                                {
                                    //lines.Concat(list).ToList()
                                    var itemTemp = _view.poLine.Concat(lines).Where(x => x.ItemCode == line.ItemCode).FirstOrDefault();
                                    if (itemTemp != null)
                                    {
                                        if ((string.IsNullOrEmpty(pastedRowCells[4]) ? "" : pastedRowCells[4]).Trim() != (string.IsNullOrEmpty(itemTemp.Spec) ? "" : itemTemp.Spec).Trim())
                                        {
                                            line.DupplicateFlag = true;
                                            line.LineErrorMessage = "Item Code is dupplicated in same PO. But MANU ID dose not matching.";
                                        }
                                        else
                                        {
                                            line.LineErrorMessage = "";
                                        }

                                        itemExist = true;
                                        line.ItemId = itemTemp.ItemId;
                                        line.ItemDescription = itemTemp.ItemDescription;
                                        line.Spec = itemTemp.Spec;
                                        line.BrandMaterail = itemTemp.BrandMaterail;
                                        line.BaseUnitPrice = itemTemp.BaseUnitPrice;
                                        line.UnitPrice = itemTemp.UnitPrice;
                                        line.Uom = itemTemp.Uom;
                                    }
                                }
                            }
                            break;

                        case 2:
                            line.Quantity = InvalidNumber(string.IsNullOrEmpty(pastedRowCells[i]) ? "0" : pastedRowCells[i]);
                            break;

                        case 3:
                            if (!itemExist)
                                line.ItemDescription = pastedRowCells[i];
                            break;

                        case 4:
                            if (!itemExist)
                            {
                                line.Spec = pastedRowCells[i];                            
                                if (!string.IsNullOrEmpty(line.Spec))
                                {
                                    var item = _repoItem.GetItemByManuId(line.Spec.Trim());
                                    if (item != null)
                                    {
                                        //if (line.ItemCode.Trim() != item.Segment1.Trim())
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

                                        itemExist = true;
                                        line.ItemId = item.InventoryItemId;
                                        line.ItemCode = item.Segment1;
                                        line.ItemDescription = item.Description;
                                        line.BrandMaterail = item.Segment3;
                                        line.UnitPrice = item.CostPricePerUnit;
                                        line.BaseUnitPrice = line.UnitPrice;
                                        line.BaseUnitPrice = item.CostPricePerUnit;
                                        line.UnitPrice = item.CostPricePerUnit * _view.poHead.Rate;
                                        line.Uom = item.PrimaryUomCode;
                                    }
                                    else
                                    {
                                        var itemTemp = _view.poLine.Concat(lines).Where(x => x.Spec == line.Spec).FirstOrDefault();
                                        if (itemTemp != null)
                                        {
                                            //if (line.ItemCode.Trim() != itemTemp.ItemCode.Trim())
                                            if ((string.IsNullOrEmpty(line.ItemCode) ? "" : line.ItemCode).Trim() != (string.IsNullOrEmpty(itemTemp.ItemCode) ? "" : itemTemp.ItemCode).Trim())
                                            {
                                                line.DupplicateFlag = true;
                                                line.LineErrorMessage = "MANU ID is dupplicated in same PO. But Item Code dose not matching.";
                                            }
                                            else
                                            {
                                                line.LineErrorMessage = "";
                                            }

                                            itemExist = true;
                                            line.ItemId = itemTemp.ItemId;
                                            line.ItemCode = itemTemp.ItemCode;
                                            line.ItemDescription = itemTemp.ItemDescription;
                                            line.Spec = itemTemp.Spec;
                                            line.BrandMaterail = itemTemp.BrandMaterail;                                                
                                            line.BaseUnitPrice = itemTemp.BaseUnitPrice;
                                            line.UnitPrice = itemTemp.UnitPrice;
                                            line.Uom = itemTemp.Uom;
                                        }
                                    }
                                }       
                            }                                
                            break;

                        case 5:
                            if (!itemExist)
                                line.BrandMaterail = pastedRowCells[i];
                            break;

                        case 6:
                            line.CostCode = pastedRowCells[i];
                            if (!ValidCostGroup(line.CostCode))
                            {
                                MessageBox.Show("Cost Code : " + line.CostCode + " dose not existing.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                valid = false;
                            }
                            else
                            {
                                CostGroupModel cost = _view.costs.Where(x => x.CostCode == line.CostCode).FirstOrDefault();
                                if (_view.poHead.JobFlag && !cost.MakingFlag)
                                {
                                    MessageBox.Show("Cost Code : " + line.CostCode + " dose not making job.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    valid = false;
                                }
                                //else if (!_view.poHead.JobFlag && cost.MakingFlag)
                                //{
                                //    MessageBox.Show("Cost Code : " + line.CostCode + " dose making job.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    valid = false;
                                //}
                            }
                            break;

                        case 7:
                            line.BOM = pastedRowCells[i];
                            break;

                        case 8:
                            line.Suplier = pastedRowCells[i];
                            break;

                        case 9:
                            //if (!itemExist)
                            line.UnitPrice = InvalidNumber(string.IsNullOrEmpty(pastedRowCells[i]) ? "0.00" : pastedRowCells[i]);
                            if (_view.poHead.CurrencyCode == "THB")
                                line.BaseUnitPrice = line.UnitPrice;
                            break;

                        case 10:
                            line.DueDate = string.IsNullOrEmpty(pastedRowCells[i]) ? null : ValidateDateFormat(pastedRowCells[i]);
                            break;

                        case 11:
                            line.CSR = pastedRowCells[i];
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

        private bool ValidCostGroup(string costCode)
        {
            CostGroupModel result = _view.costs.Where(x => x.CostCode == costCode).FirstOrDefault();
            if (result != null)
                return true;
            else
                return false;
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

        private double InvalidNumber(string number)
        {
            double myDouble;
            bool isNumerical = double.TryParse(number, out myDouble);
            return myDouble;
        }

        private void Seleted_PO(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            DataGridViewCellValidatingEventArgs erg = e as DataGridViewCellValidatingEventArgs;
            POHeaderModel po = new POHeaderModel();
            int id = Convert.ToInt32(grid.CurrentRow.Cells[0].Value);

            po = _repository.GetPOByID(id);

            _view.poHead = po;
            _view.poLine = _repository.GetPOLineByPOID(id);
            _view.BindingLines(_view.poLine);

            //int projId = poLine.
            if(_view.poLine.Count > 0)
            {
                var resProj = _view.poLine.GroupBy(x => x.RefProjectId)
                     .Select(group => new { ProjectId = group.Key, lines = group.ToList() })
                     .FirstOrDefault();

                _view.projBudget = _repoProj.GetProjectCostByProjID(resProj.ProjectId);
                _view.BindingBudgetLines(_view.projBudget);
            }
        }

        private void Find_Project(object sender, EventArgs e)
        {
            using (ProjectListForm frm = new ProjectListForm())
            {
                frm.projectNum = _view.poHead.ProjectNum;
                frm.ShowDialog();
                if (frm.projSelected != null)
                {
                    POHeaderModel po = _view.poHead;
                    po.ProjectId = frm.projSelected.FirstOrDefault().Id;
                    po.ProjectNum = frm.projSelected.FirstOrDefault().ProjectNum;

                    _view.poHead = po;
                }
            }
        }

        private void Find_TaxCode(object sender, EventArgs e)
        {
            using (TaxCodeListForm frm = new TaxCodeListForm())
            {
                frm.taxCode = _view.poHead.TaxCode;
                frm.ShowDialog();
                if (frm.taxSelected != null)
                {
                    POHeaderModel po = _view.poHead;
                    po.TaxCode = frm.taxSelected.TaxCode;
                    po.TaxRate = frm.taxSelected.TaxRate;
                    
                    _view.poHead = po;
                    CalculateLine();
                }
            }
        }

        private void Find_Currency(object sender, EventArgs e)
        {
            if (!_view.poHead.SubmitFlag)
            {
                string oldCurrency = _view.poHead.CurrencyCode;

                using (CurrencyListForm frm = new CurrencyListForm())
                {
                    frm.currencyCode = _view.poHead.CurrencyCode;
                    frm.ShowDialog();
                    if (frm.currSelected != null)
                    {
                        POHeaderModel po = _view.poHead;
                        po.CurrencyCode = frm.currSelected.CurrencyCode;
                        var rate = _repository.GetCurrencyByCode(po.CurrencyCode);
                        po.Rate = rate.ConversionRate;
                        po.RateDate = rate.ConversionDate;

                        _view.poHead = po;
                        //_view.poLine = _repository.GetPOLineByPOID(po.PoHeaderId);
                        //_view.BindingLines(_view.poLine);
                    }
                }
            }
        }

        private void Find_Term(object sender, EventArgs e)
        {
            using (TermListForm frm = new TermListForm())
            {
                frm.TermCode = _view.poHead.TermCode;
                frm.ShowDialog();
                if (frm.termSelected != null)
                {
                    POHeaderModel po = _view.poHead;
                    po.TermId = frm.termSelected.TermId;
                    po.TermCode = frm.termSelected.TermCode;
                    po.TermDesc = frm.termSelected.Description;

                    _view.poHead = po;
                }
            }
        }

        private void Find_Vendor(object sender, EventArgs e)
        {
            using (VendorListForm frm = new VendorListForm())
            {
                frm.VendorNumber = _view.poHead.VendorNum;
                frm.ShowDialog();
                if (frm.vendorSelected != null)
                {
                    POHeaderModel po = _view.poHead;
                    po.VendorId = frm.vendorSelected.VendorId;
                    po.VendorNum = frm.vendorSelected.VendorNumber;
                    po.VendorName = frm.vendorSelected.VendorName;

                    //Default Term by Vendor
                    if (!string.IsNullOrEmpty(frm.vendorSelected.TermCode))
                    {
                        TermModel term = _repoPay.GetTermByCode(frm.vendorSelected.TermCode);
                        if(term != null)
                        {
                            po.TermId = term.TermId;
                            po.TermCode = term.TermCode;
                            po.TermDesc = term.Description;
                        }
                    }

                    //Default Term by Currency
                    if (!string.IsNullOrEmpty(frm.vendorSelected.InvoiceCurrencyCode))
                    {
                        //CurrencyModel curr = _repository.GetCurrencies().Where(x => x.CurrencyCode == frm.vendorSelected.InvoiceCurrencyCode).FirstOrDefault();
                        CurrencyModel curr = _repository.GetCurrencyByCode(frm.vendorSelected.InvoiceCurrencyCode);
                        if (curr != null)
                        {
                            po.CurrencyCode = curr.CurrencyCode;
                            po.Rate = curr.ConversionRate;
                            po.RateDate = curr.ConversionDate;
                        }
                    }

                    //Default Term by Tax
                    if (!string.IsNullOrEmpty(frm.vendorSelected.VatCode))
                    {
                        TaxCodeModel tax = _repository.GetTaxCodes().Where(x => x.TaxCode == frm.vendorSelected.VatCode).FirstOrDefault();
                        if (tax != null)
                        {
                            po.TaxCode = tax.TaxCode;
                            po.TaxRate = tax.TaxRate;
                        }
                    }

                    _view.poHead = po;
                }
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            POHeaderModel po = new POHeaderModel();
            po.PODate = DateTime.Now;
            po.StatusCode = "OPEN";
            po.TypeLookupCode = "STANDARD";
            po.BuyerId = _view.EpiSession.User.Id;
            po.BuyerName = _view.EpiSession.User.UserName;

            _view.poHead = po;
            _view.poLine = new List<POLineModel>();
            _view.BindingLines(_view.poLine);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            CalculateLine();
            POHeaderModel po = _view.poHead;
            po.LastUpdatedBy = _view.EpiSession.User.Id;
            string typeLookup = string.Empty;
            //if (!po.SubmitFlag)
            //{
                if (po.VendorId == 0)
                {
                    MessageBox.Show("Vendor is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (po.TermId == 0)
                {
                    MessageBox.Show("Term is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(po.CurrencyCode))
                {
                    MessageBox.Show("Currency is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(po.TaxCode))
                {
                    MessageBox.Show("Tax Code is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //po.Remarks = _view.GetNote();
                var approver = _repoUser.GetByID(po.BuyerId);
                if(approver != null && !po.ApprovedFlag)
                {
                    po.ApproverId = approver.ApproverId;
                }

                if (po.PoHeaderId == 0)
                {
                    if (po.TypeLookupCode == "STANDARD")
                        typeLookup = "PURCHASE_PO";
                    else if (po.TypeLookupCode == "MAKING")
                    {
                        if (po.JobFlag)
                            typeLookup = "PURCHASE_PD";
                        else
                            typeLookup = "PURCHASE_PO";
                    }

                    po.PoNum = _repository.GetDocNoByType(typeLookup);
                    po.CreatedBy = _view.EpiSession.User.Id;
                    po.LastUpdatedBy = _view.EpiSession.User.Id;
                    po.PoHeaderId = _repository.InsertPO(po);
                }
                else
                {
                //po.Discount = _view.poDiscount;
                //po.Freight = _view.poFreight;
                    ValidateApproval(null, null);
                    _repository.UpdatePO(po);
                    if(!po.SubmitFlag)
                        Save_Lines();

                    if (po.ApprovedFlag)
                        SaveApproved_Lines();

                }
            //}
            //else
            //{
            //    MessageBox.Show("This PO was submited cannot save your change.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            MessageBox.Show("Save Completed.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _view.poHead = _repository.GetPOByID(po.PoHeaderId);
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            using (POListForm frm = new POListForm(null))
            {
                frm.startDate = DateTime.Now;
                frm.endDate = DateTime.Now;
                frm.ShowDialog();
                if (frm.posSelected != null)
                {
                    _view.poList = frm.posSelected;
                    _view.BindingPO(_view.poList);
                }
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if(_view.poHead != null)
            {
                List<POHeaderModel> list = new List<POHeaderModel>();
                list.Add(_view.poHead);
                _view.poList = list;
            }
            else
            {
                New_Click(null, null);
                _view.poList = new List<POHeaderModel>();
                _view.poLine = new List<POLineModel>();
            }

            _view.costs = _repoProj.GetCostGropAll();

            _view.BindingPO(_view.poList);
            _view.BindingLines(_view.poLine);
        }
    }
}