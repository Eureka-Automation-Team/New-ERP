using Eureka.Core.Domain.Users;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Views.Security
{
    public interface IUserListView
    {
        event EventHandler Form_Load;
        event EventHandler OK_Click;
        event EventHandler Filter_Click;
        event EventHandler Clear_Click;
        event EventHandler Selecting_Row;
        event EventHandler PreviousPage;
        event EventHandler NextPage;

        int pageNumber { get; set; }
        IPagedList<UserModel> list { get; set; }
        string userName { get; set; }
        string roleName { get; set; }
        List<UserModel> users { get; set; }
        UserModel userSelected { get; set; }
        void BindingData(IPagedList<UserModel> list);
        void CloseMe();
    }
}
