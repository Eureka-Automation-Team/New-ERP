namespace Eureka.CNC.Views
{
    partial class TaskMonitoringUc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTasks = new MetroFramework.Controls.MetroGrid();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StandardTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineNoReady = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ReserveShelfFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ShelfNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnShelfFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UploadNcfileFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StartFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.McUnloadFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.McPushFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OutboundFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OutboundFinishFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.QCStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 37);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvTasks);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(797, 394);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tasks Monitoring";
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToDeleteRows = false;
            this.dgvTasks.AllowUserToOrderColumns = true;
            this.dgvTasks.AllowUserToResizeRows = false;
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
            this.Priority,
            this.StandardTime,
            this.MachineNoReady,
            this.ReleaseFlag,
            this.ReserveShelfFlag,
            this.ShelfNumber,
            this.OnShelfFlag,
            this.UploadNcfileFlag,
            this.StartFlag,
            this.McUnloadFlag,
            this.McPushFlag,
            this.OutboundFlag,
            this.OutboundFinishFlag,
            this.QCStatus});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTasks.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTasks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTasks.EnableHeadersVisualStyles = false;
            this.dgvTasks.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvTasks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvTasks.Location = new System.Drawing.Point(0, 0);
            this.dgvTasks.MultiSelect = false;
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasks.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTasks.RowHeadersWidth = 30;
            this.dgvTasks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dgvTasks.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTasks.RowTemplate.Height = 60;
            this.dgvTasks.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.Size = new System.Drawing.Size(797, 394);
            this.dgvTasks.Style = MetroFramework.MetroColorStyle.Blue;
            this.dgvTasks.TabIndex = 41;
            this.dgvTasks.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dgvTasks.UseCustomBackColor = true;
            this.dgvTasks.UseCustomForeColor = true;
            this.dgvTasks.UseStyleColors = true;
            // 
            // Priority
            // 
            this.Priority.DataPropertyName = "Priority";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Priority.DefaultCellStyle = dataGridViewCellStyle2;
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            this.Priority.Width = 73;
            // 
            // StandardTime
            // 
            this.StandardTime.DataPropertyName = "StandardTime";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StandardTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.StandardTime.HeaderText = "Standard Time";
            this.StandardTime.Name = "StandardTime";
            this.StandardTime.Width = 123;
            // 
            // MachineNoReady
            // 
            this.MachineNoReady.DataPropertyName = "MachineNoReady";
            this.MachineNoReady.HeaderText = "MC Ready";
            this.MachineNoReady.Name = "MachineNoReady";
            this.MachineNoReady.ReadOnly = true;
            this.MachineNoReady.Width = 97;
            // 
            // ReleaseFlag
            // 
            this.ReleaseFlag.DataPropertyName = "ReleaseFlag";
            this.ReleaseFlag.HeaderText = "Release";
            this.ReleaseFlag.Name = "ReleaseFlag";
            this.ReleaseFlag.ReadOnly = true;
            this.ReleaseFlag.Width = 61;
            // 
            // ReserveShelfFlag
            // 
            this.ReserveShelfFlag.DataPropertyName = "ReserveShelfFlag";
            this.ReserveShelfFlag.HeaderText = "Reserve";
            this.ReserveShelfFlag.Name = "ReserveShelfFlag";
            this.ReserveShelfFlag.ReadOnly = true;
            this.ReserveShelfFlag.Width = 61;
            // 
            // ShelfNumber
            // 
            this.ShelfNumber.DataPropertyName = "ShelfNumber";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ShelfNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.ShelfNumber.HeaderText = "Shelf No.";
            this.ShelfNumber.Name = "ShelfNumber";
            this.ShelfNumber.Width = 87;
            // 
            // OnShelfFlag
            // 
            this.OnShelfFlag.DataPropertyName = "OnShelfFlag";
            this.OnShelfFlag.HeaderText = "On Shelf In";
            this.OnShelfFlag.Name = "OnShelfFlag";
            this.OnShelfFlag.ReadOnly = true;
            this.OnShelfFlag.Width = 79;
            // 
            // UploadNcfileFlag
            // 
            this.UploadNcfileFlag.DataPropertyName = "UploadNcfileFlag";
            this.UploadNcfileFlag.HeaderText = "NC Uploaded";
            this.UploadNcfileFlag.Name = "UploadNcfileFlag";
            this.UploadNcfileFlag.ReadOnly = true;
            this.UploadNcfileFlag.Width = 101;
            // 
            // StartFlag
            // 
            this.StartFlag.DataPropertyName = "StartFlag";
            this.StartFlag.HeaderText = "MC Start";
            this.StartFlag.Name = "StartFlag";
            this.StartFlag.ReadOnly = true;
            this.StartFlag.Width = 67;
            // 
            // McUnloadFlag
            // 
            this.McUnloadFlag.DataPropertyName = "McUnloadFlag";
            this.McUnloadFlag.HeaderText = "Load Out";
            this.McUnloadFlag.Name = "McUnloadFlag";
            this.McUnloadFlag.ReadOnly = true;
            this.McUnloadFlag.Width = 73;
            // 
            // McPushFlag
            // 
            this.McPushFlag.DataPropertyName = "McPushFlag";
            this.McPushFlag.HeaderText = "On Shelf Out";
            this.McPushFlag.Name = "McPushFlag";
            this.McPushFlag.ReadOnly = true;
            this.McPushFlag.Width = 92;
            // 
            // OutboundFlag
            // 
            this.OutboundFlag.DataPropertyName = "OutboundFlag";
            this.OutboundFlag.HeaderText = "Outbound";
            this.OutboundFlag.Name = "OutboundFlag";
            this.OutboundFlag.ReadOnly = true;
            this.OutboundFlag.Width = 79;
            // 
            // OutboundFinishFlag
            // 
            this.OutboundFinishFlag.DataPropertyName = "OutboundFinishFlag";
            this.OutboundFinishFlag.HeaderText = "Outbound Finish";
            this.OutboundFinishFlag.Name = "OutboundFinishFlag";
            this.OutboundFinishFlag.ReadOnly = true;
            this.OutboundFinishFlag.Width = 116;
            // 
            // QCStatus
            // 
            this.QCStatus.DataPropertyName = "QCStatus";
            this.QCStatus.HeaderText = "QC Status";
            this.QCStatus.Name = "QCStatus";
            this.QCStatus.ReadOnly = true;
            this.QCStatus.Width = 95;
            // 
            // TaskMonitoringUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TaskMonitoringUc";
            this.Size = new System.Drawing.Size(797, 431);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroGrid dgvTasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn StandardTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineNoReady;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ReleaseFlag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ReserveShelfFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShelfNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OnShelfFlag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UploadNcfileFlag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn StartFlag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn McUnloadFlag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn McPushFlag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OutboundFlag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OutboundFinishFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn QCStatus;
    }
}
