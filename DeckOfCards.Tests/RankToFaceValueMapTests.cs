using DeckOfCards.Domain.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeckOfCards.Tests
{
    [TestClass]
    public class RankToFaceValueMapTests
    {
        [TestMethod]
        public void Map_ShouldReturnValidMappedValues()
        {
            var mapper = RankFaceValueMapper.Instance;
            Assert.AreEqual(mapper[1], "Two");
            Assert.AreEqual(mapper[2], "Three");
            Assert.AreEqual(mapper[3], "Four");
            Assert.AreEqual(mapper[4], "Five");
            Assert.AreEqual(mapper[5], "Six");
            Assert.AreEqual(mapper[6], "Seven");
            Assert.AreEqual(mapper[7], "Eight");
            Assert.AreEqual(mapper[8], "Nine");
            Assert.AreEqual(mapper[9], "Ten");
            Assert.AreEqual(mapper[10], "Jack");
            Assert.AreEqual(mapper[11], "Queen");
            Assert.AreEqual(mapper[12], "King");
            Assert.AreEqual(mapper[13], "Ace");

        }
    }
}
