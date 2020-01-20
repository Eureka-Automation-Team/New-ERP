using Eureka.Core.Domain.Inventory;
using Eureka.Forms.Views.Inventory;
using Eureka.Services.Inventory;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Forms.Presentations.Inventory
{
    public class ItemsDupplicatePresenter
    {
        private readonly IItemMasterSrv _repository;
        private readonly IItemsDupplicateView _view;

        public ItemsDupplicatePresenter(IItemsDupplicateView view)
        {
            _view = view;
            _repository = new ItemMasterSrv();

            _view.Form_Load += FormLoad;
            _view.Selecting_Row += SelectingRow;
        }

        private void SelectingRow(object sender, EventArgs e)
        {
            MetroGrid grd = sender as MetroGrid;

            List<ItemMasterModel> lines = new List<ItemMasterModel>();
            ItemMasterModel line = new ItemMasterModel();
            if (grd.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in grd.SelectedRows)
                {
                    line = (ItemMasterModel)row.DataBoundItem;

                    lines.Add(line);
                }
            }

            _view.itemsSelected = lines;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            _view.SourceBinding.DataSource = _view.items;
            _view.BindingGrid();
        }
    }
}
