using System;

public partial class PlayerStats : Form
{
    List<PlayerStat> stats = new List<PlayerStat>();

    public PlayerStats()
    {
        InitializeComponent();

        LoadStatistics();
    }

    private void LoadStatistics()
    {
        dataGridView1.DataSource = stats;

        CalculateStatistics();
    }

    private void CalculateStatistics()
    {
        if (stats.Count == 0)
            return;

        double averageScore = stats.Average(s => s.Score);
        double averageTime = stats.Average(s => s.TimePlayed);

        lblAverageScore.Text = $"Average Score: {averageScore:F1}";
        lblAverageTime.Text = $"Average Time: {averageTime:F1} seconds";
    }
}
