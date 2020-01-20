namespace Eureka.Froms.Views.Controls
{
    partial class CalendaForm
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
            this.dtpMonth = new System.Windows.Forms.MonthCalendar();
            this.txtDateSelected = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // dtpMonth
            // 
            this.dtpMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpMonth.Location = new System.Drawing.Point(10, 60);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.TabIndex = 0;
            this.dtpMonth.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.dtpMonth_DateChanged);
            // 
            // txtDateSelected
            // 
            // 
            // 
            // 
            this.txtDateSelected.CustomButton.Image = null;
            this.txtDateSelected.CustomButton.Location = new System.Drawing.Point(124, 1);
            this.txtDateSelected.CustomButton.Name = "";
            this.txtDateSelected.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtDateSelected.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDateSelected.CustomButton.TabIndex = 1;
            this.txtDateSelected.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDateSelected.CustomButton.UseSelectable = true;
            this.txtDateSelected.CustomButton.Visible = false;
            this.txtDateSelected.Lines = new string[0];
            this.txtDateSelected.Location = new System.Drawing.Point(10, 224);
            this.txtDateSelected.MaxLength = 32767;
            this.txtDateSelected.Name = "txtDateSelected";
            this.txtDateSelected.PasswordChar = '\0';
            this.txtDateSelected.ReadOnly = true;
            this.txtDateSelected.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDateSelected.SelectedText = "";
            this.txtDateSelected.SelectionLength = 0;
            this.txtDateSelected.SelectionStart = 0;
            this.txtDateSelected.ShortcutsEnabled = true;
            this.txtDateSelected.Size = new System.Drawing.Size(146, 23);
            this.txtDateSelected.Style = MetroFramework.MetroColorStyle.Green;
            this.txtDateSelected.TabIndex = 1;
            this.txtDateSelected.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDateSelected.UseSelectable = true;
            this.txtDateSelected.UseStyleColors = true;
            this.txtDateSelected.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDateSelected.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(162, 224);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "OK";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // CalendaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 251);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.txtDateSelected);
            this.Controls.Add(this.dtpMonth);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalendaForm";
            this.Padding = new System.Windows.Forms.Padding(10, 60, 10, 10);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Calendar";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CalendaForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar dtpMonth;
        private MetroFramework.Controls.MetroTextBox txtDateSelected;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}