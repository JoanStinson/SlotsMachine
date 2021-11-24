namespace JGM.Game.Events
{
    public interface ILinePopupData : IGameEventData
    {
        int LineIndex { get; }
    }

    public class LinePopupData : ILinePopupData
    {
        public int LineIndex { get; private set; }

        public LinePopupData(int lineIndex)
        {
            LineIndex = lineIndex;
        }
    }
}