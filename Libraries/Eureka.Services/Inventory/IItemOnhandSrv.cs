using Eureka.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Services.Inventory
{
    public interface IItemOnhandSrv
    {
        ItemOnhandModel GetByID(int id);

        ItemOnhandModel GetDupplicated(int itemId, string subInventory, string lotNo, string bomNo);

        List<ItemOnhandModel> GetBySubinventoryCode(string subCode);

        List<ItemOnhandModel> GetByItemID(string itemId);

        List<ItemOnhandModel> GetByLotNo(string lotNo);

        List<ItemOnhandModel> GetAll();

        int InsertOnhand(ItemOnhandModel model);
        void UpdateOnhand(ItemOnhandModel model);
        void DeleteOnhand(ItemOnhandModel model);
    }
}
