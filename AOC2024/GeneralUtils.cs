namespace AOC2024;

public static class GeneralUtils
{
    // Not a *GREAT* permutations method, since it generates them all, yielding would be so much nicer.
    // but regardless, maybe it's useful at some point. 
    public static List<List<T>> GeneratePermutationsRec<T>(List<T> temp, List<T> bag)
    {
        if (bag.Count == 0)
        {
            return [temp];
        }

        var results = new List<List<T>>();
        for (var i = 0; i < bag.Count; i++)
        {
            var bagCopy = new List<T>(bag);
            var added = bagCopy[i];
            bagCopy.RemoveAt(i);
            
            var newTemp = temp.Append(added).ToList();
            
            var result = GeneratePermutationsRec(newTemp, bagCopy);
            results.AddRange(result);
        }
        
        return results;
    }
}