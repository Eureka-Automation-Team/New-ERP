using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Inventory;

namespace Eureka.Data.AdoNet.Inventory
{
    public class ItemTransactionDao : IItemTransactionDao
    {
        private static Db db = new Db("ms_sql");

        public List<ItemTransactionModel> GetAll()
        {
            string sql = @"select trx.transaction_id, trx.last_update_date, trx.last_updated_by,
                                trx.creation_date, trx.created_by, trx.last_update_login,
                                trx.request_id, trx.inventory_item_id, trx.revision,
                                trx.organization_id, trx.subinventory_code, trx.locator_id,
                                trx.transaction_type_id, trx.transaction_source_type_id, trx.transaction_source_id,
                                trx.transaction_source_name, trx.transaction_quantity, trx.transaction_uom,
                                trx.primary_quantity, trx.transaction_date, trx.transaction_reference,
                                trx.reason_id, trx.costed_flag, trx.actual_cost,
                                trx.transaction_cost, trx.new_cost, trx.currency_code,
                                trx.currency_conversion_rate, trx.currency_conversion_type, trx.currency_conversion_date,
                                trx.quantity_adjusted, trx.employee_code, trx.trx_source_line_id,
                                trx.trx_source_delivery_id, trx.cycle_count_id, trx.transfer_transaction_id,
                                trx.transaction_set_id, trx.rcv_transaction_id, trx.move_transaction_id,
                                trx.vendor_lot_number, trx.transfer_organization_id, trx.transfer_subinventory,
                                trx.transfer_locator_id, trx.shipment_number, trx.attribute1,
                                trx.attribute2, trx.attribute3, trx.attribute4,
                                trx.attribute5, trx.movement_id, trx.task_id,
                                trx.to_task_id, trx.secondary_uom_code, trx.secondary_transaction_quantity,
                                trx.catalog_item_id, trx.remarks
                            from mtl_material_transactions trx
                            order by trx.transaction_date desc";

            return db.Read(sql, Make).ToList();
        }

        public List<ItemTransactionModel> GetByDate(DateTime startDate, DateTime endDate)
        {
            string sql = @"select trx.transaction_id, trx.last_update_date, trx.last_updated_by,
                                trx.creation_date, trx.created_by, trx.last_update_login,
                                trx.request_id, trx.inventory_item_id, trx.revision,
                                trx.organization_id, trx.subinventory_code, trx.locator_id,
                                trx.transaction_type_id, trx.transaction_source_type_id, trx.transaction_source_id,
                                trx.transaction_source_name, trx.transaction_quantity, trx.transaction_uom,
                                trx.primary_quantity, trx.transaction_date, trx.transaction_reference,
                                trx.reason_id, trx.costed_flag, trx.actual_cost,
                                trx.transaction_cost, trx.new_cost, trx.currency_code,
                                trx.currency_conversion_rate, trx.currency_conversion_type, trx.currency_conversion_date,
                                trx.quantity_adjusted, trx.employee_code, trx.trx_source_line_id,
                                trx.trx_source_delivery_id, trx.cycle_count_id, trx.transfer_transaction_id,
                                trx.transaction_set_id, trx.rcv_transaction_id, trx.move_transaction_id,
                                trx.vendor_lot_number, trx.transfer_organization_id, trx.transfer_subinventory,
                                trx.transfer_locator_id, trx.shipment_number, trx.attribute1,
                                trx.attribute2, trx.attribute3, trx.attribute4,
                                trx.attribute5, trx.movement_id, trx.task_id,
                                trx.to_task_id, trx.secondary_uom_code, trx.secondary_transaction_quantity,
                                trx.catalog_item_id, trx.remarks
                            from mtl_material_transactions trx
                            WHERE cast(trx.transaction_date as date) BETWEEN cast(@StartDate as date) AND cast(@EndDate as date)
                            ORDER BY trx.transaction_date ASC";

            object[] parms = { "@StartDate", startDate, "@EndDate", endDate };
            return db.Read(sql, Make, parms).ToList();
        }

        public ItemTransactionModel GetByID(int id)
        {
            string sql = @"select trx.transaction_id, trx.last_update_date, trx.last_updated_by,
                                trx.creation_date, trx.created_by, trx.last_update_login,
                                trx.request_id, trx.inventory_item_id, trx.revision,
                                trx.organization_id, trx.subinventory_code, trx.locator_id,
                                trx.transaction_type_id, trx.transaction_source_type_id, trx.transaction_source_id,
                                trx.transaction_source_name, trx.transaction_quantity, trx.transaction_uom,
                                trx.primary_quantity, trx.transaction_date, trx.transaction_reference,
                                trx.reason_id, trx.costed_flag, trx.actual_cost,
                                trx.transaction_cost, trx.new_cost, trx.currency_code,
                                trx.currency_conversion_rate, trx.currency_conversion_type, trx.currency_conversion_date,
                                trx.quantity_adjusted, trx.employee_code, trx.trx_source_line_id,
                                trx.trx_source_delivery_id, trx.cycle_count_id, trx.transfer_transaction_id,
                                trx.transaction_set_id, trx.rcv_transaction_id, trx.move_transaction_id,
                                trx.vendor_lot_number, trx.transfer_organization_id, trx.transfer_subinventory,
                                trx.transfer_locator_id, trx.shipment_number, trx.attribute1,
                                trx.attribute2, trx.attribute3, trx.attribute4,
                                trx.attribute5, trx.movement_id, trx.task_id,
                                trx.to_task_id, trx.secondary_uom_code, trx.secondary_transaction_quantity,
                                trx.catalog_item_id, trx.remarks
                            from mtl_material_transactions trx
                            where trx.transaction_id = @transaction_id";

            object[] parms = { "@transaction_id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public List<ItemTransactionModel> GetItemID(int id)
        {
            string sql = @"select trx.transaction_id, trx.last_update_date, trx.last_updated_by,
                                trx.creation_date, trx.created_by, trx.last_update_login,
                                trx.request_id, trx.inventory_item_id, trx.revision,
                                trx.organization_id, trx.subinventory_code, trx.locator_id,
                                trx.transaction_type_id, trx.transaction_source_type_id, trx.transaction_source_id,
                                trx.transaction_source_name, trx.transaction_quantity, trx.transaction_uom,
                                trx.primary_quantity, trx.transaction_date, trx.transaction_reference,
                                trx.reason_id, trx.costed_flag, trx.actual_cost,
                                trx.transaction_cost, trx.new_cost, trx.currency_code,
                                trx.currency_conversion_rate, trx.currency_conversion_type, trx.currency_conversion_date,
                                trx.quantity_adjusted, trx.employee_code, trx.trx_source_line_id,
                                trx.trx_source_delivery_id, trx.cycle_count_id, trx.transfer_transaction_id,
                                trx.transaction_set_id, trx.rcv_transaction_id, trx.move_transaction_id,
                                trx.vendor_lot_number, trx.transfer_organization_id, trx.transfer_subinventory,
                                trx.transfer_locator_id, trx.shipment_number, trx.attribute1,
                                trx.attribute2, trx.attribute3, trx.attribute4,
                                trx.attribute5, trx.movement_id, trx.task_id,
                                trx.to_task_id, trx.secondary_uom_code, trx.secondary_transaction_quantity,
                                trx.catalog_item_id, trx.remarks
                            from mtl_material_transactions trx
                            where trx.inventory_item_id = @inventory_item_id";

            object[] parms = { "@inventory_item_id", id };
            return db.Read(sql, Make, parms).ToList();
        }

        public List<ItemTransactionModel> GetByStartDate(DateTime trxDate)
        {
            string sql = @"select trx.transaction_id, trx.last_update_date, trx.last_updated_by,
                                trx.creation_date, trx.created_by, trx.last_update_login,
                                trx.request_id, trx.inventory_item_id, trx.revision,
                                trx.organization_id, trx.subinventory_code, trx.locator_id,
                                trx.transaction_type_id, trx.transaction_source_type_id, trx.transaction_source_id,
                                trx.transaction_source_name, (trx.transaction_quantity * -1) transaction_quantity, trx.transaction_uom,
                                trx.primary_quantity, trx.transaction_date, trx.transaction_reference,
                                trx.reason_id, trx.costed_flag, trx.actual_cost,
                                trx.transaction_cost, trx.new_cost, trx.currency_code,
                                trx.currency_conversion_rate, trx.currency_conversion_type, trx.currency_conversion_date,
                                trx.quantity_adjusted, trx.employee_code, trx.trx_source_line_id,
                                trx.trx_source_delivery_id, trx.cycle_count_id, trx.transfer_transaction_id,
                                trx.transaction_set_id, trx.rcv_transaction_id, trx.move_transaction_id,
                                trx.vendor_lot_number, trx.transfer_organization_id, trx.transfer_subinventory,
                                trx.transfer_locator_id, trx.shipment_number, trx.attribute1,
                                trx.attribute2, trx.attribute3, trx.attribute4,
                                trx.attribute5, trx.movement_id, trx.task_id,
                                trx.to_task_id, trx.secondary_uom_code, trx.secondary_transaction_quantity,
                                trx.catalog_item_id, trx.remarks,
                                mtl.segment1, mtl.segment2, mtl.segment3, mtl.item_description
                            from mtl_material_transactions trx
                            left join mtl_system_items mtl on(trx.inventory_item_id = mtl.inventory_item_id)
                            where cast(trx.transaction_date as date) >= cast(@StartDate as date)
                            and trx.transaction_source_name = 'MATERIAL ISSUE'
                            order by trx.transaction_date desc";

            object[] parms = { "@StartDate", trxDate };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public int Insert(ItemTransactionModel model)
        {
            string sql =
                @"insert into mtl_material_transactions
                       (last_update_date, last_updated_by,
                        creation_date, created_by, last_update_login,
                        request_id, inventory_item_id, revision,
                        organization_id, subinventory_code, locator_id,
                        transaction_type_id, transaction_source_type_id, transaction_source_id,
                        transaction_source_name, transaction_quantity, transaction_uom,
                        primary_quantity, transaction_date, transaction_reference,
                        reason_id, costed_flag, actual_cost,
                        transaction_cost, new_cost, currency_code,
                        currency_conversion_rate, currency_conversion_type, currency_conversion_date,
                        quantity_adjusted, employee_code, trx_source_line_id,
                        trx_source_delivery_id, cycle_count_id, transfer_transaction_id,
                        transaction_set_id, rcv_transaction_id, move_transaction_id,
                        vendor_lot_number, transfer_organization_id, transfer_subinventory,
                        transfer_locator_id, shipment_number, attribute1,
                        attribute2, attribute3, attribute4,
                        attribute5, movement_id, task_id,
                        to_task_id, secondary_uom_code, secondary_transaction_quantity,
                        catalog_item_id, remarks)
                    values
                       (@last_update_date,@last_updated_by,
                        @creation_date,@created_by,@last_update_login,
                        @request_id,@inventory_item_id,@revision,
                        @organization_id,@subinventory_code,@locator_id,
                        @transaction_type_id,@transaction_source_type_id,@transaction_source_id,
                        @transaction_source_name,@transaction_quantity,@transaction_uom,
                        @primary_quantity,@transaction_date,@transaction_reference,
                        @reason_id,@costed_flag,@actual_cost,
                        @transaction_cost,@new_cost,@currency_code,
                        @currency_conversion_rate,@currency_conversion_type,@currency_conversion_date,
                        @quantity_adjusted,@employee_code,@trx_source_line_id,
                        @trx_source_delivery_id,@cycle_count_id,@transfer_transaction_id,
                        @transaction_set_id,@rcv_transaction_id,@move_transaction_id,
                        @vendor_lot_number,@transfer_organization_id,@transfer_subinventory,
                        @transfer_locator_id,@shipment_number,@attribute1,
                        @attribute2,@attribute3,@attribute4,
                        @attribute5,@movement_id,@task_id,
                        @to_task_id,@secondary_uom_code,@secondary_transaction_quantity,
                        @catalog_item_id, @remarks)";

            return db.Insert(sql, Take(model));
        }

        public void Update(ItemTransactionModel model)
        {
            string sql =
            @"update mtl_material_transactions
              set   last_update_date	= @last_update_date,
                    last_updated_by	= @last_updated_by,
                    last_update_login	= @last_update_login,
                    request_id	= @request_id,
                    inventory_item_id	= @inventory_item_id,
                    revision	= @revision,
                    organization_id	= @organization_id,
                    subinventory_code	= @subinventory_code,
                    locator_id	= @locator_id,
                    transaction_type_id	= @transaction_type_id,
                    transaction_source_type_id	= @transaction_source_type_id,
                    transaction_source_id	= @transaction_source_id,
                    transaction_source_name	= @transaction_source_name,
                    transaction_quantity	= @transaction_quantity,
                    transaction_uom	= @transaction_uom,
                    primary_quantity	= @primary_quantity,
                    transaction_date	= @transaction_date,
                    transaction_reference	= @transaction_reference,
                    reason_id	= @reason_id,
                    costed_flag	= @costed_flag,
                    actual_cost	= @actual_cost,
                    transaction_cost	= @transaction_cost,
                    new_cost	= @new_cost,
                    currency_code	= @currency_code,
                    currency_conversion_rate	= @currency_conversion_rate,
                    currency_conversion_type	= @currency_conversion_type,
                    currency_conversion_date	= @currency_conversion_date,
                    quantity_adjusted	= @quantity_adjusted,
                    employee_code	= @employee_code,
                    trx_source_line_id	= @trx_source_line_id,
                    trx_source_delivery_id	= @trx_source_delivery_id,
                    cycle_count_id	= @cycle_count_id,
                    transfer_transaction_id	= @transfer_transaction_id,
                    transaction_set_id	= @transaction_set_id,
                    rcv_transaction_id	= @rcv_transaction_id,
                    move_transaction_id	= @move_transaction_id,
                    vendor_lot_number	= @vendor_lot_number,
                    transfer_organization_id	= @transfer_organization_id,
                    transfer_subinventory	= @transfer_subinventory,
                    transfer_locator_id	= @transfer_locator_id,
                    shipment_number	= @shipment_number,
                    attribute1	= @attribute1,
                    attribute2	= @attribute2,
                    attribute3	= @attribute3,
                    attribute4	= @attribute4,
                    attribute5	= @attribute5,
                    movement_id	= @movement_id,
                    task_id	= @task_id,
                    to_task_id	= @to_task_id,
                    secondary_uom_code	= @secondary_uom_code,
                    secondary_transaction_quantity	= @secondary_transaction_quantity,
                    catalog_item_id	= @catalog_item_id,
                    remarks = @remarks
                where transaction_id = @transaction_id";

            db.Update(sql, Take(model));
        }

        public void Delete(ItemTransactionModel model)
        {
            string sql =
            @"DELETE FROM mtl_material_transactions
               WHERE transaction_id = @transaction_id";

            object[] parms = { "@transaction_id", model.TransactionId };
            db.Update(sql, parms);
        }

        // creates a Members object with order statistics based on DataReader       
        private static Func<IDataReader, ItemTransactionModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            row.ItemCode = reader["segment1"].AsString();
            row.ManuID = reader["segment2"].AsString();
            row.BrandMat = reader["segment3"].AsString();
            row.ItemDescription = reader["item_description"].AsString();
            return row;
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, ItemTransactionModel> Make = reader =>
             new ItemTransactionModel
             {
                 TransactionId = reader["transaction_id"].AsInt(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 LastUpdateLogin = reader["last_update_login"].AsInt(),
                 RequestId = reader["request_id"].AsInt(),
                 InventoryItemId = reader["inventory_item_id"].AsInt(),
                 Revision = reader["revision"].AsString(),
                 OrganizationId = reader["organization_id"].AsInt(),
                 SubinventoryCode = reader["subinventory_code"].AsString(),
                 LocatorId = reader["locator_id"].AsInt(),
                 TransactionTypeId = reader["transaction_type_id"].AsInt(),
                 TransactionSourceTypeId = reader["transaction_source_type_id"].AsInt(),
                 TransactionSourceId = reader["transaction_source_id"].AsInt(),
                 TransactionSourceName = reader["transaction_source_name"].AsString(),
                 TransactionQuantity = reader["transaction_quantity"].AsDouble(),
                 TransactionUom = reader["transaction_uom"].AsString(),
                 PrimaryQuantity = reader["primary_quantity"].AsDouble(),
                 TransactionDate = reader["transaction_date"].AsDateTime(),
                 TransactionReference = reader["transaction_reference"].AsString(),
                 ReasonId = reader["reason_id"].AsInt(),
                 CostedFlag = reader["costed_flag"].AsString(),
                 ActualCost = reader["actual_cost"].AsDouble(),
                 TransactionCost = reader["transaction_cost"].AsDouble(),
                 NewCost = reader["new_cost"].AsDouble(),
                 CurrencyCode = reader["currency_code"].AsString(),
                 CurrencyConversionRate = reader["currency_conversion_rate"].AsDouble(),
                 CurrencyConversionType = reader["currency_conversion_type"].AsString(),
                 CurrencyConversionDate = (reader["currency_conversion_date"] != DBNull.Value) ? reader["due_date"].AsDateTime() : (DateTime?)null,
                 QuantityAdjusted = reader["quantity_adjusted"].AsDouble(),
                 EmployeeCode = reader["employee_code"].AsString(),
                 TrxSourceLineId = reader["trx_source_line_id"].AsInt(),
                 TrxSourceDeliveryId = reader["trx_source_delivery_id"].AsInt(),
                 CycleCountId = reader["cycle_count_id"].AsInt(),
                 TransferTransactionId = reader["transfer_transaction_id"].AsInt(),
                 TransactionSetId = reader["transaction_set_id"].AsInt(),
                 RcvTransactionId = reader["rcv_transaction_id"].AsInt(),
                 MoveTransactionId = reader["move_transaction_id"].AsInt(),
                 VendorLotNumber = reader["vendor_lot_number"].AsString(),
                 TransferOrganizationId = reader["transfer_organization_id"].AsInt(),
                 TransferSubinventory = reader["transfer_subinventory"].AsString(),
                 TransferLocatorId = reader["transfer_locator_id"].AsInt(),
                 ShipmentNumber = reader["shipment_number"].AsString(),
                 Attribute1 = reader["attribute1"].AsString(),
                 Attribute2 = reader["attribute2"].AsString(),
                 Attribute3 = reader["attribute3"].AsString(),
                 Attribute4 = reader["attribute4"].AsString(),
                 Attribute5 = reader["attribute5"].AsString(),
                 MovementId = reader["movement_id"].AsInt(),
                 TaskId = reader["task_id"].AsInt(),
                 ToTaskId = reader["to_task_id"].AsInt(),
                 SecondaryUomCode = reader["secondary_uom_code"].AsString(),
                 SecondaryTransactionQuantity = reader["secondary_transaction_quantity"].AsDouble(),
                 CatalogItemId = reader["catalog_item_id"].AsInt(),
                 Remarks = reader["remarks"].AsString()
             };

        private object[] Take(ItemTransactionModel model)
        {
            return new object[]
            {
                "@transaction_id", model.TransactionId,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@last_update_login", model.LastUpdateLogin,
                "@request_id", model.RequestId,
                "@inventory_item_id", model.InventoryItemId,
                "@revision", model.Revision,
                "@organization_id", model.OrganizationId,
                "@subinventory_code", model.SubinventoryCode,
                "@locator_id", model.LocatorId,
                "@transaction_type_id", model.TransactionTypeId,
                "@transaction_source_type_id", model.TransactionSourceTypeId,
                "@transaction_source_id", model.TransactionSourceId,
                "@transaction_source_name", model.TransactionSourceName,
                "@transaction_quantity", model.TransactionQuantity,
                "@transaction_uom", model.TransactionUom,
                "@primary_quantity", model.PrimaryQuantity,
                "@transaction_date", model.TransactionDate,
                "@transaction_reference", model.TransactionReference,
                "@reason_id", model.ReasonId,
                "@costed_flag", model.CostedFlag,
                "@actual_cost", model.ActualCost,
                "@transaction_cost", model.TransactionCost,
                "@new_cost", model.NewCost,
                "@currency_code", model.CurrencyCode,
                "@currency_conversion_rate", model.CurrencyConversionRate,
                "@currency_conversion_type", model.CurrencyConversionType,
                "@currency_conversion_date", model.CurrencyConversionDate,
                "@quantity_adjusted", model.QuantityAdjusted,
                "@employee_code", model.EmployeeCode,
                "@trx_source_line_id", model.TrxSourceLineId,
                "@trx_source_delivery_id", model.TrxSourceDeliveryId,
                "@cycle_count_id", model.CycleCountId,
                "@transfer_transaction_id", model.TransferTransactionId,
                "@transaction_set_id", model.TransactionSetId,
                "@rcv_transaction_id", model.RcvTransactionId,
                "@move_transaction_id", model.MoveTransactionId,
                "@vendor_lot_number", model.VendorLotNumber,
                "@transfer_organization_id", model.TransferOrganizationId,
                "@transfer_subinventory", model.TransferSubinventory,
                "@transfer_locator_id", model.TransferLocatorId,
                "@shipment_number", model.ShipmentNumber,
                "@attribute1", model.Attribute1,
                "@attribute2", model.Attribute2,
                "@attribute3", model.Attribute3,
                "@attribute4", model.Attribute4,
                "@attribute5", model.Attribute5,
                "@movement_id", model.MovementId,
                "@task_id", model.TaskId,
                "@to_task_id", model.ToTaskId,
                "@secondary_uom_code", model.SecondaryUomCode,
                "@secondary_transaction_quantity", model.SecondaryTransactionQuantity,
                "@catalog_item_id", model.CatalogItemId,
                "@remarks", model.Remarks
            };
        }
    }
}
