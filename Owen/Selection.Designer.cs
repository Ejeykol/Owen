namespace Owen
{
    partial class Selection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Selection));
            this.AddNew = new System.Windows.Forms.Button();
            this.Converter = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonBack = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddNew
            // 
            this.AddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddNew.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddNew.Location = new System.Drawing.Point(203, 160);
            this.AddNew.Name = "AddNew";
            this.AddNew.Size = new System.Drawing.Size(362, 50);
            this.AddNew.TabIndex = 3;
            this.AddNew.Text = "Добавление PGN в базу";
            this.AddNew.UseVisualStyleBackColor = false;
            this.AddNew.Click += new System.EventHandler(this.AddNew_Click);
            // 
            // Converter
            // 
            this.Converter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Converter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Converter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Converter.Location = new System.Drawing.Point(203, 216);
            this.Converter.Name = "Converter";
            this.Converter.Size = new System.Drawing.Size(362, 50);
            this.Converter.TabIndex = 8;
            this.Converter.Text = "Переводчик";
            this.Converter.UseVisualStyleBackColor = false;
            this.Converter.Click += new System.EventHandler(this.Converter_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonBack});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 9;
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
            // Selection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Converter);
            this.Controls.Add(this.AddNew);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(421, 230);
            this.Name = "Selection";
            this.Text = "Форма администратора";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddNew;
        private System.Windows.Forms.Button Converter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripButtonBack;
    }
}