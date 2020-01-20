using Eureka.Core.Domain.Projects;
using Eureka.Froms.Views.Projects;
using Eureka.Services.Projects;
using MetroFramework.Controls;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Presentations.Projects
{
    public class BomNumberListPresenter
    {
        private readonly IProjectSrv _repository;
        private IBomNumberListView _view;

        public BomNumberListPresenter(IBomNumberListView view)
        {
            _view = view;
            _repository = new ProjectSrv();

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
            if (_view.bomSelected != null)
                _view.CloseMe();
        }

        private void Selecting_Row(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            try
            {
                _view.bomSelected = (BomNumberModel)grid.CurrentRow.DataBoundItem;
            }
            catch
            {
                _view.bomSelected = null;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _view.bomNumber = string.Empty;

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

        public async Task<IPagedList<BomNumberModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
            {
                var poList = _repository.GetBomNumbersAll();
                var result = poList.OrderByDescending(o => o.BomNumber).ToList();
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(_view.bomNumber)) result = result.Where(x => x.Description.Contains(_view.bomNumber.ToUpper())).ToList();
                }

                IPagedList<BomNumberModel> list = null;
                list = result.ToList().ToPagedList(pageNumber, pageSize);

                return list;
            });
        }
    }
}
