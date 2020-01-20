using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Payables
{
    public class TermModel
    {
        public int TermId { get; set; }
        public string TermCode { get; set; }
        public string Description { get; set; }
        public int DueDay { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }

    }
}
