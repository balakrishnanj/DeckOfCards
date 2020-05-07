# DeckOfCards 
 The application was developed using .Net core 3.1 frameworks with C# as the backend. 
 Application has both Console application and Web API
 Kindly use the Swagger link for API documentation.
 Repo has a postman collection to run the entire deck with 52 cards.
 Serilog for logging (both custom and Microsoft logs to file and console app)
 
# Core domain Classes:
 
- Deckbuilder.cs: 
   This will build the deck with 52 cards in sequential order. 52 cards consist of 4 suits - Hearts/Clubs/Diamond and Spades. Each suit has 13 cards with face value 2-10, Jack, Queen, King, Ace
 
- DeckOfCardsGame.cs: 
   This class has 2 methods:
     - Shuffle: It shuffles the card randomly. Internally it uses C# random generator functionality.
     - DealOneCard: It returns a random card from the shuffled list. If the deck is empty it returns null.
    
- Deck.cs:
    This class is responsible for Add, Remove, and Swap cards in the deck. It takes care of not adding duplicate cards to the suit.
    Methods: 
Add
Remove
        - Swap.
    
# To run the app: 
Github BuildOutput folder has runtime assemblies for Api and Console applications. Both are self-contained builds, .net core 3.1 installation is not required for both the apps.

- Console application: Run \BuildOutput\Console\DeckOfCards.Console.exe
- API: 
  - BuildOutput\Api\DeckOfCards.Api.exe
  - Open the browser and run: https:\\localhost:5000\Swagger
  - Run the restful API from the swagger UI.

# List of apis:
  Build - To build the deck
  List - To get the current snapshot of the deck
  Deal - Perform Deal one card operation
  Shuffle - Will shuffle the deck and returns output with remaining cards

