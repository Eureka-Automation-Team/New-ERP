using Eureka.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Forms.Views.Controls
{
    public class MenuEventArgs : EventArgs
    {
        public string formID { get; set; }
        public MenuModel ParentMenu { get; set; }
        public MenuModel MenuClicked { get; set; }
    }

    public delegate void MenuEventHandler(object sender, MenuEventArgs args);

    public interface IMenuButtonCtrl
    {
        event MenuEventHandler Item_Click;

        Panel mContainer { get; set; }
        MenuModel ParentMenu { get; set; }
        List<MenuModel> ItemMenus { get; set; }

        void AddButton(Control ctrl);
        void DisposeButton();
        void RefreshButtons();
    }
}
