using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Purchasing
{
    public class POReceiptHeaderModel
    {
        public int ReceiptHeaderId { get; set; }
        [DisplayName("Receipt No.")]
        public string ReceiptNum { get; set; }   // col index = 1
        [DisplayName("Receipt Date")]
        public DateTime ReceiptDate { get; set; }   // col index = 2
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public bool ReceivedFlag { get; set; }
        public string ReceiptSourceCode { get; set; }
        public int VendorId { get; set; }
        public string VendorCode { get; set; }
        [DisplayName("Vendor")]
        public string VendorName { get; set; }   // col index = 10
        public int OrganizationId { get; set; }
        public string ShipmentNum { get; set; }
        public int ShipToLocationId { get; set; }
        public string BillOfLading { get; set; }
        public string PackingSlip { get; set; }
        public DateTime ShippedDate { get; set; }
        public int EmployeeId { get; set; }
        public string Comments { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }   // col index = 20
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public string Attribute5 { get; set; }
        public string Attribute6 { get; set; }
        public string Attribute7 { get; set; }
        public string Attribute8 { get; set; }
        public string Attribute9 { get; set; }
        public string Attribute10 { get; set; }
        public string Attribute11 { get; set; }
        public string Attribute12 { get; set; }   // col index = 30
        public string Attribute13 { get; set; }
        public string Attribute14 { get; set; }
        public string Attribute15 { get; set; }
        public string GovernmentContext { get; set; }
        public double GrossWeight { get; set; }
        public string GrossWeightUomCode { get; set; }
        public double NetWeight { get; set; }
        public string NetWeightUomCode { get; set; }
        public string FreightTerms { get; set; }
        public string FreightBillNumber { get; set; }   // col index = 40
        public string InvoiceNum { get; set; }
        public Nullable<DateTime> InvoiceDate { get; set; }
        public double InvoiceAmount { get; set; }
        public string TaxName { get; set; }
        public double TaxAmount { get; set; }
        public double FreightAmount { get; set; }
        public string InvoiceStatusCode { get; set; }
        public string CurrencyCode { get; set; }
        public string ConversionRateType { get; set; }
        public double ConversionRate { get; set; }   // col index = 50
        public Nullable<DateTime> ConversionDate { get; set; }
        public string ApprovalStatus { get; set; }
        public Nullable<DateTime> PerformancePeriodFrom { get; set; }
        public Nullable<DateTime> PerformancePeriodTo { get; set; }
        public Nullable<DateTime> RequestDate { get; set; }
        //-----------------------------------
        public string SourceType { get; set; }
        public int ReceivedBy { get; set; }
        public string ReceivedByName { get; set; }
        public bool QCInspectionFlag { get; set; }
        public string InspectionStatus { get; set; }
        public bool GenReceiptNumberFlag { get; set; }
        public string ReceiptMethod { get; set; }

    }
}
