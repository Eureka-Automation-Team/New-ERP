using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Inventory
{
    public class ItemOnhandModel
    {
        public int OnhandQuantitiesId { get; set; }
        public int InventoryItemId { get; set; }
        [DisplayName("ERP-Item No.")]
        public string ItemCode { get; set; }
        [DisplayName("PART NAME/Description")]
        public string ItemDescription { get; set; }
        [DisplayName("MANU ID")]
        public string ManuID { get; set; }
        [DisplayName("Brand/Mat")]
        public string BrandMat { get; set; }  //col index = 5
        [DisplayName("BOM")]
        public string BomNo { get; set; }
        public int OrganizationId { get; set; }               //col index = 7
        public Nullable<DateTime> DateReceived { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }               //col index = 12
        public int LastUpdateLogin { get; set; }
        [DisplayName("Balance Qty.")]
        public double PrimaryTransactionQuantity { get; set; }
        [DisplayName("UOM")]
        public string TransactionUomCode { get; set; }
        public int CatalogItemId { get; set; }
        [DisplayName("Subinventory")]
        public string SubinventoryCode { get; set; }               //col index = 17
        public string Revision { get; set; }
        public int LocatorId { get; set; }
        public int CreateTransactionId { get; set; }
        public int UpdateTransactionId { get; set; }
        [DisplayName("Lot No.")]
        public string LotNumber { get; set; }               //col index = 22
        public Nullable<DateTime> OrigDateReceived { get; set; }
        public int CostGroupId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectNum { get; set; }
        public string ProjectCostCode { get; set; }
        public int TaskId { get; set; }
        public int OrganizationType { get; set; }               //col index = 25
        public int OwningOrganizationId { get; set; }
        public int OwningTpType { get; set; }
        public int PlanningOrganizationId { get; set; }
        public int PlanningTpType { get; set; }        
        public double TransactionQuantity { get; set; }               //col index = 30
        public string ReserveUomCode { get; set; }
        [DisplayName("Reserved Qty.")]
        public double ReserveQuantity { get; set; }
        public int StatusId { get; set; }
        [DisplayName("Unit Cost")]//col index = 33
        public double TransactionUnitCost { get; set; }
        [DisplayName("Total Cost")]
        public double TotalCost
        {
            get { return PrimaryTransactionQuantity * TransactionUnitCost; }
        }

        public string IssueProjectNum { get; set; }
        public string IssueCostCode { get; set; }
    }
}
