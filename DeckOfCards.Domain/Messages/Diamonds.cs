namespace DeckOfCards.Domain.Messages
{
    public class Diamonds:Card, ICard
    {
        public Diamonds(int rank):base(rank)
        {}

        public override string GetSuitsName()
        {
            return $"{typeof(Diamonds).Name}";
        }
    }
}
