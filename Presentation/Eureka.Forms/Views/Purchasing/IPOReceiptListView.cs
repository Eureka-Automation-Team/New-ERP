using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Views.Purchasing
{
    public interface IPOReceiptListView : IView
    {
        event EventHandler Form_Load;
        event EventHandler OK_Click;
        event EventHandler Filter_Click;
        event EventHandler Clear_Click;
        event EventHandler Selecting_Row;

        string rcvNum { get; set; }
        string vendorNum { get; set; }
        DateTime startDate { get; set; }
        DateTime endDate { get; set; }
        string rcvMethod { get; set; }
        List<POReceiptHeaderModel> rcvs { get; set; }
        List<POReceiptHeaderModel> rcvsSelected { get; set; }
        void BindingData(List<POReceiptHeaderModel> list);
        void CloseMe();
    }
}
