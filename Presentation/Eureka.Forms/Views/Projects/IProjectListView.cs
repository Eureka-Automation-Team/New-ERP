using Eureka.Core.Domain.Projects;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Views.Projects
{
    public interface IProjectListView
    {
        event EventHandler Form_Load;
        event EventHandler OK_Click;
        event EventHandler Filter_Click;
        event EventHandler Clear_Click;
        event EventHandler Selecting_Row;
        event EventHandler PreviousPage;
        event EventHandler NextPage;

        int pageNumber { get; set; }
        IPagedList<ProjectModel> list { get; set; }
        string projectNum { get; set; }
        List<ProjectModel> projects { get; set; }
        List<ProjectModel> projSelected { get; set; }
        DateTime startDate { get; set; }
        DateTime endDate { get; set; }
        void BindingData(IPagedList<ProjectModel> list);
        void CloseMe();
    }
}
