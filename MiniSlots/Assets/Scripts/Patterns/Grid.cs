using System.Collections.Generic;

namespace JGM.Game.Patterns
{
    public class Grid : IGrid
    {
        public int[,] Array2D { get; private set; }
        public int NumberOfRows => _numberOfRows;
        public int NumberOfColumns => _numberOfColumns;

        private readonly int _numberOfRows;
        private readonly int _numberOfColumns;

        public Grid(int numberOfRows, int numberOfColumns)
        {
            _numberOfRows = numberOfRows;
            _numberOfColumns = numberOfColumns;
            Array2D = new int[_numberOfRows, _numberOfColumns];
            ResetGridValues();
        }

        public void SetColumnValues(int columnIndex, in List<int> values)
        {
            for (int i = 0; i < _numberOfRows; ++i)
            {
                Array2D[i, columnIndex] = values[i];
            }
        }

        public void ResetGridValues()
        {
            for (int i = 0; i < _numberOfRows; ++i)
            {
                for (int j = 0; j < _numberOfColumns; ++j)
                {
                    Array2D[i, j] = -1;
                }
            }
        }
    }
}