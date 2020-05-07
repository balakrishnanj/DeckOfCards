using System;
using System.Threading;
using System.Threading.Tasks;
using DeckOfCards.Domain.Services;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace DeckOfCards.Console
{
    public class DeckOfCardsWorkerService : IHostedService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly IDeckBuilder _deckBuilder;
        private readonly IDeckOfCardsGame _deckOfCardsGame;

        public DeckOfCardsWorkerService(IHostApplicationLifetime hostApplicationLifetime,
            IDeckBuilder deckBuilder,
            IDeckOfCardsGame deckOfCardsGame)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
            _deckBuilder = deckBuilder;
            _deckOfCardsGame = deckOfCardsGame;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                _deckBuilder.Build();
                System.Console.Write("Lets the poker game begin..");
                System.Console.Write("\r\n");
                System.Console.Write("Game Input: 1 - Shuffle; 2- DealOneCard");
                System.Console.Write("\r\n");
                bool isDeckValid = true;
                while (isDeckValid)
                {
                    System.Console.Write("Enter game input: ");
                    int.TryParse(System.Console.ReadLine(), out var pokerInput);
                    if (pokerInput == (int)GameInput.Shuffle) //Shuffle
                    {
                        _deckOfCardsGame.Shuffle();
                    }
                    else if (pokerInput == (int)GameInput.DealOneCard)
                    {
                        var card = _deckOfCardsGame.DealOneCard();
                        if (card == null)
                        {
                            System.Console.Write("Deck is empty! Game ends here!");
                            System.Console.Write("\r\n");
                            System.Console.Write("Do you like to play again (1- yes/ 2- no): ");
                            var restartGame = System.Console.ReadLine();
                            if (restartGame == "1")
                            {       
                                _deckBuilder.Build();
                            }
                            else
                            {
                                isDeckValid = false;
                                _hostApplicationLifetime.StopApplication();
                            }
                        }
                        else
                        {
                            System.Console.Write($"Selected Card: {card.GetSuitsName()}-{card.GetFaceValue()}");
                            System.Console.Write("\r\n");
                        }
                    }
                    else
                    {
                        Log.Error($"Invalid input {pokerInput}");
                        System.Console.Write("Invalid Input. Enter valid input (1 - Shuffle, 2 - Deal One Card): ");
                        System.Console.WriteLine("\r\n");
                    }
                }
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                Log.Error("DeckGame Failed", e);
                _hostApplicationLifetime.StopApplication();
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _hostApplicationLifetime.StopApplication();
            return Task.CompletedTask;
        }
    }
}
