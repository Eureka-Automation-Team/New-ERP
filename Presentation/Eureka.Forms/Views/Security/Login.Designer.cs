namespace Eureka.Froms.Views
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtUsername = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.butLogin = new MetroFramework.Controls.MetroButton();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(51, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // txtUsername
            // 
            // 
            // 
            // 
            this.txtUsername.CustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txtUsername.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.txtUsername.CustomButton.Location = new System.Drawing.Point(280, 2);
            this.txtUsername.CustomButton.Name = "";
            this.txtUsername.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtUsername.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUsername.CustomButton.TabIndex = 1;
            this.txtUsername.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUsername.CustomButton.UseSelectable = true;
            this.txtUsername.CustomButton.Visible = false;
            this.txtUsername.DisplayIcon = true;
            this.txtUsername.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtUsername.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtUsername.Lines = new string[0];
            this.txtUsername.Location = new System.Drawing.Point(11, 116);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            //this.txtUsername.PromptText = "Enter your username";
            this.txtUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.ShortcutsEnabled = true;
            this.txtUsername.ShowClearButton = true;
            this.txtUsername.Size = new System.Drawing.Size(306, 28);
            this.txtUsername.Style = MetroFramework.MetroColorStyle.Green;
            this.txtUsername.TabIndex = 8;
            this.txtUsername.UseSelectable = true;
            this.txtUsername.UseStyleColors = true;
            this.txtUsername.WaterMark = "Enter your username";
            this.txtUsername.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUsername.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(11, 94);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(76, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel1.TabIndex = 13;
            this.metroLabel1.Text = "Username";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel1.UseStyleColors = true;
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txtPassword.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(280, 2);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.DisplayIcon = true;
            this.txtPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPassword.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(11, 173);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            //this.txtPassword.PromptText = "Enter your password";
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.ShowClearButton = true;
            this.txtPassword.Size = new System.Drawing.Size(306, 28);
            this.txtPassword.Style = MetroFramework.MetroColorStyle.Green;
            this.txtPassword.TabIndex = 14;
            this.txtPassword.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.UseStyleColors = true;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WaterMark = "Enter your password";
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(11, 151);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(73, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel2.TabIndex = 15;
            this.metroLabel2.Text = "Password";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel2.UseStyleColors = true;
            // 
            // butLogin
            // 
            this.butLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butLogin.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.butLogin.Location = new System.Drawing.Point(11, 209);
            this.butLogin.Name = "butLogin";
            this.butLogin.Size = new System.Drawing.Size(81, 35);
            this.butLogin.Style = MetroFramework.MetroColorStyle.Green;
            this.butLogin.TabIndex = 16;
            this.butLogin.Text = "Login";
            this.butLogin.UseSelectable = true;
            this.butLogin.UseStyleColors = true;
            this.butLogin.Click += new System.EventHandler(this.butLogin_Click);
            // 
            // metroLink1
            // 
            this.metroLink1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroLink1.Location = new System.Drawing.Point(174, 209);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(143, 23);
            this.metroLink1.TabIndex = 17;
            this.metroLink1.Text = "Forgotten password?";
            this.metroLink1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLink1.UseSelectable = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 258);
            this.Controls.Add(this.metroLink1);
            this.Controls.Add(this.butLogin);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtUsername);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Login";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox txtUsername;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton butLogin;
        private MetroFramework.Controls.MetroLink metroLink1;
    }
}