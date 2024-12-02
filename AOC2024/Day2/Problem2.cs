namespace AOC2024.Day2;

public class Problem2() : Day(2)
{
    public override void Run()
    {
        var lines = Utils.ReadInputLines(GetInputPath());
        var reportsList = lines
            .Select(line => line.Split().Select(int.Parse).ToList())
            .ToList();
        var count = reportsList.Count(IsDampenedReportSafe);
        Console.WriteLine(count);
    }

    private static bool IsDampenedReportSafe(List<int> report)
    {
        // check if first report is already safe
        if (Common.IsReportSafe(report))
        {
            return true;
        }
        // check if by removing one level a safe report appears
        return Enumerable.Range(0, report.Count).Any(index =>
        {
            var copy = new List<int>(report);
            copy.RemoveAt(index);
            return Common.IsReportSafe(copy);
        });
    }
}