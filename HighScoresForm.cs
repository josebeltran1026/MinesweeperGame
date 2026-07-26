using MinesweeperLibrary.BusinessLogicLayer;
using MinesweeperLibrary.DataAccessLayer;
using MinesweeperLibrary.Models;

namespace MinesweeperGUI
{

    public partial class HighScoresForm : Form
    {
        private readonly IGameStatService gameStatService;
        private readonly string defaultFilePath;

        public HighScoresForm(IGameStatService gameStatService)
        {
            InitializeComponent();

            this.gameStatService = gameStatService ??
                throw new ArgumentNullException(nameof(gameStatService));

            defaultFilePath = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments),
                "MinesweeperGame",
                "highscores.txt");

            ConfigureGrid();
            DisplayScores(gameStatService.SortByScore());
        }

        private void ConfigureGrid()
        {
            dgvHighScores.AutoGenerateColumns = false;

            colId.DataPropertyName = nameof(GameStat.Id);
            colName.DataPropertyName = nameof(GameStat.Name);
            colScore.DataPropertyName = nameof(GameStat.Score);
            colGameTime.DataPropertyName = nameof(GameStat.GameTime);

            colGameTime.DefaultCellStyle.Format = "g";
        }

        private void DisplayScores(IEnumerable<GameStat> scores)
        {
            dgvHighScores.DataSource = null;
            dgvHighScores.DataSource = scores.ToList();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new()
            {
                Title = "Save High Scores",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FileName = "highscores.txt",
                InitialDirectory = Path.GetDirectoryName(defaultFilePath)
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                gameStatService.Save(saveFileDialog.FileName);

                MessageBox.Show(
                    "High scores were saved successfully.",
                    "Save Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    $"The scores could not be saved.\n{exception.Message}",
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void mnuLoad_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new()
            {
                Title = "Load High Scores",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FileName = "highscores.txt",
                InitialDirectory = Path.GetDirectoryName(defaultFilePath)
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                gameStatService.Load(openFileDialog.FileName);
                DisplayScores(gameStatService.SortByScore());

                MessageBox.Show(
                    "High scores were loaded successfully.",
                    "Load Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    $"The scores could not be loaded.\n{exception.Message}",
                    "Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuSortByName_Click(object sender, EventArgs e)
        {
            DisplayScores(gameStatService.SortByName());
        }

        private void mnuSortByScore_Click(object sender, EventArgs e)
        {
            DisplayScores(gameStatService.SortByScore());
        }

        private void mnuSortByDate_Click(object sender, EventArgs e)
        {
            DisplayScores(gameStatService.SortByDate());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuByScore_Click(object sender, EventArgs e)
        {

        }
    }
}