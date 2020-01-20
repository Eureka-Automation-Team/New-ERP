using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Purchasing
{
    public class POLoggingModel
    {
        public int LogingId { get; set; }
        public string LogingSource { get; set; }
        public string ActionSource { get; set; }
        public int ActionBy { get; set; }
        public string ActionDescription { get; set; }
        public int PoHeaderId { get; set; }
        public int PoLineId { get; set; }
        public int RequisitionHeaderId { get; set; }
        public int RequisitionLineId { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
