using Eureka.Core.Domain.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Projects
{
    public interface ICostGroupDao
    {
        // gets a specific Member
        CostGroupModel GetByID(int id);

        List<CostGroupModel> GetByBOMID(int id);

        // gets a specific Member by email
        CostGroupModel GetByCode(string code);

        // gets a sorted list of all Members
        List<CostGroupModel> GetAll();

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(CostGroupModel model);

        // updates a Member
        void Update(CostGroupModel model);

        // deletes a Member
        void Delete(CostGroupModel model);
    }
}
