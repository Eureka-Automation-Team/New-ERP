using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Purchasing
{
    public interface IPOReceiptHaeaderDao
    {
        // gets a specific Member
        POReceiptHeaderModel GetByID(int id);

        POReceiptHeaderModel GetByNumber(string number);

        // gets a sorted list of all Members
        List<POReceiptHeaderModel> GetAll();

        List<POReceiptHeaderModel> GetByDate(DateTime startDate, DateTime endDate);

        List<RcvReportModel> GetReceivedReportByID(string startNo, string endNo);

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(POReceiptHeaderModel model);

        // updates a Member
        void Update(POReceiptHeaderModel model);

        // deletes a Member
        void Delete(POReceiptHeaderModel model);
    }
}
