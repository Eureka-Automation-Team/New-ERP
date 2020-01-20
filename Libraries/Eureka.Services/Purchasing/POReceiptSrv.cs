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
    public class POReceiptSrv : IPOReceiptSrv
    {
        private static readonly string provider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly IFactory factory = Factories.GetFactory(provider);

        #region GET
        public List<POReceiptHeaderModel> GetRcvHeaderAll()
        {
            return factory.POReceiptHaeaderDao.GetAll();
        }

        public POReceiptHeaderModel GetReceiptHeaderByNumber(string number)
        {
            return factory.POReceiptHaeaderDao.GetByNumber(number);
        }

        public List<POReceiptHeaderModel> GetRcvHeaderByDate(DateTime startDate, DateTime endDate)
        {
            return factory.POReceiptHaeaderDao.GetByDate(startDate, endDate);
        }

        public POReceiptHeaderModel GetReceiptHeaderByID(int id)
        {
            return factory.POReceiptHaeaderDao.GetByID(id);
        }

        public POReceiptLineModel GetRcvLineByID(int id)
        {
            return factory.POReceiptLineDao.GetByID(id);
        }

        public List<POReceiptLineModel> GetRcvLineByHeaderID(int id)
        {
            return factory.POReceiptLineDao.GetByReceiptID(id);
        }

        public string GenGRN(string type, DateTime receiptDate)
        {
            string docNo = string.Empty;
            string preFix = string.Empty;
            int running = 0;
            SequenceDocModel rowDoc = factory.DocSeqDao.GetByType(type);

            if (rowDoc != null)
            {
                string[] words = rowDoc.Prefix.Split('#');
                preFix = receiptDate.ToString(words[0]) + words[1];

                if (rowDoc.LastUpdateDate.Date == receiptDate.Date)     //Continue running
                {
                    running = rowDoc.NextVal;

                    rowDoc.NextVal = running + 1;
                    rowDoc.LastUpdateDate = DateTime.Now;
                    UpdateDoc(rowDoc);
                }
                else if(rowDoc.LastUpdateDate.Date > receiptDate.Date)  //Outstanding
                {
                    try
                    {
                        var maxId = factory.POReceiptHaeaderDao.GetByDate(receiptDate, receiptDate).Max(m => m.ReceiptHeaderId);
                        var rcv = factory.POReceiptHaeaderDao.GetByID(maxId);
                        if (rcv != null)
                        {
                            string[] number = rcv.ReceiptNum.Split('-');
                            running = Convert.ToInt32(number[1]) + 1;
                        }
                        else
                            running = 1;
                    }
                    catch
                    {
                        running = 1;
                    }

                }
                else   //Reset running a new day
                {
                    running = 1;
                    rowDoc.NextVal = running + 1;
                    rowDoc.LastUpdateDate = DateTime.Now;
                    UpdateDoc(rowDoc);
                }
                    
                docNo = string.Format("RC{0}{1}", preFix, running.ToString().PadLeft(rowDoc.RunningDigit, '0'));
            }
            return docNo;
        }

        public string GenReturn(string type)
        {
            string docNo = string.Empty;
            string preFix = string.Empty;
            int running = 0;
            SequenceDocModel rowDoc = factory.DocSeqDao.GetByType(type);

            if (rowDoc != null)
            {
                string[] words = rowDoc.Prefix.Split('#');
                preFix = DateTime.Now.ToString(words[0]) + words[1];

                if (rowDoc.LastUpdateDate.Date != DateTime.Now.Date)
                    running = 1;
                else
                    running = rowDoc.NextVal;

                rowDoc.NextVal = running + 1;
                rowDoc.LastUpdateDate = DateTime.Now;
                UpdateDoc(rowDoc);
                docNo = string.Format("RT{0}{1}", preFix, running.ToString().PadLeft(rowDoc.RunningDigit, '0'));
            }
            return docNo;
        }

        public List<RcvReportModel> GetReceiveReport(string startNo, string endNo)
        {
            return factory.POReceiptHaeaderDao.GetReceivedReportByID(startNo, endNo);
        }
        #endregion

        #region POST
        public int InsertRcvHead(POReceiptHeaderModel model)
        {
            model.CreationDate = DateTime.Now;
            model.LastUpdateDate = DateTime.Now;

            return factory.POReceiptHaeaderDao.Insert(model);
        }

        public void UpdateRcvHead(POReceiptHeaderModel model)
        {
            model.LastUpdateDate = DateTime.Now;

            factory.POReceiptHaeaderDao.Update(model);
        }

        public void DeleteRcvHead(POReceiptHeaderModel model)
        {
            factory.POReceiptHaeaderDao.Delete(model);
        }

        public int InsertRcvLine(POReceiptLineModel model)
        {
            model.CreationDate = DateTime.Now;
            model.LastUpdateDate = DateTime.Now;

            return factory.POReceiptLineDao.Insert(model);
        }

        public void UpdateRcvLine(POReceiptLineModel model)
        {
            model.LastUpdateDate = DateTime.Now;

            factory.POReceiptLineDao.Update(model);
        }

        public void DeleteRcvLine(POReceiptLineModel model)
        {
            factory.POReceiptLineDao.Delete(model);
        }

        public void UpdateDoc(SequenceDocModel model)
        {
            factory.DocSeqDao.Update(model);
        }
        #endregion
    }
}
