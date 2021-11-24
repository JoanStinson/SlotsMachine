namespace JGM.Game.Patterns
{
    public class LineResult : ILineResult
    {
        public int FirstItemTypeFoundInLine { get; set; } = -1;
        public int ItemCount { get; set; } = 0;
    }
}
