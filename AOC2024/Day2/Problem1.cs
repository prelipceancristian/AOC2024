namespace AOC2024.Day2;

public class Problem1() : Day(2)
{
    public override void Run()
    {
        var lines = Utils.ReadInputLines(GetInputPath());
        var reportsList = lines
            .Select(line => line.Split().Select(int.Parse).ToList())
            .ToList();
        var count = reportsList.Count(Common.IsReportSafe);
        Console.WriteLine($"Part 1: {count}");
    }
}