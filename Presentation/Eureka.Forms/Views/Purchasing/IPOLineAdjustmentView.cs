using Eureka.Core.Domain.Purchasing;
using Eureka.Froms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Forms.Views.Purchasing
{
    public interface IPOLineAdjustmentView : IView
    {
        event EventHandler FormLoad;
        event EventHandler SaveAdjust;

        BindingSource bindingSource { get; set; }

        List<POLineModel> poLines { get; set; }
        List<POLineModel> poLinesTemp { get; set; }

        void FormClose();
    }
}
