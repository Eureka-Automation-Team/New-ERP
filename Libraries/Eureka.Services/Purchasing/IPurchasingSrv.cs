using Eureka.Core.Domain.Commons;
using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Services.Purchasing
{
    public interface IPurchasingSrv
    {
        #region GET
        List<POReportModel> GetReportByID(int id);
        List<POHeaderModel> GetPOAll();
        List<POHeaderModel> GetPOByDate(DateTime startDate, DateTime endDate);
        POHeaderModel GetPOByID(int id);
        POHeaderModel GetPOByNumber(string number);

        POLineModel GetPOLineByID(int id);
        List<POLineModel> GetPOLineByPOID(int poId);
        List<POLineModel> GetPOLineByPONumber(string number);
        List<POLineModel> GetPOLineAll();

        POLineLocationModel GetLineLocationByID(int id);
        List<POLineLocationModel> GetLineLocationByPOID(int id);
        List<POLineLocationModel> GetLineLocationByPOLineID(int id);
        List<POLineLocationModel> GetLineLocationByRcvID(int id);
        List<POLineLocationModel> GetLineLocationByRcvLineID(int id);

        string GetDocNoByType(string type);

        List<CurrencyModel> GetCurrencies();
        CurrencyModel GetCurrencyByCode(string curCode);

        CurrencyModel GetToCurrencyByCode(string curCode);
        List<TaxCodeModel> GetTaxCodes();
        #endregion

        #region POST
        int InsertPO(POHeaderModel model);
        void UpdatePO(POHeaderModel model);
        void DeletePO(POHeaderModel model);

        int InsertPOLine(POLineModel model);
        void UpdatePOLine(POLineModel model);
        void DeletePOLine(POLineModel model);

        int InsertPoLineLocation(POLineLocationModel model);
        void UpdatePoLineLocation(POLineLocationModel model);
        void DeletePoLineLocation(POLineLocationModel model);

        void UpdateDoc(SequenceDocModel model);
        #endregion
    }
}
