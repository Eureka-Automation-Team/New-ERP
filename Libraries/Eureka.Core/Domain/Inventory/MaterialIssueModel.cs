using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Inventory
{
    public class MaterialIssueModel
    {
        public int IssueId { get; set; }
        public string IssueNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public int IssueBy { get; set; }
        public string IssueByName { get; set; }
    }
}
