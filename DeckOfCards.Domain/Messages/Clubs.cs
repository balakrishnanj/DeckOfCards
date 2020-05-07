namespace DeckOfCards.Domain.Messages
{
    public class Clubs : Card, ICard
    {
        public Clubs(int rank) : base(rank) { }
        public override string GetSuitsName()
        {
            return $"{typeof(Clubs).Name}";
        }
    }
}
