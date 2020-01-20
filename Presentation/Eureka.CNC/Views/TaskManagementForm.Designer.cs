namespace Eureka.CNC.Views
{
    partial class TaskManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskManagementForm));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.dgvTasks = new MetroFramework.Controls.MetroGrid();
            this.priorityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskSeqDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrimaryItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrimaryItemModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrimaryQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.managerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.standardTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dueDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancelFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lastUpdateDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.readyFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.releaseFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.uploadNcfileFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.materialCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machineNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reserveShelfFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.shelfNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onShelfFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mcProcessFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mcLoadFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mcFinishFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mcUnloadFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mcPushFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.outboundFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ncFileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mcPickFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.qCStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobTaskModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNav = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboFilterType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cboFilterBy = new System.Windows.Forms.ToolStripComboBox();
            this.txtFilterWord = new System.Windows.Forms.ToolStripTextBox();
            this.mnuFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRelease = new System.Windows.Forms.ToolStripButton();
            this.mnuQCInspection = new System.Windows.Forms.ToolStripSplitButton();
            this.mnuQCPass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQCNG = new System.Windows.Forms.ToolStripMenuItem();
            this.cboSortType = new System.Windows.Forms.ToolStripComboBox();
            this.cboSortBy = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.mnuAutoScheduling = new System.Windows.Forms.ToolStripButton();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobTaskModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).BeginInit();
            this.bindingNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel1.Controls.Add(this.dgvTasks);
            this.metroPanel1.Controls.Add(this.bindingNav);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1466, 610);
            this.metroPanel1.TabIndex = 40;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToDeleteRows = false;
            this.dgvTasks.AllowUserToOrderColumns = true;
            this.dgvTasks.AllowUserToResizeRows = false;
            this.dgvTasks.AutoGenerateColumns = false;
            this.dgvTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTasks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTasks.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTasks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvTasks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTasks.ColumnHeadersHeight = 25;
            this.dgvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.priorityDataGridViewTextBoxColumn,
            this.taskIdDataGridViewTextBoxColumn,
            this.taskSeqDataGridViewTextBoxColumn,
            this.jobIdDataGridViewTextBoxColumn,
            this.taskNumberDataGridViewTextBoxColumn,
            this.jobNumberDataGridViewTextBoxColumn,
            this.PrimaryItemCode,
            this.PrimaryItemModel,
            this.PrimaryQuantity,
            this.descriptionDataGridViewTextBoxColumn,
            this.managerDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.endDateDataGridViewTextBoxColumn,
            this.standardTimeDataGridViewTextBoxColumn,
            this.dueDateDataGridViewTextBoxColumn,
            this.cancelFlagDataGridViewCheckBoxColumn,
            this.lastUpdateDateDataGridViewTextBoxColumn,
            this.lastUpdatedByDataGridViewTextBoxColumn,
            this.creationDateDataGridViewTextBoxColumn,
            this.createdByDataGridViewTextBoxColumn,
            this.errorTextDataGridViewTextBoxColumn,
            this.readyFlagDataGridViewCheckBoxColumn,
            this.releaseFlagDataGridViewCheckBoxColumn,
            this.uploadNcfileFlagDataGridViewCheckBoxColumn,
            this.materialCodeDataGridViewTextBoxColumn,
            this.tableNumberDataGridViewTextBoxColumn,
            this.machineNoDataGridViewTextBoxColumn,
            this.sourceDataGridViewTextBoxColumn,
            this.reserveShelfFlagDataGridViewCheckBoxColumn,
            this.shelfNumberDataGridViewTextBoxColumn,
            this.onShelfFlagDataGridViewCheckBoxColumn,
            this.mcProcessFlagDataGridViewCheckBoxColumn,
            this.mcLoadFlagDataGridViewCheckBoxColumn,
            this.mcFinishFlagDataGridViewCheckBoxColumn,
            this.mcUnloadFlagDataGridViewCheckBoxColumn,
            this.mcPushFlagDataGridViewCheckBoxColumn,
            this.outboundFlagDataGridViewCheckBoxColumn,
            this.ncFileDataGridViewTextBoxColumn,
            this.mcPickFlagDataGridViewCheckBoxColumn,
            this.qCStatusDataGridViewTextBoxColumn});
            this.dgvTasks.DataSource = this.jobTaskModelBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTasks.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTasks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTasks.EnableHeadersVisualStyles = false;
            this.dgvTasks.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvTasks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvTasks.Location = new System.Drawing.Point(0, 31);
            this.dgvTasks.MultiSelect = false;
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasks.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTasks.RowHeadersWidth = 30;
            this.dgvTasks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dgvTasks.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTasks.RowTemplate.Height = 60;
            this.dgvTasks.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.Size = new System.Drawing.Size(1466, 579);
            this.dgvTasks.Style = MetroFramework.MetroColorStyle.Blue;
            this.dgvTasks.TabIndex = 41;
            this.dgvTasks.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dgvTasks.UseCustomBackColor = true;
            this.dgvTasks.UseCustomForeColor = true;
            this.dgvTasks.UseStyleColors = true;
            // 
            // priorityDataGridViewTextBoxColumn
            // 
            this.priorityDataGridViewTextBoxColumn.DataPropertyName = "Priority";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.priorityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.priorityDataGridViewTextBoxColumn.HeaderText = "Priority";
            this.priorityDataGridViewTextBoxColumn.Name = "priorityDataGridViewTextBoxColumn";
            this.priorityDataGridViewTextBoxColumn.Width = 73;
            // 
            // taskIdDataGridViewTextBoxColumn
            // 
            this.taskIdDataGridViewTextBoxColumn.DataPropertyName = "TaskId";
            this.taskIdDataGridViewTextBoxColumn.HeaderText = "TaskId";
            this.taskIdDataGridViewTextBoxColumn.Name = "taskIdDataGridViewTextBoxColumn";
            this.taskIdDataGridViewTextBoxColumn.Visible = false;
            this.taskIdDataGridViewTextBoxColumn.Width = 69;
            // 
            // taskSeqDataGridViewTextBoxColumn
            // 
            this.taskSeqDataGridViewTextBoxColumn.DataPropertyName = "TaskSeq";
            this.taskSeqDataGridViewTextBoxColumn.HeaderText = "TaskSeq";
            this.taskSeqDataGridViewTextBoxColumn.Name = "taskSeqDataGridViewTextBoxColumn";
            this.taskSeqDataGridViewTextBoxColumn.Visible = false;
            this.taskSeqDataGridViewTextBoxColumn.Width = 80;
            // 
            // jobIdDataGridViewTextBoxColumn
            // 
            this.jobIdDataGridViewTextBoxColumn.DataPropertyName = "JobId";
            this.jobIdDataGridViewTextBoxColumn.HeaderText = "JobId";
            this.jobIdDataGridViewTextBoxColumn.Name = "jobIdDataGridViewTextBoxColumn";
            this.jobIdDataGridViewTextBoxColumn.Visible = false;
            this.jobIdDataGridViewTextBoxColumn.Width = 67;
            // 
            // taskNumberDataGridViewTextBoxColumn
            // 
            this.taskNumberDataGridViewTextBoxColumn.DataPropertyName = "TaskNumber";
            this.taskNumberDataGridViewTextBoxColumn.HeaderText = "TaskNumber";
            this.taskNumberDataGridViewTextBoxColumn.Name = "taskNumberDataGridViewTextBoxColumn";
            this.taskNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.taskNumberDataGridViewTextBoxColumn.Width = 109;
            // 
            // jobNumberDataGridViewTextBoxColumn
            // 
            this.jobNumberDataGridViewTextBoxColumn.DataPropertyName = "JobNumber";
            this.jobNumberDataGridViewTextBoxColumn.HeaderText = "JobNumber";
            this.jobNumberDataGridViewTextBoxColumn.Name = "jobNumberDataGridViewTextBoxColumn";
            this.jobNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.jobNumberDataGridViewTextBoxColumn.Width = 107;
            // 
            // PrimaryItemCode
            // 
            this.PrimaryItemCode.DataPropertyName = "PrimaryItemCode";
            this.PrimaryItemCode.HeaderText = "Item Code";
            this.PrimaryItemCode.Name = "PrimaryItemCode";
            this.PrimaryItemCode.ReadOnly = true;
            this.PrimaryItemCode.Width = 101;
            // 
            // PrimaryItemModel
            // 
            this.PrimaryItemModel.DataPropertyName = "PrimaryItemModel";
            this.PrimaryItemModel.HeaderText = "Model";
            this.PrimaryItemModel.Name = "PrimaryItemModel";
            this.PrimaryItemModel.ReadOnly = true;
            this.PrimaryItemModel.Width = 71;
            // 
            // PrimaryQuantity
            // 
            this.PrimaryQuantity.DataPropertyName = "PrimaryQuantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PrimaryQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.PrimaryQuantity.HeaderText = "Qty.";
            this.PrimaryQuantity.Name = "PrimaryQuantity";
            this.PrimaryQuantity.ReadOnly = true;
            this.PrimaryQuantity.Width = 57;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Visible = false;
            this.descriptionDataGridViewTextBoxColumn.Width = 103;
            // 
            // managerDataGridViewTextBoxColumn
            // 
            this.managerDataGridViewTextBoxColumn.DataPropertyName = "Manager";
            this.managerDataGridViewTextBoxColumn.HeaderText = "Manager";
            this.managerDataGridViewTextBoxColumn.Name = "managerDataGridViewTextBoxColumn";
            this.managerDataGridViewTextBoxColumn.Visible = false;
            this.managerDataGridViewTextBoxColumn.Width = 89;
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "Start Date";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            this.startDateDataGridViewTextBoxColumn.Width = 96;
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "End Date";
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            this.endDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.endDateDataGridViewTextBoxColumn.Width = 91;
            // 
            // standardTimeDataGridViewTextBoxColumn
            // 
            this.standardTimeDataGridViewTextBoxColumn.DataPropertyName = "StandardTime";
            this.standardTimeDataGridViewTextBoxColumn.HeaderText = "Standard Time";
            this.standardTimeDataGridViewTextBoxColumn.Name = "standardTimeDataGridViewTextBoxColumn";
            this.standardTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.standardTimeDataGridViewTextBoxColumn.Width = 123;
            // 
            // dueDateDataGridViewTextBoxColumn
            // 
            this.dueDateDataGridViewTextBoxColumn.DataPropertyName = "DueDate";
            this.dueDateDataGridViewTextBoxColumn.HeaderText = "Due Date";
            this.dueDateDataGridViewTextBoxColumn.Name = "dueDateDataGridViewTextBoxColumn";
            this.dueDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dueDateDataGridViewTextBoxColumn.Width = 93;
            // 
            // cancelFlagDataGridViewCheckBoxColumn
            // 
            this.cancelFlagDataGridViewCheckBoxColumn.DataPropertyName = "CancelFlag";
            this.cancelFlagDataGridViewCheckBoxColumn.HeaderText = "CancelFlag";
            this.cancelFlagDataGridViewCheckBoxColumn.Name = "cancelFlagDataGridViewCheckBoxColumn";
            this.cancelFlagDataGridViewCheckBoxColumn.Visible = false;
            this.cancelFlagDataGridViewCheckBoxColumn.Width = 86;
            // 
            // lastUpdateDateDataGridViewTextBoxColumn
            // 
            this.lastUpdateDateDataGridViewTextBoxColumn.DataPropertyName = "LastUpdateDate";
            this.lastUpdateDateDataGridViewTextBoxColumn.HeaderText = "LastUpdateDate";
            this.lastUpdateDateDataGridViewTextBoxColumn.Name = "lastUpdateDateDataGridViewTextBoxColumn";
            this.lastUpdateDateDataGridViewTextBoxColumn.Visible = false;
            this.lastUpdateDateDataGridViewTextBoxColumn.Width = 136;
            // 
            // lastUpdatedByDataGridViewTextBoxColumn
            // 
            this.lastUpdatedByDataGridViewTextBoxColumn.DataPropertyName = "LastUpdatedBy";
            this.lastUpdatedByDataGridViewTextBoxColumn.HeaderText = "LastUpdatedBy";
            this.lastUpdatedByDataGridViewTextBoxColumn.Name = "lastUpdatedByDataGridViewTextBoxColumn";
            this.lastUpdatedByDataGridViewTextBoxColumn.Visible = false;
            this.lastUpdatedByDataGridViewTextBoxColumn.Width = 126;
            // 
            // creationDateDataGridViewTextBoxColumn
            // 
            this.creationDateDataGridViewTextBoxColumn.DataPropertyName = "CreationDate";
            this.creationDateDataGridViewTextBoxColumn.HeaderText = "CreationDate";
            this.creationDateDataGridViewTextBoxColumn.Name = "creationDateDataGridViewTextBoxColumn";
            this.creationDateDataGridViewTextBoxColumn.Visible = false;
            this.creationDateDataGridViewTextBoxColumn.Width = 120;
            // 
            // createdByDataGridViewTextBoxColumn
            // 
            this.createdByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn.HeaderText = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn.Name = "createdByDataGridViewTextBoxColumn";
            this.createdByDataGridViewTextBoxColumn.Visible = false;
            this.createdByDataGridViewTextBoxColumn.Width = 98;
            // 
            // errorTextDataGridViewTextBoxColumn
            // 
            this.errorTextDataGridViewTextBoxColumn.DataPropertyName = "ErrorText";
            this.errorTextDataGridViewTextBoxColumn.HeaderText = "ErrorText";
            this.errorTextDataGridViewTextBoxColumn.Name = "errorTextDataGridViewTextBoxColumn";
            this.errorTextDataGridViewTextBoxColumn.Visible = false;
            this.errorTextDataGridViewTextBoxColumn.Width = 83;
            // 
            // readyFlagDataGridViewCheckBoxColumn
            // 
            this.readyFlagDataGridViewCheckBoxColumn.DataPropertyName = "ReadyFlag";
            this.readyFlagDataGridViewCheckBoxColumn.HeaderText = "Ready";
            this.readyFlagDataGridViewCheckBoxColumn.Name = "readyFlagDataGridViewCheckBoxColumn";
            this.readyFlagDataGridViewCheckBoxColumn.ReadOnly = true;
            this.readyFlagDataGridViewCheckBoxColumn.Width = 52;
            // 
            // releaseFlagDataGridViewCheckBoxColumn
            // 
            this.releaseFlagDataGridViewCheckBoxColumn.DataPropertyName = "ReleaseFlag";
            this.releaseFlagDataGridViewCheckBoxColumn.HeaderText = "Release";
            this.releaseFlagDataGridViewCheckBoxColumn.Name = "releaseFlagDataGridViewCheckBoxColumn";
            this.releaseFlagDataGridViewCheckBoxColumn.ReadOnly = true;
            this.releaseFlagDataGridViewCheckBoxColumn.Visible = false;
            this.releaseFlagDataGridViewCheckBoxColumn.Width = 61;
            // 
            // uploadNcfileFlagDataGridViewCheckBoxColumn
            // 
            this.uploadNcfileFlagDataGridViewCheckBoxColumn.DataPropertyName = "UploadNcfileFlag";
            this.uploadNcfileFlagDataGridViewCheckBoxColumn.HeaderText = "Upload NC file";
            this.uploadNcfileFlagDataGridViewCheckBoxColumn.Name = "uploadNcfileFlagDataGridViewCheckBoxColumn";
            this.uploadNcfileFlagDataGridViewCheckBoxColumn.ReadOnly = true;
            this.uploadNcfileFlagDataGridViewCheckBoxColumn.Visible = false;
            this.uploadNcfileFlagDataGridViewCheckBoxColumn.Width = 106;
            // 
            // materialCodeDataGridViewTextBoxColumn
            // 
            this.materialCodeDataGridViewTextBoxColumn.DataPropertyName = "MaterialCode";
            this.materialCodeDataGridViewTextBoxColumn.HeaderText = "Material";
            this.materialCodeDataGridViewTextBoxColumn.Name = "materialCodeDataGridViewTextBoxColumn";
            this.materialCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.materialCodeDataGridViewTextBoxColumn.Width = 83;
            // 
            // tableNumberDataGridViewTextBoxColumn
            // 
            this.tableNumberDataGridViewTextBoxColumn.DataPropertyName = "TableNumber";
            this.tableNumberDataGridViewTextBoxColumn.HeaderText = "Table No.";
            this.tableNumberDataGridViewTextBoxColumn.Name = "tableNumberDataGridViewTextBoxColumn";
            this.tableNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.tableNumberDataGridViewTextBoxColumn.Width = 92;
            // 
            // machineNoDataGridViewTextBoxColumn
            // 
            this.machineNoDataGridViewTextBoxColumn.DataPropertyName = "MachineNo";
            this.machineNoDataGridViewTextBoxColumn.HeaderText = "Machine";
            this.machineNoDataGridViewTextBoxColumn.Name = "machineNoDataGridViewTextBoxColumn";
            this.machineNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.machineNoDataGridViewTextBoxColumn.Width = 86;
            // 
            // sourceDataGridViewTextBoxColumn
            // 
            this.sourceDataGridViewTextBoxColumn.DataPropertyName = "Source";
            this.sourceDataGridViewTextBoxColumn.HeaderText = "Source";
            this.sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
            this.sourceDataGridViewTextBoxColumn.ReadOnly = true;
            this.sourceDataGridViewTextBoxColumn.Visible = false;
            this.sourceDataGridViewTextBoxColumn.Width = 74;
            // 
            // reserveShelfFlagDataGridViewCheckBoxColumn
            // 
            this.reserveShelfFlagDataGridViewCheckBoxColumn.DataPropertyName = "ReserveShelfFlag";
            this.reserveShelfFlagDataGridViewCheckBoxColumn.HeaderText = "Reserve Shelf";
            this.reserveShelfFlagDataGridViewCheckBoxColumn.Name = "reserveShelfFlagDataGridViewCheckBoxColumn";
            this.reserveShelfFlagDataGridViewCheckBoxColumn.ReadOnly = true;
            this.reserveShelfFlagDataGridViewCheckBoxColumn.Width = 94;
            // 
            // shelfNumberDataGridViewTextBoxColumn
            // 
            this.shelfNumberDataGridViewTextBoxColumn.DataPropertyName = "ShelfNumber";
            this.shelfNumberDataGridViewTextBoxColumn.HeaderText = "Shelf No.";
            this.shelfNumberDataGridViewTextBoxColumn.Name = "shelfNumberDataGridViewTextBoxColumn";
            this.shelfNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.shelfNumberDataGridViewTextBoxColumn.Width = 87;
            // 
            // onShelfFlagDataGridViewCheckBoxColumn
            // 
            this.onShelfFlagDataGridViewCheckBoxColumn.DataPropertyName = "OnShelfFlag";
            this.onShelfFlagDataGridViewCheckBoxColumn.HeaderText = "On Shelf";
            this.onShelfFlagDataGridViewCheckBoxColumn.Name = "onShelfFlagDataGridViewCheckBoxColumn";
            this.onShelfFlagDataGridViewCheckBoxColumn.ReadOnly = true;
            this.onShelfFlagDataGridViewCheckBoxColumn.Visible = false;
            this.onShelfFlagDataGridViewCheckBoxColumn.Width = 64;
            // 
            // mcProcessFlagDataGridViewCheckBoxColumn
            // 
            this.mcProcessFlagDataGridViewCheckBoxColumn.DataPropertyName = "McProcessFlag";
            this.mcProcessFlagDataGridViewCheckBoxColumn.HeaderText = "Process";
            this.mcProcessFlagDataGridViewCheckBoxColumn.Name = "mcProcessFlagDataGridViewCheckBoxColumn";
            this.mcProcessFlagDataGridViewCheckBoxColumn.ReadOnly = true;
            this.mcProcessFlagDataGridViewCheckBoxColumn.Visible = false;
            this.mcProcessFlagDataGridViewCheckBoxColumn.Width = 59;
            // 
            // mcLoadFlagDataGridViewCheckBoxColumn
            // 
            this.mcLoadFlagDataGridViewCheckBoxColumn.DataPropertyName = "McLoadFlag";
            this.mcLoadFlagDataGridViewCheckBoxColumn.HeaderText = "Load";
            this.mcLoadFlagDataGridViewCheckBoxColumn.Name = "mcLoadFlagDataGridViewCheckBoxColumn";
            this.mcLoadFlagDataGridViewCheckBoxColumn.ReadOnly = true;
            this.mcLoadFlagDataGridViewCheckBoxColumn.Visible = false;
            this.mcLoadFlagDataGridViewCheckBoxColumn.Width = 45;
            // 
            // mcFinishFlagDataGridViewCheckBoxColumn
            // 
            this.mcFinishFlagDataGridViewCheckBoxColumn.DataPropertyName = "McFinishFlag";
            this.mcFinishFlagDataGridViewCheckBoxColumn.HeaderText = "Finish";
            this.mcFinishFlagDataGridViewCheckBoxColumn.Name = "mcFinishFlagDataGridViewCheckBoxColumn";
            this.mcFinishFlagDataGridViewCheckBoxColumn.ReadOnly = true;
            this.mcFinishFlagDataGridViewCheckBoxColumn.Visible = false;
            this.mcFinishFlagDataGridViewCheckBoxColumn.Width = 45;
            // 
            // mcUnloadFlagDataGridViewCheckBoxColumn
            // 
            this.mcUnloadFlagDataGridViewCheckBoxColumn.DataPropertyName = "McUnloadFlag";
            this.mcUnloadFlagDataGridViewCheckBoxColumn.HeaderText = "Unload";
            this.mcUnloadFlagDataGridViewCheckBoxColumn.Name = "mcUnloadFlagDataGridViewCheckBoxColumn";
            this.mcUnloadFlagDataGridViewCheckBoxColumn.ReadOnly = true;
            this.mcUnloadFlagDataGridViewCheckBoxColumn.Visible = false;
            this.mcUnloadFlagDataGridViewCheckBoxColumn.Width = 58;
            // 
            // mcPushFlagDataGridViewCheckBoxColumn
            // 
            this.mcPushFlagDataGridViewCheckBoxColumn.DataPropertyName = "McPushFlag";
            this.mcPushFlagDataGridViewCheckBoxColumn.HeaderText = "Push";
            this.mcPushFlagDataGridViewCheckBoxColumn.Name = "mcPushFlagDataGridViewCheckBoxColumn";
            this.mcPushFlagDataGridViewCheckBoxColumn.ReadOnly = true;
            this.mcPushFlagDataGridViewCheckBoxColumn.Visible = false;
            this.mcPushFlagDataGridViewCheckBoxColumn.Width = 41;
            // 
            // outboundFlagDataGridViewCheckBoxColumn
            // 
            this.outboundFlagDataGridViewCheckBoxColumn.DataPropertyName = "OutboundFlag";
            this.outboundFlagDataGridViewCheckBoxColumn.HeaderText = "Outbound";
            this.outboundFlagDataGridViewCheckBoxColumn.Name = "outboundFlagDataGridViewCheckBoxColumn";
            this.outboundFlagDataGridViewCheckBoxColumn.ReadOnly = true;
            this.outboundFlagDataGridViewCheckBoxColumn.Visible = false;
            this.outboundFlagDataGridViewCheckBoxColumn.Width = 79;
            // 
            // ncFileDataGridViewTextBoxColumn
            // 
            this.ncFileDataGridViewTextBoxColumn.DataPropertyName = "NcFile";
            this.ncFileDataGridViewTextBoxColumn.HeaderText = "NC File";
            this.ncFileDataGridViewTextBoxColumn.Name = "ncFileDataGridViewTextBoxColumn";
            this.ncFileDataGridViewTextBoxColumn.ReadOnly = true;
            this.ncFileDataGridViewTextBoxColumn.Width = 76;
            // 
            // mcPickFlagDataGridViewCheckBoxColumn
            // 
            this.mcPickFlagDataGridViewCheckBoxColumn.DataPropertyName = "McPickFlag";
            this.mcPickFlagDataGridViewCheckBoxColumn.HeaderText = "McPickFlag";
            this.mcPickFlagDataGridViewCheckBoxColumn.Name = "mcPickFlagDataGridViewCheckBoxColumn";
            this.mcPickFlagDataGridViewCheckBoxColumn.ReadOnly = true;
            this.mcPickFlagDataGridViewCheckBoxColumn.Visible = false;
            this.mcPickFlagDataGridViewCheckBoxColumn.Width = 84;
            // 
            // qCStatusDataGridViewTextBoxColumn
            // 
            this.qCStatusDataGridViewTextBoxColumn.DataPropertyName = "QCStatus";
            this.qCStatusDataGridViewTextBoxColumn.HeaderText = "QC Status";
            this.qCStatusDataGridViewTextBoxColumn.Name = "qCStatusDataGridViewTextBoxColumn";
            this.qCStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.qCStatusDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.qCStatusDataGridViewTextBoxColumn.Width = 95;
            // 
            // jobTaskModelBindingSource
            // 
            this.jobTaskModelBindingSource.DataSource = typeof(Eureka.Core.Domain.Manufacturing.JobTaskModel);
            // 
            // bindingNav
            // 
            this.bindingNav.AddNewItem = null;
            this.bindingNav.CountItem = this.bindingNavigatorCountItem;
            this.bindingNav.DeleteItem = null;
            this.bindingNav.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNav.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripLabel1,
            this.cboFilterType,
            this.toolStripLabel2,
            this.cboFilterBy,
            this.txtFilterWord,
            this.mnuFilter,
            this.toolStripSeparator2,
            this.mnuAutoScheduling,
            this.mnuRelease,
            this.mnuQCInspection,
            this.cboSortType,
            this.cboSortBy,
            this.toolStripLabel3});
            this.bindingNav.Location = new System.Drawing.Point(0, 0);
            this.bindingNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNav.Name = "bindingNav";
            this.bindingNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNav.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNav.Size = new System.Drawing.Size(1466, 31);
            this.bindingNav.TabIndex = 40;
            this.bindingNav.Text = "Navigator";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 28);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 28);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 28);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(60, 28);
            this.toolStripLabel1.Text = "Filter Type";
            // 
            // cboFilterType
            // 
            this.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboFilterType.Items.AddRange(new object[] {
            "REREASE",
            "INSPECTION"});
            this.cboFilterType.Name = "cboFilterType";
            this.cboFilterType.Size = new System.Drawing.Size(121, 31);
            this.cboFilterType.SelectedIndexChanged += new System.EventHandler(this.cboFilterType_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(62, 28);
            this.toolStripLabel2.Text = "Serarch by";
            // 
            // cboFilterBy
            // 
            this.cboFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterBy.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboFilterBy.Items.AddRange(new object[] {
            "*",
            "Task",
            "Job No.",
            "Item Code",
            "Model",
            "Machine Code"});
            this.cboFilterBy.Name = "cboFilterBy";
            this.cboFilterBy.Size = new System.Drawing.Size(121, 31);
            this.cboFilterBy.SelectedIndexChanged += new System.EventHandler(this.cboFilterBy_SelectedIndexChanged);
            // 
            // txtFilterWord
            // 
            this.txtFilterWord.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFilterWord.Name = "txtFilterWord";
            this.txtFilterWord.Size = new System.Drawing.Size(150, 31);
            // 
            // mnuFilter
            // 
            this.mnuFilter.Image = ((System.Drawing.Image)(resources.GetObject("mnuFilter.Image")));
            this.mnuFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFilter.Name = "mnuFilter";
            this.mnuFilter.Size = new System.Drawing.Size(58, 28);
            this.mnuFilter.Text = "Find";
            this.mnuFilter.Click += new System.EventHandler(this.mnuFilter_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // mnuRelease
            // 
            this.mnuRelease.Image = ((System.Drawing.Image)(resources.GetObject("mnuRelease.Image")));
            this.mnuRelease.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuRelease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRelease.Name = "mnuRelease";
            this.mnuRelease.Size = new System.Drawing.Size(104, 28);
            this.mnuRelease.Text = "Release Tasks";
            this.mnuRelease.Click += new System.EventHandler(this.mnuRelease_Click);
            // 
            // mnuQCInspection
            // 
            this.mnuQCInspection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQCPass,
            this.mnuQCNG});
            this.mnuQCInspection.Image = ((System.Drawing.Image)(resources.GetObject("mnuQCInspection.Image")));
            this.mnuQCInspection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuQCInspection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuQCInspection.Name = "mnuQCInspection";
            this.mnuQCInspection.Size = new System.Drawing.Size(122, 28);
            this.mnuQCInspection.Text = "QC Inspection";
            // 
            // mnuQCPass
            // 
            this.mnuQCPass.Image = ((System.Drawing.Image)(resources.GetObject("mnuQCPass.Image")));
            this.mnuQCPass.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuQCPass.Name = "mnuQCPass";
            this.mnuQCPass.Size = new System.Drawing.Size(188, 30);
            this.mnuQCPass.Text = "PASS";
            this.mnuQCPass.Click += new System.EventHandler(this.mnuQCPass_Click);
            // 
            // mnuQCNG
            // 
            this.mnuQCNG.Image = ((System.Drawing.Image)(resources.GetObject("mnuQCNG.Image")));
            this.mnuQCNG.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuQCNG.Name = "mnuQCNG";
            this.mnuQCNG.Size = new System.Drawing.Size(188, 30);
            this.mnuQCNG.Text = "NG";
            this.mnuQCNG.Click += new System.EventHandler(this.mnuQCNG_Click);
            // 
            // cboSortType
            // 
            this.cboSortType.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cboSortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSortType.Items.AddRange(new object[] {
            "A-Z",
            "Z-A"});
            this.cboSortType.Name = "cboSortType";
            this.cboSortType.Size = new System.Drawing.Size(121, 31);
            this.cboSortType.SelectedIndexChanged += new System.EventHandler(this.cboSortType_SelectedIndexChanged);
            // 
            // cboSortBy
            // 
            this.cboSortBy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cboSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSortBy.Items.AddRange(new object[] {
            "Job No.",
            "Task No.",
            "Item Code",
            "Model",
            "Start Date",
            "End Date",
            "Due Date",
            "Machine Code"});
            this.cboSortBy.Name = "cboSortBy";
            this.cboSortBy.Size = new System.Drawing.Size(121, 31);
            this.cboSortBy.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox2_SelectedIndexChanged);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(47, 28);
            this.toolStripLabel3.Text = "Sort By:";
            // 
            // metroLabel5
            // 
            this.metroLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(1154, 6);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(60, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel5.TabIndex = 75;
            this.metroLabel5.Text = "Sort by :";
            this.metroLabel5.UseStyleColors = true;
            // 
            // mnuAutoScheduling
            // 
            this.mnuAutoScheduling.Image = ((System.Drawing.Image)(resources.GetObject("mnuAutoScheduling.Image")));
            this.mnuAutoScheduling.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuAutoScheduling.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuAutoScheduling.Name = "mnuAutoScheduling";
            this.mnuAutoScheduling.Size = new System.Drawing.Size(123, 28);
            this.mnuAutoScheduling.Text = "Auto Scheduling";
            // 
            // TaskManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 674);
            this.Controls.Add(this.metroPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TaskManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Management";
            this.Load += new System.EventHandler(this.TaskManagementForm_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobTaskModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).EndInit();
            this.bindingNav.ResumeLayout(false);
            this.bindingNav.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.BindingNavigator bindingNav;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton mnuFilter;
        private MetroFramework.Controls.MetroGrid dgvTasks;
        private System.Windows.Forms.ToolStripButton mnuRelease;
        private System.Windows.Forms.BindingSource jobTaskModelBindingSource;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cboFilterType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton mnuQCInspection;
        private System.Windows.Forms.ToolStripMenuItem mnuQCPass;
        private System.Windows.Forms.ToolStripMenuItem mnuQCNG;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cboFilterBy;
        private System.Windows.Forms.ToolStripTextBox txtFilterWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn priorityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskSeqDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimaryItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimaryItemModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimaryQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn managerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn standardTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dueDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cancelFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdateDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn readyFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn releaseFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn uploadNcfileFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn reserveShelfFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shelfNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn onShelfFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mcProcessFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mcLoadFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mcFinishFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mcUnloadFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mcPushFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn outboundFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ncFileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mcPickFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qCStatusDataGridViewTextBoxColumn;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.ToolStripComboBox cboSortType;
        private System.Windows.Forms.ToolStripComboBox cboSortBy;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton mnuAutoScheduling;
    }
}