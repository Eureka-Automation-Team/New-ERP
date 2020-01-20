using Eureka.Core.Domain.Commons;
using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Services.Purchasing
{
    public interface IPOReceiptSrv
    {
        #region GET
        POReceiptHeaderModel GetReceiptHeaderByID(int id);
        POReceiptHeaderModel GetReceiptHeaderByNumber(string number);
        List<POReceiptHeaderModel> GetRcvHeaderAll();
        List<POReceiptHeaderModel> GetRcvHeaderByDate(DateTime startDate, DateTime endDate);
        List<RcvReportModel> GetReceiveReport(string startNo, string endNo);

        POReceiptLineModel GetRcvLineByID(int id);
        List<POReceiptLineModel> GetRcvLineByHeaderID(int id);

        string GenGRN(string type, DateTime receiptDate);
        string GenReturn(string type);
        #endregion

        #region POST
        int InsertRcvHead(POReceiptHeaderModel model);
        void UpdateRcvHead(POReceiptHeaderModel model);
        void DeleteRcvHead(POReceiptHeaderModel model);

        int InsertRcvLine(POReceiptLineModel model);
        void UpdateRcvLine(POReceiptLineModel model);
        void DeleteRcvLine(POReceiptLineModel model);

        void UpdateDoc(SequenceDocModel model);
        #endregion
    }
}
