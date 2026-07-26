using MinesweeperLibrary.DataAccessLayer;
using MinesweeperLibrary.Models;

namespace MinesweeperLibrary.BusinessLogicLayer
{
   
    public class GameStatService : IGameStatService
    {
        private readonly IGameStatRepository repository;
        private readonly List<GameStat> gameStats;

        public GameStatService(IGameStatRepository repository)
        {
            this.repository = repository ??
                throw new ArgumentNullException(nameof(repository));

            gameStats = new List<GameStat>();
        }

        public GameStat CreateGameStat(
            string playerName,
            int score,
            DateTime gameTime)
        {
            string cleanedName = ValidatePlayerName(playerName);

            if (score < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(score),
                    "The score cannot be negative.");
            }

            int nextId = GetNextId();

            return new GameStat(
                nextId,
                cleanedName,
                score,
                gameTime);
        }

        public void AddGameStat(GameStat gameStat)
        {
            ArgumentNullException.ThrowIfNull(gameStat);

            gameStat.Name = ValidatePlayerName(gameStat.Name);

            if (gameStat.Score < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(gameStat),
                    "The score cannot be negative.");
            }

            if (gameStat.GameTime == DateTime.MinValue)
            {
                gameStat.GameTime = DateTime.Now;
            }

            if (gameStat.Id <= 0 ||
                gameStats.Any(item => item.Id == gameStat.Id))
            {
                gameStat.Id = GetNextId();
            }

            gameStats.Add(gameStat);
        }

        public IReadOnlyList<GameStat> GetAll()
        {
            return gameStats.AsReadOnly();
        }

        public List<GameStat> SortByName()
        {
            return gameStats
                .OrderBy(item => item.Name)
                .ThenByDescending(item => item.Score)
                .ToList();
        }

        public List<GameStat> SortByScore()
        {
            return gameStats
                .OrderByDescending(item => item.Score)
                .ThenBy(item => item.Name)
                .ToList();
        }

        public List<GameStat> SortByDate()
        {
            return gameStats
                .OrderByDescending(item => item.GameTime)
                .ToList();
        }

        public void Save(string filePath)
        {
            repository.Save(filePath, gameStats);
        }

        public void Load(string filePath)
        {
            List<GameStat> loadedStats = repository.Load(filePath);

            gameStats.Clear();

            foreach (GameStat gameStat in loadedStats)
            {
                AddGameStat(gameStat);
            }
        }

        private int GetNextId()
        {
            if (gameStats.Count == 0)
            {
                return 1;
            }

            return gameStats.Max(item => item.Id) + 1;
        }

        private static string ValidatePlayerName(string playerName)
        {
            if (string.IsNullOrWhiteSpace(playerName))
            {
                throw new ArgumentException(
                    "The player name is required.",
                    nameof(playerName));
            }

            string cleanedName = playerName.Trim();

            if (cleanedName.Length > 50)
            {
                throw new ArgumentException(
                    "The player name cannot exceed 50 characters.",
                    nameof(playerName));
            }

            return cleanedName;
        }
    }
}
