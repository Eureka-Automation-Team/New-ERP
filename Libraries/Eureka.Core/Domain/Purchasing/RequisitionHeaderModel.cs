using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Purchasing
{
    public class RequisitionHeaderModel
    {
        public int RequisitionHeaderId { get; set; }
        [DisplayName("PR No.")]
        public string RequisitionNumber { get; set; }
        public DateTime RequisitionDate { get; set; }
        public int RequesterId { get; set; }
        public string RequesterName { get; set; }
        public int ApproverId { get; set; }
        public string ApproverName { get; set; }
        public string Status { get; set; }
        public string TypeLookupCode { get; set; }
        public bool JobProcessFlag { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public string Segment1 { get; set; }
        public string SummaryFlag { get; set; } //10
        public string EnabledFlag { get; set; }
        public string Segment2 { get; set; }
        public string Segment3 { get; set; }
        public string Segment4 { get; set; }
        public string Segment5 { get; set; }
        public string ProjectNo { get; set; }
        public Nullable<DateTime> StartDateActive { get; set; }
        public Nullable<DateTime> EndDateActive { get; set; }
        public int LastUpdateLogin { get; set; }
        public DateTime CreationDate { get; set; }    //20
        public int CreatedBy { get; set; }
        public string Description { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public string Attribute5 { get; set; }
        public bool CancelFlag { get; set; }
        public int OrgId { get; set; }
        public string AuthorizationStatus { get; set; }     //30
        public string NoteToAuthorizer { get; set; }
        public Nullable<DateTime> ApprovedDate { get; set; }
        public int BomId { get; set; }
        public string BomNumber { get; set; }
        public int CostId { get; set; }
        public string CostCode { get; set; }
        public int RevisionNum { get; set; }
        public bool PurchasedFlag { get; set; }
        public double TotalAmount { get; set; }
        public bool SubmitFlag { get; set; }
        public bool ApprovedFlag { get; set; }
        public bool SentPoConfirmFlag { get; set; }
        public bool PoConfirmedFlag { get; set; }
    }
}
