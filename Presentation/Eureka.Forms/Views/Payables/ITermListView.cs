using Eureka.Core.Domain.Payables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Views.Payables
{
    public interface ITermListView
    {
        event EventHandler Form_Load;
        event EventHandler OK_Click;
        event EventHandler Filter_Click;
        event EventHandler Clear_Click;
        event EventHandler Selecting_Row;

        string TermCode { get; set; }
        List<TermModel> terms { get; set; }
        TermModel termSelected { get; set; }
        void BindingData(List<TermModel> list);
        void CloseMe();
    }
}
