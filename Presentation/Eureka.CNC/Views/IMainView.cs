using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.CNC.Views
{
    public interface IMainView : IView
    {
        event EventHandler Form_Load;
        event EventHandler Monitoring;
        event EventHandler Menu_Click;

        //Session EpiSession { get; }

        string LogOnName { get; set; }
        string HostName { get; set; }
        string DatabaseName { get; set; }

        void SetTimer(bool enableTimer);
    }
}
