using System;
using System.Text;
using DeckOfCards.Domain.Messages;
using Serilog;

namespace DeckOfCards.Domain.Services
{
    public class DeckOfCardsGame : IDeckOfCardsGame
    {
        private readonly IDeck _deck;
        public DeckOfCardsGame(IDeck deck)
        {
            _deck = deck;
        }

        public void Shuffle()
        {
            var sb = new StringBuilder();
            var deckSize = _deck.GetCards().Count;
            sb.Append($"Shuffle Deck of size {deckSize}");
            var rand = new Random();
            for (int i = 0; i < deckSize - 1; i++)
            {
                int j = rand.Next(i, deckSize);
                if (i != j)
                {
                    _deck.Swap(i, j);
                }
            }
            foreach (var deckCard in _deck.GetCards())
            {
                sb.AppendLine();
                sb.Append($"{deckCard.GetSuitsName()} {deckCard.GetFaceValue()}");
            }

            sb.AppendLine();
            Console.Write(sb.ToString());
        }

        public ICard DealOneCard()
        {
            var deckSize = _deck.GetCards()?.Count;
            if (deckSize == null || deckSize == 0)
            {
                Log.Warning("Deck is empty");
                return null;
            }
            var randomCardId = new Random().Next(1, deckSize.Value) - 1;
            var selectedCard = _deck.GetCards()[randomCardId];
            _deck.Remove(randomCardId);
            return selectedCard;
        }
    }
}
