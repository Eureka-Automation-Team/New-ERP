using System;
//using System.ComponentModel;
using System.ComponentModel;

namespace Eureka.Core.Domain.Purchasing
{
    public class POReceiptLineModel
    {
        public int ReceiptLineId { get; set; }              // col index = 0
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public int ReceiptHeaderId { get; set; }
        public int LineNum { get; set; }
        public int CategoryId { get; set; }
        [DisplayName("PO")]
        public string PONum { get; set; }
        [DisplayName("Line No.")]
        public int POLineNum { get; set; }
        public int ItemId { get; set; }              // col index = 10
        [DisplayName("ERP-Item No.")]
        public string ItemCode { get; set; }    
        [DisplayName("PART NAME/Description")]
        public string ItemDescription { get; set; }
        [DisplayName("MANU ID")]
        public string Spec { get; set; }      
        [DisplayName("Brand/Mat")]
        public string BrandMaterail { get; set; }
        [DisplayName("Receive Qty")]
        public double QuantityShipped { get; set; }         //col index = 15
        [DisplayName("Ordered")]
        public double QuantityOrdered { get; set; }
        [DisplayName("Received Qty")]
        public double QuantityReceived { get; set; }
        [DisplayName("U/M")]
        public string UnitOfMeasure { get; set; }            
        [DisplayName("Unit Price")]
        public double ShipmentUnitPrice { get; set; }
        [DisplayName("Total Price")]
        public double TotalPrice
        {
            get { return QuantityShipped* ShipmentUnitPrice; }
        }
        [DisplayName("To Location")]
        public string ToSubinventory { get; set; }              // col index = 20
        [DisplayName("Lot")]
        public string LotNumber { get; set; }
        [DisplayName("Project No.")]
        public string ProjectNum { get; set; }
        [DisplayName("Cost Code")]
        public string CostCode { get; set; }
        public string ItemRevision { get; set; }
        public string VendorItemNum { get; set; }
        public string VendorLotNum { get; set; }
        public double UomConversionRate { get; set; }
        public string ShipmentLineStatusCode { get; set; }
        public string SourceDocumentCode { get; set; }
        public int PoHeaderId { get; set; }              // col index = 30
        public int PoReleaseId { get; set; }                  
        public int PoLineId { get; set; }
        public int PoLineLocationId { get; set; }
        public int PoDistributionId { get; set; }
        public int RequisitionLineId { get; set; }
        public int ReqDistributionId { get; set; }
        public int RoutingHeaderId { get; set; }
        public string PackingSlip { get; set; }
        public int FromOrganizationId { get; set; }
        public int DeliverToPersonId { get; set; }              // col index = 40
        public int EmployeeId { get; set; }              
        public string DestinationTypeCode { get; set; }
        public int ToOrganizationId { get; set; }        
        public int LocatorId { get; set; }
        public int DeliverToLocationId { get; set; }
        public int ChargeAccountId { get; set; }
        public int TransportationAccountId { get; set; }        
        public double TransferCost { get; set; }
        public double TransportationCost { get; set; }              
        public string Comments { get; set; }              // col index = 50
        public string AttributeCategory { get; set; }
        [DisplayName("BOM")]
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public string Attribute5 { get; set; }
        public string TaxName { get; set; }
        public double TaxAmount { get; set; }
        public string InvoiceStatusCode { get; set; }              
        public bool CumComparisonFlag { get; set; }              // col index = 60
        public string TruckNum { get; set; }
        public string BarCodeLabel { get; set; }
        public int PrjCostId { get; set; }
        public double SecondaryQuantityShipped { get; set; }
        public double SecondaryQuantityReceived { get; set; }
        public string SecondaryUnitOfMeasure { get; set; }
        [DisplayName("Inspection Req.")]
        public bool QcRequireInspcFlag { get; set; }
        public int QcInspectionStatus { get; set; }
        [DisplayName("Inspection Status")]
        public string InspectionName              
        {
            get { return (Enum.GetName(typeof(enumQCInspectionName), QcInspectionStatus)); }
        }

        public int MmtTransactionId { get; set; }              // col index = 70
        public int AsnLpnId { get; set; }
        public double Amount { get; set; }
        public double AmountReceived { get; set; }
        public double JobId { get; set; }
        public string ApprovalStatus { get; set; }
        public double AmountShipped { get; set; }
        public int ProjectId { get; set; }            // col index = 77
        public int QcInspectionBy { get; set; }
        public string QcInspectionByName { get; set; }
    }

    public enum enumQCInspectionName
    {
        NOTHING = 0,
        INCOMING = 1,
        PASS = 2,
        NG = 3
    }
}