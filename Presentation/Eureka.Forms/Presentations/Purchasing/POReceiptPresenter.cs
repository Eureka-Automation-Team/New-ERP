using Eureka.Core.Domain.Inventory;
using Eureka.Core.Domain.Projects;
using Eureka.Core.Domain.Purchasing;
using Eureka.Froms.Views.Controls;
using Eureka.Froms.Views.Payables;
using Eureka.Froms.Views.Purchasing;
using Eureka.Services.Inventory;
using Eureka.Services.Projects;
using Eureka.Services.Purchasing;
using MetroFramework.Controls;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Purchasing
{
    public class POReceiptPresenter
    {
        private readonly IPOReceiptView _view;
        private readonly IPOReceiptSrv _repository;

        private readonly IProjectSrv _repoProj;
        private readonly IPurchasingSrv _repoPurchase;
        private readonly IItemTransactionSrv _repoTrans;
        private readonly IItemOnhandSrv _repoOnhand;
        private readonly IItemMasterSrv _repoItem;

        public POReceiptPresenter(IPOReceiptView view)
        {
            _view = view;
            _repository = new POReceiptSrv();
            _repoProj = new ProjectSrv();
            _repoPurchase = new PurchasingSrv();
            _repoTrans = new ItemTransactionSrv();
            _repoOnhand = new ItemOnhandSrv();
            _repoItem = new ItemMasterSrv();

            _view.Form_Load += Form_Load;
            _view.Filter_Click += Filter_Click;
            _view.New_Click += New_Click;
            _view.Find_Vendor += Find_Vendor;
            _view.Save_Click += Save_Click;
            _view.GenerateGRN += GenerateGRN;
            _view.GetPO += GetPO;
            _view.Seleted_RCV += Seleted_RCV;
            //_view.Refresh_Click += Refresh_Click;
            _view.Seleted_Line += Seleted_Line;
            _view.Confirm_QC += Confirm_QC;
            _view.Received_Click += Received_Click;
            _view.Delete_Row += Delete_Row;
            _view.Test_Object += Test_Object;
            _view.Print_Received += Print_Received;
            _view.Method_Change += Method_Change;
            _view.Get_GRN += Get_GRN;
        }

        private void Get_GRN(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_view.headSeleted.VendorCode))
            {
                POReceiptHeaderModel h = _view.headSeleted;
                POReceiptHeaderModel rcvHead = null;
                if (!string.IsNullOrEmpty(_view.grnFileter))
                {
                    var head =_repository.GetReceiptHeaderByNumber(_view.grnFileter);
                    if(_view.headSeleted.VendorCode == head.VendorCode)
                    {
                        rcvHead = head;
                    }
                    else
                    {
                        MessageBox.Show("Vendor not match with header.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (rcvHead != null)
                {
                    _view.rcvLines = _repository.GetRcvLineByHeaderID(rcvHead.ReceiptHeaderId);
                }
                else
                {
                    List<POReceiptHeaderModel> list = _repository.GetRcvHeaderByDate(DateTime.Now.AddDays(-30), DateTime.Now)
                                                                 .Where(x => x.ReceivedFlag
                                                                 && x.VendorCode == _view.headSeleted.VendorCode
                                                                 && x.ReceiptMethod == "RECEIVE").ToList();
                    using (POReceiptListForm frm = new POReceiptListForm(list))
                    {
                        frm.startDate = DateTime.Now;
                        frm.endDate = DateTime.Now;
                        frm.rcvMethod = "RECEIVE";
                        frm.ShowDialog();
                        if (frm.rcvsSelected != null)
                        {
                            var head = frm.rcvsSelected.FirstOrDefault();
                            if (_view.headSeleted.VendorCode == head.VendorCode)
                            {
                                rcvHead = head;
                                _view.rcvLines = _repository.GetRcvLineByHeaderID(rcvHead.ReceiptHeaderId);
                            }
                            else
                            {
                                MessageBox.Show("Vendor not match with header.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }                                              
                        }
                    }
                } 

                if (_view.rcvLines != null)
                {
                    _view.rcvLines.ToList().ForEach(c => c.QuantityShipped = 0);
                    h.InvoiceNum = rcvHead.InvoiceNum;
                    h.Attribute1 = rcvHead.ReceiptHeaderId.ToString();
                    h.Attribute2 = rcvHead.ReceiptNum;
                    h.SourceType = rcvHead.SourceType;
                    _view.BindingRcvLines(_view.rcvLines);
                    _view.headSeleted = h;
                }
            }
            else
            {
                MessageBox.Show("Please select Vendor!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Method_Change(object sender, EventArgs e)
        {
            MetroComboBox cbo = sender as MetroComboBox;
            POReceiptHeaderModel rcv = _view.headSeleted;
            rcv.ReceiptMethod = cbo.Text;

            _view.headSeleted = rcv;
        }

        private void Print_Received(object sender, EventArgs e)
        {
            List<RcvReportModel> result = _repository.GetReceiveReport(_view.headSeleted.ReceiptNum, _view.headSeleted.ReceiptNum);
            //List<RcvReportModel> result = _repository.GetReceiveReport("190731-0018", "190731-0019");
            ReportDataSource ds = new ReportDataSource("POR001", result);
            ReportViewer rpt = new ReportViewer();
            rpt.Reset();
            rpt.LocalReport.DataSources.Clear();
            rpt.LocalReport.DataSources.Add(ds);
            rpt.LocalReport.ReportPath = "Reports/POR001.rdlc";
            rpt.RefreshReport();

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = rpt.LocalReport.Render(
                "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF File|*.pdf";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.FileName = _view.headSeleted.ReceiptNum + ".PDF";
            //saveFileDialog1.ShowDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {                
                    using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                        ProcessStartInfo startInfo = new ProcessStartInfo(saveFileDialog1.FileName);
                        Process.Start(startInfo);
                    }
                }

            }            
        }

        private void Test_Object(object sender, EventArgs e)
        {
            string lotNo = _repoItem.GetRunningLotByItemID(7);
        }

        private void Delete_Row(object sender, EventArgs e)
        {
            if (!_view.headSeleted.ReceivedFlag)
            {
                if(_view.lineSeleted != null)
                {
                    _repository.DeleteRcvLine(_view.lineSeleted);
                    _view.rcvLines = _repository.GetRcvLineByHeaderID(_view.headSeleted.ReceiptHeaderId);
                    _view.BindingRcvLines(_view.rcvLines);
                }                
            }
            else
            {
                MessageBox.Show("Cannot delete this line.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Received_Click(object sender, EventArgs e)
        {
            POReceiptHeaderModel head = _view.headSeleted;

            if (!string.IsNullOrEmpty(head.ReceiptNum))
            {                
                if (head.QCInspectionFlag && head.ReceiptMethod == "RECEIVE")
                {
                    if (head.InspectionStatus.Trim() != "PASS ALL")
                    {
                        MessageBox.Show("QC Inspection status is not PASS. Cannot Received.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                IEnumerable<POReceiptLineModel> lines = _view.rcvLines;
                if (lines.Count() > 0)
                {
                    if (ValidateLines(lines))
                    {
                        if(head.ReceiptMethod == "RETURN")
                        {
                            lines = GenerateReturnLines(lines);
                        }

                        if(head.ReceiptMethod == "RECEIVE")
                            lines = GenerateLotNumber(lines);

                        GeneratePOLocation(lines);
                        if (GenerateTransaction(lines))
                        {
                            ConfirmPOLocation(lines);

                            head.ReceivedFlag = true;
                            _repository.UpdateRcvHead(head);
                            UpdateReceivedLines(lines);
                            MessageBox.Show("Received process completed.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

            _view.headSeleted = head;
        }

        private IEnumerable<POReceiptLineModel> GenerateReturnLines(IEnumerable<POReceiptLineModel> lines)
        {
            foreach (var recLine in lines.Where(x => x.QuantityShipped < 0))
            {
                recLine.QcRequireInspcFlag = false;
                recLine.ReceiptHeaderId = _view.headSeleted.ReceiptHeaderId;

                int id = _repository.InsertRcvLine(recLine);
            }

            return _repository.GetRcvLineByHeaderID(_view.headSeleted.ReceiptHeaderId).ToList();
        }

        private void UpdateReceivedLines(IEnumerable<POReceiptLineModel> lines)
        {
            int lineNum = 1;
            foreach (var recLine in lines.OrderBy(o => o.ReceiptLineId))
            {
                recLine.LineNum = lineNum++;
                _repository.UpdateRcvLine(recLine);
            }
        }

        private IEnumerable<POReceiptLineModel> GenerateLotNumber(IEnumerable<POReceiptLineModel> lines)
        {
            //IEnumerable<POReceiptLineModel> recLines;// = new IEnumerable<POReceiptLineModel>;

            foreach (var line in lines)
            {
                line.LotNumber = _repoItem.GetRunningLotByItemID(line.ItemId);
                _repository.UpdateRcvLine(line);
            }
            _view.rcvLines = _repository.GetRcvLineByHeaderID(lines.FirstOrDefault().ReceiptHeaderId);
            _view.LineRefresh();
            return _view.rcvLines;
        }

        private bool ValidateLines(IEnumerable<POReceiptLineModel> lines)
        {
            bool result = true;
            foreach (var recLine in lines)
            {
                if (recLine.QuantityShipped == 0 && _view.headSeleted.ReceiptMethod == "RECEIVE")
                {
                    MessageBox.Show("PO No. "+ recLine.PONum +" Line : " + recLine.POLineNum + " receive qty. = 0", "Validate Line Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }

                if (string.IsNullOrEmpty(recLine.ToSubinventory))
                {
                    MessageBox.Show("Subinventory is null.", "Validate Line Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }

                if (string.IsNullOrEmpty(recLine.ProjectNum))
                {
                    MessageBox.Show("Project is null.", "Validate Line Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result = false;
                }

                if(_view.headSeleted.ReceiptMethod == "RETURN")
                {
                    ItemOnhandModel onhand = _repoOnhand.GetDupplicated(recLine.ItemId
                                                    , recLine.ToSubinventory
                                                    , recLine.LotNumber
                                                    , string.IsNullOrEmpty(recLine.Attribute1) ? "999" : recLine.Attribute1  /*Bom Number*/
                                                    );

                    if (onhand != null)
                    {
                        if (Math.Abs(recLine.QuantityShipped) > onhand.PrimaryTransactionQuantity)
                        {
                            MessageBox.Show("Return quantity is not available.", "Validate Line Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            result = false;
                        }
                    }
                }
            }

            return result;
        }

        private bool GenerateTransaction(IEnumerable<POReceiptLineModel> lines)
        {
            bool result = true;
            try
            {
                POReceiptHeaderModel recHead = _view.headSeleted;

                foreach (var recLine in lines)
                {
                    ItemTransactionModel trans = new ItemTransactionModel();
                    trans.InventoryItemId = recLine.ItemId;
                    trans.SubinventoryCode = recLine.ToSubinventory;
                    trans.TransactionSourceName = "PO RECEIVING";
                    trans.TransactionQuantity = recLine.QuantityShipped;
                    trans.TransactionUom = string.IsNullOrEmpty(recLine.UnitOfMeasure) ? "PCS" : recLine.UnitOfMeasure;
                    trans.PrimaryQuantity = recLine.QuantityShipped;
                    trans.TransactionDate = recHead.ReceiptDate;
                    trans.TransactionReference = recHead.ReceiptNum;
                    trans.CostedFlag = "Y";
                    trans.ActualCost = recLine.ShipmentUnitPrice;
                    trans.TransactionCost = recLine.ShipmentUnitPrice;
                    trans.Attribute1 = recLine.ProjectNum;
                    trans.Attribute2 = recLine.CostCode;
                    trans.Attribute3 = recLine.LotNumber;
                    trans.Attribute4 = recLine.Attribute1;  //BOM No.
                    trans.TrxSourceLineId = recLine.ReceiptLineId;
                    trans.TransferSubinventory = recLine.ToSubinventory;

                    //Update po_line_id to task_id For PO line is Job Process.
                    if (recLine.QcRequireInspcFlag)
                        trans.TaskId = recLine.PoLineId;        

                    int id = _repoTrans.InsertTrans(trans);

                    ItemOnhandModel onhand = _repoOnhand.GetDupplicated(recLine.ItemId
                                                                        , recLine.ToSubinventory
                                                                        , recLine.LotNumber
                                                                        , string.IsNullOrEmpty(recLine.Attribute1) ? "999" : recLine.Attribute1  //If BOM No. is null default '999'
                                                                        );
                    if (onhand != null)
                    {
                        double trxQty = onhand.PrimaryTransactionQuantity + recLine.QuantityShipped;
                        onhand.PrimaryTransactionQuantity = trxQty;
                        onhand.TransactionQuantity = trxQty;
                        onhand.UpdateTransactionId = id;
                        onhand.TransactionUnitCost = recLine.ShipmentUnitPrice;

                        _repoOnhand.UpdateOnhand(onhand);
                    }
                    else
                    {
                        onhand = new ItemOnhandModel();
                        onhand.InventoryItemId = recLine.ItemId;
                        onhand.DateReceived = _view.headSeleted.RequestDate;
                        onhand.PrimaryTransactionQuantity = recLine.QuantityShipped;
                        onhand.TransactionQuantity = recLine.QuantityShipped;
                        onhand.SubinventoryCode = recLine.ToSubinventory;
                        onhand.LotNumber = recLine.LotNumber;
                        onhand.TransactionUomCode = recLine.UnitOfMeasure;
                        onhand.CreateTransactionId = id;
                        onhand.UpdateTransactionId = id;
                        onhand.BomNo = string.IsNullOrEmpty(recLine.Attribute1) ? "999" : recLine.Attribute1;  //If BOM No. is null default '999'
                        onhand.TransactionUnitCost = recLine.ShipmentUnitPrice;
                        onhand.ProjectId = recLine.ProjectId;
                        onhand.ProjectNum = recLine.ProjectNum;
                        onhand.ProjectCostCode = recLine.CostCode;

                        //Update po_line_id to task_id For PO line is Job Process.
                        if (recLine.QcRequireInspcFlag)
                            onhand.TaskId = recLine.PoLineId; 

                        int onhandId = _repoOnhand.InsertOnhand(onhand);
                    }
                }

                result = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Received process error : ." + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            return result;
        }

        private void GeneratePOLocation(IEnumerable<POReceiptLineModel> lines)
        {
            //POReceiptHeaderModel recHead = _view.headSeleted;
            IEnumerable<POReceiptLineModel> resultLines = lines;

            if (_view.headSeleted.ReceiptMethod == "RETURN")
                resultLines = lines.Where(x => x.QuantityShipped < 0).ToList();

            foreach (var recLine in resultLines)
            {
                POLineLocationModel loc = new POLineLocationModel();
                loc.PoHeaderId = recLine.PoHeaderId;
                loc.PoLineId = recLine.PoLineId;
                loc.Quantity = recLine.QuantityShipped;
                loc.QuantityReceived = recLine.QuantityShipped;
                loc.UnitMeasLookupCode = recLine.UnitOfMeasure;
                loc.InspectionRequiredFlag = recLine.QcRequireInspcFlag;
                loc.ReceiptHeaderId = recLine.ReceiptHeaderId;
                loc.ReceiptLineId = recLine.ReceiptLineId;
                loc.ConfirmFlag = "N";

                int id = _repoPurchase.InsertPoLineLocation(loc);
            }

            //Get PO Lines to Update PO Status ***Not support multi PO in same Receive.
            int poId = lines.FirstOrDefault().PoHeaderId;
            List<POLineModel> poLines = _repoPurchase.GetPOLineByPOID(poId);

            var result = poLines.GroupBy(x => x.ReceivedStatus)
                             .Select(group => new { ReceivedStatus = group.Key, Items = group.ToList() })
                             .ToList();

            POHeaderModel po = _repoPurchase.GetPOByID(poId);
            if (result.Count() == 1)
            {                
                if (result.FirstOrDefault().ReceivedStatus == "Fill")
                {                    
                    po.StatusCode = "FINALLY CLOSED";
                    po.ReceivedFlag = true;
                }
                else
                {
                    po.StatusCode = "OPEN";
                    po.ReceivedFlag = false;                    
                }
            }
            else
            {
                po.StatusCode = "OPEN";
                po.ReceivedFlag = false;                
            }
            _repoPurchase.UpdatePO(po);
        }

        private void ConfirmPOLocation(IEnumerable<POReceiptLineModel> lines)
        {
            //POReceiptHeaderModel recHead = _view.headSeleted;
            foreach (var recLine in lines)
            {
                POLineLocationModel loc = _repoPurchase.GetLineLocationByPOLineID(recLine.PoLineId).Where(x => x.ReceiptLineId == recLine.ReceiptLineId).FirstOrDefault();
                loc.ConfirmFlag = "Y";
                _repoPurchase.UpdatePoLineLocation(loc);
            }
        }

        private void Confirm_QC(object sender, EventArgs e)
        {
            IEnumerable<POReceiptLineModel> lines = _view.rcvLines;
            POReceiptLineModel lineSelected = _view.lineInspection;

            lines.Where(p => p.ReceiptLineId.Equals(lineSelected.ReceiptLineId)).ToList()
                                .ForEach(u =>
                                {
                                    u.QcInspectionStatus = lineSelected.QcInspectionStatus;
                                    u.QcInspectionBy = _view.EpiSession.User.Id;
                                });

            _view.rcvLines = lines;
            _view.LineRefresh();
            _view.lineInspection = null;
        }

        private void Seleted_Line(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;

            POReceiptLineModel line = new POReceiptLineModel();

            try
            {
                line = (POReceiptLineModel)grd.CurrentRow.DataBoundItem;
                _view.lineSeleted = line;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (line.QcRequireInspcFlag)
                _view.lineInspection = _view.lineSeleted;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            _view.costs = _repoProj.GetCostGropAll();
            //Call Seleted Receipt Header....
        }

        private void Seleted_RCV(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            POReceiptHeaderModel rcv = new POReceiptHeaderModel();
            int id = Convert.ToInt32(grid.CurrentRow.Cells[0].Value);

            rcv = _repository.GetReceiptHeaderByID(id);

            _view.headSeleted = rcv;
            _view.rcvLines = _repository.GetRcvLineByHeaderID(id);
            _view.BindingRcvLines(_view.rcvLines);
        }

        private void GetPO(object sender, EventArgs e)
        {
            if (_view.headSeleted.ReceiptHeaderId != 0 && _view.headSeleted.VendorId != 0)
            {
                using (POLineSelectionForm frm = new POLineSelectionForm())
                {
                    frm.vendorId = _view.headSeleted.VendorId;
                    frm.rcvMethod = _view.headSeleted.ReceiptMethod;
                    frm.ShowDialog();
                    if (frm.linesSelected != null)
                    {
                        if (frm.linesSelected.Count() > 0)
                        {
                            List<POLineModel> poLines = frm.linesSelected;
                            AddReceivingLine(poLines);
                        }
                    }
                }
            }
        }

        private void AddReceivingLine(List<POLineModel> poLines)
        {
            if (poLines.Count > 0)
            {
                POReceiptHeaderModel recHead = _view.headSeleted;
                foreach (var poLine in poLines)
                {
                    POReceiptLineModel recLine = new POReceiptLineModel();
                    recLine.CreatedBy = _view.EpiSession.User.Id;
                    recLine.LastUpdatedBy = _view.EpiSession.User.Id;
                    recLine.ReceiptHeaderId = _view.headSeleted.ReceiptHeaderId;
                    recLine.LineNum = 0; //When to generate line num after Received status
                    recLine.QuantityShipped = poLine.Quantity - poLine.QuantityReceived; //Default 0
                    recLine.QuantityReceived = poLine.QuantityReceived;
                    recLine.UnitOfMeasure = string.IsNullOrEmpty(poLine.Uom) ? "PCS" : poLine.Uom;
                    recLine.ItemDescription = poLine.ItemDescription;
                    recLine.ItemId = poLine.ItemId;
                    recLine.SourceDocumentCode = "PURCHASING";
                    recLine.PoHeaderId = poLine.PoHeaderId;
                    recLine.PoLineId = poLine.PoLineId;
                    recLine.ToSubinventory = poLine.RefProjectNum;
                    recLine.ProjectId = poLine.RefProjectId;
                    recLine.ProjectNum = poLine.RefProjectNum;
                    recLine.ShipmentUnitPrice = poLine.UnitPrice;
                    recLine.TaxName = poLine.TaxCode;
                    recLine.TaxAmount = poLine.TaxAmount;
                    recLine.InvoiceStatusCode = "N";
                    recLine.PrjCostId = poLine.ProjCostId;
                    recLine.QuantityOrdered = poLine.Quantity;
                    recLine.CostCode = poLine.CostCode;
                    recLine.Attribute1 = poLine.BOM;   /*Bom Number*/

                    CostGroupModel cost = _view.costs.Where(x => x.CostCode == poLine.CostCode).FirstOrDefault();
                    if (cost == null)
                    {
                        MessageBox.Show("Cost Code : " + cost.CostCode +
                            " in PO Line : " + poLine.PoLineNum + " dose not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    int dup = _view.rcvLines.Where(x => x.PoLineId == poLine.PoLineId).ToList().Count();
                    if (dup > 0)
                    {
                        MessageBox.Show("PO Line : " + poLine.PoLineNum + " was existing within Receive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    recLine.QcRequireInspcFlag = cost.MakingFlag;

                    if (recLine.QcRequireInspcFlag)
                    {
                        recLine.QcInspectionStatus = 2; //Default PASS
                    }
                    else
                    {
                        recLine.QcInspectionStatus = 0; //NOTHING
                    }

                    if (_view.rcvLines.Count() == 0)
                    {
                        recHead.SourceType = poLine.LineType;
                        if (recLine.QcRequireInspcFlag)
                        {
                            recHead.QCInspectionFlag = true;
                            recHead.InspectionStatus = "HOLD";
                        }
                        else
                        {
                            recHead.QCInspectionFlag = false;
                            recHead.InspectionStatus = "NO INSPECTION";
                        }
                    }
                    else
                    {
                        if (poLine.LineType.Trim() != recHead.SourceType.Trim())
                        {
                            MessageBox.Show("PO Type is not match Receive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                        if (cost.MakingFlag != recHead.QCInspectionFlag)
                        {
                            MessageBox.Show("PO Type is not match Receive for Job process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }

                    _repository.InsertRcvLine(recLine);
                }

                _view.rcvLines = _repository.GetRcvLineByHeaderID(recHead.ReceiptHeaderId);
                _view.BindingRcvLines(_view.rcvLines);
                _repository.UpdateRcvHead(recHead);
                _view.headSeleted = recHead;
            }
        }

        private void GenerateGRN(object sender, EventArgs e)
        {
            if (_view.headSeleted.ReceiptHeaderId == 0)
            {
                MessageBox.Show("Please save this receipt before generate GRN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_view.headSeleted.GenReceiptNumberFlag)
            {
                POReceiptHeaderModel rcv = _view.headSeleted;
                rcv.ReceiptNum = _repository.GenGRN("RECEIVING_PO", rcv.ReceiptDate);
                if (rcv.ReceiptNum != "")
                {
                    rcv.GenReceiptNumberFlag = true;
                    _repository.UpdateRcvHead(rcv);

                    _view.headSeleted = rcv;
                }
                else
                {
                    MessageBox.Show("Cannot generate GRN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            POReceiptHeaderModel rcv = _view.headSeleted;
            string typeLookup = string.Empty;
            if (!rcv.ReceivedFlag)
            {
                rcv.ShippedDate = rcv.ReceiptDate;
                rcv.ReceiptSourceCode = "PURCHASE";
                if (rcv.VendorId == 0)
                {
                    MessageBox.Show("Vendor is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(rcv.InvoiceNum) && rcv.ReceiptMethod == "RECEIVE")
                {
                    MessageBox.Show("Invoice No. is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(rcv.ReceiptMethod))
                {
                    MessageBox.Show("Receipt Method is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //po.Remarks = _view.GetNote();

                if (rcv.ReceiptHeaderId == 0)
                {
                    if(rcv.ReceiptMethod == "RETURN")
                    {
                        rcv.ReceiptNum = _repository.GenReturn("RETURN_PO");
                        rcv.GenReceiptNumberFlag = true;
                    }                        

                    rcv.ReceiptHeaderId = _repository.InsertRcvHead(rcv);
                }
                else
                {
                    _repository.UpdateRcvHead(rcv);
                    if (rcv.ReceiptMethod == "RECEIVE")
                    {
                        Save_Lines();
                    }                    
                }
            }
            else
            {
                MessageBox.Show("This PO was submited cannot save your change.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _view.headSeleted = _repository.GetReceiptHeaderByID(rcv.ReceiptHeaderId);
        }

        private void Save_LinesReturn()
        {
            try
            {
                if (_view.rcvLines != null)
                {
                    IEnumerable<POReceiptLineModel> list = _view.rcvLines;
                    foreach (POReceiptLineModel item in list)
                    {
                        //item.PoHeaderId = _view.headSeleted.ReceiptHeaderId;
                        item.LastUpdatedBy = _view.EpiSession.User.Id;
                        item.LastUpdateDate = DateTime.Now;

                        _repository.UpdateRcvLine(item);
                    }
                    _view.rcvLines = _repository.GetRcvLineByHeaderID(_view.headSeleted.ReceiptHeaderId);
                    _view.BindingRcvLines(_view.rcvLines);
                    HaeaderValidation();
                    //MessageBox.Show("Save PO lines is Completed.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Receipt Lines is Error! " + Environment.NewLine
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Save_Lines()
        {
            try
            {
                if (_view.rcvLines != null)
                {
                    IEnumerable<POReceiptLineModel> list = _view.rcvLines;
                    foreach (POReceiptLineModel item in list)
                    {
                        //item.PoHeaderId = _view.headSeleted.ReceiptHeaderId;
                        item.LastUpdatedBy = _view.EpiSession.User.Id;
                        item.LastUpdateDate = DateTime.Now;

                        _repository.UpdateRcvLine(item);
                    }
                    _view.rcvLines = _repository.GetRcvLineByHeaderID(_view.headSeleted.ReceiptHeaderId);
                    _view.BindingRcvLines(_view.rcvLines);
                    HaeaderValidation();
                    //MessageBox.Show("Save PO lines is Completed.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Receipt Lines is Error! " + Environment.NewLine
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HaeaderValidation()
        {
            POReceiptHeaderModel head = _view.headSeleted;
            if (head.QCInspectionFlag)
            {
                var results = from p in _view.rcvLines
                              group p by p.QcInspectionStatus into g
                              select new { QcInspectionStatus = g.Key, rowsStatus = g.FirstOrDefault() };

                if (results.Count() > 1)
                {
                    head.InspectionStatus = "HOLD";
                }
                else if (results.Count() == 1)
                {
                    if (results.FirstOrDefault().QcInspectionStatus == 1)
                    {
                        head.InspectionStatus = "QC INCOMING";
                    }
                    else if (results.FirstOrDefault().QcInspectionStatus == 2)
                    {
                        head.InspectionStatus = "PASS ALL";
                    }
                    else if (results.FirstOrDefault().QcInspectionStatus == 3)
                    {
                        head.InspectionStatus = "NG ALL";
                    }
                }
            }
            _repository.UpdateRcvHead(head);
            _view.headSeleted = head;
        }

        private void Find_Vendor(object sender, EventArgs e)
        {
            using (VendorListForm frm = new VendorListForm())
            {
                frm.VendorNumber = _view.headSeleted.VendorCode;
                frm.ShowDialog();
                if (frm.vendorSelected != null)
                {
                    POReceiptHeaderModel rcv = _view.headSeleted;
                    rcv.VendorId = frm.vendorSelected.VendorId;
                    rcv.VendorCode = frm.vendorSelected.VendorNumber;
                    rcv.VendorName = frm.vendorSelected.VendorName;

                    _view.headSeleted = rcv;
                }
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            POReceiptHeaderModel rcv = new POReceiptHeaderModel();
            rcv.ReceiptDate = DateTime.Now;
            rcv.ReceivedBy = _view.EpiSession.User.Id;
            rcv.ReceivedByName = _view.EpiSession.User.UserName;
            rcv.CreatedBy = _view.EpiSession.User.Id;
            rcv.LastUpdatedBy = _view.EpiSession.User.Id;
            rcv.ReceiptMethod = "RECEIVE";

            _view.headSeleted = rcv;
            _view.rcvLines = new List<POReceiptLineModel>();
            _view.BindingRcvLines(_view.rcvLines);
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            using (POReceiptListForm frm = new POReceiptListForm(null))
            {
                frm.startDate = DateTime.Now;
                frm.endDate = DateTime.Now;
                frm.rcvMethod = "ALL";
                frm.ShowDialog();
                if (frm.rcvsSelected != null)
                {
                    _view.receipts = frm.rcvsSelected;
                    _view.BindingRcvHead(_view.receipts);
                }
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            New_Click(null, null);
            _view.receipts = new List<POReceiptHeaderModel>();
            _view.rcvLines = new List<POReceiptLineModel>();
            _view.costs = _repoProj.GetCostGropAll();
            _view.lineInspection = null;

            _view.BindingRcvHead(_view.receipts);
            _view.BindingRcvLines(_view.rcvLines);
        }
    }
}