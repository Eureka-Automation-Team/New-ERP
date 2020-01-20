using Eureka.Core.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Views.Payables
{
    public interface ITaxCodeListView
    {
        event EventHandler Form_Load;
        event EventHandler OK_Click;
        event EventHandler Filter_Click;
        event EventHandler Clear_Click;
        event EventHandler Selecting_Row;

        string taxCode { get; set; }
        List<TaxCodeModel> taxCodes { get; set; }
        TaxCodeModel taxSelected { get; set; }
        void BindingData(List<TaxCodeModel> list);
        void CloseMe();
    }
}
