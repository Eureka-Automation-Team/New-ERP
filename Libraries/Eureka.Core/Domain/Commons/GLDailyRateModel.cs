using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Commons
{
    public class GLDailyRateModel
    {
        public int RateTransId { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public Nullable<DateTime> ConversionDate { get; set; }
        public double ConversionRate { get; set; }
        public string ConversionType { get; set; }
        public string StatusCode { get; set; }
        public Nullable<DateTime> LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public Nullable<DateTime> CreationDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
