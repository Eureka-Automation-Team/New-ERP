using Eureka.Core.Domain.Projects;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Projects
{
    public interface IBudgetControlView : IView
    {
        event EventHandler Form_Load;
        event EventHandler Search_Click;
        event EventHandler Save_Click;
        event EventHandler Clear_Click;
        event EventHandler Delete_Click;
        event EventHandler Selected_Project;
        event EventHandler Reset_Cost;
        event EventHandler Paste_Rows;
        event EventHandler Delete_Row;
        event EventHandler GetLine_Selected;

        BindingSource bindingBudgets { get; set; }
        MetroProgressBar progression { get; set; }

        string projectFilter { get; set; }
        ProjectModel projectSelected { get; set; }
        List<ProjectModel> projects { get; set; }
        List<ProjectCostModel> projectCosts { get; set; }
        List<CostGroupModel> costs { get; set; }
        ProjectCostModel costSelected { get; set; }

        void BindingProjectsGrid(List<ProjectModel> list);
        void BindingCost(List<ProjectCostModel> list);
        void PasteClipboard();
    }
}
