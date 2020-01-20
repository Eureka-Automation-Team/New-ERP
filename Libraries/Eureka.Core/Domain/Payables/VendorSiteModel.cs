using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Payables
{
    public class VendorSiteModel
    {
        public int VendorSiteId { get; set; }
        public int VendorId { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public string PaySiteFlag { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Province { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax1 { get; set; }
        public string Fax2 { get; set; }
        public int ShipToLocationId { get; set; }
        public int BillToLocationId { get; set; }
        public string VatCode { get; set; }
        public int TermsId { get; set; }
        public string InvoiceCurrencyCode { get; set; }
        public string VatRegistrationNum { get; set; }

    }
}
