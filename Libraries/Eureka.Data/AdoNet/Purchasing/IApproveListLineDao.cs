using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Purchasing
{
    public interface IApproveListLineDao
    {
        // gets a specific Member
        ApproveListLineModel GetByID(int id);

        // gets a specific Member by Approved list header id
        List<ApproveListLineModel> GetByHeadID(int id);

        // gets a sorted list of all Members
        List<ApproveListLineModel> GetAll();

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(ApproveListLineModel model);

        // updates a Member
        void Update(ApproveListLineModel model);

        // deletes a Member
        void Delete(ApproveListLineModel model);
    }
}
