namespace Eureka.Froms.Views.Inventory
{
    partial class ItemListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemListForm));
            this.txtPageNumber = new MetroFramework.Controls.MetroTextBox();
            this.butNextPage = new MetroFramework.Controls.MetroButton();
            this.dgvList = new MetroFramework.Controls.MetroGrid();
            this.inventoryItemIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.segment1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.segment2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.segment3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricePerUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPricePerUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemMasterModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtitemDescription = new MetroFramework.Controls.MetroTextBox();
            this.txtitemCode = new MetroFramework.Controls.MetroTextBox();
            this.butPreviousPage = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtbrandMat = new MetroFramework.Controls.MetroTextBox();
            this.txtmanuId = new MetroFramework.Controls.MetroTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorFilter = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.butCopyItem = new MetroFramework.Controls.MetroButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNav = new System.Windows.Forms.BindingNavigator(this.components);
            this.butClose = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMasterModelBindingSource)).BeginInit();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).BeginInit();
            this.bindingNav.SuspendLayout();
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
            this.txtPageNumber.Location = new System.Drawing.Point(640, 1);
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
            this.butNextPage.Location = new System.Drawing.Point(723, 1);
            this.butNextPage.Name = "butNextPage";
            this.butNextPage.Size = new System.Drawing.Size(37, 25);
            this.butNextPage.TabIndex = 2;
            this.butNextPage.Text = ">";
            this.butNextPage.UseSelectable = true;
            this.butNextPage.Click += new System.EventHandler(this.butNextPage_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToOrderColumns = true;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.AutoGenerateColumns = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvList.ColumnHeadersHeight = 25;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inventoryItemIdDataGridViewTextBoxColumn,
            this.segment1DataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.segment2DataGridViewTextBoxColumn,
            this.segment3DataGridViewTextBoxColumn,
            this.pricePerUnitDataGridViewTextBoxColumn,
            this.costPricePerUnitDataGridViewTextBoxColumn});
            this.dgvList.DataSource = this.itemMasterModelBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle8;
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvList.RowHeadersWidth = 30;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvList.RowTemplate.Height = 60;
            this.dgvList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(760, 494);
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
            // inventoryItemIdDataGridViewTextBoxColumn
            // 
            this.inventoryItemIdDataGridViewTextBoxColumn.DataPropertyName = "InventoryItemId";
            this.inventoryItemIdDataGridViewTextBoxColumn.HeaderText = "InventoryItemId";
            this.inventoryItemIdDataGridViewTextBoxColumn.Name = "inventoryItemIdDataGridViewTextBoxColumn";
            this.inventoryItemIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.inventoryItemIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // segment1DataGridViewTextBoxColumn
            // 
            this.segment1DataGridViewTextBoxColumn.DataPropertyName = "Segment1";
            this.segment1DataGridViewTextBoxColumn.HeaderText = "Item Code";
            this.segment1DataGridViewTextBoxColumn.Name = "segment1DataGridViewTextBoxColumn";
            this.segment1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // segment2DataGridViewTextBoxColumn
            // 
            this.segment2DataGridViewTextBoxColumn.DataPropertyName = "Segment2";
            this.segment2DataGridViewTextBoxColumn.HeaderText = "MANU ID";
            this.segment2DataGridViewTextBoxColumn.Name = "segment2DataGridViewTextBoxColumn";
            this.segment2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // segment3DataGridViewTextBoxColumn
            // 
            this.segment3DataGridViewTextBoxColumn.DataPropertyName = "Segment3";
            this.segment3DataGridViewTextBoxColumn.HeaderText = "Brand/Mat";
            this.segment3DataGridViewTextBoxColumn.Name = "segment3DataGridViewTextBoxColumn";
            this.segment3DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pricePerUnitDataGridViewTextBoxColumn
            // 
            this.pricePerUnitDataGridViewTextBoxColumn.DataPropertyName = "PricePerUnit";
            this.pricePerUnitDataGridViewTextBoxColumn.HeaderText = "PricePerUnit";
            this.pricePerUnitDataGridViewTextBoxColumn.Name = "pricePerUnitDataGridViewTextBoxColumn";
            this.pricePerUnitDataGridViewTextBoxColumn.ReadOnly = true;
            this.pricePerUnitDataGridViewTextBoxColumn.Visible = false;
            // 
            // costPricePerUnitDataGridViewTextBoxColumn
            // 
            this.costPricePerUnitDataGridViewTextBoxColumn.DataPropertyName = "CostPricePerUnit";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.costPricePerUnitDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.costPricePerUnitDataGridViewTextBoxColumn.HeaderText = "Cost/Unit";
            this.costPricePerUnitDataGridViewTextBoxColumn.Name = "costPricePerUnitDataGridViewTextBoxColumn";
            this.costPricePerUnitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemMasterModelBindingSource
            // 
            this.itemMasterModelBindingSource.DataSource = typeof(Eureka.Core.Domain.Inventory.ItemMasterModel);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.dgvList);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(20, 147);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(760, 494);
            this.metroPanel2.TabIndex = 30;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(7, 36);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(85, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel1.TabIndex = 16;
            this.metroLabel1.Text = "Description :";
            this.metroLabel1.UseStyleColors = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(12, 9);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(80, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel6.TabIndex = 15;
            this.metroLabel6.Text = "Item Code :";
            this.metroLabel6.UseStyleColors = true;
            // 
            // txtitemDescription
            // 
            // 
            // 
            // 
            this.txtitemDescription.CustomButton.Image = null;
            this.txtitemDescription.CustomButton.Location = new System.Drawing.Point(254, 1);
            this.txtitemDescription.CustomButton.Name = "";
            this.txtitemDescription.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtitemDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtitemDescription.CustomButton.TabIndex = 1;
            this.txtitemDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtitemDescription.CustomButton.UseSelectable = true;
            this.txtitemDescription.CustomButton.Visible = false;
            this.txtitemDescription.Lines = new string[0];
            this.txtitemDescription.Location = new System.Drawing.Point(98, 30);
            this.txtitemDescription.MaxLength = 32767;
            this.txtitemDescription.Name = "txtitemDescription";
            this.txtitemDescription.PasswordChar = '\0';
            this.txtitemDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtitemDescription.SelectedText = "";
            this.txtitemDescription.SelectionLength = 0;
            this.txtitemDescription.SelectionStart = 0;
            this.txtitemDescription.ShortcutsEnabled = true;
            this.txtitemDescription.Size = new System.Drawing.Size(278, 25);
            this.txtitemDescription.Style = MetroFramework.MetroColorStyle.Green;
            this.txtitemDescription.TabIndex = 14;
            this.txtitemDescription.UseSelectable = true;
            this.txtitemDescription.UseStyleColors = true;
            this.txtitemDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtitemDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtitemCode
            // 
            // 
            // 
            // 
            this.txtitemCode.CustomButton.Image = null;
            this.txtitemCode.CustomButton.Location = new System.Drawing.Point(254, 1);
            this.txtitemCode.CustomButton.Name = "";
            this.txtitemCode.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtitemCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtitemCode.CustomButton.TabIndex = 1;
            this.txtitemCode.CustomButton.Text = "...";
            this.txtitemCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtitemCode.CustomButton.UseSelectable = true;
            this.txtitemCode.CustomButton.Visible = false;
            this.txtitemCode.Lines = new string[0];
            this.txtitemCode.Location = new System.Drawing.Point(98, 3);
            this.txtitemCode.MaxLength = 32767;
            this.txtitemCode.Name = "txtitemCode";
            this.txtitemCode.PasswordChar = '\0';
            this.txtitemCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtitemCode.SelectedText = "";
            this.txtitemCode.SelectionLength = 0;
            this.txtitemCode.SelectionStart = 0;
            this.txtitemCode.ShortcutsEnabled = true;
            this.txtitemCode.ShowClearButton = true;
            this.txtitemCode.Size = new System.Drawing.Size(278, 25);
            this.txtitemCode.Style = MetroFramework.MetroColorStyle.Green;
            this.txtitemCode.TabIndex = 13;
            this.txtitemCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtitemCode.UseSelectable = true;
            this.txtitemCode.UseStyleColors = true;
            this.txtitemCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtitemCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // butPreviousPage
            // 
            this.butPreviousPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPreviousPage.Location = new System.Drawing.Point(601, 1);
            this.butPreviousPage.Name = "butPreviousPage";
            this.butPreviousPage.Size = new System.Drawing.Size(37, 25);
            this.butPreviousPage.TabIndex = 3;
            this.butPreviousPage.Text = "<";
            this.butPreviousPage.UseSelectable = true;
            this.butPreviousPage.Click += new System.EventHandler(this.butPreviousPage_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.txtbrandMat);
            this.metroPanel1.Controls.Add(this.txtmanuId);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.metroLabel6);
            this.metroPanel1.Controls.Add(this.txtitemDescription);
            this.metroPanel1.Controls.Add(this.txtitemCode);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 87);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(760, 60);
            this.metroPanel1.TabIndex = 29;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(391, 36);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(78, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel2.TabIndex = 20;
            this.metroLabel2.Text = "Brand/Mat:";
            this.metroLabel2.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(393, 9);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(76, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel3.TabIndex = 19;
            this.metroLabel3.Text = "MANU ID :";
            this.metroLabel3.UseStyleColors = true;
            // 
            // txtbrandMat
            // 
            // 
            // 
            // 
            this.txtbrandMat.CustomButton.Image = null;
            this.txtbrandMat.CustomButton.Location = new System.Drawing.Point(254, 1);
            this.txtbrandMat.CustomButton.Name = "";
            this.txtbrandMat.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtbrandMat.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbrandMat.CustomButton.TabIndex = 1;
            this.txtbrandMat.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbrandMat.CustomButton.UseSelectable = true;
            this.txtbrandMat.CustomButton.Visible = false;
            this.txtbrandMat.Lines = new string[0];
            this.txtbrandMat.Location = new System.Drawing.Point(479, 30);
            this.txtbrandMat.MaxLength = 32767;
            this.txtbrandMat.Name = "txtbrandMat";
            this.txtbrandMat.PasswordChar = '\0';
            this.txtbrandMat.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbrandMat.SelectedText = "";
            this.txtbrandMat.SelectionLength = 0;
            this.txtbrandMat.SelectionStart = 0;
            this.txtbrandMat.ShortcutsEnabled = true;
            this.txtbrandMat.Size = new System.Drawing.Size(278, 25);
            this.txtbrandMat.Style = MetroFramework.MetroColorStyle.Green;
            this.txtbrandMat.TabIndex = 18;
            this.txtbrandMat.UseSelectable = true;
            this.txtbrandMat.UseStyleColors = true;
            this.txtbrandMat.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbrandMat.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtmanuId
            // 
            // 
            // 
            // 
            this.txtmanuId.CustomButton.Image = null;
            this.txtmanuId.CustomButton.Location = new System.Drawing.Point(254, 1);
            this.txtmanuId.CustomButton.Name = "";
            this.txtmanuId.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtmanuId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtmanuId.CustomButton.TabIndex = 1;
            this.txtmanuId.CustomButton.Text = "...";
            this.txtmanuId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtmanuId.CustomButton.UseSelectable = true;
            this.txtmanuId.CustomButton.Visible = false;
            this.txtmanuId.Lines = new string[0];
            this.txtmanuId.Location = new System.Drawing.Point(479, 3);
            this.txtmanuId.MaxLength = 32767;
            this.txtmanuId.Name = "txtmanuId";
            this.txtmanuId.PasswordChar = '\0';
            this.txtmanuId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtmanuId.SelectedText = "";
            this.txtmanuId.SelectionLength = 0;
            this.txtmanuId.SelectionStart = 0;
            this.txtmanuId.ShortcutsEnabled = true;
            this.txtmanuId.ShowClearButton = true;
            this.txtmanuId.Size = new System.Drawing.Size(278, 25);
            this.txtmanuId.Style = MetroFramework.MetroColorStyle.Green;
            this.txtmanuId.TabIndex = 17;
            this.txtmanuId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtmanuId.UseSelectable = true;
            this.txtmanuId.UseStyleColors = true;
            this.txtmanuId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtmanuId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
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
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
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
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
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
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.butCopyItem);
            this.metroPanel3.Controls.Add(this.txtPageNumber);
            this.metroPanel3.Controls.Add(this.butPreviousPage);
            this.metroPanel3.Controls.Add(this.butNextPage);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(20, 641);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(760, 29);
            this.metroPanel3.TabIndex = 31;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // butCopyItem
            // 
            this.butCopyItem.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.butCopyItem.Location = new System.Drawing.Point(479, 0);
            this.butCopyItem.Name = "butCopyItem";
            this.butCopyItem.Size = new System.Drawing.Size(116, 26);
            this.butCopyItem.TabIndex = 15;
            this.butCopyItem.Text = "Copy Item";
            this.butCopyItem.UseSelectable = true;
            this.butCopyItem.Visible = false;
            this.butCopyItem.Click += new System.EventHandler(this.butCopyItem_Click);
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
            this.bindingNav.Size = new System.Drawing.Size(760, 27);
            this.bindingNav.TabIndex = 28;
            this.bindingNav.Text = "Navigator";
            // 
            // butClose
            // 
            this.butClose.ActiveControl = null;
            this.butClose.Location = new System.Drawing.Point(776, 6);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(22, 22);
            this.butClose.Style = MetroFramework.MetroColorStyle.Green;
            this.butClose.TabIndex = 32;
            this.butClose.TileImage = ((System.Drawing.Image)(resources.GetObject("butClose.TileImage")));
            this.butClose.UseSelectable = true;
            this.butClose.UseStyleColors = true;
            this.butClose.UseTileImage = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // ItemListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 690);
            this.ControlBox = false;
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.metroPanel3);
            this.Controls.Add(this.bindingNav);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemListForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "ItemListForm";
            this.Load += new System.EventHandler(this.ItemListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMasterModelBindingSource)).EndInit();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).EndInit();
            this.bindingNav.ResumeLayout(false);
            this.bindingNav.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtPageNumber;
        private MetroFramework.Controls.MetroButton butNextPage;
        private MetroFramework.Controls.MetroGrid dgvList;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtitemDescription;
        private MetroFramework.Controls.MetroTextBox txtitemCode;
        private MetroFramework.Controls.MetroButton butPreviousPage;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorFilter;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.BindingNavigator bindingNav;
        private System.Windows.Forms.BindingSource itemMasterModelBindingSource;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtbrandMat;
        private MetroFramework.Controls.MetroTextBox txtmanuId;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventoryItemIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn segment1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn segment2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn segment3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pricePerUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPricePerUnitDataGridViewTextBoxColumn;
        private MetroFramework.Controls.MetroButton butCopyItem;
        private MetroFramework.Controls.MetroTile butClose;
    }
}