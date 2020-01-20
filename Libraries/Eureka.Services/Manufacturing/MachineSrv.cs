using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Manufacturing;
using Eureka.Data;

namespace Eureka.Services.Manufacturing
{
    public class MachineSrv : IMachineSrv
    {
        private static readonly string provider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly IFactory factory = Factories.GetFactory(provider);

        public List<MachineModel> GetAll()
        {
            return factory.MachineDao.GetAll();
        }

        public MachineModel GetByCode(string machineCode)
        {
            return factory.MachineDao.GetByCode(machineCode);
        }

        public MachineModel GetByID(int id)
        {
            return factory.MachineDao.GetByID(id);
        }

        public int Insert(MachineModel model)
        {
            return factory.MachineDao.Insert(model);
        }

        public void Update(MachineModel model)
        {
            factory.MachineDao.Update(model);
        }

        public void Delete(MachineModel model)
        {
            factory.MachineDao.Delete(model);
        }
    }
}
