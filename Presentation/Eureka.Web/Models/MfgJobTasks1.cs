using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class MfgJobTasks1
    {
        public int TaskId { get; set; }
        public int? TaskSeq { get; set; }
        public int JobEntityId { get; set; }
        public string TaskNumber { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string Manager { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CancelFlag { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreatedBy { get; set; }
        public string ErrorText { get; set; }
        public int ReadyFlag { get; set; }
        public string SourceLocation { get; set; }
        public string DestinationLocation { get; set; }
        public int McProcessFlag { get; set; }
        public int? McPickFlag { get; set; }
        public int? McLoadFlag { get; set; }
        public int? McFinishFlag { get; set; }
        public int? McUnloadFlag { get; set; }
        public int? McPushFlag { get; set; }
        public string MaterialCode { get; set; }
        public string TableNumber { get; set; }
        public string NcFile { get; set; }
        public DateTime? DueDate { get; set; }
        public string MachineNo { get; set; }
        public int? Priority { get; set; }
    }
}
