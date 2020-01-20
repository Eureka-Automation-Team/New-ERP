using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Projects
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string ProjectNum { get; set; }
        public string ProjectDescription { get; set; }
        public string Type { get; set; }
        public DateTime ProjectDate { get; set; }
        public string State { get; set; }
        public int CustomerId { get; set; }
        public string CustomerNum { get; set; }
        public string CustomerName { get; set; }
        public int ItemId { get; set; }
        public string ProductCode { get; set; }
        public int ContractId { get; set; }
        public string ContractCode { get; set; }
        public int ProjectManagerId { get; set; }
        public string ProjectManagerName { get; set; }
        public double ProjectRev { get; set; }
        public string TaxCode { get; set; }
        public double ExchangeRate { get; set; }
        public string UfContractName { get; set; }
        public string UfEstimateOrder { get; set; }
        public string UfSalePerson { get; set; }
        public double UfQtyOrder { get; set; }
        public string UfNote { get; set; }
        public string UfCbdNo { get; set; }
        public string UfProjectDescLong { get; set; }
        public string UfCloseFlag { get; set; }
        public string UfBoi { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdateBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
