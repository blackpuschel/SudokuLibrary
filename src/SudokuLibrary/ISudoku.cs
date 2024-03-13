namespace SudokuLibrary;

/// <summary>
/// A Sudoku is a board with set numbers which obey the standard Sudoku
/// rule set. The board is complete if every cell holds a valid number.
/// <para></para>
/// Contrary to a standard Sudoku, implentations can use any int values
/// to fill the board except the value of 0 (zero). This value is
/// reserved and represents an empty cell (a cell that holds no value).
/// </summary>
public interface ISudoku
{
    /// <summary>
    /// The size can be defined as the possible values in a row.
    /// For example a common Sudoku can hold the values from
    /// 1 to 9 in one row without repetitions.
    /// </summary>
    public int Size { get; }

    /// <summary>
    /// The Sudoku board is made up of cells, which can be
    /// identified by a unique combination of a 
    /// <paramref name="row"/> and a <paramref name="column"/>
    /// in this order respectively (much like a 2d-array).
    /// The indexer is 0 (zero) indexed.
    /// With the indexer the values can be accessed but not changed.
    /// </summary>
    /// <param name="row">
    ///     Represents the row in which the cell resides. 
    ///     <para>Size > row >= 0</para>
    /// </param>
    /// <param name="column">
    ///     Represents the column in which the cell resides.
    ///     <para>Size > column >= 0</para>
    /// </param>
    /// <returns>
    /// The value of a cell identified by its row and column.
    /// </returns>
    /// <exception cref="IndexOutOfRangeException">
    /// Thrown when row or column are negative or >= Size.
    /// </exception>
    int this[int row, int column] { get; }

    /// <summary>
    /// Fill out a cell with a <paramref name="value"/>. A cell is
    /// identified by its <paramref name="row"/> and its 
    /// <paramref name="column"/>. If the value would violate a Sudoku
    /// rule (e.g. having the same numbers in one row) the cells value
    /// remains unchanged.
    /// <para></para>
    /// If the cell already holds a value, the value will be overridden
    /// with the new one if valid. Putting the same values in the same
    /// cell will count as overriding. 
    /// </summary>
    /// <param name="value">
    ///     A number that the specified implementation permits.
    /// </param>
    /// <param name="row">
    ///     Represents the row in which the cell resides.
    ///     <para>Size > row >= 0</para>
    /// </param>
    /// <param name="column">
    ///     Represents the column in which the cell resides.
    ///     <para>Size > column >= 0</para>
    /// </param>
    /// <returns>
    /// True, if the cell now holds the new value.
    /// False, if the new value would violate a Sudoku rule.
    /// </returns>
    public bool Put(int value, int row, int column);

    /// <summary>
    /// Remove a non 0 (zero) value from a cell. Removing is synonymous to
    /// replacing the value with 0 (zero).
    /// </summary>
    /// <param name="row">
    ///     Represents the row in which the cell resides.
    ///     <para>Size > row >= 0</para>
    ///     </param>
    /// <param name="column">
    ///     Represents the column in which the cell resides.
    ///     <para>Size > column >= 0</para>
    /// </param>
    public void Remove(int row, int column);

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
