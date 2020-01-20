using System;

namespace Eureka.Core.Domain.Users
{
    public class UserModel : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public int LastUpdateLogin { get; set; }
        public int SessionNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public DateTime LastLogOnDate { get; set; }
        public int EmployeeId { get; set; }
        public string EmailAddress { get; set; }
        public string Fax { get; set; }
        public int CustomerId { get; set; }
        public int SupplierId { get; set; }
        public string UserGuid { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int ApproverId { get; set; }
        public string ApproverName { get; set; }
        public string SignatureImagePath { get; set; }
    }
}