using System.Reflection;

namespace Day3;

public static class SecondStar
{
    public static List<int> Get()
    {
        using var streamReader =
            File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "input.txt"));

        List<int> priorities = new();
        List<string> lines = new();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        while (!streamReader.EndOfStream)
        {
            lines.Add(streamReader.ReadLine()!);
            lines.Add(streamReader.ReadLine()!);
            lines.Add(streamReader.ReadLine()!);

            var uniqueLetter = lines.ElementAt(0).Intersect(lines.ElementAt(1)).Intersect(lines.ElementAt(2)).Single();
            
            var priorityNumber = uniqueLetter > 96 ? uniqueLetter - 96 : uniqueLetter - 64 + 26; 
            priorities.Add(priorityNumber);
            lines.Clear();
        }

        watch.Stop();
        var elapsedTicks = watch.ElapsedTicks;
        Console.WriteLine($"star2 intersect: {elapsedTicks}");
        return priorities;
    }
    
    public static List<int> GetOrderedByLength()
    {
        using var streamReader =
            File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "input.txt"));

        List<int> priorities = new();
        List<string> lines = new();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        while (!streamReader.EndOfStream)
        {
            lines.Add(streamReader.ReadLine()!);
            lines.Add(streamReader.ReadLine()!);
            lines.Add(streamReader.ReadLine()!);

            var orderedLines = lines.OrderByDescending(x => x);
            var uniqueLetter = orderedLines.ElementAt(0).Intersect(orderedLines.ElementAt(1)).Intersect(orderedLines.ElementAt(2)).Single();
            
            var priorityNumber = uniqueLetter > 96 ? uniqueLetter - 96 : uniqueLetter - 64 + 26; 
            priorities.Add(priorityNumber);
            lines.Clear();
        }

        watch.Stop();
        var elapsedTicks = watch.ElapsedTicks;
        Console.WriteLine($"star2 intersect ordered by length: {elapsedTicks}");
        return priorities;
    }
}