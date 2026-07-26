using MinesweeperLibrary.Models;

namespace MinesweeperLibrary.BusinessLogicLayer
{
    
    public class BoardService : IBoardService
    {
        private readonly Random random;

        public BoardService()
        {
            random = new Random();
        }

      
        public void SetupBombs(BoardModel board)
        {
            ValidateBoard(board);

            for (int row = 0; row < board.Size; row++)
            {
                for (int column = 0; column < board.Size; column++)
                {
                    board.Cells[row, column].IsBomb = false;
                    board.Cells[row, column].NumberOfBombNeighbors = 0;
                }
            }

            int totalCells = board.Size * board.Size;
            int numberOfBombs =
                Math.Max(1, (int)Math.Round(totalCells * board.Difficulty));

            int bombsPlaced = 0;

            while (bombsPlaced < numberOfBombs)
            {
                int row = random.Next(board.Size);
                int column = random.Next(board.Size);

                if (!board.Cells[row, column].IsBomb)
                {
                    board.Cells[row, column].IsBomb = true;
                    bombsPlaced++;
                }
            }
        }

       
        public void CountBombsNearby(BoardModel board)
        {
            ValidateBoard(board);

            for (int row = 0; row < board.Size; row++)
            {
                for (int column = 0; column < board.Size; column++)
                {
                    CellModel currentCell = board.Cells[row, column];

                    if (currentCell.IsBomb)
                    {
                        currentCell.NumberOfBombNeighbors = 9;
                        continue;
                    }

                    int bombCount = 0;

                    for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
                    {
                        for (int columnOffset = -1;
                             columnOffset <= 1;
                             columnOffset++)
                        {
                            if (rowOffset == 0 && columnOffset == 0)
                            {
                                continue;
                            }

                            int neighborRow = row + rowOffset;
                            int neighborColumn = column + columnOffset;

                            if (IsValidPosition(
                                    board,
                                    neighborRow,
                                    neighborColumn) &&
                                board.Cells[
                                    neighborRow,
                                    neighborColumn].IsBomb)
                            {
                                bombCount++;
                            }
                        }
                    }

                    currentCell.NumberOfBombNeighbors = bombCount;
                }
            }
        }

        public void ToggleFlag(BoardModel board, int row, int column)
        {
            ValidatePosition(board, row, column);

            CellModel cell = board.Cells[row, column];

            if (!cell.IsVisited)
            {
                cell.IsFlagged = !cell.IsFlagged;
            }
        }

        public void VisitCell(BoardModel board, int row, int column)
        {
            ValidatePosition(board, row, column);

            CellModel cell = board.Cells[row, column];

            if (cell.IsFlagged || cell.IsVisited)
            {
                return;
            }

            if (cell.IsBomb)
            {
                cell.IsVisited = true;
                board.GameState = GameState.Lost;
                board.EndTime = DateTime.Now;
                return;
            }

            FloodFill(board, row, column);
            board.GameState = DetermineGameState(board);

            if (board.GameState == GameState.Won)
            {
                board.EndTime = DateTime.Now;
                board.Score = DetermineFinalScore(board);
            }
        }

        public void FloodFill(BoardModel board, int row, int column)
        {
            ValidatePosition(board, row, column);

            CellModel cell = board.Cells[row, column];

            if (cell.IsVisited || cell.IsFlagged || cell.IsBomb)
            {
                return;
            }

            cell.IsVisited = true;

            if (cell.NumberOfBombNeighbors != 0)
            {
                return;
            }

            for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
            {
                for (int columnOffset = -1;
                     columnOffset <= 1;
                     columnOffset++)
                {
                    if (rowOffset == 0 && columnOffset == 0)
                    {
                        continue;
                    }

                    int neighborRow = row + rowOffset;
                    int neighborColumn = column + columnOffset;

                    if (IsValidPosition(
                            board,
                            neighborRow,
                            neighborColumn))
                    {
                        FloodFill(board, neighborRow, neighborColumn);
                    }
                }
            }
        }

        public GameState DetermineGameState(BoardModel board)
        {
            ValidateBoard(board);

            // First, inspect the entire board for a visited bomb.
            for (int row = 0; row < board.Size; row++)
            {
                for (int column = 0; column < board.Size; column++)
                {
                    CellModel cell = board.Cells[row, column];

                    if (cell.IsBomb && cell.IsVisited)
                    {
                        return GameState.Lost;
                    }
                }
            }

            // Only after confirming that no bomb was visited,
            // check whether safe cells remain unrevealed.
            for (int row = 0; row < board.Size; row++)
            {
                for (int column = 0; column < board.Size; column++)
                {
                    CellModel cell = board.Cells[row, column];

                    if (!cell.IsBomb && !cell.IsVisited)
                    {
                        return GameState.StillPlaying;
                    }
                }
            }

            return GameState.Won;
        }

        public int DetermineFinalScore(BoardModel board)
        {
            ValidateBoard(board);

            DateTime endingTime =
                board.EndTime == DateTime.MinValue
                    ? DateTime.Now
                    : board.EndTime;

            double elapsedSeconds =
                Math.Max(
                    1,
                    (endingTime - board.StartTime).TotalSeconds);

            double difficultyMultiplier =
                Math.Max(1, board.Difficulty * 100);

            double calculatedScore =
                board.Size *
                board.Size *
                difficultyMultiplier *
                100 /
                elapsedSeconds;

            return Math.Max(1, (int)Math.Round(calculatedScore));
        }

        private static bool IsValidPosition(
            BoardModel board,
            int row,
            int column)
        {
            return row >= 0 &&
                   row < board.Size &&
                   column >= 0 &&
                   column < board.Size;
        }

        private static void ValidatePosition(
            BoardModel board,
            int row,
            int column)
        {
            ValidateBoard(board);

            if (!IsValidPosition(board, row, column))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(row),
                    "The selected cell is outside the game board.");
            }
        }

        private static void ValidateBoard(BoardModel board)
        {
            ArgumentNullException.ThrowIfNull(board);

            if (board.Size <= 0)
            {
                throw new ArgumentException(
                    "The board size must be greater than zero.",
                    nameof(board));
            }

            if (board.Difficulty <= 0 ||
                board.Difficulty > 0.25)
            {
                throw new ArgumentException(
                    "Difficulty must be greater than 0 and no more than 0.25.",
                    nameof(board));
            }
        }
    }
}
