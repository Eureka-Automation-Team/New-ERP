using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Purchasing
{
    public class POLineModel
    {
        public int PoLineId { get; set; }
        public int PoHeaderId { get; set; }
        [DisplayName("Line")]
        public int PoLineNum { get; set; }
        [DisplayName("Project No.")]
        public string RefProjectNum { get; set; }
        [DisplayName("Balloon No.")]
        public string BalloonNo { get; set; }  //***new
        [DisplayName("ERP-Item No.")]
        public string ItemCode { get; set; }     //***new
        [DisplayName("QTY.")]
        public double Quantity { get; set; }
        [DisplayName("PART NAME/Description")]
        public string ItemDescription { get; set; }
        [DisplayName("MANU ID")]
        public string Spec { get; set; }      //***new  
        [DisplayName("Brand/Mat")]
        public string BrandMaterail { get; set; }      //***new
        [DisplayName("Cost Code")]
        public string CostCode { get; set; }
        [DisplayName("BOM")]
        public string BOM { get; set; }             //***new
        [DisplayName("Suplier")]
        public string Suplier { get; set; }             //***new
        [DisplayName("Unit Cost")]
        public double UnitPrice { get; set; }
        [DisplayName("Due Date")]
        public Nullable<DateTime> DueDate { get; set; }      //***new
        [DisplayName("ECN.No")]
        public string ECN { get; set; }      //***REV
        [DisplayName("Consign / Reues")]
        public string CSR { get; set; }     
        [DisplayName("Lead Time")]
        public int LeadTime { get; set; }     
        [DisplayName("Load Bom Date")]
        public Nullable<DateTime> LoadBomDate { get; set; }      
        [DisplayName("Extended Cost")]
        public double ExtendedAmount
        {
            get { return Quantity * UnitPrice; }
        }
        [DisplayName("U/M")]
        public string Uom { get; set; }
        [DisplayName("Received")]
        public string ReceivedStatus
        {
            get {
                string str = string.Empty;
                if (QuantityReceived > 0)
                {
                    if (QuantityReceived == Quantity)
                        str = "Fill";
                    else
                        str = "Partial";
                }
                else
                    str = "Pending";

                    return str;
            }
        }

        //[DisplayName("REV")]
        //public string Rev { get; set; }      

        public string Status { get; set; }
        public string LineType { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public int ItemId { get; set; }
        
        public double QunitityCompleted { get; set; }
        public double BaseUnitPrice { get; set; }
        public string TaxAbleFlag { get; set; }
        public string TaxCode { get; set; }
        public double TaxRate { get; set; }
        public double TaxAmount { get; set; }
        public int RefProjectId { get; set; }        
        public int BomLineId { get; set; }
        public int BomRelease { get; set; }
        public int ProjCostId { get; set; }
        public bool JobMakingFlag { get; set; }
        [DisplayName("Received Qty.")]
        public double QuantityReceived { get; set; }
        [DisplayName("Cancel")]
        public bool CancelFlag { get; set; }
        public bool DupplicateFlag { get; set; }
        public bool EncumbranceFlag { get; set; }
        public double EncumbranceAmount { get; set; }
        [DisplayName("Standard Price")]
        public double UnitPriceBeforeFinal { get; set; }
        public int VendorId { get; set; }
        [DisplayName("Error Message")]
        public string LineErrorMessage { get; set; }
        [DisplayName("Currency")]
        public string CurrencyCode { get; set; }
        [DisplayName("Rate")]
        public double CurrencyRate { get; set; }
    }
}
