using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Projects;

namespace Eureka.Data.AdoNet.Projects
{
    public class CostGroupDao : ICostGroupDao
    {
        private static Db db = new Db("ms_sql");

        public List<CostGroupModel> GetAll()
        {
            string sql = @"SELECT  cost_id , cost_code, making_flag
                              , cost_desc , cost_class , last_update_date 
                              , last_updated_by , creation_date , created_by 
                          FROM  prj_cost_groups
                          ORDER BY cost_code ASC";

            return db.Read(sql, Make).ToList();
        }

        public List<CostGroupModel> GetByBOMID(int id)
        {
            string sql = @"SELECT  cs.cost_id , cs.cost_code , cs.making_flag
                                , cs.cost_desc , cs.cost_class , cs.last_update_date 
                                , cs.last_updated_by , cs.creation_date , cs.created_by 
                            FROM  prj_cost_groups cs
                            LEFT JOIN prj_costs_boms bm ON(cs.cost_id = bm.cost_id)
                            WHERE bm.bom_id = @bom_id";

            object[] parms = { "@bom_id", id };
            return db.Read(sql, Make, parms).ToList();
        }

        public CostGroupModel GetByID(int id)
        {
            string sql = @"SELECT  cost_id , cost_code , making_flag
                              , cost_desc , cost_class , last_update_date 
                              , last_updated_by , creation_date , created_by 
                          FROM  prj_cost_groups
                            WHERE cost_id = @cost_id";

            object[] parms = { "@cost_id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public CostGroupModel GetByCode(string code)
        {
            string sql = @"SELECT  cost_id , cost_code, making_flag 
                              , cost_desc , cost_class , last_update_date 
                              , last_updated_by , creation_date , created_by 
                          FROM  prj_cost_groups
                            WHERE cost_code = @cost_code";

            object[] parms = { "@cost_code", code };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(CostGroupModel model)
        {
            string sql =
                @"INSERT INTO  prj_cost_groups 
                       ( cost_id 
                       , cost_code 
                       , cost_desc 
                       , cost_class 
                       , making_flag
                       , last_update_date 
                       , last_updated_by 
                       , creation_date 
                       , created_by )
                 VALUES
                       ( @cost_id
                       , @cost_code
                       , @cost_desc
                       , @cost_class
                       , @making_flag
                       , @last_update_date
                       , @last_updated_by
                       , @creation_date
                       , @created_by)";

            return db.Insert(sql, Take(model));
        }

        public void Update(CostGroupModel model)
        {
            string sql =
            @"UPDATE prj_cost_groups
                   SET cost_id = @cost_id
                      ,cost_code = @cost_code
                      ,cost_desc = @cost_desc
                      ,cost_class = @cost_class
                      ,making_flag = @making_flag
                      ,last_update_date = @last_update_date
                      ,last_updated_by = @last_updated_by
                 WHERE cost_id = @cost_id";

            db.Update(sql, Take(model));
        }

        public void Delete(CostGroupModel model)
        {
            string sql = @"DELETE FROM prj_cost_groups WHERE cost_id = @cost_id";

            object[] parms = { "@cost_id", model.Id };
            db.Update(sql, parms);
        }

        // creates a Member object based on DataReader
        private static Func<IDataReader, CostGroupModel> Make = reader =>
             new CostGroupModel
             {
                 Id = reader["cost_id"].AsInt(),
                 CostCode = reader["cost_code"].AsString(),
                 CostDescription = reader["cost_desc"].AsString(),
                 CostClass = reader["cost_class"].AsString(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdateBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 MakingFlag = reader["making_flag"].AsString() == "Y" ? true : false
             };

        private object[] Take(CostGroupModel model)
        {
            return new object[]
            {
                "@cost_id", model.Id,
                "@cost_code", model.CostCode,
                "@cost_desc", model.CostDescription,
                "@cost_class", model.CostClass,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdateBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@making_flag", model.MakingFlag ? "Y" : "N"
            };
        }
    }
}
