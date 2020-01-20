using Eureka.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;

namespace Eureka.Data.AdoNet
{
    // Data access object for Member
    // ** DAO Pattern

    public class UserDao : IUserDao
    {
        private static Db db = new Db("ms_sql");

        public UserModel GetUser(int USER_ID)
        {
            string sql =
            @"SELECT u.USER_ID, u.USER_NAME, u.LAST_UPDATE_DATE, u.LAST_UPDATED_BY, u.CREATION_DATE, u.CREATED_BY
                      , u.ENCRYPTED_PASSWORD, u.SESSION_NUMBER, u.START_DATE
                      , u.END_DATE, u.DESCRIPTION, u.LAST_LOGON_DATE, u.EMPLOYEE_ID
                      , u.EMAIL_ADDRESS, u.FAX, u.CUSTOMER_ID, u.SUPPLIER_ID
					  , r.ROLE_ID, r.ROLE_NAME, u.APPROVER_ID, u1.DESCRIPTION APPROVER_NAME
                      , u.SIGNATURE
                 FROM [FND_USERS] u
                LEFT JOIN FND_USERS u1 ON(u.APPROVER_ID = u1.USER_ID)
                LEFT JOIN FND_ROLES r ON(u.ROLE_ID = r.ROLE_ID)
                WHERE u.USER_ID = @USER_ID";

            object[] parms = { "@USER_ID", USER_ID};
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public UserModel Login(string user, string password)
        {
            string sql = @"SELECT u.USER_ID, u.USER_NAME, u.LAST_UPDATE_DATE, u.LAST_UPDATED_BY, u.CREATION_DATE, u.CREATED_BY
                      , u.ENCRYPTED_PASSWORD, u.SESSION_NUMBER, u.START_DATE
                      , u.END_DATE, u.DESCRIPTION, u.LAST_LOGON_DATE, u.EMPLOYEE_ID
                      , u.EMAIL_ADDRESS, u.FAX, u.CUSTOMER_ID, u.SUPPLIER_ID
					  , r.ROLE_ID, r.ROLE_NAME, u.APPROVER_ID, u1.DESCRIPTION APPROVER_NAME
                      , u.SIGNATURE
                FROM [FND_USERS] u
                LEFT JOIN FND_USERS u1 ON(u.APPROVER_ID = u1.USER_ID)
                LEFT JOIN FND_ROLES r ON(u.ROLE_ID = r.ROLE_ID) 
                WHERE u.USER_NAME = @USER_NAME 
                    AND u.ENCRYPTED_PASSWORD = @ENCRYPTED_PASSWORD
                    AND u.END_DATE >= GETDATE()";


            object[] parms = { "@ENCRYPTED_PASSWORD", EncryptPass(password), "@USER_NAME", user, "@END_DATE", DateTime.Now};
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public UserModel GetUserByEmail(string email)
        {
            string sql =
            @"SELECT u.USER_ID, u.USER_NAME, u.LAST_UPDATE_DATE, u.LAST_UPDATED_BY, u.CREATION_DATE, u.CREATED_BY
                      , u.ENCRYPTED_PASSWORD, u.SESSION_NUMBER, u.START_DATE
                      , u.END_DATE, u.DESCRIPTION, u.LAST_LOGON_DATE, u.EMPLOYEE_ID
                      , u.EMAIL_ADDRESS, u.FAX, u.CUSTOMER_ID, u.SUPPLIER_ID
					  , r.ROLE_ID, r.ROLE_NAME, u.APPROVER_ID, u1.DESCRIPTION APPROVER_NAME
                      , u.SIGNATURE
                 FROM [FND_USERS] u
                LEFT JOIN FND_USERS u1 ON(u.APPROVER_ID = u1.USER_ID)
                LEFT JOIN FND_ROLES r ON(u.ROLE_ID = r.ROLE_ID)
                WHERE u.EMAIL_ADDRESS = @EMAIL_ADDRESS";

            object[] parms = { "@EMAIL_ADDRESS", email};
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public List<UserModel> GetUsers(string sortExpression)
        {
            string sql =
            @"SELECT u.USER_ID, u.USER_NAME, u.LAST_UPDATE_DATE, u.LAST_UPDATED_BY, u.CREATION_DATE, u.CREATED_BY
                      , u.ENCRYPTED_PASSWORD, u.SESSION_NUMBER, u.START_DATE
                      , u.END_DATE, u.DESCRIPTION, u.LAST_LOGON_DATE, u.EMPLOYEE_ID
                      , u.EMAIL_ADDRESS, u.FAX, u.CUSTOMER_ID, u.SUPPLIER_ID
					  , r.ROLE_ID, r.ROLE_NAME, u.APPROVER_ID, u1.DESCRIPTION APPROVER_NAME
                      , u.SIGNATURE
                FROM [FND_USERS] u
                LEFT JOIN FND_USERS u1 ON(u.APPROVER_ID = u1.USER_ID)
                LEFT JOIN FND_ROLES r ON(u.ROLE_ID = r.ROLE_ID)".OrderBy(sortExpression);

            return db.Read(sql, MakeWithStats).ToList();
        }

        public string EncryptPass(string value)
        {
            MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(value);
            data = x.ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data).Replace("\n", "");
        }

        public List<UserModel> GetUsersWithOrderStatistics(string sortExpression)
        {
            throw new NotImplementedException();
        }

        public void InsertUser(UserModel user)
        {
            string sql =
            @"INSERT INTO [FND_USERS] (USER_NAME, LAST_UPDATE_DATE, LAST_UPDATED_BY, CREATION_DATE, CREATED_BY
                                   , ENCRYPTED_PASSWORD, SESSION_NUMBER, START_DATE, END_DATE
                                   , DESCRIPTION, LAST_LOGON_DATE, EMPLOYEE_ID, EMAIL_ADDRESS, FAX
                                   , CUSTOMER_ID, SUPPLIER_ID, ROLE_ID, APPROVER_ID, SIGNATURE)
              VALUES (@UserName, @LAST_UPDATE_DATE, @LAST_UPDATED_BY, @CREATION_DATE, @CREATED_BY
                                   , @ENCRYPTED_PASSWORD, @SESSION_NUMBER, @START_DATE, @END_DATE
                                   , @DESCRIPTION, @LAST_LOGON_DATE, @EMPLOYEE_ID, @EMAIL_ADDRESS, @FAX
                                   , @CUSTOMER_ID, @SUPPLIER_ID, @ROLE_ID, @APPROVER_ID, @SIGNATURE)";

            user.Id = db.Insert(sql, Take(user));
        }

        public void UpdateUser(UserModel user)
        {
            string sql =
            @"UPDATE [FND_USERS]
                SET USER_NAME = @USER_NAME,
                    LAST_UPDATE_DATE = @LAST_UPDATE_DATE,
                    LAST_UPDATED_BY = @LAST_UPDATED_BY,
                    CREATION_DATE = @CREATION_DATE,
                    CREATED_BY = @CREATED_BY,
                    ENCRYPTED_PASSWORD = @ENCRYPTED_PASSWORD,
                    SESSION_NUMBER = @SESSION_NUMBER,
                    START_DATE = @START_DATE,
                    END_DATE = @END_DATE,
                    DESCRIPTION = @DESCRIPTION,
                    LAST_LOGON_DATE = @LAST_LOGON_DATE,
                    EMPLOYEE_ID = @EMPLOYEE_ID,
                    EMAIL_ADDRESS = @EMAIL_ADDRESS,
                    FAX = @FAX,
                    CUSTOMER_ID = @CUSTOMER_ID,
                    SUPPLIER_ID = @SUPPLIER_ID,
                    ROLE_ID = @ROLE_ID,
                    APPROVER_ID = @APPROVER_ID,
                    SIGNATURE = @SIGNATURE
               WHERE USER_ID = @USER_ID";

            db.Update(sql, Take(user));
        }

        public void DeleteUser(UserModel user)
        {
            string sql =
            @"DELETE FROM [FND_USERS]
               WHERE USER_ID = @USER_ID";

            db.Update(sql, Take(user));
        }

        // creates a Member object based on DataReader

        private static Func<IDataReader, UserModel> Make = reader =>
             new UserModel
             {
                 Id = reader["USER_ID"].AsId(),
                 UserName = reader["USER_NAME"].AsString(),
                 LastUpdateDate = reader["LAST_UPDATE_DATE"].AsDateTime(),
                 LastUpdatedBy = reader["LAST_UPDATED_BY"].AsInt(),
                 CreationDate = reader["CREATION_DATE"].AsDateTime(),
                 CreatedBy = reader["CREATED_BY"].AsInt(),
                 Password = reader["ENCRYPTED_PASSWORD"].AsString(),
                 SessionNumber = reader["SESSION_NUMBER"].AsInt(),
                 StartDate = reader["START_DATE"].AsDateTime(),
                 EndDate = reader["END_DATE"].AsDateTime(),
                 Description = reader["DESCRIPTION"].AsString(),
                 LastLogOnDate = reader["LAST_LOGON_DATE"].AsDateTime(),
                 EmployeeId = reader["EMPLOYEE_ID"].AsInt(),
                 EmailAddress = reader["EMAIL_ADDRESS"].AsString(),
                 Fax = reader["FAX"].AsString(),
                 CustomerId = reader["CUSTOMER_ID"].AsInt(),
                 SupplierId = reader["SUPPLIER_ID"].AsInt(),
                 RoleID = reader["ROLE_ID"].AsInt(),
                 ApproverId = reader["APPROVER_ID"].AsInt(),
                 SignatureImagePath = reader["SIGNATURE"].AsString()
             };

        // creates a Members object with order statistics based on DataReader

        private static Func<IDataReader, UserModel> MakeWithStats = reader =>
        {
            var user = Make(reader);
            user.RoleID = reader["ROLE_ID"].AsInt();
            user.RoleName = reader["ROLE_NAME"].AsString();
            user.ApproverName = reader["APPROVER_NAME"].AsString();

            return user;
        };

        // creates query parameters list from Member object

        private object[] Take(UserModel user)
        {
            return new object[]
            {
                "@USER_ID", user.Id,
                "@USER_NAME", user.UserName,
                "@LAST_UPDATE_DATE", user.LastUpdateDate,
                "@LAST_UPDATED_BY", user.LastUpdatedBy,
                "@CREATION_DATE", user.CreationDate,
                "@CREATED_BY", user.CreatedBy,
                "@ENCRYPTED_PASSWORD", user.Password,
                "@SESSION_NUMBER", user.SessionNumber,
                "@START_DATE", user.StartDate,
                "@END_DATE", user.EndDate,
                "@DESCRIPTION", user.Description,
                "@LAST_LOGON_DATE", user.LastLogOnDate,
                "@EMPLOYEE_ID", user.EmployeeId,
                "@EMAIL_ADDRESS", user.EmailAddress,
                "@FAX", user.Fax,
                "@CUSTOMER_ID", user.CustomerId,
                "@SUPPLIER_ID", user.SupplierId,
                "@ROLE_ID", user.RoleID,
                "@APPROVER_ID", user.ApproverId,
                "@SIGNATURE", user.SignatureImagePath
            };
        }

    }
}