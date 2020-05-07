namespace DeckOfCards.Domain.Messages
{
    public class Spades : Card, ICard
    {
        public Spades(int rank): base(rank)
        {}

        public override string GetSuitsName()
        {
            return $"{typeof(Spades).Name}";
        }
    }
}
