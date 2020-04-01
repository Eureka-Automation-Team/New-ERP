using Eureka.Froms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Forms.Views.Security
{
    public interface IChangePasswordView : IView
    {
        event EventHandler Save;

        string OldPassword { get; set; }
        string NewPassword { get; set; }
        string ConfirmPassword { get; set; }
        bool Confirmed { get; }

        void CloseMe();
    }
}
