using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Purchasing;

namespace Eureka.Data.AdoNet.Purchasing
{
    public class RequisitionLineDao : IRequisitionLineDao
    {
        private static Db db = new Db("ms_sql");

        public List<RequisitionLineModel> GetAll()
        {
            string sql = @"SELECT rel.requisition_line_id, rel.requisition_header_id, rel.line_num
	                        , rel.status, rel.line_type, rel.last_update_date
	                        , rel.last_updated_by, rel.creation_date, rel.created_by
	                        , rel.item_id, rel.item_code, rel.item_description
	                        , rel.uom, rel.quantity, rel.unit_price, rel.final_unit_price
	                        , rel.extended_amount, rel.ref_project_id, rel.ref_project_num
	                        , rel.proj_cost_id, rel.cost_id, rel.cost_code
	                        , rel.balloon_no, rel.bom_id, rel.bom_no
	                        , rel.brand_materail, rel.rev, rel.due_date
	                        , rel.ecn_no, rel.csr_no, rel.lead_time
	                        , rel.load_bom_date, rel.spec_model, rel.suplier_symbol
	                        , rel.job_making_flag, rel.cancel_flag, rel.purchased_flag
	                        , bom.bom_number, cst.cost_code, rel.validated_flag
                            , rel.purchased_quantity, rel.attribute1, rel.attribute2
	                        , rel.attribute3, rel.attribute4, rel.attribute5, rel.dupplicated_flag
                            , rel.final_confirm_flag, rel.reject_flag, rel.reject_comment
                            , rel.po_header_id, rel.po_line_id, rel.vendor_id, rel.approved_flag
                            , rel.encumbrance_flag, rel.encumbrance_amount, rel.submit_flag
                            , rel.sent_price_confirm_flag , rel.price_confirm_flag
                            , rel.request_date, rel.deleted_flag, rel.notes
                          FROM po_requisition_lines_all rel
	                        LEFT JOIN prj_boms bom on(rel.bom_id = bom.bom_id)
	                        LEFT JOIN prj_cost_groups cst ON(rel.cost_id = cst.cost_id)
                          ORDER BY rel.line_num ASC";

            return db.Read(sql, Make).ToList();
        }

        public List<RequisitionLineModel> GetByProjectId(int projectId)
        {
            string sql = @"SELECT rel.requisition_line_id, rel.requisition_header_id, rel.line_num
	                        , rel.status, rel.line_type, rel.last_update_date
	                        , rel.last_updated_by, rel.creation_date, rel.created_by
	                        , rel.item_id, rel.item_code, rel.item_description
	                        , rel.uom, rel.quantity, rel.unit_price, rel.final_unit_price
	                        , rel.extended_amount, rel.ref_project_id, rel.ref_project_num
	                        , rel.proj_cost_id, rel.cost_id, rel.cost_code
	                        , rel.balloon_no, rel.bom_id, rel.bom_no
	                        , rel.brand_materail, rel.rev, rel.due_date
	                        , rel.ecn_no, rel.csr_no, rel.lead_time
	                        , rel.load_bom_date, rel.spec_model, rel.suplier_symbol
	                        , rel.job_making_flag, rel.cancel_flag, rel.purchased_flag
	                        , bom.bom_number, cst.cost_code, rel.validated_flag
                            , rel.purchased_quantity, rel.attribute1, rel.attribute2
	                        , rel.attribute3, rel.attribute4, rel.attribute5, rel.dupplicated_flag
                            , rel.final_confirm_flag, rel.reject_flag, rel.reject_comment
                            , rel.po_header_id, rel.po_line_id, rel.vendor_id, rel.approved_flag
							, reh.requisition_number, reh.requisition_date, ven.vendor_name
                            , rel.encumbrance_flag, rel.encumbrance_amount, rel.submit_flag
                            , rel.sent_price_confirm_flag , rel.price_confirm_flag
                            , rel.request_date, rel.deleted_flag, rel.notes
                          FROM po_requisition_lines_all rel
	                        LEFT JOIN prj_boms bom on(rel.bom_id = bom.bom_id)
	                        LEFT JOIN prj_cost_groups cst ON(rel.cost_id = cst.cost_id)
							LEFT JOIN po_requisition_headers_all reh ON(rel.requisition_header_id = reh.requisition_header_id)
							LEFT JOIN ap_suppliers ven ON(rel.vendor_id = ven.vendor_id)
                          WHERE  rel.ref_project_id = @ref_project_id
                            AND rel.approved_flag = 'Y'
                            AND rel.purchased_flag = 'N'
                          ORDER BY rel.requisition_line_id ASC";

            object[] parms = { "@ref_project_id", projectId};
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public List<RequisitionLineModel> GetByProjectIdForConfirm(int projectId)
        {
            string sql = @"SELECT rel.requisition_line_id, rel.requisition_header_id, rel.line_num
	                        , rel.status, rel.line_type, rel.last_update_date
	                        , rel.last_updated_by, rel.creation_date, rel.created_by
	                        , rel.item_id, rel.item_code, rel.item_description
	                        , rel.uom, rel.quantity, rel.unit_price, rel.final_unit_price
	                        , rel.extended_amount, rel.ref_project_id, rel.ref_project_num
	                        , rel.proj_cost_id, rel.cost_id, rel.cost_code
	                        , rel.balloon_no, rel.bom_id, rel.bom_no
	                        , rel.brand_materail, rel.rev, rel.due_date
	                        , rel.ecn_no, rel.csr_no, rel.lead_time
	                        , rel.load_bom_date, rel.spec_model, rel.suplier_symbol
	                        , rel.job_making_flag, rel.cancel_flag, rel.purchased_flag
	                        , bom.bom_number, cst.cost_code, rel.validated_flag
                            , rel.purchased_quantity, rel.attribute1, rel.attribute2
	                        , rel.attribute3, rel.attribute4, rel.attribute5, rel.dupplicated_flag
                            , rel.final_confirm_flag, rel.reject_flag, rel.reject_comment
                            , rel.po_header_id, rel.po_line_id, rel.vendor_id, rel.approved_flag
							, reh.requisition_number, reh.requisition_date, ven.vendor_name
                            , rel.encumbrance_flag, rel.encumbrance_amount, rel.submit_flag
                            , rel.sent_price_confirm_flag , rel.price_confirm_flag
                            , rel.request_date, rel.deleted_flag, rel.notes
                          FROM po_requisition_lines_all rel
	                        LEFT JOIN prj_boms bom on(rel.bom_id = bom.bom_id)
	                        LEFT JOIN prj_cost_groups cst ON(rel.cost_id = cst.cost_id)
							LEFT JOIN po_requisition_headers_all reh ON(rel.requisition_header_id = reh.requisition_header_id)
							LEFT JOIN ap_suppliers ven ON(rel.vendor_id = ven.vendor_id)
                          WHERE  rel.ref_project_id = @ref_project_id
                            AND rel.sent_price_confirm_flag = 'Y'
                            AND rel.price_confirm_flag = 'N'
                            AND rel.approved_flag = 'N'
                            AND rel.purchased_flag = 'N'
                          ORDER BY rel.requisition_line_id ASC";

            object[] parms = { "@ref_project_id", projectId };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public List<RequisitionLineModel> GetByDate(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT rel.requisition_line_id, rel.requisition_header_id, rel.line_num
	                        , rel.status, rel.line_type, rel.last_update_date
	                        , rel.last_updated_by, rel.creation_date, rel.created_by
	                        , rel.item_id, rel.item_code, rel.item_description
	                        , rel.uom, rel.quantity, rel.unit_price, rel.final_unit_price
	                        , rel.extended_amount, rel.ref_project_id, rel.ref_project_num
	                        , rel.proj_cost_id, rel.cost_id, rel.cost_code
	                        , rel.balloon_no, rel.bom_id, rel.bom_no
	                        , rel.brand_materail, rel.rev, rel.due_date
	                        , rel.ecn_no, rel.csr_no, rel.lead_time
	                        , rel.load_bom_date, rel.spec_model, rel.suplier_symbol
	                        , rel.job_making_flag, rel.cancel_flag, rel.purchased_flag
	                        , bom.bom_number, cst.cost_code, rel.validated_flag
                            , rel.purchased_quantity, rel.attribute1, rel.attribute2
	                        , rel.attribute3, rel.attribute4, rel.attribute5, rel.dupplicated_flag
                            , rel.final_confirm_flag, rel.reject_flag, rel.reject_comment
                            , rel.po_header_id, rel.po_line_id, rel.vendor_id, rel.approved_flag
                            , rel.encumbrance_flag, rel.encumbrance_amount, rel.submit_flag
                            , rel.sent_price_confirm_flag , rel.price_confirm_flag
                            , rel.request_date, rel.deleted_flag, rel.notes
                          FROM po_requisition_lines_all rel
	                        LEFT JOIN prj_boms bom on(rel.bom_id = bom.bom_id)
	                        LEFT JOIN prj_cost_groups cst ON(rel.cost_id = cst.cost_id)
                          WHERE  cast(rel.creation_date as date) BETWEEN cast(@StartDate as date) AND cast(@EndDate as date)
                          ORDER BY rel.line_num ASC";

            object[] parms = { "@StartDate", startDate, "@EndDate", endDate };
            return db.Read(sql, Make, parms).ToList();
        }

        public List<RequisitionLineModel> GetByHeaderID(int id)
        {
            string sql = @"SELECT rel.requisition_line_id, rel.requisition_header_id, rel.line_num
	                        , rel.status, rel.line_type, rel.last_update_date
	                        , rel.last_updated_by, rel.creation_date, rel.created_by
	                        , rel.item_id, rel.item_code, rel.item_description
	                        , rel.uom, rel.quantity, rel.unit_price, rel.final_unit_price
	                        , rel.extended_amount, rel.ref_project_id, rel.ref_project_num
	                        , rel.proj_cost_id, rel.cost_id, rel.cost_code
	                        , rel.balloon_no, rel.bom_id, rel.bom_no
	                        , rel.brand_materail, rel.rev, rel.due_date
	                        , rel.ecn_no, rel.csr_no, rel.lead_time
	                        , rel.load_bom_date, rel.spec_model, rel.suplier_symbol
	                        , rel.job_making_flag, rel.cancel_flag, rel.purchased_flag
	                        , bom.bom_number, cst.cost_code, rel.validated_flag
                            , rel.purchased_quantity, rel.attribute1, rel.attribute2
	                        , rel.attribute3, rel.attribute4, rel.attribute5, rel.dupplicated_flag
                            , rel.final_confirm_flag, rel.reject_flag, rel.reject_comment
                            , rel.po_header_id, rel.po_line_id, rel.vendor_id, rel.approved_flag
                            , rel.encumbrance_flag, rel.encumbrance_amount, rel.submit_flag
                            , rel.sent_price_confirm_flag , rel.price_confirm_flag
                            , rel.request_date, rel.deleted_flag, rel.notes
                          FROM po_requisition_lines_all rel
	                        LEFT JOIN prj_boms bom on(rel.bom_id = bom.bom_id)
	                        LEFT JOIN prj_cost_groups cst ON(rel.cost_id = cst.cost_id)
                          WHERE  rel.requisition_header_id = @requisition_header_id
                          ORDER BY rel.line_num ASC";

            object[] parms = { "@requisition_header_id", id };
            return db.Read(sql, Make, parms).ToList();
        }

        public RequisitionLineModel GetByID(int id)
        {
            string sql = @"SELECT rel.requisition_line_id, rel.requisition_header_id, rel.line_num
	                        , rel.status, rel.line_type, rel.last_update_date
	                        , rel.last_updated_by, rel.creation_date, rel.created_by
	                        , rel.item_id, rel.item_code, rel.item_description
	                        , rel.uom, rel.quantity, rel.unit_price, rel.final_unit_price
	                        , rel.extended_amount, rel.ref_project_id, rel.ref_project_num
	                        , rel.proj_cost_id, rel.cost_id, rel.cost_code
	                        , rel.balloon_no, rel.bom_id, rel.bom_no
	                        , rel.brand_materail, rel.rev, rel.due_date
	                        , rel.ecn_no, rel.csr_no, rel.lead_time
	                        , rel.load_bom_date, rel.spec_model, rel.suplier_symbol
	                        , rel.job_making_flag, rel.cancel_flag, rel.purchased_flag
	                        , bom.bom_number, cst.cost_code, rel.validated_flag
                            , rel.purchased_quantity, rel.attribute1, rel.attribute2
	                        , rel.attribute3, rel.attribute4, rel.attribute5, rel.dupplicated_flag
                            , rel.final_confirm_flag, rel.reject_flag, rel.reject_comment
                            , rel.po_header_id, rel.po_line_id, rel.vendor_id, rel.approved_flag
                            , rel.encumbrance_flag, rel.encumbrance_amount, rel.submit_flag
                            , rel.sent_price_confirm_flag , rel.price_confirm_flag
                            , rel.request_date, rel.deleted_flag, rel.notes
                          FROM po_requisition_lines_all rel
	                        LEFT JOIN prj_boms bom on(rel.bom_id = bom.bom_id)
	                        LEFT JOIN prj_cost_groups cst ON(rel.cost_id = cst.cost_id)
                          WHERE  rel.requisition_line_id = @requisition_line_id";

            object[] parms = { "@requisition_line_id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public List<RequisitionLineModel> GetByPOID(int poId)
        {
            string sql = @"SELECT rel.requisition_line_id, rel.requisition_header_id, rel.line_num
	                        , rel.status, rel.line_type, rel.last_update_date
	                        , rel.last_updated_by, rel.creation_date, rel.created_by
	                        , rel.item_id, rel.item_code, rel.item_description
	                        , rel.uom, rel.quantity, rel.unit_price, rel.final_unit_price
	                        , rel.extended_amount, rel.ref_project_id, rel.ref_project_num
	                        , rel.proj_cost_id, rel.cost_id, rel.cost_code
	                        , rel.balloon_no, rel.bom_id, rel.bom_no
	                        , rel.brand_materail, rel.rev, rel.due_date
	                        , rel.ecn_no, rel.csr_no, rel.lead_time
	                        , rel.load_bom_date, rel.spec_model, rel.suplier_symbol
	                        , rel.job_making_flag, rel.cancel_flag, rel.purchased_flag
	                        , bom.bom_number, cst.cost_code, rel.validated_flag
                            , rel.purchased_quantity, rel.attribute1, rel.attribute2
	                        , rel.attribute3, rel.attribute4, rel.attribute5, rel.dupplicated_flag
                            , rel.final_confirm_flag, rel.reject_flag, rel.reject_comment
                            , rel.po_header_id, rel.po_line_id, rel.vendor_id, rel.approved_flag
							, reh.requisition_number, reh.requisition_date, ven.vendor_name
                            , rel.encumbrance_flag, rel.encumbrance_amount, rel.submit_flag
                            , rel.sent_price_confirm_flag , rel.price_confirm_flag
                            , rel.request_date, rel.deleted_flag, rel.notes
                          FROM po_requisition_lines_all rel
	                        LEFT JOIN prj_boms bom on(rel.bom_id = bom.bom_id)
	                        LEFT JOIN prj_cost_groups cst ON(rel.cost_id = cst.cost_id)
							LEFT JOIN po_requisition_headers_all reh ON(rel.requisition_header_id = reh.requisition_header_id)
							LEFT JOIN ap_suppliers ven ON(rel.vendor_id = ven.vendor_id)
                          WHERE  rel.po_header_id = @po_header_id
                            AND rel.approved_flag = 'Y'                            
                          ORDER BY rel.requisition_line_id ASC";

            object[] parms = { "@po_header_id", poId };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public int Insert(RequisitionLineModel model)
        {
            string sql =
                @"INSERT INTO po_requisition_lines_all
		                (requisition_header_id,line_num,status
		                ,line_type,last_update_date,last_updated_by
		                ,creation_date,created_by,item_id
		                ,item_code,item_description,uom
		                ,quantity,unit_price,extended_amount
		                ,ref_project_id,ref_project_num,proj_cost_id
		                ,cost_id,cost_code,balloon_no
		                ,bom_id,bom_no,brand_materail
		                ,rev,due_date,ecn_no
		                ,csr_no,lead_time,load_bom_date
		                ,spec_model,suplier_symbol
		                ,attribute1,attribute2,attribute3
		                ,attribute4,attribute5,job_making_flag
		                ,cancel_flag,purchased_flag,validated_flag
                        ,purchased_quantity, dupplicated_flag
                        ,final_confirm_flag,reject_flag
                        ,reject_comment,po_header_id
                        ,po_line_id,vendor_id
                        ,final_unit_price,approved_flag
                        ,encumbrance_flag,encumbrance_amount,submit_flag
                        ,sent_price_confirm_flag,price_confirm_flag
                        ,request_date,deleted_flag,notes)
                     VALUES
		                (@requisition_header_id,@line_num,@status
		                ,@line_type,@last_update_date,@last_updated_by
		                ,@creation_date,@created_by,@item_id
		                ,@item_code,@item_description,@uom
		                ,@quantity,@unit_price,@extended_amount
		                ,@ref_project_id,@ref_project_num,@proj_cost_id
		                ,@cost_id,@cost_code,@balloon_no
		                ,@bom_id,@bom_no,@brand_materail
		                ,@rev,@due_date,@ecn_no
		                ,@csr_no,@lead_time,@load_bom_date
		                ,@spec_model,@suplier_symbol
		                ,@attribute1,@attribute2,@attribute3
		                ,@attribute4,@attribute5,@job_making_flag
		                ,@cancel_flag,@purchased_flag,@validated_flag
                        ,@purchased_quantity,@dupplicated_flag
                        ,@final_confirm_flag,@reject_flag
                        ,@reject_comment,@po_header_id
                        ,@po_line_id,@vendor_id
                        ,@final_unit_price,@approved_flag
                        ,@encumbrance_flag,@encumbrance_amount,@submit_flag
                        ,@sent_price_confirm_flag,@price_confirm_flag
                        ,@request_date,@deleted_flag,@notes)";

            return db.Insert(sql, Take(model));
        }

        public void Update(RequisitionLineModel model)
        {
            string sql =
            @"UPDATE po_requisition_lines_all
                   SET requisition_header_id = @requisition_header_id
                      ,line_num = @line_num
                      ,status = @status
                      ,line_type = @line_type
                      ,last_update_date = @last_update_date
                      ,last_updated_by = @last_updated_by
                      ,item_id = @item_id
                      ,item_code = @item_code
                      ,item_description = @item_description
                      ,uom = @uom
                      ,quantity = @quantity
                      ,unit_price = @unit_price
                      ,final_unit_price = @final_unit_price
                      ,extended_amount = @extended_amount
                      ,ref_project_id = @ref_project_id
                      ,ref_project_num = @ref_project_num
                      ,proj_cost_id = @proj_cost_id
                      ,cost_id = @cost_id
                      ,cost_code = @cost_code
                      ,balloon_no = @balloon_no
                      ,bom_id = @bom_id
                      ,bom_no = @bom_no
                      ,brand_materail = @brand_materail
                      ,rev = @rev
                      ,due_date = @due_date
                      ,ecn_no = @ecn_no
                      ,csr_no = @csr_no
                      ,lead_time = @lead_time
                      ,load_bom_date = @load_bom_date
                      ,spec_model = @spec_model
                      ,suplier_symbol = @suplier_symbol
                      ,attribute1 = @attribute1
                      ,attribute2 = @attribute2
                      ,attribute3 = @attribute3
                      ,attribute4 = @attribute4
                      ,attribute5 = @attribute5
                      ,job_making_flag = @job_making_flag
                      ,cancel_flag = @cancel_flag
                      ,purchased_flag = @purchased_flag
                      ,validated_flag = @validated_flag
                      ,purchased_quantity = @purchased_quantity
                      ,dupplicated_flag = @dupplicated_flag
                      ,final_confirm_flag = @final_confirm_flag
                      ,reject_flag = @reject_flag
                      ,reject_comment = @reject_comment
                      ,po_header_id = @po_header_id
                      ,po_line_id = @po_line_id
                      ,vendor_id = @vendor_id
                      ,approved_flag = @approved_flag
                      ,encumbrance_flag = @encumbrance_flag
                      ,encumbrance_amount = @encumbrance_amount
                      ,sent_price_confirm_flag = @sent_price_confirm_flag
                      ,price_confirm_flag = @price_confirm_flag
                      ,request_date = @request_date
                      ,deleted_flag = @deleted_flag
                      ,notes = @notes
                      ,submit_flag = @submit_flag
               WHERE requisition_line_id = @requisition_line_id";

            db.Update(sql, Take(model));
        }

        public void Delete(RequisitionLineModel model)
        {
            string sql = @"DELETE FROM po_requisition_lines_all WHERE requisition_line_id = @requisition_line_id";

            object[] parms = { "@requisition_line_id", model.RequisitionLineId };
            db.Update(sql, parms);
        }

        //creates a Members object with order statistics based on DataReader              
        private static Func<IDataReader, RequisitionLineModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            //row.StockOnHand = reader[""].AsDouble();
            row.RequisitionNumber = reader["requisition_number"].AsString();
            row.RequisitionDate = reader["requisition_date"].AsDateTime();
            row.VendorName = reader["vendor_name"].AsString();
            return row;
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, RequisitionLineModel> Make = reader =>
             new RequisitionLineModel
             {
                 RequisitionLineId = reader["requisition_line_id"].AsInt(),
                 RequisitionHeaderId = reader["requisition_header_id"].AsInt(),
                 LineNum = reader["line_num"].AsInt(),
                 Status = reader["status"].AsString(),
                 LineType = reader["line_type"].AsString(),
                 LastUpdateDate = (reader["last_update_date"] != DBNull.Value) ? reader["last_update_date"].AsDateTime() : (DateTime?)null,
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = (reader["creation_date"] != DBNull.Value) ? reader["creation_date"].AsDateTime() : (DateTime?)null,
                 CreatedBy = reader["created_by"].AsInt(),
                 ItemId = reader["item_id"].AsInt(),
                 ItemCode = reader["item_code"].AsString(),
                 ItemDescription = reader["item_description"].AsString(),
                 Uom = reader["uom"].AsString(),
                 Quantity = reader["quantity"].AsDouble(),
                 UnitPrice = reader["unit_price"].AsDouble(),
                 FinalUnitPrice = reader["final_unit_price"].AsDouble(),
                 RefProjectId = reader["ref_project_id"].AsInt(),
                 RefProjectNum = reader["ref_project_num"].AsString(),
                 ProjCostId = reader["proj_cost_id"].AsInt(),
                 CostId = reader["cost_id"].AsInt(),
                 CostCode = reader["cost_code"].AsString(),
                 BalloonNo = reader["balloon_no"].AsString(),
                 BomId = reader["bom_id"].AsInt(),
                 BomNo = reader["bom_no"].AsString(),
                 BrandMaterail = reader["brand_materail"].AsString(),
                 Rev = reader["rev"].AsString(),
                 DueDate = (reader["due_date"] != DBNull.Value) ? reader["due_date"].AsDateTime() : (DateTime?)null,
                 RequestDate = (reader["request_date"] != DBNull.Value) ? reader["request_date"].AsDateTime() : (DateTime?)null,
                 EcnNo = reader["ecn_no"].AsString(),
                 CsrNo = reader["csr_no"].AsString(),
                 LeadTime = reader["lead_time"].AsInt(),
                 LoadBomDate = (reader["load_bom_date"] != DBNull.Value) ? reader["load_bom_date"].AsDateTime() : (DateTime?)null,
                 SpecModel = reader["spec_model"].AsString(),
                 SuplierSymbol = reader["suplier_symbol"].AsString(),
                 Attribute1 = reader["attribute1"].AsString(),
                 Attribute2 = reader["attribute2"].AsString(),
                 Attribute3 = reader["attribute3"].AsString(),
                 Attribute4 = reader["attribute4"].AsString(),
                 Attribute5 = reader["attribute5"].AsString(),
                 JobMakingFlag = (reader["job_making_flag"].AsString() == "Y") ? true : false,
                 CancelFlag = (reader["cancel_flag"].AsString() == "Y") ? true : false,
                 PurchasedFlag = (reader["purchased_flag"].AsString() == "Y") ? true : false,
                 PurchasedQuantity = reader["purchased_quantity"].AsDouble(),
                 ValidatedFlag = (reader["validated_flag"].AsString() == "Y") ? true : false,
                 DupplicateFlag = (reader["dupplicated_flag"].AsString() == "Y") ? true : false,
                 FinalConfirmFlag = (reader["final_confirm_flag"].AsString() == "Y") ? true : false,
                 RejectFlag = (reader["reject_flag"].AsString() == "Y") ? true : false,
                 RejectComment = reader["reject_comment"].AsString(),
                 PoHeaderId = reader["po_header_id"].AsInt(),
                 PoLineId = reader["po_line_id"].AsInt(),
                 VendorId = reader["vendor_id"].AsInt(),
                 ApprovedFlag = (reader["approved_flag"].AsString() == "Y") ? true : false,
                 EncumbranceFlag = (reader["encumbrance_flag"].AsString() == "Y") ? true : false,
                 EncumbranceAmount = reader["encumbrance_amount"].AsDouble(),
                 SentPriceConfirmFlag = (reader["sent_price_confirm_flag"].AsString() == "Y") ? true : false,
                 PriceConfirmedFlag = (reader["price_confirm_flag"].AsString() == "Y") ? true : false,
                 DeleteFlag = (reader["deleted_flag"].AsString() == "Y") ? true : false,
                 SubmitFlag = (reader["submit_flag"].AsString() == "Y") ? true : false,
                 Notes = reader["notes"].AsString()
                 
             };

        private object[] Take(RequisitionLineModel model)
        {
            return new object[]
            {
                "@requisition_line_id", model.RequisitionLineId,
                "@requisition_header_id", model.RequisitionHeaderId,
                "@line_num", model.LineNum,
                "@status", model.Status,
                "@line_type", model.LineType,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@item_id", model.ItemId,
                "@item_code", model.ItemCode,
                "@item_description", model.ItemDescription,
                "@uom", model.Uom,
                "@quantity", model.Quantity,
                "@unit_price", model.UnitPrice,
                "@final_unit_price", model.FinalUnitPrice,
                "@extended_amount", model.ExtendedAmount,
                "@ref_project_id", model.RefProjectId,
                "@ref_project_num", model.RefProjectNum,
                "@proj_cost_id", model.ProjCostId,
                "@cost_id", model.CostId,
                "@cost_code", model.CostCode,
                "@balloon_no", model.BalloonNo,
                "@bom_id", model.BomId,
                "@bom_no", model.BomNo,
                "@brand_materail", model.BrandMaterail,
                "@rev", model.Rev,
                "@due_date", model.DueDate,
                "@request_date", model.RequestDate,
                "@ecn_no", model.EcnNo,
                "@csr_no", model.CsrNo,
                "@lead_time", model.LeadTime,
                "@load_bom_date", model.LoadBomDate,
                "@spec_model", model.SpecModel,
                "@suplier_symbol", model.SuplierSymbol,
                "@attribute1", model.Attribute1,
                "@attribute2", model.Attribute2,
                "@attribute3", model.Attribute3,
                "@attribute4", model.Attribute4,
                "@attribute5", model.Attribute5,
                "@job_making_flag", (model.JobMakingFlag) ? "Y" : "N",
                "@cancel_flag", (model.CancelFlag) ? "Y" : "N",
                "@purchased_flag", (model.PurchasedFlag) ? "Y" : "N",
                "@purchased_quantity", model.PurchasedQuantity,
                "@validated_flag", (model.ValidatedFlag) ? "Y" : "N",
                "@dupplicated_flag", (model.DupplicateFlag) ? "Y" : "N",
                "@final_confirm_flag",(model.FinalConfirmFlag) ? "Y" : "N",
                "@reject_flag",(model.RejectFlag) ? "Y" : "N",
                "@reject_comment", model.RejectComment,
                "@po_header_id", model.PoHeaderId,
                "@po_line_id", model.PoLineId,
                "@vendor_id", model.VendorId,
                "@approved_flag", (model.ApprovedFlag) ? "Y" : "N",
                "@encumbrance_flag", (model.EncumbranceFlag) ? "Y" : "N",
                "@encumbrance_amount", model.EncumbranceAmount,
                "@sent_price_confirm_flag", (model.SentPriceConfirmFlag) ? "Y" : "N",
                "@price_confirm_flag", (model.PriceConfirmedFlag) ? "Y" : "N",
                "@deleted_flag", (model.DeleteFlag) ? "Y" : "N",
                "@notes", model.Notes,
                "@submit_flag", (model.SubmitFlag) ? "Y" : "N"
            };
        }
    }
}
