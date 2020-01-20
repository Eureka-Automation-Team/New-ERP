using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Commons
{
    public class TaxCodeModel
    {
        public int TaxId { get; set; }
        [DisplayName("Code")]
        public string TaxCode { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Rate")]
        public double TaxRate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }

    }
}
