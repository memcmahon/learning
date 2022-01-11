using System.Text;

namespace SudokuSolver
{
    class BoardStateManager
    {
        public string GenerateState(int[,] board)
        {
            var key = new StringBuilder();

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    key.Append(board[row, col]);
                }
            }

            return key.ToString();
        }

        public bool isSolved(int[,] board)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row, col] == 0 || board[row, col].ToString().Length > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}