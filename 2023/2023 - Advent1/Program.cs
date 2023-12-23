//https://adventofcode.com/2023/day/1

string FileName = "PuzzleInput.txt";
string[] Content = File.ReadAllLines(FileName);

int Count = 0;

foreach(string Item in Content)
{
	string Number = null;
	char[] SingleContent = Item.ToArray();
	foreach(char Character in SingleContent)
	{
		if (Char.IsDigit(Character))
		{
			Number += Character;
		}
	}

	Number = Number[0] + Number[Number.Length -1].ToString();

	Count += int.Parse(Number);
}

Console.WriteLine(Count);