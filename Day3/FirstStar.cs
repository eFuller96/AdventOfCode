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

        return priorities;
    }
}