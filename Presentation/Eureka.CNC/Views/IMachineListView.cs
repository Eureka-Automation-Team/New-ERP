using Eureka.Core.Domain.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.Views
{
    public interface IMachineListView
    {
        event EventHandler Form_Load;
        event EventHandler OK_Click;
        event EventHandler Filter_Click;
        event EventHandler Clear_Click;
        event EventHandler Selecting_Row;        

        BindingSource bindingHead { get; set; }
        string MachineCode { get; set; }
        List<MachineModel> Machines { get; set; }
        MachineModel MachinesSelected { get; set; }
        void BindingData();
        void CloseMe();
    }
}
