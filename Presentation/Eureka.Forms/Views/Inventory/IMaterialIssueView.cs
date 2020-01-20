using Eureka.Core.Domain.Inventory;
using Eureka.Core.Domain.Projects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Inventory
{
    public interface IMaterialIssueView : IView
    {
        event EventHandler Form_Load;
        event EventHandler Filter_Click;
        //event EventHandler Filter_Clear;
        //event EventHandler Issue_Click;
        event EventHandler Find_Project;
        event EventHandler Issue_Entry;

        event EventHandler Insert_Cache;
        event EventHandler Delete_Cache;
        event EventHandler Clear_Cache;
        event EventHandler Project_Change;
        event EventHandler CostCode_Change;

        string projNo { get; set; }
        string bomNo { get; set; }
        string itemNo { get; set; }

        string forProjectNo { get; set; }
        string forCostCode { get; set; }

        BindingSource bindingHead { get; set; }
        BindingSource bindingCache { get; set; }

        IEnumerable<ItemOnhandModel> onhands { get; set; }
        IEnumerable<ItemOnhandModel> onhandsSelected { get; set; }
        IEnumerable<ItemOnhandModel> onhandsCache { get; set; }
        IEnumerable<ProjectModel> projs { get; set; }
        IEnumerable<ProjectCostModel> costs { get; set; }

        void BindingData(List<ItemOnhandModel> list);
        void BindingCache(List<ItemOnhandModel> list);
        void BindingComboProjects(List<ProjectModel> projs);
        void BindingComboProjectsCost(List<ProjectCostModel> costs);
    }
}
