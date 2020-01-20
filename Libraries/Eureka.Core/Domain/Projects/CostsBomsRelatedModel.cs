using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Projects
{
    public class CostsBomsRelatedModel
    {
        public int BomId { get; set; }
        public string BomNumber { get; set; }
        public int CostId { get; set; }
        public string CostCode { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public string Attribute5 { get; set; }
        public Nullable<DateTime> LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public Nullable<DateTime> CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public bool EnableFlag { get; set; }
    }
}
