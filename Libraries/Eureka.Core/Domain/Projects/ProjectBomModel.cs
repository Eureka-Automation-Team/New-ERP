using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Projects
{
    public class ProjectBomModel : BaseEntity
    {
        public int LineNo { get; set; }
        public int ProjectId { get; set; }
        public  bool Selected { get; set; }
        public int Status { get; set; }
        public string ItemNo { get; set; }        
        public string ItemDescription { get; set; }
        public double Quantity { get; set; }
        public string Material { get; set; }
        public int Revision { get; set; }
        public string MenuID { get; set; }
        public string Brand { get; set; }
        public string Remarks { get; set; }
        public string CostCode { get; set; }
        public string BomNo { get; set; }
        public double CostPrice { get; set; }
        public DateTime DueDate { get; set; }
        public string Messages { get; set; }
        public string UrgentFlag { get; set; }
        public double TotalCost { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
