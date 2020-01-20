using Eureka.Core.Domain.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Manufacturing
{
    public interface IMachineDao
    {
        List<MachineModel> GetAll();

        MachineModel GetByID(int id);

        MachineModel GetByCode(string machineCode);

        int Insert(MachineModel model);

        void Update(MachineModel model);

        void Delete(MachineModel model);
    }
}
