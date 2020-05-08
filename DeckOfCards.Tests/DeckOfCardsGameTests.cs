using System.Collections.Generic;
using DeckOfCards.Domain.Messages;
using DeckOfCards.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DeckOfCards.Tests
{
    [TestClass]
    public class DeckOfCardsGameTests
    {
        private DeckOfCardsGame _deckOfCardsGame;

        [TestMethod]
        public void DealOneCard_ValidDeckSize_ShouldRemoveCardFromDeck()
        {
            //Arrange
            var deck = new Deck();
            deck.Reset();
            deck.Add(new Clubs(1));
            deck.Add(new Diamonds(1));
            deck.Add(new Hearts(1));
            deck.Add(new Spades(1));
            _deckOfCardsGame = new DeckOfCardsGame(deck);
            var initialCount = deck.GetCards().Count;

            //Act
            var card =_deckOfCardsGame.DealOneCard();

            //Assert
            Assert.IsNotNull(card);
            Assert.AreNotEqual(deck.GetCards().Count, initialCount);
        }

        [TestMethod]
        public void DealOneCard_EmptyDeck_ShouldReturnNull()
        {

            _deckOfCardsGame = new DeckOfCardsGame(new Deck());

            var card = _deckOfCardsGame.DealOneCard();

            Assert.IsNull(card);
        }

        [TestMethod]
        public void Shuffle_DeckHasOnlyOneCard_ShouldNotShuffle()
        {
            var deck = Substitute.For<IDeck>();
            deck.GetCards().Returns(new List<ICard>
            {
                new Clubs(1)
            });

            _deckOfCardsGame = new DeckOfCardsGame(deck);
            _deckOfCardsGame.Shuffle();

            deck.DidNotReceive().Swap(Arg.Any<int>(), Arg.Any<int>());
        }

        [TestMethod]
        public void Shuffle_DeckHasNoCards_ShouldNotShuffle()
        {
            var deck = Substitute.For<IDeck>();
            deck.GetCards().Returns(new List<ICard>
            {
                new Clubs(1)
            });

            _deckOfCardsGame = new DeckOfCardsGame(deck);
            _deckOfCardsGame.Shuffle();

            deck.DidNotReceive().Swap(Arg.Any<int>(), Arg.Any<int>());
        }

        [TestMethod]
        public void Shuffle_DeckHasValidCards_ShouldShuffle()
        {
            var deck = Substitute.For<IDeck>();
            deck.GetCards().Returns(new List<ICard>
            {
                new Clubs(1),
                new Diamonds(2),
                new Hearts(3)
            });

            _deckOfCardsGame = new DeckOfCardsGame(deck);
            _deckOfCardsGame.Shuffle();

            deck.Received().Swap(Arg.Any<int>(), Arg.Any<int>());
        }
    }
}
