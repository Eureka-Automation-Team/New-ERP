using Eureka.Core.Domain.Projects;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Views.Projects
{
    public interface IBomNumberListView
    {
        event EventHandler Form_Load;
        event EventHandler OK_Click;
        event EventHandler Filter_Click;
        event EventHandler Clear_Click;
        event EventHandler Selecting_Row;
        event EventHandler PreviousPage;
        event EventHandler NextPage;

        int pageNumber { get; set; }
        IPagedList<BomNumberModel> list { get; set; }
        string bomNumber { get; set; }
        List<BomNumberModel> bomNumbers { get; set; }
        BomNumberModel bomSelected { get; set; }
        void BindingData(IPagedList<BomNumberModel> list);
        void CloseMe();
    }
}
