namespace SudokuSolver.Strategies
{
    interface ISudokuStrategy
    {
        int[,] Solve(int[,] board);
    }
}