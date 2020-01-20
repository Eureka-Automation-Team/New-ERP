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
    public class RequisitionListPresenter
    {
        private readonly IRequisitionListView _view;
        private readonly IRequisitionSrv _repository;

        public RequisitionListPresenter(IRequisitionListView view)
        {
            _view = view;
            _repository = new RequisitionSrv();

            _view.Form_Load += Form_Load;
            _view.Filter_Click += Filter_Click;
            _view.Clear_Click += Clear_Click;
            _view.OK_Click += OK_Click;
            _view.Selecting_Row += Selecting_Row;
        }

        private void Selecting_Row(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;

            if (grid.SelectedRows.Count > 0)
            {
                List<RequisitionHeaderModel> prs = new List<RequisitionHeaderModel>(); // grid.SelectedRows.DataBoundItem;
                foreach (DataGridViewRow item in grid.SelectedRows)
                {
                    try
                    {
                        int id = Convert.ToInt32(item.Cells[0].Value);
                        RequisitionHeaderModel pr = _view.list.Where(x => x.RequisitionHeaderId == id).FirstOrDefault();
                        prs.Add(pr);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (prs.Count != 0)
                {
                    _view.prsSelected = prs;
                }
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (_view.prsSelected.Count() > 0)
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

        private void Clear_Click(object sender, EventArgs e)
        {
            _view.projectNo = string.Empty;
            _view.requisitonNo = string.Empty;

            Filter_Click(sender, e);
        }

        private async void Filter_Click(object sender, EventArgs e)
        {
            _view.list = await GetPagedListAsync();
            _view.BindingData(_view.list);
        }

        private  void Form_Load(object sender, EventArgs e)
        {
            _view.startDate = DateTime.Now.AddDays(-1095);
            _view.endDate = DateTime.Now;

            Filter_Click(sender, e);
        }

        public async Task<IPagedList<RequisitionHeaderModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
            {
                var poList = _repository.GetHeadByDate(_view.startDate, _view.endDate);
                var result = poList.OrderByDescending(o => o.RequisitionDate).ThenByDescending(o => o.RequisitionNumber).ToList();
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(_view.projectNo)) result = result.Where(x => x.ProjectNo.Contains(_view.projectNo)).ToList();
                    if (!string.IsNullOrEmpty(_view.requisitonNo)) result = result.Where(x => x.RequisitionNumber.Contains(_view.requisitonNo)).ToList();
                }

                IPagedList<RequisitionHeaderModel> list = null;
                list = result.ToList().ToPagedList(pageNumber, pageSize);

                return list;
            });
        }
    }
}
