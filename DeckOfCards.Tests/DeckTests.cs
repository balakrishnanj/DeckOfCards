using System;
using DeckOfCards.Domain.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeckOfCards.Tests
{
    [TestClass]
    public class DeckTests
    {
        private Deck _deck;

        [TestInitialize]
        public void Setup()
        {
            _deck = new Deck();
            _deck.Reset();
            _deck.Add(new Hearts(1));
            _deck.Add(new Spades(1));
        }

        [TestMethod]
        public void Add_ValidCard_ShouldAddItToTheDeck()
        {
            //Act
            _deck.Add(new Clubs(1));
            //Assert
            Assert.AreEqual(_deck.GetCards().Count, 3);

        }

        [TestMethod]
        public void Add_ExistingCard_ShouldNotAddItToTheDeck()
        {
            //Act
            _deck.Add(new Hearts(1));
            _deck.Add(new Spades(1));

            //Arrange
            Assert.AreEqual(_deck.GetCards().Count, 2);
        }

        [TestMethod]
        public void Add_DeckIsNull_ShouldThrowException()
        {
            _deck = new Deck();
            Assert.ThrowsException<Exception>(() => _deck.Add(new Clubs(1)));
        }

        [TestMethod]
        public void Remove_ValidIndex_RemoveCardFromDeck()
        {
            //Act
            _deck.Remove(1);
            //Assert
            Assert.AreEqual(_deck.GetCards().Count, 1);
        }

        [TestMethod]
        public void Remove_InvalidIndex_ShouldThrowException()
        {
            //Act -> //Assert
            Assert.ThrowsException<Exception>(() => _deck.Remove(3));
        }

        [TestMethod]
        public void Remove_DeckIsNull_ShouldThrowException()
        {
            _deck = new Deck();
            Assert.ThrowsException<Exception>(() => _deck.Remove(1));
        }

        [TestMethod]
        public void Swap_ValidIndexes_ShouldSwapTheCards()
        {
            _deck.Add(new Diamonds(1));
            _deck.Add(new Clubs(1));
            var firstCard = _deck.GetCards()[0];
            var faceValue = $"{firstCard.GetSuitsName()}-{firstCard.GetFaceValue()}";

            _deck.Swap(0, 3);

            var swappedCard = _deck.GetCards()[0];
            var swappedCardFaceValue = $"{swappedCard.GetSuitsName()}-{swappedCard.GetFaceValue()}";

            Assert.AreNotEqual(faceValue, swappedCardFaceValue);
        }

        [TestMethod]
        public void Swap_InValidIndexes_ShouldThrowException()
        {
            _deck.Add(new Diamonds(1));
            _deck.Add(new Clubs(1));
            var firstCardValue = _deck.GetCards()[1].GetFaceValue();
            Assert.ThrowsException<Exception>(() => _deck.Swap(1, 5), firstCardValue);
        }

        [TestMethod]
        public void Swap_DeckIsNull_ShouldThrowException()
        {
            _deck = new Deck();
            Assert.ThrowsException<Exception>(() => _deck.Swap(0,1));
        }
    }
}
