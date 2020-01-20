using Eureka.Core.Domain.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Services.Manufacturing
{
    public interface IMachineSrv
    {
        //GET
        MachineModel GetByCode(string machineCode);
        MachineModel GetByID(int id);
        List<MachineModel> GetAll();

        //POST
        int Insert(MachineModel model);

        void Update(MachineModel model);

        void Delete(MachineModel model);
    }
}
