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
        private static Db db = new Db("ms_sql");

        public List<MachineModel> GetAll()
        {
            string sql = @"SELECT  mch.machine_id, mch.machine_code, mch.ip_address
	                        , mch.port, mch.last_update_date, mch.last_updated_by
	                        , mch.creation_date, mch.created_by, mch.enable_flag
	                        , mch.active_flag
                          FROM mfg_machines mch
                          ORDER BY mch.machine_id";

            return db.Read(sql, Make).ToList();
        }

        public MachineModel GetByCode(string machineCode)
        {
            string sql = @"SELECT  mch.machine_id, mch.machine_code, mch.ip_address
	                        , mch.port, mch.last_update_date, mch.last_updated_by
	                        , mch.creation_date, mch.created_by, mch.enable_flag
	                        , mch.active_flag
                          FROM mfg_machines mch
                          WHERE mch.machine_code = @machine_code";

            object[] parms = { "@machine_code", machineCode };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public MachineModel GetByID(int id)
        {
            string sql = @"SELECT  mch.machine_id, mch.machine_code, mch.ip_address
	                        , mch.port, mch.last_update_date, mch.last_updated_by
	                        , mch.creation_date, mch.created_by, mch.enable_flag
	                        , mch.active_flag
                          FROM mfg_machines mch
                          WHERE mch.machine_id = @machine_id";

            object[] parms = { "@machine_id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(MachineModel model)
        {
            string sql =
                @"INSERT INTO mfg_machines
                           (machine_code
                           ,ip_address
                           ,port
                           ,last_update_date
                           ,last_updated_by
                           ,creation_date
                           ,created_by
                           ,enable_flag
                           ,active_flag)
                     VALUES
                           (@machine_code
                           ,@ip_address
                           ,@port
                           ,@last_update_date
                           ,@last_updated_by
                           ,@creation_date
                           ,@created_by
                           ,@enable_flag
                           ,@active_flag)";

            return db.Insert(sql, Take(model));
        }

        public void Update(MachineModel model)
        {
            string sql =
            @"UPDATE mfg_machines
                   SET machine_code = @machine_code
                      ,ip_address = @ip_address
                      ,port = @port
                      ,last_update_date = @last_update_date
                      ,last_updated_by = @last_updated_by
                      ,creation_date = @creation_date
                      ,created_by = @created_by
                      ,enable_flag = @enable_flag
                      ,active_flag = @active_flag
                 WHERE machine_id = @machine_id";

            db.Update(sql, Take(model));
        }

        public void Delete(MachineModel model)
        {
            string sql = @"DELETE FROM mfg_machines WHERE machine_id = @machine_id";

            object[] parms = { "@machine_id", model.MachineId };
            db.Update(sql, parms);
        }

        // creates a Member object based on DataReader
        private static Func<IDataReader, MachineModel> Make = reader =>
             new MachineModel
             {
                 MachineId = reader["machine_id"].AsInt(),
                 MachineCode = reader["machine_code"].AsString(),
                 IpAddress = reader["ip_address"].AsString(),
                 Port = reader["port"].AsInt(),
                 LastUpdateDate = (reader["last_update_date"] != DBNull.Value) ? reader["last_update_date"].AsDateTime() : (DateTime?)null,
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = (reader["creation_date"] != DBNull.Value) ? reader["creation_date"].AsDateTime() : (DateTime?)null,
                 CreatedBy = reader["created_by"].AsInt(),
                 EnableFlag = (reader["enable_flag"].AsString() == "Y") ? true : false,
                 ActiveFlag = (reader["active_flag"].AsString() == "Y") ? true : false
             };

        private object[] Take(MachineModel model)
        {
            return new object[]
            {
                "@machine_id", model.MachineId,
                "@machine_code", model.MachineCode,
                "@ip_address", model.IpAddress,
                "@port", model.Port,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@enable_flag", (model.EnableFlag) ? "Y" : "N",
                "@active_flag", (model.ActiveFlag) ? "Y" : "N"
            };
        }
    }
}
