using System;
using System.Collections.Generic;

namespace Eureka.Web.Models
{
    public partial class FndRoles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
