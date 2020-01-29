using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Eureka.Core.Domain.Manufacturing;

namespace Eureka.Data.AdoNet.Manufacturing
{
    public class JobTaskDao : IJobTaskDao
    {
        private static Db db = new Db("ms_sql_job");

        public List<JobTaskModel> GetPendingTask()
        {
            string sql = @"SELECT  jt.TaskId, jt.TaskSeq, jt.JobEntityId
                                , jt.TaskNumber, jt.JobNumber, jt.Description
                                , jt.Manager, jt.StartDate, jt.EndDate
                                , jt.CancelFlag, jt.LastUpdateDate, jt.LastUpdatedBy
                                , jt.CreationDate, jt.CreatedBy, jt.ErrorText
                                , jt.ReadyFlag, jt.Source, jt.ShelfNumber
                                , jt.McProcessFlag, jt.McPickFlag, jt.McLoadFlag
                                , jt.McFinishFlag, jt.MaterialCode, jt.TableNumber
                                , jt.NcFile, jt.DueDate, jt.MachineNo
                                , jt.Priority, jt.McUnloadFlag, jt.McPushFlag
                                , jt.OnShelfFlag, jt.OutboundFlag, jt.QCStatus, jt.StandardTime
                                , jt.ReleaseFlag, jt.UploadNcfileFlag, jt.ReserveShelfFlag
                                , jt.OutboundFinishFlag, jt.StartFlag, jt.MachineNoReady
                                , jb.PrimaryItemCode, jb.PrimaryItemModel, jb.PrimaryQuantity
                                , jt.TransferNCFileToMachineFlag, jt.TransferMessage, jt.MachineId
                            FROM  JobTasks jt
                            LEFT JOIN JobEntities jb ON(jt.JobEntityId = jb.JobEntityId)
                            WHERE jt.ReleaseFlag = 0 AND jt.ReadyFlag = 1
                            ORDER BY jt.TaskSeq ASC";

            return db.Read(sql, MakeWithStats).ToList();
        }

        public List<JobTaskModel> GetInspectionTask()
        {
            string sql = @"SELECT  jt.TaskId, jt.TaskSeq, jt.JobEntityId
                                , jt.TaskNumber, jt.JobNumber, jt.Description
                                , jt.Manager, jt.StartDate, jt.EndDate
                                , jt.CancelFlag, jt.LastUpdateDate, jt.LastUpdatedBy
                                , jt.CreationDate, jt.CreatedBy, jt.ErrorText
                                , jt.ReadyFlag, jt.Source, jt.ShelfNumber
                                , jt.McProcessFlag, jt.McPickFlag, jt.McLoadFlag
                                , jt.McFinishFlag, jt.MaterialCode, jt.TableNumber
                                , jt.NcFile, jt.DueDate, jt.MachineNo
                                , jt.Priority, jt.McUnloadFlag, jt.McPushFlag
                                , jt.OnShelfFlag, jt.OutboundFlag, jt.QCStatus, jt.StandardTime
                                , jt.ReleaseFlag, jt.UploadNcfileFlag, jt.ReserveShelfFlag
                                , jt.OutboundFinishFlag, jt.StartFlag, jt.MachineNoReady
                                , jb.PrimaryItemCode, jb.PrimaryItemModel, jb.PrimaryQuantity
                                , jt.TransferNCFileToMachineFlag, jt.TransferMessage, jt.MachineId
                            FROM  JobTasks jt
                            LEFT JOIN JobEntities jb ON(jt.JobEntityId = jb.JobEntityId)
                            WHERE jt.OutboundFinishFlag = 1
                                AND ISNULL(jt.QCStatus, 'NONE') = 'NONE'
                            ORDER BY jt.TaskSeq ASC";

            return db.Read(sql, MakeWithStats).ToList();
        }

        public List<JobTaskModel> GetByJobID(int jobId)
        {
            string sql = @"SELECT  jt.TaskId, jt.TaskSeq, jt.JobEntityId
                                , jt.TaskNumber, jt.JobNumber, jt.Description
                                , jt.Manager, jt.StartDate, jt.EndDate
                                , jt.CancelFlag, jt.LastUpdateDate, jt.LastUpdatedBy
                                , jt.CreationDate, jt.CreatedBy, jt.ErrorText
                                , jt.ReadyFlag, jt.Source, jt.ShelfNumber
                                , jt.McProcessFlag, jt.McPickFlag, jt.McLoadFlag
                                , jt.McFinishFlag, jt.MaterialCode, jt.TableNumber
                                , jt.NcFile, jt.DueDate, jt.MachineNo
                                , jt.Priority, jt.McUnloadFlag, jt.McPushFlag
                                , jt.OnShelfFlag, jt.OutboundFlag, jt.QCStatus, jt.StandardTime
                                , jt.ReleaseFlag, jt.UploadNcfileFlag, jt.ReserveShelfFlag
                                , jt.OutboundFinishFlag, jt.StartFlag, jt.MachineNoReady
                                , jb.PrimaryItemCode, jb.PrimaryItemModel, jb.PrimaryQuantity
                                , jt.TransferNCFileToMachineFlag, jt.TransferMessage, jt.MachineId
                            FROM  JobTasks jt
                            LEFT JOIN JobEntities jb ON(jt.JobEntityId = jb.JobEntityId)
                            WHERE jt.JobEntityId = @JobEntityId
                            ORDER BY jt.TaskSeq ASC";

            object[] parms = { "@JobEntityId", jobId };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public List<JobTaskModel> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT  jt.TaskId, jt.TaskSeq, jt.JobEntityId
                                , jt.TaskNumber, jt.JobNumber, jt.Description
                                , jt.Manager, jt.StartDate, jt.EndDate
                                , jt.CancelFlag, jt.LastUpdateDate, jt.LastUpdatedBy
                                , jt.CreationDate, jt.CreatedBy, jt.ErrorText
                                , jt.ReadyFlag, jt.Source, jt.ShelfNumber
                                , jt.McProcessFlag, jt.McPickFlag, jt.McLoadFlag
                                , jt.McFinishFlag, jt.MaterialCode, jt.TableNumber
                                , jt.NcFile, jt.DueDate, jt.MachineNo
                                , jt.Priority, jt.McUnloadFlag, jt.McPushFlag
                                , jt.OnShelfFlag, jt.OutboundFlag, jt.QCStatus, jt.StandardTime
                                , jt.ReleaseFlag, jt.UploadNcfileFlag, jt.ReserveShelfFlag
                                , jt.OutboundFinishFlag, jt.StartFlag, jt.MachineNoReady
                                , jb.PrimaryItemCode, jb.PrimaryItemModel, jb.PrimaryQuantity
                                , jt.TransferNCFileToMachineFlag, jt.TransferMessage, jt.MachineId
                            FROM  JobTasks jt
                            LEFT JOIN JobEntities jb ON(jt.JobEntityId = jb.JobEntityId)
                            WHERE cast(jt.StartDate as date) BETWEEN cast(@StartDate as date) AND cast(@EndDate as date)
                            ORDER BY jt.TaskSeq ASC";

            object[] parms = { "@StartDate", startDate, "@EndDate", endDate };
            return db.Read(sql, Make, parms).ToList();
        }

        public JobTaskModel GetByID(int id)
        {
            string sql = @"SELECT  jt.TaskId, jt.TaskSeq, jt.JobEntityId
                                , jt.TaskNumber, jt.JobNumber, jt.Description
                                , jt.Manager, jt.StartDate, jt.EndDate
                                , jt.CancelFlag, jt.LastUpdateDate, jt.LastUpdatedBy
                                , jt.CreationDate, jt.CreatedBy, jt.ErrorText
                                , jt.ReadyFlag, jt.Source, jt.ShelfNumber
                                , jt.McProcessFlag, jt.McPickFlag, jt.McLoadFlag
                                , jt.McFinishFlag, jt.MaterialCode, jt.TableNumber
                                , jt.NcFile, jt.DueDate, jt.MachineNo
                                , jt.Priority, jt.McUnloadFlag, jt.McPushFlag
                                , jt.OnShelfFlag, jt.OutboundFlag, jt.QCStatus, jt.StandardTime
                                , jt.ReleaseFlag, jt.UploadNcfileFlag, jt.ReserveShelfFlag
                                , jt.OutboundFinishFlag, jt.StartFlag, jt.MachineNoReady
                                , jb.PrimaryItemCode, jb.PrimaryItemModel, jb.PrimaryQuantity
                                , jt.TransferNCFileToMachineFlag, jt.TransferMessage, jt.MachineId
                            FROM  JobTasks jt
                            LEFT JOIN JobEntities jb ON(jt.JobEntityId = jb.JobEntityId)
                            WHERE jt.TaskId = @TaskId";

            object[] parms = { "@TaskId", id };
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public JobTaskModel GetReadyToTransferNC()
        {
            string sql = @"SELECT  jt.TaskId, jt.TaskSeq, jt.JobEntityId
                                , jt.TaskNumber, jt.JobNumber, jt.Description
                                , jt.Manager, jt.StartDate, jt.EndDate
                                , jt.CancelFlag, jt.LastUpdateDate, jt.LastUpdatedBy
                                , jt.CreationDate, jt.CreatedBy, jt.ErrorText
                                , jt.ReadyFlag, jt.Source, jt.ShelfNumber
                                , jt.McProcessFlag, jt.McPickFlag, jt.McLoadFlag
                                , jt.McFinishFlag, jt.MaterialCode, jt.TableNumber
                                , jt.NcFile, jt.DueDate, jt.MachineNo
                                , jt.Priority, jt.McUnloadFlag, jt.McPushFlag
                                , jt.OnShelfFlag, jt.OutboundFlag, jt.QCStatus, jt.StandardTime
                                , jt.ReleaseFlag, jt.UploadNcfileFlag, jt.ReserveShelfFlag
                                , jt.OutboundFinishFlag, jt.StartFlag, jt.MachineNoReady
                                , jb.PrimaryItemCode, jb.PrimaryItemModel, jb.PrimaryQuantity
                                , jt.TransferNCFileToMachineFlag, jt.TransferMessage, jt.MachineId
                            FROM  JobTasks jt
                            LEFT JOIN JobEntities jb ON(jt.JobEntityId = jb.JobEntityId)
                            WHERE jt.McProcessFlag = 0
							AND jt.MachineNoReady is not null
							AND jt.ReadyFlag = 1
							AND jt.ReleaseFlag = 1
							AND jt.OnShelfFlag = 1
							AND jt.UploadNcfileFlag = 1
							AND jt.TransferNCFileToMachineFlag = 0
							AND jt.CancelFlag = 0
							AND jt.TransferMessage is null
							ORDER BY jt.Priority, jt.StartDate ASC";

            return db.Read(sql, MakeWithStats).FirstOrDefault();
        }

        public int Insert(JobTaskModel model)
        {
            string sql =
                @"INSERT INTO JobTasks
                       (TaskSeq
                       ,JobEntityId
                       ,TaskNumber
                       ,JobNumber
                       ,Description
                       ,Manager
                       ,StartDate
                       ,EndDate
                       ,CancelFlag
                       ,LastUpdateDate
                       ,LastUpdatedBy
                       ,CreationDate
                       ,CreatedBy
                       ,ErrorText
                       ,ReadyFlag
                       ,Source
                       ,ShelfNumber
                       ,McProcessFlag
                       ,McPickFlag
                       ,McLoadFlag
                       ,McFinishFlag
                       ,MaterialCode
                       ,TableNumber
                       ,NcFile
                       ,DueDate
                       ,MachineNo
                       ,Priority
                       ,McUnloadFlag
                       ,McPushFlag
                       ,OnShelfFlag
                       ,OutboundFlag
                       ,QCStatus
                       ,StandardTime
                       ,ReleaseFlag
                       ,UploadNcfileFlag
                       ,ReserveShelfFlag
                       ,MachineNoReady
                       ,OutboundFinishFlag
                       ,StartFlag
                       ,TransferNCFileToMachineFlag
                       ,TransferMessage
                       ,PrimaryQuantity
                       ,MachineId)
                 VALUES
                       (@TaskSeq
                       ,@JobEntityId
                       ,@TaskNumber
                       ,@JobNumber
                       ,@Description
                       ,@Manager
                       ,@StartDate
                       ,@EndDate
                       ,@CancelFlag
                       ,@LastUpdateDate
                       ,@LastUpdatedBy
                       ,@CreationDate
                       ,@CreatedBy
                       ,@ErrorText
                       ,@ReadyFlag
                       ,@Source
                       ,@ShelfNumber
                       ,@McProcessFlag
                       ,@McPickFlag
                       ,@McLoadFlag
                       ,@McFinishFlag
                       ,@MaterialCode
                       ,@TableNumber
                       ,@NcFile
                       ,@DueDate
                       ,@MachineNo
                       ,@Priority
                       ,@McUnloadFlag
                       ,@McPushFlag
                       ,@OnShelfFlag
                       ,@OutboundFlag
                       ,@QCStatus
                       ,@StandardTime
                       ,@ReleaseFlag
                       ,@UploadNcfileFlag
                       ,@ReserveShelfFlag
                       ,@MachineNoReady
                       ,@OutboundFinishFlag
                       ,@StartFlag
                       ,@TransferNCFileToMachineFlag
                       ,@TransferMessage
                       ,@PrimaryQuantity
                       ,@MachineId)";

            return db.Insert(sql, Take(model));
        }

        public void Update(JobTaskModel model)
        {
            string sql =
            @"UPDATE JobTasks
                   SET TaskSeq = @TaskSeq
                      ,JobEntityId = @JobEntityId
                      ,TaskNumber = @TaskNumber
                      ,JobNumber = @JobNumber
                      ,Description = @Description
                      ,Manager = @Manager
                      ,StartDate = @StartDate
                      ,EndDate = @EndDate
                      ,CancelFlag = @CancelFlag
                      ,LastUpdateDate = @LastUpdateDate
                      ,LastUpdatedBy = @LastUpdatedBy
                      ,CreationDate = @CreationDate
                      ,CreatedBy = @CreatedBy
                      ,ErrorText = @ErrorText
                      ,ReadyFlag = @ReadyFlag
                      ,ReleaseFlag = @ReleaseFlag
                      ,UploadNcfileFlag = @UploadNcfileFlag
                      ,Source = @Source
                      ,ShelfNumber = @ShelfNumber
                      ,ReserveShelfFlag = @ReserveShelfFlag
                      ,McProcessFlag = @McProcessFlag
                      ,McPickFlag = @McPickFlag
                      ,McLoadFlag = @McLoadFlag
                      ,McFinishFlag = @McFinishFlag
                      ,MaterialCode = @MaterialCode
                      ,TableNumber = @TableNumber
                      ,NcFile = @NcFile
                      ,DueDate = @DueDate
                      ,MachineNo = @MachineNo
                      ,Priority = @Priority
                      ,McUnloadFlag = @McUnloadFlag
                      ,McPushFlag = @McPushFlag
                      ,OnShelfFlag = @OnShelfFlag
                      ,OutboundFlag = @OutboundFlag
                      ,QCStatus = @QCStatus
                      ,StandardTime = @StandardTime
                      ,MachineNoReady = @MachineNoReady
                      ,OutboundFinishFlag = @OutboundFinishFlag
                      ,StartFlag = @StartFlag
                      ,TransferNCFileToMachineFlag = @TransferNCFileToMachineFlag
                      ,TransferMessage = @TransferMessage
                      ,MachineId = @MachineId
                 WHERE TaskId = @TaskId";

            db.Update(sql, Take(model));
        }

        public void Delete(JobTaskModel model)
        {
            string sql = @"DELETE FROM JobTasks WHERE TaskId = @TaskId";

            object[] parms = { "@TaskId", model.TaskId };
            db.Update(sql, parms);
        }

        // creates a Members object with order statistics based on DataReader       
        private static Func<IDataReader, JobTaskModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            row.PrimaryItemCode = reader["PrimaryItemCode"].AsString();
            row.PrimaryItemModel = reader["PrimaryItemModel"].AsString();
            row.PrimaryQuantity = reader["PrimaryQuantity"].AsDouble();
            return row;
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, JobTaskModel> Make = reader =>
             new JobTaskModel
             {
                 TaskId = reader["TaskId"].AsInt(),
                 TaskSeq = reader["TaskSeq"].AsInt(),
                 JobId = reader["JobEntityId"].AsInt(),
                 TaskNumber = reader["TaskNumber"].AsString(),
                 JobNumber = reader["JobNumber"].AsString(),
                 Description = reader["Description"].AsString(),
                 Manager = reader["Manager"].AsString(),
                 //StartDate = reader["StartDate"].AsDateTime(),
                 StartDate = (reader["StartDate"] != DBNull.Value) ? reader["StartDate"].AsDateTime() : (DateTime?)null,
                 //EndDate = reader["EndDate"].AsDateTime(),
                 //EndDate = (reader["EndDate"] != DBNull.Value) ? reader["EndDate"].AsDateTime() : (DateTime?)null,
                 CancelFlag = (reader["CancelFlag"].AsInt() == 1) ? true : false,
                 LastUpdateDate = reader["LastUpdateDate"].AsDateTime(),
                 LastUpdatedBy = reader["LastUpdatedBy"].AsInt(),
                 CreationDate = reader["CreationDate"].AsDateTime(),
                 CreatedBy = reader["CreatedBy"].AsInt(),
                 ErrorText = reader["ErrorText"].AsString(),
                 ReadyFlag = reader["ReadyFlag"].AsBool(),
                 ReleaseFlag = reader["ReleaseFlag"].AsBool(),
                 UploadNcfileFlag = reader["UploadNcfileFlag"].AsBool(),
                 Source = reader["Source"].AsString(),
                 ShelfNumber = reader["ShelfNumber"].AsString(),
                 ReserveShelfFlag = reader["ReserveShelfFlag"].AsBool(),
                 OnShelfFlag = reader["OnShelfFlag"].AsBool(),
                 McProcessFlag = reader["McProcessFlag"].AsBool(),
                 McPickFlag = reader["McPickFlag"].AsBool(),
                 McLoadFlag = reader["McLoadFlag"].AsBool(),
                 McFinishFlag = reader["McFinishFlag"].AsBool(),
                 McUnloadFlag = reader["McUnloadFlag"].AsBool(),
                 McPushFlag = reader["McPushFlag"].AsBool(),
                 OutboundFlag = reader["OutboundFlag"].AsBool(),
                 OutboundFinishFlag = reader["OutboundFinishFlag"].AsBool(),
                 QCStatus = reader["QCStatus"].AsString(),
                 MaterialCode = reader["MaterialCode"].AsString(),
                 TableNumber = reader["TableNumber"].AsString(),
                 NcFile = reader["NcFile"].AsString(),
                 DueDate = (reader["DueDate"] != DBNull.Value) ? reader["DueDate"].AsDateTime() : (DateTime?)null,
                 MachineNo = reader["MachineNo"].AsString(),
                 MachineNoReady = reader["MachineNoReady"].AsString(),
                 Priority = reader["Priority"].AsInt(),
                 StandardTime = reader["StandardTime"].AsDouble(),
                 StartFlag = (reader["StartFlag"].AsInt() == 1) ? true : false,
                 TransferNCFileToMachineFlag = reader["TransferNCFileToMachineFlag"].AsBool(),
                 TransferMessage = reader["TransferMessage"].AsString(),
                 MachineId = reader["MachineId"].AsInt()
             };

        private object[] Take(JobTaskModel model)
        {
            return new object[]
            {
                "@TaskId", model.TaskId,
                "@TaskSeq", model.TaskSeq,
                "@JobEntityId", model.JobId,
                "@TaskNumber", model.TaskNumber,
                "@JobNumber", model.JobNumber,
                "@Description", model.Description,
                "@Manager", model.Manager,
                "@StartDate", model.StartDate,
                "@EndDate", model.EndDate,
                "@CancelFlag", (model.CancelFlag) ? 1 : 0,
                "@LastUpdateDate", model.LastUpdateDate,
                "@LastUpdatedBy", model.LastUpdatedBy,
                "@CreationDate", model.CreationDate,
                "@CreatedBy", model.CreatedBy,
                "@ErrorText", model.ErrorText,
                "@ReadyFlag", (model.ReadyFlag) ? 1 : 0,
                "@ReleaseFlag", (model.ReleaseFlag) ? 1 : 0,
                "@UploadNcfileFlag", (model.UploadNcfileFlag) ? 1 : 0,
                "@Source", model.Source,
                "@ShelfNumber", model.ShelfNumber,
                "@ReserveShelfFlag", (model.ReserveShelfFlag) ? 1 : 0,
                "@OnShelfFlag", (model.OnShelfFlag) ? 1 : 0,
                "@McProcessFlag", (model.McProcessFlag) ? 1 : 0,
                "@McPickFlag", (model.McPickFlag) ? 1 : 0,
                "@McLoadFlag", (model.McLoadFlag) ? 1 : 0,
                "@McFinishFlag", (model.McFinishFlag) ? 1 : 0,
                "@McUnloadFlag", (model.McUnloadFlag) ? 1 : 0,
                "@McPushFlag", (model.McPushFlag) ? 1 : 0,
                "@OutboundFlag", (model.OutboundFlag) ? 1 : 0,
                "@OutboundFinishFlag", (model.OutboundFinishFlag) ? 1 : 0,                
                "@QCStatus", string.IsNullOrEmpty(model.QCStatus) ? "NONE" : model.QCStatus,
                "@MaterialCode", model.MaterialCode,
                "@TableNumber", model.TableNumber,
                "@NcFile", model.NcFile,
                "@DueDate", model.DueDate,
                "@MachineNo", model.MachineNo,
                "@MachineNoReady", model.MachineNoReady,
                "@Priority", model.Priority,
                "@StandardTime", model.StandardTime,
                "@StartFlag",(model.StartFlag) ? 1 : 0,
                "@TransferNCFileToMachineFlag",(model.TransferNCFileToMachineFlag) ? 1 : 0,
                "@TransferMessage", model.TransferMessage,
                "@PrimaryQuantity", model.PrimaryQuantity,
                "@MachineId", model.MachineId
            };
        }
    }
}
