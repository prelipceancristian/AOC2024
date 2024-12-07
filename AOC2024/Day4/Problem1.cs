namespace AOC2024.Day4;

public class Problem1() : Day(4)
{
    private const int Length = 4;
    public override void Run()
    {
        // go item by item, search horizontally, vertically, diagonally, assuming current cell is the start of the word
        var lines = Utils.ReadInputLines(GetInputPath());
        var chars = lines.Select(l => l.ToCharArray()).ToArray();
        var sum = 0;
        for (var i = 0; i < chars.Length; i++)
        {
            for (var j = 0; j < chars[0].Length; j++)
            {
                sum += GetXmasCount(chars, i, j);
            }
        }
        
        Console.WriteLine(sum);
    }

    private static int GetXmasCount(char[][] chars, int i, int j)
    {
        var sum = 0;
        sum += CheckXmasVertically(chars, i, j);
        sum += CheckXmasHorizontally(chars, i, j);
        sum += CheckXmasDiagonally(chars, i, j);
        return sum;
    }

    private static int CheckXmasHorizontally(char[][] chars, int i, int j)
    {
        var sum = 0;
        // up
        if (j >= Length - 1)
        {
            if (IsXmas(chars[i][j], chars[i][j - 1], chars[i][j - 2], chars[i][j - 3]))
            {
                sum++;
            }
        }

        // down
        if (j <= chars[0].Length - Length)
        {
            if (IsXmas(chars[i][j], chars[i][j + 1], chars[i][j + 2], chars[i][j + 3]))
            {
                sum++;
            }
        }
        
        return sum;
    }

    private static int CheckXmasVertically(char[][] chars, int i, int j)
    {
        var sum = 0;
        // left, reversed
        if (i >= Length - 1)
        {
            if (IsXmas(chars[i][j], chars[i - 1][j], chars[i - 2][j], chars[i - 3][j]))
            {
                sum++;
            }
        }

        // right
        if (i <= chars.Length - Length)
        {
            if (IsXmas(chars[i][j], chars[i + 1][j], chars[i + 2][j], chars[i + 3][j]))
            {
                sum++;
            }
        }

        return sum;
    }

    private static int CheckXmasDiagonally(char[][] chars, int i, int j)
    {
        var sum = 0;
        // left up
        if (i >= Length - 1 && j >= Length - 1)
        {
            if (IsXmas(chars[i][j], chars[i - 1][j - 1], chars[i - 2][j - 2], chars[i - 3][j - 3]))
            {
                sum++;
            }
        }

        // right up
        if (i <= chars.Length - Length && j >= Length - 1)
        {
            if (IsXmas(chars[i][j], chars[i + 1][j - 1], chars[i + 2][j - 2], chars[i + 3][j - 3]))
            {
                sum++;
            }
        }

        // left down
        if (i >= Length - 1 && j <= chars[0].Length - Length)
        {
            if (IsXmas(chars[i][j], chars[i - 1][j + 1], chars[i - 2][j + 2], chars[i - 3][j + 3]))
            {
                sum++;
            }
        }

        // right down
        if (i <= chars.Length - Length && j <= chars[0].Length - Length)
        {
            if (IsXmas(chars[i][j], chars[i + 1][j + 1], chars[i + 2][j + 2], chars[i + 3][j + 3]))
            {
                sum++;
            }
        }

        return sum;
    }

    private static bool IsXmas(char c1, char c2, char c3, char c4)
    {
        return c1 == 'X' && c2 == 'M' && c3 == 'A' && c4 == 'S';
    }
}