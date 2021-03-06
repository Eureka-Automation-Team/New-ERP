﻿using System;
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
        private static Db db = new Db("ms_sql_job");

        public List<ShelfLocationModel> GetAll()
        {
            string sql = @"SELECT loc.Id, loc.LevelNo, loc.ColumnNo
		                        , loc.CombindLocation, loc.ItemId, loc.TaskId
		                        , loc.ReserveFlag, loc.FillFlag, loc.AvailableFlag
		                        , loc.CreatedBy, loc.CreationDate, loc.LastUpdatedBy
		                        , loc.LastUpdateDate, loc.Attribute1, loc.Attribute2
		                        , loc.Attribute3, loc.Attribute4, loc.Attribute5
		                        , loc.Priority
	                        FROM ShelfLocations loc
                            ORDER BY loc.Priority, loc.LevelNo, loc.ColumnNo ASC";

            return db.Read(sql, Make).ToList();
        }

        public List<ShelfLocationModel> GetAllAvailable()
        {
            string sql = @"SELECT loc.Id, loc.LevelNo, loc.ColumnNo
		                        , loc.CombindLocation, loc.ItemId, loc.TaskId
		                        , loc.ReserveFlag, loc.FillFlag, loc.AvailableFlag
		                        , loc.CreatedBy, loc.CreationDate, loc.LastUpdatedBy
		                        , loc.LastUpdateDate, loc.Attribute1, loc.Attribute2
		                        , loc.Attribute3, loc.Attribute4, loc.Attribute5
		                        , loc.Priority
	                        FROM ShelfLocations loc
                            WHERE loc.AvailableFlag = 1                            
                            ORDER BY loc.Priority, loc.LevelNo, loc.ColumnNo ASC";

            return db.Read(sql, Make).ToList();
        }

        public List<ShelfLocationModel> GetAllReserved()
        {
            string sql = @"SELECT loc.Id, loc.LevelNo, loc.ColumnNo
		                        , loc.CombindLocation, loc.ItemId, loc.TaskId
		                        , loc.ReserveFlag, loc.FillFlag, loc.AvailableFlag
		                        , loc.CreatedBy, loc.CreationDate, loc.LastUpdatedBy
		                        , loc.LastUpdateDate, loc.Attribute1, loc.Attribute2
		                        , loc.Attribute3, loc.Attribute4, loc.Attribute5
		                        , loc.Priority
	                        FROM ShelfLocations loc
                            WHERE loc.ReserveFlag = 1
                                AND loc.AvailableFlag = 1
                            ORDER BY loc.Priority, loc.LevelNo, loc.ColumnNo ASC";

            return db.Read(sql, Make).ToList();
        }

        public ShelfLocationModel GetByID(int id)
        {
            string sql = @"SELECT loc.Id, loc.LevelNo, loc.ColumnNo
		                        , loc.CombindLocation, loc.ItemId, loc.TaskId
		                        , loc.ReserveFlag, loc.FillFlag, loc.AvailableFlag
		                        , loc.CreatedBy, loc.CreationDate, loc.LastUpdatedBy
		                        , loc.LastUpdateDate, loc.Attribute1, loc.Attribute2
		                        , loc.Attribute3, loc.Attribute4, loc.Attribute5
		                        , loc.Priority
	                        FROM ShelfLocations loc
                            WHERE loc.Id = @Id";

            object[] parms = { "@Id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(ShelfLocationModel model)
        {
            string sql =
                @"INSERT INTO ShelfLocations
                       (LevelNo
                       ,ColumnNo
                       ,CombindLocation
                       ,ItemId
                       ,TaskId
                       ,ReserveFlag
                       ,FillFlag
                       ,AvailableFlag
                       ,CreatedBy
                       ,CreationDate
                       ,LastUpdatedBy
                       ,LastUpdateDate
                       ,attribute1
                       ,attribute2
                       ,attribute3
                       ,attribute4
                       ,attribute5
                       ,Priority)
                 VALUES
                       (@LevelNo
                       ,@ColumnNo
                       ,@CombindLocation
                       ,@ItemId
                       ,@TaskId
                       ,@ReserveFlag
                       ,@FillFlag
                       ,@AvailableFlag
                       ,@CreatedBy
                       ,@CreationDate
                       ,@LastUpdatedBy
                       ,@LastUpdateDate
                       ,@attribute1
                       ,@attribute2
                       ,@attribute3
                       ,@attribute4
                       ,@attribute5
                       ,@Priority)";

            return db.Insert(sql, Take(model));
        }

        public void Update(ShelfLocationModel model)
        {
            string sql =
            @"UPDATE ShelfLocations
                   SET LevelNo = @LevelNo
                      ,ColumnNo = @ColumnNo
                      ,CombindLocation = @CombindLocation
                      ,ItemId = @ItemId
                      ,TaskId = @TaskId
                      ,ReserveFlag = @ReserveFlag
                      ,FillFlag = @FillFlag
                      ,AvailableFlag = @AvailableFlag
                      ,CreatedBy = @CreatedBy
                      ,CreationDate = @CreationDate
                      ,LastUpdatedBy = @LastUpdatedBy
                      ,LastUpdateDate = @LastUpdateDate
                      ,attribute1 = @attribute1
                      ,attribute2 = @attribute2
                      ,attribute3 = @attribute3
                      ,attribute4 = @attribute4
                      ,attribute5 = @attribute5
                      ,Priority = @Priority
                 WHERE Id = @Id";

            db.Update(sql, Take(model));
        }

        public void Delete(ShelfLocationModel model)
        {
            string sql = @"DELETE FROM ShelfLocations WHERE Id = @Id";

            object[] parms = { "@Id", model.LocationId };
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
                 LocationId = reader["Id"].AsInt(),
                 LevelNo = reader["LevelNo"].AsInt(),
                 ColumnNo = reader["ColumnNo"].AsInt(),
                 CombindLocation = reader["CombindLocation"].AsString(),
                 ItemId = reader["ItemId"].AsInt(),
                 TaskId = reader["TaskId"].AsInt(),
                 ReserveFlag = reader["ReserveFlag"].AsBool(),
                 FillFlag = reader["FillFlag"].AsBool(),
                 AvailableFlag = reader["AvailableFlag"].AsBool(),
                 CreatedBy = reader["CreatedBy"].AsInt(),
                 CreationDate = reader["CreationDate"].AsDateTime(),
                 LastUpdatedBy = reader["LastUpdatedBy"].AsInt(),
                 LastUpdateDate = reader["LastUpdateDate"].AsDateTime(),
                 Attribute1 = reader["attribute1"].AsString(),
                 Attribute2 = reader["attribute2"].AsString(),
                 Attribute3 = reader["attribute3"].AsString(),
                 Attribute4 = reader["attribute4"].AsString(),
                 Attribute5 = reader["attribute5"].AsString(),
                 Priority = reader["Priority"].AsInt()
             };

        private object[] Take(ShelfLocationModel model)
        {
            return new object[]
            {
                "@Id", model.LocationId,
                "@LevelNo", model.LevelNo,
                "@ColumnNo", model.ColumnNo,
                "@CombindLocation", model.CombindLocation,
                "@ItemId", model.ItemId,
                "@TaskId", model.TaskId,
                "@ReserveFlag", model.ReserveFlag,
                "@FillFlag", model.FillFlag,
                "@AvailableFlag", model.AvailableFlag,
                "@CreatedBy", model.CreatedBy,
                "@CreationDate", model.CreationDate,
                "@LastUpdatedBy", model.LastUpdatedBy,
                "@LastUpdateDate", model.LastUpdateDate,
                "@attribute1", model.Attribute1,
                "@attribute2", model.Attribute2,
                "@attribute3", model.Attribute3,
                "@attribute4", model.Attribute4,
                "@attribute5", model.Attribute5,
                "@Priority", model.Priority
            };
        }
    }
}
