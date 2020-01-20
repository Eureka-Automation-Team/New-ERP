using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Payables;
using Eureka.Data;

namespace Eureka.Services.Payables
{
    public class PayablesSrv : IPayablesSrv
    {
        private static readonly string provider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly IFactory factory = Factories.GetFactory(provider);

        public List<TermModel> GetTermAll()
        {
            return factory.TermDao.GetAll();
        }

        public TermModel GetTermByCode(string code)
        {
            return factory.TermDao.GetByCode(code);
        }

        public List<VendorModel> GetVendorAll()
        {
            return factory.VendorDao.GetAll();
        }

        public VendorModel GetVendorByID(int id)
        {
            return factory.VendorDao.GetByID(id);
        }

        public VendorSiteModel GetVendorSiteByID(int siteId)
        {
            return factory.VendorSiteDao.GetByID(siteId);
        }

        public List<VendorSiteModel> GetVendorSiteByVendorID(int vendorId)
        {
            return factory.VendorSiteDao.GetByVendorID(vendorId);
        }
    }
}
