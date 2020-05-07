using DeckOfCards.Domain.Messages;

namespace DeckOfCards.Domain.Services
{
    public interface IDeckOfCardsGame
    {
        void Shuffle();
        ICard DealOneCard();
    }
}
