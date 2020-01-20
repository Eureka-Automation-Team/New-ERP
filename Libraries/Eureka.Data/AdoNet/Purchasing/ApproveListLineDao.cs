using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Purchasing;

namespace Eureka.Data.AdoNet.Purchasing
{
    public class ApproveListLineDao : IApproveListLineDao
    {
        private static Db db = new Db("ms_sql");

        public void Delete(ApproveListLineModel model)
        {
            string sql = @"DELETE FROM po_approval_list_lines WHERE approval_list_line_id = @approval_list_line_id";

            object[] parms = { "@approval_list_line_id", model.ApprovalListLineId };
            db.Update(sql, parms);
        }

        public List<ApproveListLineModel> GetAll()
        {
            string sql = @"SELECT apl.approval_list_header_id
                              , apl.approval_list_line_id
                              , apl.approver_id
                              , apl.sequence_num
                              , apl.comments
                              , apl.status
                              , apl.created_by
                              , apl.creation_date
                              , apl.last_updated_by
                              , apl.last_update_date
                          FROM po_approval_list_lines apl
                          ORDER BY apl.approval_list_line_id DESC";

            return db.Read(sql, Make).ToList();
        }

        public List<ApproveListLineModel> GetByHeadID(int id)
        {
            string sql = @"SELECT apl.approval_list_header_id
                              , apl.approval_list_line_id
                              , apl.approver_id
                              , apl.sequence_num
                              , apl.comments
                              , apl.status
                              , apl.created_by
                              , apl.creation_date
                              , apl.last_updated_by
                              , apl.last_update_date
                          FROM po_approval_list_lines apl                          
                          WHERE apl.approval_list_header_id = @approval_list_header_id
                          ORDER BY apl.approval_list_line_id ASC";

            object[] parms = { "@approval_list_header_id", id };
            return db.Read(sql, Make, parms).ToList();
        }

        public ApproveListLineModel GetByID(int id)
        {
            string sql = @"SELECT apl.approval_list_header_id
                              , apl.approval_list_line_id
                              , apl.approver_id
                              , apl.sequence_num
                              , apl.comments
                              , apl.status
                              , apl.created_by
                              , apl.creation_date
                              , apl.last_updated_by
                              , apl.last_update_date
                          FROM po_approval_list_lines apl                          
                          WHERE apl.approval_list_line_id = @approval_list_line_id";

            object[] parms = { "@approval_list_line_id", id };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(ApproveListLineModel model)
        {
            string sql =
                @"INSERT INTO po_approval_list_lines
                           (approval_list_header_id
                           ,approver_id
                           ,sequence_num
                           ,comments
                           ,status
                           ,created_by
                           ,creation_date
                           ,last_updated_by
                           ,last_update_date)
                     VALUES
                           (@approval_list_header_id
                           ,@approver_id
                           ,@sequence_num
                           ,@comments
                           ,@status
                           ,@created_by
                           ,@creation_date
                           ,@last_updated_by
                           ,@last_update_date)";

            return db.Insert(sql, Take(model));
        }

        public void Update(ApproveListLineModel model)
        {
            string sql =
            @"UPDATE po_approval_list_lines
                   SET approval_list_header_id = @approval_list_header_id
                      ,approver_id = @approver_id
                      ,sequence_num = @sequence_num
                      ,comments = @comments
                      ,status = @status
                      ,last_updated_by = @last_updated_by
                      ,last_update_date = @last_update_date
                 WHERE approval_list_line_id = @approval_list_line_id";

            db.Update(sql, Take(model));
        }

        // creates a Member object based on DataReader
        private static Func<IDataReader, ApproveListLineModel> Make = reader =>
             new ApproveListLineModel
             {
                 ApprovalListHeaderId = reader["approval_list_header_id"].AsInt(),
                 ApprovalListLineId = reader["approval_list_line_id"].AsInt(),
                 ApproverId = reader["approver_id"].AsInt(),
                 SequenceNum = reader["sequence_num"].AsInt(),
                 Comments = reader["comments"].AsString(),
                 Status = reader["status"].AsString(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt()
             };

        private object[] Take(ApproveListLineModel model)
        {
            return new object[]
            {
                "@approval_list_header_id", model.ApprovalListHeaderId,
                "@approval_list_line_id", model.ApprovalListLineId,
                "@approver_id", model.ApproverId,
                "@sequence_num", model.SequenceNum,
                "@comments", model.Comments,
                "@status", model.Status,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy
            };
        }
    }
}
