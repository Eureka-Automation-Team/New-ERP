using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Manufacturing
{
    public class MachineModel
    {
        public int MachineId { get; set; }
        public string MachineCode { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public Nullable<DateTime> LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public Nullable<DateTime> CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public bool EnableFlag { get; set; }
        public bool ActiveFlag { get; set; }
    }
}
