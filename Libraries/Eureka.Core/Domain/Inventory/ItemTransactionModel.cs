using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Inventory
{
    public class ItemTransactionModel
    {
        public int TransactionId { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public int LastUpdateLogin { get; set; }
        public int RequestId { get; set; }
        public int InventoryItemId { get; set; }
        public string Revision { get; set; }
        public int OrganizationId { get; set; }
        public string SubinventoryCode { get; set; }
        public int LocatorId { get; set; }
        public int TransactionTypeId { get; set; }
        public int TransactionSourceTypeId { get; set; }
        public int TransactionSourceId { get; set; }
        public string TransactionSourceName { get; set; }
        public double TransactionQuantity { get; set; }
        public string TransactionUom { get; set; }
        public double PrimaryQuantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionReference { get; set; }
        public int ReasonId { get; set; }
        public string CostedFlag { get; set; }
        public double ActualCost { get; set; }
        public double TransactionCost { get; set; }
        public double NewCost { get; set; }
        public string CurrencyCode { get; set; }
        public double CurrencyConversionRate { get; set; }
        public string CurrencyConversionType { get; set; }
        public Nullable<DateTime> CurrencyConversionDate { get; set; }
        public double QuantityAdjusted { get; set; }
        public string EmployeeCode { get; set; }
        public int TrxSourceLineId { get; set; }
        public int TrxSourceDeliveryId { get; set; }
        public int CycleCountId { get; set; }
        public int TransferTransactionId { get; set; }
        public int TransactionSetId { get; set; }
        public int RcvTransactionId { get; set; }
        public int MoveTransactionId { get; set; }
        public string VendorLotNumber { get; set; }
        public int TransferOrganizationId { get; set; }
        public string TransferSubinventory { get; set; }
        public int TransferLocatorId { get; set; }
        public string ShipmentNumber { get; set; }        
        public string Attribute1 { get; set; } //for Project Number
        public string Attribute2 { get; set; } //For Cost code
        public string Attribute3 { get; set; } //Lot Number
        public string Attribute4 { get; set; } //Bom No
        public string Attribute5 { get; set; }
        public int MovementId { get; set; }
        public int TaskId { get; set; }
        public int ToTaskId { get; set; }
        public string SecondaryUomCode { get; set; }
        public double SecondaryTransactionQuantity { get; set; }
        public int CatalogItemId { get; set; }
        public string Remarks { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string ManuID { get; set; }
        public string BrandMat { get; set; }  //col index = 5
        public double NetIssueTransactionQty
        {
            get
            {
                if (TransactionSourceName == "MATERIAL ISSUE")
                    return  TransactionQuantity - QuantityAdjusted;
                else
                    return 0;
            }
        }
    }
}
