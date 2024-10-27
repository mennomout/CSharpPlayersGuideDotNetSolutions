namespace Helpers;

public static class DisplayHelper
{ 
    public static void DisplayColoredText(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}
