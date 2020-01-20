using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Projects
{
    public class BomNumberModel
    {
        public int BomId { get; set; }
        public string BomNumber { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public Nullable<DateTime> CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public bool EnableFlag { get; set; }
    }
}
