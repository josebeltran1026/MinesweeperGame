using MinesweeperLibrary.Models;

namespace MinesweeperLibrary.BusinessLogicLayer
{
   
    public interface IBoardService
    {
        void SetupBombs(BoardModel board);

        void CountBombsNearby(BoardModel board);

        void ToggleFlag(BoardModel board, int row, int column);

        void VisitCell(BoardModel board, int row, int column);

        void FloodFill(BoardModel board, int row, int column);

        GameState DetermineGameState(BoardModel board);

        int DetermineFinalScore(BoardModel board);
    }
}