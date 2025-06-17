namespace Owen
{
    partial class Authorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            this.AuthGroupBox = new System.Windows.Forms.GroupBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.TextBox();
            this.Auth = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonBack = new System.Windows.Forms.ToolStripButton();
            this.AuthGroupBox.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AuthGroupBox
            // 
            this.AuthGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AuthGroupBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AuthGroupBox.Controls.Add(this.PasswordLabel);
            this.AuthGroupBox.Controls.Add(this.LoginLabel);
            this.AuthGroupBox.Controls.Add(this.Password);
            this.AuthGroupBox.Controls.Add(this.Login);
            this.AuthGroupBox.Controls.Add(this.Auth);
            this.AuthGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AuthGroupBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.AuthGroupBox.Location = new System.Drawing.Point(37, 61);
            this.AuthGroupBox.MinimumSize = new System.Drawing.Size(400, 211);
            this.AuthGroupBox.Name = "AuthGroupBox";
            this.AuthGroupBox.Size = new System.Drawing.Size(400, 211);
            this.AuthGroupBox.TabIndex = 0;
            this.AuthGroupBox.TabStop = false;
            this.AuthGroupBox.Text = "Введите логин и пароль";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(87, 103);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(67, 20);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Пароль";
            // 
            // LoginLabel
            // 
            this.LoginLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Location = new System.Drawing.Point(87, 59);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(55, 20);
            this.LoginLabel.TabIndex = 3;
            this.LoginLabel.Text = "Логин";
            // 
            // Password
            // 
            this.Password.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Password.Location = new System.Drawing.Point(171, 103);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(100, 26);
            this.Password.TabIndex = 2;
            // 
            // Login
            // 
            this.Login.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Login.Location = new System.Drawing.Point(171, 53);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(100, 26);
            this.Login.TabIndex = 1;
            // 
            // Auth
            // 
            this.Auth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Auth.Location = new System.Drawing.Point(307, 175);
            this.Auth.Name = "Auth";
            this.Auth.Size = new System.Drawing.Size(87, 30);
            this.Auth.TabIndex = 0;
            this.Auth.Text = "Войти";
            this.Auth.UseVisualStyleBackColor = true;
            this.Auth.Click += new System.EventHandler(this.Auth_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonBack});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(484, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripButtonBack
            // 
            this.ToolStripButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonBack.Image")));
            this.ToolStripButtonBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonBack.Name = "ToolStripButtonBack";
            this.ToolStripButtonBack.Size = new System.Drawing.Size(59, 22);
            this.ToolStripButtonBack.Text = "Назад";
            this.ToolStripButtonBack.Click += new System.EventHandler(this.ToolStripButtonBack_Click);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 336);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.AuthGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "Authorization";
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Authorization_Load);
            this.AuthGroupBox.ResumeLayout(false);
            this.AuthGroupBox.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox AuthGroupBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.Button Auth;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripButtonBack;
    }
}