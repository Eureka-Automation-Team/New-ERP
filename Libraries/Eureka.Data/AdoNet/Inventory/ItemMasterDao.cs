using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Inventory;

namespace Eureka.Data.AdoNet.Inventory
{
    public class ItemMasterDao : IItemMasterDao
    {
        private static Db db = new Db("ms_sql");

        public List<ItemMasterModel> GetAll()
        {
            string sql = @"SELECT inventory_item_id, organization_id, last_update_date, last_updated_by, creation_date, created_by, 
		                    summary_flag, enabled_flag, start_date_active, end_date_active, item_description, buyer_id, 
		                    segment1, segment2, segment3, segment4, segment5, attribute1, attribute2, attribute3, attribute4, attribute5, 
		                    purchasing_item_flag, shippable_item_flag, customer_order_flag, internal_order_flag, service_item_flag, 
		                    inventory_item_flag, eng_item_flag, inventory_asset_flag, purchasing_enabled_flag, customer_order_enabled_flag, 
		                    internal_order_enabled_flag, so_transactions_flag, mtl_transactions_enabled_flag, stock_enabled_flag, item_catalog_group_id, 
		                    catalog_name, returnable_flag, default_shipping_org, collateral_flag, taxable_flag, qty_rcv_exception_code, 
		                    allow_item_desc_update_flag, inspection_required_flag, receipt_required_flag, market_price, qty_rcv_tolerance, 
		                    price_per_unit, asset_category_id, rounding_factor, last_lot_running, unit_weight, weight_uom_code, std_lot_size, 
		                    primary_uom_code, primary_unit_of_measure, inventory_item_status_code, min_minmax_quantity, max_minmax_quantity, 
		                    minimum_order_quantity, fixed_order_quantity, fixed_days_supply, maximum_order_quantity, vendor_warranty_flag, 
		                    warranty_vendor_id, max_warranty_amount, tax_code, invoice_enabled_flag, costing_enabled_flag, item_type, 
		                    maximum_load_weight, minimum_fill_percent, container_type_code, purchasing_tax_code, over_shipment_tolerance, 
		                    under_shipment_tolerance, over_return_tolerance, under_return_tolerance, dimension_uom_code, unit_length, 
		                    unit_width, unit_height, bulk_picked_flag, lot_status_enabled, default_lot_status_id, serial_status_enabled, 
		                    default_serial_status_id, lot_split_enabled, lot_merge_enabled, secondary_uom_code, dual_uom_deviation_high, 
		                    dual_uom_deviation_low, approval_status, item_status, cost_price_per_unit, last_update_lot
                            FROM mtl_system_items 
                            ORDER BY segment1";

            return db.Read(sql, Make).ToList();
        }

        public ItemMasterModel GetByID(int id)
        {
            string sql = @"SELECT inventory_item_id, organization_id, last_update_date, last_updated_by, creation_date, created_by, 
		                    summary_flag, enabled_flag, start_date_active, end_date_active, item_description, buyer_id, 
		                    segment1, segment2, segment3, segment4, segment5, attribute1, attribute2, attribute3, attribute4, attribute5, 
		                    purchasing_item_flag, shippable_item_flag, customer_order_flag, internal_order_flag, service_item_flag, 
		                    inventory_item_flag, eng_item_flag, inventory_asset_flag, purchasing_enabled_flag, customer_order_enabled_flag, 
		                    internal_order_enabled_flag, so_transactions_flag, mtl_transactions_enabled_flag, stock_enabled_flag, item_catalog_group_id, 
		                    catalog_name, returnable_flag, default_shipping_org, collateral_flag, taxable_flag, qty_rcv_exception_code, 
		                    allow_item_desc_update_flag, inspection_required_flag, receipt_required_flag, market_price, qty_rcv_tolerance, 
		                    price_per_unit, asset_category_id, rounding_factor, last_lot_running, unit_weight, weight_uom_code, std_lot_size, 
		                    primary_uom_code, primary_unit_of_measure, inventory_item_status_code, min_minmax_quantity, max_minmax_quantity, 
		                    minimum_order_quantity, fixed_order_quantity, fixed_days_supply, maximum_order_quantity, vendor_warranty_flag, 
		                    warranty_vendor_id, max_warranty_amount, tax_code, invoice_enabled_flag, costing_enabled_flag, item_type, 
		                    maximum_load_weight, minimum_fill_percent, container_type_code, purchasing_tax_code, over_shipment_tolerance, 
		                    under_shipment_tolerance, over_return_tolerance, under_return_tolerance, dimension_uom_code, unit_length, 
		                    unit_width, unit_height, bulk_picked_flag, lot_status_enabled, default_lot_status_id, serial_status_enabled, 
		                    default_serial_status_id, lot_split_enabled, lot_merge_enabled, secondary_uom_code, dual_uom_deviation_high, 
		                    dual_uom_deviation_low, approval_status, item_status, cost_price_per_unit, last_update_lot
                            FROM mtl_system_items
                            WHERE inventory_item_id = @inventory_item_id";

            object[] parms = { "@inventory_item_id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public ItemMasterModel GetByNumber(string number)
        {
            string sql = @"SELECT inventory_item_id, organization_id, last_update_date, last_updated_by, creation_date, created_by, 
		                    summary_flag, enabled_flag, start_date_active, end_date_active, item_description, buyer_id, 
		                    segment1, segment2, segment3, segment4, segment5, attribute1, attribute2, attribute3, attribute4, attribute5, 
		                    purchasing_item_flag, shippable_item_flag, customer_order_flag, internal_order_flag, service_item_flag, 
		                    inventory_item_flag, eng_item_flag, inventory_asset_flag, purchasing_enabled_flag, customer_order_enabled_flag, 
		                    internal_order_enabled_flag, so_transactions_flag, mtl_transactions_enabled_flag, stock_enabled_flag, item_catalog_group_id, 
		                    catalog_name, returnable_flag, default_shipping_org, collateral_flag, taxable_flag, qty_rcv_exception_code, 
		                    allow_item_desc_update_flag, inspection_required_flag, receipt_required_flag, market_price, qty_rcv_tolerance, 
		                    price_per_unit, asset_category_id, rounding_factor, last_lot_running, unit_weight, weight_uom_code, std_lot_size, 
		                    primary_uom_code, primary_unit_of_measure, inventory_item_status_code, min_minmax_quantity, max_minmax_quantity, 
		                    minimum_order_quantity, fixed_order_quantity, fixed_days_supply, maximum_order_quantity, vendor_warranty_flag, 
		                    warranty_vendor_id, max_warranty_amount, tax_code, invoice_enabled_flag, costing_enabled_flag, item_type, 
		                    maximum_load_weight, minimum_fill_percent, container_type_code, purchasing_tax_code, over_shipment_tolerance, 
		                    under_shipment_tolerance, over_return_tolerance, under_return_tolerance, dimension_uom_code, unit_length, 
		                    unit_width, unit_height, bulk_picked_flag, lot_status_enabled, default_lot_status_id, serial_status_enabled, 
		                    default_serial_status_id, lot_split_enabled, lot_merge_enabled, secondary_uom_code, dual_uom_deviation_high, 
		                    dual_uom_deviation_low, approval_status, item_status, cost_price_per_unit, last_update_lot
                            FROM mtl_system_items
                            WHERE segment1 = @segment1";

            object[] parms = { "@segment1", number };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public ItemMasterModel GetByManuID(string manuId)
        {
            string sql = @"SELECT inventory_item_id, organization_id, last_update_date, last_updated_by, creation_date, created_by, 
		                    summary_flag, enabled_flag, start_date_active, end_date_active, item_description, buyer_id, 
		                    segment1, segment2, segment3, segment4, segment5, attribute1, attribute2, attribute3, attribute4, attribute5, 
		                    purchasing_item_flag, shippable_item_flag, customer_order_flag, internal_order_flag, service_item_flag, 
		                    inventory_item_flag, eng_item_flag, inventory_asset_flag, purchasing_enabled_flag, customer_order_enabled_flag, 
		                    internal_order_enabled_flag, so_transactions_flag, mtl_transactions_enabled_flag, stock_enabled_flag, item_catalog_group_id, 
		                    catalog_name, returnable_flag, default_shipping_org, collateral_flag, taxable_flag, qty_rcv_exception_code, 
		                    allow_item_desc_update_flag, inspection_required_flag, receipt_required_flag, market_price, qty_rcv_tolerance, 
		                    price_per_unit, asset_category_id, rounding_factor, last_lot_running, unit_weight, weight_uom_code, std_lot_size, 
		                    primary_uom_code, primary_unit_of_measure, inventory_item_status_code, min_minmax_quantity, max_minmax_quantity, 
		                    minimum_order_quantity, fixed_order_quantity, fixed_days_supply, maximum_order_quantity, vendor_warranty_flag, 
		                    warranty_vendor_id, max_warranty_amount, tax_code, invoice_enabled_flag, costing_enabled_flag, item_type, 
		                    maximum_load_weight, minimum_fill_percent, container_type_code, purchasing_tax_code, over_shipment_tolerance, 
		                    under_shipment_tolerance, over_return_tolerance, under_return_tolerance, dimension_uom_code, unit_length, 
		                    unit_width, unit_height, bulk_picked_flag, lot_status_enabled, default_lot_status_id, serial_status_enabled, 
		                    default_serial_status_id, lot_split_enabled, lot_merge_enabled, secondary_uom_code, dual_uom_deviation_high, 
		                    dual_uom_deviation_low, approval_status, item_status, cost_price_per_unit, last_update_lot
                            FROM mtl_system_items
                            WHERE segment2 = @segment2";

            object[] parms = { "@segment2", manuId };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(ItemMasterModel model)
        {
            /*string sql =
                    @"INSERT INTO mtl_system_items
		                    (inventory_item_id, organization_id, last_update_date, last_updated_by, creation_date, created_by, 
		                    summary_flag, enabled_flag, start_date_active, end_date_active, item_description, buyer_id, 
		                    segment1, segment2, segment3, segment4, segment5, attribute1, attribute2, attribute3, attribute4, attribute5, 
		                    purchasing_item_flag, shippable_item_flag, customer_order_flag, internal_order_flag, service_item_flag, 
		                    inventory_item_flag, eng_item_flag, inventory_asset_flag, purchasing_enabled_flag, customer_order_enabled_flag, 
		                    internal_order_enabled_flag, so_transactions_flag, mtl_transactions_enabled_flag, stock_enabled_flag, item_catalog_group_id, 
		                    catalog_name, returnable_flag, default_shipping_org, collateral_flag, taxable_flag, qty_rcv_exception_code, 
		                    allow_item_desc_update_flag, inspection_required_flag, receipt_required_flag, market_price, qty_rcv_tolerance, 
		                    price_per_unit, asset_category_id, rounding_factor, last_lot_running, unit_weight, weight_uom_code, std_lot_size, 
		                    primary_uom_code, primary_unit_of_measure, inventory_item_status_code, min_minmax_quantity, max_minmax_quantity, 
		                    minimum_order_quantity, fixed_order_quantity, fixed_days_supply, maximum_order_quantity, vendor_warranty_flag, 
		                    warranty_vendor_id, max_warranty_amount, tax_code, invoice_enabled_flag, costing_enabled_flag, item_type, 
		                    maximum_load_weight, minimum_fill_percent, container_type_code, purchasing_tax_code, over_shipment_tolerance, 
		                    under_shipment_tolerance, over_return_tolerance, under_return_tolerance, dimension_uom_code, unit_length, 
		                    unit_width, unit_height, bulk_picked_flag, lot_status_enabled, default_lot_status_id, serial_status_enabled, 
		                    default_serial_status_id, lot_split_enabled, lot_merge_enabled, secondary_uom_code, dual_uom_deviation_high, 
		                    dual_uom_deviation_low, approval_status, item_status, cost_price_per_unit)
		              VALUES
		                    (@inventory_item_id, @organization_id, @last_update_date, @last_updated_by, @creation_date, @created_by, 
		                    @summary_flag, @enabled_flag, @start_date_active, @end_date_active, @item_description, @buyer_id, 
		                    @segment1, @segment2, @segment3, @segment4, @segment5, @attribute1, @attribute2, @attribute3, @attribute4, @attribute5, 
		                    @purchasing_item_flag, @shippable_item_flag, @customer_order_flag, @internal_order_flag, @service_item_flag, 
		                    @inventory_item_flag, @eng_item_flag, @inventory_asset_flag, @purchasing_enabled_flag, @customer_order_enabled_flag, 
		                    @internal_order_enabled_flag, @so_transactions_flag, @mtl_transactions_enabled_flag, @stock_enabled_flag, @item_catalog_group_id, 
		                    @catalog_name, @returnable_flag, @default_shipping_org, @collateral_flag, @taxable_flag, @qty_rcv_exception_code, 
		                    @allow_item_desc_update_flag, @inspection_required_flag, @receipt_required_flag, @market_price, @qty_rcv_tolerance, 
		                    @price_per_unit, @asset_category_id, @rounding_factor, @last_lot_running, @unit_weight, @weight_uom_code, @std_lot_size, 
		                    @primary_uom_code, @primary_unit_of_measure, @inventory_item_status_code, @min_minmax_quantity, @max_minmax_quantity, 
		                    @minimum_order_quantity, @fixed_order_quantity, @fixed_days_supply, @maximum_order_quantity, @vendor_warranty_flag, 
		                    @warranty_vendor_id, @max_warranty_amount, @tax_code, @invoice_enabled_flag, @costing_enabled_flag, @item_type, 
		                    @maximum_load_weight, @minimum_fill_percent, @container_type_code, @purchasing_tax_code, @over_shipment_tolerance, 
		                    @under_shipment_tolerance, @over_return_tolerance, @under_return_tolerance, @dimension_uom_code, @unit_length, 
		                    @unit_width, @unit_height, @bulk_picked_flag, @lot_status_enabled, @default_lot_status_id, @serial_status_enabled, 
		                    @default_serial_status_id, @lot_split_enabled, @lot_merge_enabled, @secondary_uom_code, @dual_uom_deviation_high, 
		                    @dual_uom_deviation_low, @approval_status, @item_status, @cost_price_per_unit)";*/

            string sql =
                    @"INSERT INTO mtl_system_items
		                    (organization_id, last_update_date, last_updated_by, creation_date, created_by, 
		                    summary_flag, enabled_flag, start_date_active, end_date_active, item_description, buyer_id, 
		                    segment1, segment2, segment3, segment4, segment5, attribute1, attribute2, attribute3, attribute4, attribute5, 
		                    purchasing_item_flag, shippable_item_flag, customer_order_flag, internal_order_flag, service_item_flag, 
		                    inventory_item_flag, eng_item_flag, inventory_asset_flag, purchasing_enabled_flag, customer_order_enabled_flag, 
		                    internal_order_enabled_flag, so_transactions_flag, mtl_transactions_enabled_flag, stock_enabled_flag, item_catalog_group_id, 
		                    catalog_name, returnable_flag, default_shipping_org, collateral_flag, taxable_flag, qty_rcv_exception_code, 
		                    allow_item_desc_update_flag, inspection_required_flag, receipt_required_flag, market_price, qty_rcv_tolerance, 
		                    price_per_unit, asset_category_id, rounding_factor, last_lot_running, unit_weight, weight_uom_code, std_lot_size, 
		                    primary_uom_code, primary_unit_of_measure, inventory_item_status_code, min_minmax_quantity, max_minmax_quantity, 
		                    minimum_order_quantity, fixed_order_quantity, fixed_days_supply, maximum_order_quantity, vendor_warranty_flag, 
		                    warranty_vendor_id, max_warranty_amount, tax_code, invoice_enabled_flag, costing_enabled_flag, item_type, 
		                    maximum_load_weight, minimum_fill_percent, container_type_code, purchasing_tax_code, over_shipment_tolerance, 
		                    under_shipment_tolerance, over_return_tolerance, under_return_tolerance, dimension_uom_code, unit_length, 
		                    unit_width, unit_height, bulk_picked_flag, lot_status_enabled, default_lot_status_id, serial_status_enabled, 
		                    default_serial_status_id, lot_split_enabled, lot_merge_enabled, secondary_uom_code, dual_uom_deviation_high, 
		                    dual_uom_deviation_low, approval_status, item_status, cost_price_per_unit, last_update_lot)
		              VALUES
		                    (@organization_id, @last_update_date, @last_updated_by, @creation_date, @created_by, 
		                    @summary_flag, @enabled_flag, @start_date_active, @end_date_active, @item_description, @buyer_id, 
		                    @segment1, @segment2, @segment3, @segment4, @segment5, @attribute1, @attribute2, @attribute3, @attribute4, @attribute5, 
		                    @purchasing_item_flag, @shippable_item_flag, @customer_order_flag, @internal_order_flag, @service_item_flag, 
		                    @inventory_item_flag, @eng_item_flag, @inventory_asset_flag, @purchasing_enabled_flag, @customer_order_enabled_flag, 
		                    @internal_order_enabled_flag, @so_transactions_flag, @mtl_transactions_enabled_flag, @stock_enabled_flag, @item_catalog_group_id, 
		                    @catalog_name, @returnable_flag, @default_shipping_org, @collateral_flag, @taxable_flag, @qty_rcv_exception_code, 
		                    @allow_item_desc_update_flag, @inspection_required_flag, @receipt_required_flag, @market_price, @qty_rcv_tolerance, 
		                    @price_per_unit, @asset_category_id, @rounding_factor, @last_lot_running, @unit_weight, @weight_uom_code, @std_lot_size, 
		                    @primary_uom_code, @primary_unit_of_measure, @inventory_item_status_code, @min_minmax_quantity, @max_minmax_quantity, 
		                    @minimum_order_quantity, @fixed_order_quantity, @fixed_days_supply, @maximum_order_quantity, @vendor_warranty_flag, 
		                    @warranty_vendor_id, @max_warranty_amount, @tax_code, @invoice_enabled_flag, @costing_enabled_flag, @item_type, 
		                    @maximum_load_weight, @minimum_fill_percent, @container_type_code, @purchasing_tax_code, @over_shipment_tolerance, 
		                    @under_shipment_tolerance, @over_return_tolerance, @under_return_tolerance, @dimension_uom_code, @unit_length, 
		                    @unit_width, @unit_height, @bulk_picked_flag, @lot_status_enabled, @default_lot_status_id, @serial_status_enabled, 
		                    @default_serial_status_id, @lot_split_enabled, @lot_merge_enabled, @secondary_uom_code, @dual_uom_deviation_high, 
		                    @dual_uom_deviation_low, @approval_status, @item_status, @cost_price_per_unit, @last_update_lot)";

            return db.Insert(sql, Take(model));
        }
        

        public void Update(ItemMasterModel model)
        {
            string sql =
            @"UPDATE mtl_system_items
              SET   organization_id = @organization_id,
                    last_update_date = @last_update_date,
                    last_updated_by = @last_updated_by,
                    summary_flag = @summary_flag,
                    enabled_flag = @enabled_flag,
                    start_date_active = @start_date_active,
                    end_date_active = @end_date_active,
                    item_description = @item_description,
                    buyer_id = @buyer_id,
                    segment1 = @segment1,
                    segment2 = @segment2,
                    segment3 = @segment3,
                    segment4 = @segment4,
                    segment5 = @segment5,
                    attribute1 = @attribute1,
                    attribute2 = @attribute2,
                    attribute3 = @attribute3,
                    attribute4 = @attribute4,
                    attribute5 = @attribute5,
                    purchasing_item_flag = @purchasing_item_flag,
                    shippable_item_flag = @shippable_item_flag,
                    customer_order_flag = @customer_order_flag,
                    internal_order_flag = @internal_order_flag,
                    service_item_flag = @service_item_flag,
                    inventory_item_flag = @inventory_item_flag,
                    eng_item_flag = @eng_item_flag,
                    inventory_asset_flag = @inventory_asset_flag,
                    purchasing_enabled_flag = @purchasing_enabled_flag,
                    customer_order_enabled_flag = @customer_order_enabled_flag,
                    internal_order_enabled_flag = @internal_order_enabled_flag,
                    so_transactions_flag = @so_transactions_flag,
                    mtl_transactions_enabled_flag = @mtl_transactions_enabled_flag,
                    stock_enabled_flag = @stock_enabled_flag,
                    item_catalog_group_id = @item_catalog_group_id,
                    catalog_name = @catalog_name,
                    returnable_flag = @returnable_flag,
                    default_shipping_org = @default_shipping_org,
                    collateral_flag = @collateral_flag,
                    taxable_flag = @taxable_flag,
                    qty_rcv_exception_code = @qty_rcv_exception_code,
                    allow_item_desc_update_flag = @allow_item_desc_update_flag,
                    inspection_required_flag = @inspection_required_flag,
                    receipt_required_flag = @receipt_required_flag,
                    market_price = @market_price,
                    qty_rcv_tolerance = @qty_rcv_tolerance,
                    price_per_unit = @price_per_unit,
                    asset_category_id = @asset_category_id,
                    rounding_factor = @rounding_factor,
                    last_lot_running = @last_lot_running,
                    unit_weight = @unit_weight,
                    weight_uom_code = @weight_uom_code,
                    std_lot_size = @std_lot_size,
                    primary_uom_code = @primary_uom_code,
                    primary_unit_of_measure = @primary_unit_of_measure,
                    inventory_item_status_code = @inventory_item_status_code,
                    min_minmax_quantity = @min_minmax_quantity,
                    max_minmax_quantity = @max_minmax_quantity,
                    minimum_order_quantity = @minimum_order_quantity,
                    fixed_order_quantity = @fixed_order_quantity,
                    fixed_days_supply = @fixed_days_supply,
                    maximum_order_quantity = @maximum_order_quantity,
                    vendor_warranty_flag = @vendor_warranty_flag,
                    warranty_vendor_id = @warranty_vendor_id,
                    max_warranty_amount = @max_warranty_amount,
                    tax_code = @tax_code,
                    invoice_enabled_flag = @invoice_enabled_flag,
                    costing_enabled_flag = @costing_enabled_flag,
                    item_type = @item_type,
                    maximum_load_weight = @maximum_load_weight,
                    minimum_fill_percent = @minimum_fill_percent,
                    container_type_code = @container_type_code,
                    purchasing_tax_code = @purchasing_tax_code,
                    over_shipment_tolerance = @over_shipment_tolerance,
                    under_shipment_tolerance = @under_shipment_tolerance,
                    over_return_tolerance = @over_return_tolerance,
                    under_return_tolerance = @under_return_tolerance,
                    dimension_uom_code = @dimension_uom_code,
                    unit_length = @unit_length,
                    unit_width = @unit_width,
                    unit_height = @unit_height,
                    bulk_picked_flag = @bulk_picked_flag,
                    lot_status_enabled = @lot_status_enabled,
                    default_lot_status_id = @default_lot_status_id,
                    serial_status_enabled = @serial_status_enabled,
                    default_serial_status_id = @default_serial_status_id,
                    lot_split_enabled = @lot_split_enabled,
                    lot_merge_enabled = @lot_merge_enabled,
                    secondary_uom_code = @secondary_uom_code,
                    dual_uom_deviation_high = @dual_uom_deviation_high,
                    dual_uom_deviation_low = @dual_uom_deviation_low,
                    approval_status = @approval_status,
                    item_status = @item_status,
                    cost_price_per_unit = @cost_price_per_unit,
                    last_update_lot = @last_update_lot
                WHERE inventory_item_id = @inventory_item_id";

            db.Update(sql, Take(model));
        }

        public void Delete(ItemMasterModel model)
        {
            string sql =
            @"DELETE FROM mtl_system_items
               WHERE inventory_item_id = @inventory_item_id";

            object[] parms = { "@inventory_item_id", model.InventoryItemId };
            db.Update(sql, parms);
        }

        // creates a Members object with order statistics based on DataReader       
        //private static Func<IDataReader, ItemMasterModel> MakeWithStats = reader =>
        //{
        //    var row = Make(reader);
        //    row.VendorName = reader["vendor_name"].AsString();
        //    row.TermDesc = reader["description"].AsString();
        //    row.BuyerName = reader["USER_NAME"].AsString();
        //    return row;
        //};

        // creates a Member object based on DataReader
        private static Func<IDataReader, ItemMasterModel> Make = reader =>
             new ItemMasterModel
             {
                 InventoryItemId = reader["inventory_item_id"].AsInt(),
                 OrganizationId = reader["organization_id"].AsInt(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 SummaryFlag = (reader["summary_flag"].AsString() == "Y") ? true : false,
                 EnabledFlag = (reader["enabled_flag"].AsString() == "Y") ? true : false,
                 StartDateActive = (reader["start_date_active"] != DBNull.Value) ? reader["start_date_active"].AsDateTime() : (DateTime?)null,
                 EndDateActive = (reader["end_date_active"] != DBNull.Value) ? reader["start_date_active"].AsDateTime() : (DateTime?)null,
                 Description = reader["item_description"].AsString(),
                 BuyerId = reader["buyer_id"].AsInt(),
                 Segment1 = reader["segment1"].AsString(),
                 Segment2 = reader["segment2"].AsString(),
                 Segment3 = reader["segment3"].AsString(),
                 Segment4 = reader["segment4"].AsString(),
                 Segment5 = reader["segment5"].AsString(),
                 Attribute1 = reader["attribute1"].AsString(),
                 Attribute2 = reader["attribute2"].AsString(),
                 Attribute3 = reader["attribute3"].AsString(),
                 Attribute4 = reader["attribute4"].AsString(),
                 Attribute5 = reader["attribute5"].AsString(),
                 PurchasingItemFlag = (reader["purchasing_item_flag"].AsString() == "Y") ? true : false,
                 ShippableItemFlag = (reader["shippable_item_flag"].AsString() == "Y") ? true : false,
                 CustomerOrderFlag = (reader["customer_order_flag"].AsString() == "Y") ? true : false,
                 InternalOrderFlag = (reader["internal_order_flag"].AsString() == "Y") ? true : false,
                 ServiceItemFlag = (reader["service_item_flag"].AsString() == "Y") ? true : false,
                 InventoryItemFlag = (reader["inventory_item_flag"].AsString() == "Y") ? true : false,
                 EngItemFlag = (reader["eng_item_flag"].AsString() == "Y") ? true : false,
                 InventoryAssetFlag = (reader["inventory_asset_flag"].AsString() == "Y") ? true : false,
                 PurchasingEnabledFlag = (reader["purchasing_enabled_flag"].AsString() == "Y") ? true : false,
                 CustomerOrderEnabledFlag = (reader["customer_order_enabled_flag"].AsString() == "Y") ? true : false,
                 InternalOrderEnabledFlag = (reader["internal_order_enabled_flag"].AsString() == "Y") ? true : false,
                 SoTransactionsFlag = (reader["so_transactions_flag"].AsString() == "Y") ? true : false,
                 MtlTransactionsEnabledFlag = (reader["mtl_transactions_enabled_flag"].AsString() == "Y") ? true : false,
                 StockEnabledFlag = (reader["stock_enabled_flag"].AsString() == "Y") ? true : false,
                 ItemCatalogGroupId = reader["item_catalog_group_id"].AsInt(),
                 CatalogName = reader["catalog_name"].AsString(),
                 ReturnableFlag = (reader["returnable_flag"].AsString() == "Y") ? true : false,
                 DefaultShippingOrg = reader["default_shipping_org"].AsInt(),
                 CollateralFlag = (reader["collateral_flag"].AsString() == "Y") ? true : false,
                 TaxableFlag = (reader["taxable_flag"].AsString() == "Y") ? true : false,
                 QtyRcvExceptionCode = reader["qty_rcv_exception_code"].AsString(),
                 AllowItemDescUpdateFlag = (reader["allow_item_desc_update_flag"].AsString() == "Y") ? true : false,
                 InspectionRequiredFlag = (reader["inspection_required_flag"].AsString() == "Y") ? true : false,
                 ReceiptRequiredFlag = (reader["receipt_required_flag"].AsString() == "Y") ? true : false,
                 MarketPrice = reader["market_price"].AsDouble(),
                 QtyRcvTolerance = reader["qty_rcv_tolerance"].AsDouble(),
                 PricePerUnit = reader["price_per_unit"].AsDouble(),
                 AssetCategoryId = reader["asset_category_id"].AsInt(),
                 RoundingFactor = reader["rounding_factor"].AsInt(),
                 LastLotRunning = reader["last_lot_running"].AsInt(),
                 UnitWeight = reader["unit_weight"].AsDouble(),
                 WeightUomCode = reader["weight_uom_code"].AsString(),
                 StdLotSize = reader["std_lot_size"].AsDouble(),
                 PrimaryUomCode = reader["primary_uom_code"].AsString(),
                 PrimaryUnitOfMeasure = reader["primary_unit_of_measure"].AsString(),
                 InventoryItemStatusCode = reader["inventory_item_status_code"].AsString(),
                 MinMinmaxQuantity = reader["min_minmax_quantity"].AsDouble(),
                 MaxMinmaxQuantity = reader["max_minmax_quantity"].AsDouble(),
                 MinimumOrderQuantity = reader["minimum_order_quantity"].AsDouble(),
                 FixedOrderQuantity = reader["fixed_order_quantity"].AsInt(),
                 FixedDaysSupply = reader["fixed_days_supply"].AsDouble(),
                 MaximumOrderQuantity = reader["maximum_order_quantity"].AsDouble(),
                 VendorWarrantyFlag = (reader["vendor_warranty_flag"].AsString() == "Y") ? true : false,
                 WarrantyVendorId = reader["warranty_vendor_id"].AsInt(),
                 MaxWarrantyAmount = reader["max_warranty_amount"].AsDouble(),
                 TaxCode = reader["tax_code"].AsString(),
                 InvoiceEnabledFlag = (reader["invoice_enabled_flag"].AsString() == "Y") ? true : false,
                 CostingEnabledFlag = (reader["costing_enabled_flag"].AsString() == "Y") ? true : false,
                 CostPricePerUnit = reader["cost_price_per_unit"].AsDouble(),
                 ItemType = reader["item_type"].AsString(),
                 MaximumLoadWeight = reader["maximum_load_weight"].AsDouble(),
                 MinimumFillPercent = reader["minimum_fill_percent"].AsInt(),
                 ContainerTypeCode = reader["container_type_code"].AsString(),
                 PurchasingTaxCode = reader["purchasing_tax_code"].AsString(),
                 OverShipmentTolerance = reader["over_shipment_tolerance"].AsDouble(),
                 UnderShipmentTolerance = reader["under_shipment_tolerance"].AsDouble(),
                 OverReturnTolerance = reader["over_return_tolerance"].AsDouble(),
                 UnderReturnTolerance = reader["under_return_tolerance"].AsDouble(),
                 DimensionUomCode = reader["dimension_uom_code"].AsString(),
                 UnitLength = reader["unit_length"].AsDouble(),
                 UnitWidth = reader["unit_width"].AsDouble(),
                 UnitHeight = reader["unit_height"].AsDouble(),
                 BulkPickedFlag = (reader["bulk_picked_flag"].AsString() == "Y") ? true : false,
                 LotStatusEnabled = reader["lot_status_enabled"].AsString(),
                 DefaultLotStatusId = reader["default_lot_status_id"].AsInt(),
                 SerialStatusEnabled = reader["serial_status_enabled"].AsString(),
                 DefaultSerialStatusId = reader["default_serial_status_id"].AsInt(),
                 LotSplitEnabled = reader["lot_split_enabled"].AsString(),
                 LotMergeEnabled = reader["lot_merge_enabled"].AsString(),
                 SecondaryUomCode = reader["secondary_uom_code"].AsString(),
                 DualUomDeviationHigh = reader["dual_uom_deviation_high"].AsDouble(),
                 DualUomDeviationLow = reader["dual_uom_deviation_low"].AsDouble(),
                 ApprovalStatus = reader["approval_status"].AsString(),
                 Status = reader["item_status"].AsInt(),
                 LastUpdateLot = (reader["last_update_lot"] != DBNull.Value) ? reader["last_update_lot"].AsDateTime() : (DateTime?)null
             };

        private object[] Take(ItemMasterModel model)
        {
            return new object[]
            {
                "@inventory_item_id", model.InventoryItemId,
                "@organization_id", model.OrganizationId,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@summary_flag", (model.SummaryFlag) ? "Y" : "N",
                "@enabled_flag", (model.EnabledFlag) ? "Y" : "N",
                "@start_date_active", model.StartDateActive,
                "@end_date_active", model.EndDateActive,
                "@item_description", model.Description,
                "@buyer_id", model.BuyerId,
                "@segment1", model.Segment1,
                "@segment2", model.Segment2,
                "@segment3", model.Segment3,
                "@segment4", model.Segment4,
                "@segment5", model.Segment5,
                "@attribute1", model.Attribute1,
                "@attribute2", model.Attribute2,
                "@attribute3", model.Attribute3,
                "@attribute4", model.Attribute4,
                "@attribute5", model.Attribute5,
                "@purchasing_item_flag", (model.PurchasingItemFlag) ? "Y" : "N",
                "@shippable_item_flag", (model.ShippableItemFlag) ? "Y" : "N",
                "@customer_order_flag", (model.CustomerOrderFlag) ? "Y" : "N",
                "@internal_order_flag", (model.InternalOrderFlag) ? "Y" : "N",
                "@service_item_flag", (model.ServiceItemFlag) ? "Y" : "N",
                "@inventory_item_flag", (model.InventoryItemFlag) ? "Y" : "N",
                "@eng_item_flag", (model.EngItemFlag) ? "Y" : "N",
                "@inventory_asset_flag", (model.InventoryAssetFlag) ? "Y" : "N",
                "@purchasing_enabled_flag", (model.PurchasingEnabledFlag) ? "Y" : "N",
                "@customer_order_enabled_flag", (model.CustomerOrderEnabledFlag) ? "Y" : "N",
                "@internal_order_enabled_flag", (model.InternalOrderEnabledFlag) ? "Y" : "N",
                "@so_transactions_flag", (model.SoTransactionsFlag) ? "Y" : "N",
                "@mtl_transactions_enabled_flag", (model.MtlTransactionsEnabledFlag) ? "Y" : "N",
                "@stock_enabled_flag", (model.StockEnabledFlag) ? "Y" : "N",
                "@item_catalog_group_id", model.ItemCatalogGroupId,
                "@catalog_name", model.CatalogName,
                "@returnable_flag", model.ReturnableFlag,
                "@default_shipping_org", model.DefaultShippingOrg,
                "@collateral_flag", model.CollateralFlag,
                "@taxable_flag", model.TaxableFlag,
                "@qty_rcv_exception_code", model.QtyRcvExceptionCode,
                "@allow_item_desc_update_flag", (model.AllowItemDescUpdateFlag) ? "Y" : "N",
                "@inspection_required_flag", (model.InspectionRequiredFlag) ? "Y" : "N",
                "@receipt_required_flag", (model.ReceiptRequiredFlag) ? "Y" : "N",
                "@market_price", model.MarketPrice,
                "@qty_rcv_tolerance", model.QtyRcvTolerance,
                "@price_per_unit", model.PricePerUnit,
                "@asset_category_id", model.AssetCategoryId,
                "@rounding_factor", model.RoundingFactor,
                "@last_lot_running", model.LastLotRunning,
                "@unit_weight", model.UnitWeight,
                "@weight_uom_code", model.WeightUomCode,
                "@std_lot_size", model.StdLotSize,
                "@primary_uom_code", model.PrimaryUomCode,
                "@primary_unit_of_measure", model.PrimaryUnitOfMeasure,
                "@inventory_item_status_code", model.InventoryItemStatusCode,
                "@min_minmax_quantity", model.MinMinmaxQuantity,
                "@max_minmax_quantity", model.MaxMinmaxQuantity,
                "@minimum_order_quantity", model.MinimumOrderQuantity,
                "@fixed_order_quantity", model.FixedOrderQuantity,
                "@fixed_days_supply", model.FixedDaysSupply,
                "@maximum_order_quantity", model.MaximumOrderQuantity,
                "@vendor_warranty_flag", (model.VendorWarrantyFlag) ? "Y" : "N",
                "@warranty_vendor_id", model.WarrantyVendorId,
                "@max_warranty_amount", model.MaxWarrantyAmount,
                "@tax_code", model.TaxCode,
                "@invoice_enabled_flag", (model.InvoiceEnabledFlag) ? "Y" : "N",
                "@costing_enabled_flag", (model.CostingEnabledFlag) ? "Y" : "N",
                "@cost_price_per_unit", model.CostPricePerUnit,
                "@item_type", model.ItemType,
                "@maximum_load_weight", model.MaximumLoadWeight,
                "@minimum_fill_percent", model.MinimumFillPercent,
                "@container_type_code", model.ContainerTypeCode,
                "@purchasing_tax_code", model.PurchasingTaxCode,
                "@over_shipment_tolerance", model.OverShipmentTolerance,
                "@under_shipment_tolerance", model.UnderShipmentTolerance,
                "@over_return_tolerance", model.OverReturnTolerance,
                "@under_return_tolerance", model.UnderReturnTolerance,
                "@dimension_uom_code", model.DimensionUomCode,
                "@unit_length", model.UnitLength,
                "@unit_width", model.UnitWidth,
                "@unit_height", model.UnitHeight,
                "@bulk_picked_flag", (model.BulkPickedFlag) ? "Y" : "N",
                "@lot_status_enabled", model.LotStatusEnabled,
                "@default_lot_status_id", model.DefaultLotStatusId,
                "@serial_status_enabled", model.SerialStatusEnabled,
                "@default_serial_status_id", model.DefaultSerialStatusId,
                "@lot_split_enabled", model.LotSplitEnabled,
                "@lot_merge_enabled", model.LotMergeEnabled,
                "@secondary_uom_code", model.SecondaryUomCode,
                "@dual_uom_deviation_high", model.DualUomDeviationHigh,
                "@dual_uom_deviation_low", model.DualUomDeviationLow,
                "@approval_status", model.ApprovalStatus,
                "@item_status", model.Status,
                "@last_update_lot", model.LastUpdateLot
            };
        }


    }
}
