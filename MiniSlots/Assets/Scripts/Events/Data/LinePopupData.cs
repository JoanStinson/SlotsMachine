namespace JGM.Game.Events
{
    public class LinePopupData : IGameEventData
    {
        public readonly int LineIndex;

        public LinePopupData(int lineIndex)
        {
            LineIndex = lineIndex;
        }
    }
}