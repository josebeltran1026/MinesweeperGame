namespace MinesweeperGUI
{
  
    public partial class WinnerForm : Form
    {
        public string PlayerName { get; private set; }

        public WinnerForm(int score)
        {
            InitializeComponent();

            PlayerName = string.Empty;
            lblScore.Text = score.ToString();
        }

        private void WinnerForm_Load(object sender, EventArgs e)
        {
            txtPlayerName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string playerName = txtPlayerName.Text.Trim();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show(
                    "Please enter your name.",
                    "Name Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPlayerName.Focus();
                return;
            }

            PlayerName = playerName;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}