using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Commons
{
    public class CurrencyModel
    {
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> ConversionDate { get; set; }
        public double ConversionRate { get; set; }
        public bool EnableFlag { get; set; }
        public Nullable<DateTime> LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public Nullable<DateTime> CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<DateTime> StartDateActive { get; set; }
        public Nullable<DateTime> EndDateActive { get; set; }
    }
}
