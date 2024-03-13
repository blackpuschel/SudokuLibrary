using SudokuLibrary.Tests.TestData;

namespace SudokuLibrary.Tests;

public class EmptySudokuTest
{
    private ISudoku _sudoku;

    public EmptySudokuTest()
    {
        _sudoku = new Sudoku();
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 2, 3)]
    [InlineData(0, 0, -5)]
    public void Indexer_ValidIndices_ReturnsCorrectValue(int row, int column, int expected)
    {
        _sudoku.Put(expected, row, column);
        int actual = _sudoku[row, column];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(-1, 0)]
    [InlineData(0, -1)]
    [InlineData(-1, -1)]
    public void Indexer_NegativeIndices_ThrowsIndexOutOfRangeException(int row, int column)
    {
        Assert.Throws<IndexOutOfRangeException>(() => { int value = _sudoku[row, column]; });
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    public void Indexer_ToLargeIndices_ThrowsIndexOutOfRangeException(int addToMaxRow, int addToMaxColumn)
    {
        int size = _sudoku.Size;
        int maxRow = size - 1;
        int maxColumn = size - 1;

        int row = maxRow + addToMaxRow;
        int column = maxColumn + addToMaxColumn;

        Assert.Throws<IndexOutOfRangeException>(() => { int value = _sudoku[row, column]; });
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(9)]
    public void Put_ValidValue_ReturnsTrueAndCellHoldsValue(int value)
    {
        int row = 0;
        int column = 0;

        bool result = _sudoku.Put(value, row, column);

        Assert.True(result);

        int actual = _sudoku[row, column];

        Assert.Equal(value, actual);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(9)]
    public void Put_ValueAlreadyInRow_ReturnsFalseAndCellValueUnchanged(int value)
    {
        int row1 = 0;
        int row2 = 5;

        _sudoku.Put(value, row1, 0);

        bool result = _sudoku.Put(value, row2, 0);

        Assert.False(result);

        int actual = _sudoku[row2, 0];

        Assert.NotEqual(value, actual);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(9)]
    public void Put_ValueAlreadyInColumn_ReturnsFalseAndCellValueUnchanged(int value)
    {
        int column1 = 0;
        int column2 = 5;

        _sudoku.Put(value, 0, column1);

        bool result = _sudoku.Put(value, 0, column2);

        Assert.False(result);

        int actual = _sudoku[0, column2];

        Assert.NotEqual(value, actual);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(9)]
    public void Put_ValueAlreadyInSquare_ReturnsFalseAndCellValueUnchanged(int value)
    {
        int squareRowEnd = 2;
        int squareColumnEnd = 2;

        _sudoku.Put(value, 0, 0);

        bool result = _sudoku.Put(value, squareRowEnd, squareColumnEnd);

        Assert.False(result);

        int actual = _sudoku[squareRowEnd, squareColumnEnd];

        Assert.NotEqual(value, actual);
    }

    [Fact]
    public void Put_SameValueInSameCell_ReturnsTrue()
    {
        int value = 5;
        int row = 5;
        int column = 5;

        _sudoku.Put(value, row, column);

        bool result = _sudoku.Put(value, row, column);

        Assert.True(result);
    }

    [Theory]
    [InlineData(1, 9)]
    [InlineData(5, 1)]
    [InlineData(9, 5)]
    public void Put_DifferentValuesInSameCell_ReturnsTrueAndOverridesPreviousValue(int oldValue, int newValue)
    {
        int row = 4;
        int column = 4;

        _sudoku.Put(oldValue, row, column);
        bool result = _sudoku.Put(newValue, row, column);

        Assert.True(result);

        int expected = newValue;
        int actual = _sudoku[row, column];

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Remove_NonZeroCell_CellIsNowZero()
    {
        int value = 1;
        int row = 0;
        int column = 0;

        _sudoku.Put(value, row, column);

        int actual = _sudoku[row, column];

        Assert.Equal(value, actual);

        _sudoku.Remove(row, column);

        int expected = 0;
        actual = _sudoku[row, column];

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Remove_ZeroCell_CellUnchanged()
    {
        int value = 0;
        int row = 0;
        int column = 0;

        _sudoku.Put(value, row, column);

        int actual = _sudoku[row, column];

        Assert.Equal(value, actual);

        _sudoku.Remove(row, column);

        int expected = 0;
        actual = _sudoku[row, column];

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsComplete_IncompleteBoard_ReturnsFalse()
    {
        int row = 0;
        int column = 0;

        _sudoku.Remove(row, column);

        int expected = 0;
        int actual = _sudoku[row, column];

        Assert.Equal(expected, actual);

        bool isComplete = _sudoku.IsComplete();

        Assert.False(isComplete);
    }
}

public class SudokuWithValuesTest
{
    [Theory]
    [ClassData(typeof(SudokuValidValuesTestData))]
    public void Put_ValidValue_ReturnsTrueAndCellHoldsValue(int[][] board, int value, int row, int column)
    {
        ISudoku sudoku = new Sudoku(board);

        bool result = sudoku.Put(value, row, column);

        Assert.True(result);

        int expected = value;
        int actual = sudoku[row, column];

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(SudokuInvalidValuesTestData))]
    public void Put_InvalidValue_ReturnsFalseAndCellValueUnchanged(int[][] board, int value, int row, int column)
    {
        ISudoku sudoku = new Sudoku(board);

        bool result = sudoku.Put(value, row, column);

        Assert.False(result);

        int actual = sudoku[row, column];

        Assert.NotEqual(value, actual);
    }

    [Fact]
    public void IsComplete_CompleteBoard_ReturnsTrue()
    {
        int[][] board = SudokuTestData.Sudoku2;
        ISudoku sudoku = new Sudoku(board);

        bool isComplete = sudoku.IsComplete();
        Assert.False(isComplete);

        int value = 5;
        int row = 0;
        int column = 0;

        sudoku.Put(value, row, column);
        
        isComplete = sudoku.IsComplete();
        Assert.True(isComplete);
    }

    [Fact]
    public void IsComplete_RemoveFromCompleteSudoku_ReturnsFalse()
    {
        int[][] board = SudokuTestData.Sudoku3;
        ISudoku sudoku = new Sudoku(board);

        bool isComplete = sudoku.IsComplete();
        Assert.True(isComplete);

        sudoku.Remove(0, 0);

        isComplete = sudoku.IsComplete();
        Assert.False(isComplete);
    }

    [Fact]
    public void IsComplete_OverrideValuesOfUncompleteSudoku_ReturnsFalse()
    {
        int[][] board = SudokuTestData.Sudoku2;
        ISudoku sudoku = new Sudoku(board);

        bool isComplete = sudoku.IsComplete();
        Assert.False(isComplete);

        // A value of 11 is not part of the Sudoku but this tests, if
        // replacing valid values with other valid values messes with
        // the IsComplete method.
        // Since theoretically only one remaining value fits the
        // board, a value outside the range is used.
        int value = 11;
        sudoku.Put(value, 1, 1);

        isComplete = sudoku.IsComplete();
        Assert.False(isComplete);
    }
}