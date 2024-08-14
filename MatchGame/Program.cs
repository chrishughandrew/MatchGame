// See https://aka.ms/new-console-template for more information
using MatchGame;

//Take some console readline input for matchRule and number of packs of cards.
// (hardcode for now)
int numofPacks = 3;
MatchRuleEnum chosenRule = MatchRuleEnum.SUIT;

// Instantiate and Setup Game with given parameters
Game game = new Game(new Deck(), new Player(), new Player());

string setupStatement = game.Setup(chosenRule, numofPacks);
Console.WriteLine(setupStatement);

// Play and Delcare the winner. 
game.Play();
Console.WriteLine($"The winner is: {game.DeclareWinner()}");



