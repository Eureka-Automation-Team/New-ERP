using Eureka.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Services.Inventory
{
    public interface IShelfLocationSrv
    {
        //GET
        ShelfLocationModel GetLocationByID(int locationId);
        List<ShelfLocationModel> GetAll();
        List<ShelfLocationModel> GetAllAvailable();
        List<ShelfLocationModel> GetAllReserved();
        //POST
        int InsertLocation(ShelfLocationModel model);
        void DeleteLocation(ShelfLocationModel model);
        void UpdateLocation(ShelfLocationModel model);
    }
}
