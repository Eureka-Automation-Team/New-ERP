using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Purchasing
{
    public interface IPOLoggingDao
    {
        POLoggingModel GetByID(int id);

        List<POLoggingModel> GetByPoId(int id);

        List<POLoggingModel> GetByUserId(int id);

        List<POLoggingModel> GetByPrId(int id);

        List<POLoggingModel> GetAll();

        List<POLoggingModel> GetByDate(DateTime startDate, DateTime endDate);

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(POLoggingModel model);

        // updates a Member
        void Update(POLoggingModel model);

        // deletes a Member
        void Delete(POLoggingModel model);
    }
}
