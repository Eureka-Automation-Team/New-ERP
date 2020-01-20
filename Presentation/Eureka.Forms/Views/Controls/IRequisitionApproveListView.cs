using Eureka.Core.Domain.Purchasing;
using Eureka.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Forms.Views.Controls
{
    public interface IRequisitionApproveListView
    {
        event EventHandler Form_Load;
        event EventHandler Refresh_Click;
        event EventHandler Approve_Click;
        event EventHandler Reject_Click;

        UserModel approver { get; set; }
        List<RequisitionLineModel> linesSelected { get; set; }
        List<RequisitionLineModel> Approvalslines { get; set; }

        BindingSource bindingLines { get; set; }
        void RefreshLinesGird();
    }
}
