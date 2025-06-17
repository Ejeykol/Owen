namespace Owen
{
    partial class Converter
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Converter));
            this.dgvMoves = new System.Windows.Forms.DataGridView();
            this.MoveNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.White = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Black = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.MovesGroupBox = new System.Windows.Forms.GroupBox();
            this.MoveBtnsPanel = new System.Windows.Forms.Panel();
            this.BtnMoveFirst = new System.Windows.Forms.Button();
            this.BtnMoveLast = new System.Windows.Forms.Button();
            this.toolStripControls = new System.Windows.Forms.ToolStrip();
            this.toolStripBackButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ChessSplitter = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.MainInfoPanel = new System.Windows.Forms.Panel();
            this.ResultLbl = new System.Windows.Forms.Label();
            this.WhiteLbl = new System.Windows.Forms.Label();
            this.BlackLbl = new System.Windows.Forms.Label();
            this.InfoLabelsPanel = new System.Windows.Forms.Panel();
            this.EventLbl = new System.Windows.Forms.Label();
            this.DateLbl = new System.Windows.Forms.Label();
            this.RoundLbl = new System.Windows.Forms.Label();
            this.ECOLbl = new System.Windows.Forms.Label();
            this.BlackEloLbl = new System.Windows.Forms.Label();
            this.WhiteEloLbl = new System.Windows.Forms.Label();
            this.SiteLbl = new System.Windows.Forms.Label();
            this.txtGame = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ImportPanel = new System.Windows.Forms.Panel();
            this.ImportLbl = new System.Windows.Forms.Label();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.PreviewPanel = new System.Windows.Forms.Panel();
            this.rtbPreview = new System.Windows.Forms.RichTextBox();
            this.PreviewLabel = new System.Windows.Forms.Label();
            this.MovePreviewLabel = new System.Windows.Forms.Label();
            this.txtMovesPreview = new System.Windows.Forms.TextBox();
            this.CommentsReportPanel = new System.Windows.Forms.Panel();
            this.CommentLbl = new System.Windows.Forms.Label();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.MovesReportPanel = new System.Windows.Forms.Panel();
            this.checkBoxIncludeImages = new System.Windows.Forms.CheckBox();
            this.WhiteMoveCheckBox = new System.Windows.Forms.CheckBox();
            this.BlackMoveCheckBox = new System.Windows.Forms.CheckBox();
            this.NudToMove = new System.Windows.Forms.NumericUpDown();
            this.NudFromMove = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ReportsBtnsPanel = new System.Windows.Forms.Panel();
            this.AddToReport = new System.Windows.Forms.Button();
            this.Report = new System.Windows.Forms.Button();
            this.BoardControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.chessboard = new ChessboardControl.Chessboard();
            this.ToolStripButtonBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.скрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьДоскуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьХодыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoves)).BeginInit();
            this.MovesGroupBox.SuspendLayout();
            this.MoveBtnsPanel.SuspendLayout();
            this.toolStripControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChessSplitter)).BeginInit();
            this.ChessSplitter.Panel1.SuspendLayout();
            this.ChessSplitter.Panel2.SuspendLayout();
            this.ChessSplitter.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.MainInfoPanel.SuspendLayout();
            this.InfoLabelsPanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.ImportPanel.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.PreviewPanel.SuspendLayout();
            this.CommentsReportPanel.SuspendLayout();
            this.MovesReportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudToMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFromMove)).BeginInit();
            this.ReportsBtnsPanel.SuspendLayout();
            this.BoardControlsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMoves
            // 
            this.dgvMoves.AllowUserToAddRows = false;
            this.dgvMoves.AllowUserToDeleteRows = false;
            this.dgvMoves.AllowUserToResizeColumns = false;
            this.dgvMoves.AllowUserToResizeRows = false;
            this.dgvMoves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMoves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMoves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMoves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MoveNum,
            this.White,
            this.Black});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMoves.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMoves.Location = new System.Drawing.Point(3, 16);
            this.dgvMoves.Name = "dgvMoves";
            this.dgvMoves.ReadOnly = true;
            this.dgvMoves.RowHeadersVisible = false;
            this.dgvMoves.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMoves.Size = new System.Drawing.Size(234, 596);
            this.dgvMoves.TabIndex = 3;
            this.dgvMoves.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMoves_CellClick);
            // 
            // MoveNum
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MoveNum.DefaultCellStyle = dataGridViewCellStyle2;
            this.MoveNum.FillWeight = 38.07107F;
            this.MoveNum.HeaderText = "";
            this.MoveNum.Name = "MoveNum";
            this.MoveNum.ReadOnly = true;
            // 
            // White
            // 
            this.White.FillWeight = 130.9645F;
            this.White.HeaderText = "Белые";
            this.White.Name = "White";
            this.White.ReadOnly = true;
            // 
            // Black
            // 
            this.Black.FillWeight = 130.9645F;
            this.Black.HeaderText = "Черные";
            this.Black.Name = "Black";
            this.Black.ReadOnly = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrev.Location = new System.Drawing.Point(54, 0);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(54, 37);
            this.btnPrev.TabIndex = 6;
            this.btnPrev.Text = "←";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNext.Location = new System.Drawing.Point(126, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(53, 37);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "→";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // MovesGroupBox
            // 
            this.MovesGroupBox.Controls.Add(this.dgvMoves);
            this.MovesGroupBox.Controls.Add(this.MoveBtnsPanel);
            this.MovesGroupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.MovesGroupBox.Location = new System.Drawing.Point(1024, 27);
            this.MovesGroupBox.Name = "MovesGroupBox";
            this.MovesGroupBox.Size = new System.Drawing.Size(240, 654);
            this.MovesGroupBox.TabIndex = 24;
            this.MovesGroupBox.TabStop = false;
            // 
            // MoveBtnsPanel
            // 
            this.MoveBtnsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MoveBtnsPanel.Controls.Add(this.btnNext);
            this.MoveBtnsPanel.Controls.Add(this.btnPrev);
            this.MoveBtnsPanel.Controls.Add(this.BtnMoveFirst);
            this.MoveBtnsPanel.Controls.Add(this.BtnMoveLast);
            this.MoveBtnsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MoveBtnsPanel.Location = new System.Drawing.Point(3, 612);
            this.MoveBtnsPanel.Name = "MoveBtnsPanel";
            this.MoveBtnsPanel.Size = new System.Drawing.Size(234, 39);
            this.MoveBtnsPanel.TabIndex = 24;
            // 
            // BtnMoveFirst
            // 
            this.BtnMoveFirst.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnMoveFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnMoveFirst.Location = new System.Drawing.Point(0, 0);
            this.BtnMoveFirst.Name = "BtnMoveFirst";
            this.BtnMoveFirst.Size = new System.Drawing.Size(54, 37);
            this.BtnMoveFirst.TabIndex = 25;
            this.BtnMoveFirst.Text = "⋘ ";
            this.BtnMoveFirst.UseVisualStyleBackColor = true;
            this.BtnMoveFirst.Click += new System.EventHandler(this.BtnMoveFirst_Click);
            // 
            // BtnMoveLast
            // 
            this.BtnMoveLast.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnMoveLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnMoveLast.Location = new System.Drawing.Point(179, 0);
            this.BtnMoveLast.Name = "BtnMoveLast";
            this.BtnMoveLast.Size = new System.Drawing.Size(53, 37);
            this.BtnMoveLast.TabIndex = 25;
            this.BtnMoveLast.Text = "⋙";
            this.BtnMoveLast.UseVisualStyleBackColor = true;
            this.BtnMoveLast.Click += new System.EventHandler(this.BtnMoveLast_Click);
            // 
            // toolStripControls
            // 
            this.toolStripControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBackButton,
            this.toolStripDropDownButton2});
            this.toolStripControls.Location = new System.Drawing.Point(0, 0);
            this.toolStripControls.Name = "toolStripControls";
            this.toolStripControls.Size = new System.Drawing.Size(1264, 27);
            this.toolStripControls.TabIndex = 27;
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
            this.toolStripBackButton.Click += new System.EventHandler(this.Back_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripDropDownButton2.Image = global::Owen.Properties.Resources.png_transparent_gear_icon_outline;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(29, 24);
            this.toolStripDropDownButton2.Text = "Настройки формы";
            this.toolStripDropDownButton2.ToolTipText = "toolStripHideButton";
            this.toolStripDropDownButton2.Click += new System.EventHandler(this.toolStripDropDownButton2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(216, 24);
            this.toolStripMenuItem1.Text = "Скрыть элементы";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.GameInfoHideShow_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(216, 24);
            this.toolStripMenuItem2.Text = "Скрыть доску";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.скрытьДоскуToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(216, 24);
            this.toolStripMenuItem3.Text = "Скрыть ходы";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.скрытьХодыToolStripMenuItem_Click);
            // 
            // ChessSplitter
            // 
            this.ChessSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChessSplitter.Location = new System.Drawing.Point(0, 27);
            this.ChessSplitter.Name = "ChessSplitter";
            // 
            // ChessSplitter.Panel1
            // 
            this.ChessSplitter.Panel1.Controls.Add(this.tabControl1);
            // 
            // ChessSplitter.Panel2
            // 
            this.ChessSplitter.Panel2.Controls.Add(this.BoardControlsGroupBox);
            this.ChessSplitter.Size = new System.Drawing.Size(1024, 654);
            this.ChessSplitter.SplitterDistance = 264;
            this.ChessSplitter.TabIndex = 22;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(264, 654);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.MainInfoPanel);
            this.tabPage1.Controls.Add(this.InfoLabelsPanel);
            this.tabPage1.Controls.Add(this.txtGame);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(256, 621);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Информация";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MainInfoPanel
            // 
            this.MainInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainInfoPanel.Controls.Add(this.ResultLbl);
            this.MainInfoPanel.Controls.Add(this.WhiteLbl);
            this.MainInfoPanel.Controls.Add(this.BlackLbl);
            this.MainInfoPanel.Location = new System.Drawing.Point(0, 238);
            this.MainInfoPanel.Name = "MainInfoPanel";
            this.MainInfoPanel.Size = new System.Drawing.Size(254, 79);
            this.MainInfoPanel.TabIndex = 25;
            // 
            // ResultLbl
            // 
            this.ResultLbl.AutoSize = true;
            this.ResultLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultLbl.Location = new System.Drawing.Point(0, 48);
            this.ResultLbl.Name = "ResultLbl";
            this.ResultLbl.Size = new System.Drawing.Size(93, 20);
            this.ResultLbl.TabIndex = 20;
            this.ResultLbl.Text = "Результат:";
            // 
            // WhiteLbl
            // 
            this.WhiteLbl.AutoSize = true;
            this.WhiteLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WhiteLbl.Location = new System.Drawing.Point(0, 8);
            this.WhiteLbl.Name = "WhiteLbl";
            this.WhiteLbl.Size = new System.Drawing.Size(63, 20);
            this.WhiteLbl.TabIndex = 18;
            this.WhiteLbl.Text = "Белый:";
            // 
            // BlackLbl
            // 
            this.BlackLbl.AutoSize = true;
            this.BlackLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BlackLbl.Location = new System.Drawing.Point(0, 28);
            this.BlackLbl.Name = "BlackLbl";
            this.BlackLbl.Size = new System.Drawing.Size(72, 20);
            this.BlackLbl.TabIndex = 19;
            this.BlackLbl.Text = "Черный:";
            // 
            // InfoLabelsPanel
            // 
            this.InfoLabelsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InfoLabelsPanel.Controls.Add(this.EventLbl);
            this.InfoLabelsPanel.Controls.Add(this.DateLbl);
            this.InfoLabelsPanel.Controls.Add(this.RoundLbl);
            this.InfoLabelsPanel.Controls.Add(this.ECOLbl);
            this.InfoLabelsPanel.Controls.Add(this.BlackEloLbl);
            this.InfoLabelsPanel.Controls.Add(this.WhiteEloLbl);
            this.InfoLabelsPanel.Controls.Add(this.SiteLbl);
            this.InfoLabelsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InfoLabelsPanel.Location = new System.Drawing.Point(3, 3);
            this.InfoLabelsPanel.Name = "InfoLabelsPanel";
            this.InfoLabelsPanel.Size = new System.Drawing.Size(250, 149);
            this.InfoLabelsPanel.TabIndex = 24;
            // 
            // EventLbl
            // 
            this.EventLbl.AutoEllipsis = true;
            this.EventLbl.AutoSize = true;
            this.EventLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.EventLbl.Location = new System.Drawing.Point(0, 120);
            this.EventLbl.Name = "EventLbl";
            this.EventLbl.Size = new System.Drawing.Size(116, 20);
            this.EventLbl.TabIndex = 14;
            this.EventLbl.Text = "Мероприятие:";
            // 
            // DateLbl
            // 
            this.DateLbl.AutoEllipsis = true;
            this.DateLbl.AutoSize = true;
            this.DateLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.DateLbl.Location = new System.Drawing.Point(0, 100);
            this.DateLbl.Name = "DateLbl";
            this.DateLbl.Size = new System.Drawing.Size(52, 20);
            this.DateLbl.TabIndex = 17;
            this.DateLbl.Text = "Дата:";
            // 
            // RoundLbl
            // 
            this.RoundLbl.AutoEllipsis = true;
            this.RoundLbl.AutoSize = true;
            this.RoundLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.RoundLbl.Location = new System.Drawing.Point(0, 80);
            this.RoundLbl.Name = "RoundLbl";
            this.RoundLbl.Size = new System.Drawing.Size(59, 20);
            this.RoundLbl.TabIndex = 16;
            this.RoundLbl.Text = "Раунд:";
            // 
            // ECOLbl
            // 
            this.ECOLbl.AutoEllipsis = true;
            this.ECOLbl.AutoSize = true;
            this.ECOLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.ECOLbl.Location = new System.Drawing.Point(0, 60);
            this.ECOLbl.Name = "ECOLbl";
            this.ECOLbl.Size = new System.Drawing.Size(81, 20);
            this.ECOLbl.TabIndex = 23;
            this.ECOLbl.Text = "Код ECO:";
            // 
            // BlackEloLbl
            // 
            this.BlackEloLbl.AutoEllipsis = true;
            this.BlackEloLbl.AutoSize = true;
            this.BlackEloLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.BlackEloLbl.Location = new System.Drawing.Point(0, 40);
            this.BlackEloLbl.Name = "BlackEloLbl";
            this.BlackEloLbl.Size = new System.Drawing.Size(102, 20);
            this.BlackEloLbl.TabIndex = 22;
            this.BlackEloLbl.Text = "Эло черных:";
            // 
            // WhiteEloLbl
            // 
            this.WhiteEloLbl.AutoSize = true;
            this.WhiteEloLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.WhiteEloLbl.Location = new System.Drawing.Point(0, 20);
            this.WhiteEloLbl.Name = "WhiteEloLbl";
            this.WhiteEloLbl.Size = new System.Drawing.Size(94, 20);
            this.WhiteEloLbl.TabIndex = 21;
            this.WhiteEloLbl.Text = "Эло белых:";
            // 
            // SiteLbl
            // 
            this.SiteLbl.AutoEllipsis = true;
            this.SiteLbl.AutoSize = true;
            this.SiteLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.SiteLbl.Location = new System.Drawing.Point(0, 0);
            this.SiteLbl.Name = "SiteLbl";
            this.SiteLbl.Size = new System.Drawing.Size(61, 20);
            this.SiteLbl.TabIndex = 15;
            this.SiteLbl.Text = "Место:";
            // 
            // txtGame
            // 
            this.txtGame.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtGame.Location = new System.Drawing.Point(29, 614);
            this.txtGame.Multiline = true;
            this.txtGame.Name = "txtGame";
            this.txtGame.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGame.Size = new System.Drawing.Size(74, 16);
            this.txtGame.TabIndex = 4;
            this.txtGame.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ImportPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(256, 621);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Импорт";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ImportPanel
            // 
            this.ImportPanel.AutoScroll = true;
            this.ImportPanel.AutoSize = true;
            this.ImportPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImportPanel.Controls.Add(this.ImportLbl);
            this.ImportPanel.Controls.Add(this.comboBoxTables);
            this.ImportPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ImportPanel.Location = new System.Drawing.Point(3, 568);
            this.ImportPanel.Name = "ImportPanel";
            this.ImportPanel.Size = new System.Drawing.Size(250, 50);
            this.ImportPanel.TabIndex = 27;
            // 
            // ImportLbl
            // 
            this.ImportLbl.AutoSize = true;
            this.ImportLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ImportLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImportLbl.Location = new System.Drawing.Point(0, 0);
            this.ImportLbl.Name = "ImportLbl";
            this.ImportLbl.Size = new System.Drawing.Size(162, 20);
            this.ImportLbl.TabIndex = 26;
            this.ImportLbl.Text = "Импорт из таблицы:";
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboBoxTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Location = new System.Drawing.Point(0, 20);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(248, 28);
            this.comboBoxTables.TabIndex = 12;
            this.comboBoxTables.SelectedIndexChanged += new System.EventHandler(this.comboBoxTables_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.PreviewPanel);
            this.tabPage3.Controls.Add(this.CommentsReportPanel);
            this.tabPage3.Controls.Add(this.MovesReportPanel);
            this.tabPage3.Controls.Add(this.ReportsBtnsPanel);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(256, 621);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Печать";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // PreviewPanel
            // 
            this.PreviewPanel.Controls.Add(this.rtbPreview);
            this.PreviewPanel.Controls.Add(this.PreviewLabel);
            this.PreviewPanel.Controls.Add(this.MovePreviewLabel);
            this.PreviewPanel.Controls.Add(this.txtMovesPreview);
            this.PreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewPanel.Location = new System.Drawing.Point(3, 3);
            this.PreviewPanel.Name = "PreviewPanel";
            this.PreviewPanel.Size = new System.Drawing.Size(250, 363);
            this.PreviewPanel.TabIndex = 36;
            // 
            // rtbPreview
            // 
            this.rtbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbPreview.Location = new System.Drawing.Point(0, 20);
            this.rtbPreview.Name = "rtbPreview";
            this.rtbPreview.Size = new System.Drawing.Size(250, 297);
            this.rtbPreview.TabIndex = 31;
            this.rtbPreview.Text = "";
            this.rtbPreview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbPreview_KeyDown);
            this.rtbPreview.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbPreview_KeyPress);
            // 
            // PreviewLabel
            // 
            this.PreviewLabel.AutoSize = true;
            this.PreviewLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PreviewLabel.Location = new System.Drawing.Point(0, 0);
            this.PreviewLabel.Name = "PreviewLabel";
            this.PreviewLabel.Size = new System.Drawing.Size(123, 20);
            this.PreviewLabel.TabIndex = 35;
            this.PreviewLabel.Text = "Предпросмотр";
            // 
            // MovePreviewLabel
            // 
            this.MovePreviewLabel.AutoSize = true;
            this.MovePreviewLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MovePreviewLabel.Location = new System.Drawing.Point(0, 317);
            this.MovePreviewLabel.Name = "MovePreviewLabel";
            this.MovePreviewLabel.Size = new System.Drawing.Size(172, 20);
            this.MovePreviewLabel.TabIndex = 37;
            this.MovePreviewLabel.Text = "Предпросмотр ходов";
            // 
            // txtMovesPreview
            // 
            this.txtMovesPreview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtMovesPreview.Location = new System.Drawing.Point(0, 337);
            this.txtMovesPreview.Name = "txtMovesPreview";
            this.txtMovesPreview.Size = new System.Drawing.Size(250, 26);
            this.txtMovesPreview.TabIndex = 36;
            // 
            // CommentsReportPanel
            // 
            this.CommentsReportPanel.AutoScroll = true;
            this.CommentsReportPanel.AutoSize = true;
            this.CommentsReportPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommentsReportPanel.Controls.Add(this.CommentLbl);
            this.CommentsReportPanel.Controls.Add(this.rtb);
            this.CommentsReportPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CommentsReportPanel.Location = new System.Drawing.Point(3, 366);
            this.CommentsReportPanel.Name = "CommentsReportPanel";
            this.CommentsReportPanel.Size = new System.Drawing.Size(250, 57);
            this.CommentsReportPanel.TabIndex = 33;
            // 
            // CommentLbl
            // 
            this.CommentLbl.AutoSize = true;
            this.CommentLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CommentLbl.Location = new System.Drawing.Point(0, 0);
            this.CommentLbl.Name = "CommentLbl";
            this.CommentLbl.Size = new System.Drawing.Size(113, 20);
            this.CommentLbl.TabIndex = 29;
            this.CommentLbl.Text = "Комментарий";
            // 
            // rtb
            // 
            this.rtb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtb.Location = new System.Drawing.Point(0, 20);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(248, 35);
            this.rtb.TabIndex = 28;
            this.rtb.Text = "";
            // 
            // MovesReportPanel
            // 
            this.MovesReportPanel.AutoScroll = true;
            this.MovesReportPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MovesReportPanel.Controls.Add(this.checkBoxIncludeImages);
            this.MovesReportPanel.Controls.Add(this.WhiteMoveCheckBox);
            this.MovesReportPanel.Controls.Add(this.BlackMoveCheckBox);
            this.MovesReportPanel.Controls.Add(this.NudToMove);
            this.MovesReportPanel.Controls.Add(this.NudFromMove);
            this.MovesReportPanel.Controls.Add(this.label2);
            this.MovesReportPanel.Controls.Add(this.label1);
            this.MovesReportPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MovesReportPanel.Location = new System.Drawing.Point(3, 423);
            this.MovesReportPanel.Name = "MovesReportPanel";
            this.MovesReportPanel.Size = new System.Drawing.Size(250, 125);
            this.MovesReportPanel.TabIndex = 32;
            // 
            // checkBoxIncludeImages
            // 
            this.checkBoxIncludeImages.AutoSize = true;
            this.checkBoxIncludeImages.Checked = true;
            this.checkBoxIncludeImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxIncludeImages.Location = new System.Drawing.Point(-1, 94);
            this.checkBoxIncludeImages.Name = "checkBoxIncludeImages";
            this.checkBoxIncludeImages.Size = new System.Drawing.Size(209, 24);
            this.checkBoxIncludeImages.TabIndex = 6;
            this.checkBoxIncludeImages.Text = "Включать изображение";
            this.checkBoxIncludeImages.UseVisualStyleBackColor = true;
            this.checkBoxIncludeImages.CheckedChanged += new System.EventHandler(this.checkBoxIncludeImages_CheckedChanged);
            // 
            // WhiteMoveCheckBox
            // 
            this.WhiteMoveCheckBox.AutoSize = true;
            this.WhiteMoveCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WhiteMoveCheckBox.Location = new System.Drawing.Point(-2, 72);
            this.WhiteMoveCheckBox.Name = "WhiteMoveCheckBox";
            this.WhiteMoveCheckBox.Size = new System.Drawing.Size(211, 24);
            this.WhiteMoveCheckBox.TabIndex = 5;
            this.WhiteMoveCheckBox.Text = "Закончить ходом белых";
            this.WhiteMoveCheckBox.UseVisualStyleBackColor = true;
            this.WhiteMoveCheckBox.CheckedChanged += new System.EventHandler(this.WhiteMoveCheckBox_CheckedChanged);
            // 
            // BlackMoveCheckBox
            // 
            this.BlackMoveCheckBox.AutoSize = true;
            this.BlackMoveCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BlackMoveCheckBox.Location = new System.Drawing.Point(0, 50);
            this.BlackMoveCheckBox.Name = "BlackMoveCheckBox";
            this.BlackMoveCheckBox.Size = new System.Drawing.Size(194, 24);
            this.BlackMoveCheckBox.TabIndex = 4;
            this.BlackMoveCheckBox.Text = "Начать ходом черных";
            this.BlackMoveCheckBox.UseVisualStyleBackColor = true;
            this.BlackMoveCheckBox.CheckedChanged += new System.EventHandler(this.BlackMoveCheckBox_CheckedChanged);
            // 
            // NudToMove
            // 
            this.NudToMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NudToMove.Location = new System.Drawing.Point(84, 22);
            this.NudToMove.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NudToMove.Name = "NudToMove";
            this.NudToMove.Size = new System.Drawing.Size(74, 26);
            this.NudToMove.TabIndex = 3;
            this.NudToMove.ValueChanged += new System.EventHandler(this.NudToMove_ValueChanged);
            // 
            // NudFromMove
            // 
            this.NudFromMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NudFromMove.Location = new System.Drawing.Point(4, 22);
            this.NudFromMove.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NudFromMove.Name = "NudFromMove";
            this.NudFromMove.Size = new System.Drawing.Size(74, 26);
            this.NudFromMove.TabIndex = 2;
            this.NudFromMove.ValueChanged += new System.EventHandler(this.NudFromMove_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(80, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "До хода:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "От хода:";
            // 
            // ReportsBtnsPanel
            // 
            this.ReportsBtnsPanel.AutoSize = true;
            this.ReportsBtnsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ReportsBtnsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportsBtnsPanel.Controls.Add(this.AddToReport);
            this.ReportsBtnsPanel.Controls.Add(this.Report);
            this.ReportsBtnsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ReportsBtnsPanel.Location = new System.Drawing.Point(3, 548);
            this.ReportsBtnsPanel.Name = "ReportsBtnsPanel";
            this.ReportsBtnsPanel.Size = new System.Drawing.Size(250, 70);
            this.ReportsBtnsPanel.TabIndex = 34;
            // 
            // AddToReport
            // 
            this.AddToReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddToReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddToReport.Location = new System.Drawing.Point(0, 0);
            this.AddToReport.Name = "AddToReport";
            this.AddToReport.Size = new System.Drawing.Size(248, 34);
            this.AddToReport.TabIndex = 29;
            this.AddToReport.Text = "Добавить в отчёт";
            this.AddToReport.UseVisualStyleBackColor = true;
            this.AddToReport.Click += new System.EventHandler(this.AddToReport_Click);
            // 
            // Report
            // 
            this.Report.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Report.Location = new System.Drawing.Point(0, 34);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(248, 34);
            this.Report.TabIndex = 27;
            this.Report.Text = "Сохранить отчёт";
            this.Report.UseVisualStyleBackColor = true;
            this.Report.Click += new System.EventHandler(this.Report_Click);
            // 
            // BoardControlsGroupBox
            // 
            this.BoardControlsGroupBox.Controls.Add(this.chessboard);
            this.BoardControlsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoardControlsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.BoardControlsGroupBox.Name = "BoardControlsGroupBox";
            this.BoardControlsGroupBox.Size = new System.Drawing.Size(756, 654);
            this.BoardControlsGroupBox.TabIndex = 21;
            this.BoardControlsGroupBox.TabStop = false;
            this.BoardControlsGroupBox.Resize += new System.EventHandler(this.BoardControlsGroupBox_Resize);
            // 
            // chessboard
            // 
            this.chessboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chessboard.Enabled = false;
            this.chessboard.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chessboard.Location = new System.Drawing.Point(28, 19);
            this.chessboard.MinimumSize = new System.Drawing.Size(250, 250);
            this.chessboard.Name = "chessboard";
            this.chessboard.ShowVisualHints = true;
            this.chessboard.Size = new System.Drawing.Size(595, 561);
            this.chessboard.TabIndex = 10;
            this.chessboard.Text = "chessboard";
            // 
            // ToolStripButtonBack
            // 
            this.ToolStripButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonBack.Image")));
            this.ToolStripButtonBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonBack.Name = "ToolStripButtonBack";
            this.ToolStripButtonBack.Size = new System.Drawing.Size(78, 24);
            this.ToolStripButtonBack.Text = "Назад";
            this.ToolStripButtonBack.Click += new System.EventHandler(this.Back_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скрытьToolStripMenuItem,
            this.скрытьДоскуToolStripMenuItem1,
            this.скрытьХодыToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // скрытьToolStripMenuItem
            // 
            this.скрытьToolStripMenuItem.Name = "скрытьToolStripMenuItem";
            this.скрытьToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.скрытьToolStripMenuItem.Text = "Скрыть панель управления";
            this.скрытьToolStripMenuItem.Click += new System.EventHandler(this.GameInfoHideShow_Click);
            // 
            // скрытьДоскуToolStripMenuItem1
            // 
            this.скрытьДоскуToolStripMenuItem1.Name = "скрытьДоскуToolStripMenuItem1";
            this.скрытьДоскуToolStripMenuItem1.Size = new System.Drawing.Size(225, 22);
            this.скрытьДоскуToolStripMenuItem1.Text = "Скрыть доску";
            this.скрытьДоскуToolStripMenuItem1.Click += new System.EventHandler(this.скрытьДоскуToolStripMenuItem1_Click);
            // 
            // скрытьХодыToolStripMenuItem
            // 
            this.скрытьХодыToolStripMenuItem.Name = "скрытьХодыToolStripMenuItem";
            this.скрытьХодыToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.скрытьХодыToolStripMenuItem.Text = "Скрыть ходы";
            this.скрытьХодыToolStripMenuItem.Click += new System.EventHandler(this.скрытьХодыToolStripMenuItem_Click);
            // 
            // Converter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.ChessSplitter);
            this.Controls.Add(this.MovesGroupBox);
            this.Controls.Add(this.toolStripControls);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(967, 558);
            this.Name = "Converter";
            this.Text = "Доска";
            this.Load += new System.EventHandler(this.Converter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoves)).EndInit();
            this.MovesGroupBox.ResumeLayout(false);
            this.MoveBtnsPanel.ResumeLayout(false);
            this.toolStripControls.ResumeLayout(false);
            this.toolStripControls.PerformLayout();
            this.ChessSplitter.Panel1.ResumeLayout(false);
            this.ChessSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChessSplitter)).EndInit();
            this.ChessSplitter.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.MainInfoPanel.ResumeLayout(false);
            this.MainInfoPanel.PerformLayout();
            this.InfoLabelsPanel.ResumeLayout(false);
            this.InfoLabelsPanel.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ImportPanel.ResumeLayout(false);
            this.ImportPanel.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.PreviewPanel.ResumeLayout(false);
            this.PreviewPanel.PerformLayout();
            this.CommentsReportPanel.ResumeLayout(false);
            this.CommentsReportPanel.PerformLayout();
            this.MovesReportPanel.ResumeLayout(false);
            this.MovesReportPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudToMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFromMove)).EndInit();
            this.ReportsBtnsPanel.ResumeLayout(false);
            this.BoardControlsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMoves;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox MovesGroupBox;
        private System.Windows.Forms.Button BtnMoveLast;
        private System.Windows.Forms.Button BtnMoveFirst;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoveNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn White;
        private System.Windows.Forms.DataGridViewTextBoxColumn Black;
        private System.Windows.Forms.ToolStrip toolStripControls;
        private System.Windows.Forms.SplitContainer ChessSplitter;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtGame;
        private System.Windows.Forms.Label BlackEloLbl;
        private System.Windows.Forms.Label SiteLbl;
        private System.Windows.Forms.Label EventLbl;
        private System.Windows.Forms.Label WhiteEloLbl;
        private System.Windows.Forms.Label ECOLbl;
        private System.Windows.Forms.Label RoundLbl;
        private System.Windows.Forms.Label DateLbl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.Label ImportLbl;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.RichTextBox rtbPreview;
        private System.Windows.Forms.Button AddToReport;
        private System.Windows.Forms.Button Report;
        private System.Windows.Forms.GroupBox BoardControlsGroupBox;
        private System.Windows.Forms.Label BlackLbl;
        private ChessboardControl.Chessboard chessboard;
        private System.Windows.Forms.Label ResultLbl;
        private System.Windows.Forms.Label WhiteLbl;
        private System.Windows.Forms.Panel MoveBtnsPanel;
        private System.Windows.Forms.Panel MovesReportPanel;
        private System.Windows.Forms.CheckBox BlackMoveCheckBox;
        private System.Windows.Forms.NumericUpDown NudToMove;
        private System.Windows.Forms.NumericUpDown NudFromMove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel CommentsReportPanel;
        private System.Windows.Forms.Label CommentLbl;
        private System.Windows.Forms.Panel InfoLabelsPanel;
        private System.Windows.Forms.Panel ImportPanel;
        private System.Windows.Forms.Panel ReportsBtnsPanel;
        private System.Windows.Forms.ToolStripButton ToolStripButtonBack;
        private System.Windows.Forms.Panel MainInfoPanel;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem скрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьДоскуToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem скрытьХодыToolStripMenuItem;
        private System.Windows.Forms.CheckBox WhiteMoveCheckBox;
        private System.Windows.Forms.Label PreviewLabel;
        private System.Windows.Forms.CheckBox checkBoxIncludeImages;
        private System.Windows.Forms.Panel PreviewPanel;
        private System.Windows.Forms.Label MovePreviewLabel;
        private System.Windows.Forms.TextBox txtMovesPreview;
        private System.Windows.Forms.ToolStripButton toolStripBackButton;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}