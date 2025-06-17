namespace Owen
{
    partial class TableViewLite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableViewLite));
            this.panelControls = new System.Windows.Forms.Panel();
            this.comboBoxRelatedTables = new System.Windows.Forms.ComboBox();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.splitContainerView = new System.Windows.Forms.SplitContainer();
            this.dataGridViewRelated = new System.Windows.Forms.DataGridView();
            this.toolStripControls = new System.Windows.Forms.ToolStrip();
            this.toolStripBackButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddNew = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.comboBoxTables = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabelTable = new System.Windows.Forms.ToolStripLabel();
            this.panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerView)).BeginInit();
            this.splitContainerView.Panel1.SuspendLayout();
            this.splitContainerView.Panel2.SuspendLayout();
            this.splitContainerView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelated)).BeginInit();
            this.toolStripControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.panel1);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControls.Location = new System.Drawing.Point(0, 621);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(1264, 60);
            this.panelControls.TabIndex = 0;
            this.panelControls.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControls_Paint);
            // 
            // comboBoxRelatedTables
            // 
            this.comboBoxRelatedTables.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboBoxRelatedTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxRelatedTables.FormattingEnabled = true;
            this.comboBoxRelatedTables.Location = new System.Drawing.Point(0, 566);
            this.comboBoxRelatedTables.Name = "comboBoxRelatedTables";
            this.comboBoxRelatedTables.Size = new System.Drawing.Size(212, 28);
            this.comboBoxRelatedTables.TabIndex = 5;
            this.comboBoxRelatedTables.SelectedIndexChanged += new System.EventHandler(this.comboBoxRelatedTables_SelectedIndexChanged);
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMain.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.Size = new System.Drawing.Size(1048, 594);
            this.dataGridViewMain.TabIndex = 1;
            this.dataGridViewMain.Click += new System.EventHandler(this.dataGridViewMain_Click);
            // 
            // splitContainerView
            // 
            this.splitContainerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerView.Location = new System.Drawing.Point(0, 27);
            this.splitContainerView.Name = "splitContainerView";
            // 
            // splitContainerView.Panel1
            // 
            this.splitContainerView.Panel1.Controls.Add(this.dataGridViewMain);
            // 
            // splitContainerView.Panel2
            // 
            this.splitContainerView.Panel2.Controls.Add(this.comboBoxRelatedTables);
            this.splitContainerView.Panel2.Controls.Add(this.dataGridViewRelated);
            this.splitContainerView.Size = new System.Drawing.Size(1264, 594);
            this.splitContainerView.SplitterDistance = 1048;
            this.splitContainerView.TabIndex = 2;
            this.splitContainerView.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainerView_SplitterMoved);
            // 
            // dataGridViewRelated
            // 
            this.dataGridViewRelated.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRelated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRelated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRelated.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRelated.Name = "dataGridViewRelated";
            this.dataGridViewRelated.Size = new System.Drawing.Size(212, 594);
            this.dataGridViewRelated.TabIndex = 2;
            this.dataGridViewRelated.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRelated_CellContentClick);
            // 
            // toolStripControls
            // 
            this.toolStripControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBackButton,
            this.toolStripDropDownButton,
            this.btnAddNew,
            this.btnSave,
            this.btnDelete,
            this.comboBoxTables,
            this.toolStripLabelTable});
            this.toolStripControls.Location = new System.Drawing.Point(0, 0);
            this.toolStripControls.Name = "toolStripControls";
            this.toolStripControls.Size = new System.Drawing.Size(1264, 27);
            this.toolStripControls.TabIndex = 28;
            this.toolStripControls.Text = "Панель элементов";
            this.toolStripControls.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripControls_ItemClicked);
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
            // toolStripDropDownButton
            // 
            this.toolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripDropDownButton.Image = global::Owen.Properties.Resources.png_transparent_gear_icon_outline;
            this.toolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton.Name = "toolStripDropDownButton";
            this.toolStripDropDownButton.Size = new System.Drawing.Size(29, 24);
            this.toolStripDropDownButton.Text = "Настройки формы";
            this.toolStripDropDownButton.ToolTipText = "toolStripHideButton";
            this.toolStripDropDownButton.Click += new System.EventHandler(this.toolStripDropDownButton_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(260, 24);
            this.toolStripMenuItem1.Text = "Скрыть левую таблицу";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.GameInfoHideShow_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(260, 24);
            this.toolStripMenuItem2.Text = "Скрыть правую таблицу";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.скрытьДоскуToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(260, 24);
            this.toolStripMenuItem3.Text = "Скрыть нижнюю панель";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.скрытьХодыToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 51);
            this.panel1.TabIndex = 5;
            // 
            // btnAddNew
            // 
            this.btnAddNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(88, 24);
            this.btnAddNew.Text = "Добавить";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 24);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 24);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(121, 27);
            this.comboBoxTables.SelectedIndexChanged += new System.EventHandler(this.comboBoxTables_SelectedIndexChanged);
            // 
            // toolStripLabelTable
            // 
            this.toolStripLabelTable.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelTable.Name = "toolStripLabelTable";
            this.toolStripLabelTable.Size = new System.Drawing.Size(155, 24);
            this.toolStripLabelTable.Text = "Выберите таблицу:";
            // 
            // TableViewLite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.splitContainerView);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.toolStripControls);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TableViewLite";
            this.Text = "Просмотр таблиц";
            this.Load += new System.EventHandler(this.TableViewLite_Load);
            this.panelControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.splitContainerView.Panel1.ResumeLayout(false);
            this.splitContainerView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerView)).EndInit();
            this.splitContainerView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelated)).EndInit();
            this.toolStripControls.ResumeLayout(false);
            this.toolStripControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.SplitContainer splitContainerView;
        private System.Windows.Forms.DataGridView dataGridViewRelated;
        private System.Windows.Forms.ToolStrip toolStripControls;
        private System.Windows.Forms.ToolStripButton toolStripBackButton;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ComboBox comboBoxRelatedTables;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton btnAddNew;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripComboBox comboBoxTables;
        private System.Windows.Forms.ToolStripLabel toolStripLabelTable;
    }
}