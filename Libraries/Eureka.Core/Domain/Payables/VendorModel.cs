using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Payables
{
    public class VendorModel
    {
        public int VendorId { get; set; }        
        public string VendorNumber { get; set; }
        public string VendorName { get; set; }
        public string EnabledFlag { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public string VendorType { get; set; }
        public int TermsId { get; set; }
        public string TermCode { get; set; }
        public string InvoiceCurrencyCode { get; set; }
        public string PaymentCurrencyCode { get; set; }
        public string VatCode { get; set; }
        public DateTime StartDataActive { get; set; }
        public DateTime EndDateActive { get; set; }
        public string VatRegistrationNum { get; set; }

    }
}
