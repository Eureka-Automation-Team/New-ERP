using Eureka.Core.Domain.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Projects
{
    public interface IBomNumberDao
    {
        // gets a specific Member
        BomNumberModel GetByID(int id);

        // gets a sorted list of all Members
        List<BomNumberModel> GetAll();

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(BomNumberModel model);

        // updates a Member
        void Update(BomNumberModel model);

        // deletes a Member
        void Delete(BomNumberModel model);
    }
}
