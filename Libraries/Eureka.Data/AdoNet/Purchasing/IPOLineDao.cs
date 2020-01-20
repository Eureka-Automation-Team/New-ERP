using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Purchasing
{
    public interface IPOLineDao
    {
        // gets a specific Member
        POLineModel GetByID(int id);

        // gets a specific Member
        List<POLineModel> GetByPOID(int id);

        // gets a specific Member by email
        List<POLineModel> GetByPONum(string number);

        // gets a sorted list of all Members
        List<POLineModel> GetAll();

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(POLineModel model);

        // updates a Member
        void Update(POLineModel model);

        // deletes a Member
        void Delete(POLineModel model);
    }
}
