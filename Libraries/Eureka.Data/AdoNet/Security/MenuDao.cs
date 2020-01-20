using Eureka.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Eureka.Data.AdoNet
{
    public class MenuDao : IMenuDao
    {
        private static Db db = new Db("ms_sql");


        public void DeleteByParent(int roleId, int parentId)
        {
            string sql =
            @"DELETE FROM [FND_MENUS]
               WHERE PARENT_ID = @PARENT_ID AND ROLE_ID = @ROLE_ID";

            object[] parms = { "@PARENT_ID", parentId, "@ROLE_ID", roleId };
            db.Update(sql, parms);
        }


        public void Enable(MenuModel menu)
        {
            string sql =
            @"DELETE FROM [FND_DISABLE_MENUS]
               WHERE MENU_ID = @MENU_ID AND ROLE_ID = @ROLE_ID";

            db.Update(sql, Take(menu));
        }

        public void Disable(MenuModel menu)
        {
            string sql =
                @"INSERT INTO [FND_DISABLE_MENUS]
                       (MENU_ID
                       ,ROLE_ID
                       ,CREATED_BY
                       ,CREATION_DATE
                       ,LAST_UPDATED_BY
                       ,LAST_UPDATE_DATE)
                 VALUES
                       (@MENU_ID
                       ,@ROLE_ID
                       ,@CREATED_BY
                       ,@CREATION_DATE 
                       ,@LAST_UPDATED_BY 
                       ,@LAST_UPDATE_DATE)";

            db.Insert(sql, Take(menu));
        }

        public List<MenuModel> GetAll(int roleId)
        {
            string sql = @"SELECT mnu.*, ISNULL(dis.menu_id, 1) ENABLE_FLAG, dis.ROLE_ID
                            FROM FND_MENUS mnu
                            LEFT JOIN FND_DISABLE_MENUS dis ON(mnu.MENU_ID = dis.MENU_ID AND dis.ROLE_ID = @ROLE_ID) 
                            ORDER BY mnu.SORT_MENU ASC";

            object[] parms = { "@ROLE_ID", roleId };
            return db.Read(sql, Make, parms).ToList();
        }

        public MenuModel GetByID(int id, int roldId)
        {
            string sql = @"SELECT mnu.*, IIF(dis.MENU_ID IS NOT NULL, 'FALSE', 'TRUE') ENABLE_FLAG, dis.ROLE_ID
                            FROM FND_MENUS mnu
                            LEFT JOIN FND_DISABLE_MENUS dis ON(mnu.MENU_ID = dis.MENU_ID AND dis.ROLE_ID = @ROLE_ID) 
                            WHERE mnu.MENU_ID = @MENU_ID";

            object[] parms = { "@MENU_ID", id , "@ROLE_ID" , roldId};
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public List<MenuModel> GetByRoleID(int roleId)
        {
            return GetAll(roleId);
        }

        // creates a Member object based on DataReader

        private static Func<IDataReader, MenuModel> Make = reader =>
             new MenuModel
             {
                 MenuID = reader["MENU_ID"].AsInt(),
                 RoleID = reader["ROLE_ID"].AsInt(),
                 Name = reader["MENU_NAME"].AsString(),
                 MenuType = reader["MENU_TYPE"].AsString(),
                 Description = reader["DESCRIPTION"].AsString(),
                 ParentId = reader["PARENT_ID"].AsInt(),
                 FormName = reader["FORM_NAME"].AsString(),
                 FormFullName = reader["FORM_FULLNAME"].AsString(),
                 SortMenu = reader["SORT_MENU"].AsInt(),                 
                 EnableFlag = (reader["ENABLE_FLAG"].AsInt() == 1) ? true : false,
                 LastUpdateDate = reader["LAST_UPDATE_DATE"].AsDateTime(),
                 LastUpdatedBy = reader["LAST_UPDATED_BY"].AsInt(),
                 CreationDate = reader["CREATION_DATE"].AsDateTime(),
                 CreatedBy = reader["CREATED_BY"].AsInt()
             };

        // creates a Members object with order statistics based on DataReader
        /*
        private static Func<IDataReader, MenuModel> MakeWithStats = reader =>
        {
            var alarm = Make(reader);
            alarm.AlarmMessage = reader["ALARM_MESSAGE"].AsString();

            return alarm;
        };*/

        private object[] Take(MenuModel menu)
        {
            return new object[]
            {
                  "@MENU_ID", menu.MenuID,
                  "@ROLE_ID", menu.RoleID,
                  "@MENU_NAME", menu.Name,
                  "@MENU_TYPE", menu.MenuType,
                  "@DESCRIPTION", menu.Description,
                  "@PARENT_ID", menu.ParentId,
                  "@FORM_NAME", menu.FormName,
                  "@FORM_FULLNAME", menu.FormFullName,
                  "@SORT_MENU", menu.SortMenu,
                  "@LAST_UPDATE_DATE", menu.LastUpdateDate,
                  "@LAST_UPDATED_BY", menu.LastUpdatedBy,
                  "@CREATION_DATE", menu.CreationDate,
                  "@CREATED_BY", menu.CreatedBy
            };
        }
    }
}