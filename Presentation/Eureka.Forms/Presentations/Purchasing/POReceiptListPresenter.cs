using Eureka.Core.Domain.Purchasing;
using Eureka.Froms.Views.Purchasing;
using Eureka.Services.Purchasing;
using MetroFramework.Controls;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Purchasing
{
    public class POReceiptListPresenter
    {
        private readonly IPOReceiptListView _view;
        private readonly IPOReceiptSrv _repository;

        public POReceiptListPresenter(IPOReceiptListView view)
        {
            _view = view;
            _repository = new POReceiptSrv();

            _view.Form_Load += Form_Load;
            _view.Filter_Click += Filter_Click;
            _view.Clear_Click += Clear_Click;
            _view.Selecting_Row += Selecting_Row;
            _view.OK_Click += OK_Click;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (_view.rcvsSelected.Count() > 0)
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
                List<POReceiptHeaderModel> rcvs = new List<POReceiptHeaderModel>(); // grid.SelectedRows.DataBoundItem;
                foreach (DataGridViewRow item in grid.SelectedRows)
                {
                    try
                    {
                        POReceiptHeaderModel po = (POReceiptHeaderModel)item.DataBoundItem;
                        rcvs.Add(po);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (rcvs.Count != 0)
                {
                    _view.rcvsSelected = rcvs;
                }
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _view.rcvNum = string.Empty;
            _view.vendorNum = string.Empty;

            Filter_Click(sender, e);
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            if (_view.rcvMethod == "ALL")
                _view.rcvs = _repository.GetRcvHeaderByDate(_view.startDate, _view.endDate);
            else
                _view.rcvs = _repository.GetRcvHeaderByDate(_view.startDate, _view.endDate).Where(x => x.ReceiptMethod == _view.rcvMethod).ToList();

            var result = _view.rcvs.OrderByDescending(o => o.ReceiptDate).ToList();
            if (result != null)
            {
                if (!string.IsNullOrEmpty(_view.rcvNum)) result = result.Where(x => x.ReceiptNum.Contains(_view.rcvNum)).ToList();
                if (!string.IsNullOrEmpty(_view.vendorNum)) result = result.Where(x => x.VendorName == (_view.vendorNum)).ToList();
            }

            result = result.ToList();
            _view.BindingData(result);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (_view.rcvs == null)
            {
                if (_view.rcvMethod == "ALL")
                    _view.rcvs = _repository.GetRcvHeaderByDate(_view.startDate, _view.endDate);
                else
                    _view.rcvs = _repository.GetRcvHeaderByDate(_view.startDate, _view.endDate).Where(x => x.ReceiptMethod == _view.rcvMethod).ToList();
            }

            _view.BindingData(_view.rcvs);
        }
    }
}
