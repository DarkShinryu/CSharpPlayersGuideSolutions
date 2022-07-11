public class Health
{
    private int _current;

    public int Current
    {
        get => _current;
        set => _current = Math.Clamp(value, 0, Max);
    }
    public int Max { get; }

    public Health(int current, int max)
    {
        _current = current;
        Max = max;
    }
}