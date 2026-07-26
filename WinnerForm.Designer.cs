namespace MinesweeperGUI
{
    partial class WinnerForm
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
            lblCongratulations = new Label();
            txtPlayerName = new TextBox();
            lblScoreTitle = new Label();
            lblScore = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblCongratulations
            // 
            lblCongratulations.AutoSize = true;
            lblCongratulations.Location = new Point(47, 9);
            lblCongratulations.Name = "lblCongratulations";
            lblCongratulations.Size = new Size(296, 20);
            lblCongratulations.TabIndex = 0;
            lblCongratulations.Text = "Congratulations! You won. Enter your name:";
            // 
            // txtPlayerName
            // 
            txtPlayerName.Location = new Point(36, 32);
            txtPlayerName.MaxLength = 50;
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new Size(320, 27);
            txtPlayerName.TabIndex = 1;
            // 
            // lblScoreTitle
            // 
            lblScoreTitle.AutoSize = true;
            lblScoreTitle.Location = new Point(57, 99);
            lblScoreTitle.Name = "lblScoreTitle";
            lblScoreTitle.Size = new Size(49, 20);
            lblScoreTitle.TabIndex = 2;
            lblScoreTitle.Text = "Score:";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.Location = new Point(143, 87);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(22, 25);
            lblScore.TabIndex = 3;
            lblScore.Text = "0";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(71, 139);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save Score";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(231, 145);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // WinnerForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(412, 203);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblScore);
            Controls.Add(lblScoreTitle);
            Controls.Add(txtPlayerName);
            Controls.Add(lblCongratulations);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WinnerForm";
            Text = "Record High Score";
            Load += WinnerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCongratulations;
        private TextBox txtPlayerName;
        private Label lblScoreTitle;
        private Label lblScore;
        private Button btnSave;
        private Button btnCancel;
    }
}