using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DeckOfCards.Domain.Messages
{
    public interface IDeck
    {
        Guid Id { get; set; }
        ReadOnlyCollection<ICard> GetCards();
        void Reset();
        void Add(ICard card);
        void Remove(int cardIndex);
        void Swap(int initialIndex, int newIndex);
    }
    public class Deck : IDeck
    {
        private IList<ICard> Cards { get; set; }
        public Guid Id { get; set; }

        public ReadOnlyCollection<ICard> GetCards()
        {
            return new ReadOnlyCollection<ICard>(Cards);
        }

        public void Reset()
        {
            Cards = new List<ICard>();
        }

        public void Add(ICard card)
        {
            if(Cards == null) throw new Exception("Invalid deck. Build the deck!");

            if (!RankFaceValueMapper.Instance.ContainsKey(card.Rank))
            {
                throw new Exception("Invalid Card. Card rank should be between 1-13");
            }

            if (!Cards.Contains(card))
                Cards.Add(card);

            if (Cards.Count > Constants.DECK_SIZE)
            {
                throw new Exception($"Deck size cannot be greater than { Constants.DECK_SIZE } ");
            }
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
