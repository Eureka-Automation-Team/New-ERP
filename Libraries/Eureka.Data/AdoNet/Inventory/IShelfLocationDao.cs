using Eureka.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Inventory
{
    public interface IShelfLocationDao
    {
        ShelfLocationModel GetByID(int id);

        List<ShelfLocationModel> GetAllAvailable();

        List<ShelfLocationModel> GetAllReserved();

        List<ShelfLocationModel> GetAll();

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(ShelfLocationModel model);

        // updates a Member
        void Update(ShelfLocationModel model);

        // deletes a Member
        void Delete(ShelfLocationModel model);
    }
}
