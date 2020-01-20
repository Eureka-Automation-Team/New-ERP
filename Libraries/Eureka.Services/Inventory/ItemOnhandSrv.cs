using Eureka.Core.Domain.Inventory;
using Eureka.Data;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Eureka.Services.Inventory
{
    public class ItemOnhandSrv : IItemOnhandSrv
    {
        private static readonly string provider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly IFactory factory = Factories.GetFactory(provider);

        public List<ItemOnhandModel> GetAll()
        {
            return factory.ItemOnhandDao.GetAll();
        }

        public ItemOnhandModel GetByID(int id)
        {
            return factory.ItemOnhandDao.GetByID(id);
        }

        public List<ItemOnhandModel> GetByItemID(string itemId)
        {
            return factory.ItemOnhandDao.GetByItemID(itemId);
        }

        public List<ItemOnhandModel> GetByLotNo(string lotNo)
        {
            return factory.ItemOnhandDao.GetByLotNo(lotNo);
        }

        public List<ItemOnhandModel> GetBySubinventoryCode(string subCode)
        {
            return factory.ItemOnhandDao.GetBySubinventoryCode(subCode);
        }

        public int InsertOnhand(ItemOnhandModel model)
        {
            model.CreationDate = DateTime.Now;
            model.LastUpdateDate = DateTime.Now;

            return factory.ItemOnhandDao.Insert(model);
        }

        public void UpdateOnhand(ItemOnhandModel model)
        {
            model.LastUpdateDate = DateTime.Now;
            factory.ItemOnhandDao.Update(model);
        }

        public void DeleteOnhand(ItemOnhandModel model)
        {
            factory.ItemOnhandDao.Delete(model);
        }

        public ItemOnhandModel GetDupplicated(int itemId, string subInventory, string lotNo, string  bomNo)
        {
            return factory.ItemOnhandDao.GetDupplicated(itemId, subInventory, lotNo, bomNo);
        }
    }
}