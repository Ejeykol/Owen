namespace Owen
{
    partial class Start
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.MainLabel = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.Auth = new System.Windows.Forms.Button();
            this.IconPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IconPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainLabel.AutoSize = true;
            this.MainLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainLabel.Location = new System.Drawing.Point(495, 265);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(224, 115);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "OWEN";
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit.Location = new System.Drawing.Point(12, 629);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(127, 40);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Auth
            // 
            this.Auth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Auth.AutoSize = true;
            this.Auth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Auth.Location = new System.Drawing.Point(1125, 629);
            this.Auth.Name = "Auth";
            this.Auth.Size = new System.Drawing.Size(127, 40);
            this.Auth.TabIndex = 2;
            this.Auth.Text = "Вход";
            this.Auth.UseVisualStyleBackColor = true;
            this.Auth.Click += new System.EventHandler(this.Enter_Click);
            // 
            // IconPicture
            // 
            this.IconPicture.Image = ((System.Drawing.Image)(resources.GetObject("IconPicture.Image")));
            this.IconPicture.InitialImage = ((System.Drawing.Image)(resources.GetObject("IconPicture.InitialImage")));
            this.IconPicture.Location = new System.Drawing.Point(880, 96);
            this.IconPicture.Name = "IconPicture";
            this.IconPicture.Size = new System.Drawing.Size(372, 455);
            this.IconPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconPicture.TabIndex = 4;
            this.IconPicture.TabStop = false;
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.IconPicture);
            this.Controls.Add(this.Auth);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.MainLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Start";
            this.Text = "Owen";
            this.Load += new System.EventHandler(this.Start_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IconPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Auth;
        private System.Windows.Forms.PictureBox IconPicture;
    }
}

