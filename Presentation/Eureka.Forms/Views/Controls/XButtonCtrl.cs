using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eureka.Core.Domain.Security;

namespace Eureka.Forms.Views.Controls
{
    public partial class XButtonCtrl : UserControl, IXButton
    {
        private MenuModel _ItemMenu;

        public XButtonCtrl()
        {
            InitializeComponent();
        }

        public MenuModel ItemButton
        {
            get { return _ItemMenu; }
            set { _ItemMenu = value; }
        }

        public bool ButtonEnable
        {
            get { return button.Enabled; }
            set { button.Enabled = value; }
        }

        public event EventHandler Button_Initail;
        public event XButtonEventHandler XButton_Click;

        private void button_Click(object sender, EventArgs e)
        {
            XButton_Click(sender, new XButtonEventArgs { ButtonModel = (MenuModel)button.Tag });
        }

        private void XButtonCtrl_Load(object sender, EventArgs e)
        {
            if(this.ItemButton != null)
            {
                button.Text = "          " + ItemButton.Name;
                button.Tag = ItemButton;
            }
        }
    }
}
