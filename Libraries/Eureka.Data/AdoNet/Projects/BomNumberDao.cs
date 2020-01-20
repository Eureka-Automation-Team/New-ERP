using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Projects;

namespace Eureka.Data.AdoNet.Projects
{
    public class BomNumberDao : IBomNumberDao
    {
        private static Db db = new Db("ms_sql");

        public List<BomNumberModel> GetAll()
        {
            string sql = @"SELECT bom_id
                                  ,bom_number
                                  ,description
                                  ,last_update_date
                                  ,last_updated_by
                                  ,creation_date
                                  ,created_by
                                  ,enable_flag
                              FROM prj_boms   
                            ORDER BY bom_number DESC";

            object[] parms = { "@enable_flag", "Y" };
            return db.Read(sql, Make, parms).ToList();
        }

        public BomNumberModel GetByID(int id)
        {
            string sql = @"SELECT bom_id
                                  ,bom_number
                                  ,description
                                  ,last_update_date
                                  ,last_updated_by
                                  ,creation_date
                                  ,created_by
                                  ,enable_flag
                              FROM prj_boms
                         WHERE bom_id = @bom_id
                            AND enable_flag = @enable_flag";

            object[] parms = { "@bom_id", id, "@enable_flag", "Y" };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(BomNumberModel model)
        {
            string sql =
                @"INSERT INTO prj_boms
                           (bom_number
                           ,description
                           ,last_update_date
                           ,last_updated_by
                           ,creation_date
                           ,created_by
                           ,enable_flag)
                     VALUES
                           (@bom_number
                           ,@description
                           ,@last_update_date
                           ,@last_updated_by
                           ,@creation_date
                           ,@created_by
                           ,@enable_flag)";

            return db.Insert(sql, Take(model));
        }

        public void Update(BomNumberModel model)
        {
            string sql =
            @"UPDATE prj_boms
               SET bom_number = @bom_number
                  ,description = @description
                  ,last_update_date = @last_update_date
                  ,last_updated_by = @last_updated_by
                  ,enable_flag = @enable_flag
               WHERE bom_id = @bom_id";

            db.Update(sql, Take(model));
        }

        public void Delete(BomNumberModel model)
        {
            string sql = @"DELETE FROM prj_boms WHERE bom_id = @bom_id";

            object[] parms = { "@bom_id", model.BomId };
            db.Update(sql, parms);
        }

        // creates a Members object with order statistics based on DataReader      
        /*
        private static Func<IDataReader, BomNumberModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            row.VendorName = reader["vendor_name"].AsString();
            row.TermDesc = reader["description"].AsString();
            row.BuyerName = reader["USER_NAME"].AsString();
            return row;
        };*/

        // creates a Member object based on DataReader
        private static Func<IDataReader, BomNumberModel> Make = reader =>
             new BomNumberModel
             {
                 BomId = reader["bom_id"].AsInt(),
                 BomNumber = reader["bom_number"].AsString(),
                 Description = reader["description"].AsString(),
                 LastUpdateDate = (reader["last_update_date"] != DBNull.Value) ? reader["last_update_date"].AsDateTime() : (DateTime?)null,
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = (reader["creation_date"] != DBNull.Value) ? reader["creation_date"].AsDateTime() : (DateTime?)null,
                 CreatedBy = reader["created_by"].AsInt(),
                 EnableFlag = (reader["enable_flag"].AsString() == "Y") ? true : false
             };

        private object[] Take(BomNumberModel model)
        {
            return new object[]
            {
                "@bom_id", model.BomId,
                "@bom_number", model.BomNumber,
                "@description", model.Description,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@enable_flag", (model.EnableFlag) ? "Y" : "N"
            };
        }
    }
}
