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
            string sql = @"SELECT  jt.task_id, jt.task_seq, jt.job_entity_id
                                , jt.task_number, jt.job_number, jt.description
                                , jt.manager, jt.start_date, jt.end_date
                                , jt.cancel_flag, jt.last_update_date, jt.last_updated_by
                                , jt.creation_date, jt.created_by, jt.error_text
                                , jt.ready_flag, jt.source, jt.shelf_number
                                , jt.mc_process_flag, jt.mc_pick_flag, jt.mc_load_flag
                                , jt.mc_finish_flag, jt.material_code, jt.table_number
                                , jt.nc_file, jt.due_date, jt.machine_no
                                , jt.priority, jt.mc_unload_flag, jt.mc_push_flag
                                , jt.on_shelf_flag, jt.outbound_flag, jt.qc_status, jt.standard_time
                                , jt.release_flag, jt.upload_ncfile_flag, jt.reserve_shelf_flag
                                , jt.outbound_finish_flag, jt.Start_Flag, jt.machine_no_ready
                                , jb.primary_item_code, jb.primary_item_model, jb.primary_quantity
                                , jt.trf_ncfile_to_mc_flag, jt.transfer_message
                            FROM  mfg_job_tasks jt
                            LEFT JOIN mfg_job_entities jb ON(jt.job_entity_id = jb.job_entity_id)
                            WHERE jt.release_flag = 0 AND jt.ready_flag = 1
                            ORDER BY jt.task_seq ASC";

            return db.Read(sql, MakeWithStats).ToList();
        }

        public List<JobTaskModel> GetInspectionTask()
        {
            string sql = @"SELECT  jt.task_id, jt.task_seq, jt.job_entity_id
                                , jt.task_number, jt.job_number, jt.description
                                , jt.manager, jt.start_date, jt.end_date
                                , jt.cancel_flag, jt.last_update_date, jt.last_updated_by
                                , jt.creation_date, jt.created_by, jt.error_text
                                , jt.ready_flag, jt.source, jt.shelf_number
                                , jt.mc_process_flag, jt.mc_pick_flag, jt.mc_load_flag
                                , jt.mc_finish_flag, jt.material_code, jt.table_number
                                , jt.nc_file, jt.due_date, jt.machine_no
                                , jt.priority, jt.mc_unload_flag, jt.mc_push_flag
                                , jt.on_shelf_flag, jt.outbound_flag, jt.qc_status, jt.standard_time
                                , jt.release_flag, jt.upload_ncfile_flag, jt.reserve_shelf_flag
                                , jt.outbound_finish_flag, jt.Start_Flag, jt.machine_no_ready
                                , jb.primary_item_code, jb.primary_item_model, jb.primary_quantity
                                , jt.trf_ncfile_to_mc_flag, jt.transfer_message
                            FROM  mfg_job_tasks jt
                            LEFT JOIN mfg_job_entities jb ON(jt.job_entity_id = jb.job_entity_id)
                            WHERE jt.outbound_finish_flag = 1
                                AND ISNULL(jt.qc_status, 'NONE') = 'NONE'
                            ORDER BY jt.task_seq ASC";

            return db.Read(sql, MakeWithStats).ToList();
        }

        public List<JobTaskModel> GetByJobID(int jobId)
        {
            string sql = @"SELECT  jt.task_id, jt.task_seq, jt.job_entity_id
                                , jt.task_number, jt.job_number, jt.description
                                , jt.manager, jt.start_date, jt.end_date
                                , jt.cancel_flag, jt.last_update_date, jt.last_updated_by
                                , jt.creation_date, jt.created_by, jt.error_text
                                , jt.ready_flag, jt.source, jt.shelf_number
                                , jt.mc_process_flag, jt.mc_pick_flag, jt.mc_load_flag
                                , jt.mc_finish_flag, jt.material_code, jt.table_number
                                , jt.nc_file, jt.due_date, jt.machine_no
                                , jt.priority, jt.mc_unload_flag, jt.mc_push_flag
                                , jt.on_shelf_flag, jt.outbound_flag, jt.qc_status, jt.standard_time
                                , jt.release_flag, jt.upload_ncfile_flag, jt.reserve_shelf_flag
                                , jt.outbound_finish_flag, jt.Start_Flag, jt.machine_no_ready
                                , jb.primary_item_code, jb.primary_item_model, jb.primary_quantity
                                , jt.trf_ncfile_to_mc_flag, jt.transfer_message
                            FROM  mfg_job_tasks jt
                            LEFT JOIN mfg_job_entities jb ON(jt.job_entity_id = jb.job_entity_id)
                            WHERE jt.job_entity_id = @job_entity_id
                            ORDER BY jt.task_seq ASC";

            object[] parms = { "@job_entity_id", jobId };
            return db.Read(sql, MakeWithStats, parms).ToList();
        }

        public List<JobTaskModel> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            string sql = @"SELECT  jt.task_id, jt.task_seq, jt.job_entity_id
                                , jt.task_number, jt.job_number, jt.description
                                , jt.manager, jt.start_date, jt.end_date
                                , jt.cancel_flag, jt.last_update_date, jt.last_updated_by
                                , jt.creation_date, jt.created_by, jt.error_text
                                , jt.ready_flag, jt.source, jt.shelf_number
                                , jt.mc_process_flag, jt.mc_pick_flag, jt.mc_load_flag
                                , jt.mc_finish_flag, jt.material_code, jt.table_number
                                , jt.nc_file, jt.due_date, jt.machine_no
                                , jt.priority, jt.mc_unload_flag, jt.mc_push_flag
                                , jt.on_shelf_flag, jt.outbound_flag, jt.qc_status, jt.standard_time
                                , jt.release_flag, jt.upload_ncfile_flag, jt.reserve_shelf_flag
                                , jt.outbound_finish_flag, jt.Start_Flag, jt.machine_no_ready
                                , jb.primary_item_code, jb.primary_item_model, jb.primary_quantity
                                , jt.trf_ncfile_to_mc_flag, jt.transfer_message
                            FROM  mfg_job_tasks jt
                            LEFT JOIN mfg_job_entities jb ON(jt.job_entity_id = jb.job_entity_id)
                            WHERE cast(jt.start_date as date) BETWEEN cast(@StartDate as date) AND cast(@EndDate as date)
                            ORDER BY jt.task_seq ASC";

            object[] parms = { "@StartDate", startDate, "@EndDate", endDate };
            return db.Read(sql, Make, parms).ToList();
        }

        public JobTaskModel GetByID(int id)
        {
            string sql = @"SELECT  jt.task_id, jt.task_seq, jt.job_entity_id
                                , jt.task_number, jt.job_number, jt.description
                                , jt.manager, jt.start_date, jt.end_date
                                , jt.cancel_flag, jt.last_update_date, jt.last_updated_by
                                , jt.creation_date, jt.created_by, jt.error_text
                                , jt.ready_flag, jt.source, jt.shelf_number
                                , jt.mc_process_flag, jt.mc_pick_flag, jt.mc_load_flag
                                , jt.mc_finish_flag, jt.material_code, jt.table_number
                                , jt.nc_file, jt.due_date, jt.machine_no
                                , jt.priority, jt.mc_unload_flag, jt.mc_push_flag
                                , jt.on_shelf_flag, jt.outbound_flag, jt.qc_status, jt.standard_time
                                , jt.release_flag, jt.upload_ncfile_flag, jt.reserve_shelf_flag
                                , jt.outbound_finish_flag, jt.Start_Flag, jt.machine_no_ready
                                , jb.primary_item_code, jb.primary_item_model, jb.primary_quantity
                                , jt.trf_ncfile_to_mc_flag, jt.transfer_message
                            FROM  mfg_job_tasks jt
                            LEFT JOIN mfg_job_entities jb ON(jt.job_entity_id = jb.job_entity_id)
                            WHERE jt.task_id = @task_id";

            object[] parms = { "@task_id", id };
            return db.Read(sql, MakeWithStats, parms).FirstOrDefault();
        }

        public JobTaskModel GetReadyToTransferNC()
        {
            string sql = @"SELECT  jt.task_id, jt.task_seq, jt.job_entity_id
                                , jt.task_number, jt.job_number, jt.description
                                , jt.manager, jt.start_date, jt.end_date
                                , jt.cancel_flag, jt.last_update_date, jt.last_updated_by
                                , jt.creation_date, jt.created_by, jt.error_text
                                , jt.ready_flag, jt.source, jt.shelf_number
                                , jt.mc_process_flag, jt.mc_pick_flag, jt.mc_load_flag
                                , jt.mc_finish_flag, jt.material_code, jt.table_number
                                , jt.nc_file, jt.due_date, jt.machine_no
                                , jt.priority, jt.mc_unload_flag, jt.mc_push_flag
                                , jt.on_shelf_flag, jt.outbound_flag, jt.qc_status, jt.standard_time
                                , jt.release_flag, jt.upload_ncfile_flag, jt.reserve_shelf_flag
                                , jt.outbound_finish_flag, jt.Start_Flag, jt.machine_no_ready
                                , jb.primary_item_code, jb.primary_item_model, jb.primary_quantity
                                , jt.trf_ncfile_to_mc_flag, jt.transfer_message
                            FROM  mfg_job_tasks jt
                            LEFT JOIN mfg_job_entities jb ON(jt.job_entity_id = jb.job_entity_id)
                            WHERE jt.mc_process_flag = 0
							AND jt.machine_no_ready is not null
							AND jt.ready_flag = 1
							AND jt.release_flag = 1
							AND jt.on_shelf_flag = 1
							AND jt.upload_ncfile_flag = 1
							AND jt.trf_ncfile_to_mc_flag = 0
							AND jt.cancel_flag = 0
							AND jt.transfer_message is null
							ORDER BY jt.priority, jt.start_date ASC";

            return db.Read(sql, MakeWithStats).FirstOrDefault();
        }

        public int Insert(JobTaskModel model)
        {
            string sql =
                @"INSERT INTO mfg_job_tasks
                       (task_seq
                       ,job_entity_id
                       ,task_number
                       ,job_number
                       ,description
                       ,manager
                       ,start_date
                       ,end_date
                       ,cancel_flag
                       ,last_update_date
                       ,last_updated_by
                       ,creation_date
                       ,created_by
                       ,error_text
                       ,ready_flag
                       ,source
                       ,shelf_number
                       ,mc_process_flag
                       ,mc_pick_flag
                       ,mc_load_flag
                       ,mc_finish_flag
                       ,material_code
                       ,table_number
                       ,nc_file
                       ,due_date
                       ,machine_no
                       ,priority
                       ,mc_unload_flag
                       ,mc_push_flag
                       ,on_shelf_flag
                       ,outbound_flag
                       ,qc_status
                       ,standard_time
                       ,release_flag
                       ,upload_ncfile_flag
                       ,reserve_shelf_flag
                       ,machine_no_ready
                       ,outbound_finish_flag
                       ,Start_Flag
                       ,trf_ncfile_to_mc_flag
                       ,transfer_message)
                 VALUES
                       (@task_seq
                       ,@job_entity_id
                       ,@task_number
                       ,@job_number
                       ,@description
                       ,@manager
                       ,@start_date
                       ,@end_date
                       ,@cancel_flag
                       ,@last_update_date
                       ,@last_updated_by
                       ,@creation_date
                       ,@created_by
                       ,@error_text
                       ,@ready_flag
                       ,@source
                       ,@shelf_number
                       ,@mc_process_flag
                       ,@mc_pick_flag
                       ,@mc_load_flag
                       ,@mc_finish_flag
                       ,@material_code
                       ,@table_number
                       ,@nc_file
                       ,@due_date
                       ,@machine_no
                       ,@priority
                       ,@mc_unload_flag
                       ,@mc_push_flag
                       ,@on_shelf_flag
                       ,@outbound_flag
                       ,@qc_status
                       ,@standard_time
                       ,@release_flag
                       ,@upload_ncfile_flag
                       ,@reserve_shelf_flag
                       ,@machine_no_ready
                       ,@outbound_finish_flag
                       ,@Start_Flag
                       ,@trf_ncfile_to_mc_flag
                       ,@transfer_message)";

            return db.Insert(sql, Take(model));
        }

        public void Update(JobTaskModel model)
        {
            string sql =
            @"UPDATE mfg_job_tasks
                   SET task_seq = @task_seq
                      ,job_entity_id = @job_entity_id
                      ,task_number = @task_number
                      ,job_number = @job_number
                      ,description = @description
                      ,manager = @manager
                      ,start_date = @start_date
                      ,end_date = @end_date
                      ,cancel_flag = @cancel_flag
                      ,last_update_date = @last_update_date
                      ,last_updated_by = @last_updated_by
                      ,creation_date = @creation_date
                      ,created_by = @created_by
                      ,error_text = @error_text
                      ,ready_flag = @ready_flag
                      ,release_flag = @release_flag
                      ,upload_ncfile_flag = @upload_ncfile_flag
                      ,source = @source
                      ,shelf_number = @shelf_number
                      ,reserve_shelf_flag = @reserve_shelf_flag
                      ,mc_process_flag = @mc_process_flag
                      ,mc_pick_flag = @mc_pick_flag
                      ,mc_load_flag = @mc_load_flag
                      ,mc_finish_flag = @mc_finish_flag
                      ,material_code = @material_code
                      ,table_number = @table_number
                      ,nc_file = @nc_file
                      ,due_date = @due_date
                      ,machine_no = @machine_no
                      ,priority = @priority
                      ,mc_unload_flag = @mc_unload_flag
                      ,mc_push_flag = @mc_push_flag
                      ,on_shelf_flag = @on_shelf_flag
                      ,outbound_flag = @outbound_flag
                      ,qc_status = @qc_status
                      ,standard_time = @standard_time
                      ,machine_no_ready = @machine_no_ready
                      ,outbound_finish_flag = @outbound_finish_flag
                      ,Start_Flag = @Start_Flag
                      ,trf_ncfile_to_mc_flag = @trf_ncfile_to_mc_flag
                      ,transfer_message = @transfer_message
                 WHERE task_id = @task_id";

            db.Update(sql, Take(model));
        }

        public void Delete(JobTaskModel model)
        {
            string sql = @"DELETE FROM mfg_job_tasks WHERE task_id = @task_id";

            object[] parms = { "@task_id", model.TaskId };
            db.Update(sql, parms);
        }

        // creates a Members object with order statistics based on DataReader       
        private static Func<IDataReader, JobTaskModel> MakeWithStats = reader =>
        {
            var row = Make(reader);
            row.PrimaryItemCode = reader["primary_item_code"].AsString();
            row.PrimaryItemModel = reader["primary_item_model"].AsString();
            row.PrimaryQuantity = reader["primary_quantity"].AsDouble();
            return row;
        };

        // creates a Member object based on DataReader
        private static Func<IDataReader, JobTaskModel> Make = reader =>
             new JobTaskModel
             {
                 TaskId = reader["task_id"].AsInt(),
                 TaskSeq = reader["task_seq"].AsInt(),
                 JobId = reader["job_entity_id"].AsInt(),
                 TaskNumber = reader["task_number"].AsString(),
                 JobNumber = reader["job_number"].AsString(),
                 Description = reader["description"].AsString(),
                 Manager = reader["manager"].AsString(),
                 //StartDate = reader["start_date"].AsDateTime(),
                 StartDate = (reader["start_date"] != DBNull.Value) ? reader["start_date"].AsDateTime() : (DateTime?)null,
                 //EndDate = reader["end_date"].AsDateTime(),
                 //EndDate = (reader["end_date"] != DBNull.Value) ? reader["end_date"].AsDateTime() : (DateTime?)null,
                 CancelFlag = (reader["cancel_flag"].AsInt() == 1) ? true : false,
                 LastUpdateDate = reader["last_update_date"].AsDateTime(),
                 LastUpdatedBy = reader["last_updated_by"].AsInt(),
                 CreationDate = reader["creation_date"].AsDateTime(),
                 CreatedBy = reader["created_by"].AsInt(),
                 ErrorText = reader["error_text"].AsString(),
                 ReadyFlag = (reader["ready_flag"].AsInt() == 1) ? true : false,
                 ReleaseFlag = (reader["release_flag"].AsInt() == 1) ? true : false,
                 UploadNcfileFlag = (reader["upload_ncfile_flag"].AsInt() == 1) ? true : false,
                 Source = reader["source"].AsString(),
                 ShelfNumber = reader["shelf_number"].AsString(),
                 ReserveShelfFlag = (reader["reserve_shelf_flag"].AsInt() == 1) ? true : false,
                 OnShelfFlag = (reader["on_shelf_flag"].AsInt() == 1) ? true : false,
                 McProcessFlag = (reader["mc_process_flag"].AsInt() == 1) ? true : false,
                 McPickFlag = (reader["mc_pick_flag"].AsInt() == 1) ? true : false,
                 McLoadFlag = (reader["mc_load_flag"].AsInt() == 1) ? true : false,
                 McFinishFlag = (reader["mc_finish_flag"].AsInt() == 1) ? true : false,
                 McUnloadFlag = (reader["mc_unload_flag"].AsInt() == 1) ? true : false,
                 McPushFlag = (reader["mc_push_flag"].AsInt() == 1) ? true : false,
                 OutboundFlag = (reader["outbound_flag"].AsInt() == 1) ? true : false,
                 OutboundFinishFlag = (reader["outbound_finish_flag"].AsInt() == 1) ? true : false,
                 QCStatus = reader["qc_status"].AsString(),
                 MaterialCode = reader["material_code"].AsString(),
                 TableNumber = reader["table_number"].AsString(),
                 NcFile = reader["nc_file"].AsString(),
                 DueDate = (reader["due_date"] != DBNull.Value) ? reader["due_date"].AsDateTime() : (DateTime?)null,
                 MachineNo = reader["machine_no"].AsString(),
                 MachineNoReady = reader["machine_no_ready"].AsString(),
                 Priority = reader["priority"].AsInt(),
                 StandardTime = reader["standard_time"].AsDouble(),
                 StartFlag = (reader["Start_Flag"].AsInt() == 1) ? true : false,
                 TransferNCFileToMachineFlag = (reader["trf_ncfile_to_mc_flag"].AsInt() == 1) ? true : false,
                 TransferMessage = reader["transfer_message"].AsString()
             };

        private object[] Take(JobTaskModel model)
        {
            return new object[]
            {
                "@task_id", model.TaskId,
                "@task_seq", model.TaskSeq,
                "@job_entity_id", model.JobId,
                "@task_number", model.TaskNumber,
                "@job_number", model.JobNumber,
                "@description", model.Description,
                "@manager", model.Manager,
                "@start_date", model.StartDate,
                "@end_date", model.EndDate,
                "@cancel_flag", (model.CancelFlag) ? 1 : 0,
                "@last_update_date", model.LastUpdateDate,
                "@last_updated_by", model.LastUpdatedBy,
                "@creation_date", model.CreationDate,
                "@created_by", model.CreatedBy,
                "@error_text", model.ErrorText,
                "@ready_flag", (model.ReadyFlag) ? 1 : 0,
                "@release_flag", (model.ReleaseFlag) ? 1 : 0,
                "@upload_ncfile_flag", (model.UploadNcfileFlag) ? 1 : 0,
                "@source", model.Source,
                "@shelf_number", model.ShelfNumber,
                "@reserve_shelf_flag", (model.ReserveShelfFlag) ? 1 : 0,
                "@on_shelf_flag", (model.OnShelfFlag) ? 1 : 0,
                "@mc_process_flag", (model.McProcessFlag) ? 1 : 0,
                "@mc_pick_flag", (model.McPickFlag) ? 1 : 0,
                "@mc_load_flag", (model.McLoadFlag) ? 1 : 0,
                "@mc_finish_flag", (model.McFinishFlag) ? 1 : 0,
                "@mc_unload_flag", (model.McUnloadFlag) ? 1 : 0,
                "@mc_push_flag", (model.McPushFlag) ? 1 : 0,
                "@outbound_flag", (model.OutboundFlag) ? 1 : 0,
                "@outbound_finish_flag", (model.OutboundFinishFlag) ? 1 : 0,                
                "@qc_status", string.IsNullOrEmpty(model.QCStatus) ? "NONE" : model.QCStatus,
                "@material_code", model.MaterialCode,
                "@table_number", model.TableNumber,
                "@nc_file", model.NcFile,
                "@due_date", model.DueDate,
                "@machine_no", model.MachineNo,
                "@machine_no_ready", model.MachineNoReady,
                "@priority", model.Priority,
                "@standard_time", model.StandardTime,
                "@Start_Flag",(model.StartFlag) ? 1 : 0,
                "@trf_ncfile_to_mc_flag",(model.TransferNCFileToMachineFlag) ? 1 : 0,
                "@transfer_message", model.TransferMessage
            };
        }
    }
}
