namespace AOC2024.Day8;

public class Problem1() : Day(8)
{
    public override void Run()
    {
        var lines = Utils.ReadInputLines(GetInputPath());
        var map = lines.Select(l => l.ToCharArray()).ToArray();
        var antennas = FindAntennas(map);
        var antinodes = FindAntinodes(antennas, map);
        Console.WriteLine(antinodes.Count);
    }

    private static bool IsAntenna(char c)
    {
        return char.IsDigit(c) || char.IsLetter(c); 
    }

    private static List<Antenna> FindAntennas(char[][] map)
    {
        var antennas = new List<Antenna>();
        for (var i = 0; i < map.Length; i++)
        {
            for (var j = 0; j < map[i].Length; j++)
            {
                if (IsAntenna(map[i][j]))
                {
                    antennas.Add(new Antenna(map[i][j], i, j));
                }
            }
        }

        return antennas;
    }

    private static List<(int, int)> FindAntinodes(List<Antenna> antennas, char[][] map)
    {
        var antinodePositions = new HashSet<(int, int)>();
        foreach (var antenna1 in antennas)
        {
            foreach (var antenna2 in antennas)
            {
                if (antenna1.X == antenna2.X || antenna1.Y == antenna2.Y ||
                    antenna1.Identifier != antenna2.Identifier)
                {
                    continue;
                }
                var antinodes = GetClosestAntinodes(map, antenna1, antenna2);
                foreach (var antinode in antinodes)
                {
                    antinodePositions.Add(antinode);
                }
            }
        }

        return antinodePositions.ToList();
    }

    private static List<(int, int)> GetClosestAntinodes(char[][] map, Antenna antenna1, Antenna antenna2)
    {
        var antinodePositions = new List<(int, int)>();
        var (verticalOffset, horizontalOffset) = GetAntinodeOffsets(antenna1, antenna2);

        var firstAntinodePosition = (antenna1.X + verticalOffset, antenna1.Y + horizontalOffset);
        if (IsPositionValid(firstAntinodePosition, map))
        {
            antinodePositions.Add(firstAntinodePosition);
        }
                    
        var secondAntinodePosition = (antenna2.X - verticalOffset, antenna2.Y - horizontalOffset);
        if (IsPositionValid(secondAntinodePosition, map))
        {
            antinodePositions.Add(secondAntinodePosition);
        }
        
        return antinodePositions;
    }

    private static (int, int) GetAntinodeOffsets(Antenna antenna1, Antenna antenna2)
    {
        var verticalOffset = antenna1.X - antenna2.X;
        var horizontalOffset = antenna1.Y - antenna2.Y;
        return (verticalOffset, horizontalOffset);
    }

    private static bool IsPositionValid((int, int) position, char[][] map)
    {
        if (position.Item1 < 0 || position.Item1 > map.Length - 1) return false;
        if (position.Item2 < 0 || position.Item2 > map[0].Length - 1) return false;
        return true;
    }
    
    
    record Antenna(char Identifier, int X, int Y);
}