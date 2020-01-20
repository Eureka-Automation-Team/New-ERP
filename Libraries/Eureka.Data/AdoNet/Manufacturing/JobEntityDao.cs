using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eureka.Core.Domain.Manufacturing;

namespace Eureka.Data.AdoNet.Manufacturing
{
    public class JobEntityDao : IJobEntityDao
    {
        private static Db db = new Db("ms_sql_job");

        public List<JobEntityModel> GetAll()
        {
            string sql = @"SELECT jb.job_entity_id, jb.organization_id, jb.last_update_date
                            , jb.last_updated_by, jb.creation_date, jb.created_by
                            , jb.job_entity_name, jb.job_entiry_date, jb.entity_type
                            , jb.description, jb.primary_item_id, jb.primary_item_code
                            , jb.primary_item_model, jb.segment1, jb.segment2
                            , jb.segment3, jb.segment4, jb.segment5
                            , jb.open_status, jb.cancel_flag, jb.primary_quantity
                            , jb.process_flag, jb.completed_flag, jb.po_header_id, jb.po_line_id
                          FROM mfg_job_entities jb
                          ORDER BY jb.job_entiry_date ASC";

            return db.Read(sql, Make).ToList();
        }

        public List<JobEntityModel> GetByDate(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT jb.job_entity_id, jb.organization_id, jb.last_update_date
                            , jb.last_updated_by, jb.creation_date, jb.created_by
                            , jb.job_entity_name, jb.job_entiry_date, jb.entity_type
                            , jb.description, jb.primary_item_id, jb.primary_item_code
                            , jb.primary_item_model, jb.segment1, jb.segment2
                            , jb.segment3, jb.segment4, jb.segment5
                            , jb.open_status, jb.cancel_flag, jb.primary_quantity
                            , jb.process_flag, jb.completed_flag, jb.po_header_id, jb.po_line_id
                          FROM mfg_job_entities jb
                            WHERE cast(jb.job_entiry_date as date) BETWEEN cast(@StartDate as date) AND cast(@EndDate as date)
                            ORDER BY jb.job_entiry_date ASC";

            object[] parms = { "@StartDate", startDate, "@EndDate", endDate };
            return db.Read(sql, Make, parms).ToList();
        }

        public JobEntityModel GetByID(int id)
        {
            string sql = @"SELECT jb.job_entity_id, jb.organization_id, jb.last_update_date
                            , jb.last_updated_by, jb.creation_date, jb.created_by
                            , jb.job_entity_name, jb.job_entiry_date, jb.entity_type
                            , jb.description, jb.primary_item_id, jb.primary_item_code
                            , jb.primary_item_model, jb.segment1, jb.segment2
                            , jb.segment3, jb.segment4, jb.segment5
                            , jb.open_status, jb.cancel_flag, jb.primary_quantity
                            , jb.process_flag, jb.completed_flag, jb.po_header_id, jb.po_line_id
                          FROM mfg_job_entities jb
                            WHERE jb.job_entity_id = @job_entity_id";

            object[] parms = { "@job_entity_id", id};
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public JobEntityModel GetByPOLineID(int poLineId)
        {
            string sql = @"SELECT jb.job_entity_id, jb.organization_id, jb.last_update_date
                            , jb.last_updated_by, jb.creation_date, jb.created_by
                            , jb.job_entity_name, jb.job_entiry_date, jb.entity_type
                            , jb.description, jb.primary_item_id, jb.primary_item_code
                            , jb.primary_item_model, jb.segment1, jb.segment2
                            , jb.segment3, jb.segment4, jb.segment5
                            , jb.open_status, jb.cancel_flag, jb.primary_quantity
                            , jb.process_flag, jb.completed_flag, jb.po_header_id, jb.po_line_id
                          FROM mfg_job_entities jb
                            WHERE jb.job_entity_id = @job_entity_id";

            object[] parms = { "@po_line_id", poLineId };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public JobEntityModel GetByJobName(string jobName)
        {
            string sql = @"SELECT jb.job_entity_id, jb.organization_id, jb.last_update_date
                            , jb.last_updated_by, jb.creation_date, jb.created_by
                            , jb.job_entity_name, jb.job_entiry_date, jb.entity_type
                            , jb.description, jb.primary_item_id, jb.primary_item_code
                            , jb.primary_item_model, jb.segment1, jb.segment2
                            , jb.segment3, jb.segment4, jb.segment5
                            , jb.open_status, jb.cancel_flag, jb.primary_quantity
                            , jb.process_flag, jb.completed_flag, jb.po_header_id, jb.po_line_id
                          FROM mfg_job_entities jb
                            WHERE jb.job_entity_name = @job_entity_name";

            object[] parms = { "@job_entity_name", jobName };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(JobEntityModel model)
        {
            string sql =
                @"INSERT INTO mfg_job_entities
                           (organization_id
                           ,last_update_date
                           ,last_updated_by
                           ,creation_date
                           ,created_by
                           ,job_entity_name
                           ,job_entiry_date
                           ,entity_type
                           ,description
                           ,primary_item_id
                           ,primary_item_code
                           ,primary_item_model
                           ,primary_quantity
                           ,segment1
                           ,segment2
                           ,segment3
                           ,segment4
                           ,segment5
                           ,open_status
                           ,cancel_flag
                           ,process_flag
                           ,completed_flag
                           ,po_header_id
                           ,po_line_id)
                     VALUES
                           (@organization_id
                           ,@last_update_date
                           ,@last_updated_by
                           ,@creation_date
                           ,@created_by
                           ,@job_entity_name
                           ,@job_entiry_date
                           ,@entity_type
                           ,@description
                           ,@primary_item_id
                           ,@primary_item_code
                           ,@primary_item_model
                           ,@primary_quantity
                           ,@segment1
                           ,@segment2
                           ,@segment3
                           ,@segment4
                           ,@segment5
                           ,@open_status
                           ,@cancel_flag
                           ,@process_flag
                           ,@completed_flag
                           ,@po_header_id
                           ,@po_line_id)";

            return db.Insert(sql, Take(model));
        }

        public void Update(JobEntityModel model)
        {
            string sql =
            @"UPDATE mfg_job_entities
                   SET organization_id = @organization_id
                      ,last_update_date = @last_update_date
                      ,last_updated_by = @last_updated_by
                      ,creation_date = @creation_date
                      ,created_by = @created_by
                      ,job_entity_name = @job_entity_name
                      ,job_entiry_date = @job_entiry_date
                      ,entity_type = @entity_type
                      ,description = @description
                      ,primary_item_id = @primary_item_id
                      ,primary_item_code = @primary_item_code
                      ,primary_item_model = @primary_item_model
                      ,primary_quantity = @primary_quantity
                      ,segment1 = @segment1
                      ,segment2 = @segment2
                      ,segment3 = @segment3
                      ,segment4 = @segment4
                      ,segment5 = @segment5
                      ,open_status = @open_status
                      ,cancel_flag = @cancel_flag
                      ,process_flag = @process_flag
                      ,completed_flag = @completed_flag
                      ,po_header_id = @po_header_id
                      ,po_line_id = @po_line_id
                 WHERE job_entity_id = @job_entity_id";

            db.Update(sql, Take(model));
        }

        public void Delete(JobEntityModel model)
        {
            string sql = @"DELETE FROM mfg_job_entities WHERE job_entity_id = @job_entity_id";

            object[] parms = { "@job_entity_id", model.JobEntityId };
            db.Update(sql, parms);
        }

        // creates a Members object with order statistics based on DataReader       
        private static Func<IDataReader, JobEntityModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            //row.ItemCode = reader["segment1"].AsString();
            //row.ManuID = reader["segment2"].AsString();
            //row.BrandMat = reader["segment3"].AsString();
            //row.ItemDescription = reader["item_description"].AsString();
            return row;
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, JobEntityModel> Make = reader =>
             new JobEntityModel
             {
                 JobEntityId = reader["job_entity_id"].AsInt(),
                 OrganizationId = reader["organization_id"].AsInt(),
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 JobEntityName = reader["job_entity_name"].AsString(),
                 EntityType = reader["entity_type"].AsInt(),
                 JobEntiryDate = reader["job_entiry_date"].AsDateTime(),
                 Description = reader["description"].AsString(),
                 PrimaryItemId = reader["primary_item_id"].AsInt(),
                 PrimaryItemCode = reader["primary_item_code"].AsString(),
                 PrimaryItemModel = reader["primary_item_model"].AsString(),
                 PrimaryQuantity = reader["primary_quantity"].AsDouble(),
                 Segment1 = reader["segment1"].AsString(),
                 Segment2 = reader["segment2"].AsString(),
                 Segment3 = reader["segment3"].AsString(),
                 Segment4 = reader["segment4"].AsString(),
                 Segment5 = reader["segment5"].AsString(),
                 OpenStatus = (reader["open_status"].AsString() == "Y") ? true : false,
                 ProcessFlag = (reader["process_flag"].AsString() == "Y") ? true : false,
                 CompletedFlag = (reader["completed_flag"].AsString() == "Y") ? true : false,
                 CancelFlag = (reader["cancel_flag"].AsString() == "Y") ? true : false,
                 PoHeaderId = reader["po_header_id"].AsInt(),
                 PoLineId = reader["po_line_id"].AsInt()
             };

        private object[] Take(JobEntityModel model)
        {
            return new object[]
            {
                "@job_entity_id", model.JobEntityId,
                "@organization_id", model.OrganizationId,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@job_entity_name", model.JobEntityName,
                "@job_entiry_date", model.JobEntiryDate,
                "@entity_type", model.EntityType,
                "@description", model.Description,
                "@primary_item_id", model.PrimaryItemId,
                "@primary_item_code", model.PrimaryItemCode,
                "@primary_item_model", model.PrimaryItemModel,
                "@primary_quantity", model.PrimaryQuantity,
                "@segment1", model.Segment1,
                "@segment2", model.Segment2,
                "@segment3", model.Segment3,
                "@segment4", model.Segment4,
                "@segment5", model.Segment5,
                "@open_status", (model.OpenStatus) ? "Y" : "N",
                "@process_flag", (model.ProcessFlag) ? "Y" : "N",
                "@completed_flag", (model.CompletedFlag) ? "Y" : "N",
                "@cancel_flag", (model.CancelFlag) ? "Y" : "N",
                "@po_header_id", model.PoHeaderId,
                "@po_line_id", model.PoLineId
            };
        }
    }
}
