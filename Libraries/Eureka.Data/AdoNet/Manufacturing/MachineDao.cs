using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Manufacturing;

namespace Eureka.Data.AdoNet.Manufacturing
{
    public class MachineDao : IMachineDao
    {
        private static Db db = new Db("ms_sql_job");

        public List<MachineModel> GetAll()
        {
            string sql = @"SELECT  mch.MachineId, mch.MachineCode, mch.IpAddress
	                        , mch.PortNumber, mch.LastUpdateDate, mch.LastUpdatedBy
	                        , mch.CreationDate, mch.CreatedBy, mch.EnableFlag
	                        , mch.ActiveFlag
                          FROM Machines mch
                          ORDER BY mch.MachineId";

            return db.Read(sql, Make).ToList();
        }

        public MachineModel GetByCode(string machineCode)
        {
            string sql = @"SELECT  mch.MachineId, mch.MachineCode, mch.IpAddress
	                        , mch.PortNumber, mch.LastUpdateDate, mch.LastUpdatedBy
	                        , mch.CreationDate, mch.CreatedBy, mch.EnableFlag
	                        , mch.ActiveFlag
                          FROM Machines mch
                          WHERE mch.MachineCode = @MachineCode";

            object[] parms = { "@MachineCode", machineCode };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public MachineModel GetByID(int id)
        {
            string sql = @"SELECT  mch.MachineId, mch.MachineCode, mch.IpAddress
	                        , mch.PortNumber, mch.LastUpdateDate, mch.LastUpdatedBy
	                        , mch.CreationDate, mch.CreatedBy, mch.EnableFlag
	                        , mch.ActiveFlag
                          FROM Machines mch
                          WHERE mch.MachineId = @MachineId";

            object[] parms = { "@MachineId", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(MachineModel model)
        {
            string sql =
                @"INSERT INTO Machines
                           (MachineCode
                           ,IpAddress
                           ,PortNumber
                           ,LastUpdateDate
                           ,LastUpdatedBy
                           ,CreationDate
                           ,CreatedBy
                           ,EnableFlag
                           ,ActiveFlag)
                     VALUES
                           (@MachineCode
                           ,@IpAddress
                           ,@PortNumber
                           ,@LastUpdateDate
                           ,@LastUpdatedBy
                           ,@CreationDate
                           ,@CreatedBy
                           ,@EnableFlag
                           ,@ActiveFlag)";

            return db.Insert(sql, Take(model));
        }

        public void Update(MachineModel model)
        {
            string sql =
            @"UPDATE Machines
                   SET MachineCode = @MachineCode
                      ,IpAddress = @IpAddress
                      ,PortNumber = @PortNumber
                      ,LastUpdateDate = @LastUpdateDate
                      ,LastUpdatedBy = @LastUpdatedBy
                      ,CreationDate = @CreationDate
                      ,CreatedBy = @CreatedBy
                      ,EnableFlag = @EnableFlag
                      ,ActiveFlag = @ActiveFlag
                 WHERE MachineId = @MachineId";

            db.Update(sql, Take(model));
        }

        public void Delete(MachineModel model)
        {
            string sql = @"DELETE FROM Machines WHERE MachineId = @MachineId";

            object[] parms = { "@MachineId", model.MachineId };
            db.Update(sql, parms);
        }

        // creates a Member object based on DataReader
        private static Func<IDataReader, MachineModel> Make = reader =>
             new MachineModel
             {
                 MachineId = reader["MachineId"].AsInt(),
                 MachineCode = reader["MachineCode"].AsString(),
                 IpAddress = reader["IpAddress"].AsString(),
                 Port = reader["PortNumber"].AsInt(),
                 LastUpdateDate = (reader["LastUpdateDate"] != DBNull.Value) ? reader["LastUpdateDate"].AsDateTime() : (DateTime?)null,
                 LastUpdatedBy = reader["LastUpdatedBy"].AsInt(),
                 CreationDate = (reader["CreationDate"] != DBNull.Value) ? reader["CreationDate"].AsDateTime() : (DateTime?)null,
                 CreatedBy = reader["CreatedBy"].AsInt(),
                 EnableFlag = (reader["EnableFlag"].AsString() == "Y") ? true : false,
                 ActiveFlag = (reader["ActiveFlag"].AsString() == "Y") ? true : false
             };

        private object[] Take(MachineModel model)
        {
            return new object[]
            {
                "@MachineId", model.MachineId,
                "@MachineCode", model.MachineCode,
                "@IpAddress", model.IpAddress,
                "@PortNumber", model.Port,
                "@LastUpdateDate", model.LastUpdateDate,
                "@LastUpdatedBy", model.LastUpdatedBy,
                "@CreationDate", model.CreationDate,
                "@CreatedBy", model.CreatedBy,
                "@EnableFlag", (model.EnableFlag) ? "Y" : "N",
                "@ActiveFlag", (model.ActiveFlag) ? "Y" : "N"
            };
        }
    }
}
