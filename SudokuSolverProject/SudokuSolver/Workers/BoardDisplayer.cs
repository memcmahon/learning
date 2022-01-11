namespace SudokuSolver.Workers
{
    class BoardDisplayer
    {
        public void Display(string title, int[,] board)
        {
            if (!title.Equals(String.Empty)) 
            {
                Console.WriteLine(title);
                Console.WriteLine();
            }

            for (int row = 0; row < 9; row++)
            {
                Console.Write("|");
                for (int col = 0; col < 9; col++)
                {
                    Console.Write("{0} {1}", board[row, col], "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}