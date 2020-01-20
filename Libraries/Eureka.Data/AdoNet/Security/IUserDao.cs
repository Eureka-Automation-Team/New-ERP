using Eureka.Core.Domain.Users;
using System.Collections.Generic;

namespace Eureka.Data
{
    // defines methods to access Members.
    // this is a database-independent interface. Implementations are database specific
    // ** DAO Pattern
    public interface IUserDao
    {
        // gets a specific Member
        UserModel GetUser(int userId);

        // gets a specific Member by email
        UserModel GetUserByEmail(string email);

        // gets a sorted list of all Members
        List<UserModel> GetUsers(string sortExpression = "u.USER_ID ASC");

        //get User from user/password
        UserModel Login(string user, string password);

        // gets Members with order statistics in given sort order.
        List<UserModel> GetUsersWithOrderStatistics(string sortExpression);

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        void InsertUser(UserModel user);

        // updates a Member
        void UpdateUser(UserModel user);

        // deletes a Member
        void DeleteUser(UserModel user);

        // 
        string EncryptPass(string value);
    }
}