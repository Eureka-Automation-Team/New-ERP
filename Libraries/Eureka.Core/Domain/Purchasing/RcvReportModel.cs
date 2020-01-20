using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Purchasing
{
    public class RcvReportModel
    {
        public string ReceiptNum { get; set; } 
        public DateTime ReceiptDate { get; set; }
        public int VendorId { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string InvoiceNum { get; set; }
        public int ReceivedBy { get; set; }
        public string ReceivedByName { get; set; }
        public string PONumber { get; set; }
        public int LineNum { get; set; }
        public int POLineNum { get; set; }
        public int ItemId { get; set; }            
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string Spec { get; set; }  //MANU ID
        public string BrandMaterail { get; set; } //Brand/Mat
        public double QuantityReceived { get; set; }
        public string UnitOfMeasure { get; set; }
        public double ShipmentUnitPrice { get; set; }
        public double TotalPrice
        {
            get { return QuantityReceived * ShipmentUnitPrice; }
        }
        public string ToSubinventory { get; set; }            
        public string LotNumber { get; set; }
        public string ProjectNum { get; set; }
    }
}
