using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class ViewMachineMonitoring
    {
        public string MachineCode { get; set; }
        public decimal? WorkingTimeHr { get; set; }
        public decimal? WorkingTimeMm { get; set; }
        public decimal? StandardTimeMm { get; set; }
        public decimal? StandardTimeHh { get; set; }
        public DateTime? TranactionDate { get; set; }
        public decimal? JoborderQty { get; set; }
        public int? ReleaseQty { get; set; }
        public int? CompleteQty { get; set; }
        public decimal? PlanningQty { get; set; }
        public int? QtyPass { get; set; }
        public int? QtyReject { get; set; }
        public int? QtyHold { get; set; }
        public int QtyRework { get; set; }
        public decimal? PlanningTimeHr { get; set; }
        public decimal? PlanningTimeMm { get; set; }
        public decimal? InboundTimeMm { get; set; }
        public decimal? MachineTimeMm { get; set; }
        public decimal? LoadingTimeMm { get; set; }
        public decimal? UnloadTimeMm { get; set; }
        public decimal? OutboundTimeMm { get; set; }
        public decimal? InboundTimeHr { get; set; }
        public decimal? MachineTimeHr { get; set; }
        public decimal? LoadingTimeHr { get; set; }
        public decimal? UnloadTimeHr { get; set; }
        public decimal? OutboundTimeHr { get; set; }
        public int? MaintenanceTime { get; set; }
        public int? BreakdownTime { get; set; }
        public int? SetupTime { get; set; }
        public decimal? Avialability { get; set; }
        public decimal? ProductionPlanningTime { get; set; }
        public decimal? ProductionRunningTime { get; set; }
        public decimal? Performance { get; set; }
    }
}
