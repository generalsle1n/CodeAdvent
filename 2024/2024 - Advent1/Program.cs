string InputName = "Input.txt";
string InputData = File.ReadAllText(InputName);

string[] Entries = InputData.Split(Environment.NewLine);
List<int> Left = new List<int>();
List<int> Right = new List<int>();

foreach(string SingleEntry in Entries)
{
    string[] Splitted = SingleEntry.Split("   ");

    Left.Add(int.Parse(Splitted[0]));
    Right.Add(int.Parse(Splitted[1]));
}

Left.Sort();
Right.Sort();

int Result = 0;
int Counter = 0;

foreach(int Value in Left)
{
    if(Value >= Right[Counter])
    {
        Result += Value - Right[Counter];
    }else if(Value <= Right[Counter])
    {
        Result += Right[Counter] - Value;
    }

    Counter += 1;
}

Console.WriteLine($"Result Part One: {Result}");

string InputPartTwoName = "InputPartTwo.txt";
string InputPartTwoData = File.ReadAllText(InputPartTwoName);

string[] EntriesPartTwo = InputPartTwoData.Split(Environment.NewLine);

List<int> LeftPartTwo = new List<int>();
List<int> RightPartTwo = new List<int>();

foreach (string SingleEntry in EntriesPartTwo)
{
    string[] Splitted = SingleEntry.Split("   ");

    LeftPartTwo.Add(int.Parse(Splitted[0]));
    RightPartTwo.Add(int.Parse(Splitted[1]));
}

int ResultPartTwo = 0;
int CounterPartTwo = 0;

foreach(int Value in LeftPartTwo)
{
    ResultPartTwo += Value * RightPartTwo.Where(item => item == Value).Count();
}

Console.WriteLine($"Result Part Two: {ResultPartTwo}");