using Eureka.Core.Domain.Projects;
using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Views.Purchasing
{
    public interface IPOReceiptView : IView
    {
        event EventHandler Form_Load;
        event EventHandler Filter_Click;
        event EventHandler Save_Click;
        event EventHandler New_Click;
        event EventHandler GenerateGRN;
        event EventHandler Seleted_RCV;
        event EventHandler Find_Vendor;
        event EventHandler Get_GRN;
        event EventHandler Print_Received;
        event EventHandler Seleted_Line;
        event EventHandler Confirm_QC;
        event EventHandler Delete_Row;
        event EventHandler Test_Object;
        event EventHandler Received_Click;
        event EventHandler GetPO;
        //event EventHandler Refresh_Click;
        event EventHandler Method_Change;

        POReceiptHeaderModel headSeleted { get; set; }
        POReceiptLineModel lineSeleted { get; set; }
        POReceiptLineModel lineInspection { get; set; }
        IEnumerable<POReceiptHeaderModel> receipts { get; set; }
        IEnumerable<POReceiptLineModel> rcvLines { get; set; }
        IEnumerable<CostGroupModel> costs { get; set; }
        string grnFileter { get; set; }


        void BindingRcvHead(IEnumerable<POReceiptHeaderModel> list);
        void BindingRcvLines(IEnumerable<POReceiptLineModel> list);
        void LineRefresh();

    }
}
