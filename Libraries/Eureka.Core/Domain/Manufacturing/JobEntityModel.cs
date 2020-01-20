using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Manufacturing
{
    public class JobEntityModel
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
        public int PrimaryItemId { get; set; }
        public string PrimaryItemCode { get; set; }
        public string PrimaryItemModel { get; set; }
        public double PrimaryQuantity { get; set; }
        public string Segment1 { get; set; }
        public string Segment2 { get; set; }
        public string Segment3 { get; set; }
        public string Segment4 { get; set; }
        public string Segment5 { get; set; }
        public bool OpenStatus { get; set; }
        public bool ProcessFlag { get; set; }
        public bool CompletedFlag { get; set; }
        public bool CancelFlag { get; set; }
        public int PoLineId { get; set; }
        public int PoHeaderId { get; set; }
    }
}
