Color orange = new Color(255, 128, 0);
Color cyan = Color.Cyan;

orange.DisplayColor();
cyan.DisplayColor();

public class Color
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }

    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public static Color White  { get; } = new Color(255, 255, 255);
    public static Color Black  { get; } = new Color(  0,   0,   0);
    public static Color Red    { get; } = new Color(255,   0,   0);
    public static Color Green  { get; } = new Color(  0, 255,   0);
    public static Color Blue   { get; } = new Color(  0,   0, 255);
    public static Color Yellow { get; } = new Color(255, 255,   0);
    public static Color Pink   { get; } = new Color(255, 128, 255);
    public static Color Cyan   { get; } = new Color(  0, 255, 255);

    public void DisplayColor() => Console.WriteLine($"R: {R,3} G: {G,3} B: {B,3}");
}