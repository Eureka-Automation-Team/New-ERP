using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Purchasing
{
    public interface IRequisitionHeaderDao
    {
        // gets a specific Member
        RequisitionHeaderModel GetByID(int id);

        RequisitionHeaderModel GetByNumber(string number);

        // gets a sorted list of all Members
        List<RequisitionHeaderModel> GetAll();

        // gets a sorted list of all Members
        List<RequisitionHeaderModel> GetByProjectNumber(string prjNumber);

        List<RequisitionHeaderModel> GetByDate(DateTime startDate, DateTime endDate);

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(RequisitionHeaderModel model);

        // updates a Member
        void Update(RequisitionHeaderModel model);

        // deletes a Member
        void Delete(RequisitionHeaderModel model);
    }
}
