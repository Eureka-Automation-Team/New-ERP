using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Purchasing;

namespace Eureka.Data.AdoNet.Purchasing
{
    public class RequisitionHeaderDao : IRequisitionHeaderDao
    {
        private static Db db = new Db("ms_sql");

        public List<RequisitionHeaderModel> GetAll()
        {
            string sql = @"SELECT requisition_header_id, reh.requisition_number, reh.requisition_date
	                            , reh.requester_id, reh.type_lookup_code, reh.job_process_flag
	                            , reh.last_update_date, reh.last_updated_by, reh.segment1
	                            , reh.summary_flag, reh.enabled_flag, reh.segment2
	                            , reh.segment3, reh.segment4, reh.segment5
	                            , reh.project_number, reh.start_date_active, reh.end_date_active
	                            , reh.last_update_login, reh.creation_date, reh.created_by
	                            , reh.description, reh.attribute1, reh.attribute2
	                            , reh.attribute3, reh.attribute4, reh.attribute5
	                            , reh.cancel_flag, reh.org_id, reh.authorization_status
	                            , reh.note_to_authorizer, reh.approved_date, reh.bom_id, reh.cost_id
	                            , reh.revision_num, reh.purchased_flag, reh.total_amount
	                            , bom.bom_number, cst.cost_code, reh.approver_id
								, reqt.DESCRIPTION as requester_name, reqa.DESCRIPTION as approver_name
                                , reh.status, reh.submit_flag, reh.approved_flag
                                , reh.sent_po_confirm_flag , reh.po_confirm_flag
                            FROM po_requisition_headers_all reh
                              LEFT JOIN prj_boms bom on(reh.bom_id = bom.bom_id)
                              LEFT JOIN prj_cost_groups cst ON(reh.cost_id = cst.cost_id)
							  LEFT JOIN fnd_users reqt ON(reh.requester_id = reqt.USER_ID)
							  LEFT JOIN fnd_users reqa ON(reh.approver_id = reqa.USER_ID)
                            WHERE reh.requisition_header_id = @requisition_header_id";

            return db.Read(sql, MakeWithStats).ToList();
        }

        public RequisitionHeaderModel GetByNumber(string number)
        {
            string sql = @"SELECT requisition_header_id, reh.requisition_number, reh.requisition_date
	                            , reh.requester_id, reh.type_lookup_code, reh.job_process_flag
	                            , reh.last_update_date, reh.last_updated_by, reh.segment1
	                            , reh.summary_flag, reh.enabled_flag, reh.segment2
	                            , reh.segment3, reh.segment4, reh.segment5
	                            , reh.project_number, reh.start_date_active, reh.end_date_active
	                            , reh.last_update_login, reh.creation_date, reh.created_by
	                            , reh.description, reh.attribute1, reh.attribute2
	                            , reh.attribute3, reh.attribute4, reh.attribute5
	                            , reh.cancel_flag, reh.org_id, reh.authorization_status
	                            , reh.note_to_authorizer, reh.approved_date, reh.bom_id, reh.cost_id
	                            , reh.revision_num, reh.purchased_flag, reh.total_amount
	                            , bom.bom_number, cst.cost_code, reh.approver_id
								, reqt.DESCRIPTION as requester_name, reqa.DESCRIPTION as approver_name
                                , reh.status, reh.submit_flag, reh.approved_flag
                                , reh.sent_po_confirm_flag , reh.po_confirm_flag
                            FROM po_requisition_headers_all reh
                              LEFT JOIN prj_boms bom on(reh.bom_id = bom.bom_id)
                              LEFT JOIN prj_cost_groups cst ON(reh.cost_id = cst.cost_id)
							  LEFT JOIN fnd_users reqt ON(reh.requester_id = reqt.USER_ID)
							  LEFT JOIN fnd_users reqa ON(reh.approver_id = reqa.USER_ID)
                            WHERE reh.requisition_number = @requisition_number
                              AND reh.approved_flag = 'Y'";

            object[] parms = { "@requisition_number", number };
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public List<RequisitionHeaderModel> GetByDate(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT requisition_header_id, reh.requisition_number, reh.requisition_date
	                            , reh.requester_id, reh.type_lookup_code, reh.job_process_flag
	                            , reh.last_update_date, reh.last_updated_by, reh.segment1
	                            , reh.summary_flag, reh.enabled_flag, reh.segment2
	                            , reh.segment3, reh.segment4, reh.segment5
	                            , reh.project_number, reh.start_date_active, reh.end_date_active
	                            , reh.last_update_login, reh.creation_date, reh.created_by
	                            , reh.description, reh.attribute1, reh.attribute2
	                            , reh.attribute3, reh.attribute4, reh.attribute5
	                            , reh.cancel_flag, reh.org_id, reh.authorization_status
	                            , reh.note_to_authorizer, reh.approved_date, reh.bom_id, reh.cost_id
	                            , reh.revision_num, reh.purchased_flag, reh.total_amount
	                            , bom.bom_number, cst.cost_code, reh.approver_id
								, reqt.DESCRIPTION as requester_name, reqa.DESCRIPTION as approver_name
                                , reh.status, reh.submit_flag, reh.approved_flag
                                , reh.sent_po_confirm_flag , reh.po_confirm_flag
                            FROM po_requisition_headers_all reh
                              LEFT JOIN prj_boms bom on(reh.bom_id = bom.bom_id)
                              LEFT JOIN prj_cost_groups cst ON(reh.cost_id = cst.cost_id)
							  LEFT JOIN fnd_users reqt ON(reh.requester_id = reqt.USER_ID)
							  LEFT JOIN fnd_users reqa ON(reh.approver_id = reqa.USER_ID)
                            WHERE cast(reh.requisition_date as date) BETWEEN cast(@StartDate as date) AND cast(@EndDate as date)
                            ORDER BY reh.requisition_date ASC";

            object[] parms = { "@StartDate", startDate, "@EndDate", endDate };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public RequisitionHeaderModel GetByID(int id)
        {
            string sql = @"SELECT requisition_header_id, reh.requisition_number, reh.requisition_date
	                            , reh.requester_id, reh.type_lookup_code, reh.job_process_flag
	                            , reh.last_update_date, reh.last_updated_by, reh.segment1
	                            , reh.summary_flag, reh.enabled_flag, reh.segment2
	                            , reh.segment3, reh.segment4, reh.segment5
	                            , reh.project_number, reh.start_date_active, reh.end_date_active
	                            , reh.last_update_login, reh.creation_date, reh.created_by
	                            , reh.description, reh.attribute1, reh.attribute2
	                            , reh.attribute3, reh.attribute4, reh.attribute5
	                            , reh.cancel_flag, reh.org_id, reh.authorization_status
	                            , reh.note_to_authorizer, reh.approved_date, reh.bom_id, reh.cost_id
	                            , reh.revision_num, reh.purchased_flag, reh.total_amount
	                            , bom.bom_number, cst.cost_code, reh.approver_id
								, reqt.DESCRIPTION as requester_name, reqa.DESCRIPTION as approver_name
                                , reh.status, reh.submit_flag, reh.approved_flag
                                , reh.sent_po_confirm_flag , reh.po_confirm_flag
                            FROM po_requisition_headers_all reh
                              LEFT JOIN prj_boms bom on(reh.bom_id = bom.bom_id)
                              LEFT JOIN prj_cost_groups cst ON(reh.cost_id = cst.cost_id)
							  LEFT JOIN fnd_users reqt ON(reh.requester_id = reqt.USER_ID)
							  LEFT JOIN fnd_users reqa ON(reh.approver_id = reqa.USER_ID)
                            WHERE reh.requisition_header_id = @requisition_header_id";

            object[] parms = { "@requisition_header_id", id };
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public List<RequisitionHeaderModel> GetByProjectNumber(string prjNumber)
        {
            string sql = @"SELECT requisition_header_id, reh.requisition_number, reh.requisition_date
	                            , reh.requester_id, reh.type_lookup_code, reh.job_process_flag
	                            , reh.last_update_date, reh.last_updated_by, reh.segment1
	                            , reh.summary_flag, reh.enabled_flag, reh.segment2
	                            , reh.segment3, reh.segment4, reh.segment5
	                            , reh.project_number, reh.start_date_active, reh.end_date_active
	                            , reh.last_update_login, reh.creation_date, reh.created_by
	                            , reh.description, reh.attribute1, reh.attribute2
	                            , reh.attribute3, reh.attribute4, reh.attribute5
	                            , reh.cancel_flag, reh.org_id, reh.authorization_status
	                            , reh.note_to_authorizer, reh.approved_date, reh.bom_id, reh.cost_id
	                            , reh.revision_num, reh.purchased_flag, reh.total_amount
	                            , bom.bom_number, cst.cost_code, reh.approver_id
								, reqt.DESCRIPTION as requester_name, reqa.DESCRIPTION as approver_name
                                , reh.status, reh.submit_flag, reh.approved_flag
                                , reh.sent_po_confirm_flag , reh.po_confirm_flag
                            FROM po_requisition_headers_all reh
                              LEFT JOIN prj_boms bom on(reh.bom_id = bom.bom_id)
                              LEFT JOIN prj_cost_groups cst ON(reh.cost_id = cst.cost_id)
							  LEFT JOIN fnd_users reqt ON(reh.requester_id = reqt.USER_ID)
							  LEFT JOIN fnd_users reqa ON(reh.approver_id = reqa.USER_ID)
                            WHERE reh.project_number = @project_number";

            object[] parms = { "@project_number", prjNumber };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public int Insert(RequisitionHeaderModel model)
        {
            string sql =
                @"INSERT INTO po_requisition_headers_all
		                (requisition_number, requisition_date, requester_id
		                , type_lookup_code, job_process_flag, last_update_date
		                , last_updated_by, segment1, summary_flag
		                , enabled_flag, segment2, segment3
		                , segment4, segment5, project_number
		                , start_date_active, end_date_active, last_update_login
		                , creation_date, created_by, description
		                , attribute1, attribute2, attribute3
		                , attribute4, attribute5, cancel_flag
		                , org_id, authorization_status, note_to_authorizer
		                , approved_date, bom_id, cost_id, revision_num
		                , purchased_flag, total_amount, approver_id, status
                        , submit_flag, approved_flag
                        , sent_po_confirm_flag , po_confirm_flag)
		             VALUES
		                (@requisition_number, @requisition_date, @requester_id
		                , @type_lookup_code, @job_process_flag, @last_update_date
		                , @last_updated_by, @segment1, @summary_flag
		                , @enabled_flag, @segment2, @segment3
		                , @segment4, @segment5, @project_number
		                , @start_date_active, @end_date_active, @last_update_login
		                , @creation_date, @created_by, @description
		                , @attribute1, @attribute2, @attribute3
		                , @attribute4, @attribute5, @cancel_flag
		                , @org_id, @authorization_status, @note_to_authorizer
		                , @approved_date, @bom_id, @cost_id, @revision_num
		                , @purchased_flag, @total_amount, @approver_id, @status
                        , @submit_flag, @approved_flag
                        , @sent_po_confirm_flag , @po_confirm_flag)";

            return db.Insert(sql, Take(model));
        }

        public void Update(RequisitionHeaderModel model)
        {
            string sql =
            @"UPDATE po_requisition_headers_all
                   SET requisition_number = @requisition_number
                      ,requisition_date = @requisition_date
                      ,requester_id = @requester_id
                      ,type_lookup_code = @type_lookup_code
                      ,job_process_flag = @job_process_flag
                      ,last_update_date = @last_update_date
                      ,last_updated_by = @last_updated_by
                      ,segment1 = @segment1
                      ,summary_flag = @summary_flag
                      ,enabled_flag = @enabled_flag
                      ,segment2 = @segment2
                      ,segment3 = @segment3
                      ,segment4 = @segment4
                      ,segment5 = @segment5
                      ,project_number = @project_number
                      ,start_date_active = @start_date_active
                      ,end_date_active = @end_date_active
                      ,last_update_login = @last_update_login
                      ,creation_date = @creation_date
                      ,created_by = @created_by
                      ,description = @description
                      ,attribute1 = @attribute1
                      ,attribute2 = @attribute2
                      ,attribute3 = @attribute3
                      ,attribute4 = @attribute4
                      ,attribute5 = @attribute5
                      ,cancel_flag = @cancel_flag
                      ,org_id = @org_id
                      ,authorization_status = @authorization_status
                      ,note_to_authorizer = @note_to_authorizer
                      ,approved_date = @approved_date
                      ,bom_id = @bom_id
                      ,cost_id = @cost_id
                      ,revision_num = @revision_num
                      ,purchased_flag = @purchased_flag
                      ,total_amount = @total_amount
                      ,approver_id = @approver_id
                      ,status = @status
                      ,approved_flag = @approved_flag
                      ,submit_flag = @submit_flag
                      ,sent_po_confirm_flag = @sent_po_confirm_flag
                      ,po_confirm_flag = @po_confirm_flag
                 WHERE requisition_header_id = @requisition_header_id";

            db.Update(sql, Take(model));
        }

        public void Delete(RequisitionHeaderModel model)
        {
            string sql = @"DELETE FROM po_requisition_headers_all WHERE requisition_header_id = @requisition_header_id";

            object[] parms = { "@requisition_header_id", model.RequisitionHeaderId };
            db.Update(sql, parms);
        }

        //creates a Members object with order statistics based on DataReader              
        private static Func<IDataReader, RequisitionHeaderModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            row.CostCode = reader["cost_code"].AsString();
            row.BomNumber = reader["bom_number"].AsString();
            row.RequesterName = reader["requester_name"].AsString();
            row.ApproverName = reader["approver_name"].AsString();
            return row;
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, RequisitionHeaderModel> Make = reader =>
             new RequisitionHeaderModel
             {
                 RequisitionHeaderId = reader["requisition_header_id"].AsInt(),
                 RequisitionNumber = reader["requisition_number"].AsString(),
                 RequisitionDate = reader["requisition_date"].AsDateTime(),
                 RequesterId = reader["requester_id"].AsInt(),
                 TypeLookupCode = reader["type_lookup_code"].AsString(),
                 JobProcessFlag = (reader["job_process_flag"].AsString() == "Y") ? true : false,
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 Segment1 = reader["segment1"].AsString(),
                 SummaryFlag = reader["summary_flag"].AsString(),
                 EnabledFlag = reader["enabled_flag"].AsString(),
                 Segment2 = reader["segment2"].AsString(),
                 Segment3 = reader["segment3"].AsString(),
                 Segment4 = reader["segment4"].AsString(),
                 Segment5 = reader["segment5"].AsString(),
                 ProjectNo = reader["project_number"].AsString(),
                 StartDateActive = (reader["start_date_active"] != DBNull.Value) ? reader["start_date_active"].AsDateTime() : (DateTime?)null,
                 EndDateActive = (reader["end_date_active"] != DBNull.Value) ? reader["end_date_active"].AsDateTime() : (DateTime?)null,
                 LastUpdateLogin = reader["last_update_login"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 Description = reader["description"].AsString(),
                 Attribute1 = reader["attribute1"].AsString(),
                 Attribute2 = reader["attribute2"].AsString(),
                 Attribute3 = reader["attribute3"].AsString(),
                 Attribute4 = reader["attribute4"].AsString(),
                 Attribute5 = reader["attribute5"].AsString(),
                 CancelFlag = (reader["cancel_flag"].AsString() == "Y") ? true : false,
                 OrgId = reader["org_id"].AsInt(),
                 AuthorizationStatus = reader["authorization_status"].AsString(),
                 NoteToAuthorizer = reader["note_to_authorizer"].AsString(),
                 ApprovedDate = (reader["approved_date"] != DBNull.Value) ? reader["approved_date"].AsDateTime() : (DateTime?)null,
                 BomId = reader["bom_id"].AsInt(),
                 CostId = reader["cost_id"].AsInt(),
                 RevisionNum = reader["revision_num"].AsInt(),
                 PurchasedFlag = (reader["purchased_flag"].AsString() == "Y") ? true : false,
                 TotalAmount = reader["total_amount"].AsDouble(),
                 ApproverId = reader["approver_id"].AsInt(),
                 Status = reader["status"].AsString(),
                 ApprovedFlag = (reader["approved_flag"].AsString() == "Y") ? true : false,
                 SubmitFlag = (reader["submit_flag"].AsString() == "Y") ? true : false,
                 SentPoConfirmFlag = (reader["sent_po_confirm_flag"].AsString() == "Y") ? true : false,
                 PoConfirmedFlag = (reader["po_confirm_flag"].AsString() == "Y") ? true : false
             };

        private object[] Take(RequisitionHeaderModel model)
        {
            return new object[]
            {
                "@requisition_header_id", model.RequisitionHeaderId,
                "@requisition_number", model.RequisitionNumber,
                "@requisition_date", model.RequisitionDate,
                "@requester_id", model.RequesterId,
                "@type_lookup_code", model.TypeLookupCode,
                "@job_process_flag", model.JobProcessFlag,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@segment1", model.Segment1,
                "@summary_flag", model.SummaryFlag,
                "@enabled_flag", model.EnabledFlag,
                "@segment2", model.Segment2,
                "@segment3", model.Segment3,
                "@segment4", model.Segment4,
                "@segment5", model.Segment5,
                "@project_number", model.ProjectNo,
                "@start_date_active", model.StartDateActive,
                "@end_date_active", model.EndDateActive,
                "@last_update_login", model.LastUpdateLogin,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@description", model.Description,
                "@attribute1", model.Attribute1,
                "@attribute2", model.Attribute2,
                "@attribute3", model.Attribute3,
                "@attribute4", model.Attribute4,
                "@attribute5", model.Attribute5,
                "@cancel_flag", (model.CancelFlag) ? "Y" : "N",
                "@org_id", model.OrgId,
                "@authorization_status", model.AuthorizationStatus,
                "@note_to_authorizer", model.NoteToAuthorizer,
                "@approved_date", model.ApprovedDate,
                "@bom_id", model.BomId,
                "@cost_id", model.CostId,
                "@revision_num", model.RevisionNum,
                "@purchased_flag", (model.PurchasedFlag) ? "Y" : "N",
                "@total_amount", model.TotalAmount,
                "@approver_id", model.ApproverId,
                "@status", model.Status,
                "@approved_flag", (model.ApprovedFlag) ? "Y" : "N",
                "@submit_flag", (model.SubmitFlag) ? "Y" : "N",
                "@sent_po_confirm_flag", (model.SentPoConfirmFlag) ? "Y" : "N",
                "@po_confirm_flag", (model.PoConfirmedFlag) ? "Y" : "N"
            };
        }
    }
}
