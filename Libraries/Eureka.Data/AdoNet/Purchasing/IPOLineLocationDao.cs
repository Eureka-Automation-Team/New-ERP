using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Purchasing
{
    public interface IPOLineLocationDao
    {
        POLineLocationModel GetByID(int id);

        List<POLineLocationModel> GetByPOID(int id);

        List<POLineLocationModel> GetByPOLineID(int id);

        List<POLineLocationModel> GetByReciptID(int id);

        List<POLineLocationModel> GetByReciptLineID(int id);

        List<POLineLocationModel> GetByDate(DateTime startDate, DateTime endDate);

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(POLineLocationModel model);

        // updates a Member
        void Update(POLineLocationModel model);

        // deletes a Member
        void Delete(POLineLocationModel model);
    }
}
