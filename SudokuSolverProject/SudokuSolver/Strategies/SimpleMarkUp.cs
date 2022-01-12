using SudokuSolver.Workers;

namespace SudokuSolver.Strategies
{
    class SimpleMarkUp : ISudokuStrategy
    {
        private readonly SudokuMapper _sudokuMapper;

        public SimpleMarkUp(SudokuMapper sudokuMapper)
        {
            _sudokuMapper = sudokuMapper;
        }

        public int[,] Solve(int[,] board)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row, col] == 0 || board[row, col].ToString().Length > 1)
                    {
                        var possibilitiesInRowAndCol = GetPossibilitiesInRowAndCol(board, row, col);
                        var possibilitiesInBlock = GetPossibilitiesInBlock(board, row, col);
                        var intersection = GetPossibilityIntersection(possibilitiesInRowAndCol, possibilitiesInBlock);
                        board[row, col] = intersection;
                    }
                }
            }

            return board;
        }

        private int GetPossibilitiesInRowAndCol(int[,] board, int givenRow, int givenCol)
        {
            int[] allPossibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int col=0; col < 9; col++)
            {
                if (IsValidSingle(board[givenRow, givenCol]))
                {
                    var currentValue = board[givenRow, col];
                    if (currentValue != 0) allPossibilities[currentValue - 1] = 0;
                }
            }

            for (int row=0; row < 9; row++)
            {
                if (IsValidSingle(board[givenRow, givenCol]))
                {
                    var currentValue = board[row, givenCol];
                    if (currentValue != 0) allPossibilities[currentValue - 1] = 0;
                }
            }

            var realPossibilities = new List<int>();

            foreach (var n in allPossibilities)
            {
                if (n != 0) realPossibilities.Add(n);
            }

            return Convert.ToInt32(String.Concat(realPossibilities));
        }

        private int GetPossibilitiesInBlock(int[,] board, int givenRow, int givenCol)
        {
            int[] allPossibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sudokuMap = _sudokuMapper.Find(givenRow, givenCol);

            for (int row = sudokuMap.StartRow; row <= sudokuMap.StartRow + 2; row++)
            {
                for (int col = sudokuMap.StartCol; col <= sudokuMap.StartCol + 2; col++)
                {
                    var currentValue = board[row, col];
                    if(currentValue > 0 && currentValue <= 9) allPossibilities[currentValue - 1] = 0;
                }
            }

            var realPossibilities = new List<int>();
            foreach (var n in allPossibilities)
            {
                if (n != 0) realPossibilities.Add(n);
            }

            return Convert.ToInt32(String.Concat(realPossibilities));
        }

        private int GetPossibilityIntersection(int pRowAndCol, int pBlock)
        {
            var possibilitiesInRowAndCol = pRowAndCol.ToString().ToCharArray();
            var possibilitiesInBlock = pBlock.ToString().ToCharArray();
            var realPossibilities = possibilitiesInRowAndCol.Intersect(possibilitiesInBlock);

            return Convert.ToInt32(string.Concat(realPossibilities));
        }

        private bool IsValidSingle(int cellDigit)
        {
            return cellDigit != 0 && cellDigit.ToString().Length < 2;
        }
    }
}