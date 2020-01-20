using Eureka.Core.Domain.Purchasing;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Views.Purchasing
{
    public interface IPOListView : IView
    {
        event EventHandler Form_Load;
        event EventHandler OK_Click;
        event EventHandler Filter_Click;
        event EventHandler Clear_Click;
        event EventHandler Selecting_Row;
        event EventHandler PreviousPage;
        event EventHandler NextPage;

        int pageNumber { get; set; }
        IPagedList<POHeaderModel> list { get; set; }
        string poNum { get; set; }
        string buyer { get; set; }
        int vendorId { get; set; }
        DateTime startDate { get; set; }
        DateTime endDate { get; set; }
        List<POHeaderModel> pos { get; set; }
        List<POHeaderModel> posSelected { get; set; }
        void BindingData(IPagedList<POHeaderModel> list);
        void CloseMe();

        //async Task<IPagedList<POHeaderModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 10);
    }
}
