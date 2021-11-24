using JGM.Game.Patterns;
using NUnit.Framework;
using System.Collections.Generic;
using Grid = JGM.Game.Patterns.Grid;

namespace JGM.GameTests.Patterns
{
    public class GridToLineConverterTest
    {
        private GridToLineConverter _gridToLineConverter;
        private IGrid _grid;
        private const int _numberOfRows = 3;
        private const int _numberOfCols = 5;
        private List<int> _expectedValuesInLine;

        [OneTimeSetUp]
        public void SetUp()
        {
            _gridToLineConverter = new GridToLineConverter();
            _grid = new Grid(_numberOfRows, _numberOfCols);
            _expectedValuesInLine = new List<int>();
            for (int i = 0; i < _numberOfCols; ++i)
            {
                _expectedValuesInLine.Add(i * 2);
            }
        }

        [TestCase(LineType.HorizontalFirstRow)]
        [TestCase(LineType.HorizontalSecondRow)]
        [TestCase(LineType.HorizontalThirdRow)]
        [TestCase(LineType.W)]
        [TestCase(LineType.V)]
        public void GetValuesFromLine_ValidLineValues_ReturnsExpectedResult(LineType lineType)
        {
            if (lineType <= LineType.HorizontalThirdRow)
            {
                SetGridValuesForHorizontalLineType((int)lineType);
            }
            else if (lineType == LineType.W)
            {
                SetGridValuesForWLineType();
            }
            else if (lineType == LineType.V)
            {
                SetGridValuesForVLineType();
            }
            _gridToLineConverter.GetLineValuesFromGrid(lineType, _grid, out List<int> actualValuesInLine);
            Assert.AreEqual(_expectedValuesInLine, actualValuesInLine);
        }

        [TestCase(LineType.HorizontalFirstRow)]
        [TestCase(LineType.HorizontalSecondRow)]
        [TestCase(LineType.HorizontalThirdRow)]
        [TestCase(LineType.W)]
        [TestCase(LineType.V)]
        public void GetValuesFromLine_GetValuesWhenGridIsReset_ReturnsWrongResult(LineType lineType)
        {
            if (lineType <= LineType.HorizontalThirdRow)
            {
                SetGridValuesForHorizontalLineType((int)lineType);
            }
            else if (lineType == LineType.W)
            {
                SetGridValuesForWLineType();
            }
            else if (lineType == LineType.V)
            {
                SetGridValuesForVLineType();
            }
            _grid.ResetGridValues();
            _gridToLineConverter.GetLineValuesFromGrid(lineType, _grid, out List<int> actualValuesInLine);
            Assert.AreNotEqual(_expectedValuesInLine, actualValuesInLine);
        }

        private void SetGridValuesForHorizontalLineType(in int lineType)
        {
            var valuesToAddToGrid = new List<int>();
            for (int i = 0; i < _numberOfRows; ++i)
            {
                valuesToAddToGrid.Add(i);
            }
            for (uint i = 0; i < _numberOfCols; ++i)
            {
                valuesToAddToGrid[lineType] = _expectedValuesInLine[(int)i];
                _grid.SetColumnValues(i, valuesToAddToGrid);
            }
        }

        private void SetGridValuesForWLineType()
        {
            for (uint i = 0; i < _expectedValuesInLine.Count; ++i)
            {
                var columnValues = (i % 2 == 0) ? new List<int> { _expectedValuesInLine[(int)i], 4, 8 } : new List<int> { 6, 7, _expectedValuesInLine[(int)i] };
                _grid.SetColumnValues(i, columnValues);
            }
        }

        private void SetGridValuesForVLineType()
        {
            var firstCol = new List<int> { _expectedValuesInLine[0], 3, 4 };
            var secondCol = new List<int> { 6, _expectedValuesInLine[1], 7 };
            var thirdCol = new List<int> { 8, 4, _expectedValuesInLine[2] };
            var fourthCol = new List<int> { 1, _expectedValuesInLine[3], 3 };
            var fifthCol = new List<int> { _expectedValuesInLine[4], 9, 2 };
            _grid.SetColumnValues(0, firstCol);
            _grid.SetColumnValues(1, secondCol);
            _grid.SetColumnValues(2, thirdCol);
            _grid.SetColumnValues(3, fourthCol);
            _grid.SetColumnValues(4, fifthCol);
        }
    }
}