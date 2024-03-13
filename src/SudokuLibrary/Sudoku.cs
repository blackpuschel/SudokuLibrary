namespace SudokuLibrary;

/// <summary>
/// A common square Sudoku with the common Sudoku rule set.
/// </summary>
public class Sudoku : ISudoku
{
    private const int DEFAULT_SIZE = 9;

    private readonly int[,] _board;
    private readonly int _squareSize;
    private int _remainingCells = -1;

    public int Size => _board.GetLength(0);

    public int this[int row, int column] => _board[row, column];


    /// <summary>
    /// Initializes an empty Sudoku board with a size of 9.
    /// </summary>
    public Sudoku()
    {
        _board = new int[DEFAULT_SIZE, DEFAULT_SIZE];
        _squareSize = (int)(Math.Sqrt(Size) + 0.1);
    }

    /// <summary>
    /// The Sudokus board has to be square, meaning same amount of rows and columns.
    /// The amount of rows has to be the square of a natural number.
    /// </summary>
    /// <param name="board"></param>
    /// <exception cref="ArgumentException">
    /// Thrown when the board was not square.
    /// </exception>
    public Sudoku(int[][] board)
    {
        _board = new int[board.Length, board.Length];

        for (int row = 0; row < board.Length; row++)
        {
            if (board[row].Length != board.Length)
            {
                throw new ArgumentException("The array was not square.");
            }

            for (int column = 0; column < board[row].Length; column++)
            {
                _board[row, column] = board[row][column];
            }
        }

        _squareSize = (int)(Math.Sqrt(Size) + 0.1);
    }

    /// <summary>
    /// The amount of rows has to be the square of a natural number.
    /// </summary>
    /// <param name="board"></param>
    public Sudoku(int[,] board)
    {
        _board = board;
        _squareSize = (int)(Math.Sqrt(Size) + 0.1);
    }

    public bool IsComplete()
    {
        if (_remainingCells < 0)
        {
            _remainingCells = CountRemainingCells();
        }

        return _remainingCells == 0;
    }

    private int CountRemainingCells()
    {
        int remainingCells = 0;
        foreach (int cell in _board)
        {
            if (cell == 0)
            {
                remainingCells++;
            }
        }

        return remainingCells;
    }

    /// <param name="value">
    ///     Generally any value is permitted. But it makes sense to
    ///     limit the used values to match the Sudoku board. For
    ///     example a board with a size of 9 should only contain the 
    ///     values from 1 to 9.
    ///     <para />
    ///     A value of 0 (zero) is treated as a place holder for
    ///     empty cells. Use <see cref="Remove"/> instead.
    /// </param>
    /// <inheritdoc />
    public bool Put(int value, int row, int column)
    {
        if (value == 0)
        {
            Remove(row, column);
            return true;
        }

        if (value == _board[row, column])
        {
            return true;
        }

        if (IsUniqueInColumn(value, column)
            && IsUniqueInRow(value, row)
            && IsUniqueInSquare(value, row, column))
        {
            if (_board[row, column] == 0)
            {
                _remainingCells--;
            }

            _board[row, column] = value;
            return true;
        }

        return false;
    }

    private bool IsUniqueInRow(int value, int row)
    {
        for (int column = 0; column < Size; column++)
        {
            if (_board[row, column] == value)
            {
                return false;
            }
        }

        return true;
    }

    private bool IsUniqueInColumn(int value, int column)
    {
        for (int row = 0; row < Size; row++)
        {
            if (_board[row, column] == value)
            {
                return false;
            }
        }

        return true;
    }

    private bool IsUniqueInSquare(int value, int row, int column)
    {
        int squareRow = row / _squareSize;
        int squareColumn = column / _squareSize;

        for (int r = squareRow * _squareSize; r < (squareRow + 1) * _squareSize; r++)
        {
            for (int c = squareColumn * _squareSize; c < (squareColumn + 1) * _squareSize; c++)
            {
                if (_board[r, c] == value)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void Remove(int row, int column)
    {
        if (_board[row, column] != 0)
        {
            _remainingCells++;
            _board[row, column] = 0;
        }
    }
}
