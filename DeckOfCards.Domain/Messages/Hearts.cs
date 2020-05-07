namespace DeckOfCards.Domain.Messages
{
    public class Hearts : Card, ICard
    {
        public Hearts(int rank) : base(rank)
        { }

        public override string GetSuitsName()
        {
            return $"{typeof(Hearts).Name}";
        }
    }
}
