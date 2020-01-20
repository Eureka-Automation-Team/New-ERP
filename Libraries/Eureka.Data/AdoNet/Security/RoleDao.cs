using Eureka.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet
{
    public class RoleDao : IRoleDao
    {
        private static Db db = new Db("ms_sql");

        public void Delete(RoleModel role)
        {
            string sql =
            @"DELETE FROM [FND_ROLES]
               WHERE ROLE_ID = @ROLE_ID";

            db.Update(sql, Take(role));
        }

        public List<RoleModel> GetAll()
        {
            string sql = @"SELECT * FROM [FND_ROLES] ORDER BY ROLE_ID ASC";

            return db.Read(sql, Make).ToList();
        }

        public RoleModel GetByID(int id)
        {
            string sql = @"SELECT * FROM [FND_ROLES] WHERE ROLE_ID = @ROLE_ID";

            object[] parms = { "@ROLE_ID", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public RoleModel GetByName(string name)
        {
            string sql = @"SELECT * FROM [FND_ROLES] WHERE ROLE_NAME = @ROLE_NAME";

            object[] parms = { "@ROLE_NAME", name };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(RoleModel role)
        {
            string sql =
                @"INSERT INTO [FND_ROLES]
                       (ROLE_NAME
                       ,DESCRIPTION
                       ,CREATED_BY
                       ,CREATION_DATE
                       ,LAST_UPDATED_BY
                       ,LAST_UPDATE_DATE)
                 VALUES
                       (@ROLE_NAME
                       ,@DESCRIPTION
                       ,@CREATED_BY
                       ,@CREATION_DATE 
                       ,@LAST_UPDATED_BY 
                       ,@LAST_UPDATE_DATE)";

            return db.Insert(sql, Take(role));
        }

        public void Update(RoleModel role)
        {
            string sql =
            @"UPDATE [FND_ROLES]
               SET ROLE_NAME = @ROLE_NAME 
                  ,DESCRIPTION = @DESCRIPTION
                  ,LAST_UPDATED_BY = @LAST_UPDATED_BY
                  ,LAST_UPDATE_DATE = @LAST_UPDATE_DATE
             WHERE ROLE_ID = @ROLE_ID";

            db.Update(sql, Take(role));
        }

        // creates a Member object based on DataReader

        private static Func<IDataReader, RoleModel> Make = reader =>
             new RoleModel
             {
                 RoleID = reader["ROLE_ID"].AsId(),
                 Name = reader["ROLE_NAME"].AsString(),
                 Description = reader["DESCRIPTION"].AsString(),
                 LastUpdateDate = reader["LAST_UPDATE_DATE"].AsDateTime(),
                 LastUpdatedBy = reader["LAST_UPDATED_BY"].AsInt(),
                 CreationDate = reader["CREATION_DATE"].AsDateTime(),
                 CreatedBy = reader["CREATED_BY"].AsInt()
             };


        private object[] Take(RoleModel role)
        {
            return new object[]
            {
                "@ROLE_ID", role.RoleID,
                "@ROLE_NAME", role.Name,
                "@DESCRIPTION", role.Description,
                "@LAST_UPDATE_DATE", role.LastUpdateDate,
                "@LAST_UPDATED_BY", role.LastUpdatedBy,
                "@CREATION_DATE", role.CreationDate,
                "@CREATED_BY", role.CreatedBy
            };
        }
    }
}
