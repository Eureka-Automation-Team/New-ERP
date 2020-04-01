using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Purchasing;

namespace Eureka.Data.AdoNet.Purchasing
{
    public class POReceiptHaeaderDao : IPOReceiptHaeaderDao
    {
        private static Db db = new Db("ms_sql");

        public List<POReceiptHeaderModel> GetAll()
        {
            string sql = @"SELECT rcv.receipt_header_id, rcv.receipt_num, rcv.receipt_date, rcv.last_update_date
	                            , rcv.last_updated_by, rcv.creation_date, rcv.created_by
	                            , rcv.received_flag, rcv.receipt_source_code, rcv.vendor_id
	                            , rcv.vendor_site_id, rcv.organization_id, rcv.shipment_num
	                            , rcv.ship_to_location_id, rcv.bill_of_lading, rcv.packing_slip
	                            , rcv.shipped_date, rcv.employee_id, rcv.comments
	                            , rcv.attribute1, rcv.attribute2, rcv.attribute3
	                            , rcv.attribute4, rcv.attribute5, rcv.attribute6
	                            , rcv.attribute7, rcv.attribute8, rcv.attribute9
	                            , rcv.attribute10, rcv.attribute11, rcv.attribute12
	                            , rcv.attribute13, rcv.attribute14, rcv.attribute15
	                            , rcv.government_context, rcv.gross_weight, rcv.gross_weight_uom_code
	                            , rcv.net_weight, rcv.net_weight_uom_code, rcv.freight_terms
	                            , rcv.freight_bill_number, rcv.invoice_num, rcv.invoice_date
	                            , rcv.invoice_amount, rcv.tax_name, rcv.tax_amount
	                            , rcv.freight_amount, rcv.invoice_status_code, rcv.currency_code
	                            , rcv.conversion_rate_type, rcv.conversion_rate, rcv.conversion_date
	                            , rcv.approval_status, rcv.performance_period_from, rcv.performance_period_to
	                            , rcv.request_date, rcv.source_type, rcv.received_by, rcv.generate_grn_flag
                                , sup.vendor_number, sup.vendor_name, usr.DESCRIPTION as received_name
                                , rcv.qc_require_inspc_flag, rcv.qc_inspection_step, rcv.receipt_method
                            FROM po_receipt_headers rcv
							LEFT JOIN ap_suppliers sup ON(rcv.vendor_id = sup.vendor_id)
							LEFT JOIN fnd_users usr ON(rcv.received_by = usr.USER_ID)                     
                          WHERE cast(rcv.receipt_date as date) BETWEEN cast(@StartDate as date) AND cast(@EndDate as date)";

            return db.Read(sql, MakeWithStats).ToList();
        }

        public List<POReceiptHeaderModel> GetByDate(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT rcv.receipt_header_id, rcv.receipt_num, rcv.receipt_date, rcv.last_update_date
	                            , rcv.last_updated_by, rcv.creation_date, rcv.created_by
	                            , rcv.received_flag, rcv.receipt_source_code, rcv.vendor_id
	                            , rcv.vendor_site_id, rcv.organization_id, rcv.shipment_num
	                            , rcv.ship_to_location_id, rcv.bill_of_lading, rcv.packing_slip
	                            , rcv.shipped_date, rcv.employee_id, rcv.comments
	                            , rcv.attribute1, rcv.attribute2, rcv.attribute3
	                            , rcv.attribute4, rcv.attribute5, rcv.attribute6
	                            , rcv.attribute7, rcv.attribute8, rcv.attribute9
	                            , rcv.attribute10, rcv.attribute11, rcv.attribute12
	                            , rcv.attribute13, rcv.attribute14, rcv.attribute15
	                            , rcv.government_context, rcv.gross_weight, rcv.gross_weight_uom_code
	                            , rcv.net_weight, rcv.net_weight_uom_code, rcv.freight_terms
	                            , rcv.freight_bill_number, rcv.invoice_num, rcv.invoice_date
	                            , rcv.invoice_amount, rcv.tax_name, rcv.tax_amount
	                            , rcv.freight_amount, rcv.invoice_status_code, rcv.currency_code
	                            , rcv.conversion_rate_type, rcv.conversion_rate, rcv.conversion_date
	                            , rcv.approval_status, rcv.performance_period_from, rcv.performance_period_to
	                            , rcv.request_date, rcv.source_type, rcv.received_by, rcv.generate_grn_flag
                                , sup.vendor_number, sup.vendor_name, usr.DESCRIPTION as received_name
                                , rcv.qc_require_inspc_flag, rcv.qc_inspection_step, rcv.receipt_method
                            FROM po_receipt_headers rcv
							LEFT JOIN ap_suppliers sup ON(rcv.vendor_id = sup.vendor_id)
							LEFT JOIN fnd_users usr ON(rcv.received_by = usr.USER_ID)                     
                          WHERE cast(rcv.receipt_date as date) BETWEEN cast(@StartDate as date) AND cast(@EndDate as date)
                            AND rcv.generate_grn_flag = 'Y'";

            object[] parms = { "@StartDate", startDate, "@EndDate", endDate };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public POReceiptHeaderModel GetByID(int id)
        {
            string sql = @"SELECT rcv.receipt_header_id, rcv.receipt_num, rcv.receipt_date, rcv.last_update_date
	                            , rcv.last_updated_by, rcv.creation_date, rcv.created_by
	                            , rcv.received_flag, rcv.receipt_source_code, rcv.vendor_id
	                            , rcv.vendor_site_id, rcv.organization_id, rcv.shipment_num
	                            , rcv.ship_to_location_id, rcv.bill_of_lading, rcv.packing_slip
	                            , rcv.shipped_date, rcv.employee_id, rcv.comments
	                            , rcv.attribute1, rcv.attribute2, rcv.attribute3
	                            , rcv.attribute4, rcv.attribute5, rcv.attribute6
	                            , rcv.attribute7, rcv.attribute8, rcv.attribute9
	                            , rcv.attribute10, rcv.attribute11, rcv.attribute12
	                            , rcv.attribute13, rcv.attribute14, rcv.attribute15
	                            , rcv.government_context, rcv.gross_weight, rcv.gross_weight_uom_code
	                            , rcv.net_weight, rcv.net_weight_uom_code, rcv.freight_terms
	                            , rcv.freight_bill_number, rcv.invoice_num, rcv.invoice_date
	                            , rcv.invoice_amount, rcv.tax_name, rcv.tax_amount
	                            , rcv.freight_amount, rcv.invoice_status_code, rcv.currency_code
	                            , rcv.conversion_rate_type, rcv.conversion_rate, rcv.conversion_date
	                            , rcv.approval_status, rcv.performance_period_from, rcv.performance_period_to
	                            , rcv.request_date, rcv.source_type, rcv.received_by, rcv.generate_grn_flag
                                , sup.vendor_number, sup.vendor_name, usr.DESCRIPTION as received_name
                                , rcv.qc_require_inspc_flag, rcv.qc_inspection_step, rcv.receipt_method
                            FROM po_receipt_headers rcv
							LEFT JOIN ap_suppliers sup ON(rcv.vendor_id = sup.vendor_id)
							LEFT JOIN fnd_users usr ON(rcv.received_by = usr.USER_ID)
                          WHERE rcv.receipt_header_id = @receipt_header_id";

            object[] parms = { "@receipt_header_id", id };
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public POReceiptHeaderModel GetByNumber(string number)
        {
            string sql = @"SELECT rcv.receipt_header_id, rcv.receipt_num, rcv.receipt_date, rcv.last_update_date
	                            , rcv.last_updated_by, rcv.creation_date, rcv.created_by
	                            , rcv.received_flag, rcv.receipt_source_code, rcv.vendor_id
	                            , rcv.vendor_site_id, rcv.organization_id, rcv.shipment_num
	                            , rcv.ship_to_location_id, rcv.bill_of_lading, rcv.packing_slip
	                            , rcv.shipped_date, rcv.employee_id, rcv.comments
	                            , rcv.attribute1, rcv.attribute2, rcv.attribute3
	                            , rcv.attribute4, rcv.attribute5, rcv.attribute6
	                            , rcv.attribute7, rcv.attribute8, rcv.attribute9
	                            , rcv.attribute10, rcv.attribute11, rcv.attribute12
	                            , rcv.attribute13, rcv.attribute14, rcv.attribute15
	                            , rcv.government_context, rcv.gross_weight, rcv.gross_weight_uom_code
	                            , rcv.net_weight, rcv.net_weight_uom_code, rcv.freight_terms
	                            , rcv.freight_bill_number, rcv.invoice_num, rcv.invoice_date
	                            , rcv.invoice_amount, rcv.tax_name, rcv.tax_amount
	                            , rcv.freight_amount, rcv.invoice_status_code, rcv.currency_code
	                            , rcv.conversion_rate_type, rcv.conversion_rate, rcv.conversion_date
	                            , rcv.approval_status, rcv.performance_period_from, rcv.performance_period_to
	                            , rcv.request_date, rcv.source_type, rcv.received_by, rcv.generate_grn_flag
                                , sup.vendor_number, sup.vendor_name, usr.DESCRIPTION as received_name
                                , rcv.qc_require_inspc_flag, rcv.qc_inspection_step, rcv.receipt_method
                            FROM po_receipt_headers rcv
							LEFT JOIN ap_suppliers sup ON(rcv.vendor_id = sup.vendor_id)
							LEFT JOIN fnd_users usr ON(rcv.received_by = usr.USER_ID)
                          WHERE rcv.receipt_num = @receipt_num AND rcv.received_flag = @received_flag";

            object[] parms = { "@receipt_num", number, "@received_flag", "Y" };
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public int Insert(POReceiptHeaderModel model)
        {
            string sql =
                @"INSERT INTO po_receipt_headers
	                (receipt_num,receipt_date,last_update_date
	                ,last_updated_by,creation_date,created_by
	                ,received_flag,receipt_source_code,vendor_id
	                ,vendor_site_id,organization_id,shipment_num
	                ,ship_to_location_id,bill_of_lading,packing_slip
	                ,shipped_date,employee_id,comments
	                ,attribute1,attribute2,attribute3
	                ,attribute4,attribute5,attribute6
	                ,attribute7,attribute8,attribute9
	                ,attribute10,attribute11,attribute12
	                ,attribute13,attribute14,attribute15
	                ,government_context,gross_weight,gross_weight_uom_code
	                ,net_weight,net_weight_uom_code,freight_terms
	                ,freight_bill_number,invoice_num,invoice_date
	                ,invoice_amount,tax_name,tax_amount
	                ,freight_amount,invoice_status_code,currency_code
	                ,conversion_rate_type,conversion_rate,conversion_date
	                ,approval_status,performance_period_from,performance_period_to
	                ,request_date, source_type, received_by, generate_grn_flag
                    ,qc_require_inspc_flag,qc_inspection_step,receipt_method)
                VALUES
	                (@receipt_num,@receipt_date,@last_update_date
	                ,@last_updated_by,@creation_date,@created_by
	                ,@received_flag,@receipt_source_code,@vendor_id
	                ,@vendor_site_id,@organization_id,@shipment_num
	                ,@ship_to_location_id,@bill_of_lading,@packing_slip
	                ,@shipped_date,@employee_id,@comments
	                ,@attribute1,@attribute2,@attribute3
	                ,@attribute4,@attribute5,@attribute6
	                ,@attribute7,@attribute8,@attribute9
	                ,@attribute10,@attribute11,@attribute12
	                ,@attribute13,@attribute14,@attribute15
	                ,@government_context,@gross_weight,@gross_weight_uom_code
	                ,@net_weight,@net_weight_uom_code,@freight_terms
	                ,@freight_bill_number,@invoice_num,@invoice_date
	                ,@invoice_amount,@tax_name,@tax_amount
	                ,@freight_amount,@invoice_status_code,@currency_code
	                ,@conversion_rate_type,@conversion_rate,@conversion_date
	                ,@approval_status,@performance_period_from,@performance_period_to
	                ,@request_date,@source_type,@received_by,@generate_grn_flag
                    ,@qc_require_inspc_flag,@qc_inspection_step,@receipt_method)";

            return db.Insert(sql, Take(model));
        }

        public void Update(POReceiptHeaderModel model)
        {
            string sql =
            @"UPDATE po_receipt_headers
               SET receipt_num = @receipt_num
                  ,receipt_date = @receipt_date
                  ,last_update_date = @last_update_date
                  ,last_updated_by = @last_updated_by
                  ,received_flag = @received_flag
                  ,receipt_source_code = @receipt_source_code
                  ,vendor_id = @vendor_id
                  ,vendor_site_id = @vendor_site_id
                  ,organization_id = @organization_id
                  ,shipment_num = @shipment_num
                  ,ship_to_location_id = @ship_to_location_id
                  ,bill_of_lading = @bill_of_lading
                  ,packing_slip = @packing_slip
                  ,shipped_date = @shipped_date
                  ,employee_id = @employee_id
                  ,comments = @comments
                  ,attribute1 = @attribute1
                  ,attribute2 = @attribute2
                  ,attribute3 = @attribute3
                  ,attribute4 = @attribute4
                  ,attribute5 = @attribute5
                  ,attribute6 = @attribute6
                  ,attribute7 = @attribute7
                  ,attribute8 = @attribute8
                  ,attribute9 = @attribute9
                  ,attribute10 = @attribute10
                  ,attribute11 = @attribute11
                  ,attribute12 = @attribute12
                  ,attribute13 = @attribute13
                  ,attribute14 = @attribute14
                  ,attribute15 = @attribute15
                  ,government_context = @government_context
                  ,gross_weight = @gross_weight
                  ,gross_weight_uom_code = @gross_weight_uom_code
                  ,net_weight = @net_weight
                  ,net_weight_uom_code = @net_weight_uom_code
                  ,freight_terms = @freight_terms
                  ,freight_bill_number = @freight_bill_number
                  ,invoice_num = @invoice_num
                  ,invoice_date = @invoice_date
                  ,invoice_amount = @invoice_amount
                  ,tax_name = @tax_name
                  ,tax_amount = @tax_amount
                  ,freight_amount = @freight_amount
                  ,invoice_status_code = @invoice_status_code
                  ,currency_code = @currency_code
                  ,conversion_rate_type = @conversion_rate_type
                  ,conversion_rate = @conversion_rate
                  ,conversion_date = @conversion_date
                  ,approval_status = @approval_status
                  ,performance_period_from = @performance_period_from
                  ,performance_period_to = @performance_period_to
                  ,request_date = @request_date
                  ,source_type = @source_type
                  ,received_by = @received_by
                  ,generate_grn_flag = @generate_grn_flag
                  ,qc_require_inspc_flag = @qc_require_inspc_flag
                  ,qc_inspection_step = @qc_inspection_step
                  ,receipt_method = @receipt_method
             WHERE receipt_header_id = @receipt_header_id";

            db.Update(sql, Take(model));
        }

        public void Delete(POReceiptHeaderModel model)
        {
            string sql = @"DELETE FROM po_receipt_headers WHERE receipt_header_id = @receipt_header_id";

            object[] parms = { "@receipt_header_id", model.ReceiptHeaderId };
            db.Update(sql, parms);
        }

        // creates a Members object with order statistics based on DataReader       
        private static Func<IDataReader, POReceiptHeaderModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            row.VendorName = reader["vendor_name"].AsString();
            row.VendorCode = reader["vendor_number"].AsString();
            row.ReceivedByName = reader["received_name"].AsString();
            return row;
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, POReceiptHeaderModel> Make = reader =>
             new POReceiptHeaderModel
             {
                 ReceiptHeaderId = reader["receipt_header_id"].AsInt(),
                 ReceiptNum = reader["receipt_num"].AsString(),
                 ReceiptDate = reader["receipt_date"].AsDateTime(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 ReceivedFlag = (reader["received_flag"].AsString() == "Y") ? true : false,
                 ReceiptSourceCode = reader["receipt_source_code"].AsString(),
                 VendorId = reader["vendor_id"].AsInt(),
                 VendorName = reader["vendor_site_id"].AsString(),
                 OrganizationId = reader["organization_id"].AsInt(),
                 ShipmentNum = reader["shipment_num"].AsString(),
                 ShipToLocationId = reader["ship_to_location_id"].AsInt(),
                 BillOfLading = reader["bill_of_lading"].AsString(),
                 PackingSlip = reader["packing_slip"].AsString(),
                 ShippedDate = reader["shipped_date"].AsDateTime(),
                 EmployeeId = reader["employee_id"].AsInt(),
                 Comments = reader["comments"].AsString(),
                 Attribute1 = reader["attribute1"].AsString(),
                 Attribute2 = reader["attribute2"].AsString(),
                 Attribute3 = reader["attribute3"].AsString(),
                 Attribute4 = reader["attribute4"].AsString(),
                 Attribute5 = reader["attribute5"].AsString(),
                 Attribute6 = reader["attribute6"].AsString(),
                 Attribute7 = reader["attribute7"].AsString(),
                 Attribute8 = reader["attribute8"].AsString(),
                 Attribute9 = reader["attribute9"].AsString(),
                 Attribute10 = reader["attribute10"].AsString(),
                 Attribute11 = reader["attribute11"].AsString(),
                 Attribute12 = reader["attribute12"].AsString(),
                 Attribute13 = reader["attribute13"].AsString(),
                 Attribute14 = reader["attribute14"].AsString(),
                 Attribute15 = reader["attribute15"].AsString(),
                 GovernmentContext = reader["government_context"].AsString(),
                 GrossWeight = reader["gross_weight"].AsDouble(),
                 GrossWeightUomCode = reader["gross_weight_uom_code"].AsString(),
                 NetWeight = reader["net_weight"].AsDouble(),
                 NetWeightUomCode = reader["net_weight_uom_code"].AsString(),
                 FreightTerms = reader["freight_terms"].AsString(),
                 FreightBillNumber = reader["freight_bill_number"].AsString(),
                 InvoiceNum = reader["invoice_num"].AsString(),
                 InvoiceDate = (reader["invoice_date"] != DBNull.Value) ? reader["invoice_date"].AsDateTime() : (DateTime?)null,
                 InvoiceAmount = reader["invoice_amount"].AsDouble(),
                 TaxName = reader["tax_name"].AsString(),
                 TaxAmount = reader["tax_amount"].AsDouble(),
                 FreightAmount = reader["freight_amount"].AsDouble(),
                 InvoiceStatusCode = reader["invoice_status_code"].AsString(),
                 CurrencyCode = reader["currency_code"].AsString(),
                 ConversionRateType = reader["conversion_rate_type"].AsString(),
                 ConversionRate = reader["conversion_rate"].AsDouble(),
                 ConversionDate = (reader["conversion_date"] != DBNull.Value) ? reader["conversion_date"].AsDateTime() : (DateTime?)null,
                 ApprovalStatus = reader["approval_status"].AsString(),
                 PerformancePeriodFrom = (reader["performance_period_from"] != DBNull.Value) ? reader["performance_period_from"].AsDateTime() : (DateTime?)null,
                 PerformancePeriodTo = (reader["performance_period_to"] != DBNull.Value) ? reader["performance_period_to"].AsDateTime() : (DateTime?)null,
                 RequestDate = (reader["request_date"] != DBNull.Value) ? reader["request_date"].AsDateTime() : (DateTime?)null,
                 SourceType = reader["source_type"].AsString(),
                 ReceivedBy = reader["received_by"].AsInt(),
                 GenReceiptNumberFlag = (reader["generate_grn_flag"].AsString() == "Y") ? true : false,
                 QCInspectionFlag = (reader["qc_require_inspc_flag"].AsString() == "Y") ? true : false,
                 InspectionStatus = reader["qc_inspection_step"].AsString(),
                 ReceiptMethod = reader["receipt_method"].AsString()
             };

        private object[] Take(POReceiptHeaderModel model)
        {
            return new object[]
            {
                "@receipt_header_id", model.ReceiptHeaderId,
                "@receipt_num", model.ReceiptNum,
                "@receipt_date", model.ReceiptDate,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@received_flag", (model.ReceivedFlag) ? "Y" : "N",
                "@receipt_source_code", model.ReceiptSourceCode,
                "@vendor_id", model.VendorId,
                "@vendor_site_id", 0,
                "@organization_id", model.OrganizationId,
                "@shipment_num", model.ShipmentNum,
                "@ship_to_location_id", model.ShipToLocationId,
                "@bill_of_lading", model.BillOfLading,
                "@packing_slip", model.PackingSlip,
                "@shipped_date", model.ShippedDate,
                "@employee_id", model.EmployeeId,
                "@comments", model.Comments,
                "@attribute1", model.Attribute1,
                "@attribute2", model.Attribute2,
                "@attribute3", model.Attribute3,
                "@attribute4", model.Attribute4,
                "@attribute5", model.Attribute5,
                "@attribute6", model.Attribute6,
                "@attribute7", model.Attribute7,
                "@attribute8", model.Attribute8,
                "@attribute9", model.Attribute9,
                "@attribute10", model.Attribute10,
                "@attribute11", model.Attribute11,
                "@attribute12", model.Attribute12,
                "@attribute13", model.Attribute13,
                "@attribute14", model.Attribute14,
                "@attribute15", model.Attribute15,
                "@government_context", model.GovernmentContext,
                "@gross_weight", model.GrossWeight,
                "@gross_weight_uom_code", model.GrossWeightUomCode,
                "@net_weight", model.NetWeight,
                "@net_weight_uom_code", model.NetWeightUomCode,
                "@freight_terms", model.FreightTerms,
                "@freight_bill_number", model.FreightBillNumber,
                "@invoice_num", model.InvoiceNum,
                "@invoice_date", model.InvoiceDate,
                "@invoice_amount", model.InvoiceAmount,
                "@tax_name", model.TaxName,
                "@tax_amount", model.TaxAmount,
                "@freight_amount", model.FreightAmount,
                "@invoice_status_code", model.InvoiceStatusCode,
                "@currency_code", model.CurrencyCode,
                "@conversion_rate_type", model.ConversionRateType,
                "@conversion_rate", model.ConversionRate,
                "@conversion_date", model.ConversionDate,
                "@approval_status", model.ApprovalStatus,
                "@performance_period_from", model.PerformancePeriodFrom,
                "@performance_period_to", model.PerformancePeriodTo,
                "@request_date", model.RequestDate,
                "@source_type", model.SourceType,
                "@received_by", model.ReceivedBy,
                "@generate_grn_flag", (model.GenReceiptNumberFlag) ? "Y" : "N",
                 "@qc_require_inspc_flag", (model.QCInspectionFlag) ? "Y" : "N",
                 "@qc_inspection_step", model.InspectionStatus,
                 "@receipt_method", model.ReceiptMethod
            };
        }

        public List<RcvReportModel> GetReceivedReportByID(string startNo, string endNo)
        {
            string sql = @"SELECT rvh.receipt_num, rvh.receipt_date, sup.vendor_number
	                            , sup.vendor_name, rvh.invoice_num, usr.description as received_name
	                            , sup.vendor_id, poh.po_num, rvl.line_num, pol.item_code
	                            , rvl.item_description, pol.spec_model as manu_id, pol.brand_materail
	                            , rvl.project_num, rvl.to_subinventory, rvl.quantity_shipped
	                            , rvl.shipment_unit_price, rvh.received_by, rvl.item_id
                                , rvl.unit_of_measure, rvl.lot_number
                            FROM po_receipt_headers rvh
                            LEFT JOIN ap_suppliers sup ON(rvh.vendor_id = sup.vendor_id)
                            LEFT JOIN fnd_users usr ON(rvh.received_by = usr.user_id)
                            LEFT JOIN po_receipt_lines rvl ON(rvh.receipt_header_id = rvl.receipt_header_id)
                            LEFT JOIN po_lines_all pol ON(rvl.po_line_id = pol.po_line_id)
                            LEFT JOIN po_headers_all poh ON(rvl.po_header_id = poh.po_header_id)
                            WHERE rvh.received_flag = 'Y'
                            AND rvh.receipt_num BETWEEN @start_number AND @end_number
                            AND pol.cancel_flag = 'N'
                            ORDER BY rvh.receipt_header_id ASC";

            object[] parms = { "@start_number", startNo, "@end_number", endNo };
            return db.Read(sql, MakeReport, parms).ToList();
        }

        // creates a Member object based on DataReader
        private static Func<IDataReader, RcvReportModel> MakeReport = reader =>
             new RcvReportModel
             {
                 ReceiptNum = reader["receipt_num"].AsString(),
                 ReceiptDate = reader["receipt_date"].AsDateTime(),
                 VendorId = reader["vendor_id"].AsInt(),
                 VendorCode = reader["vendor_number"].AsString(),
                 VendorName = reader["vendor_name"].AsString(),
                 InvoiceNum = reader["invoice_num"].AsString(),
                 ReceivedBy = reader["received_by"].AsInt(),
                 ReceivedByName = reader["received_name"].AsString(),
                 PONumber = reader["po_num"].AsString(),
                 LineNum = reader["line_num"].AsInt(),
                 //POLineNum = reader["POLineNum"].AsInt(),
                 ItemId = reader["item_id"].AsInt(),
                 ItemCode = reader["item_code"].AsString(),
                 ItemDescription = reader["item_description"].AsString(),
                 Spec = reader["manu_id"].AsString(),
                 BrandMaterail = reader["brand_materail"].AsString(),
                 QuantityReceived = reader["quantity_shipped"].AsDouble(),
                 UnitOfMeasure = reader["unit_of_measure"].AsString(),
                 ShipmentUnitPrice = reader["shipment_unit_price"].AsDouble(),
                 ToSubinventory = reader["to_subinventory"].AsString(),
                 LotNumber = reader["lot_number"].AsString(),
                 ProjectNum = reader["project_num"].AsString()
             };
    }
}
