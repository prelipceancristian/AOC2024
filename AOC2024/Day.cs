namespace AOC2024;

public abstract class Day
{
    private readonly int _dayNumber;

    protected Day(int dayNumber)
    {
        _dayNumber = dayNumber;
    }

    protected string GetInputPath()
    {
        return Path.Combine("../../../", "Inputs", $"day{_dayNumber}.txt");
    }

    public abstract void Run();
}