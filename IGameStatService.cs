using MinesweeperLibrary.Models;

namespace MinesweeperLibrary.BusinessLogicLayer
{
   
    public interface IGameStatService
    {
        GameStat CreateGameStat(
            string playerName,
            int score,
            DateTime gameTime);

        void AddGameStat(GameStat gameStat);

        IReadOnlyList<GameStat> GetAll();

        List<GameStat> SortByName();

        List<GameStat> SortByScore();

        List<GameStat> SortByDate();

        void Save(string filePath);

        void Load(string filePath);
    }
}