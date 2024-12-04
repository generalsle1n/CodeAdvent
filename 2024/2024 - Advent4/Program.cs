using _2024___Advent4;
using System;

string InputFileName = "Input.txt";
string[] InputFileData = File.ReadAllLines(InputFileName);

List<List<string>> MatrixData = new List<List<string>>();

foreach (string SingleLine in InputFileData)
{
    List<string> Data = SingleLine.ToList().Select(item => item.ToString()).ToList();
    MatrixData.Add(Data);
}


int ResultPartOne = 0;

//Horizontal
foreach (List<string> SingleLine in MatrixData)
{
    string Data = StringChecker.GetStringFromHorizontal(SingleLine);
    ResultPartOne += StringChecker.CountInString(Data);
}

//Vertical
int ListLength = MatrixData[0].Count;
int Count = 0;

while(Count < ListLength)
{
    string Data = StringChecker.GetStringFromVertical(MatrixData, Count);
    ResultPartOne += StringChecker.CountInString(Data);
    Count++;
}

//Diagonal
List<string> LeftToRight = StringChecker.GetStringFromDiagonalLeftToRight(MatrixData);

foreach(string SingleLine in LeftToRight)
{
    ResultPartOne += StringChecker.CountInString(SingleLine);
}

List<string> RightToLeft = StringChecker.GetStringFromDiagonalRightToLeft(MatrixData);

foreach (string SingleLine in RightToLeft)
{
    ResultPartOne += StringChecker.CountInString(SingleLine);
}

Console.WriteLine($"Result Part One: {ResultPartOne}");

string InputFileDataPartTwo = File.ReadAllText(InputFileName);

StringChecker.FindXInString(InputFileData);