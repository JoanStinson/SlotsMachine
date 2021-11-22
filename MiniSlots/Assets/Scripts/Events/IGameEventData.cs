using JGM.Game.Patterns;

namespace JGM.Game.Events
{
    public interface IGameEventData
    {
    }

    public class LinePopupData : IGameEventData
    {
        public readonly int LineIndex;

        public LinePopupData(int lineIndex)
        {
            LineIndex = lineIndex;
        }
    }

    public class CreditsPopupData : IGameEventData
    {
        public readonly int CreditsAmount;

        public CreditsPopupData(int creditsAmount)
        {
            CreditsAmount = creditsAmount;
        }
    }

    public class SpinResultData : IGameEventData
    {
        public readonly Grid SpinResultGrid;

        public SpinResultData(Grid grid)
        {
            SpinResultGrid = grid;
        }
    }
}