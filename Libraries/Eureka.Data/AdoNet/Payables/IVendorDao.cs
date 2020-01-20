using Eureka.Core.Domain.Payables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Payables
{
    public interface IVendorDao
    {
        // gets a specific Member
        VendorModel GetByID(int id);

        // gets a specific Member by email
        VendorModel GetByNum(string number);

        // gets a sorted list of all Members
        List<VendorModel> GetAll();

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(VendorModel model);

        // updates a Member
        void Update(VendorModel model);

        // deletes a Member
        void Delete(VendorModel model);
    }
}
