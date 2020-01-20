using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Purchasing
{
    public class POHeaderModel
    {
        public int PoHeaderId { get; set; }
        [DisplayName("PO No.")]
        public string PoNum { get; set; }
        [DisplayName("Date")]
        public DateTime PODate { get; set; }
        public string TypeLookupCode { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public int VendorId { get; set; }
        public int VendorSiteId { get; set; }
        [DisplayName("Vendor Code")]
        public string VendorNum { get; set; }
        [DisplayName("Vendor Name")]
        public string VendorName { get; set; }
        public int ShipToLocationId { get; set; }
        public int BillToLocationId { get; set; }
        public int TermId { get; set; }
        public string TermCode { get; set; }
        public string TermDesc { get; set; }
        public string CurrencyCode { get; set; }
        public string RateType { get; set; }
        public Nullable<DateTime> RateDate { get; set; }
        public double Rate { get; set; }
        public string AuthorizationStatus { get; set; }
        public int RevisionNum { get; set; }
        public Nullable<DateTime> RevisedDate { get; set; }
        public bool ApprovedFlag { get; set; }
        public Nullable<DateTime> ApprovedDate { get; set; }
        public string Remarks { get; set; }
        public Nullable<DateTime> ClosedDate { get; set; }
        public string ApprovalRequiredFlag { get; set; }
        public bool CancelFlag { get; set; }
        public string StatusCode { get; set; }
        public string TaxCode { get; set; }
        public double TaxRate { get; set; }
        public double SubTotal { get; set; }
        public double SebTotalAfterDiscount
        {
            get { return (SubTotal - Discount); }
        }
        public double TaxAmount
        {
            //คืด VAT หลังหักส่วนลด
            get { return (SebTotalAfterDiscount * TaxRate) / 100; }
        }
        public double Discount { get; set; }
        public double Freight { get; set; }
        public double TotalAmount
        {
            //บวกค่าจัดส่ง โดยไม่นำไปคิด VAT
            get { return (SebTotalAfterDiscount + Freight) + TaxAmount; }
        }
        public string Status { get; set; }
        public string StatusName { get; set; }
        public int ProjectId { get; set; }
        public string ProjectNum { get; set; }
        public bool ReceivedFlag { get; set; }
        public int BuyerId { get; set; }
        [DisplayName("Buyer")]
        public string BuyerName { get; set; }
        public bool SubmitFlag { get; set; }
        public bool JobFlag { get; set; }
        public string RevisionNote { get; set; }
        public int ApproverId { get; set; }
        public string ApproverName { get; set; }
    }
}
