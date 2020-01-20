using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Purchasing;

namespace Eureka.Data.AdoNet.Purchasing
{
    public class POReceiptLineDao : IPOReceiptLineDao
    {
        private static Db db = new Db("ms_sql");

        public List<POReceiptLineModel> GetAll()
        {
            string sql = @"SELECT rcvl.receipt_line_id, rcvl.last_update_date, rcvl.last_updated_by, rcvl.creation_date
	                            , rcvl.created_by, rcvl.receipt_header_id, rcvl.line_num
	                            , rcvl.category_id, rcvl.quantity_shipped, rcvl.quantity_received
	                            , rcvl.unit_of_measure, rcvl.item_description, rcvl.item_id
	                            , rcvl.item_revision, rcvl.vendor_item_num, rcvl.vendor_lot_num
	                            , rcvl.uom_conversion_rate, rcvl.shipment_line_status_code, rcvl.source_document_code
	                            , rcvl.po_header_id, rcvl.po_release_id, rcvl.po_line_id
	                            , rcvl.po_line_location_id, rcvl.po_distribution_id, rcvl.requisition_line_id
	                            , rcvl.req_distribution_id, rcvl.routing_header_id, rcvl.packing_slip
	                            , rcvl.from_organization_id, rcvl.deliver_to_person_id, rcvl.employee_id
	                            , rcvl.destination_type_code, rcvl.to_organization_id, rcvl.to_subinventory
	                            , rcvl.locator_id, rcvl.deliver_to_location_id, rcvl.charge_account_id
	                            , rcvl.transportation_account_id, rcvl.shipment_unit_price, rcvl.transfer_cost
	                            , rcvl.transportation_cost, rcvl.comments, rcvl.attribute_category
	                            , rcvl.attribute1, rcvl.attribute2, rcvl.attribute3
	                            , rcvl.attribute4, rcvl.attribute5, rcvl.tax_name
	                            , rcvl.tax_amount, rcvl.invoice_status_code, rcvl.cum_comparison_flag
	                            , rcvl.truck_num, rcvl.bar_code_label, rcvl.cost_group_id
	                            , rcvl.secondary_quantity_shipped, rcvl.secondary_quantity_received, rcvl.secondary_unit_of_measure
	                            , rcvl.qc_require_inspc_flag , rcvl.qc_inspection_status, rcvl.mmt_transaction_id
	                            , rcvl.asn_lpn_id, rcvl.amount, rcvl.amount_received
	                            , rcvl.job_id, rcvl.approval_status, rcvl.amount_shipped, rcvl.qc_inspection_by
	                            , rcvl.project_id, rcvl.project_num, rcvl.quantity_ordered, rcvl.cost_code, rcvl.lot_number
                            FROM po_receipt_lines rcvl";

            return db.Read(sql, Make).ToList();
        }

        public List<POReceiptLineModel> GetByDate(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT rcvl.receipt_line_id, rcvl.last_update_date, rcvl.last_updated_by, rcvl.creation_date
	                            , rcvl.created_by, rcvl.receipt_header_id, rcvl.line_num
	                            , rcvl.category_id, rcvl.quantity_shipped, rcvl.quantity_received
	                            , rcvl.unit_of_measure, rcvl.item_description, rcvl.item_id
	                            , rcvl.item_revision, rcvl.vendor_item_num, rcvl.vendor_lot_num
	                            , rcvl.uom_conversion_rate, rcvl.shipment_line_status_code, rcvl.source_document_code
	                            , rcvl.po_header_id, rcvl.po_release_id, rcvl.po_line_id
	                            , rcvl.po_line_location_id, rcvl.po_distribution_id, rcvl.requisition_line_id
	                            , rcvl.req_distribution_id, rcvl.routing_header_id, rcvl.packing_slip
	                            , rcvl.from_organization_id, rcvl.deliver_to_person_id, rcvl.employee_id
	                            , rcvl.destination_type_code, rcvl.to_organization_id, rcvl.to_subinventory
	                            , rcvl.locator_id, rcvl.deliver_to_location_id, rcvl.charge_account_id
	                            , rcvl.transportation_account_id, rcvl.shipment_unit_price, rcvl.transfer_cost
	                            , rcvl.transportation_cost, rcvl.comments, rcvl.attribute_category
	                            , rcvl.attribute1, rcvl.attribute2, rcvl.attribute3
	                            , rcvl.attribute4, rcvl.attribute5, rcvl.tax_name
	                            , rcvl.tax_amount, rcvl.invoice_status_code, rcvl.cum_comparison_flag
	                            , rcvl.truck_num, rcvl.bar_code_label, rcvl.cost_group_id
	                            , rcvl.secondary_quantity_shipped, rcvl.secondary_quantity_received, rcvl.secondary_unit_of_measure
	                            , rcvl.qc_require_inspc_flag , rcvl.qc_inspection_status, rcvl.mmt_transaction_id
	                            , rcvl.asn_lpn_id, rcvl.amount, rcvl.amount_received
	                            , rcvl.job_id, rcvl.approval_status, rcvl.amount_shipped, rcvl.qc_inspection_by
	                            , rcvl.project_id, rcvl.project_num, rcvl.quantity_ordered, rcvl.cost_code, rcvl.lot_number
                            FROM po_receipt_lines rcvl
                          WHERE cast(rcvl.creation_date as date) BETWEEN cast(@StartDate as date) AND cast(@EndDate as date)";

            object[] parms = { "@StartDate", startDate, "@EndDate", endDate };
            return db.Read(sql, Make, parms).ToList();
        }

        public POReceiptLineModel GetByID(int id)
        {
            string sql = @"SELECT rcvl.receipt_line_id, rcvl.last_update_date, rcvl.last_updated_by, rcvl.creation_date
	                            , rcvl.created_by, rcvl.receipt_header_id, rcvl.line_num
	                            , rcvl.category_id, rcvl.quantity_shipped, rcvl.quantity_received
	                            , rcvl.unit_of_measure, rcvl.item_description, rcvl.item_id
	                            , rcvl.item_revision, rcvl.vendor_item_num, rcvl.vendor_lot_num
	                            , rcvl.uom_conversion_rate, rcvl.shipment_line_status_code, rcvl.source_document_code
	                            , rcvl.po_header_id, rcvl.po_release_id, rcvl.po_line_id
	                            , rcvl.po_line_location_id, rcvl.po_distribution_id, rcvl.requisition_line_id
	                            , rcvl.req_distribution_id, rcvl.routing_header_id, rcvl.packing_slip
	                            , rcvl.from_organization_id, rcvl.deliver_to_person_id, rcvl.employee_id
	                            , rcvl.destination_type_code, rcvl.to_organization_id, rcvl.to_subinventory
	                            , rcvl.locator_id, rcvl.deliver_to_location_id, rcvl.charge_account_id
	                            , rcvl.transportation_account_id, rcvl.shipment_unit_price, rcvl.transfer_cost
	                            , rcvl.transportation_cost, rcvl.comments, rcvl.attribute_category
	                            , rcvl.attribute1, rcvl.attribute2, rcvl.attribute3
	                            , rcvl.attribute4, rcvl.attribute5, rcvl.tax_name
	                            , rcvl.tax_amount, rcvl.invoice_status_code, rcvl.cum_comparison_flag
	                            , rcvl.truck_num, rcvl.bar_code_label, rcvl.cost_group_id
	                            , rcvl.secondary_quantity_shipped, rcvl.secondary_quantity_received, rcvl.secondary_unit_of_measure
	                            , rcvl.qc_require_inspc_flag , rcvl.qc_inspection_status, rcvl.mmt_transaction_id
	                            , rcvl.asn_lpn_id, rcvl.amount, rcvl.amount_received
	                            , rcvl.job_id, rcvl.approval_status, rcvl.amount_shipped, rcvl.qc_inspection_by
	                            , rcvl.project_id, rcvl.project_num, rcvl.quantity_ordered, rcvl.cost_code, rcvl.lot_number
                            FROM po_receipt_lines rcvl
                          WHERE rcvl.receipt_line_id = @receipt_line_id";

            object[] parms = { "@receipt_line_id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public List<POReceiptLineModel> GetByPOID(int id)
        {
            string sql = @"SELECT rcvl.receipt_line_id, rcvl.last_update_date, rcvl.last_updated_by, rcvl.creation_date
	                            , rcvl.created_by, rcvl.receipt_header_id, rcvl.line_num
	                            , rcvl.category_id, rcvl.quantity_shipped, rcvl.quantity_received
	                            , rcvl.unit_of_measure, rcvl.item_description, rcvl.item_id
	                            , rcvl.item_revision, rcvl.vendor_item_num, rcvl.vendor_lot_num
	                            , rcvl.uom_conversion_rate, rcvl.shipment_line_status_code, rcvl.source_document_code
	                            , rcvl.po_header_id, rcvl.po_release_id, rcvl.po_line_id
	                            , rcvl.po_line_location_id, rcvl.po_distribution_id, rcvl.requisition_line_id
	                            , rcvl.req_distribution_id, rcvl.routing_header_id, rcvl.packing_slip
	                            , rcvl.from_organization_id, rcvl.deliver_to_person_id, rcvl.employee_id
	                            , rcvl.destination_type_code, rcvl.to_organization_id, rcvl.to_subinventory
	                            , rcvl.locator_id, rcvl.deliver_to_location_id, rcvl.charge_account_id
	                            , rcvl.transportation_account_id, rcvl.shipment_unit_price, rcvl.transfer_cost
	                            , rcvl.transportation_cost, rcvl.comments, rcvl.attribute_category
	                            , rcvl.attribute1, rcvl.attribute2, rcvl.attribute3
	                            , rcvl.attribute4, rcvl.attribute5, rcvl.tax_name
	                            , rcvl.tax_amount, rcvl.invoice_status_code, rcvl.cum_comparison_flag
	                            , rcvl.truck_num, rcvl.bar_code_label, rcvl.cost_group_id
	                            , rcvl.secondary_quantity_shipped, rcvl.secondary_quantity_received, rcvl.secondary_unit_of_measure
	                            , rcvl.qc_require_inspc_flag , rcvl.qc_inspection_status, rcvl.mmt_transaction_id
	                            , rcvl.asn_lpn_id, rcvl.amount, rcvl.amount_received
	                            , rcvl.job_id, rcvl.approval_status, rcvl.amount_shipped, rcvl.qc_inspection_by
	                            , rcvl.project_id, rcvl.project_num, rcvl.quantity_ordered, rcvl.cost_code, rcvl.lot_number
                            FROM po_receipt_lines rcvl
                          WHERE rcvl.po_header_id = @po_header_id";

            object[] parms = { "@po_header_id", id };
            return db.Read(sql, Make, parms).ToList();
        }

        public List<POReceiptLineModel> GetByPOLineID(int id)
        {
            string sql = @"SELECT rcvl.receipt_line_id, rcvl.last_update_date, rcvl.last_updated_by, rcvl.creation_date
	                            , rcvl.created_by, rcvl.receipt_header_id, rcvl.line_num
	                            , rcvl.category_id, rcvl.quantity_shipped, rcvl.quantity_received
	                            , rcvl.unit_of_measure, rcvl.item_description, rcvl.item_id
	                            , rcvl.item_revision, rcvl.vendor_item_num, rcvl.vendor_lot_num
	                            , rcvl.uom_conversion_rate, rcvl.shipment_line_status_code, rcvl.source_document_code
	                            , rcvl.po_header_id, rcvl.po_release_id, rcvl.po_line_id
	                            , rcvl.po_line_location_id, rcvl.po_distribution_id, rcvl.requisition_line_id
	                            , rcvl.req_distribution_id, rcvl.routing_header_id, rcvl.packing_slip
	                            , rcvl.from_organization_id, rcvl.deliver_to_person_id, rcvl.employee_id
	                            , rcvl.destination_type_code, rcvl.to_organization_id, rcvl.to_subinventory
	                            , rcvl.locator_id, rcvl.deliver_to_location_id, rcvl.charge_account_id
	                            , rcvl.transportation_account_id, rcvl.shipment_unit_price, rcvl.transfer_cost
	                            , rcvl.transportation_cost, rcvl.comments, rcvl.attribute_category
	                            , rcvl.attribute1, rcvl.attribute2, rcvl.attribute3
	                            , rcvl.attribute4, rcvl.attribute5, rcvl.tax_name
	                            , rcvl.tax_amount, rcvl.invoice_status_code, rcvl.cum_comparison_flag
	                            , rcvl.truck_num, rcvl.bar_code_label, rcvl.cost_group_id
	                            , rcvl.secondary_quantity_shipped, rcvl.secondary_quantity_received, rcvl.secondary_unit_of_measure
	                            , rcvl.qc_require_inspc_flag , rcvl.qc_inspection_status, rcvl.mmt_transaction_id
	                            , rcvl.asn_lpn_id, rcvl.amount, rcvl.amount_received
	                            , rcvl.job_id, rcvl.approval_status, rcvl.amount_shipped, rcvl.qc_inspection_by
	                            , rcvl.project_id, rcvl.project_num, rcvl.quantity_ordered, rcvl.cost_code, rcvl.lot_number
                            FROM po_receipt_lines rcvl
                          WHERE rcvl.po_line_id = @po_line_id";

            object[] parms = { "@po_line_id", id };
            return db.Read(sql, Make, parms).ToList();
        }

        public List<POReceiptLineModel> GetByReceiptID(int id)
        {
            string sql = @"SELECT rcvl.receipt_line_id, rcvl.last_update_date, rcvl.last_updated_by, rcvl.creation_date
	                            , rcvl.created_by, rcvl.receipt_header_id, rcvl.line_num
	                            , rcvl.category_id, rcvl.quantity_shipped, ISNULL(loc.quantity_received, 0) quantity_received
	                            , rcvl.unit_of_measure, rcvl.item_description, rcvl.item_id
	                            , rcvl.item_revision, rcvl.vendor_item_num, rcvl.vendor_lot_num
	                            , rcvl.uom_conversion_rate, rcvl.shipment_line_status_code, rcvl.source_document_code
	                            , rcvl.po_header_id, rcvl.po_release_id, rcvl.po_line_id
	                            , rcvl.po_line_location_id, rcvl.po_distribution_id, rcvl.requisition_line_id
	                            , rcvl.req_distribution_id, rcvl.routing_header_id, rcvl.packing_slip
	                            , rcvl.from_organization_id, rcvl.deliver_to_person_id, rcvl.employee_id
	                            , rcvl.destination_type_code, rcvl.to_organization_id, rcvl.to_subinventory
	                            , rcvl.locator_id, rcvl.deliver_to_location_id, rcvl.charge_account_id
	                            , rcvl.transportation_account_id, rcvl.shipment_unit_price, rcvl.transfer_cost
	                            , rcvl.transportation_cost, rcvl.comments, rcvl.attribute_category
	                            , rcvl.attribute1, rcvl.attribute2, rcvl.attribute3
	                            , rcvl.attribute4, rcvl.attribute5, rcvl.tax_name
	                            , rcvl.tax_amount, rcvl.invoice_status_code, rcvl.cum_comparison_flag
	                            , rcvl.truck_num, rcvl.bar_code_label, rcvl.cost_group_id
	                            , rcvl.secondary_quantity_shipped, rcvl.secondary_quantity_received, rcvl.secondary_unit_of_measure
	                            , rcvl.qc_require_inspc_flag , rcvl.qc_inspection_status, rcvl.mmt_transaction_id
	                            , rcvl.asn_lpn_id, rcvl.amount, rcvl.amount_received
	                            , rcvl.job_id, rcvl.approval_status, rcvl.amount_shipped, rcvl.qc_inspection_by
	                            , rcvl.project_id, rcvl.project_num, rcvl.quantity_ordered, rcvl.cost_code, rcvl.lot_number
                                , poh.po_num, pol.po_line_num, pol.item_code
                            FROM po_receipt_lines rcvl
							LEFT JOIN po_headers_all poh ON(rcvl.po_header_id = poh.po_header_id)
							LEFT JOIN po_lines_all pol ON(rcvl.po_line_id = pol.po_line_id)
							LEFT JOIN (SELECT po_header_id, po_line_id, sum(quantity_received)  quantity_received
                            FROM po_line_locations_all GROUP BY po_header_id ,po_line_id) loc 
                                ON(rcvl.po_line_id = loc.po_line_id)
                          WHERE rcvl.receipt_header_id = @receipt_header_id";

            object[] parms = { "@receipt_header_id", id };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public int Insert(POReceiptLineModel model)
        {
            string sql =
                @"INSERT INTO po_receipt_lines
	                (last_update_date,last_updated_by,creation_date
	                ,created_by,receipt_header_id,line_num
	                ,category_id,quantity_shipped,quantity_received
	                ,unit_of_measure,item_description,item_id
	                ,item_revision,vendor_item_num,vendor_lot_num
	                ,uom_conversion_rate,shipment_line_status_code,source_document_code
	                ,po_header_id,po_release_id,po_line_id
	                ,po_line_location_id,po_distribution_id,requisition_line_id
	                ,req_distribution_id,routing_header_id,packing_slip
	                ,from_organization_id,deliver_to_person_id,employee_id
	                ,destination_type_code,to_organization_id,to_subinventory
	                ,locator_id,deliver_to_location_id,charge_account_id
	                ,transportation_account_id,shipment_unit_price,transfer_cost
	                ,transportation_cost,comments,attribute_category
	                ,attribute1,attribute2,attribute3
	                ,attribute4,attribute5,tax_name
	                ,tax_amount,invoice_status_code,cum_comparison_flag
	                ,truck_num,bar_code_label,cost_group_id
	                ,secondary_quantity_shipped,secondary_quantity_received,secondary_unit_of_measure
	                ,qc_require_inspc_flag ,qc_inspection_status,mmt_transaction_id
	                ,asn_lpn_id,amount,amount_received
	                ,job_id,approval_status,amount_shipped
	                ,project_id,project_num,quantity_ordered
                    ,cost_code,lot_number,qc_inspection_by)
                VALUES
	                ( @last_update_date, @last_updated_by, @creation_date
	                , @created_by, @receipt_header_id, @line_num
	                , @category_id, @quantity_shipped, @quantity_received
	                , @unit_of_measure, @item_description, @item_id
	                , @item_revision, @vendor_item_num, @vendor_lot_num
	                , @uom_conversion_rate, @shipment_line_status_code, @source_document_code
	                , @po_header_id, @po_release_id, @po_line_id
	                , @po_line_location_id, @po_distribution_id, @requisition_line_id
	                , @req_distribution_id, @routing_header_id, @packing_slip
	                , @from_organization_id, @deliver_to_person_id, @employee_id
	                , @destination_type_code, @to_organization_id, @to_subinventory
	                , @locator_id, @deliver_to_location_id, @charge_account_id
	                , @transportation_account_id, @shipment_unit_price, @transfer_cost
	                , @transportation_cost, @comments, @attribute_category
	                , @attribute1, @attribute2, @attribute3
	                , @attribute4, @attribute5, @tax_name
	                , @tax_amount, @invoice_status_code, @cum_comparison_flag
	                , @truck_num, @bar_code_label, @cost_group_id
	                , @secondary_quantity_shipped, @secondary_quantity_received, @secondary_unit_of_measure
	                , @qc_require_inspc_flag, @qc_inspection_status, @mmt_transaction_id
	                , @asn_lpn_id, @amount, @amount_received
	                , @job_id, @approval_status, @amount_shipped
	                , @project_id, @project_num,@quantity_ordered
                    , @cost_code, @lot_number,@qc_inspection_by)";

            return db.Insert(sql, Take(model));
        }

        public void Update(POReceiptLineModel model)
        {
            string sql =
            @"UPDATE po_receipt_lines
               SET last_update_date = @last_update_date
                  ,last_updated_by = @last_updated_by
                  ,receipt_header_id = @receipt_header_id
                  ,line_num = @line_num
                  ,category_id = @category_id
                  ,quantity_shipped = @quantity_shipped
                  ,quantity_received = @quantity_received
                  ,unit_of_measure = @unit_of_measure
                  ,item_description = @item_description
                  ,item_id = @item_id
                  ,item_revision = @item_revision
                  ,vendor_item_num = @vendor_item_num
                  ,vendor_lot_num = @vendor_lot_num
                  ,uom_conversion_rate = @uom_conversion_rate
                  ,shipment_line_status_code = @shipment_line_status_code
                  ,source_document_code = @source_document_code
                  ,po_header_id = @po_header_id
                  ,po_release_id = @po_release_id
                  ,po_line_id = @po_line_id
                  ,po_line_location_id = @po_line_location_id
                  ,po_distribution_id = @po_distribution_id
                  ,requisition_line_id = @requisition_line_id
                  ,req_distribution_id = @req_distribution_id
                  ,routing_header_id = @routing_header_id
                  ,packing_slip = @packing_slip
                  ,from_organization_id = @from_organization_id
                  ,deliver_to_person_id = @deliver_to_person_id
                  ,employee_id = @employee_id
                  ,destination_type_code = @destination_type_code
                  ,to_organization_id = @to_organization_id
                  ,to_subinventory = @to_subinventory
                  ,locator_id = @locator_id
                  ,deliver_to_location_id = @deliver_to_location_id
                  ,charge_account_id = @charge_account_id
                  ,transportation_account_id = @transportation_account_id
                  ,shipment_unit_price = @shipment_unit_price
                  ,transfer_cost = @transfer_cost
                  ,transportation_cost = @transportation_cost
                  ,comments = @comments
                  ,attribute_category = @attribute_category
                  ,attribute1 = @attribute1
                  ,attribute2 = @attribute2
                  ,attribute3 = @attribute3
                  ,attribute4 = @attribute4
                  ,attribute5 = @attribute5
                  ,tax_name = @tax_name
                  ,tax_amount = @tax_amount
                  ,invoice_status_code = @invoice_status_code
                  ,cum_comparison_flag = @cum_comparison_flag
                  ,truck_num = @truck_num
                  ,bar_code_label = @bar_code_label
                  ,cost_group_id = @cost_group_id
                  ,secondary_quantity_shipped = @secondary_quantity_shipped
                  ,secondary_quantity_received = @secondary_quantity_received
                  ,secondary_unit_of_measure = @secondary_unit_of_measure
                  ,qc_require_inspc_flag = @qc_require_inspc_flag
                  ,qc_inspection_status = @qc_inspection_status
                  ,mmt_transaction_id = @mmt_transaction_id
                  ,asn_lpn_id = @asn_lpn_id
                  ,amount = @amount
                  ,amount_received = @amount_received
                  ,job_id = @job_id
                  ,approval_status = @approval_status
                  ,amount_shipped = @amount_shipped
                  ,project_id = @project_id
                  ,project_num = @project_num
                  ,quantity_ordered = @quantity_ordered
                  ,cost_code = @cost_code
                  ,lot_number = @lot_number
                  ,qc_inspection_by = @qc_inspection_by
             WHERE receipt_line_id = @receipt_line_id";

            db.Update(sql, Take(model));
        }

        public void Delete(POReceiptLineModel model)
        {
            string sql =
            @"DELETE FROM po_receipt_lines
               WHERE receipt_line_id = @receipt_line_id";

            object[] parms = { "@receipt_line_id", model.ReceiptLineId };
            db.Update(sql, parms);
        }

        private static Func<IDataReader, POReceiptLineModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            row.PONum = reader["po_num"].AsString();
            row.POLineNum = reader["po_line_num"].AsInt();
            row.ItemCode = reader["item_code"].AsString();
            return row;
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, POReceiptLineModel> Make = reader =>
             new POReceiptLineModel
             {
                 ReceiptLineId = reader["receipt_line_id"].AsInt(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 ReceiptHeaderId = reader["receipt_header_id"].AsInt(),
                 LineNum = reader["line_num"].AsInt(),
                 CategoryId = reader["category_id"].AsInt(),
                 QuantityShipped = reader["quantity_shipped"].AsDouble(),
                 QuantityOrdered = reader["quantity_ordered"].AsDouble(),
                 QuantityReceived = reader["quantity_received"].AsDouble(),
                 UnitOfMeasure = reader["unit_of_measure"].AsString(),
                 ItemDescription = reader["item_description"].AsString(),
                 ItemId = reader["item_id"].AsInt(),
                 ItemRevision = reader["item_revision"].AsString(),
                 VendorItemNum = reader["vendor_item_num"].AsString(),
                 VendorLotNum = reader["vendor_lot_num"].AsString(),
                 UomConversionRate = reader["uom_conversion_rate"].AsDouble(),
                 ShipmentLineStatusCode = reader["shipment_line_status_code"].AsString(),
                 SourceDocumentCode = reader["source_document_code"].AsString(),
                 PoHeaderId = reader["po_header_id"].AsInt(),
                 PoReleaseId = reader["po_release_id"].AsInt(),
                 PoLineId = reader["po_line_id"].AsInt(),
                 PoLineLocationId = reader["po_line_location_id"].AsInt(),
                 PoDistributionId = reader["po_distribution_id"].AsInt(),
                 RequisitionLineId = reader["requisition_line_id"].AsInt(),
                 ReqDistributionId = reader["req_distribution_id"].AsInt(),
                 RoutingHeaderId = reader["routing_header_id"].AsInt(),
                 PackingSlip = reader["packing_slip"].AsString(),
                 FromOrganizationId = reader["from_organization_id"].AsInt(),
                 DeliverToPersonId = reader["deliver_to_person_id"].AsInt(),
                 EmployeeId = reader["employee_id"].AsInt(),
                 DestinationTypeCode = reader["destination_type_code"].AsString(),
                 ToOrganizationId = reader["to_organization_id"].AsInt(),
                 ToSubinventory = reader["to_subinventory"].AsString(),
                 LocatorId = reader["locator_id"].AsInt(),
                 DeliverToLocationId = reader["deliver_to_location_id"].AsInt(),
                 ChargeAccountId = reader["charge_account_id"].AsInt(),
                 TransportationAccountId = reader["transportation_account_id"].AsInt(),
                 ShipmentUnitPrice = reader["shipment_unit_price"].AsDouble(),
                 TransferCost = reader["transfer_cost"].AsDouble(),
                 TransportationCost = reader["transportation_cost"].AsDouble(),
                 Comments = reader["comments"].AsString(),
                 AttributeCategory = reader["attribute_category"].AsString(),
                 Attribute1 = reader["attribute1"].AsString(),
                 Attribute2 = reader["attribute2"].AsString(),
                 Attribute3 = reader["attribute3"].AsString(),
                 Attribute4 = reader["attribute4"].AsString(),
                 Attribute5 = reader["attribute5"].AsString(),
                 TaxName = reader["tax_name"].AsString(),
                 TaxAmount = reader["tax_amount"].AsDouble(),
                 InvoiceStatusCode = reader["invoice_status_code"].AsString(),
                 CumComparisonFlag = (reader["cum_comparison_flag"].AsString() == "Y") ? true : false,
                 TruckNum = reader["truck_num"].AsString(),
                 BarCodeLabel = reader["bar_code_label"].AsString(),
                 PrjCostId = reader["cost_group_id"].AsInt(),
                 SecondaryQuantityShipped = reader["secondary_quantity_shipped"].AsDouble(),
                 SecondaryQuantityReceived = reader["secondary_quantity_received"].AsDouble(),
                 SecondaryUnitOfMeasure = reader["secondary_unit_of_measure"].AsString(),
                 QcRequireInspcFlag = (reader["qc_require_inspc_flag"].AsString() == "Y") ? true : false,
                 QcInspectionStatus = reader["qc_inspection_status"].AsInt(),
                 MmtTransactionId = reader["mmt_transaction_id"].AsInt(),
                 AsnLpnId = reader["asn_lpn_id"].AsInt(),
                 Amount = reader["amount"].AsDouble(),
                 AmountReceived = reader["amount_received"].AsDouble(),
                 JobId = reader["job_id"].AsDouble(),
                 ApprovalStatus = reader["approval_status"].AsString(),
                 AmountShipped = reader["amount_shipped"].AsDouble(),
                 ProjectId = reader["project_id"].AsInt(),
                 ProjectNum = reader["project_num"].AsString(),
                 CostCode = reader["cost_code"].AsString(),
                 LotNumber = reader["lot_number"].AsString(),
                 QcInspectionBy = reader["qc_inspection_by"].AsInt()
             };

        private object[] Take(POReceiptLineModel model)
        {
            return new object[]
            {
                "@receipt_line_id", model.ReceiptLineId,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@receipt_header_id", model.ReceiptHeaderId,
                "@line_num", model.LineNum,
                "@category_id", model.CategoryId,
                "@quantity_shipped", model.QuantityShipped,
                "@quantity_ordered", model.QuantityOrdered,
                "@quantity_received", model.QuantityReceived,
                "@unit_of_measure", model.UnitOfMeasure,
                "@item_description", model.ItemDescription,
                "@item_id", model.ItemId,
                "@item_revision", model.ItemRevision,
                "@vendor_item_num", model.VendorItemNum,
                "@vendor_lot_num", model.VendorLotNum,
                "@uom_conversion_rate", model.UomConversionRate,
                "@shipment_line_status_code", model.ShipmentLineStatusCode,
                "@source_document_code", model.SourceDocumentCode,
                "@po_header_id", model.PoHeaderId,
                "@po_release_id", model.PoReleaseId,
                "@po_line_id", model.PoLineId,
                "@po_line_location_id", model.PoLineLocationId,
                "@po_distribution_id", model.PoDistributionId,
                "@requisition_line_id", model.RequisitionLineId,
                "@req_distribution_id", model.ReqDistributionId,
                "@routing_header_id", model.RoutingHeaderId,
                "@packing_slip", model.PackingSlip,
                "@from_organization_id", model.FromOrganizationId,
                "@deliver_to_person_id", model.DeliverToPersonId,
                "@employee_id", model.EmployeeId,
                "@destination_type_code", model.DestinationTypeCode,
                "@to_organization_id", model.ToOrganizationId,
                "@to_subinventory", model.ToSubinventory,
                "@locator_id", model.LocatorId,
                "@deliver_to_location_id", model.DeliverToLocationId,
                "@charge_account_id", model.ChargeAccountId,
                "@transportation_account_id", model.TransportationAccountId,
                "@shipment_unit_price", model.ShipmentUnitPrice,
                "@transfer_cost", model.TransferCost,
                "@transportation_cost", model.TransportationCost,
                "@comments", model.Comments,
                "@attribute_category", model.AttributeCategory,
                "@attribute1", model.Attribute1,
                "@attribute2", model.Attribute2,
                "@attribute3", model.Attribute3,
                "@attribute4", model.Attribute4,
                "@attribute5", model.Attribute5,
                "@tax_name", model.TaxName,
                "@tax_amount", model.TaxAmount,
                "@invoice_status_code", model.InvoiceStatusCode,
                "@cum_comparison_flag", (model.CumComparisonFlag) ? "Y" : "N",
                "@truck_num", model.TruckNum,
                "@bar_code_label", model.BarCodeLabel,
                "@cost_group_id", model.PrjCostId,
                "@secondary_quantity_shipped", model.SecondaryQuantityShipped,
                "@secondary_quantity_received", model.SecondaryQuantityReceived,
                "@secondary_unit_of_measure", model.SecondaryUnitOfMeasure,
                "@qc_require_inspc_flag", (model.QcRequireInspcFlag) ? "Y" : "N",
                "@qc_inspection_status", model.QcInspectionStatus,
                "@mmt_transaction_id", model.MmtTransactionId,
                "@asn_lpn_id", model.AsnLpnId,
                "@amount", model.Amount,
                "@amount_received", model.AmountReceived,
                "@job_id", model.JobId,
                "@approval_status", model.ApprovalStatus,
                "@amount_shipped", model.AmountShipped,
                "@project_id", model.ProjectId,
                "@project_num", model.ProjectNum,
                "@cost_code", model.CostCode,
                "@lot_number", model.LotNumber,
                "@qc_inspection_by", model.QcInspectionBy
            };
        }
    }
}
