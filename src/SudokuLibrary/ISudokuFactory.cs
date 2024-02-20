namespace SudokuLibrary.src;

/// <summary>
/// Sudoku factorys are responsible for creating a specific kind of
/// Sudoku, depending on the underlying implementation.
/// Different Factorys may create different kind of Sudokus and own
/// different rule sets.
/// </summary>
public interface ISudokuFactory
{
    /// <summary>
    /// Creates a Sudoku based on the used factory implementation.
    /// </summary>
    /// <returns>
    /// The new Sudoku.
    /// </returns>
    public ISudoku Create();
}
