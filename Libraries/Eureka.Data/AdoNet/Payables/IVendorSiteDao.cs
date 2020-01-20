using Eureka.Core.Domain.Payables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Payables
{
    public interface IVendorSiteDao
    {
        // gets a specific Member
        VendorSiteModel GetByID(int id);

        // gets a specific Member
        List<VendorSiteModel> GetByVendorID(int id);

        // gets a specific Member by email
        List<VendorSiteModel> GetByVendorNum(string number);

        // gets a sorted list of all Members
        List<VendorSiteModel> GetAll();

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(VendorSiteModel model);

        // updates a Member
        void Update(VendorSiteModel model);

        // deletes a Member
        void Delete(VendorSiteModel model);
    }
}
