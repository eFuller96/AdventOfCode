using System.Reflection;


char answer;

const int firstStar = 4;
const int secondStar = 14;

Get(firstStar);
Get(secondStar);

void Get(int length)
{
    using var streamReader =
        File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "input.txt"));

    while (!streamReader.EndOfStream)
    {
        var line = streamReader.ReadLine();

        for (var i = 0; i < line!.Length; i++)
        {
            var windowToCheck = line.Substring(i, length);
            if (windowToCheck.Distinct().Count() == length)
            {
                Console.WriteLine($"answer: {i+length}");
                break;
            }
        }
    }
}
