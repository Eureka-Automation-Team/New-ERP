using System;
using System.Collections.Generic;

namespace Eureka.Core.Domain.Security
{
    public class MenuModel
    {
        public int MenuID { get; set; }
        public int RoleID { get; set; }
        public string Name { get; set; }
        public string MenuType { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public string FormName { get; set; }
        public string FormFullName { get; set; }
        public int SortMenu { get; set; }
        public bool EnableFlag { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }

        //public List<MenuModel> ToList()
        //{
        //    throw new NotImplementedException();
        //}
    }
}