using Eureka.Core.Domain.Payables;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Views.Payables
{
    public interface IVendorListView
    {        
        event EventHandler Form_Load;
        event EventHandler OK_Click;
        event EventHandler Filter_Click;
        event EventHandler Clear_Click;
        event EventHandler Selecting_Row;
        event EventHandler PreviousPage;
        event EventHandler NextPage;

        int pageNumber { get; set; }
        IPagedList<VendorModel> list { get; set; }
        string VendorNumber { get; set; }
        string VendorName { get; set; }
        List<VendorModel> vendors { get; set; }
        VendorModel vendorSelected { get; set; }
        void BindingData(IPagedList<VendorModel> list);
        void CloseMe();
    }
}
