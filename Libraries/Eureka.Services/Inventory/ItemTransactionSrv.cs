using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Commons;
using Eureka.Core.Domain.Inventory;
using Eureka.Data;

namespace Eureka.Services.Inventory
{
    public class ItemTransactionSrv : IItemTransactionSrv
    {
        private static readonly string provider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly IFactory factory = Factories.GetFactory(provider);

        public List<ItemTransactionModel> GetTransAll()
        {
            return factory.ItemTransactionDao.GetAll();
        }

        public List<ItemTransactionModel> GetTransByDate(DateTime startDate, DateTime endDate)
        {
            return factory.ItemTransactionDao.GetByDate(startDate, endDate);
        }

        public ItemTransactionModel GetTransByID(int id)
        {
            return factory.ItemTransactionDao.GetByID(id);
        }

        public List<ItemTransactionModel> GetTransByItemID(int itemId)
        {
            return factory.ItemTransactionDao.GetItemID(itemId);
        }

        public List<ItemTransactionModel> GetTransByStartDate(DateTime startDate)
        {
            return factory.ItemTransactionDao.GetByStartDate(startDate);
        }

        public string GenIssueNumber(string type)
        {
            string docNo = string.Empty;
            string preFix = string.Empty;
            int running = 0;
            SequenceDocModel rowDoc = factory.DocSeqDao.GetByType(type);

            if (rowDoc != null)
            {
                string[] words = rowDoc.Prefix.Split('#');
                preFix = DateTime.Now.ToString(words[0]) + words[1];

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

        public int InsertTrans(ItemTransactionModel model)
        {
            model.CreationDate = DateTime.Now;
            model.LastUpdateDate = DateTime.Now;

            return factory.ItemTransactionDao.Insert(model);
        }

        public void UpdateTrans(ItemTransactionModel model)
        {
            model.LastUpdateDate = DateTime.Now;
            factory.ItemTransactionDao.Update(model);
        }

        public void DeleteTrans(ItemTransactionModel model)
        {
            factory.ItemTransactionDao.Delete(model);
        }

        public void UpdateDoc(SequenceDocModel model)
        {
            factory.DocSeqDao.Update(model);
        }

        public SequenceDocModel GetSequenceDoc(string type)
        {
            return factory.DocSeqDao.GetByType(type);
        }
    }
}
