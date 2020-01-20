using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Inventory;
using Eureka.Data;

namespace Eureka.Services.Inventory
{
    public class ShelfLocationSrv : IShelfLocationSrv
    {
        private static readonly string provider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly IFactory factory = Factories.GetFactory(provider);

        public List<ShelfLocationModel> GetAll()
        {
            return factory.ShelfLocationDao.GetAll();
        }

        public List<ShelfLocationModel> GetAllAvailable()
        {
            return factory.ShelfLocationDao.GetAllAvailable();
        }

        public List<ShelfLocationModel> GetAllReserved()
        {
            return factory.ShelfLocationDao.GetAllReserved();
        }

        public ShelfLocationModel GetLocationByID(int locationId)
        {
            return factory.ShelfLocationDao.GetByID(locationId);
        }

        public int InsertLocation(ShelfLocationModel model)
        {
            model.CreationDate = DateTime.Now;
            model.LastUpdateDate = DateTime.Now;
            return factory.ShelfLocationDao.Insert(model);
        }

        public void UpdateLocation(ShelfLocationModel model)
        {
            model.LastUpdateDate = DateTime.Now;
            factory.ShelfLocationDao.Update(model);
        }

        public void DeleteLocation(ShelfLocationModel model)
        {
            factory.ShelfLocationDao.Delete(model);
        }
    }
}
