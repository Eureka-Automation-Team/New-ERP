using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Commons;
using Eureka.Core.Domain.Purchasing;
using Eureka.Data;

namespace Eureka.Services.Purchasing
{
    public class RequisitionSrv : IRequisitionSrv
    {
        private static readonly string provider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly IFactory factory = Factories.GetFactory(provider);

        #region GET
        public string GetDocNo(string type)
        {
            string docNo = string.Empty;
            string preFix = string.Empty;
            int running = 0;
            SequenceDocModel rowDoc = factory.DocSeqDao.GetByType(type);

            if (rowDoc != null)
            {
                string[] words = rowDoc.Prefix.Split('#');
                preFix = words[0] + DateTime.Now.ToString(words[1]);

                if (rowDoc.LastUpdateDate.Month != DateTime.Now.Month)
                    running = 1;
                else
                    running = rowDoc.NextVal;

                rowDoc.NextVal = running + 1;
                rowDoc.LastUpdateDate = DateTime.Now;
                UpdateDoc(rowDoc);
                docNo = string.Format("{0}{1}", preFix, running.ToString().PadLeft(rowDoc.RunningDigit, '0'));
            }
            return docNo;
        }

        public List<RequisitionHeaderModel> GetHeadAll()
        {
            return factory.RequisitionHeaderDao.GetAll();
        }

        public List<RequisitionHeaderModel> GetHeadByDate(DateTime startDate, DateTime endDate)
        {
            return factory.RequisitionHeaderDao.GetByDate(startDate, endDate);
        }

        public RequisitionHeaderModel GetHeadByID(int id)
        {
            return factory.RequisitionHeaderDao.GetByID(id);
        }

        public RequisitionHeaderModel GetHeadByNumber(string number)
        {
            return factory.RequisitionHeaderDao.GetByNumber(number);
        }

        public List<RequisitionLineModel> GetLinesByHeaderID(int id)
        {
            return factory.RequisitionLineDao.GetByHeaderID(id);
        }

        public RequisitionLineModel GetLineByID(int id)
        {
            return factory.RequisitionLineDao.GetByID(id);
        }

        public List<RequisitionHeaderModel> GetHeadByProjectNumber(string prjNumber)
        {
            return factory.RequisitionHeaderDao.GetByProjectNumber(prjNumber);
        }

        public List<RequisitionLineModel> GetLinesByProjectID(int projId)
        {
            return factory.RequisitionLineDao.GetByProjectId(projId);
        }

        public List<RequisitionLineModel> GetLinesByProjectIDForConfirm(int projId)
        {
            return factory.RequisitionLineDao.GetByProjectIdForConfirm(projId);
        }

        public List<RequisitionLineModel> GetLinesByPOID(int poId)
        {
            return factory.RequisitionLineDao.GetByPOID(poId);
        }
        #endregion

        #region POST
        public int InsertPR(RequisitionHeaderModel model)
        {
            return factory.RequisitionHeaderDao.Insert(model);
        }

        public void UpdateDoc(SequenceDocModel model)
        {
            factory.DocSeqDao.Update(model);
        }

        public void UpdatePR(RequisitionHeaderModel model)
        {
            factory.RequisitionHeaderDao.Update(model);
        }

        public void DeletePR(RequisitionHeaderModel model)
        {
            factory.RequisitionHeaderDao.Delete(model);
        }

        public int InsertPRLine(RequisitionLineModel model)
        {
            return factory.RequisitionLineDao.Insert(model);
        }

        public void UpdatePRLine(RequisitionLineModel model)
        {
            factory.RequisitionLineDao.Update(model);
        }

        public void DeletePRLine(RequisitionLineModel model)
        {
            factory.RequisitionLineDao.Delete(model);
        }

        public void UpdateCancelFlag(int reqId)
        {
            var reqLines = factory.RequisitionLineDao.GetByHeaderID(reqId);
            var grpList = reqLines.GroupBy(item => item.CancelFlag)
                                  .Select(group => new { Lines = group.Key, ReqLines = group.ToList() })
                                  .ToList();

            if(grpList.Count == 1)
            {
                if (grpList.FirstOrDefault().Lines)
                {
                    var head = factory.RequisitionHeaderDao.GetByID(reqId);
                    head.CancelFlag = true;
                    head.LastUpdateDate = DateTime.Now;
                    factory.RequisitionHeaderDao.Update(head);
                }                    
            }
        }

        public void UpdatePurchasedFlag(int reqId)
        {
            var reqLines = factory.RequisitionLineDao.GetByHeaderID(reqId);
            var grpList = reqLines.GroupBy(item => item.PurchasedFlag)
                                  .Select(group => new { Lines = group.Key, ReqLines = group.ToList() })
                                  .ToList();

            if (grpList.Count == 1)
            {
                if (grpList.FirstOrDefault().Lines)
                {
                    var head = factory.RequisitionHeaderDao.GetByID(reqId);
                    head.PurchasedFlag = true;
                    head.LastUpdateDate = DateTime.Now;
                    factory.RequisitionHeaderDao.Update(head);
                }
            }
        }

        public int KeepLogging(POLoggingModel model)
        {
            return factory.POLoggingDao.Insert(model);
        }
        #endregion
    }
}
