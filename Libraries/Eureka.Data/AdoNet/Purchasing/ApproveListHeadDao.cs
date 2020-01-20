using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Purchasing;

namespace Eureka.Data.AdoNet.Purchasing
{
    public class ApproveListHeadDao : IApproveListHeadDao
    {
        private static Db db = new Db("ms_sql");

        public void Delete(ApproveListHeadModel model)
        {
            string sql = @"DELETE FROM po_approval_list_headers WHERE approval_list_header_id = @approval_list_header_id";

            object[] parms = { "@approval_list_header_id", model.ApprovalListHeaderId };
            db.Update(sql, parms);
        }

        public List<ApproveListHeadModel> GetAll()
        {
            string sql = @"SELECT apv.approval_list_header_id
                              , apv.document_id
                              , apv.document_type
                              , apv.revision
                              , apv.latest_revision
                              , apv.first_approver_id
                              , apv.approval_path_id
                              , apv.created_by
                              , apv.creation_date
                              , apv.last_updated_by
                              , apv.last_update_date
                              , apv.final_flag
                          FROM po_approval_list_headers apv
                          ORDER BY apv.approval_list_header_id DESC";

            return db.Read(sql, Make).ToList();
        }

        public List<ApproveListHeadModel> GetByDate(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT apv.approval_list_header_id
                              , apv.document_id
                              , apv.document_type
                              , apv.revision
                              , apv.latest_revision
                              , apv.first_approver_id
                              , apv.approval_path_id
                              , apv.created_by
                              , apv.creation_date
                              , apv.last_updated_by
                              , apv.last_update_date
                              , apv.final_flag
                          FROM po_approval_list_headers apv
                          WHERE cast(apv.creation_date as date) BETWEEN cast(@StartDate as date) AND cast(@EndDate as date)
                          ORDER BY apv.approval_list_header_id ASC";

            object[] parms = { "@StartDate", startDate, "@EndDate", endDate };
            return db.Read(sql, Make, parms).ToList();
        }

        public ApproveListHeadModel GetByID(int id)
        {
            string sql = @"SELECT apv.approval_list_header_id
                              , apv.document_id
                              , apv.document_type
                              , apv.revision
                              , apv.latest_revision
                              , apv.first_approver_id
                              , apv.approval_path_id
                              , apv.created_by
                              , apv.creation_date
                              , apv.last_updated_by
                              , apv.last_update_date
                              , apv.final_flag
                          FROM po_approval_list_headers apv
                          WHERE apv.approval_list_header_id = @approval_list_header_id";

            object[] parms = { "@approval_list_header_id", id};
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public ApproveListHeadModel GetByPOID(int id)
        {
            string sql = @"SELECT apv.approval_list_header_id
                              , apv.document_id
                              , apv.document_type
                              , apv.revision
                              , apv.latest_revision
                              , apv.first_approver_id
                              , apv.approval_path_id
                              , apv.created_by
                              , apv.creation_date
                              , apv.last_updated_by
                              , apv.last_update_date
                              , apv.final_flag
                          FROM po_approval_list_headers apv
                          WHERE apv.document_id = @document_id AND apv.document_type = 'PURCHASE'";

            object[] parms = { "@document_id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(ApproveListHeadModel model)
        {
            string sql =
                @"INSERT INTO po_approval_list_headers
                           (document_id
                           ,document_type
                           ,revision
                           ,latest_revision
                           ,first_approver_id
                           ,approval_path_id
                           ,created_by
                           ,creation_date
                           ,last_updated_by
                           ,last_update_date
                           ,final_flag)
                     VALUES
                           (@document_id
                           ,@document_type
                           ,@revision
                           ,@latest_revision
                           ,@first_approver_id
                           ,@approval_path_id
                           ,@created_by
                           ,@creation_date
                           ,@last_updated_by
                           ,@last_update_date
                           ,@final_flag)";

            return db.Insert(sql, Take(model));
        }

        public void Update(ApproveListHeadModel model)
        {
            string sql =
            @"UPDATE po_approval_list_headers
               SET document_id = @document_id
                  ,document_type = @document_type
                  ,revision = @revision
                  ,latest_revision = @latest_revision
                  ,first_approver_id = @first_approver_id
                  ,approval_path_id = @approval_path_id
                  ,last_updated_by = @last_updated_by
                  ,last_update_date = @last_update_date
                  ,final_flag = @final_flag
             WHERE approval_list_header_id = @approval_list_header_id";

            db.Update(sql, Take(model));
        }

        // creates a Member object based on DataReader
        private static Func<IDataReader, ApproveListHeadModel> Make = reader =>
             new ApproveListHeadModel
             {
                 ApprovalListHeaderId = reader["approval_list_header_id"].AsInt(),
                 DocumentId = reader["document_id"].AsInt(),
                 DocumentType = reader["document_type"].AsString(),
                 Revision = reader["revision"].AsInt(),
                 LatestRevision = reader["latest_revision"].AsString(),
                 FirstApproverId = reader["first_approver_id"].AsInt(),
                 ApprovalPathId = reader["approval_path_id"].AsInt(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt()
             };

        private object[] Take(ApproveListHeadModel model)
        {
            return new object[]
            {
                "@approval_list_header_id", model.ApprovalListHeaderId,
                "@document_id", model.DocumentId,
                "@document_type", model.DocumentType,
                "@revision", model.Revision,
                "@latest_revision", model.LatestRevision,
                "@first_approver_id", model.FirstApproverId,
                "@approval_path_id", model.ApprovalPathId,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy
            };
        }
    }
}
