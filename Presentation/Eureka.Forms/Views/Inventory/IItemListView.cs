using Eureka.Core.Domain.Inventory;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Inventory
{
    public interface IItemListView : IView
    {
        event EventHandler Form_Load;
        event EventHandler OK_Click;
        event EventHandler Filter_Click;
        event EventHandler Clear_Click;
        event EventHandler Selecting_Row;
        event EventHandler PreviousPage;
        event EventHandler NextPage;

        BindingSource BindingSource { get; set; }
        int pageNumber { get; set; }
        IPagedList<ItemMasterModel> list { get; set; }
        string itemCode { get; set; }
        string itemDescription { get; set; }
        string manuId { get; set; }
        string brandMat { get; set; }
        List<ItemMasterModel> items { get; set; }
        ItemMasterModel itemSelected { get; set; }
        void BindingData(IPagedList<ItemMasterModel> list);
        void CloseMe();
    }
}
