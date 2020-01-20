using Eureka.Core.Domain.Purchasing;
using Eureka.Froms.Views.Purchasing;
using Eureka.Services.Purchasing;
using MetroFramework.Controls;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Purchasing
{
    public class POListPresenter
    {
        private readonly IPurchasingSrv _repository;
        private readonly IPOListView _view;

        public POListPresenter(IPOListView view)
        {
            _view = view;
            _repository = new PurchasingSrv();

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
            try
            {
                if (_view.posSelected.Count() > 0)
                {
                    _view.CloseMe();
                }
                else
                {
                    MessageBox.Show("Please select rows.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Please select rows.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Selecting_Row(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;

            if (grid.SelectedRows.Count > 0)
            {
                List<POHeaderModel> pos = new List<POHeaderModel>(); // grid.SelectedRows.DataBoundItem;
                foreach (DataGridViewRow item in grid.SelectedRows)
                {
                    try
                    {
                        int id = Convert.ToInt32(item.Cells[0].Value);
                        POHeaderModel po = _view.list.Where(x => x.PoHeaderId == id).FirstOrDefault();
                        pos.Add(po);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (pos.Count != 0)
                {
                    _view.posSelected = pos;
                }
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _view.poNum = string.Empty;

            Filter_Click(sender, e);
        }

        private async void Filter_Click(object sender, EventArgs e)
        {
            //_view.pos = _repository.GetPOByDate(_view.startDate, _view.endDate);
            _view.list = await GetPagedListAsync();
            _view.BindingData(_view.list);
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            _view.buyer = _view.EpiSession.User.UserName;

            //if(_view.pos == null)
            //_view.pos = _repository.GetPOByDate(_view.startDate, _view.endDate);

            _view.list = await GetPagedListAsync();
            _view.BindingData(_view.list);
            //Filter_Click(sender, e);
        }

        public async Task<IPagedList<POHeaderModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
            {
                var poList = _repository.GetPOByDate(_view.startDate, _view.endDate);
                var result = poList.OrderByDescending(o => o.PODate).ThenByDescending(o => o.PoNum).ToList();
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(_view.poNum)) result = result.Where(x => x.PoNum.Contains(_view.poNum.Trim())).ToList();
                    if (!string.IsNullOrEmpty(_view.buyer)) result = result.Where(x => x.BuyerName == (_view.buyer.Trim())).ToList();
                    if (_view.vendorId != 0) result = result.Where(x => x.VendorId == (_view.vendorId)).ToList();
                }

                IPagedList<POHeaderModel> list = null;
                list = result.ToList().ToPagedList(pageNumber, pageSize);

                return list;
            });
        }
    }
}