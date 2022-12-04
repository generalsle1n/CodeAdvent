//https://adventofcode.com/2022/day/2
using Advent2.model;

string fileName = "input.txt";
string[] rawFile = File.ReadAllLines(fileName);

int myGameScore = 0;

List<SingleRound> allGames = new List<SingleRound>();

foreach(string line in rawFile)
{
    string[] singleGame = line.Split(" ");
    SingleRound game = new SingleRound
    {
        Opponent = (OpponentGame)singleGame[0].ToCharArray()[0],
        YoureSelf = (YoureSelfGame)singleGame[1].ToCharArray()[0],
    };
    game.CalculateScore();
    myGameScore += game.Score;
    allGames.Add(game);
}

Console.WriteLine(myGameScore);