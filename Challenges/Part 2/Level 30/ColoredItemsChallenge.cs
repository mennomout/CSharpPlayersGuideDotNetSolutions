namespace Challenges.Part_2.Level30;

public class ColoredItemsChallenge() : Challenge("Colored Items")
{
    public override void Run(object[]? parameters = null)
    {
        ColoredItem<Sword> sword = new() { Color = ConsoleColor.DarkCyan };
        ColoredItem<Bow> bow = new() { Color = ConsoleColor.DarkRed };
        ColoredItem<Axe> axe = new() { Color = ConsoleColor.DarkYellow };

        sword.Display();
        bow.Display();
        axe.Display();
    }
}

public class ColoredItem<T>
{
    public ConsoleColor Color { get; set; }

    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(this.ToString());
    }
}

public class Sword { }
public class Bow { }
public class Axe { }
