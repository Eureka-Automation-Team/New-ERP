using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Inventory;

namespace Eureka.Data.AdoNet.Inventory
{
    public class ShelfLocationDao : IShelfLocationDao
    {
        private static Db db = new Db("ms_sql");

        public List<ShelfLocationModel> GetAll()
        {
            string sql = @"SELECT loc.location_id, loc.level_no, loc.column_no
		                        , loc.combind_location, loc.item_id, loc.task_id
		                        , loc.reserve_flag, loc.fill_flag, loc.available_flag
		                        , loc.created_by, loc.creation_date, loc.last_updated_by
		                        , loc.last_update_date, loc.attribute1, loc.attribute2
		                        , loc.attribute3, loc.attribute4, loc.attribute5
		                        , loc.priority
	                        FROM inv_locations loc
                            ORDER BY loc.priority, loc.level_no, loc.column_no ASC";

            return db.Read(sql, Make).ToList();
        }

        public List<ShelfLocationModel> GetAllAvailable()
        {
            string sql = @"SELECT loc.location_id, loc.level_no, loc.column_no
		                        , loc.combind_location, loc.item_id, loc.task_id
		                        , loc.reserve_flag, loc.fill_flag, loc.available_flag
		                        , loc.created_by, loc.creation_date, loc.last_updated_by
		                        , loc.last_update_date, loc.attribute1, loc.attribute2
		                        , loc.attribute3, loc.attribute4, loc.attribute5
		                        , loc.priority
	                        FROM inv_locations loc
                            WHERE loc.available_flag = 1                            
                            ORDER BY loc.priority, loc.level_no, loc.column_no ASC";

            return db.Read(sql, Make).ToList();
        }

        public List<ShelfLocationModel> GetAllReserved()
        {
            string sql = @"SELECT loc.location_id, loc.level_no, loc.column_no
		                        , loc.combind_location, loc.item_id, loc.task_id
		                        , loc.reserve_flag, loc.fill_flag, loc.available_flag
		                        , loc.created_by, loc.creation_date, loc.last_updated_by
		                        , loc.last_update_date, loc.attribute1, loc.attribute2
		                        , loc.attribute3, loc.attribute4, loc.attribute5
		                        , loc.priority
	                        FROM inv_locations loc
                            WHERE loc.reserve_flag = 1
                                AND loc.available_flag = 1
                            ORDER BY loc.priority, loc.level_no, loc.column_no ASC";

            return db.Read(sql, Make).ToList();
        }

        public ShelfLocationModel GetByID(int id)
        {
            string sql = @"SELECT loc.location_id, loc.level_no, loc.column_no
		                        , loc.combind_location, loc.item_id, loc.task_id
		                        , loc.reserve_flag, loc.fill_flag, loc.available_flag
		                        , loc.created_by, loc.creation_date, loc.last_updated_by
		                        , loc.last_update_date, loc.attribute1, loc.attribute2
		                        , loc.attribute3, loc.attribute4, loc.attribute5
		                        , loc.priority
	                        FROM inv_locations loc
                            WHERE loc.location_id = @location_id";

            object[] parms = { "@location_id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(ShelfLocationModel model)
        {
            string sql =
                @"INSERT INTO inv_locations
                       (level_no
                       ,column_no
                       ,combind_location
                       ,item_id
                       ,task_id
                       ,reserve_flag
                       ,fill_flag
                       ,available_flag
                       ,created_by
                       ,creation_date
                       ,last_updated_by
                       ,last_update_date
                       ,attribute1
                       ,attribute2
                       ,attribute3
                       ,attribute4
                       ,attribute5
                       ,priority)
                 VALUES
                       (@level_no
                       ,@column_no
                       ,@combind_location
                       ,@item_id
                       ,@task_id
                       ,@reserve_flag
                       ,@fill_flag
                       ,@available_flag
                       ,@created_by
                       ,@creation_date
                       ,@last_updated_by
                       ,@last_update_date
                       ,@attribute1
                       ,@attribute2
                       ,@attribute3
                       ,@attribute4
                       ,@attribute5
                       ,@priority)";

            return db.Insert(sql, Take(model));
        }

        public void Update(ShelfLocationModel model)
        {
            string sql =
            @"UPDATE inv_locations
                   SET level_no = @level_no
                      ,column_no = @column_no
                      ,combind_location = @combind_location
                      ,item_id = @item_id
                      ,task_id = @task_id
                      ,reserve_flag = @reserve_flag
                      ,fill_flag = @fill_flag
                      ,available_flag = @available_flag
                      ,created_by = @created_by
                      ,creation_date = @creation_date
                      ,last_updated_by = @last_updated_by
                      ,last_update_date = @last_update_date
                      ,attribute1 = @attribute1
                      ,attribute2 = @attribute2
                      ,attribute3 = @attribute3
                      ,attribute4 = @attribute4
                      ,attribute5 = @attribute5
                      ,priority = @priority
                 WHERE location_id = @location_id";

            db.Update(sql, Take(model));
        }

        public void Delete(ShelfLocationModel model)
        {
            string sql = @"DELETE FROM inv_locations WHERE location_id = @location_id";

            object[] parms = { "@location_id", model.LocationId };
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
        private static Func<IDataReader, ShelfLocationModel> Make = reader =>
             new ShelfLocationModel
             {
                 LocationId = reader["location_id"].AsInt(),
                 LevelNo = reader["level_no"].AsInt(),
                 ColumnNo = reader["column_no"].AsInt(),
                 CombindLocation = reader["combind_location"].AsString(),
                 ItemId = reader["item_id"].AsInt(),
                 TaskId = reader["task_id"].AsInt(),
                 ReserveFlag = (reader["reserve_flag"].AsInt() == 1) ? true : false,
                 FillFlag = (reader["fill_flag"].AsInt() == 1) ? true : false,
                 AvailableFlag = (reader["available_flag"].AsInt() == 1) ? true : false,
                 CreatedBy = reader["created_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 Attribute1 = reader["attribute1"].AsString(),
                 Attribute2 = reader["attribute2"].AsString(),
                 Attribute3 = reader["attribute3"].AsString(),
                 Attribute4 = reader["attribute4"].AsString(),
                 Attribute5 = reader["attribute5"].AsString(),
                 Priority = reader["priority"].AsInt()
             };

        private object[] Take(ShelfLocationModel model)
        {
            return new object[]
            {
                "@location_id", model.LocationId,
                "@level_no", model.LevelNo,
                "@column_no", model.ColumnNo,
                "@combind_location", model.CombindLocation,
                "@item_id", model.ItemId,
                "@task_id", model.TaskId,
                "@reserve_flag", (model.ReserveFlag) ? 1 : 0,
                "@fill_flag", (model.FillFlag) ? 1 : 0,
                "@available_flag", (model.AvailableFlag) ? 1 : 0,
                "@created_by", model.CreatedBy,
                "@creation_date", model.CreationDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@last_update_date", model.LastUpdateDate,
                "@attribute1", model.Attribute1,
                "@attribute2", model.Attribute2,
                "@attribute3", model.Attribute3,
                "@attribute4", model.Attribute4,
                "@attribute5", model.Attribute5,
                "@priority", model.Priority
            };
        }
    }
}
