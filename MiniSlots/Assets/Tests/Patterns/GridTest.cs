using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using Grid = JGM.Game.Patterns.Grid;

namespace JGM.GameTests.Patterns
{
    public class GridTest
    {
        private Grid _grid;
        private List<int> _testValues;

        [OneTimeSetUp]
        public void SetUp()
        {
            _grid = new Grid(3, 4);
            _testValues = new List<int>();
            for (int i = 0; i < 20; ++i)
            {
                _testValues.Add(i);
            }
        }

        [TestCase(2u, 3u)]
        [TestCase(5u, 4u)]
        [TestCase(7u, 12u)]
        public void CreateNewGrid_ColsAndRowsAreGreaterThanZero_ReturnsExpectedResult(uint numberOfRows, uint numberOfColumns)
        {
            _grid = new Grid(numberOfRows, numberOfColumns);
            Assert.AreEqual(numberOfRows, _grid.NumberOfRows);
            Assert.AreEqual(numberOfColumns, _grid.NumberOfColumns);
            Assert.AreEqual(numberOfRows * numberOfColumns, _grid.Array2D.Length);
        }

        [TestCase(0u, 0u)]
        [TestCase(0u, 1u)]
        [TestCase(1u, 0u)]
        public void CreateNewGrid_ColsAndOrRowsAreZero_LogsAssertionsFailed(uint numberOfRows, uint numberOfColumns)
        {
            _grid = new Grid(numberOfRows, numberOfColumns);
            LogAssert.Expect(LogType.Assert, "Assertion failed");
        }

        [TestCase(2u, 1u, 0u)]
        [TestCase(1u, 3u, 1u)]
        [TestCase(1u, 5u, 2u)]
        [TestCase(5u, 4u, 3u)]
        [TestCase(7u, 12u, 6u)]
        public void SetColumnValues_ColIndexIsLessThanColsLength_ReturnsExpectedResult(uint numberOfRows, uint numberOfColumns, uint columnIndex)
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

        [TestCase(1u, 1u, 1u)]
        [TestCase(1u, 3u, 4u)]
        [TestCase(7u, 6u, 16u)]
        public void SetColumnValues_ColIndexIsGreaterThanColsLength_LogsAssertionFailed(uint numberOfRows, uint numberOfColumns, uint columnIndex)
        {
            _grid = new Grid(numberOfRows, numberOfColumns);
            Assert.That(() => _grid.SetColumnValues(columnIndex, _testValues), Throws.TypeOf<IndexOutOfRangeException>());
            LogAssert.Expect(LogType.Assert, "Assertion failed");
        }

        [TestCase(9u, 1u)]
        [TestCase(1u, 8u)]
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