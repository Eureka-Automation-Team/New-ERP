using Eureka.Core.Domain.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Services.Manufacturing
{
    public interface IJobEntitySrv
    {
        //GET
        JobEntityModel GetExistingJobNumber(string JobNo);
        JobEntityModel GetExistingPO(int poLineId);
        List<JobTaskModel> GetPendingTasks();
        List<JobTaskModel> GetTasksByDateRange(DateTime startDate, DateTime endDate);
        List<JobTaskModel> GetInspectionTask();
        List<JobTaskModel> GetTasksByJobID(int jobId);
        List<JobEntityModel> GetJobsByDate(DateTime startDate, DateTime endDate);
        string GetNewJobNumber();
        JobTaskModel GetReadyToTransferNC();
        //POST
        int InsertJob(JobEntityModel model);

        int InsertTask(JobTaskModel model);

        void UpdateJob(JobEntityModel model);

        void UpdateTask(JobTaskModel model);

        void DeleteJob(JobEntityModel model);

        void DeleteTask(JobTaskModel model);
    }
}
