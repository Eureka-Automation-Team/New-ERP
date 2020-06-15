namespace Eureka.Froms.Views.Payables
{
    partial class VendorListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendorListForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingNav = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtVendorName = new MetroFramework.Controls.MetroTextBox();
            this.txtVendorNum = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.dgvVendors = new MetroFramework.Controls.MetroGrid();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.txtPageNumber = new MetroFramework.Controls.MetroTextBox();
            this.butPreviousPage = new MetroFramework.Controls.MetroButton();
            this.butNextPage = new MetroFramework.Controls.MetroButton();
            this.vendorModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vendorIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatRegistrationNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).BeginInit();
            this.bindingNav.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendors)).BeginInit();
            this.metroPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vendorModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingNav
            // 
            this.bindingNav.AddNewItem = this.toolStripButton3;
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
            this.toolStripButton2,
            this.toolStripButton3});
            this.bindingNav.Location = new System.Drawing.Point(20, 60);
            this.bindingNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNav.Name = "bindingNav";
            this.bindingNav.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNav.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNav.Size = new System.Drawing.Size(694, 27);
            this.bindingNav.TabIndex = 10;
            this.bindingNav.Text = "Navigator";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "toolStripButton3";
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
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.metroLabel6);
            this.metroPanel1.Controls.Add(this.txtVendorName);
            this.metroPanel1.Controls.Add(this.txtVendorNum);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 87);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(694, 60);
            this.metroPanel1.TabIndex = 11;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(51, 30);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(52, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel1.TabIndex = 16;
            this.metroLabel1.Text = "Name :";
            this.metroLabel1.UseStyleColors = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(7, 3);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(96, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel6.TabIndex = 15;
            this.metroLabel6.Text = "Vendor Code :";
            this.metroLabel6.UseStyleColors = true;
            // 
            // txtVendorName
            // 
            // 
            // 
            // 
            this.txtVendorName.CustomButton.Image = null;
            this.txtVendorName.CustomButton.Location = new System.Drawing.Point(332, 1);
            this.txtVendorName.CustomButton.Name = "";
            this.txtVendorName.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtVendorName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtVendorName.CustomButton.TabIndex = 1;
            this.txtVendorName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtVendorName.CustomButton.UseSelectable = true;
            this.txtVendorName.CustomButton.Visible = false;
            this.txtVendorName.Lines = new string[0];
            this.txtVendorName.Location = new System.Drawing.Point(109, 30);
            this.txtVendorName.MaxLength = 32767;
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.PasswordChar = '\0';
            this.txtVendorName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtVendorName.SelectedText = "";
            this.txtVendorName.SelectionLength = 0;
            this.txtVendorName.SelectionStart = 0;
            this.txtVendorName.ShortcutsEnabled = true;
            this.txtVendorName.Size = new System.Drawing.Size(356, 25);
            this.txtVendorName.Style = MetroFramework.MetroColorStyle.Green;
            this.txtVendorName.TabIndex = 14;
            this.txtVendorName.UseSelectable = true;
            this.txtVendorName.UseStyleColors = true;
            this.txtVendorName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtVendorName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtVendorNum
            // 
            // 
            // 
            // 
            this.txtVendorNum.CustomButton.Image = null;
            this.txtVendorNum.CustomButton.Location = new System.Drawing.Point(103, 1);
            this.txtVendorNum.CustomButton.Name = "";
            this.txtVendorNum.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtVendorNum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtVendorNum.CustomButton.TabIndex = 1;
            this.txtVendorNum.CustomButton.Text = "...";
            this.txtVendorNum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtVendorNum.CustomButton.UseSelectable = true;
            this.txtVendorNum.CustomButton.Visible = false;
            this.txtVendorNum.Lines = new string[0];
            this.txtVendorNum.Location = new System.Drawing.Point(109, 3);
            this.txtVendorNum.MaxLength = 32767;
            this.txtVendorNum.Name = "txtVendorNum";
            this.txtVendorNum.PasswordChar = '\0';
            this.txtVendorNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtVendorNum.SelectedText = "";
            this.txtVendorNum.SelectionLength = 0;
            this.txtVendorNum.SelectionStart = 0;
            this.txtVendorNum.ShortcutsEnabled = true;
            this.txtVendorNum.ShowClearButton = true;
            this.txtVendorNum.Size = new System.Drawing.Size(127, 25);
            this.txtVendorNum.Style = MetroFramework.MetroColorStyle.Green;
            this.txtVendorNum.TabIndex = 13;
            this.txtVendorNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVendorNum.UseSelectable = true;
            this.txtVendorNum.UseStyleColors = true;
            this.txtVendorNum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtVendorNum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.dgvVendors);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(20, 147);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(694, 237);
            this.metroPanel2.TabIndex = 12;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // dgvVendors
            // 
            this.dgvVendors.AllowUserToOrderColumns = true;
            this.dgvVendors.AllowUserToResizeRows = false;
            this.dgvVendors.AutoGenerateColumns = false;
            this.dgvVendors.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVendors.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvVendors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVendors.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvVendors.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVendors.ColumnHeadersHeight = 25;
            this.dgvVendors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vendorIdDataGridViewTextBoxColumn,
            this.vendorNumberDataGridViewTextBoxColumn,
            this.vendorNameDataGridViewTextBoxColumn,
            this.vatRegistrationNumDataGridViewTextBoxColumn,
            this.Address});
            this.dgvVendors.DataSource = this.vendorModelBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVendors.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVendors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVendors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvVendors.EnableHeadersVisualStyles = false;
            this.dgvVendors.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvVendors.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvVendors.Location = new System.Drawing.Point(0, 0);
            this.dgvVendors.MultiSelect = false;
            this.dgvVendors.Name = "dgvVendors";
            this.dgvVendors.ReadOnly = true;
            this.dgvVendors.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendors.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVendors.RowHeadersWidth = 30;
            this.dgvVendors.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dgvVendors.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvVendors.RowTemplate.Height = 60;
            this.dgvVendors.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendors.Size = new System.Drawing.Size(694, 237);
            this.dgvVendors.StandardTab = true;
            this.dgvVendors.Style = MetroFramework.MetroColorStyle.Green;
            this.dgvVendors.TabIndex = 37;
            this.dgvVendors.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dgvVendors.UseCustomBackColor = true;
            this.dgvVendors.UseCustomForeColor = true;
            this.dgvVendors.UseStyleColors = true;
            this.dgvVendors.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendors_CellDoubleClick);
            this.dgvVendors.SelectionChanged += new System.EventHandler(this.dgvVendors_SelectionChanged);
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
            this.metroPanel3.Location = new System.Drawing.Point(20, 384);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(694, 29);
            this.metroPanel3.TabIndex = 27;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
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
            this.txtPageNumber.Location = new System.Drawing.Point(574, 1);
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
            this.butPreviousPage.Location = new System.Drawing.Point(535, 1);
            this.butPreviousPage.Name = "butPreviousPage";
            this.butPreviousPage.Size = new System.Drawing.Size(37, 25);
            this.butPreviousPage.TabIndex = 3;
            this.butPreviousPage.Text = "<";
            this.butPreviousPage.UseSelectable = true;
            this.butPreviousPage.Click += new System.EventHandler(this.butPreviousPage_Click);
            // 
            // butNextPage
            // 
            this.butNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butNextPage.Location = new System.Drawing.Point(657, 1);
            this.butNextPage.Name = "butNextPage";
            this.butNextPage.Size = new System.Drawing.Size(37, 25);
            this.butNextPage.TabIndex = 2;
            this.butNextPage.Text = ">";
            this.butNextPage.UseSelectable = true;
            this.butNextPage.Click += new System.EventHandler(this.butNextPage_Click);
            // 
            // vendorModelBindingSource
            // 
            this.vendorModelBindingSource.DataSource = typeof(Eureka.Core.Domain.Payables.VendorModel);
            // 
            // vendorIdDataGridViewTextBoxColumn
            // 
            this.vendorIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorIdDataGridViewTextBoxColumn.DataPropertyName = "VendorId";
            this.vendorIdDataGridViewTextBoxColumn.HeaderText = "VendorId";
            this.vendorIdDataGridViewTextBoxColumn.Name = "vendorIdDataGridViewTextBoxColumn";
            this.vendorIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorIdDataGridViewTextBoxColumn.Visible = false;
            this.vendorIdDataGridViewTextBoxColumn.Width = 90;
            // 
            // vendorNumberDataGridViewTextBoxColumn
            // 
            this.vendorNumberDataGridViewTextBoxColumn.DataPropertyName = "VendorNumber";
            this.vendorNumberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.vendorNumberDataGridViewTextBoxColumn.Name = "vendorNumberDataGridViewTextBoxColumn";
            this.vendorNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorNumberDataGridViewTextBoxColumn.Width = 146;
            // 
            // vendorNameDataGridViewTextBoxColumn
            // 
            this.vendorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorNameDataGridViewTextBoxColumn.DataPropertyName = "VendorName";
            this.vendorNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.vendorNameDataGridViewTextBoxColumn.Name = "vendorNameDataGridViewTextBoxColumn";
            this.vendorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorNameDataGridViewTextBoxColumn.Width = 71;
            // 
            // vatRegistrationNumDataGridViewTextBoxColumn
            // 
            this.vatRegistrationNumDataGridViewTextBoxColumn.DataPropertyName = "VatRegistrationNum";
            this.vatRegistrationNumDataGridViewTextBoxColumn.HeaderText = "TAX ID";
            this.vatRegistrationNumDataGridViewTextBoxColumn.Name = "vatRegistrationNumDataGridViewTextBoxColumn";
            this.vatRegistrationNumDataGridViewTextBoxColumn.ReadOnly = true;
            this.vatRegistrationNumDataGridViewTextBoxColumn.Width = 146;
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 80;
            // 
            // VendorListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(734, 433);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.bindingNav);
            this.Controls.Add(this.metroPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VendorListForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Vendors";
            this.Load += new System.EventHandler(this.VendorListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).EndInit();
            this.bindingNav.ResumeLayout(false);
            this.bindingNav.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendors)).EndInit();
            this.metroPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vendorModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNav;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorFilter;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroGrid dgvVendors;
        private MetroFramework.Controls.MetroTextBox txtVendorName;
        private MetroFramework.Controls.MetroTextBox txtVendorNum;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroTextBox txtPageNumber;
        private MetroFramework.Controls.MetroButton butPreviousPage;
        private MetroFramework.Controls.MetroButton butNextPage;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.BindingSource vendorModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vatRegistrationNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
    }
}