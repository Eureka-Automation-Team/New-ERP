using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class MfgJobTransactionLogs
    {
        public int TransactionLogId { get; set; }
        public int? JobEntityId { get; set; }
        public int? TaskId { get; set; }
        public string Action { get; set; }
        public DateTime? ActionTime { get; set; }
        public string LogMessages { get; set; }
    }
}
