using Eureka.Core.Domain.Commons;
using Eureka.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Services.Inventory
{
    public interface IItemMasterSrv
    {
        List<ItemMasterModel> GetItemAll();

        ItemMasterModel GetItemByID(int id);

        ItemMasterModel GetItemByNumber(string number);

        ItemMasterModel GetItemByManuId(string manuId);

        string GetRunningLotByItemID(int id);

        string GenLotNumber(string type);

        int InsertItem(ItemMasterModel model);
        void UpdateItem(ItemMasterModel model);
        void DeleteItem(ItemMasterModel model);

        void UpdateDoc(SequenceDocModel model);
    }
}
