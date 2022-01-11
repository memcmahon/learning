using SudokuSolver.Workers;

namespace SudokuSolver.Strategies
{
    class SudokuSolverEngine
    {
        private readonly BoardStateManager _boardStateManager;
        private readonly SudokuMapper _sudokuMapper;

        public SudokuSolverEngine(BoardStateManager boardStateManager, SudokuMapper sudokuMapper)
        {
            _boardStateManager = boardStateManager;
            _sudokuMapper = sudokuMapper;
        }

        public bool Solve(int[,] board)
        {
            List<ISudokuStrategy> strategies = new List<ISudokuStrategy>() 
            {
                new SimpleMarkUp(_sudokuMapper)
            };

            var currentState = _boardStateManager.GenerateState(board);
            var nextState = _boardStateManager.GenerateState(strategies.First().Solve(board));

            while (!_boardStateManager.isSolved(board) && currentState != nextState)
            {
                currentState = nextState;
                foreach (var strategy in strategies)
                {
                    nextState = _boardStateManager.GenerateState(strategy.Solve(board));
                }

            }
            BoardDisplayer displayer = new BoardDisplayer();
            displayer.Display("solved", board);
            return _boardStateManager.isSolved(board);
        }
    }
}