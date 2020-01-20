using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class InvLocations
    {
        public int LocationId { get; set; }
        public int? LevelNo { get; set; }
        public int? ColumnNo { get; set; }
        public string CombindLocation { get; set; }
        public int? ItemId { get; set; }
        public int? TaskId { get; set; }
        public int? ReserveFlag { get; set; }
        public int? FillFlag { get; set; }
        public int? AvailableFlag { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public string Attribute5 { get; set; }
        public int? Priority { get; set; }
    }
}
