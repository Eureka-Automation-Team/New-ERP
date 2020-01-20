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
    public class ItemMasterSrv : IItemMasterSrv
    {
        private static readonly string provider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly IFactory factory = Factories.GetFactory(provider);

        public List<ItemMasterModel> GetItemAll()
        {
            return factory.ItemMasterDao.GetAll();
        }

        public ItemMasterModel GetItemByID(int id)
        {
            return factory.ItemMasterDao.GetByID(id);
        }

        public ItemMasterModel GetItemByNumber(string number)
        {
            return factory.ItemMasterDao.GetByNumber(number);
        }

        public string GetRunningLotByItemID(int id)
        {
            string lotNo = string.Empty;
            string prefix = string.Empty;
            int runningNo = 0;
            DateTime lastUpdate;
            ItemMasterModel item = factory.ItemMasterDao.GetByID(id);

            if(item != null)
            {
                lastUpdate = ((item.LastUpdateLot == null) ? DateTime.Now : (DateTime)item.LastUpdateLot);

                if (DateTime.Now.Date != lastUpdate.Date)
                {
                    runningNo = 1;
                }
                else
                {
                    runningNo = item.LastLotRunning + 1;
                }

                prefix = DateTime.Now.ToString("yyMMdd");
                lotNo = string.Format("{0}-{1}", prefix, runningNo.ToString().PadLeft(4, '0'));

                item.LastUpdateLot = DateTime.Now;
                item.LastLotRunning = runningNo;
                UpdateItem(item);
            }

            return lotNo;
        }

        public int InsertItem(ItemMasterModel model)
        {
            model.CreationDate = DateTime.Now;
            model.LastUpdateDate = DateTime.Now;

            return factory.ItemMasterDao.Insert(model);
        }

        public void UpdateItem(ItemMasterModel model)
        {
            model.LastUpdateDate = DateTime.Now;

            factory.ItemMasterDao.Update(model);
        }

        public void DeleteItem(ItemMasterModel model)
        {
            factory.ItemMasterDao.Delete(model);
        }

        public ItemMasterModel GetItemByManuId(string manuId)
        {
            return factory.ItemMasterDao.GetByManuID(manuId);
        }

        public string GenLotNumber(string type)
        {
            string docNo = string.Empty;
            string preFix = string.Empty;
            int running = 0;
            SequenceDocModel rowDoc = factory.DocSeqDao.GetByType("LOT_NUMBER");

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

        public void UpdateDoc(SequenceDocModel model)
        {
            factory.DocSeqDao.Update(model);
        }
    }
}
