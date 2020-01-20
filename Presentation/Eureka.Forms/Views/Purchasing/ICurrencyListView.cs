using Eureka.Core.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Purchasing
{
    public interface ICurrencyListView
    {
        event EventHandler Form_Load;
        event EventHandler OK_Click;
        event EventHandler Filter_Click;
        event EventHandler Clear_Click;
        event EventHandler Selecting_Row;

        BindingSource bindingCurrency { get; set; }
        string currencyCode { get; set; }
        List<CurrencyModel> currencies { get; set; }
        CurrencyModel currSelected { get; set; }
        void BindingData();
        void CloseMe();
    }
}
