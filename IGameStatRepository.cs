using MinesweeperLibrary.Models;

namespace MinesweeperLibrary.DataAccessLayer
{
    
    public interface IGameStatRepository
    {
        void Save(string filePath, IEnumerable<GameStat> gameStats);

        List<GameStat> Load(string filePath);
    }
}