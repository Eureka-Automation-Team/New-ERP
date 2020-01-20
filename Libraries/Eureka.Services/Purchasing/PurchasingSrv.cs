using Eureka.Core.Domain.Commons;
using Eureka.Core.Domain.Purchasing;
using Eureka.Data;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Eureka.Services.Purchasing
{
    public class PurchasingSrv : IPurchasingSrv
    {
        private static readonly string provider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly IFactory factory = Factories.GetFactory(provider);

        #region GET

        public List<POHeaderModel> GetPOAll()
        {
            return factory.POHeaderDao.GetAll();
        }

        public List<POHeaderModel> GetPOByDate(DateTime startDate, DateTime endDate)
        {
            return factory.POHeaderDao.GetByDate(startDate, endDate);
        }

        public POHeaderModel GetPOByID(int id)
        {
            return factory.POHeaderDao.GetByID(id);
        }

        public POHeaderModel GetPOByNumber(string number)
        {
            return factory.POHeaderDao.GetByPONum(number);
        }

        public POLineModel GetPOLineByID(int id)
        {
            return factory.POLineDao.GetByID(id);
        }

        public List<POLineModel> GetPOLineByPOID(int poId)
        {
            return factory.POLineDao.GetByPOID(poId);
        }

        public List<POLineModel> GetPOLineByPONumber(string number)
        {
            return factory.POLineDao.GetByPONum(number);
        }

        public string GetDocNoByType(string type)
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

        public List<CurrencyModel> GetCurrencies()
        {
            return factory.CurrencyDao.GetAll();
        }

        public CurrencyModel GetCurrencyByCode(string curCode)
        {
            return factory.CurrencyDao.GetByFormCurrency(curCode);
        }

        public List<TaxCodeModel> GetTaxCodes()
        {
            return factory.TaxCodeDao.GetAll();
        }

        public List<POReportModel> GetReportByID(int id)
        {
            return factory.POHeaderDao.GetPOReportByID(id);
        }

        public POLineLocationModel GetLineLocationByID(int id)
        {
            return factory.POLineLocationDao.GetByID(id);
        }

        public List<POLineLocationModel> GetLineLocationByPOID(int id)
        {
            return factory.POLineLocationDao.GetByPOID(id);
        }

        public List<POLineLocationModel> GetLineLocationByPOLineID(int id)
        {
            return factory.POLineLocationDao.GetByPOLineID(id);
        }

        public List<POLineLocationModel> GetLineLocationByRcvID(int id)
        {
            return factory.POLineLocationDao.GetByReciptID(id);
        }

        public List<POLineLocationModel> GetLineLocationByRcvLineID(int id)
        {
            return factory.POLineLocationDao.GetByReciptLineID(id);
        }

        #endregion GET

        #region POST

        public int InsertPO(POHeaderModel model)
        {
            model.CreationDate = DateTime.Now;
            model.LastUpdateDate = DateTime.Now;

            return factory.POHeaderDao.Insert(model);
        }

        public int InsertPOLine(POLineModel model)
        {
            model.CreationDate = DateTime.Now;
            model.LastUpdateDate = DateTime.Now;

            return factory.POLineDao.Insert(model);
        }

        public void UpdatePO(POHeaderModel model)
        {
            model.LastUpdateDate = DateTime.Now;

            factory.POHeaderDao.Update(model);
        }

        public void UpdatePOLine(POLineModel model)
        {
            model.LastUpdateDate = DateTime.Now;

            factory.POLineDao.Update(model);
        }

        public void DeletePO(POHeaderModel model)
        {
            factory.POHeaderDao.Delete(model);
        }

        public void DeletePOLine(POLineModel model)
        {
            factory.POLineDao.Delete(model);
        }

        public void UpdateDoc(SequenceDocModel model)
        {
            factory.DocSeqDao.Update(model);
        }

        public int InsertPoLineLocation(POLineLocationModel model)
        {
            model.CreationDate = DateTime.Now;
            model.LastUpdateDate = DateTime.Now;

            return factory.POLineLocationDao.Insert(model);
        }

        public void UpdatePoLineLocation(POLineLocationModel model)
        {
            model.LastUpdateDate = DateTime.Now;

            factory.POLineLocationDao.Update(model);
        }

        public void DeletePoLineLocation(POLineLocationModel model)
        {
            factory.POLineLocationDao.Delete(model);
        }

        public List<POLineModel> GetPOLineAll()
        {
            return factory.POLineDao.GetAll();
        }

        public CurrencyModel GetToCurrencyByCode(string curCode)
        {
            return factory.CurrencyDao.GetByToCurrency(curCode);
        }

        #endregion POST
    }
}