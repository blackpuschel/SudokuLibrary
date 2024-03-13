using System.Collections;

namespace SudokuLibrary.Tests.TestData;

internal class SudokuValidValuesTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        // board, value, row, column
        yield return new object[] { SudokuTestData.Sudoku1, 1, 0, 1};
        yield return new object[] { SudokuTestData.Sudoku1, 6, 4, 5 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
