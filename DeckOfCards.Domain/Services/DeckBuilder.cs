using System;
using System.Linq;
using DeckOfCards.Domain.Messages;

namespace DeckOfCards.Domain.Services
{
    public class DeckBuilder : IDeckBuilder
    {
        private readonly IDeck _deck;
        public DeckBuilder(IDeck deck)
        {
            _deck = deck;
        }

        public void Build()
        {
            var suitTypes = typeof(ICard)
                .Assembly
                .GetTypes()
                .Where(t => t.IsClass && typeof(ICard).IsAssignableFrom(t));

            foreach (var suitType in suitTypes)
            {
                var rank = 1;
                while (rank <= 13)
                {
                    var card = Activator.CreateInstance(suitType, rank) as ICard;
                    _deck.Add(card);
                    rank++;
                }
            }
        }
    }
}
