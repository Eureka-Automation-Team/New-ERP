using Eureka.Core.Domain.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Services.Projects
{
    public interface IProjectSrv
    {
        List<ProjectModel> GetProjectAll();

        ProjectModel GetProjectByNumber(string projNumber);

        List<ProjectModel> GetProjectByDate(DateTime startDate, DateTime endDate);

        List<ProjectCostModel> GetProjectCostByProjID(int projId);

        List<ProjectCostModel> ProjectCost_Reset(int projId);

        List<CostGroupModel> GetCostGropAll();

        List<CostGroupModel> GetCostGropByBOMID(int id);

        List<BomNumberModel> GetBomNumbersAll();

        List<CostsBomsRelatedModel> GetCostsByBomID(int bomId);

        ProjectCostModel GetByProjectCost(string projectNum, string costCode);

        List<ProjectCostModel> ProjectCost_PurchaseOnly(int projId);

        double GetCostUsage(string projectNum, string costCode);

        int InsertProjCost(ProjectCostModel model);
        void UpdateProjCost(ProjectCostModel model);
    }
}
