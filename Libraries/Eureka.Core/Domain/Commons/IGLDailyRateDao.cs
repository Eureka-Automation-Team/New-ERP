using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Commons
{
    public interface IGLDailyRateDao
    {
        List<GLDailyRateModel> GetAll();

        GLDailyRateModel GetByFormCurrency(string currCode);

        int Insert(GLDailyRateModel model);
    }
}
