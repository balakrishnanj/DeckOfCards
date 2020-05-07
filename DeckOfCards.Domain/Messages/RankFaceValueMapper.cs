using System.Collections.Generic;

namespace DeckOfCards.Domain.Messages
{
    public static class RankFaceValueMapper
    {
        public static IDictionary<int, string> Instance =>
            new Dictionary<int, string>
            {
                {1, "Two"},
                {2, "Three"},
                {3, "Four"},
                {4, "Five"},
                {5, "Six"},
                {6, "Seven"},
                {7, "Eight"},
                {8, "Nine"},
                {9, "Ten"},
                {10, "Jack"},
                {11, "Queen"},
                {12, "King"},
                {13, "Ace"},
            };
    }
}
