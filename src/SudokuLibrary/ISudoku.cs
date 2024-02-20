namespace SudokuLibrary.src;

/// <summary>
/// A Sudoku is a board with set numbers which obey the standadrd Sudoku rule set.
/// The board is complete if every cell holds a valid number.
/// </summary>
public interface ISudoku
{
    /// <summary>
    /// This is the Sudoku board represented as an 2d-array.
    /// Changes to this reference will not affect the board.
    /// The 0 (zero) is reserved for an empty cell. Cells with a
    /// different value from 0 (zero) count as filled out.
    /// </summary>
    public int[][] Board { get; }

    /// <summary>
    /// Fill out a cell with a value. A cell is identified by its row
    /// and its column. If the value would violate a Sudoku rule (e.g.
    /// having the same numbers in one row) the cells value remains
    /// unchanged.
    /// </summary>
    /// <param name="value">A number that the specified implementation permits.</param>
    /// <param name="row">The row inside the Sudoku board.</param>
    /// <param name="column">The column inside the Sudoku board.</param>
    /// <returns>
    /// True, if the cell now holds the new value.
    /// False, if the new value would violate a Sudoku rule.
    /// </returns>
    public bool Put(int value, uint row, uint column);

    /// <summary>
    /// Remove a non 0 (zero) value from a cell. Removing is synonymous to
    /// replacing the value with 0 (zero).
    /// </summary>
    /// <param name="row">The row inside the Sudoku board.</param>
    /// <param name="column">The column inside the Sudoku board.</param>
    public void Remove(uint row, uint column);

    /// <summary>
    /// Checks, if the Sudoku is complete or rather solved. This means
    /// that all cells have a value different from 0 (zero). However it
    /// is not responsible for checking against the Sudoku rule set.
    /// Therefore incorrect Sudokus may pass as complete.
    /// </summary>
    /// <returns>
    /// True, if all values a different from 0 (zero).
    /// False, if atleast one 0 (zero) cell remains.
    /// </returns>
    public bool IsComplete();
}
