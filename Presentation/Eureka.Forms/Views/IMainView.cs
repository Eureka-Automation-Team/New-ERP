using Eureka.Forms.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Views
{
    public interface IMainView : IView
    {
        event EventHandler Form_Load;
        event EventHandler Monitoring;
        event EventHandler Menu_Click;
        event EventHandler ParentMenu_Click;
        event MenuEventHandler Item_Click;

        MenuButtonCtrl menuList { get; set; }
        string LogOnName { get; set; }
        string HostName { get; set; }
        string DatabaseName { get; set; }
        string ConnectionState { get; set; }

        void SetTimer(bool enableTimer);
    }
}
