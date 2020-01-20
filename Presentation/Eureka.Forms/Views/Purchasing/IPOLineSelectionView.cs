using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Views.Purchasing
{
    public interface IPOLineSelectionView : IView
    {
        event EventHandler Form_Load;
        event EventHandler SearchPO_Click;
        //event EventHandler SelectAll_Checked;
        event EventHandler OK_Click;

        bool selectAll { get; set; }
        int vendorId { get; set; }
        string poNumber { get; set; }
        string rcvMethod { get; set; }
        POHeaderModel po { get; set; }
        List<POLineModel> line { get; set; }

        List<POLineModel> linesSelected { get; set; }
        void BindingData(List<POLineModel> list);
        void CloseMe();
    }
}
