namespace AOC2024;

public static class Utils
{
    public static List<string> ReadInputLines(string fileName)
    {
        return File.ReadAllLines(fileName).ToList();
    }
}