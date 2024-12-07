namespace AOC2024.Day5;

public static class Common
{
    public static Dictionary<string, List<string>> BuildOrderingDict(List<string> orderingLines)
    {
        var dict = orderingLines.Aggregate(
            seed: new Dictionary<string, List<string>>(),
            (orderingDict, line) =>
            {
                var numbers = line.Split("|");
                var first = numbers[0];
                var second = numbers[1];
                if (!orderingDict.TryGetValue(first, value: out var greaterThan))
                {
                    orderingDict.Add(first, [second]);
                }
                else
                {
                    greaterThan.Add(second);
                }
                
                return orderingDict;
            });

        return dict;
    }

    public static bool ArePagesOrdered(string[] pages, Dictionary<string, List<string>> orderingDict)
    {
        for (var i = 0; i < pages.Length - 1; i++)
        {
            var page = pages[i];
            var followingPages = pages[(i + 1)..];
            if (followingPages.Any(fp => IsSmaller(fp, page, orderingDict)))
            {
                return false;
            }
        }

        return true;
    }
    
    public static bool IsSmaller(string first, string second, Dictionary<string, List<string>> orderingDictionary)
    {
        var greaterThanFirst = orderingDictionary.TryGetValue(first, out var value) ? value : [];
        return greaterThanFirst.Contains(second);
    }
}