namespace Owen
{
    partial class Import
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Import));
            this.TxtFilePath = new System.Windows.Forms.TextBox();
            this.BtnImport = new System.Windows.Forms.Button();
            this.PrgImport = new System.Windows.Forms.ProgressBar();
            this.LblStatus = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.TxtTableName = new System.Windows.Forms.TextBox();
            this.toolStripControls = new System.Windows.Forms.ToolStrip();
            this.toolStripBackButton = new System.Windows.Forms.ToolStripButton();
            this.TableNameLabel = new System.Windows.Forms.Label();
            this.toolStripControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtFilePath
            // 
            this.TxtFilePath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TxtFilePath.Location = new System.Drawing.Point(47, 69);
            this.TxtFilePath.Name = "TxtFilePath";
            this.TxtFilePath.Size = new System.Drawing.Size(400, 26);
            this.TxtFilePath.TabIndex = 0;
            // 
            // BtnImport
            // 
            this.BtnImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnImport.Location = new System.Drawing.Point(47, 179);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(120, 30);
            this.BtnImport.TabIndex = 1;
            this.BtnImport.Text = "Импорт";
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // PrgImport
            // 
            this.PrgImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PrgImport.Location = new System.Drawing.Point(68, 236);
            this.PrgImport.Name = "PrgImport";
            this.PrgImport.Size = new System.Drawing.Size(543, 23);
            this.PrgImport.TabIndex = 2;
            this.PrgImport.Visible = false;
            // 
            // LblStatus
            // 
            this.LblStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblStatus.AutoSize = true;
            this.LblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LblStatus.Location = new System.Drawing.Point(299, 271);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(63, 20);
            this.LblStatus.TabIndex = 3;
            this.LblStatus.Text = "Готово";
            this.LblStatus.Visible = false;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnBrowse.Location = new System.Drawing.Point(457, 69);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(42, 26);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFilePath.Location = new System.Drawing.Point(46, 46);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(154, 20);
            this.lblFilePath.TabIndex = 5;
            this.lblFilePath.Text = "Путь к файлу PGN:";
            // 
            // TxtTableName
            // 
            this.TxtTableName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TxtTableName.Location = new System.Drawing.Point(47, 140);
            this.TxtTableName.Name = "TxtTableName";
            this.TxtTableName.Size = new System.Drawing.Size(400, 26);
            this.TxtTableName.TabIndex = 6;
            // 
            // toolStripControls
            // 
            this.toolStripControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBackButton});
            this.toolStripControls.Location = new System.Drawing.Point(0, 0);
            this.toolStripControls.Name = "toolStripControls";
            this.toolStripControls.Size = new System.Drawing.Size(650, 27);
            this.toolStripControls.TabIndex = 28;
            this.toolStripControls.Text = "Панель элементов";
            // 
            // toolStripBackButton
            // 
            this.toolStripBackButton.Image = global::Owen.Properties.Resources.pngtree_back_arrow_backward_direction_previous_png_image_5198415;
            this.toolStripBackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBackButton.Name = "toolStripBackButton";
            this.toolStripBackButton.Size = new System.Drawing.Size(78, 24);
            this.toolStripBackButton.Text = "Назад";
            this.toolStripBackButton.ToolTipText = "Назад";
            this.toolStripBackButton.Click += new System.EventHandler(this.toolStripBackButton_Click);
            // 
            // TableNameLabel
            // 
            this.TableNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TableNameLabel.AutoSize = true;
            this.TableNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TableNameLabel.Location = new System.Drawing.Point(46, 117);
            this.TableNameLabel.Name = "TableNameLabel";
            this.TableNameLabel.Size = new System.Drawing.Size(191, 20);
            this.TableNameLabel.TabIndex = 29;
            this.TableNameLabel.Text = "Название для таблицы:";
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 300);
            this.Controls.Add(this.TableNameLabel);
            this.Controls.Add(this.toolStripControls);
            this.Controls.Add(this.TxtTableName);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.PrgImport);
            this.Controls.Add(this.BtnImport);
            this.Controls.Add(this.TxtFilePath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(666, 339);
            this.MinimumSize = new System.Drawing.Size(666, 339);
            this.Name = "Import";
            this.Text = "Импорт PGN в SQL";
            this.Load += new System.EventHandler(this.Import_Load);
            this.toolStripControls.ResumeLayout(false);
            this.toolStripControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtFilePath;
        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.ProgressBar PrgImport;
        private System.Windows.Forms.Label LblStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox TxtTableName;
        private System.Windows.Forms.ToolStrip toolStripControls;
        private System.Windows.Forms.ToolStripButton toolStripBackButton;
        private System.Windows.Forms.Label TableNameLabel;
    }
}