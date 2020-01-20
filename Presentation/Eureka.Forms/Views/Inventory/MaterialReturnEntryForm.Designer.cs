namespace Eureka.Froms.Views.Inventory
{
    partial class MaterialReturnEntryForm
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.txtReturnNumber = new MetroFramework.Controls.MetroTextBox();
            this.dtpTransactionDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroButton2);
            this.metroPanel1.Controls.Add(this.metroButton1);
            this.metroPanel1.Controls.Add(this.dtpTransactionDate);
            this.metroPanel1.Controls.Add(this.metroLabel12);
            this.metroPanel1.Controls.Add(this.metroLabel10);
            this.metroPanel1.Controls.Add(this.txtReturnNumber);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(329, 121);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel10.Location = new System.Drawing.Point(8, 14);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(107, 19);
            this.metroLabel10.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel10.TabIndex = 59;
            this.metroLabel10.Text = "Return Number:";
            this.metroLabel10.UseStyleColors = true;
            // 
            // txtReturnNumber
            // 
            // 
            // 
            // 
            this.txtReturnNumber.CustomButton.Image = null;
            this.txtReturnNumber.CustomButton.Location = new System.Drawing.Point(173, 1);
            this.txtReturnNumber.CustomButton.Name = "";
            this.txtReturnNumber.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtReturnNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtReturnNumber.CustomButton.TabIndex = 1;
            this.txtReturnNumber.CustomButton.Text = "...";
            this.txtReturnNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtReturnNumber.CustomButton.UseSelectable = true;
            this.txtReturnNumber.CustomButton.Visible = false;
            this.txtReturnNumber.Lines = new string[0];
            this.txtReturnNumber.Location = new System.Drawing.Point(121, 14);
            this.txtReturnNumber.MaxLength = 32767;
            this.txtReturnNumber.Name = "txtReturnNumber";
            this.txtReturnNumber.PasswordChar = '\0';
            this.txtReturnNumber.ReadOnly = true;
            this.txtReturnNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtReturnNumber.SelectedText = "";
            this.txtReturnNumber.SelectionLength = 0;
            this.txtReturnNumber.SelectionStart = 0;
            this.txtReturnNumber.ShortcutsEnabled = true;
            this.txtReturnNumber.ShowClearButton = true;
            this.txtReturnNumber.Size = new System.Drawing.Size(197, 25);
            this.txtReturnNumber.Style = MetroFramework.MetroColorStyle.Green;
            this.txtReturnNumber.TabIndex = 58;
            this.txtReturnNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReturnNumber.UseSelectable = true;
            this.txtReturnNumber.UseStyleColors = true;
            this.txtReturnNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtReturnNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpTransactionDate.DisplayFocus = true;
            this.dtpTransactionDate.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtpTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransactionDate.Location = new System.Drawing.Point(121, 45);
            this.dtpTransactionDate.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(197, 25);
            this.dtpTransactionDate.Style = MetroFramework.MetroColorStyle.Green;
            this.dtpTransactionDate.TabIndex = 62;
            this.dtpTransactionDate.UseStyleColors = true;
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel12.Location = new System.Drawing.Point(1, 45);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(114, 19);
            this.metroLabel12.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel12.TabIndex = 61;
            this.metroLabel12.Text = "Transaction Date:";
            this.metroLabel12.UseStyleColors = true;
            // 
            // metroButton1
            // 
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton1.Location = new System.Drawing.Point(121, 76);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(90, 33);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroButton1.TabIndex = 63;
            this.metroButton1.Text = "&OK";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton2.Location = new System.Drawing.Point(228, 76);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(90, 33);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Green;
            this.metroButton2.TabIndex = 64;
            this.metroButton2.Text = "&Cancel";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.UseStyleColors = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // MaterialReturnEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 201);
            this.Controls.Add(this.metroPanel1);
            this.Name = "MaterialReturnEntryForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Material Return Entry";
            this.Load += new System.EventHandler(this.MaterialReturnEntryForm_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox txtReturnNumber;
        private MetroFramework.Controls.MetroDateTime dtpTransactionDate;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}