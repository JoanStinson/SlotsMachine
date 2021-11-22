using System.Collections.Generic;

namespace JGM.Game.Patterns
{
    public class LineResult
    {
        public int firstItemTypeFoundInLine = -1;
        public int itemCount = 0;
    }

    public class LinePatternChecker
    {
        public LineResult GetResultFromLine(in List<int> itemsInsideLine)
        {
            LineResult lineResult = new LineResult();

            for (int i = 0; i < itemsInsideLine.Count; ++i)
            {
                if (lineResult.firstItemTypeFoundInLine == -1)
                {
                    lineResult.firstItemTypeFoundInLine = itemsInsideLine[i];
                    lineResult.itemCount++;
                }
                else if (itemsInsideLine[i] == lineResult.firstItemTypeFoundInLine)
                {
                    lineResult.itemCount++;
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