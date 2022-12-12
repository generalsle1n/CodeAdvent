//https://adventofcode.com/2022/day/5
using Advent5;
using Advent5.model;
using System.Text.RegularExpressions;
using System;
using System.Security;
using System.Text;

string input = "input.txt";

//Read File
string rawData = File.ReadAllText(input);
string[] splitted = rawData.Split(Environment.NewLine + Environment.NewLine);

//Split Into two pieces
string crateSection = splitted[0];
string[] moveSection = splitted[1].Split(Environment.NewLine);

//Split All Lines
string[] formated = crateSection.Split(Environment.NewLine);

//Create Crates
StackHelper sth = new StackHelper();
List<CrateStack> AllCrates = sth.CreateStacks(formated[formated.Length -1]);

int count = formated.Length -2;

while(count >= 0)
{
    string rawLine = formated[count];
    string[] pieces = sth.SplitLineIntoCrate(rawLine);

    int crateCount = 0;

    foreach(string piece in pieces)
    {
        if(!piece.Equals("   "))
        {
            AllCrates[crateCount].Stack.AddCrate(new Crate()
            {
                ID = piece
            });
        }
        
        crateCount++;
    }

    count--;
}

foreach(string move in moveSection)
{
    string currentMove = move.Replace("move","").Replace("from","").Replace("to","");
    string[] parsedMove = currentMove.Split("  ");
    
    int rangeMax= int.Parse(parsedMove[0].Replace(" ",""));
    int rangeCount = 0;

    List<Crate> tempQueue = new List<Crate>();

    while(rangeCount < rangeMax)
    {
        Crate cur = AllCrates.Find(item => item.ID == int.Parse(parsedMove[1])).Stack.GetCrate();
        tempQueue.Add(cur);
        rangeCount++;
    }
    
    foreach(Crate crate in tempQueue)
    {
        AllCrates.Find(item => item.ID == int.Parse(parsedMove[2])).Stack.AddCrate(crate);
    }

}

StringBuilder result = new StringBuilder();

foreach(CrateStack stack in AllCrates)
{
    result.Append(stack.Stack.GetCrate().ID);
}
Console.WriteLine(result);