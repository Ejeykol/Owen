namespace Owen
{
    partial class TableDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableDataForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.LabelText = new System.Windows.Forms.Label();
            this.LabelColumn = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.comboBoxColumns = new System.Windows.Forms.ComboBox();
            this.SanSelect = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.ControlsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(800, 364);
            this.dataGridView.TabIndex = 0;
            // 
            // ControlsGroupBox
            // 
            this.ControlsGroupBox.Controls.Add(this.LabelText);
            this.ControlsGroupBox.Controls.Add(this.LabelColumn);
            this.ControlsGroupBox.Controls.Add(this.btnReset);
            this.ControlsGroupBox.Controls.Add(this.btnSearch);
            this.ControlsGroupBox.Controls.Add(this.textBoxSearch);
            this.ControlsGroupBox.Controls.Add(this.comboBoxColumns);
            this.ControlsGroupBox.Controls.Add(this.SanSelect);
            this.ControlsGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ControlsGroupBox.Location = new System.Drawing.Point(0, 364);
            this.ControlsGroupBox.Name = "ControlsGroupBox";
            this.ControlsGroupBox.Size = new System.Drawing.Size(800, 86);
            this.ControlsGroupBox.TabIndex = 1;
            this.ControlsGroupBox.TabStop = false;
            // 
            // LabelText
            // 
            this.LabelText.AutoSize = true;
            this.LabelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelText.Location = new System.Drawing.Point(31, 47);
            this.LabelText.Name = "LabelText";
            this.LabelText.Size = new System.Drawing.Size(67, 24);
            this.LabelText.TabIndex = 6;
            this.LabelText.Text = "Текст:";
            // 
            // LabelColumn
            // 
            this.LabelColumn.AutoSize = true;
            this.LabelColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelColumn.Location = new System.Drawing.Point(6, 12);
            this.LabelColumn.Name = "LabelColumn";
            this.LabelColumn.Size = new System.Drawing.Size(92, 24);
            this.LabelColumn.TabIndex = 5;
            this.LabelColumn.Text = "Столбец:";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReset.Location = new System.Drawing.Point(253, 46);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(108, 33);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Очистить";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearch.Location = new System.Drawing.Point(253, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(108, 32);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSearch.Location = new System.Drawing.Point(104, 47);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(121, 29);
            this.textBoxSearch.TabIndex = 2;
            // 
            // comboBoxColumns
            // 
            this.comboBoxColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxColumns.FormattingEnabled = true;
            this.comboBoxColumns.Items.AddRange(new object[] {
            "Нажимите для выбора таблицы"});
            this.comboBoxColumns.Location = new System.Drawing.Point(104, 9);
            this.comboBoxColumns.Name = "comboBoxColumns";
            this.comboBoxColumns.Size = new System.Drawing.Size(121, 32);
            this.comboBoxColumns.TabIndex = 1;
            // 
            // SanSelect
            // 
            this.SanSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SanSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.SanSelect.Location = new System.Drawing.Point(666, 6);
            this.SanSelect.Name = "SanSelect";
            this.SanSelect.Size = new System.Drawing.Size(128, 80);
            this.SanSelect.TabIndex = 0;
            this.SanSelect.Text = "Загрузить SAN";
            this.SanSelect.UseVisualStyleBackColor = true;
            this.SanSelect.Click += new System.EventHandler(this.SanSelect_Click);
            // 
            // TableDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.ControlsGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TableDataForm";
            this.Text = "Таблица из базы";
            this.Load += new System.EventHandler(this.TableDataForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ControlsGroupBox.ResumeLayout(false);
            this.ControlsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox ControlsGroupBox;
        private System.Windows.Forms.Button SanSelect;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox comboBoxColumns;
        private System.Windows.Forms.Label LabelText;
        private System.Windows.Forms.Label LabelColumn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}