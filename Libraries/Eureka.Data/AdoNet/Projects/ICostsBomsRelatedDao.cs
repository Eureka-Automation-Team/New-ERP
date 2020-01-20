using Eureka.Core.Domain.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Projects
{
    public interface ICostsBomsRelatedDao
    {
        // gets a specific Member
        List<CostsBomsRelatedModel> GetByCostID(int id);

        List<CostsBomsRelatedModel> GetByBomID(int id);

        CostsBomsRelatedModel GetByBomAndCostID(int bomId, int costId);

        // gets a sorted list of all Members
        List<CostsBomsRelatedModel> GetAll();

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(CostsBomsRelatedModel model);

        // updates a Member
        void Update(CostsBomsRelatedModel model);

        // deletes a Member
        void Delete(CostsBomsRelatedModel model);
    }
}
