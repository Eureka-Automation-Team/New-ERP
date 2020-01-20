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
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Projects
{
    public class ProjectCostListPresenter
    {
        private readonly IProjectCostListView _view;
        private readonly IProjectSrv _repository;

        public ProjectCostListPresenter(IProjectCostListView view)
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
            if (_view.projCostSelected != null)
                _view.CloseMe();
        }

        private void Selecting_Row(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;

            if (grid.SelectedRows.Count > 0)
            {
                List<ProjectCostModel> prjs = new List<ProjectCostModel>(); // grid.SelectedRows.DataBoundItem;
                foreach (DataGridViewRow item in grid.SelectedRows)
                {
                    try
                    {
                        ProjectCostModel prj = (ProjectCostModel)item.DataBoundItem;
                        prjs.Add(prj);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (prjs.Count != 0)
                {
                    _view.projCostSelected = prjs;
                }
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _view.costCode = string.Empty;
            Filter_Click(sender, e);
        }

        private async void Filter_Click(object sender, EventArgs e)
        {
            _view.list = await GetPagedListAsync();
            _view.bindingLine.DataSource = _view.list;
            _view.BindingData(_view.list);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Filter_Click(sender, e);
        }

        public async Task<IPagedList<ProjectCostModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
            {
                int prjId = _repository.GetProjectByNumber(_view.projectNum).Id;
                if (prjId != 0)
                {
                    var result = _repository.GetProjectCostByProjID(prjId);
                    if (result != null)
                    {
                        if (!string.IsNullOrEmpty(_view.projectNum)) result = result.Where(x => x.ProjectNum.Contains(_view.projectNum)).ToList();
                    }

                    IPagedList<ProjectCostModel> list = null;
                    list = result.ToList().ToPagedList(pageNumber, pageSize);

                    return list;
                }
                else
                    return null;

            });
        }
    }
}
