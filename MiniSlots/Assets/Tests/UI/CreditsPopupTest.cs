using JGM.Game.Events;
using JGM.Game.UI;
using JGM.Game.Utils;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

namespace JGM.GameTests.UI
{
    public class CreditsPopupTest
    {
        private CreditsPopup _creditsPopup;
        private TextMeshProUGUI _textMeshProUGUI;
        private Mock<ICreditsPopupData> _gameEventDataMock;
        private const int _creditsAmount = 50;

        [OneTimeSetUp]
        public void SetUp()
        {
            var dummyGO = new GameObject("Dummy");
            _textMeshProUGUI = dummyGO.AddComponent<TextMeshProUGUI>();
            _creditsPopup = dummyGO.AddComponent<CreditsPopup>();
            _creditsPopup.Initialize(_textMeshProUGUI);
            _gameEventDataMock = new Mock<ICreditsPopupData>();
            _gameEventDataMock.SetupGet(x => x.CreditsAmount).Returns(_creditsAmount);
        }

        [UnityTest]
        public IEnumerator ShowCredits_DataIsValid_ReturnsExpectedResult()
        {
            _creditsPopup.ShowCredits(_gameEventDataMock.Object);
            Assert.AreEqual(_textMeshProUGUI.text, $"Credits: {_creditsAmount}");
            Assert.IsTrue(_textMeshProUGUI.enabled);
            Assert.IsTrue(_textMeshProUGUI.gameObject.activeSelf);
            yield return new WaitForSeconds(ObjectDisabler.DefaultDelayTime);
            Assert.IsFalse(_creditsPopup.gameObject.activeSelf);
        }

        [Test]
        public void ShowCredits_TextMeshProIsNull_ThrowsException()
        {
            _creditsPopup.Initialize(null);
            Assert.That(() => _creditsPopup.ShowCredits(_gameEventDataMock.Object), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void ShowCredits_DataPassedInIsNull_ThrowsExceptionAndAssertFails()
        {
            Assert.That(() => _creditsPopup.ShowCredits(null), Throws.TypeOf<NullReferenceException>());
            LogAssert.Expect(LogType.Assert, "Assertion failed");
        }
    }
}