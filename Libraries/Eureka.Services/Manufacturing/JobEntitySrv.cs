using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Commons;
using Eureka.Core.Domain.Manufacturing;
using Eureka.Data;

namespace Eureka.Services.Manufacturing
{
    public class JobEntitySrv : IJobEntitySrv
    {
        private static readonly string provider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly IFactory factory = Factories.GetFactory(provider);

        public int InsertJob(JobEntityModel model)
        {
            model.CreationDate = DateTime.Now;
            model.LastUpdateDate = DateTime.Now;
            return factory.JobEntityDao.Insert(model);
        }

        public int InsertTask(JobTaskModel model)
        {
            model.CreationDate = DateTime.Now;
            model.LastUpdateDate = DateTime.Now;
            return factory.JobTaskDao.Insert(model);
        }

        public void UpdateJob(JobEntityModel model)
        {
            model.LastUpdateDate = DateTime.Now;
            factory.JobEntityDao.Update(model);
        }

        public void UpdateTask(JobTaskModel model)
        {
            model.LastUpdateDate = DateTime.Now;
            factory.JobTaskDao.Update(model);
        }

        public void DeleteJob(JobEntityModel model)
        {
            factory.JobEntityDao.Delete(model);
        }

        public void DeleteTask(JobTaskModel model)
        {
            factory.JobTaskDao.Delete(model);
        }

        public List<JobEntityModel> GetJobsByDate(DateTime startDate, DateTime endDate)
        {
            return factory.JobEntityDao.GetByDate(startDate, endDate);
        }

        public JobEntityModel GetExistingJobNumber(string JobNo)
        {
            return factory.JobEntityDao.GetByJobName(JobNo);
        }

        public List<JobTaskModel> GetTasksByJobID(int jobId)
        {
            return factory.JobTaskDao.GetByJobID(jobId);
        }

        public List<JobTaskModel> GetPendingTasks()
        {
            return factory.JobTaskDao.GetPendingTask();
        }

        public string GetNewJobNumber()
        {
            string docNo = string.Empty;
            string preFix = string.Empty;
            int running = 0;
            SequenceDocModel rowDoc = factory.DocSeqDao.GetByType("JOB_ENTITY");

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

        public void UpdateDoc(SequenceDocModel model)
        {
            factory.DocSeqDao.Update(model);
        }

        public List<JobTaskModel> GetInspectionTask()
        {
            return factory.JobTaskDao.GetInspectionTask();
        }

        public JobEntityModel GetExistingPO(int poLineId)
        {
            return factory.JobEntityDao.GetByPOLineID(poLineId);
        }

        public JobTaskModel GetReadyToTransferNC()
        {
            return factory.JobTaskDao.GetReadyToTransferNC();
        }

        public List<JobTaskModel> GetTasksByDateRange(DateTime startDate, DateTime endDate)
        {
            return factory.JobTaskDao.GetByDateRange(startDate, endDate);
        }

        public List<JobTaskModel> GetReleaseTasks()
        {
            return factory.JobTaskDao.GetReleaseTasks();
        }
    }
}
