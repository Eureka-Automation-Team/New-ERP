using Eureka.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Forms.Views.Controls
{
    public class XButtonEventArgs : EventArgs
    {
        public MenuModel ButtonModel { get; set; }
    }

    public delegate void XButtonEventHandler(object sender, XButtonEventArgs args);

    public interface IXButton
    {
        event EventHandler Button_Initail;
        event XButtonEventHandler XButton_Click;

        MenuModel ItemButton { get; set; }
        bool ButtonEnable { get; set; }
}
}
