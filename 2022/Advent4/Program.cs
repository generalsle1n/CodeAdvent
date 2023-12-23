//https://adventofcode.com/2022/day/4
using Advent4.model;

string input = "input.txt";
string[] allLines = File.ReadAllLines(input);

List<ElfPair> elfPairs= new List<ElfPair>();

foreach(string line in allLines)
{
    List<string> RawSections = line.Split(",").ToList();
    List<int> SectionIndex = new List<int>();
    
    foreach(string section in RawSections)
    {
        string[] RawIndex = section.Split("-");
        foreach(string index in RawIndex)
        {
            SectionIndex.Add(int.Parse(index));
        }
    }

    ElfPair cur = new ElfPair()
    {
        First = new Section
        {
            Start = SectionIndex[0],
            End = SectionIndex[1]
        },
        Second = new Section
        {
            Start = SectionIndex[2],
            End = SectionIndex[3]
        }
    };

    cur.Overlaped = cur.CheckIfOverlaped();

    elfPairs.Add(cur);
}

List<ElfPair> allOverlapped = elfPairs.FindAll(Pair => Pair.Overlaped == true);

Console.WriteLine(allOverlapped.Count);