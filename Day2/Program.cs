using Day2;

FirstStar.Get();
SecondStar.Get();

Console.WriteLine($"Total score: {FirstStar.Rounds.Sum()}");
Console.WriteLine($"Total score part two: {SecondStar.Rounds.Sum()}");