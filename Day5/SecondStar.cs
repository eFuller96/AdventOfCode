using System.Reflection;

namespace Day5;

public static class SecondStar
{
    public static void Get(Stack<char>[] columns)
    {
        var valuesToMove = new List<char>();

        using var streamReader =
            File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "input.txt"));

        while (!streamReader.EndOfStream)
        {
            var line = streamReader.ReadLine();
            var numbers = line!.Where(char.IsDigit).Select(c => c - '0').ToArray();
            var to = numbers[^1] - 1;
            var from = numbers[^2] - 1;
            var amount = int.Parse(string.Join("",  numbers.Take(numbers.Length - 2)));;
        
            for (var i = amount; i > 0; i--)
            {
                valuesToMove.Add(columns[from].Pop());
            }

            valuesToMove.Reverse();
            valuesToMove.ForEach(x => columns[to].Push(x));
            valuesToMove.Clear();
        }
        
        foreach (var column in columns)
        {
            Console.WriteLine($"{column.Peek()}");
        }
    }
}