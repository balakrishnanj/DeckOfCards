using System.Linq;
using DeckOfCards.Domain.Messages;
using DeckOfCards.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeckOfCards.Tests
{
    [TestClass]
    public class DeckBuilderTests
    {
        [TestMethod]
        public void Build_ValidData_ShouldBuildDeck()
        {
            var deck = new Deck();
            //Act
            new DeckBuilder(deck).Build();

            //Assert
            var cards = deck.GetCards();
            Assert.IsNotNull(deck.Id);
            Assert.AreEqual(cards.Count, 52);
            Assert.AreEqual(cards.Select(c => c.GetSuitsName()).Distinct().Count(), 4);
            Assert.AreEqual(cards.Count(x => x.GetSuitsName() == typeof(Clubs).Name), 13);
            Assert.AreEqual(cards.Count(x => x.GetSuitsName() == typeof(Hearts).Name), 13);
            Assert.AreEqual(cards.Count(x => x.GetSuitsName() == typeof(Diamonds).Name), 13);
            Assert.AreEqual(cards.Count(x => x.GetSuitsName() == typeof(Spades).Name), 13);
        }
    }
}
