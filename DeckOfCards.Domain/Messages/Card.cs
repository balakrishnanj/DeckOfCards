using System;

namespace DeckOfCards.Domain.Messages
{
    public interface ICard
    {
        int Rank { get; }
        string GetSuitsName();
        string GetFaceValue();
    }

    public abstract class Card : IEquatable<Card>
    {
        internal Card(int rank)
        {
            Rank = rank;
        }

        public int Rank { get; }
        public abstract string GetSuitsName();
        public virtual string GetFaceValue()
        {
            return RankFaceValueMapper.Instance[Rank];
        }

        public bool Equals(Card other)
        {
            return $"{GetSuitsName()}-{Rank}".Equals($"{other.GetSuitsName()}-{other.Rank}");
        }

        public override bool Equals(object obj)
        {
            var card = obj as ICard;
            return $"{GetSuitsName()}-{Rank}".Equals($"{card.GetSuitsName()}-{card.Rank}");
        }

        public override int GetHashCode()
        {
            return $"{GetSuitsName()}-{Rank}".GetHashCode();
        }
    }
}
