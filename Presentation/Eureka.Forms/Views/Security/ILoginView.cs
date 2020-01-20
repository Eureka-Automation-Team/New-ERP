using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Views
{
    public interface ILoginView : IView
    {
        event EventHandler Form_Load;
        event EventHandler LogIn;

        string UserName { get; set; }
        string Password { get; set; }
    }
}
