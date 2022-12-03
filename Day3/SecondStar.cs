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

        return priorities;
    }
}