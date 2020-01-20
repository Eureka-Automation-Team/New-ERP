using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Purchasing
{
    public class ApproveListLineModel
    {
        public int ApprovalListHeaderId { get; set; }
        public int ApprovalListLineId { get; set; }
        public int ApproverId { get; set; }
        public string ApproverName { get; set; }
        public int SequenceNum { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public string StatusName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
