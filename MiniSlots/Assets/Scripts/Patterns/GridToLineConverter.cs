using System.Collections.Generic;

namespace JGM.Game.Patterns
{
    public class GridToLineConverter : IGridToLineConverter
    {
        public void GetLineValuesFromGrid(LineType lineType, in IGrid grid, out List<int> valuesInLine)
        {
            valuesInLine = new List<int>();
            switch (lineType)
            {
                case LineType.HorizontalFirstRow:
                    GetValuesInHorizontalLine(grid, ref valuesInLine, 0);
                    break;

                case LineType.HorizontalSecondRow:
                    GetValuesInHorizontalLine(grid, ref valuesInLine, 1);
                    break;

                case LineType.HorizontalThirdRow:
                    GetValuesInHorizontalLine(grid, ref valuesInLine, 2);
                    break;

                case LineType.W:
                    GetValuesInWLine(grid, ref valuesInLine);
                    break;

                case LineType.V:
                    GetValuesInVLine(grid, ref valuesInLine);
                    break;
            }
        }

        private void GetValuesInHorizontalLine(in IGrid grid, ref List<int> valuesInLine, int rowIndex)
        {
            for (int j = 0; j < grid.NumberOfColumns; ++j)
            {
                valuesInLine.Add(grid.Array2D[rowIndex, j]);
            }
        }

        private void GetValuesInWLine(in IGrid grid, ref List<int> valuesInLine)
        {
            valuesInLine.Add(grid.Array2D[0, 0]);
            valuesInLine.Add(grid.Array2D[2, 1]);
            valuesInLine.Add(grid.Array2D[0, 2]);
            valuesInLine.Add(grid.Array2D[2, 3]);
            valuesInLine.Add(grid.Array2D[0, 4]);
        }

        private void GetValuesInVLine(in IGrid grid, ref List<int> valuesInLine)
        {
            valuesInLine.Add(grid.Array2D[0, 0]);
            valuesInLine.Add(grid.Array2D[1, 1]);
            valuesInLine.Add(grid.Array2D[2, 2]);
            valuesInLine.Add(grid.Array2D[1, 3]);
            valuesInLine.Add(grid.Array2D[0, 4]);
        }
    }
}