using Eureka.Core.Domain.Commons;
using Eureka.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Services.Inventory
{
    public interface IItemTransactionSrv
    {
        List<ItemTransactionModel> GetTransAll();

        ItemTransactionModel GetTransByID(int id);

        List<ItemTransactionModel> GetTransByItemID(int itemId);

        List<ItemTransactionModel> GetTransByDate(DateTime startDate, DateTime endDate);

        List<ItemTransactionModel> GetTransByStartDate(DateTime startDate);

        string GenIssueNumber(string type);

        SequenceDocModel GetSequenceDoc(string type);

        void UpdateDoc(SequenceDocModel model);

        int InsertTrans(ItemTransactionModel model);
        void UpdateTrans(ItemTransactionModel model);
        void DeleteTrans(ItemTransactionModel model);
    }
}
