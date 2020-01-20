using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class MstShift
    {
        public int ShiftId { get; set; }
        public string ShiftCode { get; set; }
        public string ShiftDesc { get; set; }
        public short? Mon { get; set; }
        public short? Tue { get; set; }
        public short? Wed { get; set; }
        public short? Thu { get; set; }
        public short? Fri { get; set; }
        public short? Sat { get; set; }
        public short? Sun { get; set; }
        public string Stime { get; set; }
        public string Etime { get; set; }
        public int Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public Guid? RowPoiter { get; set; }
    }
}
