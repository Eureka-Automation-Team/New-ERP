using Eureka.Core.Domain.Security;
using Eureka.Froms.Views;
using Eureka.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Security
{
    public class LoginPresenter
    {
        private readonly ISecuritieSrv _repository;
        private readonly ILoginView _view;

        public LoginPresenter(ILoginView view)
        {
            _view = view;
            _repository = new SecuritieSrv();

            _view.Form_Load += Form_Load;
            _view.LogIn += LogIn;
        }

        private void LogIn(object sender, EventArgs e)
        {
            Session.Instance.User = _repository.Login(_view.UserName, _view.Password.ToString().Trim());

            if (!Session.Instance.isLoggedIn)
            {
                MessageBox.Show("Login failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Session.Instance.Role = _repository.GetRoleByID(Session.Instance.User.RoleID);
                Session.Instance.Menus = _repository.GetMenus(Session.Instance.Role.RoleID);
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            _view.UserName = "";
            _view.Password = "";
        }
    }
}
