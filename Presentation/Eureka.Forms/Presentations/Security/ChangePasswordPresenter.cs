using Eureka.Core.Domain.Users;
using Eureka.Forms.Views.Security;
using Eureka.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Forms.Presentations.Security
{
    public class ChangePasswordPresenter
    {
        private readonly IChangePasswordView _view;
        private readonly ISecuritieSrv _repository;

        public ChangePasswordPresenter(IChangePasswordView view)
        {
            _view = view;
            _repository = new SecuritieSrv();

            _view.Save += Save;
        }

        private void Save(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_view.OldPassword))
            {
                MessageBox.Show("Please enter Old Password.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_repository.MatchingPass(_view.EpiSession.User.Password, _view.OldPassword))
            {
                MessageBox.Show("Old password is invalid.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(_view.NewPassword))
            {
                MessageBox.Show("Please enter New Password.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(_view.ConfirmPassword))
            {
                MessageBox.Show("Please enter Confirm Password.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_view.NewPassword.Trim() != _view.ConfirmPassword.Trim())
            {
                MessageBox.Show("Please re-confirm New Password.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserModel result = _view.EpiSession.User;
            result.Password = _view.NewPassword;
            _repository.UpdatePass(result);
            MessageBox.Show("Changed password complete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _view.CloseMe();
        }
    }
}
