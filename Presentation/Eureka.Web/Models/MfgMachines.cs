using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class MfgMachines
    {
        public int MachineId { get; set; }
        public string MachineCode { get; set; }
        public string IpAddress { get; set; }
        public int? Port { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreatedBy { get; set; }
        public string EnableFlag { get; set; }
        public string ActiveFlag { get; set; }
        public string Type { get; set; }
        public string MachineGroup { get; set; }
        public string ProductionLine { get; set; }
        public string PlantId { get; set; }
        public string MachineModel { get; set; }
        public string Shift1 { get; set; }
        public string Shift2 { get; set; }
        public string ShiftOt { get; set; }
        public int? CalendarId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? WorkingHr { get; set; }
        public short? Mon { get; set; }
        public short? Tue { get; set; }
        public short? Wed { get; set; }
        public short? Thu { get; set; }
        public short? Fri { get; set; }
        public short? Sat { get; set; }
        public short? Sun { get; set; }
        public int? LunchHr { get; set; }
        public string StimeLunchHr { get; set; }
        public string EtimeLunchHr { get; set; }
        public int? MaintenanceTime { get; set; }
    }
}
