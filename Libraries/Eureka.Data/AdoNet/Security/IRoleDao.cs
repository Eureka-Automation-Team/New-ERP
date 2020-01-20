using Eureka.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data
{
    public interface IRoleDao
    {
        // gets a specific Member
        RoleModel GetByID(int id);

        // gets a specific Member
        RoleModel GetByName(string name);

        // gets a sorted list of all Members
        List<RoleModel> GetAll();

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(RoleModel role);

        // updates
        void Update(RoleModel role);

        // deletes a Member
        void Delete(RoleModel role);
    }
}
