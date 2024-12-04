using System.Text.RegularExpressions;

namespace AOC2024.Day3;

public class Problem1() : Day(3)
{
    public override void Run()
    {
        var lines = Utils.ReadInputLines(GetInputPath());
        const string pattern = @"mul\(\d+,\d+\)";
        var regex = new Regex(pattern);
        var content = string.Join(' ', lines);
        var matches = regex.Matches(content);
        var sum = matches.Select(m => ParseMul(m.Value)).Sum();
        Console.WriteLine(sum);
    }

    private int ParseMul(string value)
    {
        var splitted = value.Split(',');
        var first = int.Parse(splitted[0][4..]);
        var second = int.Parse(splitted[1][..^1]);
        return first * second;
    }
    
    
}