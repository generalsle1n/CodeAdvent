using Advent1.model;

string inutFileName = "calories.txt";

string fileData = File.ReadAllText(inutFileName);

List<Elf> allElfs = new List<Elf>();

string[] perElf = fileData.Split(Environment.NewLine + Environment.NewLine);

int elfCount = 1;

foreach(string allCaloriePerElf in perElf)
{
    List<int> calories = new List<int>();
    string[] notProcessedCalories = allCaloriePerElf.Split(Environment.NewLine);

    foreach (string singleCalorie in notProcessedCalories)
    {
        calories.Add(int.Parse(singleCalorie));
    }

    allElfs.Add(new Elf
    {
        number = elfCount,
        calories = calories,
        SumCalories = calories.Sum()
    });
    elfCount++;
}

Elf max = allElfs.MaxBy(elf => elf.SumCalories);

Console.WriteLine();