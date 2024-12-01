namespace AOC2024.Day1;

public class Problem2() : Day(1)
{
    public override void Run()
    {
        var inputLines = Utils.ReadInputLines(GetInputPath());
        var distances = inputLines.Select(l => l.Split(' ')).ToList();
        var leftDistances = distances
            .Select(dist => dist[0])
            .Select(int.Parse)
            .Order();
        var rightDistances = distances
            .Select(dist => dist[^1])
            .Select(int.Parse)
            .Order();

        var sum = leftDistances
            .Sum(x => x * rightDistances.Count(y => y == x));
        
        Console.WriteLine($"Sum: {sum}");
    }
}