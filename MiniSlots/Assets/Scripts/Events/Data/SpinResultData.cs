using JGM.Game.Patterns;

namespace JGM.Game.Events
{
    public class SpinResultData : IGameEventData
    {
        public readonly IGrid SpinResultGrid;

        public SpinResultData(IGrid grid)
        {
            SpinResultGrid = grid;
        }
    }
}