using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Purchasing
{
    public class RequisitionLineModel
    {
        public int RequisitionLineId { get; set; }
        public int RequisitionHeaderId { get; set; }
        public string RequisitionNumber { get; set; }
        public DateTime RequisitionDate { get; set; }
        public int LineNum { get; set; }
        public string Status { get; set; }
        public string LineType { get; set; }
        public Nullable<DateTime> LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public Nullable<DateTime> CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string Uom { get; set; }
        public double Quantity { get; set; }
        public double StockOnHand { get; set; }
        public double UnitPrice { get; set; }
        public double FinalUnitPrice { get; set; }
        public double ExtendedAmount
        {
            get
            {
                return ApprovedFlag ? Quantity * FinalUnitPrice : Quantity * UnitPrice;
            }
        }
        public int RefProjectId { get; set; }
        public string RefProjectNum { get; set; }
        public int ProjCostId { get; set; }
        public int CostId { get; set; }
        public string CostCode { get; set; }
        public string BalloonNo { get; set; }
        public int BomId { get; set; }
        public string BomNo { get; set; }
        public string BrandMaterail { get; set; }
        public string Rev { get; set; }
        public Nullable<DateTime> DueDate { get; set; }
        public Nullable<DateTime> RequestDate { get; set; }
        public string EcnNo { get; set; }
        public string CsrNo { get; set; }
        public int LeadTime { get; set; }
        public Nullable<DateTime> LoadBomDate { get; set; }
        public string SpecModel { get; set; }
        public string SuplierSymbol { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public string Attribute5 { get; set; }
        public bool JobMakingFlag { get; set; }
        public bool CancelFlag { get; set; }
        public bool PurchasedFlag { get; set; }
        //---------------------------------------
        public double PurchasedQuantity { get; set; }
        public bool ApprovedFlag { get; set; }
        public bool ValidatedFlag { get; set; }
        public bool DupplicateFlag { get; set; }
        public bool FinalConfirmFlag { get; set; }
        public bool RejectFlag { get; set; }
        public string RejectComment { get; set; }
        public int PoHeaderId { get; set; }
        public int PoLineId { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public bool EncumbranceFlag { get; set; }
        public double EncumbranceAmount { get; set; }
        public bool SentPriceConfirmFlag { get; set; }
        public bool PriceConfirmedFlag { get; set; }
        public string LineErrorMessage { get; set; }
        public string Notes { get; set; }
        public bool DeleteFlag { get; set; }
        public bool SubmitFlag { get; set; }
    }
}
