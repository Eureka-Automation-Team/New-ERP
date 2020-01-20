using Eureka.Core.Domain.Users;
using System.Collections.Generic;

namespace Eureka.Core.Domain.Security
{
    public class Session
    {
        #region Define as Singleton

        private static Session _Instance;

        public static Session Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Session();
                }
                return (_Instance);
            }
        }

        private Session()
        {
        }

        #endregion Define as Singleton

        public UserModel User { get; set; }
        public RoleModel Role { get; set; }
        public List<MenuModel> Menus { get; set; }

        public bool isLoggedIn
        {
            get
            {
                if (User != null)
                    return true;
                else return false;
            }
        }

        public string StatusConnected { get; set; }
        public string DatabaseName { get; set; }
        public string IPAddress { get; set; }
    }
}