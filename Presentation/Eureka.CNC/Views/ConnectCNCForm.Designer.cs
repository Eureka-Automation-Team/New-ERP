namespace Eureka.CNC.Views
{
    partial class ConnectCNCForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.progNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prgDetListDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programListDetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programListDetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(92, 22);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(182, 20);
            this.txtIPAddress.TabIndex = 1;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(92, 48);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(182, 20);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "8193";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP Address :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(92, 74);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(267, 20);
            this.txtFile.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "NC File";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(365, 74);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(112, 20);
            this.btnOpenFile.TabIndex = 7;
            this.btnOpenFile.Text = "Browse...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(483, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 20);
            this.button2.TabIndex = 8;
            this.button2.Text = "Upload NC File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(92, 100);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 20);
            this.button3.TabIndex = 9;
            this.button3.Text = "Re-Load all programs";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.progNameDataGridViewTextBoxColumn,
            this.progNoDataGridViewTextBoxColumn,
            this.progSizeDataGridViewTextBoxColumn,
            this.progDateDataGridViewTextBoxColumn,
            this.prgDetListDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.programListDetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(92, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(700, 315);
            this.dataGridView1.TabIndex = 10;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(247, 100);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 20);
            this.button4.TabIndex = 11;
            this.button4.Text = "Delete Program";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // progNameDataGridViewTextBoxColumn
            // 
            this.progNameDataGridViewTextBoxColumn.DataPropertyName = "ProgName";
            this.progNameDataGridViewTextBoxColumn.HeaderText = "ProgName";
            this.progNameDataGridViewTextBoxColumn.Name = "progNameDataGridViewTextBoxColumn";
            // 
            // progNoDataGridViewTextBoxColumn
            // 
            this.progNoDataGridViewTextBoxColumn.DataPropertyName = "ProgNo";
            this.progNoDataGridViewTextBoxColumn.HeaderText = "ProgNo";
            this.progNoDataGridViewTextBoxColumn.Name = "progNoDataGridViewTextBoxColumn";
            // 
            // progSizeDataGridViewTextBoxColumn
            // 
            this.progSizeDataGridViewTextBoxColumn.DataPropertyName = "ProgSize";
            this.progSizeDataGridViewTextBoxColumn.HeaderText = "ProgSize";
            this.progSizeDataGridViewTextBoxColumn.Name = "progSizeDataGridViewTextBoxColumn";
            // 
            // progDateDataGridViewTextBoxColumn
            // 
            this.progDateDataGridViewTextBoxColumn.DataPropertyName = "ProgDate";
            this.progDateDataGridViewTextBoxColumn.HeaderText = "ProgDate";
            this.progDateDataGridViewTextBoxColumn.Name = "progDateDataGridViewTextBoxColumn";
            // 
            // prgDetListDataGridViewTextBoxColumn
            // 
            this.prgDetListDataGridViewTextBoxColumn.DataPropertyName = "PrgDetList";
            this.prgDetListDataGridViewTextBoxColumn.HeaderText = "PrgDetList";
            this.prgDetListDataGridViewTextBoxColumn.Name = "prgDetListDataGridViewTextBoxColumn";
            // 
            // programListDetBindingSource
            // 
            this.programListDetBindingSource.DataSource = typeof(Eureka.Core.Domain.CNC.ProgramListDet);
            // 
            // ConnectCNCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 453);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.button1);
            this.Name = "ConnectCNCForm";
            this.Text = "ConnectCNCForm";
            this.Load += new System.EventHandler(this.ConnectCNCForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programListDetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn progNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn progNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn progSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn progDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prgDetListDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource programListDetBindingSource;
        private System.Windows.Forms.Button button4;
    }
}