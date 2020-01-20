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
    public interface IRequisitionListView : IView
    {
        event EventHandler Form_Load;
        event EventHandler OK_Click;
        event EventHandler Filter_Click;
        event EventHandler Clear_Click;
        event EventHandler Selecting_Row;
        //event EventHandler PreviousPage;
        //event EventHandler NextPage;

        BindingSource bindingHead { get; set; }
        int pageNumber { get; set; }
        IPagedList<RequisitionHeaderModel> list { get; set; }
        string projectNo { get; set; }
        string requisitonNo { get; set; }
        DateTime startDate { get; set; }
        DateTime endDate { get; set; }
        List<RequisitionHeaderModel> prs { get; set; }
        List<RequisitionHeaderModel> prsSelected { get; set; }
        void BindingData(IPagedList<RequisitionHeaderModel> list);
        void CloseMe();
    }
}
