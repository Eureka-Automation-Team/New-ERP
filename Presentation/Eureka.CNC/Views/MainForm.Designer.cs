namespace Eureka.CNC.Views
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLogOff = new MaterialSkin.Controls.MaterialRaisedButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnJobEntry = new System.Windows.Forms.Button();
            this.btnTaskManagement = new System.Windows.Forms.Button();
            this.btnDashboards = new System.Windows.Forms.Button();
            this.btnTestUpload = new System.Windows.Forms.Button();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbHostName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbDatabaseName = new System.Windows.Forms.ToolStripStatusLabel();
            this.monitoringStatus = new System.Windows.Forms.StatusStrip();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.monitoringStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.btnLogOff);
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Location = new System.Drawing.Point(0, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(349, 431);
            this.panel3.TabIndex = 2;
            // 
            // btnLogOff
            // 
            this.btnLogOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOff.Depth = 0;
            this.btnLogOff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogOff.Location = new System.Drawing.Point(3, 389);
            this.btnLogOff.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogOff.Name = "btnLogOff";
            this.btnLogOff.Primary = true;
            this.btnLogOff.Size = new System.Drawing.Size(338, 39);
            this.btnLogOff.TabIndex = 1;
            this.btnLogOff.Text = "Log Off";
            this.btnLogOff.UseCompatibleTextRendering = true;
            this.btnLogOff.UseMnemonic = false;
            this.btnLogOff.UseVisualStyleBackColor = true;
            this.btnLogOff.Click += new System.EventHandler(this.btnLogOff_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnJobEntry);
            this.flowLayoutPanel1.Controls.Add(this.btnTaskManagement);
            this.flowLayoutPanel1.Controls.Add(this.btnDashboards);
            this.flowLayoutPanel1.Controls.Add(this.btnTestUpload);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(349, 208);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnJobEntry
            // 
            this.btnJobEntry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJobEntry.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnJobEntry.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobEntry.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnJobEntry.Location = new System.Drawing.Point(3, 3);
            this.btnJobEntry.Name = "btnJobEntry";
            this.btnJobEntry.Size = new System.Drawing.Size(338, 44);
            this.btnJobEntry.TabIndex = 0;
            this.btnJobEntry.Text = "Jobs Entry";
            this.btnJobEntry.UseVisualStyleBackColor = true;
            this.btnJobEntry.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTaskManagement
            // 
            this.btnTaskManagement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaskManagement.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskManagement.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnTaskManagement.Location = new System.Drawing.Point(3, 53);
            this.btnTaskManagement.Name = "btnTaskManagement";
            this.btnTaskManagement.Size = new System.Drawing.Size(338, 44);
            this.btnTaskManagement.TabIndex = 1;
            this.btnTaskManagement.Text = "Task Management";
            this.btnTaskManagement.UseVisualStyleBackColor = true;
            this.btnTaskManagement.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDashboards
            // 
            this.btnDashboards.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboards.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDashboards.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboards.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnDashboards.Location = new System.Drawing.Point(3, 103);
            this.btnDashboards.Name = "btnDashboards";
            this.btnDashboards.Size = new System.Drawing.Size(338, 44);
            this.btnDashboards.TabIndex = 2;
            this.btnDashboards.Text = "Dashboards";
            this.btnDashboards.UseVisualStyleBackColor = true;
            this.btnDashboards.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnTestUpload
            // 
            this.btnTestUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestUpload.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTestUpload.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestUpload.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnTestUpload.Location = new System.Drawing.Point(3, 153);
            this.btnTestUpload.Name = "btnTestUpload";
            this.btnTestUpload.Size = new System.Drawing.Size(338, 44);
            this.btnTestUpload.TabIndex = 3;
            this.btnTestUpload.Text = "Test Upload File";
            this.btnTestUpload.UseVisualStyleBackColor = true;
            this.btnTestUpload.Click += new System.EventHandler(this.btnTestUpload_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(49, 17);
            this.toolStripStatusLabel2.Text = "Host : ";
            // 
            // tsbHostName
            // 
            this.tsbHostName.Name = "tsbHostName";
            this.tsbHostName.Size = new System.Drawing.Size(117, 19);
            this.tsbHostName.Text = "192.168.122.250";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(85, 17);
            this.toolStripStatusLabel1.Text = "Database : ";
            // 
            // tsbDatabaseName
            // 
            this.tsbDatabaseName.Name = "tsbDatabaseName";
            this.tsbDatabaseName.Size = new System.Drawing.Size(36, 19);
            this.tsbDatabaseName.Text = "DEV";
            // 
            // monitoringStatus
            // 
            this.monitoringStatus.BackColor = System.Drawing.Color.Transparent;
            this.monitoringStatus.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.monitoringStatus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.monitoringStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.tsbHostName,
            this.toolStripStatusLabel1,
            this.tsbDatabaseName});
            this.monitoringStatus.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.monitoringStatus.Location = new System.Drawing.Point(0, 494);
            this.monitoringStatus.Name = "monitoringStatus";
            this.monitoringStatus.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.monitoringStatus.Size = new System.Drawing.Size(349, 24);
            this.monitoringStatus.SizingGrip = false;
            this.monitoringStatus.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(349, 518);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.monitoringStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CNC";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.monitoringStatus.ResumeLayout(false);
            this.monitoringStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnJobEntry;
        private System.Windows.Forms.Button btnTaskManagement;
        private System.Windows.Forms.Button btnDashboards;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsbHostName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsbDatabaseName;
        private System.Windows.Forms.StatusStrip monitoringStatus;
        private MaterialSkin.Controls.MaterialRaisedButton btnLogOff;
        private System.Windows.Forms.Button btnTestUpload;
    }
}