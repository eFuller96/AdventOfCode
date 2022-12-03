using System.Reflection;

namespace Day2;

public static class FirstStar
{
    public static List<int> Rounds { get; } = new();

    public static void Get()
    {
        var score = 0;
        var letterPointsLookUp = new Dictionary<char, int>
            { { 'A', 1 }, { 'B', 2 }, { 'C', 3 }, { 'X', 1 }, { 'Y', 2 }, { 'Z', 3 } };

        using var streamReader =
            File.OpenText(
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "input.txt"));

        while (!streamReader.EndOfStream)
        {
            var line = streamReader.ReadLine();
            var optionsPlayed = line!.Split(' ');
            var myLetterPlayed = char.Parse(optionsPlayed.Last());

            // get point for option played
            score += letterPointsLookUp[myLetterPlayed];

            var sum = letterPointsLookUp[char.Parse(optionsPlayed.First())] +
                      letterPointsLookUp[myLetterPlayed];

            switch (sum)
            {
                case 2:
                    // draw
                    score += 3;
                    break;
                case 3:
                {
                    if (myLetterPlayed == 'Y')
                    {
                        // win
                        score += 6;
                    }

                    break;
                }
                case 4 when myLetterPlayed == 'X':
                    // win
                    score += 6;
                    break;
                case 4:
                {
                    if (myLetterPlayed == 'Y')
                    {
                        // draw
                        score += 3;
                    }

                    break;
                }
                case 5:
                {
                    if (myLetterPlayed == 'Z')
                    {
                        // win
                        score += 6;
                    }

                    break;
                }
                case 6:
                    // draw
                    score += 3;
                    break;
            }

            Rounds.Add(score);
            score = 0;
        }
    }
}