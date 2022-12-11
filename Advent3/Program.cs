//https://adventofcode.com/2022/day/4
using Advent3.model;
using static Advent3.model.Rucksack;

string input = "input.txt";

string[] allLines = File.ReadAllLines(input);
List<Rucksack> AllRucksacks = new List<Rucksack>();

int ItemPriority = 0;

foreach(string line in allLines)
{
    int length = line.Length;
    Rucksack cur = new Rucksack()
    {
        FirstPart= line.Substring(0, length/2),
        SecondPart = line.Substring(length/2),
    };
    List<string> AllDups = cur.GetDuplicates();

    foreach(string dup in AllDups)
    {
        foreach(char item in dup)
        {
            ItemPriority += (int)Enum.Parse<ItemCost>(item.ToString());
        }
    }
    AllRucksacks.Add(cur);
}

Console.WriteLine(ItemPriority);