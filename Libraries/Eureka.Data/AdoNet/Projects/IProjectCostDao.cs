using Eureka.Core.Domain.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Projects
{
    public interface IProjectCostDao
    {
        // gets a specific Member
        ProjectCostModel GetByID(int id);

        // gets a sorted list of all Members
        List<ProjectCostModel> GetAll();

        // gets a sorted list of all Members
        List<ProjectCostModel> GetByProjectNum(string prjNum);

        // gets a sorted list of all Members
        List<ProjectCostModel> GetByProjectID(int prjId);

        // gets a sorted list of all Members
        List<ProjectCostModel> GetByCostCode(string costCode);

        ProjectCostModel GetByProjectCost(string projectNum, string costCode);

        double GetCostUsage(string projectNum, string costCode);

        double GetCostUsagePurchaseOnly(string projectNum, string costCode);

        double GetExcessCost(string projectNum, string costCode);

        double GetExcessCostPurchaseOnly(string projectNum, string costCode);

        double GetActualCost(string projectNum, string costCode);

        double GetActualCostInstock(string projectNum, string costCode);

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(ProjectCostModel model);

        // updates a Member
        void Update(ProjectCostModel model);

        // deletes a Member
        void Delete(ProjectCostModel model);
    }
}
