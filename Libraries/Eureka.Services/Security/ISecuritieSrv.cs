using Eureka.Core.Domain.Security;
using Eureka.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Services
{
    public interface ISecuritieSrv
    {
        List<UserModel> GetUserAll();
        UserModel GetByID(int id);
        RoleModel GetRoleByID(int id);
        UserModel Login(string user, string password);
        List<MenuModel> GetMenus(int roleId);
        MenuModel GetMenuById(int id, int roleId);
        void DisableMenu(MenuModel menu);
        void EnableMenu(MenuModel menu);

        bool MatchingPass(string oldPass, string matchingPass);

        void UpdatePass(UserModel user);
    }
}
