using Eureka.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data
{
    public interface IMenuDao
    {
        // gets a specific Member
        MenuModel GetByID(int id, int roldId);

        // gets a specific Member
        List<MenuModel> GetByRoleID(int roleId);

        // gets a sorted list of all Members
        List<MenuModel> GetAll(int roleId);

        // deletes a Member
        void Enable(MenuModel menu);

        void Disable(MenuModel menu);
    }
}
