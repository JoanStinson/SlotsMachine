using NUnit.Framework;
using System.Collections.Generic;
using Grid = JGM.Game.Patterns.Grid;

namespace JGM.GameTests.Patterns
{
    public class GridTest
    {
        private Grid _grid;
        private List<int> _testValues;

        [SetUp]
        public void SetUp()
        {
            _grid = new Grid(3, 4);
            _testValues = new List<int>();
            for (int i = 0; i < 20; ++i)
            {
                _testValues.Add(i);
            }
        }

        [TestCase(0u, 0u)]
        [TestCase(0u, 1u)]
        [TestCase(1u, 0u)]
        [TestCase(1u, 1u)]
        [TestCase(5u, 4u)]
        [TestCase(7u, 12u)]
        public void CreateNewGrid_ColsAndRowsAreAccurate_ReturnsExpectedResult(uint numberOfRows, uint numberOfColumns)
        {
            _grid = new Grid(numberOfRows, numberOfColumns);

            Assert.AreEqual(numberOfRows, _grid.NumberOfRows);
            Assert.AreEqual(numberOfColumns, _grid.NumberOfColumns);
            uint expectedNumberOfGridElements = numberOfRows * numberOfColumns;
            Assert.AreEqual(expectedNumberOfGridElements, _grid.Array2D.Length);
        }

        [TestCase(0u, 1u, 0u)]
        [TestCase(1u, 0u, 0u)]
        [TestCase(1u, 1u, 0u)]
        [TestCase(5u, 4u, 3u)]
        [TestCase(7u, 12u, 6u)]
        public void SetColumnValues_SetsValuesCorrectly_ReturnsExpectedResult(uint numberOfRows, uint numberOfColumns, uint columnIndex)
        {
            _grid = new Grid(numberOfRows, numberOfColumns);

            _grid.SetColumnValues(columnIndex, _testValues);

            bool allColumnValuesAreSet = true;
            for (int i = 0; i < numberOfRows; ++i)
            {
                if (_grid.Array2D[i, columnIndex] != _testValues[i])
                {
                    allColumnValuesAreSet = false;
                    break;
                }
                if (!allColumnValuesAreSet)
                {
                    break;
                }
            }
            Assert.IsTrue(allColumnValuesAreSet);
        }

        [TestCase(0u, 1u)]
        [TestCase(1u, 0u)]
        [TestCase(1u, 1u)]
        [TestCase(5u, 4u)]
        [TestCase(7u, 12u)]
        public void ResetGrid_ResetsAllValues_ReturnsExpectedResult(uint numberOfRows, uint numberOfColumns)
        {
            _grid = new Grid(numberOfRows, numberOfColumns);
            for (int i = 0; i < numberOfRows; ++i)
            {
                for (int j = 0; j < numberOfColumns; ++j)
                {
                    _grid.Array2D[i, j] = 4;
                }
            }

            _grid.ResetGridValues();

            bool allValuesReseted = true;
            for (int i = 0; i < numberOfRows; ++i)
            {
                for (int j = 0; j < numberOfColumns; ++j)
                {
                    if (_grid.Array2D[i, j] != -1)
                    {
                        allValuesReseted = false;
                        break;
                    }
                }
                if (!allValuesReseted)
                {
                    break;
                }
            }
            Assert.IsTrue(allValuesReseted);
        }
    }
}