using System.Collections.Generic;

namespace JGM.Game.Patterns
{
    public interface IGrid
    {
        int[,] Array2D { get; }
        int NumberOfRows { get; }
        int NumberOfColumns { get; }

        void SetColumnValues(int columnIndex, in List<int> values);
        void ResetGridValues();
    }
}