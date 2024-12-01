namespace AOC2024.Day1;

public class Problem1() : Day(1)
{
    public static int DayNumber => 1;
    
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
            .Zip(rightDistances)
            .Select(x => Math.Abs(x.First - x.Second))
            .Sum();
        Console.WriteLine($"Sum: {sum}");
    }
}