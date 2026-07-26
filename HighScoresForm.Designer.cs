namespace MinesweeperGUI
{
    partial class HighScoresForm
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
            menuStrip1 = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuSave = new ToolStripMenuItem();
            mnuLoad = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            mnuSort = new ToolStripMenuItem();
            mnuSortByName = new ToolStripMenuItem();
            mnuSortByScore = new ToolStripMenuItem();
            mnuSortByDate = new ToolStripMenuItem();
            lblTitle = new Label();
            dgvHighScores = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colScore = new DataGridViewTextBoxColumn();
            colGameTime = new DataGridViewTextBoxColumn();
            btnClose = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHighScores).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile, mnuSort });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(732, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuSave, mnuLoad, mnuExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(46, 24);
            mnuFile.Text = "File";
            // 
            // mnuSave
            // 
            mnuSave.Name = "mnuSave";
            mnuSave.Size = new Size(125, 26);
            mnuSave.Text = "Save";
            mnuSave.Click += mnuSave_Click;
            // 
            // mnuLoad
            // 
            mnuLoad.Name = "mnuLoad";
            mnuLoad.Size = new Size(125, 26);
            mnuLoad.Text = "Load";
            mnuLoad.Click += mnuLoad_Click;
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(125, 26);
            mnuExit.Text = "Exit";
            mnuExit.Click += mnuExit_Click;
            // 
            // mnuSort
            // 
            mnuSort.DropDownItems.AddRange(new ToolStripItem[] { mnuSortByName, mnuSortByScore, mnuSortByDate });
            mnuSort.Name = "mnuSort";
            mnuSort.Size = new Size(50, 24);
            mnuSort.Text = "Sort";
            // 
            // mnuSortByName
            // 
            mnuSortByName.Name = "mnuSortByName";
            mnuSortByName.Size = new Size(152, 26);
            mnuSortByName.Text = "By Name";
            mnuSortByName.Click += mnuSortByName_Click;
            // 
            // mnuSortByScore
            // 
            mnuSortByScore.Name = "mnuSortByScore";
            mnuSortByScore.Size = new Size(152, 26);
            mnuSortByScore.Text = "By Score";
            mnuSortByScore.Click += mnuByScore_Click;
            // 
            // mnuSortByDate
            // 
            mnuSortByDate.Name = "mnuSortByDate";
            mnuSortByDate.Size = new Size(152, 26);
            mnuSortByDate.Text = "By Date";
            mnuSortByDate.Click += mnuSortByDate_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(262, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(172, 38);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "High Scores";
            // 
            // dgvHighScores
            // 
            dgvHighScores.AllowUserToAddRows = false;
            dgvHighScores.AllowUserToDeleteRows = false;
            dgvHighScores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHighScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHighScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHighScores.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colScore, colGameTime });
            dgvHighScores.Location = new Point(175, 81);
            dgvHighScores.MultiSelect = false;
            dgvHighScores.Name = "dgvHighScores";
            dgvHighScores.ReadOnly = true;
            dgvHighScores.RowHeadersWidth = 51;
            dgvHighScores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHighScores.Size = new Size(300, 188);
            dgvHighScores.TabIndex = 2;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Name";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colScore
            // 
            colScore.DataPropertyName = "Score";
            colScore.HeaderText = "Score";
            colScore.MinimumWidth = 6;
            colScore.Name = "colScore";
            colScore.ReadOnly = true;
            // 
            // colGameTime
            // 
            colGameTime.DataPropertyName = "GameTime";
            colGameTime.HeaderText = "Date";
            colGameTime.MinimumWidth = 6;
            colGameTime.Name = "colGameTime";
            colGameTime.ReadOnly = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(357, 360);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // HighScoresForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(732, 453);
            Controls.Add(btnClose);
            Controls.Add(dgvHighScores);
            Controls.Add(lblTitle);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(650, 400);
            Name = "HighScoresForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = " Minesweeper High Scores";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHighScores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuSave;
        private ToolStripMenuItem mnuLoad;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem mnuSort;
        private ToolStripMenuItem mnuSortByName;
        private ToolStripMenuItem mnuSortByScore;
        private ToolStripMenuItem mnuSortByDate;
        private Label lblTitle;
        private DataGridView dgvHighScores;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colScore;
        private DataGridViewTextBoxColumn colGameTime;
        private Button btnClose;
    }
}