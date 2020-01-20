using Eureka.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Inventory
{
    public interface IItemOnhandDao
    {
        // gets a specific Member
        ItemOnhandModel GetByID(int id);

        ItemOnhandModel GetDupplicated(int itemId, string subInventory, string lotNo, string bomNo);

        // gets a specific Member by email
        List<ItemOnhandModel> GetBySubinventoryCode(string subCode);

        List<ItemOnhandModel> GetByItemID(string itemId);

        List<ItemOnhandModel> GetByLotNo(string lotNo);

        // gets a sorted list of all Members
        List<ItemOnhandModel> GetAll();

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(ItemOnhandModel model);

        // updates a Member
        void Update(ItemOnhandModel model);

        // deletes a Member
        void Delete(ItemOnhandModel model);
    }
}
