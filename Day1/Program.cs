using System.Reflection;

var listOfCalories = new List<int>();
var calorieCounter = 0;

using (var streamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "input.txt")))
{
    while (!streamReader.EndOfStream)
    {
        var line = streamReader.ReadLine();
        if (line == string.Empty)
        {
            listOfCalories.Add(calorieCounter);
            calorieCounter = 0;
            continue;
        }

        calorieCounter += int.Parse(line);
    }
}

var answer = listOfCalories.Max();

Console.WriteLine($"answer:{answer}");

var answerTwo = listOfCalories.OrderByDescending(x => x).Take(3).Sum();

Console.WriteLine($"answer 2: {answerTwo}");
