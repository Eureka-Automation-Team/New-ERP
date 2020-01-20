using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class ViewMfgJobTransactionLogs
    {
        public int? JobEntityId { get; set; }
        public int? TaskId { get; set; }
        public DateTime? ActReleaseDate { get; set; }
        public DateTime? ActOnShelfDate { get; set; }
        public DateTime? ActLoadingDate { get; set; }
        public DateTime? ActStartDate { get; set; }
        public DateTime? ActFinishDate { get; set; }
        public DateTime? ActUnloadingDate { get; set; }
        public DateTime? ActOutboundDate { get; set; }
        public int? ActInboundTime { get; set; }
        public int? ActLoadingTime { get; set; }
        public int? ActMachineTime { get; set; }
        public int? ActUnloadTime { get; set; }
        public int? ActOutboundTime { get; set; }
    }
}
