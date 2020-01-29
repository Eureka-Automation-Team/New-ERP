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
            string sql = @"SELECT jb.JobEntityId, jb.OrganizationId, jb.LastUpdateDate
                            , jb.LastUpdatedBy, jb.CreationDate, jb.CreatedBy
                            , jb.JobEntityName, jb.JobEntiryDate, jb.EntityType
                            , jb.Description, jb.PrimaryItemId, jb.PrimaryItemCode
                            , jb.PrimaryItemModel, jb.Segment1, jb.Segment2
                            , jb.Segment3, jb.Segment4, jb.Segment5
                            , jb.OpenStatus, jb.CancelFlag, jb.PrimaryQuantity
                            , jb.ProcessFlag, jb.CompletedFlag, jb.PoHeaderId, jb.PoLineId
                          FROM JobEntities jb
                          ORDER BY jb.JobEntiryDate ASC";

            return db.Read(sql, Make).ToList();
        }

        public List<JobEntityModel> GetByDate(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT jb.JobEntityId, jb.OrganizationId, jb.LastUpdateDate
                            , jb.LastUpdatedBy, jb.CreationDate, jb.CreatedBy
                            , jb.JobEntityName, jb.JobEntiryDate, jb.EntityType
                            , jb.Description, jb.PrimaryItemId, jb.PrimaryItemCode
                            , jb.PrimaryItemModel, jb.Segment1, jb.Segment2
                            , jb.Segment3, jb.Segment4, jb.Segment5
                            , jb.OpenStatus, jb.CancelFlag, jb.PrimaryQuantity
                            , jb.ProcessFlag, jb.CompletedFlag, jb.PoHeaderId, jb.PoLineId
                          FROM JobEntities jb
                            WHERE cast(jb.JobEntiryDate as date) BETWEEN cast(@StartDate as date) AND cast(@EndDate as date)
                            ORDER BY jb.JobEntiryDate ASC";

            object[] parms = { "@StartDate", startDate, "@EndDate", endDate };
            return db.Read(sql, Make, parms).ToList();
        }

        public JobEntityModel GetByID(int id)
        {
            string sql = @"SELECT jb.JobEntityId, jb.OrganizationId, jb.LastUpdateDate
                            , jb.LastUpdatedBy, jb.CreationDate, jb.CreatedBy
                            , jb.JobEntityName, jb.JobEntiryDate, jb.EntityType
                            , jb.Description, jb.PrimaryItemId, jb.PrimaryItemCode
                            , jb.PrimaryItemModel, jb.Segment1, jb.Segment2
                            , jb.Segment3, jb.Segment4, jb.Segment5
                            , jb.OpenStatus, jb.CancelFlag, jb.PrimaryQuantity
                            , jb.ProcessFlag, jb.CompletedFlag, jb.PoHeaderId, jb.PoLineId
                          FROM JobEntities jb
                            WHERE jb.JobEntityId = @JobEntityId";

            object[] parms = { "@JobEntityId", id};
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public JobEntityModel GetByPOLineID(int poLineId)
        {
            string sql = @"SELECT jb.JobEntityId, jb.OrganizationId, jb.LastUpdateDate
                            , jb.LastUpdatedBy, jb.CreationDate, jb.CreatedBy
                            , jb.JobEntityName, jb.JobEntiryDate, jb.EntityType
                            , jb.Description, jb.PrimaryItemId, jb.PrimaryItemCode
                            , jb.PrimaryItemModel, jb.Segment1, jb.Segment2
                            , jb.Segment3, jb.Segment4, jb.Segment5
                            , jb.OpenStatus, jb.CancelFlag, jb.PrimaryQuantity
                            , jb.ProcessFlag, jb.CompletedFlag, jb.PoHeaderId, jb.PoLineId
                          FROM JobEntities jb
                            WHERE jb.JobEntityId = @JobEntityId";

            object[] parms = { "@PoLineId", poLineId };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public JobEntityModel GetByJobName(string jobName)
        {
            string sql = @"SELECT jb.JobEntityId, jb.OrganizationId, jb.LastUpdateDate
                            , jb.LastUpdatedBy, jb.CreationDate, jb.CreatedBy
                            , jb.JobEntityName, jb.JobEntiryDate, jb.EntityType
                            , jb.Description, jb.PrimaryItemId, jb.PrimaryItemCode
                            , jb.PrimaryItemModel, jb.Segment1, jb.Segment2
                            , jb.Segment3, jb.Segment4, jb.Segment5
                            , jb.OpenStatus, jb.CancelFlag, jb.PrimaryQuantity
                            , jb.ProcessFlag, jb.CompletedFlag, jb.PoHeaderId, jb.PoLineId
                          FROM JobEntities jb
                            WHERE jb.JobEntityName = @JobEntityName";

            object[] parms = { "@JobEntityName", jobName };
            return db.Read(sql, Make, parms).FirstOrDefault();
        }

        public int Insert(JobEntityModel model)
        {
            string sql =
                @"INSERT INTO JobEntities
                           (OrganizationId
                           ,LastUpdateDate
                           ,LastUpdatedBy
                           ,CreationDate
                           ,CreatedBy
                           ,JobEntityName
                           ,JobEntiryDate
                           ,EntityType
                           ,Description
                           ,PrimaryItemId
                           ,PrimaryItemCode
                           ,PrimaryItemModel
                           ,PrimaryQuantity
                           ,Segment1
                           ,segment2
                           ,segment3
                           ,segment4
                           ,segment5
                           ,OpenStatus
                           ,CancelFlag
                           ,ProcessFlag
                           ,CompletedFlag
                           ,PoHeaderId
                           ,PoLineId)
                     VALUES
                           (@OrganizationId
                           ,@LastUpdateDate
                           ,@LastUpdatedBy
                           ,@CreationDate
                           ,@CreatedBy
                           ,@JobEntityName
                           ,@JobEntiryDate
                           ,@EntityType
                           ,@Description
                           ,@PrimaryItemId
                           ,@PrimaryItemCode
                           ,@PrimaryItemModel
                           ,@PrimaryQuantity
                           ,@Segment1
                           ,@segment2
                           ,@segment3
                           ,@segment4
                           ,@segment5
                           ,@OpenStatus
                           ,@CancelFlag
                           ,@ProcessFlag
                           ,@CompletedFlag
                           ,@PoHeaderId
                           ,@PoLineId)";

            return db.Insert(sql, Take(model));
        }

        public void Update(JobEntityModel model)
        {
            string sql =
            @"UPDATE JobEntities
                   SET OrganizationId = @OrganizationId
                      ,LastUpdateDate = @LastUpdateDate
                      ,LastUpdatedBy = @LastUpdatedBy
                      ,CreationDate = @CreationDate
                      ,CreatedBy = @CreatedBy
                      ,JobEntityName = @JobEntityName
                      ,JobEntiryDate = @JobEntiryDate
                      ,EntityType = @EntityType
                      ,Description = @Description
                      ,PrimaryItemId = @PrimaryItemId
                      ,PrimaryItemCode = @PrimaryItemCode
                      ,PrimaryItemModel = @PrimaryItemModel
                      ,PrimaryQuantity = @PrimaryQuantity
                      ,Segment1 = @Segment1
                      ,segment2 = @segment2
                      ,segment3 = @segment3
                      ,segment4 = @segment4
                      ,segment5 = @segment5
                      ,OpenStatus = @OpenStatus
                      ,CancelFlag = @CancelFlag
                      ,ProcessFlag = @ProcessFlag
                      ,CompletedFlag = @CompletedFlag
                      ,PoHeaderId = @PoHeaderId
                      ,PoLineId = @PoLineId
                 WHERE JobEntityId = @JobEntityId";

            db.Update(sql, Take(model));
        }

        public void Delete(JobEntityModel model)
        {
            string sql = @"DELETE FROM JobEntities WHERE JobEntityId = @JobEntityId";

            object[] parms = { "@JobEntityId", model.JobEntityId };
            db.Update(sql, parms);
        }

        // creates a Members object with order statistics based on DataReader       
        private static Func<IDataReader, JobEntityModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            //row.ItemCode = reader["Segment1"].AsString();
            //row.ManuID = reader["segment2"].AsString();
            //row.BrandMat = reader["segment3"].AsString();
            //row.ItemDescription = reader["item_Description"].AsString();
            return row;
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, JobEntityModel> Make = reader =>
             new JobEntityModel
             {
                 JobEntityId = reader["JobEntityId"].AsInt(),
                 OrganizationId = reader["OrganizationId"].AsInt(),
                 LastUpdateDate = reader["LastUpdateDate"].AsDateTime(),
                 LastUpdatedBy = reader["LastUpdatedBy"].AsInt(),
                 CreationDate = reader["CreationDate"].AsDateTime(),
                 CreatedBy = reader["CreatedBy"].AsInt(),
                 JobEntityName = reader["JobEntityName"].AsString(),
                 EntityType = reader["EntityType"].AsInt(),
                 JobEntiryDate = reader["JobEntiryDate"].AsDateTime(),
                 Description = reader["Description"].AsString(),
                 PrimaryItemId = reader["PrimaryItemId"].AsInt(),
                 PrimaryItemCode = reader["PrimaryItemCode"].AsString(),
                 PrimaryItemModel = reader["PrimaryItemModel"].AsString(),
                 PrimaryQuantity = reader["PrimaryQuantity"].AsDouble(),
                 Segment1 = reader["Segment1"].AsString(),
                 Segment2 = reader["segment2"].AsString(),
                 Segment3 = reader["segment3"].AsString(),
                 Segment4 = reader["segment4"].AsString(),
                 Segment5 = reader["segment5"].AsString(),
                 OpenStatus = reader["OpenStatus"].AsBool(),
                 ProcessFlag = reader["ProcessFlag"].AsBool(),
                 CompletedFlag = reader["CompletedFlag"].AsBool(),
                 CancelFlag = reader["CancelFlag"].AsBool(),
                 PoHeaderId = reader["PoHeaderId"].AsInt(),
                 PoLineId = reader["PoLineId"].AsInt()
             };

        private object[] Take(JobEntityModel model)
        {
            return new object[]
            {
                "@JobEntityId", model.JobEntityId,
                "@OrganizationId", model.OrganizationId,
                "@LastUpdateDate", model.LastUpdateDate,
                "@LastUpdatedBy", model.LastUpdatedBy,
                "@CreationDate", model.CreationDate,
                "@CreatedBy", model.CreatedBy,
                "@JobEntityName", model.JobEntityName,
                "@JobEntiryDate", model.JobEntiryDate,
                "@EntityType", model.EntityType,
                "@Description", model.Description,
                "@PrimaryItemId", model.PrimaryItemId,
                "@PrimaryItemCode", model.PrimaryItemCode,
                "@PrimaryItemModel", model.PrimaryItemModel,
                "@PrimaryQuantity", model.PrimaryQuantity,
                "@Segment1", model.Segment1,
                "@segment2", model.Segment2,
                "@segment3", model.Segment3,
                "@segment4", model.Segment4,
                "@segment5", model.Segment5,
                "@OpenStatus", (model.OpenStatus) ? 1 : 0,
                "@ProcessFlag", (model.ProcessFlag) ? 1 : 0,
                "@CompletedFlag", (model.CompletedFlag) ? 1 : 0,
                "@CancelFlag", (model.CancelFlag) ? 1 : 0,
                "@PoHeaderId", model.PoHeaderId,
                "@PoLineId", model.PoLineId
            };
        }
    }
}
