using Eureka.Core.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Views.Inventory
{
    public interface IMaterialReturnEntryView : IView
    {
        event EventHandler Form_Load;
        event EventHandler OK_Click;
        event EventHandler Cancel_Click;

        SequenceDocModel rowDoc { get; set; }
        int running { get; set; }
        string returnNumber { get; set; }
        DateTime TransactionDate { get; set; }

        void CloseForm();
    }
}
