using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Purchasing
{
    public interface IApproveListHeadDao
    {
        // gets a specific Member
        ApproveListHeadModel GetByID(int id);

        // gets a specific Member by email
        ApproveListHeadModel GetByPOID(int id);

        // gets a sorted list of all Members
        List<ApproveListHeadModel> GetAll();

        List<ApproveListHeadModel> GetByDate(DateTime startDate, DateTime endDate);

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(ApproveListHeadModel model);

        // updates a Member
        void Update(ApproveListHeadModel model);

        // deletes a Member
        void Delete(ApproveListHeadModel model);
    }
}
