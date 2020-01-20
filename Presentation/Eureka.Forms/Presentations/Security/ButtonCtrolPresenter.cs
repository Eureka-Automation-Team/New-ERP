using Eureka.Forms.Views.Controls;
using Eureka.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Forms.Presentations.Security
{
    public class ButtonCtrolPresenter
    {
        private readonly IMenuButtonCtrl _view;

        public ButtonCtrolPresenter(IMenuButtonCtrl view)
        {
            _view = view;
            _view.Item_Click += Item_Click;
        }

        private void Item_Click(object sender, MenuEventArgs args)
        {
            return;
        }

        private void Load(object sender, EventArgs e)
        {
            _view.DisposeButton();
            foreach (var item in _view.ItemMenus.OrderBy(o => o.SortMenu))
            {
                XButtonCtrl but = new XButtonCtrl();
                but.ItemButton = item;
                but.XButton_Click += new XButtonEventHandler(MenuItem_Click);

                _view.AddButton(but);
            }
        }

        private void MenuItem_Click(object sender, XButtonEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
