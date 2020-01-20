namespace Eureka.Froms.Views.Purchasing
{
    partial class RequisitionListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequisitionListForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPageNumber = new MetroFramework.Controls.MetroTextBox();
            this.butNextPage = new MetroFramework.Controls.MetroButton();
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
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.butPreviousPage = new MetroFramework.Controls.MetroButton();
            this.dtpEndDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dtpStartDate = new MetroFramework.Controls.MetroDateTime();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtRequisitionNumber = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtProjectNum = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.dgvList = new MetroFramework.Controls.MetroGrid();
            this.requisitionHeaderModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.requisitionHeaderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisitionNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisitionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bomNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).BeginInit();
            this.bindingNav.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requisitionHeaderModelBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.txtPageNumber.Location = new System.Drawing.Point(406, 1);
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
            // butNextPage
            // 
            this.butNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butNextPage.Location = new System.Drawing.Point(489, 1);
            this.butNextPage.Name = "butNextPage";
            this.butNextPage.Size = new System.Drawing.Size(37, 25);
            this.butNextPage.TabIndex = 2;
            this.butNextPage.Text = ">";
            this.butNextPage.UseSelectable = true;
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
            this.bindingNav.Size = new System.Drawing.Size(526, 27);
            this.bindingNav.TabIndex = 27;
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
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.txtPageNumber);
            this.metroPanel3.Controls.Add(this.butPreviousPage);
            this.metroPanel3.Controls.Add(this.butNextPage);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(20, 469);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(526, 29);
            this.metroPanel3.TabIndex = 30;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // butPreviousPage
            // 
            this.butPreviousPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPreviousPage.Location = new System.Drawing.Point(367, 1);
            this.butPreviousPage.Name = "butPreviousPage";
            this.butPreviousPage.Size = new System.Drawing.Size(37, 25);
            this.butPreviousPage.TabIndex = 3;
            this.butPreviousPage.Text = "<";
            this.butPreviousPage.UseSelectable = true;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpEndDate.DisplayFocus = true;
            this.dtpEndDate.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(285, 40);
            this.dtpEndDate.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(157, 25);
            this.dtpEndDate.Style = MetroFramework.MetroColorStyle.Green;
            this.dtpEndDate.TabIndex = 23;
            this.dtpEndDate.UseStyleColors = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(253, 40);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(26, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel2.TabIndex = 22;
            this.metroLabel2.Text = "To:";
            this.metroLabel2.UseStyleColors = true;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpStartDate.DisplayFocus = true;
            this.dtpStartDate.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(90, 40);
            this.dtpStartDate.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(157, 25);
            this.dtpStartDate.Style = MetroFramework.MetroColorStyle.Green;
            this.dtpStartDate.TabIndex = 21;
            this.dtpStartDate.UseStyleColors = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.txtRequisitionNumber);
            this.metroPanel1.Controls.Add(this.dtpEndDate);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.dtpStartDate);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.metroLabel6);
            this.metroPanel1.Controls.Add(this.txtProjectNum);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 87);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(526, 71);
            this.metroPanel1.TabIndex = 28;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(202, 3);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(101, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel3.TabIndex = 25;
            this.metroLabel3.Text = "Requisition No.";
            this.metroLabel3.UseStyleColors = true;
            // 
            // txtRequisitionNumber
            // 
            this.txtRequisitionNumber.AccessibleDescription = "";
            // 
            // 
            // 
            this.txtRequisitionNumber.CustomButton.Image = null;
            this.txtRequisitionNumber.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.txtRequisitionNumber.CustomButton.Name = "";
            this.txtRequisitionNumber.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtRequisitionNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRequisitionNumber.CustomButton.TabIndex = 1;
            this.txtRequisitionNumber.CustomButton.Text = "...";
            this.txtRequisitionNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRequisitionNumber.CustomButton.UseSelectable = true;
            this.txtRequisitionNumber.CustomButton.Visible = false;
            this.txtRequisitionNumber.Lines = new string[0];
            this.txtRequisitionNumber.Location = new System.Drawing.Point(309, 3);
            this.txtRequisitionNumber.MaxLength = 32767;
            this.txtRequisitionNumber.Name = "txtRequisitionNumber";
            this.txtRequisitionNumber.PasswordChar = '\0';
            this.txtRequisitionNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRequisitionNumber.SelectedText = "";
            this.txtRequisitionNumber.SelectionLength = 0;
            this.txtRequisitionNumber.SelectionStart = 0;
            this.txtRequisitionNumber.ShortcutsEnabled = true;
            this.txtRequisitionNumber.ShowClearButton = true;
            this.txtRequisitionNumber.Size = new System.Drawing.Size(133, 25);
            this.txtRequisitionNumber.Style = MetroFramework.MetroColorStyle.Green;
            this.txtRequisitionNumber.TabIndex = 24;
            this.txtRequisitionNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRequisitionNumber.UseSelectable = true;
            this.txtRequisitionNumber.UseStyleColors = true;
            this.txtRequisitionNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRequisitionNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(10, 40);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(74, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel1.TabIndex = 20;
            this.metroLabel1.Text = "Start Date:";
            this.metroLabel1.UseStyleColors = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(7, 3);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(76, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel6.TabIndex = 15;
            this.metroLabel6.Text = "Project No.";
            this.metroLabel6.UseStyleColors = true;
            // 
            // txtProjectNum
            // 
            // 
            // 
            // 
            this.txtProjectNum.CustomButton.Image = null;
            this.txtProjectNum.CustomButton.Location = new System.Drawing.Point(82, 1);
            this.txtProjectNum.CustomButton.Name = "";
            this.txtProjectNum.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtProjectNum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtProjectNum.CustomButton.TabIndex = 1;
            this.txtProjectNum.CustomButton.Text = "...";
            this.txtProjectNum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtProjectNum.CustomButton.UseSelectable = true;
            this.txtProjectNum.CustomButton.Visible = false;
            this.txtProjectNum.Lines = new string[0];
            this.txtProjectNum.Location = new System.Drawing.Point(90, 3);
            this.txtProjectNum.MaxLength = 32767;
            this.txtProjectNum.Name = "txtProjectNum";
            this.txtProjectNum.PasswordChar = '\0';
            this.txtProjectNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProjectNum.SelectedText = "";
            this.txtProjectNum.SelectionLength = 0;
            this.txtProjectNum.SelectionStart = 0;
            this.txtProjectNum.ShortcutsEnabled = true;
            this.txtProjectNum.ShowClearButton = true;
            this.txtProjectNum.Size = new System.Drawing.Size(106, 25);
            this.txtProjectNum.Style = MetroFramework.MetroColorStyle.Green;
            this.txtProjectNum.TabIndex = 13;
            this.txtProjectNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProjectNum.UseSelectable = true;
            this.txtProjectNum.UseStyleColors = true;
            this.txtProjectNum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtProjectNum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.dgvList);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(20, 158);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(526, 311);
            this.metroPanel2.TabIndex = 29;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToOrderColumns = true;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.AutoGenerateColumns = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.ColumnHeadersHeight = 25;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.requisitionHeaderIdDataGridViewTextBoxColumn,
            this.requisitionNumberDataGridViewTextBoxColumn,
            this.requisitionDateDataGridViewTextBoxColumn,
            this.bomNumberDataGridViewTextBoxColumn,
            this.costCodeDataGridViewTextBoxColumn});
            this.dgvList.DataSource = this.requisitionHeaderModelBindingSource;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvList.RowTemplate.Height = 60;
            this.dgvList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(526, 311);
            this.dgvList.StandardTab = true;
            this.dgvList.Style = MetroFramework.MetroColorStyle.Green;
            this.dgvList.TabIndex = 37;
            this.dgvList.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dgvList.UseCustomBackColor = true;
            this.dgvList.UseCustomForeColor = true;
            this.dgvList.UseStyleColors = true;
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            this.dgvList.SelectionChanged += new System.EventHandler(this.dgvList_SelectionChanged);
            // 
            // requisitionHeaderModelBindingSource
            // 
            this.requisitionHeaderModelBindingSource.DataSource = typeof(Eureka.Core.Domain.Purchasing.RequisitionHeaderModel);
            // 
            // requisitionHeaderIdDataGridViewTextBoxColumn
            // 
            this.requisitionHeaderIdDataGridViewTextBoxColumn.DataPropertyName = "RequisitionHeaderId";
            this.requisitionHeaderIdDataGridViewTextBoxColumn.HeaderText = "RequisitionHeaderId";
            this.requisitionHeaderIdDataGridViewTextBoxColumn.Name = "requisitionHeaderIdDataGridViewTextBoxColumn";
            this.requisitionHeaderIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.requisitionHeaderIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // requisitionNumberDataGridViewTextBoxColumn
            // 
            this.requisitionNumberDataGridViewTextBoxColumn.DataPropertyName = "RequisitionNumber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.requisitionNumberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.requisitionNumberDataGridViewTextBoxColumn.HeaderText = "Req No.";
            this.requisitionNumberDataGridViewTextBoxColumn.Name = "requisitionNumberDataGridViewTextBoxColumn";
            this.requisitionNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // requisitionDateDataGridViewTextBoxColumn
            // 
            this.requisitionDateDataGridViewTextBoxColumn.DataPropertyName = "RequisitionDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.requisitionDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.requisitionDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.requisitionDateDataGridViewTextBoxColumn.Name = "requisitionDateDataGridViewTextBoxColumn";
            this.requisitionDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bomNumberDataGridViewTextBoxColumn
            // 
            this.bomNumberDataGridViewTextBoxColumn.DataPropertyName = "BomNumber";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bomNumberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.bomNumberDataGridViewTextBoxColumn.HeaderText = "Bom No.";
            this.bomNumberDataGridViewTextBoxColumn.Name = "bomNumberDataGridViewTextBoxColumn";
            this.bomNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costCodeDataGridViewTextBoxColumn
            // 
            this.costCodeDataGridViewTextBoxColumn.DataPropertyName = "CostCode";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.costCodeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.costCodeDataGridViewTextBoxColumn.HeaderText = "Cost Code";
            this.costCodeDataGridViewTextBoxColumn.Name = "costCodeDataGridViewTextBoxColumn";
            this.costCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // RequisitionListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 518);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.bindingNav);
            this.Controls.Add(this.metroPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RequisitionListForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Requisition List";
            this.Load += new System.EventHandler(this.RequisitionListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).EndInit();
            this.bindingNav.ResumeLayout(false);
            this.bindingNav.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requisitionHeaderModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtPageNumber;
        private MetroFramework.Controls.MetroButton butNextPage;
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
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroButton butPreviousPage;
        private MetroFramework.Controls.MetroDateTime dtpEndDate;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime dtpStartDate;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtProjectNum;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroGrid dgvList;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtRequisitionNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisitionHeaderIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisitionNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requisitionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bomNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource requisitionHeaderModelBindingSource;
    }
}