using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Projects;
using Eureka.Data;

namespace Eureka.Services.Projects
{
    public class ProjectSrv : IProjectSrv
    {
        private static readonly string provider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly IFactory factory = Factories.GetFactory(provider);

        public List<BomNumberModel> GetBomNumbersAll()
        {
            return factory.BomNumberDao.GetAll();
        }

        public ProjectCostModel GetByProjectCost(string projectNum, string costCode)
        {
            return factory.ProjectCostDao.GetByProjectCost(projectNum, costCode);
        }

        public List<CostGroupModel> GetCostGropAll()
        {
            return factory.CostGroupDao.GetAll();
        }

        public List<CostGroupModel> GetCostGropByBOMID(int id)
        {
            return factory.CostGroupDao.GetByBOMID(id);
        }

        public List<CostsBomsRelatedModel> GetCostsByBomID(int bomId)
        {
            return factory.CostsBomsRelatedDao.GetByBomID(bomId);
        }

        public double GetCostUsage(string projectNum, string costCode)
        {
            return factory.ProjectCostDao.GetCostUsage(projectNum, costCode);
        }

        public List<ProjectModel> GetProjectAll()
        {
            return factory.ProjectDao.GetAll();
        }

        public List<ProjectCostModel> ProjectCost_Reset(int projId)
        {
            var budgetLines = GetProjectCostByProjID(projId);
            if (budgetLines != null)
            {
                foreach (var line in budgetLines)
                {
                    var budgetUsage = factory.ProjectCostDao.GetCostUsage(line.ProjectNum, line.CostCode);
                    var excessCost = factory.ProjectCostDao.GetExcessCost(line.ProjectNum, line.CostCode);
                    var actCost = factory.ProjectCostDao.GetActualCost(line.ProjectNum, line.CostCode);
                    var actCostInstock = factory.ProjectCostDao.GetActualCostInstock(line.ProjectNum, line.CostCode);
                    line.FcstCostAmount = budgetUsage + line.BeginCostUsaged; //Modify 23/9/2019
                    line.InstockCostAmount = Math.Abs(actCostInstock) + line.BeginCostUsagedInstock;
                    line.ActCostAmount = Math.Abs(actCost) + line.BeginCostActual;
                    
                    line.ExcessCost = excessCost;
                    UpdateProjCost(line);
                }
            }

            return budgetLines;
        }


        //GetCostUsagePurchaseOnly
        public List<ProjectCostModel> ProjectCost_PurchaseOnly(int projId)
        {
            var budgetLines = GetProjectCostByProjID(projId);
            if (budgetLines != null)
            {
                foreach (var line in budgetLines)
                {
                    var budgetUsage = factory.ProjectCostDao.GetCostUsagePurchaseOnly(line.ProjectNum, line.CostCode);
                    var excessCost = factory.ProjectCostDao.GetExcessCostPurchaseOnly(line.ProjectNum, line.CostCode);
                    var actCost = factory.ProjectCostDao.GetActualCost(line.ProjectNum, line.CostCode);
                    var actCostInstock = factory.ProjectCostDao.GetActualCostInstock(line.ProjectNum, line.CostCode);

                    line.FcstCostAmount = budgetUsage + line.BeginCostUsaged; //Modify 23/9/2019
                    line.ActCostAmount = Math.Abs(actCost) + line.BeginCostActual;
                    line.InstockCostAmount = Math.Abs(actCostInstock) + line.BeginCostUsagedInstock;
                    line.ExcessCost = excessCost;
                    //line.la
                    UpdateProjCost(line);
                }
            }

            return budgetLines;
        }

        public List<ProjectModel> GetProjectByDate(DateTime startDate, DateTime endDate)
        {
            return factory.ProjectDao.GetByDate(startDate, endDate);
        }

        public ProjectModel GetProjectByNumber(string projNumber)
        {
            return factory.ProjectDao.GetByNum(projNumber);
        }

        public List<ProjectCostModel> GetProjectCostByProjID(int projId)
        {
            return factory.ProjectCostDao.GetByProjectID(projId)
                    .OrderBy(x => x.CostCode)
                    .ToList();
        }

        public int InsertProjCost(ProjectCostModel model)
        {
            return factory.ProjectCostDao.Insert(model);
        }

        public void UpdateProjCost(ProjectCostModel model)
        {
            model.LastUpdateDate = DateTime.Now;
            factory.ProjectCostDao.Update(model);
        }
    }
}
