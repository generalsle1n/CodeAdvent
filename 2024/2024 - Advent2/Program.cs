using _2024___Advent2;

string InputFileNamePartOne = "Input.txt";
string InputFileDataPartOne = File.ReadAllText(InputFileNamePartOne);

string[] InputFileSplitted = InputFileDataPartOne.Split(Environment.NewLine);
int SafePartOne = 0;

foreach(string SingleValue in InputFileSplitted)
{
    if (LevelCheck.SingleLevelCheck(SingleValue))
    {
        SafePartOne++;
    }
}

Console.WriteLine($"Result Part One: {SafePartOne}");

List<List<int>> AllReports = new List<List<int>>();

foreach(string SingleValue in InputFileSplitted)
{
    List<int> Report = SingleValue.Split(" ").Select(item => int.Parse(item)).ToList();
    AllReports.Add(Report);
}

Console.WriteLine($"Result Part One: {LevelCheck.CountSafeDampened(AllReports)}");