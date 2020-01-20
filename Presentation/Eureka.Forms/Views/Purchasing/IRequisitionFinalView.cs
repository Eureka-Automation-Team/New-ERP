using Eureka.Core.Domain.Inventory;
using Eureka.Core.Domain.Projects;
using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Purchasing
{
    public interface IRequisitionFinalView : IView
    {
        event EventHandler Form_Load;
        event EventHandler Filter_Click;
        event EventHandler Save_Changed;

        event EventHandler Find_Project;
        event EventHandler Find_Bom;
        event EventHandler Find_Requistion;
        event EventHandler Find_Item;
        event EventHandler Find_Vendor;
        event EventHandler Set_Vendor;
        event EventHandler Change_Cost;

        event EventHandler ConvertPO_Click;
        //event EventHandler SetVendor_Click;
        event EventHandler Reject_Click;
        event EventHandler ConfirmPrice_Click;
        event EventHandler UnConfirmPrice_Click;
        //event EventHandler CheckAll_Click;
        event EventHandler Selection_Changed;
        event EventHandler Set_DueDate;
        event EventHandler Refresh_Lines;
        event EventHandler Sorting_Changed;

        List<RequisitionLineModel> linesSelected { get; set; }
        List<RequisitionLineModel> reqLines { get; set; }
        List<ProjectCostModel> projBudget { get; set; }

        ProjectModel projectParam { get; set; }
        BomNumberModel bomsParam { get; set; }
        RequisitionHeaderModel reqheadParam { get; set; }
        ItemMasterModel itemsParam { get; set; }

        BindingSource bindingLines { get; set; }
        BindingSource bindingBudgetLines { get; set; }

        string projectNumber { get; set; }
        string bomNumber { get; set; }
        string requisitionNumber { get; set; }
        string itemNumber { get; set; }
        string vendorName { get; set; }

        bool CheckAll { get; set; }
        bool pendingParam { get; set; }
        bool rejectParam { get; set; }
        bool confirmedParam { get; set; }
        //bool purchasedParam { get; set; }

        string SortBy { get; set; }
        string SortType { get; set; }

        void BindingLines(List<RequisitionLineModel> list);
        void BindingBudgetLines(List<ProjectCostModel> list);

        void BindCheckBox();
        void RefreshLinesGird();
        void RefreshBudgetGrid();
    }
}
