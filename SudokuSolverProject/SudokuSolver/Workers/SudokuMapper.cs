using SudokuSolver.Data;

namespace SudokuSolver.Workers
{
    class SudokuMapper
    {
        public SudokuMap Find(int row, int col)
        {
            SudokuMap map = new SudokuMap();

            if ((row >= 0 && row <= 2) && (col >= 0 && col <= 2))
            {
                map.StartRow = 0;
                map.StartCol = 0;
            } 
            else if ((row >= 0 && row <= 2) && (col >= 3 && col <= 5))
            {
                map.StartRow = 0;
                map.StartCol = 3;
            }
            else if ((row >= 0 && row <= 2) && (col >= 6 && col <= 8))
            {
                map.StartRow = 0;
                map.StartCol = 6;
            }
            else if ((row >= 3 && row <= 5) && (col >= 0 && col <= 2))
            {
                map.StartRow = 3;
                map.StartCol = 0;
            }
            else if ((row >= 3 && row <= 5) && (col >= 3 && col <= 5))
            {
                map.StartRow = 3;
                map.StartCol = 3;
            }
            else if ((row >= 3 && row <= 5) && (col >= 6 && col <= 8))
            {
                map.StartRow = 3;
                map.StartCol = 6;
            }
            else if ((row >= 6 && row <= 8) && (col >= 0 && col <= 2))
            {
                map.StartRow = 6;
                map.StartCol = 0;
            } 
            else if ((row >= 6 && row <= 8) && (col >= 3 && col <= 5))
            {
                map.StartRow = 6;
                map.StartCol = 3;
            } 
            else if ((row >= 6 && row <= 8) && (col >= 6 && col <= 8))
            {
                map.StartRow = 6;
                map.StartCol = 6;
            } 

            return map;
        }
    }
}