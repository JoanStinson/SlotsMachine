using JGM.Game.Events;
using JGM.Game.UI;
using JGM.Game.Utils;
using Moq;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace JGM.GameTests.UI
{
    public class LinePopupsTest
    {
        private LinePopups _linePopups;
        private Transform[] _lines;
        private Mock<ILinePopupData> _gameEventDataMock;
        private const int _linesSize = 3;

        [OneTimeSetUp]
        public void SetUp()
        {
            var dummyGO = new GameObject("Dummy");
            _linePopups = dummyGO.AddComponent<LinePopups>();
            _lines = new Transform[_linesSize];
            for (int i = 0; i < _linesSize; ++i)
            {
                var lineGO = new GameObject("Line Game Object");
                lineGO.SetActive(false);
                var line = lineGO.transform;
                _lines[i] = line;
            }
            _linePopups.Initialize(_lines);
            _gameEventDataMock = new Mock<ILinePopupData>();
        }

        [UnityTest]
        public IEnumerator ShowLinePopup_DataIsValid_ReturnsExpectedResult()
        {
            for (int i = 0; i < _linesSize; ++i)
            {
                _gameEventDataMock.SetupGet(x => x.LineIndex).Returns(i);
                _linePopups.ShowLinePopup(_gameEventDataMock.Object);
                Assert.IsTrue(_lines[i].gameObject.activeSelf);
                yield return new WaitForSeconds(ObjectDisabler.DefaultDelayTime);
                Assert.IsFalse(_lines[i].gameObject.activeSelf);
            }
        }
    }
}

