namespace SudokuLibrary.Tests.TestData;

internal static class SudokuTestData
{
    /// <summary>
    /// <list type="bullet">
    /// <item>Size: 9x9</item>
    /// <item>Square: 3x3</item>
    /// <item>Values: 1-9</item>
    /// <item>Values: 1-9</item>
    /// <item>Est. diff.: easy</item>
    /// </list>
    /// </summary>
    internal static int[][] Sudoku1 => [
        [5,0,0,  2,0,0,  9,8,0],
        [6,4,0,  0,3,8,  0,5,0],
        [8,0,7,  9,4,0,  0,0,3],

        [0,5,3,  0,0,2,  0,0,0],
        [0,0,0,  0,9,0,  7,4,0],
        [4,9,0,  0,5,0,  0,0,2],

        [0,0,2,  5,0,0,  3,0,0],
        [0,7,0,  0,0,9,  5,6,1],
        [1,0,5,  3,0,7,  4,0,9]
    ];

    /// <summary>
    /// About: Missing only one value of 5 in [0, 0].
    /// <list type="bullet">
    /// <item>Size: 9x9</item>
    /// <item>Square: 3x3</item>
    /// <item>Values: 1-9</item>
    /// <item>Values: 1-9</item>
    /// <item>Est. diff.: very easy</item>
    /// </list>
    /// </summary>
    internal static int[][] Sudoku2 => [
        [0,3,1,  2,7,6,  9,8,4],
        [6,4,9,  1,3,8,  2,5,7],
        [8,2,7,  9,4,5,  6,1,3],

        [7,5,3,  4,8,2,  1,9,6],
        [2,1,8,  6,9,3,  7,4,5],
        [4,9,6,  7,5,1,  8,3,2],

        [9,6,2,  5,1,4,  3,7,8],
        [3,7,4,  8,2,9,  5,6,1],
        [1,8,5,  3,6,7,  4,2,9]
    ];

    /// <summary>
    /// About: This board is complete.
    /// <list type="bullet">
    /// <item>Size: 9x9</item>
    /// <item>Square: 3x3</item>
    /// <item>Values: 1-9</item>
    /// <item>Values: 1-9</item>
    /// <item>Est. diff.: very easy</item>
    /// </list>
    /// </summary>
    internal static int[][] Sudoku3 => [
        [5,3,1,  2,7,6,  9,8,4],
        [6,4,9,  1,3,8,  2,5,7],
        [8,2,7,  9,4,5,  6,1,3],

        [7,5,3,  4,8,2,  1,9,6],
        [2,1,8,  6,9,3,  7,4,5],
        [4,9,6,  7,5,1,  8,3,2],

        [9,6,2,  5,1,4,  3,7,8],
        [3,7,4,  8,2,9,  5,6,1],
        [1,8,5,  3,6,7,  4,2,9]
    ];
}
