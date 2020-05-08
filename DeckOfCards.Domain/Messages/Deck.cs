using System;
using System.Collections.Generic;

namespace DeckOfCards.Domain.Messages
{
    public interface IDeck
    {
        Guid Id { get; set; }
        IList<ICard> GetCards();
        void Reset();
        void Add(ICard card);
        void Remove(int cardIndex);
        void Swap(int initialIndex, int newIndex);
    }
    public class Deck : IDeck
    {
        private IList<ICard> Cards { get; set; }
        public Guid Id { get; set; }

        public IList<ICard> GetCards()
        {
            return Cards;
        }

        public void Reset()
        {
            Cards = new List<ICard>();
        }

        public void Add(ICard card)
        {
            if(Cards == null) throw new Exception("Invalid deck. Build the deck!");

            if (!Cards.Contains(card))
                Cards.Add(card);
        }
        public void Remove(int cardIndex)
        {
            try
            {
                if (Cards == null) throw new Exception("Invalid deck. Build the deck!");

                Cards.RemoveAt(cardIndex);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid Index", ex);
            }
        }

        public void Swap(int initialIndex, int newIndex)
        {
            if (Cards == null) throw new Exception("Invalid deck. Build the deck!");

            if (newIndex > Cards.Count || newIndex < 0) { throw new Exception($"Cannot shuffle cards. {newIndex} is out of bound"); }
            if (initialIndex > Cards.Count || newIndex < 0) { throw new Exception($"Cannot shuffle cards. {initialIndex} is out of bound"); }
            
            var swap = Cards[initialIndex];
            Cards[initialIndex] = Cards[newIndex];
            Cards[newIndex] = swap;
        }
    }
}
