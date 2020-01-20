namespace Eureka.CNC.Views
{
    partial class MachineListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineListForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtMachineCode = new MaterialSkin.Controls.MaterialSingleLineTextField();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvJobs = new MetroFramework.Controls.MetroGrid();
            this.machineIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machineCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdateDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enableFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.activeFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.machineModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).BeginInit();
            this.bindingNav.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.machineModelBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMachineCode
            // 
            this.txtMachineCode.Depth = 0;
            this.txtMachineCode.Hint = "";
            this.txtMachineCode.Location = new System.Drawing.Point(123, 13);
            this.txtMachineCode.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.PasswordChar = '\0';
            this.txtMachineCode.SelectedText = "";
            this.txtMachineCode.SelectionLength = 0;
            this.txtMachineCode.SelectionStart = 0;
            this.txtMachineCode.Size = new System.Drawing.Size(152, 23);
            this.txtMachineCode.TabIndex = 44;
            this.txtMachineCode.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(9, 18);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(108, 18);
            this.materialLabel1.TabIndex = 42;
            this.materialLabel1.Text = "Machine Code:";
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
            this.bindingNav.Size = new System.Drawing.Size(309, 27);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMachineCode);
            this.panel2.Controls.Add(this.materialLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 47);
            this.panel2.TabIndex = 39;
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
            this.machineIdDataGridViewTextBoxColumn,
            this.machineCodeDataGridViewTextBoxColumn,
            this.ipAddressDataGridViewTextBoxColumn,
            this.portDataGridViewTextBoxColumn,
            this.lastUpdateDateDataGridViewTextBoxColumn,
            this.lastUpdatedByDataGridViewTextBoxColumn,
            this.creationDateDataGridViewTextBoxColumn,
            this.createdByDataGridViewTextBoxColumn,
            this.enableFlagDataGridViewCheckBoxColumn,
            this.activeFlagDataGridViewCheckBoxColumn});
            this.dgvJobs.DataSource = this.machineModelBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvJobs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJobs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvJobs.EnableHeadersVisualStyles = false;
            this.dgvJobs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvJobs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvJobs.Location = new System.Drawing.Point(0, 74);
            this.dgvJobs.MultiSelect = false;
            this.dgvJobs.Name = "dgvJobs";
            this.dgvJobs.ReadOnly = true;
            this.dgvJobs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJobs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvJobs.RowHeadersWidth = 30;
            this.dgvJobs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dgvJobs.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvJobs.RowTemplate.Height = 60;
            this.dgvJobs.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJobs.Size = new System.Drawing.Size(309, 383);
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
            // machineIdDataGridViewTextBoxColumn
            // 
            this.machineIdDataGridViewTextBoxColumn.DataPropertyName = "MachineId";
            this.machineIdDataGridViewTextBoxColumn.HeaderText = "MachineId";
            this.machineIdDataGridViewTextBoxColumn.Name = "machineIdDataGridViewTextBoxColumn";
            this.machineIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.machineIdDataGridViewTextBoxColumn.Visible = false;
            this.machineIdDataGridViewTextBoxColumn.Width = 98;
            // 
            // machineCodeDataGridViewTextBoxColumn
            // 
            this.machineCodeDataGridViewTextBoxColumn.DataPropertyName = "MachineCode";
            this.machineCodeDataGridViewTextBoxColumn.HeaderText = "Machine Code";
            this.machineCodeDataGridViewTextBoxColumn.Name = "machineCodeDataGridViewTextBoxColumn";
            this.machineCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.machineCodeDataGridViewTextBoxColumn.Width = 127;
            // 
            // ipAddressDataGridViewTextBoxColumn
            // 
            this.ipAddressDataGridViewTextBoxColumn.DataPropertyName = "IpAddress";
            this.ipAddressDataGridViewTextBoxColumn.HeaderText = "IP Address";
            this.ipAddressDataGridViewTextBoxColumn.Name = "ipAddressDataGridViewTextBoxColumn";
            this.ipAddressDataGridViewTextBoxColumn.ReadOnly = true;
            this.ipAddressDataGridViewTextBoxColumn.Width = 95;
            // 
            // portDataGridViewTextBoxColumn
            // 
            this.portDataGridViewTextBoxColumn.DataPropertyName = "Port";
            this.portDataGridViewTextBoxColumn.HeaderText = "Port";
            this.portDataGridViewTextBoxColumn.Name = "portDataGridViewTextBoxColumn";
            this.portDataGridViewTextBoxColumn.ReadOnly = true;
            this.portDataGridViewTextBoxColumn.Width = 57;
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
            // enableFlagDataGridViewCheckBoxColumn
            // 
            this.enableFlagDataGridViewCheckBoxColumn.DataPropertyName = "EnableFlag";
            this.enableFlagDataGridViewCheckBoxColumn.HeaderText = "EnableFlag";
            this.enableFlagDataGridViewCheckBoxColumn.Name = "enableFlagDataGridViewCheckBoxColumn";
            this.enableFlagDataGridViewCheckBoxColumn.ReadOnly = true;
            this.enableFlagDataGridViewCheckBoxColumn.Visible = false;
            this.enableFlagDataGridViewCheckBoxColumn.Width = 83;
            // 
            // activeFlagDataGridViewCheckBoxColumn
            // 
            this.activeFlagDataGridViewCheckBoxColumn.DataPropertyName = "ActiveFlag";
            this.activeFlagDataGridViewCheckBoxColumn.HeaderText = "ActiveFlag";
            this.activeFlagDataGridViewCheckBoxColumn.Name = "activeFlagDataGridViewCheckBoxColumn";
            this.activeFlagDataGridViewCheckBoxColumn.ReadOnly = true;
            this.activeFlagDataGridViewCheckBoxColumn.Visible = false;
            this.activeFlagDataGridViewCheckBoxColumn.Width = 80;
            // 
            // machineModelBindingSource
            // 
            this.machineModelBindingSource.DataSource = typeof(Eureka.Core.Domain.Manufacturing.MachineModel);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvJobs);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.bindingNav);
            this.panel1.Location = new System.Drawing.Point(3, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 457);
            this.panel1.TabIndex = 1;
            // 
            // MachineListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 523);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MachineListForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Machine List";
            this.Load += new System.EventHandler(this.MachineListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).EndInit();
            this.bindingNav.ResumeLayout(false);
            this.bindingNav.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.machineModelBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtMachineCode;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
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
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroGrid dgvJobs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn portDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdateDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enableFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activeFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource machineModelBindingSource;
    }
}