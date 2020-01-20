using Eureka.Core.Domain.Payables;
using System.Collections.Generic;

namespace Eureka.Services.Payables
{
    public interface IPayablesSrv
    {
        List<TermModel> GetTermAll();
        TermModel GetTermByCode(string code);
        List<VendorModel> GetVendorAll();

        VendorModel GetVendorByID(int id);

        VendorSiteModel GetVendorSiteByID(int siteId);

        List<VendorSiteModel> GetVendorSiteByVendorID(int vendorId);
    }
}