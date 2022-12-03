using System.Reflection;

namespace Day2;

public static class SecondStar
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
            var columns = line!.Split(' ');
            var opponentPlay = char.Parse(columns.First());
            var whatNeedsToHappen = char.Parse(columns.Last());

            int losingPlay;
            switch (whatNeedsToHappen)
            {
                // lose
                case 'X':
                    losingPlay = (letterPointsLookUp[opponentPlay] + 2) % 3;
                    score += losingPlay == 0 ? 3 : losingPlay;
                    break;
                // draw
                case 'Y':
                    score += letterPointsLookUp[opponentPlay];
                    score += 3;
                    break;
                // win
                case 'Z':
                    losingPlay = (letterPointsLookUp[opponentPlay] + 1) % 3;
                    score += losingPlay == 0 ? 3 : losingPlay;
                    score += 6;
                    break;
            }

            Rounds.Add(score);
            score = 0;
        }
    }
}