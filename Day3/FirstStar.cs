using System.Reflection;

namespace Day3;

public static class FirstStar
{
    // 0 (n+m)
    // 2ms
    public static List<int> Get()
    {
        using var streamReader =
            File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "input.txt"));

        List<int> priorities = new();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        
        while (!streamReader.EndOfStream)
        {
            var line = streamReader.ReadLine();

            var sackOne = line!.Substring(0, line.Length / 2);
            var sackTwo = line.Substring(line.Length / 2, line.Length / 2);

            var uniqueLetter = sackOne.Intersect(sackTwo).Single();

            var priorityNumber = uniqueLetter > 96 ? uniqueLetter - 96 : uniqueLetter - 64 + 26;
            priorities.Add(priorityNumber);
        }

        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        Console.WriteLine($"Intersect: {elapsedMs}");
        return priorities;
    }

    // O(nm)
    // 0ms
    public static List<int> GetWithNestedLoops()
    {
        using var streamReader =
            File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "input.txt"));

        List<int> priorities = new();
        var watch = System.Diagnostics.Stopwatch.StartNew();

        while (!streamReader.EndOfStream)
        {
            var line = streamReader.ReadLine();

            var sackOne = line!.Substring(0, line.Length / 2);
            var sackTwo = line.Substring(line.Length / 2, line.Length / 2);

            var foundMatch = false;

            foreach (var sackOneLetter in sackOne)
            {
                foreach (var sackTwoLetter in sackTwo)
                {
                    if (sackTwoLetter == sackOneLetter)
                    {
                        foundMatch = true;
                        var priorityNumber = sackOneLetter > 96 ? sackOneLetter - 96 : sackOneLetter - 64 + 26; 
                        priorities.Add(priorityNumber);
                        break;
                    }
                }

                if (foundMatch)
                {
                    break;
                }
            }
        }

        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        Console.WriteLine($"nested forloops: {elapsedMs}");
        return priorities;
    }
}