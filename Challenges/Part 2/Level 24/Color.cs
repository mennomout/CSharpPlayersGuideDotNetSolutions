using System.ComponentModel;

namespace Challenges.Part_2.Level_24;

public class Color
{
    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public static Color GetWhite() => new(255, 255, 255);
    public static Color GetBlack() => new(0, 0, 0);
    public static Color GetRed() => new(255, 0, 0);
    public static Color GetOrange() => new(255, 165, 0);
    public static Color GetYellow() => new(255, 255, 0);
    public static Color GetGreen() => new(0, 128, 0);
    public static Color GetBlue() => new(0, 0, 255);
    public static Color GetPurple() => new(128, 0, 128);
}
