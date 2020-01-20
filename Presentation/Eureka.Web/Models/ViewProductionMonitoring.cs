using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class ViewProductionMonitoring
    {
        public string MachineCode { get; set; }
        public int? WorkingHr { get; set; }
        public string PartNumber { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public decimal? JoborderQty { get; set; }
        public int ReleaseQty { get; set; }
        public int CompleteQty { get; set; }
        public decimal? PlanningQty { get; set; }
        public int? TaskId { get; set; }
        public int? JobEntityId { get; set; }
        public int? Priority { get; set; }
        public int? StandardTime { get; set; }
        public decimal? StandardTimeMm { get; set; }
        public decimal? StandardTimeHr { get; set; }
        public decimal? PlanningTimeMm { get; set; }
        public decimal? PlaningTimeHr { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? PlaningTimeMm { get; set; }
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
        public DateTime? ActReleaseDate { get; set; }
        public DateTime? ActOnShelfDate { get; set; }
        public DateTime? ActLoadingDate { get; set; }
        public DateTime? ActStartDate { get; set; }
        public DateTime? ActFinishDate { get; set; }
        public DateTime? ActUnloadingDate { get; set; }
        public DateTime? ActOutboundDate { get; set; }
        public int ActInboundTime { get; set; }
        public int ActMachineTime { get; set; }
        public int ActLoadingTime { get; set; }
        public int ActUnloadTime { get; set; }
        public int ActOutboundTime { get; set; }
        public decimal? ActInboundTime1 { get; set; }
        public decimal? ActMachineTime1 { get; set; }
        public decimal? ActLoadingTime1 { get; set; }
        public decimal? ActUnloadTime1 { get; set; }
        public decimal? ActOutboundTime1 { get; set; }
        public int MaintenanceTime { get; set; }
        public int BreakdownTime { get; set; }
        public string BreakdownType { get; set; }
        public int SetupTime { get; set; }
    }
}
