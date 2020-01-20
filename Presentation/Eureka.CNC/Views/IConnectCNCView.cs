using FocasInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.Views
{
    public interface IConnectCNCView
    {
        event EventHandler Form_Load;
        event EventHandler Connect_Click;
        event EventHandler BrowseFile_Click;
        event EventHandler Upload_Click;
        event EventHandler GetProgramList_Click;
        event EventHandler DeleteProgram_Click;

        BindingSource bindingProgram { get; set; }
        MachineInterface _focasInt1 { get; set; }
        bool Connected { get; set; }
        string IpAddress { get; set; }
        string Port { get; set; }
        string FilePath { get; set; }
    }
}
