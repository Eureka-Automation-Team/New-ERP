namespace Eureka.CNC.Views
{
    partial class JobListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobListForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvJobs = new MetroFramework.Controls.MetroGrid();
            this.jobEntityIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.organizationIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdateDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobEntityNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobEntiryDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaryItemIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaryItemCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaryItemModelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.segment1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.segment2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.segment3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.segment4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.segment5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openStatusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cancelFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.jobEntityModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtJobNumber = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
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
            this.bindingNavigatorFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobEntityModelBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).BeginInit();
            this.bindingNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvJobs);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.bindingNav);
            this.panel1.Location = new System.Drawing.Point(2, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 468);
            this.panel1.TabIndex = 0;
            // 
            // dgvJobs
            // 
            this.dgvJobs.AllowUserToAddRows = false;
            this.dgvJobs.AllowUserToDeleteRows = false;
            this.dgvJobs.AllowUserToOrderColumns = true;
            this.dgvJobs.AllowUserToResizeRows = false;
            this.dgvJobs.AutoGenerateColumns = false;
            this.dgvJobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvJobs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvJobs.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvJobs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvJobs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvJobs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvJobs.ColumnHeadersHeight = 25;
            this.dgvJobs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jobEntityIdDataGridViewTextBoxColumn,
            this.organizationIdDataGridViewTextBoxColumn,
            this.lastUpdateDateDataGridViewTextBoxColumn,
            this.lastUpdatedByDataGridViewTextBoxColumn,
            this.creationDateDataGridViewTextBoxColumn,
            this.createdByDataGridViewTextBoxColumn,
            this.jobEntityNameDataGridViewTextBoxColumn,
            this.jobEntiryDateDataGridViewTextBoxColumn,
            this.entityTypeDataGridViewTextBoxColumn,
            this.primaryItemIdDataGridViewTextBoxColumn,
            this.primaryItemCodeDataGridViewTextBoxColumn,
            this.primaryItemModelDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.segment1DataGridViewTextBoxColumn,
            this.segment2DataGridViewTextBoxColumn,
            this.segment3DataGridViewTextBoxColumn,
            this.segment4DataGridViewTextBoxColumn,
            this.segment5DataGridViewTextBoxColumn,
            this.openStatusDataGridViewCheckBoxColumn,
            this.cancelFlagDataGridViewCheckBoxColumn});
            this.dgvJobs.DataSource = this.jobEntityModelBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvJobs.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJobs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvJobs.EnableHeadersVisualStyles = false;
            this.dgvJobs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvJobs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvJobs.Location = new System.Drawing.Point(0, 109);
            this.dgvJobs.MultiSelect = false;
            this.dgvJobs.Name = "dgvJobs";
            this.dgvJobs.ReadOnly = true;
            this.dgvJobs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJobs.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvJobs.RowHeadersWidth = 30;
            this.dgvJobs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dgvJobs.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvJobs.RowTemplate.Height = 60;
            this.dgvJobs.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJobs.Size = new System.Drawing.Size(495, 359);
            this.dgvJobs.StandardTab = true;
            this.dgvJobs.Style = MetroFramework.MetroColorStyle.Blue;
            this.dgvJobs.TabIndex = 38;
            this.dgvJobs.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dgvJobs.UseCustomBackColor = true;
            this.dgvJobs.UseCustomForeColor = true;
            this.dgvJobs.UseStyleColors = true;
            this.dgvJobs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJobs_CellDoubleClick);
            this.dgvJobs.SelectionChanged += new System.EventHandler(this.dgvJobs_SelectionChanged);
            // 
            // jobEntityIdDataGridViewTextBoxColumn
            // 
            this.jobEntityIdDataGridViewTextBoxColumn.DataPropertyName = "JobEntityId";
            this.jobEntityIdDataGridViewTextBoxColumn.HeaderText = "JobEntityId";
            this.jobEntityIdDataGridViewTextBoxColumn.Name = "jobEntityIdDataGridViewTextBoxColumn";
            this.jobEntityIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.jobEntityIdDataGridViewTextBoxColumn.Visible = false;
            this.jobEntityIdDataGridViewTextBoxColumn.Width = 101;
            // 
            // organizationIdDataGridViewTextBoxColumn
            // 
            this.organizationIdDataGridViewTextBoxColumn.DataPropertyName = "OrganizationId";
            this.organizationIdDataGridViewTextBoxColumn.HeaderText = "OrganizationId";
            this.organizationIdDataGridViewTextBoxColumn.Name = "organizationIdDataGridViewTextBoxColumn";
            this.organizationIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.organizationIdDataGridViewTextBoxColumn.Visible = false;
            this.organizationIdDataGridViewTextBoxColumn.Width = 127;
            // 
            // lastUpdateDateDataGridViewTextBoxColumn
            // 
            this.lastUpdateDateDataGridViewTextBoxColumn.DataPropertyName = "LastUpdateDate";
            this.lastUpdateDateDataGridViewTextBoxColumn.HeaderText = "LastUpdateDate";
            this.lastUpdateDateDataGridViewTextBoxColumn.Name = "lastUpdateDateDataGridViewTextBoxColumn";
            this.lastUpdateDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastUpdateDateDataGridViewTextBoxColumn.Visible = false;
            this.lastUpdateDateDataGridViewTextBoxColumn.Width = 136;
            // 
            // lastUpdatedByDataGridViewTextBoxColumn
            // 
            this.lastUpdatedByDataGridViewTextBoxColumn.DataPropertyName = "LastUpdatedBy";
            this.lastUpdatedByDataGridViewTextBoxColumn.HeaderText = "LastUpdatedBy";
            this.lastUpdatedByDataGridViewTextBoxColumn.Name = "lastUpdatedByDataGridViewTextBoxColumn";
            this.lastUpdatedByDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastUpdatedByDataGridViewTextBoxColumn.Visible = false;
            this.lastUpdatedByDataGridViewTextBoxColumn.Width = 126;
            // 
            // creationDateDataGridViewTextBoxColumn
            // 
            this.creationDateDataGridViewTextBoxColumn.DataPropertyName = "CreationDate";
            this.creationDateDataGridViewTextBoxColumn.HeaderText = "CreationDate";
            this.creationDateDataGridViewTextBoxColumn.Name = "creationDateDataGridViewTextBoxColumn";
            this.creationDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.creationDateDataGridViewTextBoxColumn.Visible = false;
            this.creationDateDataGridViewTextBoxColumn.Width = 120;
            // 
            // createdByDataGridViewTextBoxColumn
            // 
            this.createdByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn.HeaderText = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn.Name = "createdByDataGridViewTextBoxColumn";
            this.createdByDataGridViewTextBoxColumn.ReadOnly = true;
            this.createdByDataGridViewTextBoxColumn.Visible = false;
            this.createdByDataGridViewTextBoxColumn.Width = 98;
            // 
            // jobEntityNameDataGridViewTextBoxColumn
            // 
            this.jobEntityNameDataGridViewTextBoxColumn.DataPropertyName = "JobEntityName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.jobEntityNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.jobEntityNameDataGridViewTextBoxColumn.HeaderText = "Job No.";
            this.jobEntityNameDataGridViewTextBoxColumn.Name = "jobEntityNameDataGridViewTextBoxColumn";
            this.jobEntityNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.jobEntityNameDataGridViewTextBoxColumn.Width = 82;
            // 
            // jobEntiryDateDataGridViewTextBoxColumn
            // 
            this.jobEntiryDateDataGridViewTextBoxColumn.DataPropertyName = "JobEntiryDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "dd-MM-yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.jobEntiryDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.jobEntiryDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.jobEntiryDateDataGridViewTextBoxColumn.Name = "jobEntiryDateDataGridViewTextBoxColumn";
            this.jobEntiryDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.jobEntiryDateDataGridViewTextBoxColumn.Width = 63;
            // 
            // entityTypeDataGridViewTextBoxColumn
            // 
            this.entityTypeDataGridViewTextBoxColumn.DataPropertyName = "EntityType";
            this.entityTypeDataGridViewTextBoxColumn.HeaderText = "EntityType";
            this.entityTypeDataGridViewTextBoxColumn.Name = "entityTypeDataGridViewTextBoxColumn";
            this.entityTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.entityTypeDataGridViewTextBoxColumn.Visible = false;
            this.entityTypeDataGridViewTextBoxColumn.Width = 93;
            // 
            // primaryItemIdDataGridViewTextBoxColumn
            // 
            this.primaryItemIdDataGridViewTextBoxColumn.DataPropertyName = "PrimaryItemId";
            this.primaryItemIdDataGridViewTextBoxColumn.HeaderText = "PrimaryItemId";
            this.primaryItemIdDataGridViewTextBoxColumn.Name = "primaryItemIdDataGridViewTextBoxColumn";
            this.primaryItemIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.primaryItemIdDataGridViewTextBoxColumn.Visible = false;
            this.primaryItemIdDataGridViewTextBoxColumn.Width = 119;
            // 
            // primaryItemCodeDataGridViewTextBoxColumn
            // 
            this.primaryItemCodeDataGridViewTextBoxColumn.DataPropertyName = "PrimaryItemCode";
            this.primaryItemCodeDataGridViewTextBoxColumn.HeaderText = "Item No.";
            this.primaryItemCodeDataGridViewTextBoxColumn.Name = "primaryItemCodeDataGridViewTextBoxColumn";
            this.primaryItemCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.primaryItemCodeDataGridViewTextBoxColumn.Width = 87;
            // 
            // primaryItemModelDataGridViewTextBoxColumn
            // 
            this.primaryItemModelDataGridViewTextBoxColumn.DataPropertyName = "PrimaryItemModel";
            this.primaryItemModelDataGridViewTextBoxColumn.HeaderText = "Model";
            this.primaryItemModelDataGridViewTextBoxColumn.Name = "primaryItemModelDataGridViewTextBoxColumn";
            this.primaryItemModelDataGridViewTextBoxColumn.ReadOnly = true;
            this.primaryItemModelDataGridViewTextBoxColumn.Width = 71;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 103;
            // 
            // segment1DataGridViewTextBoxColumn
            // 
            this.segment1DataGridViewTextBoxColumn.DataPropertyName = "Segment1";
            this.segment1DataGridViewTextBoxColumn.HeaderText = "Segment1";
            this.segment1DataGridViewTextBoxColumn.Name = "segment1DataGridViewTextBoxColumn";
            this.segment1DataGridViewTextBoxColumn.ReadOnly = true;
            this.segment1DataGridViewTextBoxColumn.Visible = false;
            this.segment1DataGridViewTextBoxColumn.Width = 95;
            // 
            // segment2DataGridViewTextBoxColumn
            // 
            this.segment2DataGridViewTextBoxColumn.DataPropertyName = "Segment2";
            this.segment2DataGridViewTextBoxColumn.HeaderText = "Segment2";
            this.segment2DataGridViewTextBoxColumn.Name = "segment2DataGridViewTextBoxColumn";
            this.segment2DataGridViewTextBoxColumn.ReadOnly = true;
            this.segment2DataGridViewTextBoxColumn.Visible = false;
            this.segment2DataGridViewTextBoxColumn.Width = 95;
            // 
            // segment3DataGridViewTextBoxColumn
            // 
            this.segment3DataGridViewTextBoxColumn.DataPropertyName = "Segment3";
            this.segment3DataGridViewTextBoxColumn.HeaderText = "Segment3";
            this.segment3DataGridViewTextBoxColumn.Name = "segment3DataGridViewTextBoxColumn";
            this.segment3DataGridViewTextBoxColumn.ReadOnly = true;
            this.segment3DataGridViewTextBoxColumn.Visible = false;
            this.segment3DataGridViewTextBoxColumn.Width = 95;
            // 
            // segment4DataGridViewTextBoxColumn
            // 
            this.segment4DataGridViewTextBoxColumn.DataPropertyName = "Segment4";
            this.segment4DataGridViewTextBoxColumn.HeaderText = "Segment4";
            this.segment4DataGridViewTextBoxColumn.Name = "segment4DataGridViewTextBoxColumn";
            this.segment4DataGridViewTextBoxColumn.ReadOnly = true;
            this.segment4DataGridViewTextBoxColumn.Visible = false;
            this.segment4DataGridViewTextBoxColumn.Width = 95;
            // 
            // segment5DataGridViewTextBoxColumn
            // 
            this.segment5DataGridViewTextBoxColumn.DataPropertyName = "Segment5";
            this.segment5DataGridViewTextBoxColumn.HeaderText = "Segment5";
            this.segment5DataGridViewTextBoxColumn.Name = "segment5DataGridViewTextBoxColumn";
            this.segment5DataGridViewTextBoxColumn.ReadOnly = true;
            this.segment5DataGridViewTextBoxColumn.Visible = false;
            this.segment5DataGridViewTextBoxColumn.Width = 95;
            // 
            // openStatusDataGridViewCheckBoxColumn
            // 
            this.openStatusDataGridViewCheckBoxColumn.DataPropertyName = "OpenStatus";
            this.openStatusDataGridViewCheckBoxColumn.HeaderText = "OpenStatus";
            this.openStatusDataGridViewCheckBoxColumn.Name = "openStatusDataGridViewCheckBoxColumn";
            this.openStatusDataGridViewCheckBoxColumn.ReadOnly = true;
            this.openStatusDataGridViewCheckBoxColumn.Visible = false;
            this.openStatusDataGridViewCheckBoxColumn.Width = 86;
            // 
            // cancelFlagDataGridViewCheckBoxColumn
            // 
            this.cancelFlagDataGridViewCheckBoxColumn.DataPropertyName = "CancelFlag";
            this.cancelFlagDataGridViewCheckBoxColumn.HeaderText = "Cancel";
            this.cancelFlagDataGridViewCheckBoxColumn.Name = "cancelFlagDataGridViewCheckBoxColumn";
            this.cancelFlagDataGridViewCheckBoxColumn.ReadOnly = true;
            this.cancelFlagDataGridViewCheckBoxColumn.Width = 59;
            // 
            // jobEntityModelBindingSource
            // 
            this.jobEntityModelBindingSource.DataSource = typeof(Eureka.Core.Domain.Manufacturing.JobEntityModel);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.materialLabel3);
            this.panel2.Controls.Add(this.dtpEndDate);
            this.panel2.Controls.Add(this.dtpStartDate);
            this.panel2.Controls.Add(this.txtJobNumber);
            this.panel2.Controls.Add(this.materialLabel2);
            this.panel2.Controls.Add(this.materialLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 82);
            this.panel2.TabIndex = 39;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(278, 46);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(27, 19);
            this.materialLabel3.TabIndex = 50;
            this.materialLabel3.Text = "To";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(309, 40);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(180, 24);
            this.dtpEndDate.TabIndex = 49;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(92, 40);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(180, 24);
            this.dtpStartDate.TabIndex = 48;
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.Depth = 0;
            this.txtJobNumber.Hint = "";
            this.txtJobNumber.Location = new System.Drawing.Point(92, 13);
            this.txtJobNumber.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.PasswordChar = '\0';
            this.txtJobNumber.SelectedText = "";
            this.txtJobNumber.SelectionLength = 0;
            this.txtJobNumber.SelectionStart = 0;
            this.txtJobNumber.Size = new System.Drawing.Size(180, 23);
            this.txtJobNumber.TabIndex = 44;
            this.txtJobNumber.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(10, 46);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(77, 19);
            this.materialLabel2.TabIndex = 43;
            this.materialLabel2.Text = "Job Date.:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(21, 18);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(66, 19);
            this.materialLabel1.TabIndex = 42;
            this.materialLabel1.Text = "Job No.:";
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
            this.bindingNavigatorFilter,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton2});
            this.bindingNav.Location = new System.Drawing.Point(0, 0);
            this.bindingNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNav.Name = "bindingNav";
            this.bindingNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNav.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNav.Size = new System.Drawing.Size(495, 27);
            this.bindingNav.TabIndex = 28;
            this.bindingNav.Text = "Navigator";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 24);
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
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
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
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorFilter
            // 
            this.bindingNavigatorFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorFilter.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorFilter.Image")));
            this.bindingNavigatorFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bindingNavigatorFilter.Name = "bindingNavigatorFilter";
            this.bindingNavigatorFilter.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorFilter.Text = "toolStripButton1";
            this.bindingNavigatorFilter.Click += new System.EventHandler(this.bindingNavigatorFilter_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // JobListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 533);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JobListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job List";
            this.Load += new System.EventHandler(this.JobListForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobEntityModelBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).EndInit();
            this.bindingNav.ResumeLayout(false);
            this.bindingNav.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.ToolStripButton bindingNavigatorFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private MetroFramework.Controls.MetroGrid dgvJobs;
        private System.Windows.Forms.BindingSource jobEntityModelBindingSource;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtJobNumber;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobEntityIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn organizationIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdateDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobEntityNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobEntiryDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entityTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryItemIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryItemCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryItemModelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn segment1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn segment2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn segment3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn segment4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn segment5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn openStatusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cancelFlagDataGridViewCheckBoxColumn;
    }
}