using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Projects
{
    public class CostGroupModel : BaseEntity
    {
        public string CostCode { get; set; }
        public string CostDescription { get; set; }
        public string CostClass { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public bool MakingFlag { get; set; }
    }
}
