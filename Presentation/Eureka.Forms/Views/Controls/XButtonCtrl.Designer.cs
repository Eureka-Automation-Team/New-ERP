namespace Eureka.Forms.Views.Controls
{
    partial class XButtonCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XButtonCtrl));
            this.button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button.FlatAppearance.BorderSize = 0;
            this.button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button.ForeColor = System.Drawing.Color.Gray;
            this.button.Image = ((System.Drawing.Image)(resources.GetObject("button.Image")));
            this.button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button.Location = new System.Drawing.Point(0, 0);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(235, 34);
            this.button.TabIndex = 5;
            this.button.Tag = "";
            this.button.Text = "          XButton";
            this.button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // XButtonCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button);
            this.Name = "XButtonCtrl";
            this.Size = new System.Drawing.Size(235, 34);
            this.Load += new System.EventHandler(this.XButtonCtrl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button;
    }
}
