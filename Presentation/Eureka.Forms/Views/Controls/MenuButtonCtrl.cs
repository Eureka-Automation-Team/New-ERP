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
using KimtToo.VisualReactive;
using Eureka.Forms.Presentations.Security;

namespace Eureka.Forms.Views.Controls
{
    public partial class MenuButtonCtrl : UserControl, IMenuButtonCtrl
    {
        private ButtonCtrolPresenter _presenter;
        private MenuModel _ParentMenu;
        private List<MenuModel> _ItemsMenu;

        public MenuButtonCtrl()
        {
            InitializeComponent();

            _presenter = new ButtonCtrolPresenter(this);
        }

        public List<MenuModel> ItemMenus
        {
            get { return _ItemsMenu; }
            set { _ItemsMenu = value; }
        }

        public Panel mContainer
        {
            get { return pnlContainer; }
            set { pnlContainer = value; }
        }

        public MenuModel ParentMenu
        {
            get { return _ParentMenu; }
            set { _ParentMenu = value; }
        }

        public event MenuEventHandler Item_Click;

        public void RefreshButtons()
        {
            MenuButtonCtrl_Load(null, null);
        }

        public void AddButton(Control ctrl)
        {
            ctrl.Dock = DockStyle.Top;
            mContainer.Controls.Add(ctrl);
        }

        public void DisposeButton()
        {
            mContainer.Controls.Clear();
        }

        private void MenuButtonCtrl_Load(object sender, EventArgs e)
        {
            DisposeButton();
            if(ItemMenus != null)
            {
                foreach (var item in ItemMenus.OrderByDescending(o => o.SortMenu))
                {
                    XButtonCtrl but = new XButtonCtrl();
                    but.ItemButton = item;
                    but.XButton_Click += new XButtonEventHandler(MenuItem_Click);

                    AddButton(but);
                }
            }

        }

        private void MenuItem_Click(object sender, XButtonEventArgs args)
        {
            if(Item_Click != null)
                Item_Click(sender, new MenuEventArgs { formID = args.ButtonModel.FormName, ParentMenu = null, MenuClicked = args.ButtonModel });
        }
    }
}
