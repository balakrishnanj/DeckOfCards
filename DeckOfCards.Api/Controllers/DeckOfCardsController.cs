using System.Collections.Generic;
using DeckOfCards.Api.Dtos;
using DeckOfCards.Domain.Messages;
using DeckOfCards.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Card = DeckOfCards.Api.Dtos.Card;

namespace DeckOfCards.Api.Controllers
{
    [ApiController]
    [Route("DeckOfCards")]
    public class DeckOfCardsController : ControllerBase
    {
        private readonly IDeckOfCardsGame _deckOfCardsGame;
        private readonly IDeck _deck;
        private readonly IDeckBuilder _deckBuilder;

        public DeckOfCardsController(IDeckOfCardsGame deckOfCardsGame,
            IDeck deck,
            IDeckBuilder deckBuilder)
        {
            _deckOfCardsGame = deckOfCardsGame;
            _deck = deck;
            _deckBuilder = deckBuilder;
        }

        [HttpGet]
        [Route("List")]
        public DeckResponse GetCards()
        {
            if (_deck.GetCards() == null) return new DeckResponse
            {
                Status = "Build the deck before you start the game!",
                Success = false
            };

            var deckResponse = new DeckResponse
            {
                Cards = new List<Card>(),
            };
            foreach (var card in _deck.GetCards())
            {
                deckResponse.Cards.Add(new Card
                {
                    Rank = card.Rank,
                    Suit = card.GetSuitsName(),
                    Value = card.GetFaceValue()
                });
            }

            return deckResponse;
        }

        [HttpGet]
        [Route("Deal")]
        public DeckResponse DealOneCard()
        {
            var card = _deckOfCardsGame.DealOneCard();
            if (card == null)
            {
                return new DeckResponse
                {
                    Id = _deck.Id,
                    Status = "Deck is empty!",
                    Remaining = _deck.GetCards().Count,
                    Success = false
                };
            }
            var cards = _deck.GetCards();
            return new DeckResponse
            {
                Id = _deck.Id,
                Status = "Deal Successful",
                Success = false,
                Remaining = cards.Count,
                Cards = new List<Card>
                {
                    new Card
                    {
                        Rank = card.Rank,
                        Suit = card.GetSuitsName(),
                        Value = card.GetFaceValue()
                    }
                }
            };
        }

        [HttpPut]
        [Route("Shuffle")]
        public DeckResponse Shuffle()
        {
            if (_deck.GetCards() == null) return new DeckResponse
            {
                Status = "Build the deck before you start the game!",
                Success = false
            };

            _deckOfCardsGame.Shuffle();

            return new DeckResponse
            {
                Success = true,
                Remaining = _deck.GetCards().Count,
                Id = _deck.Id,
                Status = "Shuffled Successfully"
            };
        }

        [HttpPost]
        [Route("Build")]
        [Route("Reset")]
        public DeckResponse Build()
        {
            _deckBuilder.Build();
            var deckResponse = new DeckResponse
            {
                Id = _deck.Id,
                Status = "Deck built with 52 cards",
                Success = true,
                Remaining = _deck.GetCards().Count,
                Cards = new List<Card>()
            };

            foreach (var card in _deck.GetCards())
            {
                deckResponse.Cards.Add(new Card
                {
                    Rank = card.Rank,
                    Suit = card.GetSuitsName(),
                    Value = card.GetFaceValue()
                });
            }

            return deckResponse;

        }
    }
}
