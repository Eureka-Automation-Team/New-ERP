using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Eureka.Web.Models
{
    public partial class MESContext : DbContext
    {
        public MESContext()
        {
        }

        public MESContext(DbContextOptions<MESContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DocSequencesDefine> DocSequencesDefine { get; set; }
        public virtual DbSet<FndRoles> FndRoles { get; set; }
        public virtual DbSet<FndUsers> FndUsers { get; set; }
        public virtual DbSet<InvLocations> InvLocations { get; set; }
        public virtual DbSet<MfgJobEntities> MfgJobEntities { get; set; }
        public virtual DbSet<MfgJobTasks> MfgJobTasks { get; set; }
        public virtual DbSet<MfgJobTasks1> MfgJobTasks1 { get; set; }
        public virtual DbSet<MfgJobTasks2> MfgJobTasks2 { get; set; }
        public virtual DbSet<MfgJobTasks5> MfgJobTasks5 { get; set; }
        public virtual DbSet<MfgJobTransactionLogs> MfgJobTransactionLogs { get; set; }
        public virtual DbSet<MfgMachines> MfgMachines { get; set; }
        public virtual DbSet<MfgShift> MfgShift { get; set; }
        public virtual DbSet<MstShift> MstShift { get; set; }
        public virtual DbSet<PlnCalendar> PlnCalendar { get; set; }
        public virtual DbSet<PlnCalendarDays> PlnCalendarDays { get; set; }
        public virtual DbSet<Table1> Table1 { get; set; }
        public virtual DbSet<ViewJobStatus> ViewJobStatus { get; set; }
        public virtual DbSet<ViewJobTaskStatus> ViewJobTaskStatus { get; set; }
        public virtual DbSet<ViewJobTotalActual> ViewJobTotalActual { get; set; }
        public virtual DbSet<ViewJobTotalPlan> ViewJobTotalPlan { get; set; }
        public virtual DbSet<ViewLocationStatus> ViewLocationStatus { get; set; }
        public virtual DbSet<ViewMachineMonitoring> ViewMachineMonitoring { get; set; }
        public virtual DbSet<ViewMfgJobTransactionLogs> ViewMfgJobTransactionLogs { get; set; }
        public virtual DbSet<ViewProductionMonitoring> ViewProductionMonitoring { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server= 127.0.0.1; Database = MES; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocSequencesDefine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("doc_sequences_define");

                entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CREATION_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.DocSequenceId).HasColumnName("DOC_SEQUENCE_ID");

                entity.Property(e => e.DocTypeCode)
                    .IsRequired()
                    .HasColumnName("DOC_TYPE_CODE")
                    .HasMaxLength(200);

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnName("LAST_UPDATE_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.Nextval).HasColumnName("NEXTVAL");

                entity.Property(e => e.Prefix)
                    .HasColumnName("PREFIX")
                    .HasMaxLength(50);

                entity.Property(e => e.RunningDigit).HasColumnName("RUNNING_DIGIT");
            });

            modelBuilder.Entity<FndRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("fnd_roles");

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CREATION_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnName("LAST_UPDATE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.RoleName)
                    .HasColumnName("ROLE_NAME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FndUsers>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("fnd_users");

                entity.Property(e => e.ApproverId).HasColumnName("APPROVER_ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CREATION_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(50);

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("EMAIL_ADDRESS")
                    .HasMaxLength(100);

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.EncryptedPassword)
                    .HasColumnName("ENCRYPTED_PASSWORD")
                    .HasMaxLength(50);

                entity.Property(e => e.EndDate)
                    .HasColumnName("END_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Fax)
                    .HasColumnName("FAX")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.LastLogonDate)
                    .HasColumnName("LAST_LOGON_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnName("LAST_UPDATE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.Property(e => e.SessionNumber).HasColumnName("SESSION_NUMBER");

                entity.Property(e => e.Signature)
                    .HasColumnName("SIGNATURE")
                    .HasMaxLength(200);

                entity.Property(e => e.StartDate)
                    .HasColumnName("START_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.SupplierId).HasColumnName("SUPPLIER_ID");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserName)
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<InvLocations>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("inv_locations");

                entity.Property(e => e.Attribute1)
                    .HasColumnName("attribute1")
                    .HasMaxLength(150);

                entity.Property(e => e.Attribute2)
                    .HasColumnName("attribute2")
                    .HasMaxLength(150);

                entity.Property(e => e.Attribute3)
                    .HasColumnName("attribute3")
                    .HasMaxLength(150);

                entity.Property(e => e.Attribute4)
                    .HasColumnName("attribute4")
                    .HasMaxLength(150);

                entity.Property(e => e.Attribute5)
                    .HasColumnName("attribute5")
                    .HasMaxLength(150);

                entity.Property(e => e.AvailableFlag).HasColumnName("available_flag");

                entity.Property(e => e.ColumnNo).HasColumnName("column_no");

                entity.Property(e => e.CombindLocation)
                    .HasColumnName("combind_location")
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FillFlag).HasColumnName("fill_flag");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnName("last_update_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.LevelNo).HasColumnName("level_no");

                entity.Property(e => e.LocationId)
                    .HasColumnName("location_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.ReserveFlag).HasColumnName("reserve_flag");

                entity.Property(e => e.TaskId).HasColumnName("task_id");
            });

            modelBuilder.Entity<MfgJobEntities>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mfg_job_entities");

                entity.Property(e => e.CancelFlag)
                    .IsRequired()
                    .HasColumnName("cancel_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompletedFlag)
                    .IsRequired()
                    .HasColumnName("completed_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(240);

                entity.Property(e => e.EntityType).HasColumnName("entity_type");

                entity.Property(e => e.JobEntiryDate)
                    .HasColumnName("job_entiry_date")
                    .HasColumnType("date");

                entity.Property(e => e.JobEntityId)
                    .HasColumnName("job_entity_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.JobEntityName)
                    .IsRequired()
                    .HasColumnName("job_entity_name")
                    .HasMaxLength(240);

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnName("last_update_date")
                    .HasColumnType("date");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.OpenStatus)
                    .IsRequired()
                    .HasColumnName("open_status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OrganizationId).HasColumnName("organization_id");

                entity.Property(e => e.PoHeaderId).HasColumnName("po_header_id");

                entity.Property(e => e.PoLineId).HasColumnName("po_line_id");

                entity.Property(e => e.PrimaryItemCode)
                    .HasColumnName("primary_item_code")
                    .HasMaxLength(240);

                entity.Property(e => e.PrimaryItemId).HasColumnName("primary_item_id");

                entity.Property(e => e.PrimaryItemModel)
                    .HasColumnName("primary_item_model")
                    .HasMaxLength(240);

                entity.Property(e => e.PrimaryQuantity)
                    .HasColumnName("primary_quantity")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProcessFlag)
                    .IsRequired()
                    .HasColumnName("process_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Segment1)
                    .HasColumnName("segment1")
                    .HasMaxLength(40);

                entity.Property(e => e.Segment2)
                    .HasColumnName("segment2")
                    .HasMaxLength(240);

                entity.Property(e => e.Segment3)
                    .HasColumnName("segment3")
                    .HasMaxLength(240);

                entity.Property(e => e.Segment4)
                    .HasColumnName("segment4")
                    .HasMaxLength(40);

                entity.Property(e => e.Segment5)
                    .HasColumnName("segment5")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<MfgJobTasks>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mfg_job_tasks");

                entity.Property(e => e.BreakdownTime).HasColumnName("breakdown_time");

                entity.Property(e => e.BreakdownType)
                    .HasColumnName("breakdown_type")
                    .HasMaxLength(50);

                entity.Property(e => e.CancelFlag).HasColumnName("cancel_flag");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(250);

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ErrorText)
                    .HasColumnName("error_text")
                    .HasMaxLength(2000);

                entity.Property(e => e.JobEntityId).HasColumnName("job_entity_id");

                entity.Property(e => e.JobNumber)
                    .IsRequired()
                    .HasColumnName("job_number")
                    .HasMaxLength(20);

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnName("last_update_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.MachineNo)
                    .HasColumnName("machine_no")
                    .HasMaxLength(50);

                entity.Property(e => e.MachineNoReady)
                    .HasColumnName("machine_no_ready")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Manager)
                    .HasColumnName("manager")
                    .HasMaxLength(240);

                entity.Property(e => e.MaterialCode)
                    .HasColumnName("material_code")
                    .HasMaxLength(50);

                entity.Property(e => e.McFinishFlag).HasColumnName("mc_finish_flag");

                entity.Property(e => e.McLoadFlag).HasColumnName("mc_load_flag");

                entity.Property(e => e.McPickFlag).HasColumnName("mc_pick_flag");

                entity.Property(e => e.McProcessFlag).HasColumnName("mc_process_flag");

                entity.Property(e => e.McPushFlag).HasColumnName("mc_push_flag");

                entity.Property(e => e.McUnloadFlag).HasColumnName("mc_unload_flag");

                entity.Property(e => e.NcFile)
                    .HasColumnName("nc_file")
                    .HasMaxLength(500);

                entity.Property(e => e.OnShelfFlag).HasColumnName("on_shelf_flag");

                entity.Property(e => e.OutboundFinishFlag).HasColumnName("outbound_finish_flag");

                entity.Property(e => e.OutboundFlag).HasColumnName("outbound_flag");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.QcStatus)
                    .HasColumnName("qc_status")
                    .HasMaxLength(50);

                entity.Property(e => e.ReadyFlag).HasColumnName("ready_flag");

                entity.Property(e => e.ReleaseFlag).HasColumnName("release_flag");

                entity.Property(e => e.ReserveShelfFlag).HasColumnName("reserve_shelf_flag");

                entity.Property(e => e.SetupTime).HasColumnName("setup_time");

                entity.Property(e => e.ShelfNumber)
                    .HasColumnName("shelf_number")
                    .HasMaxLength(200);

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasMaxLength(200);

                entity.Property(e => e.StandardTime).HasColumnName("standard_time");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartFlag).HasColumnName("Start_Flag");

                entity.Property(e => e.TableNumber)
                    .HasColumnName("table_number")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TaskNumber)
                    .IsRequired()
                    .HasColumnName("task_number")
                    .HasMaxLength(25);

                entity.Property(e => e.TaskSeq).HasColumnName("task_seq");

                entity.Property(e => e.TransferMessage)
                    .HasColumnName("transfer_message")
                    .HasMaxLength(240);

                entity.Property(e => e.TrfNcfileToMcFlag)
                    .HasColumnName("trf_ncfile_to_mc_flag")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UploadNcfileFlag).HasColumnName("upload_ncfile_flag");
            });

            modelBuilder.Entity<MfgJobTasks1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mfg_job_tasks1");

                entity.Property(e => e.CancelFlag).HasColumnName("cancel_flag");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(250);

                entity.Property(e => e.DestinationLocation)
                    .HasColumnName("destination_location")
                    .HasMaxLength(200);

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ErrorText)
                    .HasColumnName("error_text")
                    .HasMaxLength(2000);

                entity.Property(e => e.JobEntityId).HasColumnName("job_entity_id");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnName("last_update_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.MachineNo)
                    .HasColumnName("machine_no")
                    .HasMaxLength(50);

                entity.Property(e => e.Manager)
                    .HasColumnName("manager")
                    .HasMaxLength(240);

                entity.Property(e => e.MaterialCode)
                    .HasColumnName("material_code")
                    .HasMaxLength(50);

                entity.Property(e => e.McFinishFlag).HasColumnName("mc_finish_flag");

                entity.Property(e => e.McLoadFlag).HasColumnName("mc_load_flag");

                entity.Property(e => e.McPickFlag).HasColumnName("mc_pick_flag");

                entity.Property(e => e.McProcessFlag).HasColumnName("mc_process_flag");

                entity.Property(e => e.McPushFlag).HasColumnName("mc_push_flag");

                entity.Property(e => e.McUnloadFlag).HasColumnName("mc_unload_flag");

                entity.Property(e => e.NcFile)
                    .HasColumnName("nc_file")
                    .HasMaxLength(500);

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.ReadyFlag).HasColumnName("ready_flag");

                entity.Property(e => e.SourceLocation)
                    .HasColumnName("source_location")
                    .HasMaxLength(200);

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TableNumber)
                    .HasColumnName("table_number")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasColumnName("task_name")
                    .HasMaxLength(20);

                entity.Property(e => e.TaskNumber)
                    .IsRequired()
                    .HasColumnName("task_number")
                    .HasMaxLength(25);

                entity.Property(e => e.TaskSeq).HasColumnName("task_seq");
            });

            modelBuilder.Entity<MfgJobTasks2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mfg_job_tasks2");

                entity.Property(e => e.CancelFlag).HasColumnName("cancel_flag");

                entity.Property(e => e.Code1).HasColumnName("CODE1");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(250);

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ErrorText)
                    .HasColumnName("error_text")
                    .HasMaxLength(2000);

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnName("last_update_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.MachineNo)
                    .HasColumnName("machine_no")
                    .HasMaxLength(50);

                entity.Property(e => e.Manager)
                    .HasColumnName("manager")
                    .HasMaxLength(240);

                entity.Property(e => e.MaterialCode)
                    .HasColumnName("material_code")
                    .HasMaxLength(50);

                entity.Property(e => e.McFinishFlag).HasColumnName("mc_finish_flag");

                entity.Property(e => e.McLoadFlag).HasColumnName("mc_load_flag");

                entity.Property(e => e.McPickFlag).HasColumnName("mc_pick_flag");

                entity.Property(e => e.McProcessFlag).HasColumnName("mc_process_flag");

                entity.Property(e => e.NcFile)
                    .HasColumnName("nc_file")
                    .HasMaxLength(500);

                entity.Property(e => e.ReadyFlag).HasColumnName("ready_flag");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TableNumber)
                    .HasColumnName("table_number")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasColumnName("task_name")
                    .HasMaxLength(20);

                entity.Property(e => e.TaskNumber)
                    .IsRequired()
                    .HasColumnName("task_number")
                    .HasMaxLength(25);

                entity.Property(e => e.TaskSeq).HasColumnName("task_seq");
            });

            modelBuilder.Entity<MfgJobTasks5>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mfg_job_tasks5");

                entity.Property(e => e.CancelFlag).HasColumnName("cancel_flag");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(250);

                entity.Property(e => e.DestinationLocation)
                    .HasColumnName("destination_location")
                    .HasMaxLength(200);

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ErrorText)
                    .HasColumnName("error_text")
                    .HasMaxLength(2000);

                entity.Property(e => e.JobEntityId).HasColumnName("job_entity_id");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnName("last_update_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.MachineNo)
                    .HasColumnName("machine_no")
                    .HasMaxLength(50);

                entity.Property(e => e.Manager)
                    .HasColumnName("manager")
                    .HasMaxLength(240);

                entity.Property(e => e.MaterialCode)
                    .HasColumnName("material_code")
                    .HasMaxLength(50);

                entity.Property(e => e.McFinishFlag).HasColumnName("mc_finish_flag");

                entity.Property(e => e.McLoadFlag).HasColumnName("mc_load_flag");

                entity.Property(e => e.McPickFlag).HasColumnName("mc_pick_flag");

                entity.Property(e => e.McProcessFlag).HasColumnName("mc_process_flag");

                entity.Property(e => e.McPushFlag).HasColumnName("mc_push_flag");

                entity.Property(e => e.McUnloadFlag).HasColumnName("mc_unload_flag");

                entity.Property(e => e.NcFile)
                    .HasColumnName("nc_file")
                    .HasMaxLength(500);

                entity.Property(e => e.NgFlag).HasColumnName("ng_flag");

                entity.Property(e => e.OnShelfFlag).HasColumnName("on_shelf_flag");

                entity.Property(e => e.OutboundFlag).HasColumnName("outbound_flag");

                entity.Property(e => e.PassFlag).HasColumnName("pass_flag");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.ReadyFlag).HasColumnName("ready_flag");

                entity.Property(e => e.SourceLocation)
                    .HasColumnName("source_location")
                    .HasMaxLength(200);

                entity.Property(e => e.StandardTime).HasColumnName("standard_time");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TableNumber)
                    .HasColumnName("table_number")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasColumnName("task_name")
                    .HasMaxLength(20);

                entity.Property(e => e.TaskNumber)
                    .IsRequired()
                    .HasColumnName("task_number")
                    .HasMaxLength(25);

                entity.Property(e => e.TaskSeq).HasColumnName("task_seq");
            });

            modelBuilder.Entity<MfgJobTransactionLogs>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mfg_job_transaction_logs");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasMaxLength(50);

                entity.Property(e => e.ActionTime)
                    .HasColumnName("action_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.JobEntityId).HasColumnName("job_entity_id");

                entity.Property(e => e.LogMessages)
                    .HasColumnName("log_messages")
                    .HasMaxLength(500);

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.TransactionLogId)
                    .HasColumnName("transaction_log_id")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<MfgMachines>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mfg_machines");

                entity.Property(e => e.ActiveFlag)
                    .HasColumnName("active_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CalendarId).HasColumnName("CalendarID");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EnableFlag)
                    .HasColumnName("enable_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EndTime).HasColumnType("smalldatetime");

                entity.Property(e => e.EtimeLunchHr)
                    .HasColumnName("ETIME_Lunch_hr")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("('13:00')");

                entity.Property(e => e.Fri).HasColumnName("FRI");

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnName("last_update_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("last_updated_by");

                entity.Property(e => e.MachineCode)
                    .HasColumnName("machine_code")
                    .HasMaxLength(50);

                entity.Property(e => e.MachineGroup)
                    .HasColumnName("machineGroup")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MachineId)
                    .HasColumnName("machine_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MachineModel)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.MaintenanceTime).HasColumnName("maintenance_time");

                entity.Property(e => e.Mon).HasColumnName("MON");

                entity.Property(e => e.PlantId)
                    .HasColumnName("PlantID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Port).HasColumnName("port");

                entity.Property(e => e.ProductionLine)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Sat).HasColumnName("SAT");

                entity.Property(e => e.Shift1)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Shift2)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ShiftOt)
                    .HasColumnName("ShiftOT")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.StartTime).HasColumnType("smalldatetime");

                entity.Property(e => e.StimeLunchHr)
                    .HasColumnName("STIME_Lunch_hr")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("('12:00')");

                entity.Property(e => e.Sun).HasColumnName("SUN");

                entity.Property(e => e.Thu).HasColumnName("THU");

                entity.Property(e => e.Tue).HasColumnName("TUE");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Wed).HasColumnName("WED");
            });

            modelBuilder.Entity<MfgShift>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mfg_shift");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Etime)
                    .HasColumnName("ETIME")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("('24:00')");

                entity.Property(e => e.Fri).HasColumnName("FRI");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Mon).HasColumnName("MON");

                entity.Property(e => e.RowPoiter).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Sat).HasColumnName("SAT");

                entity.Property(e => e.ShiftCode)
                    .HasColumnName("shift_code")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.ShiftDesc)
                    .HasColumnName("shift_desc")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.ShiftId).HasColumnName("shift_id");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.Stime)
                    .HasColumnName("STIME")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("('00:00')");

                entity.Property(e => e.Sun).HasColumnName("SUN");

                entity.Property(e => e.Thu).HasColumnName("THU");

                entity.Property(e => e.Tue).HasColumnName("TUE");

                entity.Property(e => e.Wed).HasColumnName("WED");
            });

            modelBuilder.Entity<MstShift>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mst_shift");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Etime)
                    .HasColumnName("ETIME")
                    .HasMaxLength(8);

                entity.Property(e => e.Fri).HasColumnName("FRI");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Mon).HasColumnName("MON");

                entity.Property(e => e.Sat).HasColumnName("SAT");

                entity.Property(e => e.ShiftCode)
                    .HasColumnName("shift_code")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.ShiftDesc)
                    .HasColumnName("shift_desc")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.ShiftId).HasColumnName("shift_id");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.Stime)
                    .HasColumnName("STIME")
                    .HasMaxLength(8);

                entity.Property(e => e.Sun).HasColumnName("SUN");

                entity.Property(e => e.Thu).HasColumnName("THU");

                entity.Property(e => e.Tue).HasColumnName("TUE");

                entity.Property(e => e.Wed).HasColumnName("WED");
            });

            modelBuilder.Entity<PlnCalendar>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pln_calendar");

                entity.Property(e => e.CalendarId)
                    .HasColumnName("CALENDAR_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CREATION_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnName("LAST_UPDATE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.YearNum).HasColumnName("YEAR_NUM");
            });

            modelBuilder.Entity<PlnCalendarDays>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pln_calendar_days");

                entity.Property(e => e.AsOfDate)
                    .HasColumnName("AS_OF_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.CalendarId).HasColumnName("CALENDAR_ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("CREATION_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.DayId)
                    .HasColumnName("DAY_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnName("LAST_UPDATE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.ShiftDay).HasColumnName("SHIFT_DAY");

                entity.Property(e => e.ShiftNight).HasColumnName("SHIFT_NIGHT");

                entity.Property(e => e.Status).HasColumnName("STATUS");
            });

            modelBuilder.Entity<Table1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Table_1");

                entity.Property(e => e.Test1)
                    .HasColumnName("test1")
                    .HasMaxLength(50);

                entity.Property(e => e.Test2)
                    .HasColumnName("test2")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ViewJobStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_JobStatus");

                entity.Property(e => e.JobEntityId).HasColumnName("job_entity_id");
            });

            modelBuilder.Entity<ViewJobTaskStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_JobTaskStatus");

                entity.Property(e => e.CancelFlag)
                    .IsRequired()
                    .HasColumnName("cancel_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompletedFlag)
                    .IsRequired()
                    .HasColumnName("completed_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(240);

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.JobEntiryDate)
                    .HasColumnName("job_entiry_date")
                    .HasColumnType("date");

                entity.Property(e => e.JobEntityId).HasColumnName("job_entity_id");

                entity.Property(e => e.JobEntityName)
                    .IsRequired()
                    .HasColumnName("job_entity_name")
                    .HasMaxLength(240);

                entity.Property(e => e.JobNumber)
                    .HasColumnName("job_number")
                    .HasMaxLength(20);

                entity.Property(e => e.MachineNo)
                    .HasColumnName("machine_no")
                    .HasMaxLength(50);

                entity.Property(e => e.MachineNoReady)
                    .HasColumnName("machine_no_ready")
                    .HasMaxLength(50);

                entity.Property(e => e.MaterialCode)
                    .HasColumnName("material_code")
                    .HasMaxLength(50);

                entity.Property(e => e.McFinishFlag).HasColumnName("mc_finish_flag");

                entity.Property(e => e.McLoadFlag).HasColumnName("mc_load_flag");

                entity.Property(e => e.McProcessFlag).HasColumnName("mc_process_flag");

                entity.Property(e => e.McPushFlag).HasColumnName("mc_push_flag");

                entity.Property(e => e.McUnloadFlag).HasColumnName("mc_unload_flag");

                entity.Property(e => e.NcFile)
                    .HasColumnName("nc_file")
                    .HasMaxLength(500);

                entity.Property(e => e.OnShelfFlag).HasColumnName("on_shelf_flag");

                entity.Property(e => e.OpenStatus)
                    .IsRequired()
                    .HasColumnName("open_status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OutboundFinishFlag).HasColumnName("outbound_finish_flag");

                entity.Property(e => e.OutboundFlag).HasColumnName("outbound_flag");

                entity.Property(e => e.PrimaryItemCode)
                    .HasColumnName("primary_item_code")
                    .HasMaxLength(240);

                entity.Property(e => e.PrimaryItemModel)
                    .HasColumnName("primary_item_model")
                    .HasMaxLength(240);

                entity.Property(e => e.PrimaryQuantity)
                    .HasColumnName("primary_quantity")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.QcStatus)
                    .HasColumnName("qc_status")
                    .HasMaxLength(50);

                entity.Property(e => e.ReadyFlag).HasColumnName("ready_flag");

                entity.Property(e => e.ReleaseFlag).HasColumnName("release_flag");

                entity.Property(e => e.ReserveShelfFlag).HasColumnName("reserve_shelf_flag");

                entity.Property(e => e.ShelfNumber)
                    .HasColumnName("shelf_number")
                    .HasMaxLength(200);

                entity.Property(e => e.StandardTime).HasColumnName("standard_time");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartFlag).HasColumnName("Start_Flag");

                entity.Property(e => e.TableNumber)
                    .HasColumnName("table_number")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.UploadNcfileFlag).HasColumnName("upload_ncfile_flag");
            });

            modelBuilder.Entity<ViewJobTotalActual>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_JobTotalActual");

                entity.Property(e => e.ActualQty).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.MachineNo)
                    .HasColumnName("machine_no")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ViewJobTotalPlan>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_JobTotalPlan");

                entity.Property(e => e.MachineNo)
                    .HasColumnName("machine_no")
                    .HasMaxLength(50);

                entity.Property(e => e.PlanQty).HasColumnType("decimal(38, 2)");
            });

            modelBuilder.Entity<ViewLocationStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_LocationStatus");

                entity.Property(e => e.AvailableFlag).HasColumnName("available_flag");

                entity.Property(e => e.CancelFlag)
                    .HasColumnName("cancel_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompletedFlag)
                    .HasColumnName("completed_flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(240);

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FillFlag).HasColumnName("fill_flag");

                entity.Property(e => e.JobEntiryDate)
                    .HasColumnName("job_entiry_date")
                    .HasColumnType("date");

                entity.Property(e => e.JobEntityId).HasColumnName("job_entity_id");

                entity.Property(e => e.JobEntityName)
                    .HasColumnName("job_entity_name")
                    .HasMaxLength(240);

                entity.Property(e => e.JobNumber)
                    .HasColumnName("job_number")
                    .HasMaxLength(20);

                entity.Property(e => e.MachineNo)
                    .HasColumnName("machine_no")
                    .HasMaxLength(50);

                entity.Property(e => e.MachineNoReady)
                    .HasColumnName("machine_no_ready")
                    .HasMaxLength(50);

                entity.Property(e => e.MaterialCode)
                    .HasColumnName("material_code")
                    .HasMaxLength(50);

                entity.Property(e => e.McFinishFlag).HasColumnName("mc_finish_flag");

                entity.Property(e => e.McLoadFlag).HasColumnName("mc_load_flag");

                entity.Property(e => e.McProcessFlag).HasColumnName("mc_process_flag");

                entity.Property(e => e.McPushFlag).HasColumnName("mc_push_flag");

                entity.Property(e => e.McUnloadFlag).HasColumnName("mc_unload_flag");

                entity.Property(e => e.NcFile)
                    .HasColumnName("nc_file")
                    .HasMaxLength(500);

                entity.Property(e => e.OnShelfFlag).HasColumnName("on_shelf_flag");

                entity.Property(e => e.OpenStatus)
                    .HasColumnName("open_status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OutboundFinishFlag).HasColumnName("outbound_finish_flag");

                entity.Property(e => e.OutboundFlag).HasColumnName("outbound_flag");

                entity.Property(e => e.PrimaryItemCode)
                    .HasColumnName("primary_item_code")
                    .HasMaxLength(240);

                entity.Property(e => e.PrimaryItemModel)
                    .HasColumnName("primary_item_model")
                    .HasMaxLength(240);

                entity.Property(e => e.PrimaryQuantity)
                    .HasColumnName("primary_quantity")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.QcStatus)
                    .HasColumnName("qc_status")
                    .HasMaxLength(50);

                entity.Property(e => e.ReadyFlag).HasColumnName("ready_flag");

                entity.Property(e => e.ReleaseFlag).HasColumnName("release_flag");

                entity.Property(e => e.ReserveFlag).HasColumnName("reserve_flag");

                entity.Property(e => e.ReserveShelfFlag).HasColumnName("reserve_shelf_flag");

                entity.Property(e => e.ShelfNo).HasMaxLength(20);

                entity.Property(e => e.ShelfNumber)
                    .HasColumnName("shelf_number")
                    .HasMaxLength(200);

                entity.Property(e => e.StandardTime).HasColumnName("standard_time");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartFlag).HasColumnName("Start_Flag");

                entity.Property(e => e.TableNumber)
                    .HasColumnName("table_number")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskId1).HasColumnName("task_id");

                entity.Property(e => e.Taskid).HasColumnName("taskid");

                entity.Property(e => e.UploadNcfileFlag).HasColumnName("upload_ncfile_flag");
            });

            modelBuilder.Entity<ViewMachineMonitoring>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Machine_monitoring");

                entity.Property(e => e.Avialability).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BreakdownTime).HasColumnName("breakdown_time");

                entity.Property(e => e.CompleteQty).HasColumnName("complete_qty");

                entity.Property(e => e.InboundTimeHr)
                    .HasColumnName("InboundTimeHR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InboundTimeMm)
                    .HasColumnName("InboundTimeMM")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.JoborderQty)
                    .HasColumnName("joborder_qty")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.LoadingTimeHr)
                    .HasColumnName("LoadingTimeHR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LoadingTimeMm)
                    .HasColumnName("LoadingTimeMM")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MachineCode)
                    .HasColumnName("machine_code")
                    .HasMaxLength(50);

                entity.Property(e => e.MachineTimeHr)
                    .HasColumnName("MachineTimeHR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MachineTimeMm)
                    .HasColumnName("MachineTimeMM")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MaintenanceTime).HasColumnName("maintenance_time");

                entity.Property(e => e.OutboundTimeHr)
                    .HasColumnName("OutboundTimeHR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OutboundTimeMm)
                    .HasColumnName("OutboundTimeMM")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Performance).HasColumnType("decimal(38, 16)");

                entity.Property(e => e.PlanningQty)
                    .HasColumnName("planning_qty")
                    .HasColumnType("decimal(38, 2)");

                entity.Property(e => e.PlanningTimeHr)
                    .HasColumnName("PlanningTimeHR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PlanningTimeMm)
                    .HasColumnName("PlanningTimeMM")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductionPlanningTime).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductionRunningTime).HasColumnType("decimal(20, 2)");

                entity.Property(e => e.QtyHold).HasColumnName("Qty_Hold");

                entity.Property(e => e.QtyPass).HasColumnName("Qty_Pass");

                entity.Property(e => e.QtyReject).HasColumnName("Qty_Reject");

                entity.Property(e => e.QtyRework).HasColumnName("Qty_Rework");

                entity.Property(e => e.ReleaseQty).HasColumnName("release_qty");

                entity.Property(e => e.SetupTime).HasColumnName("setup_time");

                entity.Property(e => e.StandardTimeHh)
                    .HasColumnName("StandardTimeHH")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StandardTimeMm)
                    .HasColumnName("StandardTimeMM")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TranactionDate)
                    .HasColumnName("Tranaction_date")
                    .HasColumnType("date");

                entity.Property(e => e.UnloadTimeHr)
                    .HasColumnName("UnloadTimeHR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnloadTimeMm)
                    .HasColumnName("UnloadTimeMM")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WorkingTimeHr)
                    .HasColumnName("WorkingTimeHR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WorkingTimeMm)
                    .HasColumnName("WorkingTimeMM")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<ViewMfgJobTransactionLogs>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_mfg_job_transaction_logs");

                entity.Property(e => e.ActFinishDate)
                    .HasColumnName("Act_finishDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActInboundTime).HasColumnName("Act_InboundTime");

                entity.Property(e => e.ActLoadingDate)
                    .HasColumnName("Act_loadingDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActLoadingTime).HasColumnName("Act_LoadingTime");

                entity.Property(e => e.ActMachineTime).HasColumnName("Act_MachineTime");

                entity.Property(e => e.ActOnShelfDate)
                    .HasColumnName("Act_on_shelfDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActOutboundDate)
                    .HasColumnName("Act_outboundDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActOutboundTime).HasColumnName("Act_OutboundTime");

                entity.Property(e => e.ActReleaseDate)
                    .HasColumnName("Act_releaseDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActStartDate)
                    .HasColumnName("Act_startDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActUnloadTime).HasColumnName("Act_UnloadTime");

                entity.Property(e => e.ActUnloadingDate)
                    .HasColumnName("Act_unloadingDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.JobEntityId).HasColumnName("job_entity_id");

                entity.Property(e => e.TaskId).HasColumnName("task_id");
            });

            modelBuilder.Entity<ViewProductionMonitoring>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_production_monitoring");

                entity.Property(e => e.ActFinishDate)
                    .HasColumnName("Act_finishDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActInboundTime).HasColumnName("Act_InboundTime");

                entity.Property(e => e.ActInboundTime1)
                    .HasColumnName("Act_InboundTime1")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ActLoadingDate)
                    .HasColumnName("Act_loadingDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActLoadingTime).HasColumnName("Act_LoadingTime");

                entity.Property(e => e.ActLoadingTime1)
                    .HasColumnName("Act_LoadingTime1")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ActMachineTime).HasColumnName("Act_MachineTime");

                entity.Property(e => e.ActMachineTime1)
                    .HasColumnName("Act_MachineTime1")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ActOnShelfDate)
                    .HasColumnName("Act_on_shelfDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActOutboundDate)
                    .HasColumnName("Act_outboundDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActOutboundTime).HasColumnName("Act_OutboundTime");

                entity.Property(e => e.ActOutboundTime1)
                    .HasColumnName("Act_OutboundTime1")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ActReleaseDate)
                    .HasColumnName("Act_releaseDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActStartDate)
                    .HasColumnName("Act_startDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActUnloadTime).HasColumnName("Act_UnloadTime");

                entity.Property(e => e.ActUnloadTime1)
                    .HasColumnName("Act_UnloadTime1")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ActUnloadingDate)
                    .HasColumnName("Act_unloadingDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.BreakdownTime).HasColumnName("breakdown_time");

                entity.Property(e => e.BreakdownType)
                    .IsRequired()
                    .HasColumnName("breakdown_type")
                    .HasMaxLength(50);

                entity.Property(e => e.CompleteQty).HasColumnName("complete_qty");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(240);

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.JobEntityId).HasColumnName("job_entity_id");

                entity.Property(e => e.JobNumber)
                    .HasColumnName("job_number")
                    .HasMaxLength(20);

                entity.Property(e => e.JoborderQty)
                    .HasColumnName("joborder_qty")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MachineCode)
                    .HasColumnName("machine_code")
                    .HasMaxLength(50);

                entity.Property(e => e.MachineNo)
                    .HasColumnName("machine_no")
                    .HasMaxLength(50);

                entity.Property(e => e.MachineNoReady)
                    .IsRequired()
                    .HasColumnName("machine_no_ready")
                    .HasMaxLength(50);

                entity.Property(e => e.MaintenanceTime).HasColumnName("maintenance_time");

                entity.Property(e => e.MaterialCode)
                    .HasColumnName("material_code")
                    .HasMaxLength(50);

                entity.Property(e => e.McFinishFlag).HasColumnName("mc_finish_flag");

                entity.Property(e => e.McLoadFlag).HasColumnName("mc_load_flag");

                entity.Property(e => e.McProcessFlag).HasColumnName("mc_process_flag");

                entity.Property(e => e.McPushFlag).HasColumnName("mc_push_flag");

                entity.Property(e => e.McUnloadFlag).HasColumnName("mc_unload_flag");

                entity.Property(e => e.Model)
                    .HasColumnName("MODEL")
                    .HasMaxLength(240);

                entity.Property(e => e.NcFile)
                    .HasColumnName("nc_file")
                    .HasMaxLength(500);

                entity.Property(e => e.OnShelfFlag).HasColumnName("on_shelf_flag");

                entity.Property(e => e.OutboundFinishFlag).HasColumnName("outbound_finish_flag");

                entity.Property(e => e.OutboundFlag).HasColumnName("outbound_flag");

                entity.Property(e => e.PartNumber).HasMaxLength(240);

                entity.Property(e => e.PlaningTimeHr)
                    .HasColumnName("PlaningTimeHR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PlaningTimeMm).HasColumnName("Planing_TimeMM");

                entity.Property(e => e.PlanningQty)
                    .HasColumnName("planning_qty")
                    .HasColumnType("decimal(19, 2)");

                entity.Property(e => e.PlanningTimeMm)
                    .HasColumnName("PlanningTimeMM")
                    .HasColumnType("decimal(38, 4)");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.QcStatus)
                    .HasColumnName("qc_status")
                    .HasMaxLength(50);

                entity.Property(e => e.ReadyFlag).HasColumnName("ready_flag");

                entity.Property(e => e.ReleaseFlag).HasColumnName("release_flag");

                entity.Property(e => e.ReleaseQty).HasColumnName("release_qty");

                entity.Property(e => e.ReserveShelfFlag).HasColumnName("reserve_shelf_flag");

                entity.Property(e => e.SetupTime).HasColumnName("setup_time");

                entity.Property(e => e.ShelfNumber)
                    .HasColumnName("shelf_number")
                    .HasMaxLength(200);

                entity.Property(e => e.StandardTime).HasColumnName("standard_time");

                entity.Property(e => e.StandardTimeHr)
                    .HasColumnName("StandardTimeHR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StandardTimeMm)
                    .HasColumnName("StandardTimeMM")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartFlag).HasColumnName("Start_Flag");

                entity.Property(e => e.TableNumber)
                    .HasColumnName("table_number")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.UploadNcfileFlag).HasColumnName("upload_ncfile_flag");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
