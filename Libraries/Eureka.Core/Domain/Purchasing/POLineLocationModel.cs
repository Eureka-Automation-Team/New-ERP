using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Core.Domain.Purchasing
{
    public class POLineLocationModel
    {
        public int LineLocationId { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatedBy { get; set; }
        public int PoHeaderId { get; set; }
        public int PoLineId { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public double Quantity { get; set; }
        public double QuantityReceived { get; set; }
        public double QuantityAccepted { get; set; }
        public double QuantityRejected { get; set; }
        public double QuantityBilled { get; set; }
        public double QuantityCancelled { get; set; }
        public string UnitMeasLookupCode { get; set; }
        public int PoReleaseId { get; set; }
        public int ShipToLocationId { get; set; }
        public string ShipViaLookupCode { get; set; }
        public Nullable<DateTime> NeedByDate { get; set; }
        public Nullable<DateTime> PromisedDate { get; set; }
        public Nullable<DateTime> LastAcceptDate { get; set; }
        public double PriceOverride { get; set; }
        public bool EncumberedFlag { get; set; }
        public Nullable<DateTime> EncumberedDate { get; set; }
        public double UnencumberedQuantity { get; set; }
        public string FobLookupCode { get; set; }
        public string FreightTermsLookupCode { get; set; }
        public bool TaxableFlag { get; set; }
        public string TaxName { get; set; }
        public double EstimatedTaxAmount { get; set; }
        public bool InspectionRequiredFlag { get; set; }
        public bool ReceiptRequiredFlag { get; set; }
        public int ShipmentNum { get; set; }
        public int ReceiptHeaderId { get; set; }
        public int ReceiptLineId { get; set; }
        public int OrgId { get; set; }
        public int TaxCodeId { get; set; }
        public bool CalculateTaxFlag { get; set; }
        public string NoteToReceiver { get; set; }
        public double Amount { get; set; }
        public double AmountReceived { get; set; }
        public double AmountBilled { get; set; }
        public double AmountCancelled { get; set; }
        public double AmountRejected { get; set; }
        public double AmountAccepted { get; set; }
        public string ConfirmFlag { get; set; }
    }
}
