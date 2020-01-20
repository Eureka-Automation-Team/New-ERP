using Eureka.Core.Domain.Inventory;
using Eureka.Froms.Views.Inventory;
using Eureka.Services.Inventory;
using MetroFramework.Controls;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Inventory
{
    public class ItemListPresenter
    {
        private readonly IItemMasterSrv _repository;
        private readonly IItemListView _view;

        public ItemListPresenter(IItemListView view)
        {
            _view = view;
            _repository = new ItemMasterSrv();

            _view.Form_Load += Form_Load;
            _view.Filter_Click += Filter_Click;
            _view.Clear_Click += Clear_Click;
            _view.Selecting_Row += Selecting_Row;
            _view.OK_Click += OK_Click;
            _view.PreviousPage += PreviousPage;
            _view.NextPage += NextPage;
        }

        private async void NextPage(object sender, EventArgs e)
        {
            if (_view.list.HasNextPage)
            {
                if (_view.pageNumber == 0)
                    _view.pageNumber = 1;

                _view.list = await GetPagedListAsync(++_view.pageNumber);
                _view.BindingData(_view.list);
            }
        }

        private async void PreviousPage(object sender, EventArgs e)
        {
            if (_view.list.HasPreviousPage)
            {
                _view.list = await GetPagedListAsync(--_view.pageNumber);
                _view.BindingData(_view.list);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (_view.itemSelected != null)
                _view.CloseMe();
        }

        private void Selecting_Row(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            DataGridViewCellValidatingEventArgs erg = e as DataGridViewCellValidatingEventArgs;

            try
            {
                _view.itemSelected = (ItemMasterModel)grid.CurrentRow.DataBoundItem;
            }
            catch
            {
                _view.itemSelected = null;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _view.itemCode = string.Empty;
            _view.itemDescription = string.Empty;
            _view.manuId = string.Empty;
            _view.brandMat = string.Empty;

            Filter_Click(sender, e);
        }

        private async void Filter_Click(object sender, EventArgs e)
        {
            _view.list = await GetPagedListAsync();
            _view.BindingData(_view.list);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Filter_Click(sender, e);
        }

        public async Task<IPagedList<ItemMasterModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 100)
        {
            return await Task.Factory.StartNew(() =>
            {
                var result = _view.items.OrderByDescending(o => o.CreationDate).ToList();
                //var lines = result.OrderByDescending(o => o.Segment1).ToList();

                Cursor.Current = Cursors.WaitCursor;
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(_view.itemCode)) result = result.Where(x => x.Segment1.ToUpper().Contains(_view.itemCode.ToUpper())).ToList();
                    if (!string.IsNullOrEmpty(_view.itemDescription)) result = result
                                                                        .Where(x => 
                                                                        (string.IsNullOrEmpty(x.Description) ? "" : x.Description).ToUpper().Contains(_view.itemDescription.ToUpper())).ToList();
                    if (!string.IsNullOrEmpty(_view.manuId)) result = result
                                                                        .Where(x => 
                                                                        (string.IsNullOrEmpty(x.Segment2) ? "" : x.Segment2).ToUpper().Contains(_view.manuId.ToUpper())).ToList();
                    if (!string.IsNullOrEmpty(_view.itemDescription)) result = result
                                                                        .Where(x => 
                                                                        (string.IsNullOrEmpty(x.Segment3) ? "" : x.Segment3).ToUpper().Contains(_view.brandMat.ToUpper())).ToList();
                }

                IPagedList<ItemMasterModel> list = null;
                list = result.ToList().ToPagedList(pageNumber, pageSize);
                Cursor.Current = Cursors.Default;
                return list;
            });
        }

        // If you want to implement both "*" and "?"
        private static String LikeToRegular(String value)
        {
            return "^" + Regex.Escape(value).Replace("_", ".").Replace("%", ".*") + "$";
        }
    }
}
