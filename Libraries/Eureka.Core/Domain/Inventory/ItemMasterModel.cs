using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Inventory
{
    public class ItemMasterModel
    {
        public int InventoryItemId { get; set; }
        public int OrganizationId { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public bool SummaryFlag { get; set; }
        public bool EnabledFlag { get; set; }
        public Nullable<DateTime> StartDateActive { get; set; }
        public Nullable<DateTime> EndDateActive { get; set; }
        public string Description { get; set; }
        public int BuyerId { get; set; }
        [DisplayName("Item Code")]
        public string Segment1 { get; set; }
        [DisplayName("MANU ID")]
        public string Segment2 { get; set; }
        [DisplayName("Brand/Mat")]
        public string Segment3 { get; set; }
        public string Segment4 { get; set; }
        public string Segment5 { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public string Attribute5 { get; set; }
        public bool PurchasingItemFlag { get; set; }
        public bool ShippableItemFlag { get; set; }
        public bool CustomerOrderFlag { get; set; }
        public bool InternalOrderFlag { get; set; }
        public bool ServiceItemFlag { get; set; }
        public bool InventoryItemFlag { get; set; }
        public bool EngItemFlag { get; set; }
        public bool InventoryAssetFlag { get; set; }
        public bool PurchasingEnabledFlag { get; set; }
        public bool CustomerOrderEnabledFlag { get; set; }
        public bool InternalOrderEnabledFlag { get; set; }
        public bool SoTransactionsFlag { get; set; }
        public bool MtlTransactionsEnabledFlag { get; set; }
        public bool StockEnabledFlag { get; set; }
        public int ItemCatalogGroupId { get; set; }
        public string CatalogName { get; set; }
        public bool ReturnableFlag { get; set; }
        public int DefaultShippingOrg { get; set; }
        public bool CollateralFlag { get; set; }
        public bool TaxableFlag { get; set; }
        public string QtyRcvExceptionCode { get; set; }
        public bool AllowItemDescUpdateFlag { get; set; }
        public bool InspectionRequiredFlag { get; set; }
        public bool ReceiptRequiredFlag { get; set; }
        public double MarketPrice { get; set; }
        public double QtyRcvTolerance { get; set; }
        public double PricePerUnit { get; set; }
        public int AssetCategoryId { get; set; }
        public int RoundingFactor { get; set; }
        public Nullable<DateTime> LastUpdateLot { get; set; }
        public int LastLotRunning { get; set; }
        public double UnitWeight { get; set; }
        public string WeightUomCode { get; set; }
        public double StdLotSize { get; set; }
        public string PrimaryUomCode { get; set; }
        public string PrimaryUnitOfMeasure { get; set; }
        public string InventoryItemStatusCode { get; set; }
        public double MinMinmaxQuantity { get; set; }
        public double MaxMinmaxQuantity { get; set; }
        public double MinimumOrderQuantity { get; set; }
        public int FixedOrderQuantity { get; set; }
        public double FixedDaysSupply { get; set; }
        public double MaximumOrderQuantity { get; set; }
        public bool VendorWarrantyFlag { get; set; }
        public int WarrantyVendorId { get; set; }
        public double MaxWarrantyAmount { get; set; }
        public string TaxCode { get; set; }
        public bool InvoiceEnabledFlag { get; set; }
        public bool CostingEnabledFlag { get; set; }
        public double CostPricePerUnit { get; set; }
        public string ItemType { get; set; }
        public double MaximumLoadWeight { get; set; }
        public int MinimumFillPercent { get; set; }
        public string ContainerTypeCode { get; set; }
        public string PurchasingTaxCode { get; set; }
        public double OverShipmentTolerance { get; set; }
        public double UnderShipmentTolerance { get; set; }
        public double OverReturnTolerance { get; set; }
        public double UnderReturnTolerance { get; set; }
        public string DimensionUomCode { get; set; }
        public double UnitLength { get; set; }
        public double UnitWidth { get; set; }
        public double UnitHeight { get; set; }
        public bool BulkPickedFlag { get; set; }
        public string LotStatusEnabled { get; set; }
        public int DefaultLotStatusId { get; set; }
        public string SerialStatusEnabled { get; set; }
        public int DefaultSerialStatusId { get; set; }
        public string LotSplitEnabled { get; set; }
        public string LotMergeEnabled { get; set; }
        public string SecondaryUomCode { get; set; }
        public double DualUomDeviationHigh { get; set; }
        public double DualUomDeviationLow { get; set; }
        public string ApprovalStatus { get; set; }
        public int Status { get; set; }
    }
}
