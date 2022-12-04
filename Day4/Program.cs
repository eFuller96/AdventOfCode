using System.Reflection;

using var streamReader =
    File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "input.txt"));

var count = 0;

while (!streamReader.EndOfStream)
{
    var line = streamReader.ReadLine();
    var pairs = line!.Split(',')
        .Select(x => new Tuple<int, int>(int.Parse(x.Split('-').First()), int.Parse(x.Split('-').Last()))).ToArray();

    var firstRange = pairs.First();
    var secondRange = pairs.Last();

    // Star 1
    // if ((firstRange.Item1 - secondRange.Item1 > 0 && firstRange.Item2 - secondRange.Item2 > 0) ||
    //     firstRange.Item1 - secondRange.Item1 < 0 && firstRange.Item2 - secondRange.Item2 < 0)
    // {
    //     continue;
    // }

    // Star 2
    if ((secondRange.Item1 < firstRange.Item1 && secondRange.Item1 < firstRange.Item2 &&
         secondRange.Item2 < firstRange.Item1 && secondRange.Item2 < firstRange.Item2) ||
        (secondRange.Item2 > firstRange.Item1 && secondRange.Item2 > firstRange.Item2 &&
         secondRange.Item1 > firstRange.Item1 && secondRange.Item1 > firstRange.Item2))
    {
        continue;
    }

    count++;
}

Console.WriteLine($"answer: {count}");