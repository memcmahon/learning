namespace SudokuSolver.Workers
{
    class SudokuFileReader
    {
        public int[,] ReadFile(string filename)
        {
            int[,] sudokuBoard = new int[9,9];

            var sudokuBoardLines = File.ReadAllLines(filename);
            int row = 0;
            foreach(var line in sudokuBoardLines)
            {
                string[] sudokuBoardLineElements = line.Trim('|').Split('|');
                int col = 0;
                foreach (var elem in sudokuBoardLineElements)
                {
                    if (elem == " ")
                    {
                        sudokuBoard[row, col] = 0;
                    } else {
                        sudokuBoard[row, col] = Convert.ToInt16(elem); 
                    }
                    col ++;
                }
                row++;
            }

            return sudokuBoard;
        }
    }
}