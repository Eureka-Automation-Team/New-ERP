using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class FndUsers
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreatedBy { get; set; }
        public string EncryptedPassword { get; set; }
        public int? SessionNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? LastLogonDate { get; set; }
        public int? EmployeeId { get; set; }
        public string EmailAddress { get; set; }
        public string Fax { get; set; }
        public int? CustomerId { get; set; }
        public int? SupplierId { get; set; }
        public int? RoleId { get; set; }
        public int? ApproverId { get; set; }
        public string Signature { get; set; }
    }
}
