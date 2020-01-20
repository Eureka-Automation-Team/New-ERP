using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class MfgJobTasks
    {
        public int TaskId { get; set; }
        public int? TaskSeq { get; set; }
        public int JobEntityId { get; set; }
        public string TaskNumber { get; set; }
        public string JobNumber { get; set; }
        public string Description { get; set; }
        public int? StandardTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ReadyFlag { get; set; }
        public int? ReleaseFlag { get; set; }
        public string Source { get; set; }
        public string ShelfNumber { get; set; }
        public int ReserveShelfFlag { get; set; }
        public int? OnShelfFlag { get; set; }
        public int? UploadNcfileFlag { get; set; }
        public int McProcessFlag { get; set; }
        public int? McLoadFlag { get; set; }
        public int? McFinishFlag { get; set; }
        public int? McUnloadFlag { get; set; }
        public int? McPushFlag { get; set; }
        public int? OutboundFlag { get; set; }
        public int? OutboundFinishFlag { get; set; }
        public string QcStatus { get; set; }
        public string MaterialCode { get; set; }
        public string TableNumber { get; set; }
        public string NcFile { get; set; }
        public DateTime? DueDate { get; set; }
        public string MachineNo { get; set; }
        public string MachineNoReady { get; set; }
        public int? Priority { get; set; }
        public int? McPickFlag { get; set; }
        public string ErrorText { get; set; }
        public string Manager { get; set; }
        public int? CancelFlag { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? StartFlag { get; set; }
        public int? TrfNcfileToMcFlag { get; set; }
        public string TransferMessage { get; set; }
        public int? SetupTime { get; set; }
        public int? BreakdownTime { get; set; }
        public string BreakdownType { get; set; }
    }
}
