using System.Globalization;
using System.Text;
using MinesweeperLibrary.Models;

namespace MinesweeperLibrary.DataAccessLayer
{
   
    public class GameStatFileRepository : IGameStatRepository
    {
        private const char Separator = '|';

        public void Save(
            string filePath,
            IEnumerable<GameStat> gameStats)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException(
                    "A valid file path is required.",
                    nameof(filePath));
            }

            ArgumentNullException.ThrowIfNull(gameStats);

            string? directoryPath = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrWhiteSpace(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            List<string> lines = new();

            foreach (GameStat gameStat in gameStats)
            {
                string safeName = SanitizeName(gameStat.Name);

                string line = string.Join(
                    Separator,
                    gameStat.Id.ToString(CultureInfo.InvariantCulture),
                    safeName,
                    gameStat.Score.ToString(CultureInfo.InvariantCulture),
                    gameStat.GameTime.ToString(
                        "O",
                        CultureInfo.InvariantCulture));

                lines.Add(line);
            }

            File.WriteAllLines(
                filePath,
                lines,
                Encoding.UTF8);
        }

        public List<GameStat> Load(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException(
                    "A valid file path is required.",
                    nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                return new List<GameStat>();
            }

            List<GameStat> gameStats = new();
            string[] lines = File.ReadAllLines(
                filePath,
                Encoding.UTF8);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] values = line.Split(Separator);

                if (values.Length != 4)
                {
                    continue;
                }

                bool idIsValid = int.TryParse(
                    values[0],
                    NumberStyles.Integer,
                    CultureInfo.InvariantCulture,
                    out int id);

                bool scoreIsValid = int.TryParse(
                    values[2],
                    NumberStyles.Integer,
                    CultureInfo.InvariantCulture,
                    out int score);

                bool dateIsValid = DateTime.TryParse(
                    values[3],
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind,
                    out DateTime gameTime);

                if (!idIsValid || !scoreIsValid || !dateIsValid)
                {
                    continue;
                }

                GameStat gameStat = new(
                    id,
                    values[1],
                    score,
                    gameTime);

                gameStats.Add(gameStat);
            }

            return gameStats;
        }

        private static string SanitizeName(string name)
        {
            return name
                .Replace(Separator, '-')
                .Replace("\r", " ")
                .Replace("\n", " ")
                .Trim();
        }
    }
}