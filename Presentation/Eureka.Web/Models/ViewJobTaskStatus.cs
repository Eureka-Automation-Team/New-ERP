using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class ViewJobTaskStatus
    {
        public int JobEntityId { get; set; }
        public string JobEntityName { get; set; }
        public string PrimaryItemCode { get; set; }
        public string Description { get; set; }
        public string PrimaryItemModel { get; set; }
        public decimal PrimaryQuantity { get; set; }
        public DateTime JobEntiryDate { get; set; }
        public int? TaskId { get; set; }
        public int? Priority { get; set; }
        public int? StandardTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? ReadyFlag { get; set; }
        public int? ReleaseFlag { get; set; }
        public int? OnShelfFlag { get; set; }
        public string ShelfNumber { get; set; }
        public int? ReserveShelfFlag { get; set; }
        public int? UploadNcfileFlag { get; set; }
        public string MachineNo { get; set; }
        public string JobNumber { get; set; }
        public int? McProcessFlag { get; set; }
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
        public string MachineNoReady { get; set; }
        public int? StartFlag { get; set; }
        public string OpenStatus { get; set; }
        public string CompletedFlag { get; set; }
        public string CancelFlag { get; set; }
    }
}
