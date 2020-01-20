namespace Eureka.Froms.Views.Purchasing
{
    partial class POListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POListForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.dgvPoList = new MetroFramework.Controls.MetroGrid();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtbuyer = new MetroFramework.Controls.MetroTextBox();
            this.dtpEndDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dtpStartDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtPONum = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.butNextPage = new MetroFramework.Controls.MetroButton();
            this.txtPageNumber = new MetroFramework.Controls.MetroTextBox();
            this.butPreviousPage = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).BeginInit();
            this.bindingNav.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoList)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.SuspendLayout();
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
            this.bindingNav.Location = new System.Drawing.Point(20, 60);
            this.bindingNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNav.Name = "bindingNav";
            this.bindingNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNav.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNav.Size = new System.Drawing.Size(519, 27);
            this.bindingNav.TabIndex = 22;
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
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(7, 3);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(56, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel6.TabIndex = 15;
            this.metroLabel6.Text = "PO No.:";
            this.metroLabel6.UseStyleColors = true;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.dgvPoList);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(20, 156);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(519, 245);
            this.metroPanel2.TabIndex = 24;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // dgvPoList
            // 
            this.dgvPoList.AllowUserToAddRows = false;
            this.dgvPoList.AllowUserToDeleteRows = false;
            this.dgvPoList.AllowUserToOrderColumns = true;
            this.dgvPoList.AllowUserToResizeRows = false;
            this.dgvPoList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPoList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPoList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvPoList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPoList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPoList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPoList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPoList.ColumnHeadersHeight = 25;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPoList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPoList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPoList.EnableHeadersVisualStyles = false;
            this.dgvPoList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvPoList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvPoList.Location = new System.Drawing.Point(0, 0);
            this.dgvPoList.Name = "dgvPoList";
            this.dgvPoList.ReadOnly = true;
            this.dgvPoList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPoList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPoList.RowHeadersWidth = 30;
            this.dgvPoList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dgvPoList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPoList.RowTemplate.Height = 60;
            this.dgvPoList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPoList.Size = new System.Drawing.Size(519, 245);
            this.dgvPoList.StandardTab = true;
            this.dgvPoList.Style = MetroFramework.MetroColorStyle.Green;
            this.dgvPoList.TabIndex = 37;
            this.dgvPoList.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dgvPoList.UseCustomBackColor = true;
            this.dgvPoList.UseCustomForeColor = true;
            this.dgvPoList.UseStyleColors = true;
            this.dgvPoList.MultiSelectChanged += new System.EventHandler(this.dgvPoList_MultiSelectChanged);
            this.dgvPoList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPoList_CellDoubleClick);
            this.dgvPoList.SelectionChanged += new System.EventHandler(this.dgvPoList_SelectionChanged);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.txtbuyer);
            this.metroPanel1.Controls.Add(this.dtpEndDate);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.dtpStartDate);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.metroLabel6);
            this.metroPanel1.Controls.Add(this.txtPONum);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 87);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(519, 69);
            this.metroPanel1.TabIndex = 23;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(265, 4);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(47, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel3.TabIndex = 21;
            this.metroLabel3.Text = "Buyer:";
            this.metroLabel3.UseStyleColors = true;
            // 
            // txtbuyer
            // 
            // 
            // 
            // 
            this.txtbuyer.CustomButton.Image = null;
            this.txtbuyer.CustomButton.Location = new System.Drawing.Point(169, 1);
            this.txtbuyer.CustomButton.Name = "";
            this.txtbuyer.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtbuyer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbuyer.CustomButton.TabIndex = 1;
            this.txtbuyer.CustomButton.Text = "...";
            this.txtbuyer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbuyer.CustomButton.UseSelectable = true;
            this.txtbuyer.CustomButton.Visible = false;
            this.txtbuyer.Lines = new string[0];
            this.txtbuyer.Location = new System.Drawing.Point(318, 4);
            this.txtbuyer.MaxLength = 32767;
            this.txtbuyer.Name = "txtbuyer";
            this.txtbuyer.PasswordChar = '\0';
            this.txtbuyer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbuyer.SelectedText = "";
            this.txtbuyer.SelectionLength = 0;
            this.txtbuyer.SelectionStart = 0;
            this.txtbuyer.ShortcutsEnabled = true;
            this.txtbuyer.ShowClearButton = true;
            this.txtbuyer.Size = new System.Drawing.Size(193, 25);
            this.txtbuyer.Style = MetroFramework.MetroColorStyle.Green;
            this.txtbuyer.TabIndex = 20;
            this.txtbuyer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbuyer.UseSelectable = true;
            this.txtbuyer.UseStyleColors = true;
            this.txtbuyer.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbuyer.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpEndDate.DisplayFocus = true;
            this.dtpEndDate.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(318, 35);
            this.dtpEndDate.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(193, 25);
            this.dtpEndDate.Style = MetroFramework.MetroColorStyle.Green;
            this.dtpEndDate.TabIndex = 19;
            this.dtpEndDate.UseStyleColors = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(286, 35);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(26, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel2.TabIndex = 18;
            this.metroLabel2.Text = "To:";
            this.metroLabel2.UseStyleColors = true;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpStartDate.DisplayFocus = true;
            this.dtpStartDate.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(87, 35);
            this.dtpStartDate.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(193, 25);
            this.dtpStartDate.Style = MetroFramework.MetroColorStyle.Green;
            this.dtpStartDate.TabIndex = 17;
            this.dtpStartDate.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(7, 35);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(74, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel1.TabIndex = 16;
            this.metroLabel1.Text = "Start Date:";
            this.metroLabel1.UseStyleColors = true;
            // 
            // txtPONum
            // 
            // 
            // 
            // 
            this.txtPONum.CustomButton.Image = null;
            this.txtPONum.CustomButton.Location = new System.Drawing.Point(121, 1);
            this.txtPONum.CustomButton.Name = "";
            this.txtPONum.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPONum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPONum.CustomButton.TabIndex = 1;
            this.txtPONum.CustomButton.Text = "...";
            this.txtPONum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPONum.CustomButton.UseSelectable = true;
            this.txtPONum.CustomButton.Visible = false;
            this.txtPONum.Lines = new string[0];
            this.txtPONum.Location = new System.Drawing.Point(87, 3);
            this.txtPONum.MaxLength = 32767;
            this.txtPONum.Name = "txtPONum";
            this.txtPONum.PasswordChar = '\0';
            this.txtPONum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPONum.SelectedText = "";
            this.txtPONum.SelectionLength = 0;
            this.txtPONum.SelectionStart = 0;
            this.txtPONum.ShortcutsEnabled = true;
            this.txtPONum.ShowClearButton = true;
            this.txtPONum.Size = new System.Drawing.Size(145, 25);
            this.txtPONum.Style = MetroFramework.MetroColorStyle.Green;
            this.txtPONum.TabIndex = 13;
            this.txtPONum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPONum.UseSelectable = true;
            this.txtPONum.UseStyleColors = true;
            this.txtPONum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPONum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.txtPageNumber);
            this.metroPanel3.Controls.Add(this.butPreviousPage);
            this.metroPanel3.Controls.Add(this.butNextPage);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(20, 401);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(519, 29);
            this.metroPanel3.TabIndex = 25;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // butNextPage
            // 
            this.butNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butNextPage.Location = new System.Drawing.Point(482, 2);
            this.butNextPage.Name = "butNextPage";
            this.butNextPage.Size = new System.Drawing.Size(37, 25);
            this.butNextPage.TabIndex = 2;
            this.butNextPage.Text = ">";
            this.butNextPage.UseSelectable = true;
            this.butNextPage.Click += new System.EventHandler(this.butNextPage_Click);
            // 
            // txtPageNumber
            // 
            this.txtPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPageNumber.CustomButton.Image = null;
            this.txtPageNumber.CustomButton.Location = new System.Drawing.Point(58, 1);
            this.txtPageNumber.CustomButton.Name = "";
            this.txtPageNumber.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPageNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPageNumber.CustomButton.TabIndex = 1;
            this.txtPageNumber.CustomButton.Text = "...";
            this.txtPageNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPageNumber.CustomButton.UseSelectable = true;
            this.txtPageNumber.CustomButton.Visible = false;
            this.txtPageNumber.Lines = new string[0];
            this.txtPageNumber.Location = new System.Drawing.Point(399, 2);
            this.txtPageNumber.MaxLength = 32767;
            this.txtPageNumber.Name = "txtPageNumber";
            this.txtPageNumber.PasswordChar = '\0';
            this.txtPageNumber.ReadOnly = true;
            this.txtPageNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPageNumber.SelectedText = "";
            this.txtPageNumber.SelectionLength = 0;
            this.txtPageNumber.SelectionStart = 0;
            this.txtPageNumber.ShortcutsEnabled = true;
            this.txtPageNumber.ShowClearButton = true;
            this.txtPageNumber.Size = new System.Drawing.Size(82, 25);
            this.txtPageNumber.Style = MetroFramework.MetroColorStyle.Green;
            this.txtPageNumber.TabIndex = 14;
            this.txtPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPageNumber.UseSelectable = true;
            this.txtPageNumber.UseStyleColors = true;
            this.txtPageNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPageNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // butPreviousPage
            // 
            this.butPreviousPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPreviousPage.Location = new System.Drawing.Point(360, 2);
            this.butPreviousPage.Name = "butPreviousPage";
            this.butPreviousPage.Size = new System.Drawing.Size(37, 25);
            this.butPreviousPage.TabIndex = 3;
            this.butPreviousPage.Text = "<";
            this.butPreviousPage.UseSelectable = true;
            this.butPreviousPage.Click += new System.EventHandler(this.butPreviousPage_Click);
            // 
            // POListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 450);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.bindingNav);
            this.Controls.Add(this.metroPanel3);
            this.Name = "POListForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "PO List";
            this.Load += new System.EventHandler(this.POListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).EndInit();
            this.bindingNav.ResumeLayout(false);
            this.bindingNav.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoList)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroGrid dgvPoList;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtPONum;
        private MetroFramework.Controls.MetroDateTime dtpStartDate;
        private MetroFramework.Controls.MetroDateTime dtpEndDate;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtbuyer;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroTextBox txtPageNumber;
        private MetroFramework.Controls.MetroButton butPreviousPage;
        private MetroFramework.Controls.MetroButton butNextPage;
    }
}