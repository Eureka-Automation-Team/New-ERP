using Eureka.Core.Domain.Users;
using Eureka.Froms.Views.Security;
using Eureka.Services;
using MetroFramework.Controls;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Presentations.Security
{
    public class UserListPresenter
    {
        private readonly ISecuritieSrv _repository;
        private readonly IUserListView _view;

        public UserListPresenter(IUserListView view)
        {
            _view = view;
            _repository = new SecuritieSrv();

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
            if (_view.userSelected != null)
                _view.CloseMe();
        }

        private void Selecting_Row(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            try
            {
                _view.userSelected = (UserModel)grid.CurrentRow.DataBoundItem;
            }
            catch
            {
                _view.userSelected = null;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _view.userName = string.Empty;
            _view.roleName = string.Empty;

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

        public async Task<IPagedList<UserModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
            {
                var poList = _repository.GetUserAll();
                var result = poList.OrderByDescending(o => o.UserName).ToList();
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(_view.userName)) result = result.Where(x => x.UserName.ToUpper().Contains(_view.userName.ToUpper())).ToList();
                    if (!string.IsNullOrEmpty(_view.roleName)) result = result.Where(x => (string.IsNullOrEmpty(x.RoleName) ? "" : x.RoleName).ToUpper().Contains(_view.roleName.ToUpper())).ToList();
                }

                IPagedList<UserModel> list = null;
                list = result.ToList().ToPagedList(pageNumber, pageSize);

                return list;
            });
        }
    }
}
