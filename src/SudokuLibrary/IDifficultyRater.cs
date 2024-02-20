namespace SudokuLibrary.src;

/// <summary>
/// A Sudokus difficulty can be judged in many subjective ways. To
/// accomodate the different ways to rate a Sudoku, different kind of
/// difficulty raters can be used for a Sudoku.
/// Not all raters might be suitable for different kinds of Sudokus.
/// </summary>
public interface IDifficultyRater
{
    /// <summary>
    /// Rates the difficulty of a Sudoku board from 0 to 100.
    /// Following divisions for this range applie:
    /// <list type="bullet">
    ///     <item><description>0-10:   very easy</description></item>
    ///     <item><description>11-25:  easy</description></item>
    ///     <item><description>26-50:  medium</description></item>
    ///     <item><description>51-75:  hard</description></item>
    ///     <item><description>76-100: very hard</description></item>
    /// </list>
    /// </summary>
    /// <param name="board">
    /// The Sudoku board filled with values.
    /// Values of 0 (zero) represent empty cells.
    /// </param> 
    /// <returns>A rating from 0 to 100.</returns>
    internal int Rate(int[][] board);
}
