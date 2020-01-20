using Eureka.Core.Domain.Payables;
using Eureka.Froms.Views.Payables;
using Eureka.Services.Payables;
using MetroFramework.Controls;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Payables
{
    public class VendorsListPresenter
    {
        private readonly IVendorListView _view;
        private readonly IPayablesSrv _repository;

        public VendorsListPresenter(IVendorListView view)
        {
            _view = view;
            _repository = new PayablesSrv();

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
            if (_view.vendorSelected != null)
                _view.CloseMe();
        }

        private void Selecting_Row(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            DataGridViewCellValidatingEventArgs erg = e as DataGridViewCellValidatingEventArgs;

            try
            {
                _view.vendorSelected = (VendorModel)grid.CurrentRow.DataBoundItem;
            }
            catch
            {
                _view.vendorSelected = null;
            }
            
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _view.VendorName = string.Empty;
            _view.VendorNumber = string.Empty;

            Filter_Click(sender, e);
        }

        private async void Filter_Click(object sender, EventArgs e)
        {
            var result = _view.vendors;
            if (result != null)
            {
                if (!string.IsNullOrEmpty(_view.VendorNumber)) result = result.Where(x => x.VendorNumber.ToUpper().Contains(_view.VendorNumber.ToUpper())).ToList();
                if (!string.IsNullOrEmpty(_view.VendorName)) result = result.Where(x => x.VendorName.ToUpper().Contains(_view.VendorName.ToUpper())).ToList();
            }

            _view.list = await GetPagedListAsync();
            _view.BindingData(_view.list);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //_view.vendors = _repository.GetVendorAll();

            Filter_Click(sender, e);
        }

        public async Task<IPagedList<VendorModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
            {
                var poList = _repository.GetVendorAll();
                var result = poList.OrderByDescending(o => o.VendorName).ToList();
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(_view.VendorNumber)) result = result.Where(x => x.VendorNumber.ToUpper().Contains(_view.VendorNumber.ToUpper())).ToList();
                    if (!string.IsNullOrEmpty(_view.VendorName)) result = result.Where(x => x.VendorName.ToUpper().Contains(_view.VendorName.ToUpper())).ToList();
                }

                IPagedList<VendorModel> list = null;
                list = result.ToList().ToPagedList(pageNumber, pageSize);

                return list;
            });
        }
    }
}
