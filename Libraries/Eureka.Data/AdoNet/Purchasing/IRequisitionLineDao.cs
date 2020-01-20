using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Purchasing
{
    public interface IRequisitionLineDao
    {
        // gets a specific Member
        RequisitionLineModel GetByID(int id);

        List<RequisitionLineModel> GetByHeaderID(int id);

        List<RequisitionLineModel> GetByProjectId(int projectId);

        List<RequisitionLineModel> GetByProjectIdForConfirm(int projectId);

        List<RequisitionLineModel> GetByPOID(int poId);

        // gets a sorted list of all Members
        List<RequisitionLineModel> GetAll();

        List<RequisitionLineModel> GetByDate(DateTime startDate, DateTime endDate);

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(RequisitionLineModel model);

        // updates a Member
        void Update(RequisitionLineModel model);

        // deletes a Member
        void Delete(RequisitionLineModel model);
    }
}
