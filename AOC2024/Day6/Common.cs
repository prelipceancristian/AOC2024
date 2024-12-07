namespace AOC2024.Day6;

public static class Common
{
    internal static HashSet<ValueTuple<int, int>> RunMaze(char[][] maze, Guard guard)
    {
        // initial position counts too
        var positions = new HashSet<ValueTuple<int, int>> { (guard.Position.Item1, guard.Position.Item2) };
        while (true)
        {
            var nextPosition = guard.LookAhead();
            if (!IsInsideMazeBounds(maze, nextPosition))
            {
                break;
            }

            if (maze[nextPosition.Item1][nextPosition.Item2] == '#')
            {
                guard.Direction = guard.Direction.Rotate();
            }
            else
            {
                positions.Add(nextPosition);
                guard.Position = nextPosition;
            }
        }

        return positions;
    }

    internal static bool IsInsideMazeBounds(char[][] maze, (int, int) position)
    {
        if (position.Item1 < 0) return false;
        if (position.Item1 >= maze.Length) return false;
        if (position.Item2 < 0) return false;
        if (position.Item2 >= maze.Length) return false;
        return true;
    }
    
    internal class Guard((int, int) position, Direction direction)
    {
        public (int, int) Position { get; set; } = position;
    
        public Direction Direction { get; set; } = direction;
    
        public (int, int) LookAhead()
        {
            return Direction switch
            {
                Direction.Up => (Position.Item1 - 1, Position.Item2),
                Direction.Down => (Position.Item1 + 1, Position.Item2),
                Direction.Left => (Position.Item1, Position.Item2 - 1),
                Direction.Right => (Position.Item1, Position.Item2 + 1),
                _ => throw new ArgumentOutOfRangeException(nameof(Direction), Direction, null)
            };
        }
    }
    
    internal static Guard GetGuardFromMaze(char[][] maze)
    {
        var guardChars = new Dictionary<char, Direction>
        {
            ['^'] = Direction.Up,
            ['v'] = Direction.Down,
            ['<'] = Direction.Left,
            ['>'] = Direction.Right
        };
        for (var i = 0; i < maze.Length; i++)
        {
            for (var j = 0; j < maze[i].Length; j++)
            {
                if (guardChars.TryGetValue(maze[i][j], out var direction))
                {
                    return new Guard((i, j), direction);
                }
            }
        }
        
        throw new Exception("Could not find the initial position of the guard");
    }
}

internal enum Direction
{
    Up = 0,
    Down = 1,
    Left = 2,
    Right = 3
}

internal static class Extensions
{
    internal static Direction Rotate(this Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return Direction.Right;
            case Direction.Right:
                return Direction.Down;
            case Direction.Down:
                return Direction.Left;
            case Direction.Left:
                return Direction.Up;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }
}