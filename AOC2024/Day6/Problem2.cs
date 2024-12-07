namespace AOC2024.Day6;

public class Problem2() : Day(6)
{
    public override void Run()
    {
        // idea: a loop is detected if a position is passed twice with the same direction.
        var maze = Utils.ReadInputLines(GetInputPath())
            .Select(line => line.ToCharArray())
            .ToArray();
        var guard = Common.GetGuardFromMaze(maze);
        var initialPosition = guard.Position;
        var positions = Common.RunMaze(maze, guard);
        // cannot place obstacle on the first position
        positions.Remove(initialPosition);
        var count = 0;
        foreach (var position in positions)
        {
            // place obstacle on the path
            maze[position.Item1][position.Item2] = '#';
            if (HasLoop(maze))
            {
                count++;
            }
            maze[position.Item1][position.Item2] = '.';
        }
        
        Console.WriteLine(count);
    }

    private static bool HasLoop(char[][] maze)
    {
        // slightly adjusted compared to part 1.
        // instead of checking only the location, check the direction. 
        // going on the same place twice in the same direction will result in going on a previous path, 
        // thus a loop.
        var guard = Common.GetGuardFromMaze(maze);
        var positionStates = new HashSet<ValueTuple<ValueTuple<int, int>, Direction>>
        {
            (guard.Position, guard.Direction)
        };
        while (true)
        {
            var nextPosition = guard.LookAhead();
            if (!Common.IsInsideMazeBounds(maze, nextPosition))
            {
                // reached the end. no loop was detected. 
                return false;
            }

            if (maze[nextPosition.Item1][nextPosition.Item2] == '#')
            {
                guard.Direction = guard.Direction.Rotate();
            }
            else
            {
                var positionState = (nextPosition, guard.Direction);
                if (!positionStates.Add(positionState))
                {
                    return true;
                }

                guard.Position = nextPosition;
            }
        }
    }
}