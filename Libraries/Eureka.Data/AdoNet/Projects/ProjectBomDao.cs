using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Projects;

namespace Eureka.Data.AdoNet.Projects
{
    public class ProjectBomDao : IProjectBomDao
    {
        private static Db db = new Db("ms_sql");

        public List<ProjectBomModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ProjectBomModel> GetByDate(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public ProjectBomModel GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public ProjectBomModel GetByNum(string number)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProjectBomModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(ProjectBomModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProjectBomModel model)
        {
            string sql = @"DELETE FROM prj_project_costs WHERE proj_cost_id = @proj_cost_id";

            object[] parms = { "@proj_cost_id", model.Id };
            db.Update(sql, parms);
        }

        // creates a Member object based on DataReader
        private static Func<IDataReader, ProjectBomModel> Make = reader =>
             new ProjectBomModel
             {
                 Id = reader["line_id"].AsInt(),
                 ProjectId = reader["project_id"].AsInt(),
                 LineNo = reader["line_num"].AsInt(),
                 Status = reader["status"].AsInt(),
                 ItemNo = reader["item_no"].AsString(),
                 ItemDescription = reader["item_description"].AsString(),
                 Quantity = reader["quantity"].AsDouble(),
                 Material = reader["material"].AsString(),
                 Revision = reader["revision"].AsInt(),
                 MenuID = reader["menu_id"].AsString(),
                 Brand = reader["brand"].AsString(),
                 Remarks = reader["remarks"].AsString(),
                 CostCode = reader["cost_code"].AsString(),
                 BomNo = reader["bom_no"].AsString(),
                 CostPrice = reader["cost_price"].AsDouble(),
                 DueDate = reader["due_date"].AsDateTime(),
                 TotalCost = reader["total_cost"].AsDouble(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdateBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt()
             };

        private object[] Take(ProjectBomModel model)
        {
            return new object[]
            {
                "@line_id", model.Id,
                "@project_id", model.ProjectId,
                "@line_num", model.LineNo,
                "@status", model.Status,
                "@item_no", model.ItemNo,
                "@item_description", model.ItemDescription,
                "@quantity", model.Quantity,
                "@material", model.Material,
                "@revision", model.Revision,
                "@menu_id", model.MenuID,
                "@brand", model.Brand,
                "@remarks", model.Remarks,
                "@cost_code", model.CostCode,
                "@bom_no", model.BomNo,
                "@cost_price", model.CostPrice,
                "@due_date", model.DueDate,
                "@total_cost", model.TotalCost,
                "@messages", model.Messages,
                "@urgent_flag", model.UrgentFlag,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdateBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy
            };
        }
    }
}
