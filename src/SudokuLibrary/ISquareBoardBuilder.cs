namespace SudokuLibrary.src;

/// <summary>
/// A Builder interface for creating a square Sudoku board.
/// The size of the board is the responsibility of the
/// specific inplementations.
/// </summary>
internal interface ISquareBoardBuilder
{
    /// <summary>
    /// Build a square board based on the standard Sudoku rule set.
    /// A value of 0 (zero) is reserved for empty cells.
    /// </summary>
    /// <returns>
    /// A 2d-array representing a Sudoku board.
    /// </returns>
    internal int[][] Build();
}
