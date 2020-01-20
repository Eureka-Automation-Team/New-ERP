using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Purchasing
{
    public interface IPOHeaderDao
    {
        // gets a specific Member
        POHeaderModel GetByID(int id);

        // gets a specific Member
        List<POReportModel> GetPOReportByID(int id);

        // gets a specific Member by email
        POHeaderModel GetByPONum(string number);

        // gets a sorted list of all Members
        List<POHeaderModel> GetAll();

        List<POHeaderModel> GetByDate(DateTime startDate, DateTime endDate);

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(POHeaderModel model);

        // updates a Member
        void Update(POHeaderModel model);

        // deletes a Member
        void Delete(POHeaderModel model);
    }
}
