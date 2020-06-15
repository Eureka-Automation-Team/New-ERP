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
    public interface IPOEntryView : IView
    {
        event EventHandler Form_Load;
        event EventHandler Filter_Click;
        event EventHandler Save_Click;
        event EventHandler New_Click;
        event EventHandler SubmitPO_Click;
        event EventHandler UnSubmitPO_Click;
        event EventHandler Approved_Click;
        event EventHandler Find_Vendor;
        event EventHandler Find_Term;
        event EventHandler Find_Currency;
        event EventHandler Find_TaxCode;
        event EventHandler Find_Project;
        event EventHandler Seleted_PO;
        event EventHandler Paste_Rows;
        event EventHandler Delete_Row;
        event EventHandler Print_PO;
        event EventHandler Type_Change;
        event EventHandler GetLine_Selected;
        event EventHandler Refresh_Click;
        event EventHandler Cancel_Click;
        event EventHandler Cancel_Line;
        event EventHandler LineAdjustment;

        POHeaderModel poHead { get; set; }
        POLineModel poLineSelected { get; set; }
        List<POLineModel> poLine { get; set; }
        List<POHeaderModel> poList { get; set; }
        List<CostGroupModel> costs { get; set; }
        List<ProjectCostModel> projBudget { get; set; }
        BindingSource bindingHead { get; set; }
        BindingSource bindingBudgetLines { get; set; }


        void BindingPO(List<POHeaderModel> list);
        void BindingLines(List<POLineModel> list);
        void BindingBudgetLines(List<ProjectCostModel> list);
        void PasteClipboard();
        void ActiveJobFlag(string type);
        void RefreshBudgetGrid();
        string GetNote();
    }
}
