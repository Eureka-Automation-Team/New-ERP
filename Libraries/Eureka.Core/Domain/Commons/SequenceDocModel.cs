using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Commons
{
    public class SequenceDocModel : BaseEntity
    {
        public string Prefix { get; set; }
        public string DocTypeCode { get; set; }
        public int NextVal { get; set; }
        public int RunningDigit { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
