using System.Collections.Generic;

namespace JGM.Game.Patterns
{
    public interface IGrid
    {
        int[,] Array2D { get; }
        uint NumberOfRows { get; }
        uint NumberOfColumns { get; }

        void SetColumnValues(uint columnIndex, in List<int> values);
        void ResetGridValues();
    }
}