//mul\([0-9]{1,3},[0-9]{1,3}\)

using System.Text.RegularExpressions;

string InputNameFile = "Input.txt";
string InputData = File.ReadAllText(InputNameFile);
string RegexString = @"mul\([0-9]{1,3},[0-9]{1,3}\)";
string RegexDisable = @"don't\(\)";
string RegexEnable = @"do\(\)";

Regex Match = new Regex(RegexString);
Regex DisableMatch = new Regex(RegexDisable);
Regex EnableMatch = new Regex(RegexEnable);

MatchCollection AllMatches = Match.Matches(InputData);
MatchCollection AllDisabledMatches = DisableMatch.Matches(InputData);
MatchCollection AllEnabledMatches = EnableMatch.Matches(InputData);

int ResultPartOne = 0;

foreach(Match SingleMatch in AllMatches)
{
    string RawData = SingleMatch.Value.Replace("mul(", "").Replace(")", "");
    List<int> SplitData = RawData.Split(",").Select(item => int.Parse(item)).ToList();

    ResultPartOne += SplitData[0] * SplitData[1];
}

Console.WriteLine($"Result Part One: {ResultPartOne}");

List<Match> AllMatchesWith = new List<Match>();

foreach (Match SingleMatch in AllMatches)
{
    AllMatchesWith.Add(SingleMatch);    
}

foreach (Match SingleMatch in AllDisabledMatches)
{
    AllMatchesWith.Add(SingleMatch);
}

foreach (Match SingleMatch in AllEnabledMatches)
{
    AllMatchesWith.Add(SingleMatch);
}

AllMatchesWith = AllMatchesWith.OrderBy(item => item.Index).ToList();

int ResultPartTwo = 0;
bool Enabled = true;

foreach (Match SingleMatch in AllMatchesWith)
{
    if (Enabled)
    {
        if (SingleMatch.Value.Equals("don't()"))
        {
            Enabled = false;
        }
        else if (SingleMatch.Value.Equals("do()"))
        {
            Enabled = true;
        }
        else
        {
            string RawData = SingleMatch.Value.Replace("mul(", "").Replace(")", "");
            List<int> SplitData = RawData.Split(",").Select(item => int.Parse(item)).ToList();

            ResultPartTwo += SplitData[0] * SplitData[1];
        }
    }
    else if (SingleMatch.Value.Equals("do()"))
    {
        Enabled = true;
    }
}

Console.WriteLine($"Result Part Two: {ResultPartTwo}");