namespace AOC2024.Day6;

public class Problem1() : Day(6)
{
    public override void Run()
    {
        var maze = Utils.ReadInputLines(GetInputPath())
            .Select(line => line.ToCharArray())
            .ToArray();
        var guard = Common.GetGuardFromMaze(maze);
        var positions = Common.RunMaze(maze, guard);
        Console.WriteLine(positions.Count);
    }
}