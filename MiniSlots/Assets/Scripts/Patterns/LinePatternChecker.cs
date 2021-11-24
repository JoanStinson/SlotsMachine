using System.Collections.Generic;

namespace JGM.Game.Patterns
{
    public class LinePatternChecker : ILinePatternChecker
    {
        public ILineResult GetResultFromLine(in List<int> itemsInsideLine)
        {
            var lineResult = new LineResult();

            for (int i = 0; i < itemsInsideLine.Count; ++i)
            {
                if (lineResult.FirstItemTypeFoundInLine == -1)
                {
                    lineResult.FirstItemTypeFoundInLine = itemsInsideLine[i];
                    lineResult.ItemCount++;
                }
                else if (itemsInsideLine[i] == lineResult.FirstItemTypeFoundInLine)
                {
                    lineResult.ItemCount++;
                }
                else
                {
                    break;
                }
            }

            return lineResult;
        }
    }
}