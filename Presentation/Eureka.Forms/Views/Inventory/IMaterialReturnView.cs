using Eureka.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Inventory
{
    public interface IMaterialReturnView : IView
    {
        //event EventHandler Form_Load;
        event EventHandler Filter_Click;
        event EventHandler AddLine_Click;
        event EventHandler Find_Project;
        //event EventHandler Find_Item;
        event EventHandler Save_Click;
        event EventHandler Delete_Click;

        BindingSource bindingMaterialsTrans { get; set; }
        BindingSource bindingReturnLines { get; set; }

        List<ItemTransactionModel> materialsTrans { get; set; }
        List<ItemTransactionModel> materialsReturn { get; set; }

        string projNumber { get; set; }
        string itemFilter { get; set; }
        DateTime transDate { get; set; }

        void BindingTrans();
        void BindingReturns();
    }
}
