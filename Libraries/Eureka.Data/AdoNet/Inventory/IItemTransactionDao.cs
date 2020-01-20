using Eureka.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Inventory
{
    public interface IItemTransactionDao
    {
        // gets a specific Member
        ItemTransactionModel GetByID(int id);

        // gets a sorted list of all Members
        List<ItemTransactionModel> GetItemID(int id);

        // gets a specific Member by email
        List<ItemTransactionModel> GetByDate(DateTime startDate, DateTime endDate);

        // gets a sorted list of all Members
        List<ItemTransactionModel> GetAll();

        List<ItemTransactionModel> GetByStartDate(DateTime trxDate);

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(ItemTransactionModel model);

        // updates a Member
        void Update(ItemTransactionModel model);

        // deletes a Member
        void Delete(ItemTransactionModel model);
    }
}
