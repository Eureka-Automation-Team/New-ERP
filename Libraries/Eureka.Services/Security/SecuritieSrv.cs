using Eureka.Core.Domain.Security;
using Eureka.Core.Domain.Users;
using Eureka.Data;
using System.Collections.Generic;
using System.Configuration;

namespace Eureka.Services
{
    public class SecuritieSrv : ISecuritieSrv
    {
        private static readonly string provider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly IFactory factory = Factories.GetFactory(provider);

        public List<UserModel> GetUserAll()
        {
            return factory.UserDao.GetUsers();
        }

        public RoleModel GetRoleByID(int id)
        {
            return factory.RoleDao.GetByID(id);
        }

        public UserModel GetByID(int id)
        {
            return factory.UserDao.GetUser(id);
        }

        public UserModel Login(string user, string password)
        {
            if (string.IsNullOrEmpty(user)) return null;
            if (string.IsNullOrEmpty(password)) return null;

            return factory.UserDao.Login(user, password);
        }

        public List<MenuModel> GetMenus(int roleId)
        {
            return factory.MenuDao.GetByRoleID(roleId);
        }

        public MenuModel GetMenuById(int id, int roleId)
        {
            return factory.MenuDao.GetByID(id, roleId);
        }

        public void DisableMenu(MenuModel menu)
        {
            factory.MenuDao.Disable(menu);
        }

        public void EnableMenu(MenuModel menu)
        {
            factory.MenuDao.Enable(menu);
        }
    }
}