using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class MfgJobEntities
    {
        public int JobEntityId { get; set; }
        public int OrganizationId { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public string JobEntityName { get; set; }
        public DateTime JobEntiryDate { get; set; }
        public int EntityType { get; set; }
        public string Description { get; set; }
        public int? PrimaryItemId { get; set; }
        public string PrimaryItemCode { get; set; }
        public string PrimaryItemModel { get; set; }
        public decimal PrimaryQuantity { get; set; }
        public string Segment1 { get; set; }
        public string Segment2 { get; set; }
        public string Segment3 { get; set; }
        public string Segment4 { get; set; }
        public string Segment5 { get; set; }
        public string OpenStatus { get; set; }
        public string ProcessFlag { get; set; }
        public string CompletedFlag { get; set; }
        public string CancelFlag { get; set; }
        public int? PoHeaderId { get; set; }
        public int? PoLineId { get; set; }
    }
}
