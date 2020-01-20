using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class DocSequencesDefine
    {
        public int DocSequenceId { get; set; }
        public string Prefix { get; set; }
        public string DocTypeCode { get; set; }
        public int Nextval { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public int? RunningDigit { get; set; }
    }
}
