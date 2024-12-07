namespace AOC2024.Day4;

public class Problem2() : Day(4)
{
    public override void Run()
    {
        var lines = Utils.ReadInputLines(GetInputPath());
        var chars = lines.Select(l => l.ToCharArray()).ToArray();
        var sum = chars
            .SelectMany((row, i) => row.Select((_, j) => (i, j)))
            .Count(pos => IsMas(chars, pos.i, pos.j));

        Console.WriteLine(sum);
    }

    private bool IsMas(char[][] chars, int i, int j)
    {
        if (i == 0 || i == chars.Length - 1)
        {
            return false;
        }

        if (j == 0 || j == chars[0].Length - 1)
        {
            return false;
        }

        return CheckDiagonal(chars[i - 1][j - 1], chars[i][j], chars[i + 1][j + 1]) &&
               CheckDiagonal(chars[i - 1][j + 1], chars[i][j], chars[i + 1][j - 1]);
    }

    private bool CheckDiagonal(char left, char middle, char right)
    {
        var option1 = new string(new[] { left, middle, right });
        var option2 = new string(new[] { right, middle, left });
        return option1 == "MAS" || option2 == "MAS";
    }
}