using System.Text.RegularExpressions;

namespace AOC2024.Day3;

public class Problem2(): Day(3)
{
    public override void Run()
    {
        var lines = Utils.ReadInputLines(GetInputPath());
        const string pattern = @"mul\(\d+,\d+\)";
        const string doPattern = @"do\(\)";
        const string dontPattern = @"don\'t\(\)";
        var mulRegex = new Regex(pattern);
        var doRegex = new Regex(doPattern);
        var dontRegex = new Regex(dontPattern);
        var content = string.Join(' ', lines);
        var matches = mulRegex.Matches(content);
        var doMatches = doRegex.Matches(content);
        var dontMatches = dontRegex.Matches(content);
        var sum = matches.Select(m => ParseMul(m, doMatches, dontMatches)).Sum();
        Console.WriteLine(sum);
    }
    
    private int ParseMul(Match mulMatch, MatchCollection doMatches, MatchCollection dontMatches)
    {
        if (!IsMulEnabled(mulMatch.Index, doMatches, dontMatches))
        {
            return 0;
        }
        var splitted = mulMatch.Value.Split(',');
        var first = int.Parse(splitted[0][4..]);
        var second = int.Parse(splitted[1][..^1]);
        return first * second;
    }

    private bool IsMulEnabled(int position, MatchCollection doMatches, MatchCollection dontMatches)
    {
        var previousDoMatch = doMatches.LastOrDefault(m => m.Index < position)?.Index ?? 0;
        var previousDontMatch = dontMatches.LastOrDefault(m => m.Index < position)?.Index ?? int.MinValue;
        return previousDoMatch > previousDontMatch;
    }
}