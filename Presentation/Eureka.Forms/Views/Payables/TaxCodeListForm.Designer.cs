namespace Eureka.Froms.Views.Payables
{
    partial class TaxCodeListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaxCodeListForm));
            this.txtTaxCode = new MetroFramework.Controls.MetroTextBox();
            this.dgvTaxCodes = new MetroFramework.Controls.MetroGrid();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorFilter = new System.Windows.Forms.ToolStripButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNav = new System.Windows.Forms.BindingNavigator(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxCodes)).BeginInit();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).BeginInit();
            this.bindingNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTaxCode
            // 
            // 
            // 
            // 
            this.txtTaxCode.CustomButton.Image = null;
            this.txtTaxCode.CustomButton.Location = new System.Drawing.Point(103, 1);
            this.txtTaxCode.CustomButton.Name = "";
            this.txtTaxCode.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtTaxCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTaxCode.CustomButton.TabIndex = 1;
            this.txtTaxCode.CustomButton.Text = "...";
            this.txtTaxCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTaxCode.CustomButton.UseSelectable = true;
            this.txtTaxCode.CustomButton.Visible = false;
            this.txtTaxCode.Lines = new string[0];
            this.txtTaxCode.Location = new System.Drawing.Point(83, 2);
            this.txtTaxCode.MaxLength = 32767;
            this.txtTaxCode.Name = "txtTaxCode";
            this.txtTaxCode.PasswordChar = '\0';
            this.txtTaxCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTaxCode.SelectedText = "";
            this.txtTaxCode.SelectionLength = 0;
            this.txtTaxCode.SelectionStart = 0;
            this.txtTaxCode.ShortcutsEnabled = true;
            this.txtTaxCode.ShowClearButton = true;
            this.txtTaxCode.Size = new System.Drawing.Size(127, 25);
            this.txtTaxCode.Style = MetroFramework.MetroColorStyle.Green;
            this.txtTaxCode.TabIndex = 13;
            this.txtTaxCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTaxCode.UseSelectable = true;
            this.txtTaxCode.UseStyleColors = true;
            this.txtTaxCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTaxCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dgvTaxCodes
            // 
            this.dgvTaxCodes.AllowUserToAddRows = false;
            this.dgvTaxCodes.AllowUserToDeleteRows = false;
            this.dgvTaxCodes.AllowUserToOrderColumns = true;
            this.dgvTaxCodes.AllowUserToResizeRows = false;
            this.dgvTaxCodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaxCodes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTaxCodes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvTaxCodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTaxCodes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvTaxCodes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaxCodes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTaxCodes.ColumnHeadersHeight = 25;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTaxCodes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTaxCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaxCodes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTaxCodes.EnableHeadersVisualStyles = false;
            this.dgvTaxCodes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvTaxCodes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvTaxCodes.Location = new System.Drawing.Point(0, 0);
            this.dgvTaxCodes.MultiSelect = false;
            this.dgvTaxCodes.Name = "dgvTaxCodes";
            this.dgvTaxCodes.ReadOnly = true;
            this.dgvTaxCodes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaxCodes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTaxCodes.RowHeadersWidth = 30;
            this.dgvTaxCodes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dgvTaxCodes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTaxCodes.RowTemplate.Height = 60;
            this.dgvTaxCodes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaxCodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaxCodes.Size = new System.Drawing.Size(333, 359);
            this.dgvTaxCodes.StandardTab = true;
            this.dgvTaxCodes.Style = MetroFramework.MetroColorStyle.Green;
            this.dgvTaxCodes.TabIndex = 37;
            this.dgvTaxCodes.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dgvTaxCodes.UseCustomBackColor = true;
            this.dgvTaxCodes.UseCustomForeColor = true;
            this.dgvTaxCodes.UseStyleColors = true;
            this.dgvTaxCodes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaxCodes_CellDoubleClick);
            this.dgvTaxCodes.SelectionChanged += new System.EventHandler(this.dgvTaxCodes_SelectionChanged);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.dgvTaxCodes);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(20, 120);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(333, 359);
            this.metroPanel2.TabIndex = 21;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(7, 3);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(70, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel6.TabIndex = 15;
            this.metroLabel6.Text = "Tax Code :";
            this.metroLabel6.UseStyleColors = true;
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
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroLabel6);
            this.metroPanel1.Controls.Add(this.txtTaxCode);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 87);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(333, 33);
            this.metroPanel1.TabIndex = 20;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
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
            this.bindingNav.Size = new System.Drawing.Size(333, 27);
            this.bindingNav.TabIndex = 19;
            this.bindingNav.Text = "Navigator";
            // 
            // TaxCodeListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 499);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.bindingNav);
            this.Name = "TaxCodeListForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Tax Codes";
            this.Load += new System.EventHandler(this.TaxCodeListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxCodes)).EndInit();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNav)).EndInit();
            this.bindingNav.ResumeLayout(false);
            this.bindingNav.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtTaxCode;
        private MetroFramework.Controls.MetroGrid dgvTaxCodes;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorFilter;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingNavigator bindingNav;
    }
}