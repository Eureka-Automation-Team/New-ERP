using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;

namespace Eureka.Data.AdoNet.Purchasing
{
    public interface IPOReceiptLineDao
    {
        // gets a specific Member
        POReceiptLineModel GetByID(int id);

        // gets a sorted list of all Members
        List<POReceiptLineModel> GetByReceiptID(int id);

        // gets a sorted list of all Members
        List<POReceiptLineModel> GetAll();

        List<POReceiptLineModel> GetByDate(DateTime startDate, DateTime endDate);

        // gets a sorted list of all Members
        List<POReceiptLineModel> GetByPOID(int id);

        // gets a sorted list of all Members
        List<POReceiptLineModel> GetByPOLineID(int id);

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(POReceiptLineModel model);

        // updates a Member
        void Update(POReceiptLineModel model);

        // deletes a Member
        void Delete(POReceiptLineModel model);
    }
}