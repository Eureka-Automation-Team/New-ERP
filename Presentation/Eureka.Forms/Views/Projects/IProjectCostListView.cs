using Eureka.Core.Domain.Projects;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Projects
{
    public interface IProjectCostListView
    {
        event EventHandler Form_Load;
        event EventHandler OK_Click;
        event EventHandler Filter_Click;
        event EventHandler Clear_Click;
        event EventHandler Selecting_Row;
        event EventHandler PreviousPage;
        event EventHandler NextPage;
        
        BindingSource bindingLine { get; set; }
        int pageNumber { get; set; }
        string projectNum { get; set; }
        IPagedList<ProjectCostModel> list { get; set; }
        string costCode { get; set; }
        List<ProjectCostModel> projectCosts { get; set; }
        List<ProjectCostModel> projCostSelected { get; set; }

        void BindingData(IPagedList<ProjectCostModel> list);
        void CloseMe();
    }
}
