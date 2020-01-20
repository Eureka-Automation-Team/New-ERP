using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Projects;

namespace Eureka.Data.AdoNet.Projects
{
    public class CostsBomsRelatedDao : ICostsBomsRelatedDao
    {
        private static Db db = new Db("ms_sql");

        public List<CostsBomsRelatedModel> GetAll()
        {
            string sql = @"SELECT cb.bom_id, cb.cost_id, cb.attribute1
	                        , cb.attribute2, cb.attribute3, cb.attribute4
	                        , cb.attribute5, cb.last_update_date, cb.last_updated_by
	                        , cb.creation_date, cb.created_by, cb.enable_flag
	                        , bom.bom_number, cst.cost_code
                          FROM prj_costs_boms cb
                          LEFT JOIN prj_boms bom on(cb.bom_id = bom.bom_id)
                          LEFT JOIN prj_cost_groups cst ON(cb.cost_id = cst.cost_id)
                          ORDER BY cb.creation_date";
       
            return db.Read(sql, MakeWithStats).ToList();
        }

        public CostsBomsRelatedModel GetByBomAndCostID(int bomId, int costId)
        {
            string sql = @"SELECT cb.bom_id, cb.cost_id, cb.attribute1
	                        , cb.attribute2, cb.attribute3, cb.attribute4
	                        , cb.attribute5, cb.last_update_date, cb.last_updated_by
	                        , cb.creation_date, cb.created_by, cb.enable_flag
	                        , bom.bom_number, cst.cost_code
                          FROM prj_costs_boms cb
                          LEFT JOIN prj_boms bom on(cb.bom_id = bom.bom_id)
                          LEFT JOIN prj_cost_groups cst ON(cb.cost_id = cst.cost_id)
                          WHERE  cb.bom_id = @bom_id AND cb.cost_id = @cost_id";

            object[] parms = { "@bom_id", bomId, "@cost_id", costId };
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public List<CostsBomsRelatedModel> GetByBomID(int id)
        {
            string sql = @"SELECT cb.bom_id, cb.cost_id, cb.attribute1
	                        , cb.attribute2, cb.attribute3, cb.attribute4
	                        , cb.attribute5, cb.last_update_date, cb.last_updated_by
	                        , cb.creation_date, cb.created_by, cb.enable_flag
	                        , bom.bom_number, cst.cost_code
                          FROM prj_costs_boms cb
                          LEFT JOIN prj_boms bom on(cb.bom_id = bom.bom_id)
                          LEFT JOIN prj_cost_groups cst ON(cb.cost_id = cst.cost_id)
                          WHERE  cb.bom_id = @bom_id";

            object[] parms = { "@bom_id", id };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public List<CostsBomsRelatedModel> GetByCostID(int id)
        {
            string sql = @"SELECT cb.bom_id, cb.cost_id, cb.attribute1
	                        , cb.attribute2, cb.attribute3, cb.attribute4
	                        , cb.attribute5, cb.last_update_date, cb.last_updated_by
	                        , cb.creation_date, cb.created_by, cb.enable_flag
	                        , bom.bom_number, cst.cost_code
                          FROM prj_costs_boms cb
                          LEFT JOIN prj_boms bom on(cb.bom_id = bom.bom_id)
                          LEFT JOIN prj_cost_groups cst ON(cb.cost_id = cst.cost_id)
                          WHERE  cb.cost_id = @cost_id";

            object[] parms = { "@cost_id", id};
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public int Insert(CostsBomsRelatedModel model)
        {
            string sql =
                @"INSERT INTO prj_costs_boms
                           (bom_id
                           ,cost_id
                           ,attribute1
                           ,attribute2
                           ,attribute3
                           ,attribute4
                           ,attribute5
                           ,last_update_date
                           ,last_updated_by
                           ,creation_date
                           ,created_by
                           ,enable_flag)
                     VALUES
                           (@bom_id
                           ,@cost_id
                           ,@attribute1
                           ,@attribute2
                           ,@attribute3
                           ,@attribute4
                           ,@attribute5
                           ,@last_update_date
                           ,@last_updated_by
                           ,@creation_date
                           ,@created_by
                           ,@enable_flag)";

            return db.Insert(sql, Take(model));
        }

        public void Update(CostsBomsRelatedModel model)
        {
            string sql =
            @"UPDATE prj_costs_boms
                   SET bom_id = @bom_id
                      ,cost_id = @cost_id
                      ,attribute1 = @attribute1
                      ,attribute2 = @attribute2
                      ,attribute3 = @attribute3
                      ,attribute4 = @attribute4
                      ,attribute5 = @attribute5
                      ,last_update_date = @last_update_date
                      ,last_updated_by = @last_updated_by
                      ,enable_flag = @enable_flag
               WHERE bom_id = @bom_id AND cost_id = @cost_id";

            db.Update(sql, Take(model));
        }

        public void Delete(CostsBomsRelatedModel model)
        {
            string sql = @"DELETE FROM prj_costs_boms WHERE bom_id = @bom_id AND cost_id = @cost_id";

            object[] parms = { "@bom_id", model.BomId, "@cost_id", model.CostId };
            db.Update(sql, parms);
        }

        // creates a Members object with order statistics based on DataReader              
        private static Func<IDataReader, CostsBomsRelatedModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            row.CostCode = reader["cost_code"].AsString();
            row.BomNumber = reader["bom_number"].AsString();
            return row;
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, CostsBomsRelatedModel> Make = reader =>
             new CostsBomsRelatedModel
             {
                 BomId = reader["bom_id"].AsInt(),
                 CostId = reader["cost_id"].AsInt(),
                 Attribute1 = reader["attribute1"].AsString(),
                 Attribute2 = reader["attribute2"].AsString(),
                 Attribute3 = reader["attribute3"].AsString(),
                 Attribute4 = reader["attribute4"].AsString(),
                 Attribute5 = reader["attribute5"].AsString(),
                 LastUpdateDate = (reader["last_update_date"] != DBNull.Value) ? reader["last_update_date"].AsDateTime() : (DateTime?)null,
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = (reader["creation_date"] != DBNull.Value) ? reader["creation_date"].AsDateTime() : (DateTime?)null,
                 CreatedBy = reader["created_by"].AsInt(),
                 EnableFlag = (reader["enable_flag"].AsString() == "Y") ? true : false
             };

        private object[] Take(CostsBomsRelatedModel model)
        {
            return new object[]
            {
                "@bom_id", model.BomId,
                "@cost_id", model.CostId,
                "@attribute1", model.CostCode,      /***/
                "@attribute2", model.BomNumber,     /***/
                "@attribute3", model.Attribute3,
                "@attribute4", model.Attribute4,
                "@attribute5", model.Attribute5,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@enable_flag", (model.EnableFlag) ? "Y" : "N"
            };
        }
    }
}
