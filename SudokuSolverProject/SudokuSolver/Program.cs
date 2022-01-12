using System.Linq;
using SudokuSolver.Workers;
using SudokuSolver.Strategies;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            SudokuFileReader reader = new SudokuFileReader();
            BoardStateManager stateManager = new BoardStateManager();
            SudokuMapper sudokuMapper = new SudokuMapper();
            SudokuSolverEngine engine = new SudokuSolverEngine(stateManager, sudokuMapper);
            BoardDisplayer displayer = new BoardDisplayer();

            int[,] board = reader.ReadFile("Easy.txt");

            Console.WriteLine(engine.Solve(board));
        }
    }
}
