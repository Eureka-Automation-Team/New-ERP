using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Purchasing;

namespace Eureka.Data.AdoNet.Purchasing
{
    public class POLineLocationDao : IPOLineLocationDao
    {
        private static Db db = new Db("ms_sql");

        public POLineLocationModel GetByID(int id)
        {
            string sql = @"SELECT pol.line_location_id, pol.last_update_date, pol.last_updated_by, pol.po_header_id
	                            , pol.po_line_id, pol.creation_date, pol.created_by
	                            , pol.quantity, pol.quantity_received, pol.quantity_accepted
	                            , pol.quantity_rejected, pol.quantity_billed, pol.quantity_cancelled
	                            , pol.unit_meas_lookup_code, pol.po_release_id, pol.ship_to_location_id
	                            , pol.ship_via_lookup_code, pol.need_by_date, pol.promised_date
	                            , pol.last_accept_date, pol.price_override, pol.encumbered_flag
	                            , pol.encumbered_date, pol.unencumbered_quantity, pol.fob_lookup_code
	                            , pol.freight_terms_lookup_code, pol.taxable_flag, pol.tax_name
	                            , pol.estimated_tax_amount, pol.inspection_required_flag, pol.receipt_required_flag
	                            , pol.shipment_num, pol.receipt_header_id, pol.receipt_line_id
	                            , pol.org_id, pol.tax_code_id, pol.calculate_tax_flag
	                            , pol.note_to_receiver, pol.amount, pol.amount_received
	                            , pol.amount_billed, pol.amount_cancelled, pol.amount_rejected
	                            , pol.amount_accepted, pol.confirm_flag
                            FROM po_line_locations_all pol
                            WHERE pol.line_location_id = @line_location_id
                            AND pol.confirm_flag = @confirm_flag";

            object[] parms = { "@document_id", id, "@confirm_flag", "Y" };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public List<POLineLocationModel> GetByDate(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT pol.line_location_id, pol.last_update_date, pol.last_updated_by, pol.po_header_id
	                            , pol.po_line_id, pol.creation_date, pol.created_by
	                            , pol.quantity, pol.quantity_received, pol.quantity_accepted
	                            , pol.quantity_rejected, pol.quantity_billed, pol.quantity_cancelled
	                            , pol.unit_meas_lookup_code, pol.po_release_id, pol.ship_to_location_id
	                            , pol.ship_via_lookup_code, pol.need_by_date, pol.promised_date
	                            , pol.last_accept_date, pol.price_override, pol.encumbered_flag
	                            , pol.encumbered_date, pol.unencumbered_quantity, pol.fob_lookup_code
	                            , pol.freight_terms_lookup_code, pol.taxable_flag, pol.tax_name
	                            , pol.estimated_tax_amount, pol.inspection_required_flag, pol.receipt_required_flag
	                            , pol.shipment_num, pol.receipt_header_id, pol.receipt_line_id
	                            , pol.org_id, pol.tax_code_id, pol.calculate_tax_flag
	                            , pol.note_to_receiver, pol.amount, pol.amount_received
	                            , pol.amount_billed, pol.amount_cancelled, pol.amount_rejected
	                            , pol.amount_accepted, pol.confirm_flag
                            FROM po_line_locations_all pol
                            WHERE cast(pol.creation_date as date) BETWEEN cast(@StartDate as date) AND cast(@EndDate as date)
                            AND pol.confirm_flag = @confirm_flag";

            object[] parms = { "@StartDate", startDate, "@EndDate", endDate, "@confirm_flag", "Y" };
            return db.Read(sql, Make, parms).ToList();
        }

        public List<POLineLocationModel> GetByPOID(int id)
        {
            string sql = @"SELECT pol.line_location_id, pol.last_update_date, pol.last_updated_by, pol.po_header_id
	                            , pol.po_line_id, pol.creation_date, pol.created_by
	                            , pol.quantity, pol.quantity_received, pol.quantity_accepted
	                            , pol.quantity_rejected, pol.quantity_billed, pol.quantity_cancelled
	                            , pol.unit_meas_lookup_code, pol.po_release_id, pol.ship_to_location_id
	                            , pol.ship_via_lookup_code, pol.need_by_date, pol.promised_date
	                            , pol.last_accept_date, pol.price_override, pol.encumbered_flag
	                            , pol.encumbered_date, pol.unencumbered_quantity, pol.fob_lookup_code
	                            , pol.freight_terms_lookup_code, pol.taxable_flag, pol.tax_name
	                            , pol.estimated_tax_amount, pol.inspection_required_flag, pol.receipt_required_flag
	                            , pol.shipment_num, pol.receipt_header_id, pol.receipt_line_id
	                            , pol.org_id, pol.tax_code_id, pol.calculate_tax_flag
	                            , pol.note_to_receiver, pol.amount, pol.amount_received
	                            , pol.amount_billed, pol.amount_cancelled, pol.amount_rejected
	                            , pol.amount_accepted, pol.confirm_flag
                            FROM po_line_locations_all pol
                            WHERE pol.po_header_id = @po_header_id
                            AND pol.confirm_flag = @confirm_flag";

            object[] parms = { "@po_header_id", id, "@confirm_flag", "Y" };
            return db.Read(sql, Make, parms).ToList();
        }

        public List<POLineLocationModel> GetByPOLineID(int id)
        {
            string sql = @"SELECT pol.line_location_id, pol.last_update_date, pol.last_updated_by, pol.po_header_id
	                            , pol.po_line_id, pol.creation_date, pol.created_by
	                            , pol.quantity, pol.quantity_received, pol.quantity_accepted
	                            , pol.quantity_rejected, pol.quantity_billed, pol.quantity_cancelled
	                            , pol.unit_meas_lookup_code, pol.po_release_id, pol.ship_to_location_id
	                            , pol.ship_via_lookup_code, pol.need_by_date, pol.promised_date
	                            , pol.last_accept_date, pol.price_override, pol.encumbered_flag
	                            , pol.encumbered_date, pol.unencumbered_quantity, pol.fob_lookup_code
	                            , pol.freight_terms_lookup_code, pol.taxable_flag, pol.tax_name
	                            , pol.estimated_tax_amount, pol.inspection_required_flag, pol.receipt_required_flag
	                            , pol.shipment_num, pol.receipt_header_id, pol.receipt_line_id
	                            , pol.org_id, pol.tax_code_id, pol.calculate_tax_flag
	                            , pol.note_to_receiver, pol.amount, pol.amount_received
	                            , pol.amount_billed, pol.amount_cancelled, pol.amount_rejected
	                            , pol.amount_accepted, pol.confirm_flag
                            FROM po_line_locations_all pol
                            WHERE pol.po_line_id = @po_line_id";

            object[] parms = { "@po_line_id", id};
            return db.Read(sql, Make, parms).ToList();
        }

        public List<POLineLocationModel> GetByReciptID(int id)
        {
            string sql = @"SELECT pol.line_location_id, pol.last_update_date, pol.last_updated_by, pol.po_header_id
	                            , pol.po_line_id, pol.creation_date, pol.created_by
	                            , pol.quantity, pol.quantity_received, pol.quantity_accepted
	                            , pol.quantity_rejected, pol.quantity_billed, pol.quantity_cancelled
	                            , pol.unit_meas_lookup_code, pol.po_release_id, pol.ship_to_location_id
	                            , pol.ship_via_lookup_code, pol.need_by_date, pol.promised_date
	                            , pol.last_accept_date, pol.price_override, pol.encumbered_flag
	                            , pol.encumbered_date, pol.unencumbered_quantity, pol.fob_lookup_code
	                            , pol.freight_terms_lookup_code, pol.taxable_flag, pol.tax_name
	                            , pol.estimated_tax_amount, pol.inspection_required_flag, pol.receipt_required_flag
	                            , pol.shipment_num, pol.receipt_header_id, pol.receipt_line_id
	                            , pol.org_id, pol.tax_code_id, pol.calculate_tax_flag
	                            , pol.note_to_receiver, pol.amount, pol.amount_received
	                            , pol.amount_billed, pol.amount_cancelled, pol.amount_rejected
	                            , pol.amount_accepted, pol.confirm_flag
                            FROM po_line_locations_all pol
                            WHERE pol.receipt_header_id = @receipt_header_id
                            AND pol.confirm_flag = @confirm_flag";

            object[] parms = { "@receipt_header_id", id, "@confirm_flag", "Y" };
            return db.Read(sql, Make, parms).ToList();
        }

        public List<POLineLocationModel> GetByReciptLineID(int id)
        {
            string sql = @"SELECT pol.line_location_id, pol.last_update_date, pol.last_updated_by, pol.po_header_id
	                            , pol.po_line_id, pol.creation_date, pol.created_by
	                            , pol.quantity, pol.quantity_received, pol.quantity_accepted
	                            , pol.quantity_rejected, pol.quantity_billed, pol.quantity_cancelled
	                            , pol.unit_meas_lookup_code, pol.po_release_id, pol.ship_to_location_id
	                            , pol.ship_via_lookup_code, pol.need_by_date, pol.promised_date
	                            , pol.last_accept_date, pol.price_override, pol.encumbered_flag
	                            , pol.encumbered_date, pol.unencumbered_quantity, pol.fob_lookup_code
	                            , pol.freight_terms_lookup_code, pol.taxable_flag, pol.tax_name
	                            , pol.estimated_tax_amount, pol.inspection_required_flag, pol.receipt_required_flag
	                            , pol.shipment_num, pol.receipt_header_id, pol.receipt_line_id
	                            , pol.org_id, pol.tax_code_id, pol.calculate_tax_flag
	                            , pol.note_to_receiver, pol.amount, pol.amount_received
	                            , pol.amount_billed, pol.amount_cancelled, pol.amount_rejected
	                            , pol.amount_accepted, pol.confirm_flag
                            FROM po_line_locations_all pol
                            WHERE pol.receipt_line_id = @receipt_line_id
                            AND pol.confirm_flag = @confirm_flag";

            object[] parms = { "@receipt_line_id", id, "@confirm_flag", "Y" };
            return db.Read(sql, Make, parms).ToList();
        }

        public int Insert(POLineLocationModel model)
        {
            string sql =
                @"INSERT INTO po_line_locations_all
	                    (last_update_date, last_updated_by, po_header_id
	                    , po_line_id, creation_date, created_by
	                    , quantity, quantity_received, quantity_accepted
	                    , quantity_rejected, quantity_billed, quantity_cancelled
	                    , unit_meas_lookup_code, po_release_id, ship_to_location_id
	                    , ship_via_lookup_code, need_by_date, promised_date
	                    , last_accept_date, price_override, encumbered_flag
	                    , encumbered_date, unencumbered_quantity, fob_lookup_code
	                    , freight_terms_lookup_code, taxable_flag, tax_name
	                    , estimated_tax_amount, inspection_required_flag, receipt_required_flag
	                    , shipment_num, receipt_header_id, receipt_line_id
	                    , org_id, tax_code_id, calculate_tax_flag
	                    , note_to_receiver, amount, amount_received
	                    , amount_billed, amount_cancelled, amount_rejected
	                    , amount_accepted, confirm_flag)
                    VALUES
	                    (GETDATE(), @last_updated_by, @po_header_id
	                    , @po_line_id, GETDATE(), @created_by
	                    , @quantity, @quantity_received, @quantity_accepted
	                    , @quantity_rejected, @quantity_billed, @quantity_cancelled
	                    , @unit_meas_lookup_code, @po_release_id, @ship_to_location_id
	                    , @ship_via_lookup_code, @need_by_date, @promised_date
	                    , @last_accept_date, @price_override, @encumbered_flag
	                    , @encumbered_date, @unencumbered_quantity, @fob_lookup_code
	                    , @freight_terms_lookup_code, @taxable_flag, @tax_name
	                    , @estimated_tax_amount, @inspection_required_flag, @receipt_required_flag
	                    , @shipment_num, @receipt_header_id, @receipt_line_id
	                    , @org_id, @tax_code_id, @calculate_tax_flag
	                    , @note_to_receiver, @amount, @amount_received
	                    , @amount_billed, @amount_cancelled, @amount_rejected
	                    , @amount_accepted, @confirm_flag)";

            return db.Insert(sql, Take(model));
        }

        public void Update(POLineLocationModel model)
        {
            string sql =
            @"UPDATE po_line_locations_all
               SET last_update_date = GETDATE()
                  ,last_updated_by = @last_updated_by
                  ,po_header_id = @po_header_id
                  ,po_line_id = @po_line_id
                  ,quantity = @quantity
                  ,quantity_received = @quantity_received
                  ,quantity_accepted = @quantity_accepted
                  ,quantity_rejected = @quantity_rejected
                  ,quantity_billed = @quantity_billed
                  ,quantity_cancelled = @quantity_cancelled
                  ,unit_meas_lookup_code = @unit_meas_lookup_code
                  ,po_release_id = @po_release_id
                  ,ship_to_location_id = @ship_to_location_id
                  ,ship_via_lookup_code = @ship_via_lookup_code
                  ,need_by_date = @need_by_date
                  ,promised_date = @promised_date
                  ,last_accept_date = @last_accept_date
                  ,price_override = @price_override
                  ,encumbered_flag = @encumbered_flag
                  ,encumbered_date = @encumbered_date
                  ,unencumbered_quantity = @unencumbered_quantity
                  ,fob_lookup_code = @fob_lookup_code
                  ,freight_terms_lookup_code = @freight_terms_lookup_code
                  ,taxable_flag = @taxable_flag
                  ,tax_name = @tax_name
                  ,estimated_tax_amount = @estimated_tax_amount
                  ,inspection_required_flag = @inspection_required_flag
                  ,receipt_required_flag = @receipt_required_flag
                  ,shipment_num = @shipment_num
                  ,receipt_header_id = @receipt_header_id
                  ,receipt_line_id = @receipt_line_id
                  ,org_id = @org_id
                  ,tax_code_id = @tax_code_id
                  ,calculate_tax_flag = @calculate_tax_flag
                  ,note_to_receiver = @note_to_receiver
                  ,amount = @amount
                  ,amount_received = @amount_received
                  ,amount_billed = @amount_billed
                  ,amount_cancelled = @amount_cancelled
                  ,amount_rejected = @amount_rejected
                  ,amount_accepted = @amount_accepted
                  ,confirm_flag = @confirm_flag
             WHERE line_location_id = @line_location_id";

            db.Update(sql, Take(model));
        }

        public void Delete(POLineLocationModel model)
        {
            string sql = @"DELETE FROM po_line_locations_all WHERE line_location_id = @line_location_id";

            object[] parms = { "@line_location_id", model.LineLocationId };
            db.Update(sql, parms);
        }

        // creates a Member object based on DataReader
        private static Func<IDataReader, POLineLocationModel> Make = reader =>
             new POLineLocationModel
             {
                 LineLocationId = reader["line_location_id"].AsInt(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 PoHeaderId = reader["po_header_id"].AsInt(),
                 PoLineId = reader["po_line_id"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 Quantity = reader["quantity"].AsDouble(),
                 QuantityReceived = reader["quantity_received"].AsDouble(),
                 QuantityAccepted = reader["quantity_accepted"].AsDouble(),
                 QuantityRejected = reader["quantity_rejected"].AsDouble(),
                 QuantityBilled = reader["quantity_billed"].AsDouble(),
                 QuantityCancelled = reader["quantity_cancelled"].AsDouble(),
                 UnitMeasLookupCode = reader["unit_meas_lookup_code"].AsString(),
                 PoReleaseId = reader["po_release_id"].AsInt(),
                 ShipToLocationId = reader["ship_to_location_id"].AsInt(),
                 ShipViaLookupCode = reader["ship_via_lookup_code"].AsString(),
                 NeedByDate = (reader["need_by_date"] != DBNull.Value) ? reader["need_by_date"].AsDateTime() : (DateTime?)null,
                 PromisedDate = (reader["promised_date"] != DBNull.Value) ? reader["promised_date"].AsDateTime() : (DateTime?)null,
                 LastAcceptDate = (reader["last_accept_date"] != DBNull.Value) ? reader["last_accept_date"].AsDateTime() : (DateTime?)null,
                 PriceOverride = reader["price_override"].AsDouble(),
                 EncumberedFlag = (reader["encumbered_flag"].AsString() == "Y") ? true : false,
                 EncumberedDate = (reader["encumbered_date"] != DBNull.Value) ? reader["encumbered_date"].AsDateTime() : (DateTime?)null,
                 UnencumberedQuantity = reader["unencumbered_quantity"].AsDouble(),
                 FobLookupCode = reader["fob_lookup_code"].AsString(),
                 FreightTermsLookupCode = reader["freight_terms_lookup_code"].AsString(),
                 TaxableFlag = (reader["taxable_flag"].AsString() == "Y") ? true : false,
                 TaxName = reader["tax_name"].AsString(),
                 EstimatedTaxAmount = reader["estimated_tax_amount"].AsDouble(),
                 InspectionRequiredFlag = (reader["inspection_required_flag"].AsString() == "Y") ? true : false,
                 ReceiptRequiredFlag = (reader["receipt_required_flag"].AsString() == "Y") ? true : false,
                 ShipmentNum = reader["shipment_num"].AsInt(),
                 ReceiptHeaderId = reader["receipt_header_id"].AsInt(),
                 ReceiptLineId = reader["receipt_line_id"].AsInt(),
                 OrgId = reader["org_id"].AsInt(),
                 TaxCodeId = reader["tax_code_id"].AsInt(),
                 CalculateTaxFlag = (reader["calculate_tax_flag"].AsString() == "Y") ? true : false,
                 NoteToReceiver = reader["note_to_receiver"].AsString(),
                 Amount = reader["amount"].AsDouble(),
                 AmountReceived = reader["amount_received"].AsDouble(),
                 AmountBilled = reader["amount_billed"].AsDouble(),
                 AmountCancelled = reader["amount_cancelled"].AsDouble(),
                 AmountRejected = reader["amount_rejected"].AsDouble(),
                 AmountAccepted = reader["amount_accepted"].AsDouble(),
                 ConfirmFlag = reader["confirm_flag"].AsString()
             };

        private object[] Take(POLineLocationModel model)
        {
            return new object[]
            {
                "@line_location_id", model.LineLocationId,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@po_header_id", model.PoHeaderId,
                "@po_line_id", model.PoLineId,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@quantity", model.Quantity,
                "@quantity_received", model.QuantityReceived,
                "@quantity_accepted", model.QuantityAccepted,
                "@quantity_rejected", model.QuantityRejected,
                "@quantity_billed", model.QuantityBilled,
                "@quantity_cancelled", model.QuantityCancelled,
                "@unit_meas_lookup_code", model.UnitMeasLookupCode,
                "@po_release_id", model.PoReleaseId,
                "@ship_to_location_id", model.ShipToLocationId,
                "@ship_via_lookup_code", model.ShipViaLookupCode,
                "@need_by_date", model.NeedByDate,
                "@promised_date", model.PromisedDate,
                "@last_accept_date", model.LastAcceptDate,
                "@price_override", model.PriceOverride,
                "@encumbered_flag", (model.EncumberedFlag) ? "Y" : "N",
                "@encumbered_date", model.EncumberedDate,
                "@unencumbered_quantity", model.UnencumberedQuantity,
                "@fob_lookup_code", model.FobLookupCode,
                "@freight_terms_lookup_code", model.FreightTermsLookupCode,
                "@taxable_flag", (model.TaxableFlag) ? "Y" : "N",
                "@tax_name", model.TaxName,
                "@estimated_tax_amount", model.EstimatedTaxAmount,
                "@inspection_required_flag", (model.InspectionRequiredFlag) ? "Y" : "N",
                "@receipt_required_flag", (model.ReceiptRequiredFlag) ? "Y" : "N",
                "@shipment_num", model.ShipmentNum,
                "@receipt_header_id", model.ReceiptHeaderId,
                "@receipt_line_id", model.ReceiptLineId,
                "@org_id", model.OrgId,
                "@tax_code_id", model.TaxCodeId,
                "@calculate_tax_flag", (model.CalculateTaxFlag) ? "Y" : "N",
                "@note_to_receiver", model.NoteToReceiver,
                "@amount", model.Amount,
                "@amount_received", model.AmountReceived,
                "@amount_billed", model.AmountBilled,
                "@amount_cancelled", model.AmountCancelled,
                "@amount_rejected", model.AmountRejected,
                "@amount_accepted", model.AmountAccepted,
                "@confirm_flag", model.ConfirmFlag
            };
        }
    }
}
