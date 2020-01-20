using Eureka.Core.Domain.Commons;
using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Services.Purchasing
{
    public interface IRequisitionSrv
    {
        #region GET
        List<RequisitionHeaderModel> GetHeadAll();
        List<RequisitionHeaderModel> GetHeadByProjectNumber(string prjNumber);
        List<RequisitionHeaderModel> GetHeadByDate(DateTime startDate, DateTime endDate);
        RequisitionHeaderModel GetHeadByID(int id);
        RequisitionHeaderModel GetHeadByNumber(string number);
        List<RequisitionLineModel> GetLinesByHeaderID(int id);
        List<RequisitionLineModel> GetLinesByProjectID(int projId);
        List<RequisitionLineModel> GetLinesByProjectIDForConfirm(int projId);
        List<RequisitionLineModel> GetLinesByPOID(int poId);
        RequisitionLineModel GetLineByID(int id);
        int KeepLogging(POLoggingModel model);
        void UpdateCancelFlag(int reqId);
        void UpdatePurchasedFlag(int reqId);
        string GetDocNo(string type);
        #endregion

        #region POST
        int InsertPR(RequisitionHeaderModel model);
        void UpdatePR(RequisitionHeaderModel model);
        void DeletePR(RequisitionHeaderModel model);

        int InsertPRLine(RequisitionLineModel model);
        void UpdatePRLine(RequisitionLineModel model);
        void DeletePRLine(RequisitionLineModel model);

        void UpdateDoc(SequenceDocModel model);
        #endregion
    }
}
