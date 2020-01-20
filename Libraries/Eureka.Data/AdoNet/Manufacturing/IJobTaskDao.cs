using Eureka.Core.Domain.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Manufacturing
{
    public interface IJobTaskDao
    {
        List<JobTaskModel> GetPendingTask();

        List<JobTaskModel> GetInspectionTask();

        JobTaskModel GetByID(int id);

        JobTaskModel GetReadyToTransferNC();

        List<JobTaskModel> GetByJobID(int jobId);

        List<JobTaskModel> GetByDateRange(DateTime startDate, DateTime endDate);

        int Insert(JobTaskModel model);

        void Update(JobTaskModel model);

        void Delete(JobTaskModel model);
    }
}
