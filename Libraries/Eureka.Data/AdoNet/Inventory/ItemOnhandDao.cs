using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Inventory;

namespace Eureka.Data.AdoNet.Inventory
{
    public class ItemOnhandDao : IItemOnhandDao
    {
        private static Db db = new Db("ms_sql");

        public List<ItemOnhandModel> GetByItemID(string itemId)
        {
            string sql = @"select oh.onhand_quantities_id, oh.inventory_item_id, oh.organization_id,
                             oh.date_received, oh.last_update_date, oh.last_updated_by,
                             oh.creation_date, oh.created_by, oh.last_update_login,
                             oh.primary_transaction_quantity, oh.catalog_item_id, oh.subinventory_code,
                             oh.revision, oh.locator_id, oh.create_transaction_id,
                             oh.update_transaction_id, oh.lot_number, oh.orig_date_received,
                             oh.cost_group_id, oh.project_id, oh.task_id,
                             oh.organization_type, oh.owning_organization_id, oh.owning_tp_type,
                             oh.planning_organization_id, oh.planning_tp_type, oh.transaction_uom_code,
                             oh.transaction_quantity, oh.reserve_uom_code, oh.reserve_quantity,
                             oh.status_id, oh.BOM_NO, mtl.segment1, mtl.segment2, mtl.segment3, mtl.item_description,
                             oh.transaction_unit_cost, oh.project_number, oh.project_cost_code
                            from mtl_onhand_quantities_detail oh
                            left join mtl_system_items mtl on(oh.inventory_item_id = mtl.inventory_item_id)
                            where oh.inventory_item_id = @inventory_item_id
                            AND oh.primary_transaction_quantity > 0";

            object[] parms = { "@inventory_item_id", itemId };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public List<ItemOnhandModel> GetByLotNo(string lotNo)
        {
            string sql = @"select oh.onhand_quantities_id, oh.inventory_item_id, oh.organization_id,
                             oh.date_received, oh.last_update_date, oh.last_updated_by,
                             oh.creation_date, oh.created_by, oh.last_update_login,
                             oh.primary_transaction_quantity, oh.catalog_item_id, oh.subinventory_code,
                             oh.revision, oh.locator_id, oh.create_transaction_id,
                             oh.update_transaction_id, oh.lot_number, oh.orig_date_received,
                             oh.cost_group_id, oh.project_id, oh.task_id,
                             oh.organization_type, oh.owning_organization_id, oh.owning_tp_type,
                             oh.planning_organization_id, oh.planning_tp_type, oh.transaction_uom_code,
                             oh.transaction_quantity, oh.reserve_uom_code, oh.reserve_quantity,
                             oh.status_id, oh.BOM_NO, mtl.segment1, mtl.segment2, mtl.segment3, mtl.item_description,
                             oh.transaction_unit_cost, oh.project_number, oh.project_cost_code
                            from mtl_onhand_quantities_detail oh
                            left join mtl_system_items mtl on(oh.inventory_item_id = mtl.inventory_item_id)
                            where oh.lot_number = @lot_number
                            AND oh.primary_transaction_quantity > 0";

            object[] parms = { "@lot_number", lotNo };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public List<ItemOnhandModel> GetAll()
        {
            string sql = @"select oh.onhand_quantities_id, oh.inventory_item_id, oh.organization_id,
                             oh.date_received, oh.last_update_date, oh.last_updated_by,
                             oh.creation_date, oh.created_by, oh.last_update_login,
                             oh.primary_transaction_quantity, oh.catalog_item_id, oh.subinventory_code,
                             oh.revision, oh.locator_id, oh.create_transaction_id,
                             oh.update_transaction_id, oh.lot_number, oh.orig_date_received,
                             oh.cost_group_id, oh.project_id, oh.task_id,
                             oh.organization_type, oh.owning_organization_id, oh.owning_tp_type,
                             oh.planning_organization_id, oh.planning_tp_type, oh.transaction_uom_code,
                             oh.transaction_quantity, oh.reserve_uom_code, oh.reserve_quantity,
                             oh.status_id, oh.BOM_NO, mtl.segment1, mtl.segment2, mtl.segment3, mtl.item_description,
                             oh.transaction_unit_cost, oh.project_number, oh.project_cost_code
                            from mtl_onhand_quantities_detail oh
                            left join mtl_system_items mtl on(oh.inventory_item_id = mtl.inventory_item_id)
                            where oh.primary_transaction_quantity > 0
                            order by oh.catalog_item_id";

            return db.Read(sql, MakeWithStats).ToList();
        }

        public ItemOnhandModel GetByID(int id)
        {
            string sql = @"select oh.onhand_quantities_id, oh.inventory_item_id, oh.organization_id,
                             oh.date_received, oh.last_update_date, oh.last_updated_by,
                             oh.creation_date, oh.created_by, oh.last_update_login,
                             oh.primary_transaction_quantity, oh.catalog_item_id, oh.subinventory_code,
                             oh.revision, oh.locator_id, oh.create_transaction_id,
                             oh.update_transaction_id, oh.lot_number, oh.orig_date_received,
                             oh.cost_group_id, oh.project_id, oh.task_id,
                             oh.organization_type, oh.owning_organization_id, oh.owning_tp_type,
                             oh.planning_organization_id, oh.planning_tp_type, oh.transaction_uom_code,
                             oh.transaction_quantity, oh.reserve_uom_code, oh.reserve_quantity,
                             oh.status_id, oh.BOM_NO, mtl.segment1, mtl.segment2, mtl.segment3, mtl.item_description,
                             oh.transaction_unit_cost, oh.project_number, oh.project_cost_code
                            from mtl_onhand_quantities_detail oh
                            left join mtl_system_items mtl on(oh.inventory_item_id = mtl.inventory_item_id)
                            where oh.onhand_quantities_id = @onhand_quantities_id
                            AND oh.primary_transaction_quantity > 0";

            object[] parms = { "@onhand_quantities_id", id };
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public ItemOnhandModel GetDupplicated(int itemId, string subInventory, string lotNo, string bomNo)
        {
            string sql = @"SELECT TOP 1 oh.onhand_quantities_id, oh.inventory_item_id, oh.organization_id,
                             oh.date_received, oh.last_update_date, oh.last_updated_by,
                             oh.creation_date, oh.created_by, oh.last_update_login,
                             oh.primary_transaction_quantity, oh.catalog_item_id, oh.subinventory_code,
                             oh.revision, oh.locator_id, oh.create_transaction_id,
                             oh.update_transaction_id, oh.lot_number, oh.orig_date_received,
                             oh.cost_group_id, oh.project_id, oh.task_id,
                             oh.organization_type, oh.owning_organization_id, oh.owning_tp_type,
                             oh.planning_organization_id, oh.planning_tp_type, oh.transaction_uom_code,
                             oh.transaction_quantity, oh.reserve_uom_code, oh.reserve_quantity,
                             oh.status_id, oh.BOM_NO, mtl.segment1, mtl.segment2, mtl.segment3, mtl.item_description,
                             oh.transaction_unit_cost, oh.project_number, oh.project_cost_code
                            FROM mtl_onhand_quantities_detail oh
                                LEFT JOIN mtl_system_items mtl on(oh.inventory_item_id = mtl.inventory_item_id)
                            WHERE oh.inventory_item_id = @inventory_item_id
                                AND oh.subinventory_code = @subinventory_code
                                AND oh.lot_number = @lot_number
                                AND oh.bom_no = @bom_no
                            ORDER BY oh.onhand_quantities_id DESC";

            object[] parms = { "@inventory_item_id", itemId, "@subinventory_code", subInventory, "@lot_number", lotNo, "@bom_no", bomNo };
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public List<ItemOnhandModel> GetBySubinventoryCode(string subCode)
        {
            string sql = @"select oh.onhand_quantities_id, oh.inventory_item_id, oh.organization_id,
                             oh.date_received, oh.last_update_date, oh.last_updated_by,
                             oh.creation_date, oh.created_by, oh.last_update_login,
                             oh.primary_transaction_quantity, oh.catalog_item_id, oh.subinventory_code,
                             oh.revision, oh.locator_id, oh.create_transaction_id,
                             oh.update_transaction_id, oh.lot_number, oh.orig_date_received,
                             oh.cost_group_id, oh.project_id, oh.task_id,
                             oh.organization_type, oh.owning_organization_id, oh.owning_tp_type,
                             oh.planning_organization_id, oh.planning_tp_type, oh.transaction_uom_code,
                             oh.transaction_quantity, oh.reserve_uom_code, oh.reserve_quantity,
                             oh.status_id, oh.BOM_NO, mtl.segment1, mtl.segment2, mtl.segment3, mtl.item_description,
                             oh.transaction_unit_cost, oh.project_number, oh.project_cost_code
                            from mtl_onhand_quantities_detail oh
                            left join mtl_system_items mtl on(oh.inventory_item_id = mtl.inventory_item_id)
                            where oh.subinventory_code = @subinventory_code
                            AND oh.primary_transaction_quantity > 0
                            order by oh.catalog_item_id";

            object[] parms = { "@subinventory_code", subCode };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public int Insert(ItemOnhandModel model)
        {
            string sql =
                @"insert into mtl_onhand_quantities_detail
                       (inventory_item_id, organization_id,
                        date_received, last_update_date, last_updated_by,
                        creation_date, created_by, last_update_login,
                        primary_transaction_quantity, catalog_item_id, subinventory_code,
                        revision, locator_id, create_transaction_id,
                        update_transaction_id, lot_number, orig_date_received,
                        cost_group_id, project_id, task_id,
                        organization_type, owning_organization_id, owning_tp_type,
                        planning_organization_id, planning_tp_type, transaction_uom_code,
                        transaction_quantity, reserve_uom_code, reserve_quantity,
                        status_id, BOM_NO, transaction_unit_cost,
                        project_number, project_cost_code)
                    values
                       (@inventory_item_id,@organization_id,
                        @date_received,@last_update_date,@last_updated_by,
                        @creation_date,@created_by,@last_update_login,
                        @primary_transaction_quantity,@catalog_item_id,@subinventory_code,
                        @revision,@locator_id,@create_transaction_id,
                        @update_transaction_id,@lot_number,@orig_date_received,
                        @cost_group_id,@project_id,@task_id,
                        @organization_type,@owning_organization_id,@owning_tp_type,
                        @planning_organization_id,@planning_tp_type,@transaction_uom_code,
                        @transaction_quantity,@reserve_uom_code,@reserve_quantity,
                        @status_id, @BOM_NO, @transaction_unit_cost,
                        @project_number, @project_cost_code)";

            return db.Insert(sql, Take(model));
        }

        public void Update(ItemOnhandModel model)
        {
            string sql =
            @"UPDATE mtl_onhand_quantities_detail
              SET   inventory_item_id = @inventory_item_id,
                    organization_id = @organization_id,
                    date_received = @date_received,
                    last_update_date = @last_update_date,
                    last_updated_by = @last_updated_by,
                    last_update_login = @last_update_login,
                    primary_transaction_quantity = @primary_transaction_quantity,
                    catalog_item_id = @catalog_item_id,
                    subinventory_code = @subinventory_code,
                    revision = @revision,
                    locator_id = @locator_id,
                    create_transaction_id = @create_transaction_id,
                    update_transaction_id = @update_transaction_id,
                    lot_number = @lot_number,
                    orig_date_received = @orig_date_received,
                    cost_group_id = @cost_group_id,
                    project_id = @project_id,
                    task_id = @task_id,
                    organization_type = @organization_type,
                    owning_organization_id = @owning_organization_id,
                    owning_tp_type = @owning_tp_type,
                    planning_organization_id = @planning_organization_id,
                    planning_tp_type = @planning_tp_type,
                    transaction_uom_code = @transaction_uom_code,
                    transaction_quantity = @transaction_quantity,
                    reserve_uom_code = @reserve_uom_code,
                    reserve_quantity = @reserve_quantity,
                    status_id = @status_id,
                    BOM_NO = @BOM_NO,
                    transaction_unit_cost = @transaction_unit_cost,
                    project_number = @project_number,
                    project_cost_code = @project_cost_code
                where onhand_quantities_id = @onhand_quantities_id";

            db.Update(sql, Take(model));
        }

        public void Delete(ItemOnhandModel model)
        {
            string sql =
            @"DELETE FROM mtl_onhand_quantities_detail
               WHERE onhand_quantities_id = @onhand_quantities_id";

            object[] parms = { "@onhand_quantities_id", model.OnhandQuantitiesId };
            db.Update(sql, parms);
        }

        // creates a Members object with order statistics based on DataReader       
        private static Func<IDataReader, ItemOnhandModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            row.ItemCode = reader["segment1"].AsString();
            row.ManuID = reader["segment2"].AsString();
            row.BrandMat = reader["segment3"].AsString();
            row.ItemDescription = reader["item_description"].AsString();
            return row;
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, ItemOnhandModel> Make = reader =>
             new ItemOnhandModel
             {
                 OnhandQuantitiesId = reader["onhand_quantities_id"].AsInt(),
                 InventoryItemId = reader["inventory_item_id"].AsInt(),
                 OrganizationId = reader["organization_id"].AsInt(),
                 DateReceived = (reader["date_received"] != DBNull.Value) ? reader["date_received"].AsDateTime() : (DateTime?)null,
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 LastUpdateLogin = reader["last_update_login"].AsInt(),
                 PrimaryTransactionQuantity = reader["primary_transaction_quantity"].AsDouble(),
                 CatalogItemId = reader["catalog_item_id"].AsInt(),
                 SubinventoryCode = reader["subinventory_code"].AsString(),
                 Revision = reader["revision"].AsString(),
                 LocatorId = reader["locator_id"].AsInt(),
                 CreateTransactionId = reader["create_transaction_id"].AsInt(),
                 UpdateTransactionId = reader["update_transaction_id"].AsInt(),
                 LotNumber = reader["lot_number"].AsString(),
                 OrigDateReceived = (reader["orig_date_received"] != DBNull.Value) ? reader["orig_date_received"].AsDateTime() : (DateTime?)null,
                 CostGroupId = reader["cost_group_id"].AsInt(),
                 ProjectId = reader["project_id"].AsInt(),
                 TaskId = reader["task_id"].AsInt(),
                 OrganizationType = reader["organization_type"].AsInt(),
                 OwningOrganizationId = reader["owning_organization_id"].AsInt(),
                 OwningTpType = reader["owning_tp_type"].AsInt(),
                 PlanningOrganizationId = reader["planning_organization_id"].AsInt(),
                 PlanningTpType = reader["planning_tp_type"].AsInt(),
                 TransactionUomCode = reader["transaction_uom_code"].AsString(),
                 TransactionQuantity = reader["transaction_quantity"].AsDouble(),
                 ReserveUomCode = reader["reserve_uom_code"].AsString(),
                 ReserveQuantity = reader["reserve_quantity"].AsDouble(),
                 StatusId = reader["status_id"].AsInt(),
                 BomNo = reader["BOM_NO"].AsString(),
                 TransactionUnitCost = reader["transaction_unit_cost"].AsDouble(),
                 ProjectNum = reader["project_number"].AsString(),
                 ProjectCostCode = reader["project_cost_code"].AsString()
             };

        private object[] Take(ItemOnhandModel model)
        {
            return new object[]
            {
                "@onhand_quantities_id", model.OnhandQuantitiesId,
                "@inventory_item_id", model.InventoryItemId,
                "@organization_id", model.OrganizationId,
                "@date_received", model.DateReceived,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@last_update_login", model.LastUpdateLogin,
                "@primary_transaction_quantity", model.PrimaryTransactionQuantity,
                "@catalog_item_id", model.CatalogItemId,
                "@subinventory_code", model.SubinventoryCode,
                "@revision", model.Revision,
                "@locator_id", model.LocatorId,
                "@create_transaction_id", model.CreateTransactionId,
                "@update_transaction_id", model.UpdateTransactionId,
                "@lot_number", model.LotNumber,
                "@orig_date_received", model.OrigDateReceived,
                "@cost_group_id", model.CostGroupId,
                "@project_id", model.ProjectId,
                "@task_id", model.TaskId,
                "@organization_type", model.OrganizationType,
                "@owning_organization_id", model.OwningOrganizationId,
                "@owning_tp_type", model.OwningTpType,
                "@planning_organization_id", model.PlanningOrganizationId,
                "@planning_tp_type", model.PlanningTpType,
                "@transaction_uom_code", model.TransactionUomCode,
                "@transaction_quantity", model.TransactionQuantity,
                "@reserve_uom_code", model.ReserveUomCode,
                "@reserve_quantity", model.ReserveQuantity,
                "@status_id", model.StatusId,
                "@BOM_NO", model.BomNo,
                "@transaction_unit_cost", model.TransactionUnitCost,
                "@project_number", model.ProjectNum,
                "@project_cost_code", model.ProjectCostCode
            };
        }
    }
}
