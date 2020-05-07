using System;
using Microsoft.Extensions.Hosting;
using DeckOfCards.Domain.Messages;
using DeckOfCards.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace DeckOfCards.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddCommandLine(args);
                    config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                    config.AddJsonFile("appsettings.json", true, true);

                })
                .ConfigureServices(
                    (hostContext, services) =>
                    {
                        services.AddScoped<IDeck, Deck>();
                        services.AddTransient<IDeckBuilder, DeckBuilder>();
                        services.AddTransient<IDeckOfCardsGame, DeckOfCardsGame>();
                        services.AddHostedService<DeckOfCardsWorkerService>();
                    })
                .UseSerilog((hostcontext, loggerConfiguration) =>
                {
                    loggerConfiguration
                        .ReadFrom.Configuration(hostcontext.Configuration);
                })
                .Build().Run();
        }
    }
}
