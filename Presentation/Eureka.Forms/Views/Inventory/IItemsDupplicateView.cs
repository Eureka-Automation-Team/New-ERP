using Eureka.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Forms.Views.Inventory
{
    public interface IItemsDupplicateView
    {
        event EventHandler Form_Load;
        event EventHandler Copy_Click;
        event EventHandler Selecting_Row;

        BindingSource SourceBinding { get; set; }
        List<ItemMasterModel> items { get; set; }
        List<ItemMasterModel> itemsSelected { get; set; }
        void BindingGrid();
        void CloseMe();
    }
}
