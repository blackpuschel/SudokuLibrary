using System.Collections;

namespace SudokuLibrary.Tests.TestData;

internal class SudokuInvalidValuesTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        // board, value, row, column
        yield return new object[] { SudokuTestData.Sudoku1, 1, 8, 4 };
        yield return new object[] { SudokuTestData.Sudoku1, 2, 1, 8 };
        yield return new object[] { SudokuTestData.Sudoku1, 4, 6, 8 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
