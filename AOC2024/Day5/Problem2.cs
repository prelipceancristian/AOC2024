namespace AOC2024.Day5;

public class Problem2() : Day(5)
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
            .Where(pages => !Common.ArePagesOrdered(pages, orderingDictionary))
            .Select(pages => OrderPages(pages, orderingDictionary))
            .Select(l => l[l.Length / 2]) // take middle element for the answer
            .Sum(int.Parse);
        
        Console.WriteLine(orderedLines);
    }

    private static string[] OrderPages(string[] pages, Dictionary<string, List<string>> orderingDictionary)
    {
        // let's just do a bubble sort lol
        for (var i = 0; i < pages.Length; i++)
        {
            for (var j = i + 1; j < pages.Length; j++)
            {
                if (!Common.IsSmaller(pages[i], pages[j], orderingDictionary))
                {
                    (pages[i], pages[j]) = (pages[j], pages[i]);
                }
            }
        }
        
        return pages;
    }

}