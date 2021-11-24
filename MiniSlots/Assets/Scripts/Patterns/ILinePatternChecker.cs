using System.Collections.Generic;

namespace JGM.Game.Patterns
{
    public interface ILinePatternChecker
    {
        ILineResult GetResultFromLine(in List<int> itemsInsideLine);
    }
}