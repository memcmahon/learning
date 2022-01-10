using System.Linq;
using SudokuSolver.Workers;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new SudokuFileReader();
            reader.ReadFile("easy.txt");
        }
    }
}
