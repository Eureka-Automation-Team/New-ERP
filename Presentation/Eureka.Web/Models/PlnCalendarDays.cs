using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class PlnCalendarDays
    {
        public int DayId { get; set; }
        public int CalendarId { get; set; }
        public DateTime AsOfDate { get; set; }
        public int? ShiftDay { get; set; }
        public int? ShiftNight { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
