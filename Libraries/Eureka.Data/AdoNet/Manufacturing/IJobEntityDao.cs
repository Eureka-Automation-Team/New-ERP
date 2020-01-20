using Eureka.Core.Domain.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Manufacturing
{
    public interface IJobEntityDao
    {
        JobEntityModel GetByID(int id);

        JobEntityModel GetByPOLineID(int poLineId);

        JobEntityModel GetByJobName(string jobName);

        List<JobEntityModel> GetAll();

        List<JobEntityModel> GetByDate(DateTime startDate, DateTime endDate);

        int Insert(JobEntityModel model);

        void Update(JobEntityModel model);

        void Delete(JobEntityModel model);
    }
}
