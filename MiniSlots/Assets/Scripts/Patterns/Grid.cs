using System.Collections.Generic;
using Debug = UnityEngine.Debug;

namespace JGM.Game.Patterns
{
    public class Grid : IGrid
    {
        public int[,] Array2D { get; private set; }
        public uint NumberOfRows => _numberOfRows;
        public uint NumberOfColumns => _numberOfColumns;

        private readonly uint _numberOfRows;
        private readonly uint _numberOfColumns;

        public Grid(uint numberOfRows, uint numberOfColumns)
        {
            Debug.Assert(numberOfRows > 0 && numberOfColumns > 0);
            _numberOfRows = numberOfRows;
            _numberOfColumns = numberOfColumns;
            Array2D = new int[_numberOfRows, _numberOfColumns];
            ResetGridValues();
        }

        public void SetColumnValues(uint columnIndex, in List<int> values)
        {
            Debug.Assert(columnIndex < _numberOfColumns);
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