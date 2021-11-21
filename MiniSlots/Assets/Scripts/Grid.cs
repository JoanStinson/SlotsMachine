using System.Collections.Generic;

public class Grid
{
    public int[,] array2D;
    private readonly int _numberOfRows;
    private readonly int _numberOfColumns;
    public int NumberOfRows => _numberOfRows;
    public int NumberOfColumns => _numberOfColumns;

    public Grid(int numberOfRows, int numberOfColumns)
    {
        _numberOfRows = numberOfRows;
        _numberOfColumns = numberOfColumns;
        array2D = new int[_numberOfRows, _numberOfColumns];
        ResetGrid();
    }

    public void SetColumnValues(int columnIndex, in List<int> values)
    {
        for (int i = 0; i < _numberOfRows; ++i)
        {
            array2D[i, columnIndex] = values[i];
        }
    }

    public void ResetGrid()
    {
        for (int i = 0; i < _numberOfRows; ++i)
        {
            for (int j = 0; j < _numberOfColumns; ++j)
            {
                array2D[i, j] = -1;
            }
        }
    }
}
