using Eureka.Core.Domain.Inventory;
using Eureka.Core.Domain.Projects;
using Eureka.Core.Domain.Purchasing;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Purchasing
{
    public interface IRequisitionEntryView : IView
    {
        event EventHandler Form_Load;
        //event EventHandler Filter_Click;
        event EventHandler Save_Click;
        event EventHandler New_Click;
        event EventHandler New_Line;
        event EventHandler BOM_Changed;
        event EventHandler CostCode_Changed;
        event EventHandler Find_Requester;
        event EventHandler Find_Approver;
        event EventHandler Find_Boms;
        event EventHandler Find_Items;
        event EventHandler GetLine_Selected;
        event EventHandler Find_Project;
        event EventHandler Selection_Change;
        event EventHandler PasteStandard_Rows;
        event EventHandler PasteMaking_Rows;
        event EventHandler Delete_Row;
        event EventHandler DuplicateList_Click;
        
        //event EventHandler Type_Change;
        event EventHandler Refresh_Click;
        event EventHandler ValidateCells;
        //event EventHandler ValidateLine;
        event EventHandler Set_DueDate;
        event EventHandler SendPOConfirm_Click;
        event EventHandler Submit_Click;
        event EventHandler UnSubmit_Click;
        event EventHandler Approved_Click;
        event EventHandler ConvertPO_Click;
        event EventHandler SendLinePOConfirm_Click;

        event EventHandler LineSubmit_Click;
        event EventHandler LineUnSubmit_Click;
        event EventHandler LineApprove_Click;
        event EventHandler LineReject_Click;

        List<ItemMasterModel> items { get; set; }
        BindingSource bindingLine { get; set; }
        BindingSource bindingBudgetLines { get; set; }
        RequisitionHeaderModel reqHead { get; set; }
        List<ProjectModel> projects { get; set; }
        List<ProjectCostModel> projectCosts { get; set; }
        ProjectModel projHead { get; set; }
        List<RequisitionLineModel> reqLines { get; set; }
        List<ProjectCostModel> projBudget { get; set; }
        List<RequisitionLineModel> reqLinesSelected { get; set; }
        List<RequisitionHeaderModel> reqHeaderList { get; set; }
        CostGroupModel costSelected { get; set; }


        void BindingTree(List<ProjectModel> prjList,List<RequisitionHeaderModel> reqList);
        void BindingLines(List<RequisitionLineModel> list);
        void BindingComboCost(List<CostGroupModel> costs);
        void ActiveJobFlag(string type);
        void DisableBomSelecting();
        void EnableBomSelecting();
        void BindingRequisitionByProject(List<RequisitionHeaderModel> list, ProjectModel prj);
        void BindingBudgetLines(List<ProjectCostModel> list);
        void RefreshGird();
    }
}
