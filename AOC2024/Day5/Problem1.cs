namespace AOC2024.Day5;

public class Problem1() : Day(5)
{
    public override void Run()
    {
        var lines = Utils.ReadInputLines(GetInputPath());
        var emptyLineIndex = lines.IndexOf(string.Empty);
        var orderingLines = lines[..emptyLineIndex];
        var pageLines = lines[(emptyLineIndex + 1)..];
            
        var pagesList = pageLines
            .Select(x => x.Split(","))
            .ToList();
        var orderingDictionary = Common.BuildOrderingDict(orderingLines);
        var orderedLines = pagesList
            .Where(pages => Common.ArePagesOrdered(pages, orderingDictionary))
            .Select(l => l[l.Length / 2]) // take middle element for the answer
            .Sum(int.Parse);
        
        Console.WriteLine(orderedLines);
    }
}