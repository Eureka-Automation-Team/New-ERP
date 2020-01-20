using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Purchasing
{
    public class ApproveListHeadModel
    {
        public int ApprovalListHeaderId { get; set; }
        public int DocumentId { get; set; }
        public string DocumentType { get; set; }
        public int Revision { get; set; }
        public String LatestRevision { get; set; }
        public int FirstApproverId { get; set; }
        public int ApprovalPathId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string FinalFlag { get; set; }
    }
}
