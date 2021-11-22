using System.Collections.Generic;

public enum LineType
{
    HorizontalFirstRow,
    HorizontalSecondRow,
    HorizontalThirdRow,
    W,
    V
}

public class GridToLineConverter 
{
    public void GetValuesInHorizontalLine(in Grid grid, out List<int> values, int rowIndex)
    {
        values = new List<int>();
        for (int j = 0; j < grid.NumberOfColumns; ++j)
        {
            values.Add(grid.array2D[rowIndex, j]);
        }
    }

    public void GetValuesInWLine(in Grid grid, out List<int> values)
    {
        values = new List<int>();
        values.Add(grid.array2D[0, 0]);
        values.Add(grid.array2D[2, 1]);
        values.Add(grid.array2D[0, 2]);
        values.Add(grid.array2D[2, 3]);
        values.Add(grid.array2D[0, 4]);
    }

    public void GetValuesInVLine(in Grid grid, out List<int> values)
    {
        values = new List<int>();
        values.Add(grid.array2D[0, 0]);
        values.Add(grid.array2D[1, 1]);
        values.Add(grid.array2D[2, 2]);
        values.Add(grid.array2D[1, 3]);
        values.Add(grid.array2D[0, 4]);
    }
}
