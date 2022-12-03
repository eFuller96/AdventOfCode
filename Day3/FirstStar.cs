using System.Reflection;

namespace Day3;

public static class FirstStar
{
    public static List<int> Get()
    {
        using var streamReader =
            File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "input.txt"));

        List<int> priorities = new();

        while (!streamReader.EndOfStream)
        {
            var line = streamReader.ReadLine();

            var sackOne = line!.Substring(0, line.Length / 2);
            var sackTwo = line.Substring(line.Length / 2, line.Length / 2);

            var uniqueLetter = sackOne.Intersect(sackTwo).Single();

            var priorityNumber = uniqueLetter > 96 ? uniqueLetter - 96 : uniqueLetter - 64 + 26;
            priorities.Add(priorityNumber);
        }

        return priorities;
    }
}