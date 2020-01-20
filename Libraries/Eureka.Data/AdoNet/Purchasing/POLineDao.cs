using Eureka.Core.Domain.Purchasing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Purchasing
{
    public class POLineDao : IPOLineDao
    {
        private static Db db = new Db("ms_sql");

        public List<POLineModel> GetAll()
        {
            string sql = @"SELECT pl.po_line_id, pl.po_header_id, pl.po_line_num
                            , pl.status, pl.line_type, pl.last_update_date
                            , pl.last_updated_by, pl.creation_date, pl.created_by
                            , pl.item_id, pl.item_description, pl.uom
                            , pl.quantity, pl.qunitity_completed, pl.base_unit_price
                            , pl.tax_able_flag, pl.tax_code, pl.tax_rate
                            , pl.tax_amount, pl.unit_price, pl.extended_amount
                            , pl.ref_project_id, pl.ref_project_num, pl.bom_line_id
                            , pl.bom_release, pl.proj_cost_id, pl.cost_code
                            , pl.balloon_no, pl.bom, pl.item_code
                            , pl.spec_model, pl.brand_materail
                            , pl.rev, pl.due_date, pl.ecn_no, pl.cancel_flag
                            , pl.csr_no, pl.lead_time, pl.load_bom_date, pl.suplier, pl.job_making_flag
                            , pl.encumbrance_flag, pl.encumbrance_amount, pl.dupplicate_line_flag, pl.error_message
                            , pl.currency_code, pl.currency_rate
                          FROM po_lines_all pl
                          WHERE ISNULL(pl.encumbrance_flag, 'N') = 'N'
                            AND CAST(pl.creation_date as DATE) > CAST('7-31-2019' as DATE)
                          ORDER BY pl.ref_project_num ASC";

            return db.Read(sql, Make).ToList();
        }

        public POLineModel GetByID(int id)
        {
            string sql = @"SELECT pl.po_line_id, pl.po_header_id, pl.po_line_num
                            , pl.status, pl.line_type, pl.last_update_date
                            , pl.last_updated_by, pl.creation_date, pl.created_by
                            , pl.item_id, pl.item_description, pl.uom
                            , pl.quantity, pl.qunitity_completed, pl.base_unit_price
                            , pl.tax_able_flag, pl.tax_code, pl.tax_rate
                            , pl.tax_amount, pl.unit_price, pl.extended_amount
                            , pl.ref_project_id, pl.ref_project_num, pl.bom_line_id
                            , pl.bom_release, pl.proj_cost_id, pl.cost_code
                            , pl.balloon_no, pl.bom, pl.item_code
                            , pl.spec_model, pl.brand_materail
                            , pl.rev, pl.due_date, pl.ecn_no, pl.cancel_flag
                            , pl.csr_no, pl.lead_time, pl.load_bom_date, pl.suplier
							, pl.job_making_flag, ISNULL(pol.quantity_received, 0) quantity_received
                            , pl.encumbrance_flag, pl.encumbrance_amount, pl.dupplicate_line_flag, pl.error_message
                            , pl.currency_code, pl.currency_rate
                          FROM po_lines_all pl
                            LEFT JOIN (SELECT po_header_id, po_line_id, sum(quantity_received)  quantity_received
                            FROM po_line_locations_all GROUP BY po_header_id ,po_line_id) pol 
                                ON(pl.po_line_id = pol.po_line_id)
                          WHERE pl.po_line_id = @po_line_id";

            object[] parms = { "@po_line_id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public List<POLineModel> GetByPOID(int id)
        {
            string sql = @"SELECT pl.po_line_id, pl.po_header_id, pl.po_line_num
                            , pl.status, pl.line_type, pl.last_update_date
                            , pl.last_updated_by, pl.creation_date, pl.created_by
                            , pl.item_id, pl.item_description, pl.uom
                            , pl.quantity, pl.qunitity_completed, pl.base_unit_price
                            , pl.tax_able_flag, pl.tax_code, pl.tax_rate
                            , pl.tax_amount, pl.unit_price, pl.extended_amount
                            , pl.ref_project_id, pl.ref_project_num, pl.bom_line_id
                            , pl.bom_release, pl.proj_cost_id, pl.cost_code
                            , pl.balloon_no, pl.bom, pl.item_code
                            , pl.spec_model, pl.brand_materail
                            , pl.rev, pl.due_date, pl.ecn_no, pl.cancel_flag
                            , pl.csr_no, pl.lead_time, pl.load_bom_date, pl.suplier
							, pl.job_making_flag, ISNULL(pol.quantity_received, 0) quantity_received
                            , pl.encumbrance_flag, pl.encumbrance_amount, rel.unit_price pr_unit_price
                            , poh.vendor_id, pl.dupplicate_line_flag, pl.error_message
                            , pl.currency_code, pl.currency_rate
                          FROM po_lines_all pl
                            LEFT JOIN (SELECT po_line_id, sum(quantity_received)  quantity_received
                            FROM po_line_locations_all GROUP BY po_line_id) pol 
                                ON(pl.po_line_id = pol.po_line_id)
                            LEFT JOIN po_requisition_lines_all rel ON(pl.po_line_id = rel.po_line_id)
                            LEFT JOIN po_headers_all poh ON(pl.po_header_id = poh.po_header_id)
                          WHERE pl.po_header_id = @po_header_id
                          ORDER BY pl.po_line_num ASC";

            object[] parms = { "@po_header_id", id };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public List<POLineModel> GetByPONum(string number)
        {
            string sql = @"SELECT pl.po_line_id, pl.po_header_id, pl.po_line_num
                            , pl.status, pl.line_type, pl.last_update_date
                            , pl.last_updated_by, pl.creation_date, pl.created_by
                            , pl.item_id, pl.item_description, pl.uom
                            , pl.quantity, pl.qunitity_completed, pl.base_unit_price
                            , pl.tax_able_flag, pl.tax_code, pl.tax_rate
                            , pl.tax_amount, pl.unit_price, pl.extended_amount
                            , pl.ref_project_id, pl.ref_project_num, pl.bom_line_id
                            , pl.bom_release, pl.proj_cost_id, pl.cost_code
                            , pl.balloon_no, pl.bom, pl.item_code
                            , pl.spec_model, pl.brand_materail
                            , pl.rev, pl.due_date, pl.ecn_no, pl.cancel_flag
                            , pl.csr_no, pl.lead_time, pl.load_bom_date, pl.suplier, pl.job_making_flag
                            , pl.encumbrance_flag, pl.encumbrance_amount, pl.dupplicate_line_flag, pl.error_message
                            , pl.currency_code, pl.currency_rate
                          FROM po_lines_all pl
                            LEFT JOIN po_headers_all po ON(pl.po_header_id = po.po_header_id)
                          WHERE po.po_num = @po_num
                          ORDER BY pl.po_line_num ASC";

            object[] parms = { "@po_num", number };
            return db.Read(sql, Make, parms).ToList();
        }

        public int Insert(POLineModel model)
        {
            string sql =
                @"INSERT INTO po_lines_all
                       (po_header_id
                       ,po_line_num
                       ,status
                       ,line_type
                       ,last_update_date
                       ,last_updated_by
                       ,creation_date
                       ,created_by
                       ,item_id
                       ,item_description
                       ,uom
                       ,quantity
                       ,qunitity_completed
                       ,base_unit_price
                       ,tax_able_flag
                       ,tax_code
                       ,tax_rate
                       ,tax_amount
                       ,unit_price
                       ,extended_amount
                       ,ref_project_id
                       ,ref_project_num
                       ,bom_line_id
                       ,bom_release
                       ,proj_cost_id
                       ,cost_code
                       ,balloon_no
                       ,bom
                       ,item_code
                       ,spec_model
                       ,brand_materail
                       ,due_date
                       ,ecn_no
                       ,csr_no
                       ,lead_time
                       ,load_bom_date
                       ,suplier
                       ,job_making_flag
                       ,cancel_flag
                       ,encumbrance_flag
                       ,encumbrance_amount
                       ,dupplicate_line_flag
                       ,error_message
                       ,currency_code
                       ,currency_rate)
                 VALUES
                       (@po_header_id
                       ,@po_line_num
                       ,@status
                       ,@line_type
                       ,@last_update_date
                       ,@last_updated_by
                       ,@creation_date
                       ,@created_by
                       ,@item_id
                       ,@item_description
                       ,@uom
                       ,@quantity
                       ,@qunitity_completed
                       ,@base_unit_price
                       ,@tax_able_flag
                       ,@tax_code
                       ,@tax_rate
                       ,@tax_amount
                       ,@unit_price
                       ,@extended_amount
                       ,@ref_project_id
                       ,@ref_project_num
                       ,@bom_line_id
                       ,@bom_release
                       ,@proj_cost_id
                       ,@cost_code
                       ,@balloon_no
                       ,@bom
                       ,@item_code
                       ,@spec_model
                       ,@brand_materail
                       ,@due_date
                       ,@ecn_no
                       ,@csr_no
                       ,@lead_time
                       ,@load_bom_date
                       ,@suplier
                       ,@job_making_flag
                       ,@cancel_flag
                       ,@encumbrance_flag
                       ,@encumbrance_amount
                       ,@dupplicate_line_flag
                       ,@error_message
                       ,@currency_code
                       ,@currency_rate)";

            return db.Insert(sql, Take(model));
        }

        public void Update(POLineModel model)
        {
            string sql =
            @"UPDATE po_lines_all
                   SET po_header_id = @po_header_id
                      ,po_line_num = @po_line_num
                      ,status = @status
                      ,line_type = @line_type
                      ,last_update_date = @last_update_date
                      ,last_updated_by = @last_updated_by
                      ,item_id = @item_id
                      ,item_description = @item_description
                      ,uom = @uom
                      ,quantity = @quantity
                      ,qunitity_completed = @qunitity_completed
                      ,base_unit_price = @base_unit_price
                      ,tax_able_flag = @tax_able_flag
                      ,tax_code = @tax_code
                      ,tax_rate = @tax_rate
                      ,tax_amount = @tax_amount
                      ,unit_price = @unit_price
                      ,extended_amount = @extended_amount
                      ,ref_project_id = @ref_project_id
                      ,ref_project_num = @ref_project_num
                      ,bom_line_id = @bom_line_id
                      ,bom_release = @bom_release
                      ,proj_cost_id = @proj_cost_id
                      ,cost_code = @cost_code
                      ,balloon_no = @balloon_no
                      ,bom = @bom
                      ,item_code = @item_code
                      ,spec_model = @spec_model
                      ,brand_materail = @brand_materail
                      ,due_date = @due_date
                      ,ecn_no = @ecn_no
                      ,csr_no = @csr_no
                      ,lead_time = @lead_time
                      ,load_bom_date = @load_bom_date
                      ,suplier = @suplier
                      ,job_making_flag = @job_making_flag
                      ,cancel_flag = @cancel_flag
                      ,encumbrance_flag = @encumbrance_flag
                      ,encumbrance_amount = @encumbrance_amount
                      ,dupplicate_line_flag = @dupplicate_line_flag
                      ,error_message = @error_message
                      ,currency_code = @currency_code
                      ,currency_rate = @currency_rate
                 WHERE po_line_id = @po_line_id";

            db.Update(sql, Take(model));
        }

        public void Delete(POLineModel model)
        {
            string sql = @"DELETE FROM po_lines_all WHERE po_line_id = @po_line_id";

            object[] parms = { "@po_line_id", model.PoLineId };
            db.Update(sql, parms);
        }

        private static Func<IDataReader, POLineModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            row.QuantityReceived = reader["quantity_received"].AsDouble();
            row.UnitPriceBeforeFinal = reader["pr_unit_price"].AsDouble();
            row.VendorId = reader["vendor_id"].AsInt();
            return row;
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, POLineModel> Make = reader =>
             new POLineModel
             {
                 PoLineId = reader["po_line_id"].AsInt(),
                 PoHeaderId = reader["po_header_id"].AsInt(),
                 PoLineNum = reader["po_line_num"].AsInt(),
                 Status = (reader["status"] != DBNull.Value) ? reader["status"].AsString() : "Pending",
                 LineType = reader["line_type"].AsString(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 ItemId = reader["item_id"].AsInt(),
                 ItemDescription = reader["item_description"].AsString(),
                 Uom = reader["uom"].AsString(),
                 Quantity = reader["quantity"].AsDouble(),
                 QunitityCompleted = reader["qunitity_completed"].AsDouble(),
                 BaseUnitPrice = reader["base_unit_price"].AsDouble(),
                 TaxAbleFlag = reader["tax_able_flag"].AsString(),
                 TaxCode = reader["tax_code"].AsString(),
                 TaxRate = reader["tax_rate"].AsDouble(),
                 TaxAmount = reader["tax_amount"].AsDouble(),
                 UnitPrice = reader["unit_price"].AsDouble(),
                 //ExtendedAmount = reader["extended_amount"].AsDouble(),
                 RefProjectId = reader["ref_project_id"].AsInt(),
                 RefProjectNum = reader["ref_project_num"].AsString(),
                 BomLineId = reader["bom_line_id"].AsInt(),
                 BomRelease = reader["bom_release"].AsInt(),
                 ProjCostId = reader["proj_cost_id"].AsInt(),
                 CostCode = reader["cost_code"].AsString(),
                 BalloonNo = reader["balloon_no"].AsString(),
                 BOM = reader["bom"].AsString(),
                 ItemCode = reader["item_code"].AsString(),
                 Spec = reader["spec_model"].AsString(),
                 BrandMaterail = reader["brand_materail"].AsString(),
                 //Rev = reader["rev"].AsString(),
                 DueDate = (reader["due_date"] != DBNull.Value) ? reader["due_date"].AsDateTime() : (DateTime?)null,
                 ECN = reader["ecn_no"].AsString(),
                 CSR = reader["csr_no"].AsString(),
                 LeadTime = reader["lead_time"].AsInt(),
                 LoadBomDate = (reader["load_bom_date"] != DBNull.Value) ? reader["load_bom_date"].AsDateTime() : (DateTime?)null,
                 Suplier = reader["suplier"].AsString(),
                 JobMakingFlag = reader["job_making_flag"].AsString().Trim() == "Y" ? true : false,
                 CancelFlag = reader["cancel_flag"].AsString().Trim() == "Y" ? true : false,
                 EncumbranceFlag = (reader["encumbrance_flag"].AsString() == "Y") ? true : false,
                 DupplicateFlag = (reader["dupplicate_line_flag"].AsString() == "Y") ? true : false,
                 EncumbranceAmount = reader["encumbrance_amount"].AsDouble(),
                 LineErrorMessage = reader["error_message"].AsString(),
                 CurrencyCode = reader["currency_code"].AsString(),
                 CurrencyRate = reader["currency_rate"].AsDouble()
             };

        private object[] Take(POLineModel model)
        {
            return new object[]
            {
                "@po_line_id", model.PoLineId,
                "@po_header_id", model.PoHeaderId,
                "@po_line_num", model.PoLineNum,
                "@status", model.Status,
                "@line_type", model.LineType,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@item_id", model.ItemId,
                "@item_description", model.ItemDescription,
                "@uom", model.Uom,
                "@quantity", model.Quantity,
                "@qunitity_completed", model.QunitityCompleted,
                "@base_unit_price", model.BaseUnitPrice,
                "@tax_able_flag", model.TaxAbleFlag,
                "@tax_code", model.TaxCode,
                "@tax_rate", model.TaxRate,
                "@tax_amount", model.TaxAmount,
                "@unit_price", model.UnitPrice,
                "@extended_amount", model.ExtendedAmount,
                "@ref_project_id", model.RefProjectId,
                "@ref_project_num", model.RefProjectNum,
                "@bom_line_id", model.BomLineId,
                "@bom_release", model.BomRelease,
                "@proj_cost_id", model.ProjCostId,
                "@cost_code", model.CostCode,
                "@balloon_no", model.BalloonNo,
                "@bom", model.BOM,
                "@item_code", model.ItemCode,
                "@spec_model", model.Spec,
                "@brand_materail", model.BrandMaterail,
                //"@rev", model.Rev,
                "@due_date", model.DueDate,
                "@ecn_no", model.ECN,
                "@csr_no", model.CSR,
                "@lead_time", model.LeadTime,
                "@load_bom_date", model.LoadBomDate,
                "@suplier", model.Suplier,
                "@job_making_flag", model.JobMakingFlag ? "Y" : "N",
                "@cancel_flag", model.CancelFlag ? "Y" : "N",
                "@encumbrance_flag", (model.EncumbranceFlag) ? "Y" : "N",
                "@dupplicate_line_flag", (model.DupplicateFlag) ? "Y" : "N",
                "@encumbrance_amount", model.EncumbranceAmount,
                "@error_message", model.LineErrorMessage,
                "@currency_code", model.CurrencyCode,
                "@currency_rate", model.CurrencyRate
            };
        }
    }
}
