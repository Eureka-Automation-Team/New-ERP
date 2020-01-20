using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class PlnCalendar
    {
        public int CalendarId { get; set; }
        public int? YearNum { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
