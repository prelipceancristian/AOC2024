namespace AOC2024.Day2;

public static class Common
{
    public static bool IsReportSafe(List<int> report)
    {
        const int maxLevelDifference = 3;
        var isIncreasing = Math.Sign(report[1] - report[0]);
        return report
            .Zip(report.Skip(1), (first, second) => (first, second))
            .All(levelPair =>
            {
                var (first, second) = levelPair;
                var step = (second - first) * isIncreasing;
                return step is > 0 and <= maxLevelDifference;
            });
    }
}