using Eureka.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Inventory
{
    public interface IItemMasterDao
    {
        // gets a specific Member
        ItemMasterModel GetByID(int id);

        // gets a specific Member by email
        ItemMasterModel GetByNumber(string number);

        // gets a specific Member by email
        ItemMasterModel GetByManuID(string manuId);

        // gets a sorted list of all Members
        List<ItemMasterModel> GetAll();

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(ItemMasterModel model);

        // updates a Member
        void Update(ItemMasterModel model);

        // deletes a Member
        void Delete(ItemMasterModel model);
    }
}
