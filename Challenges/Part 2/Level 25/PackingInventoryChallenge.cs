using Helpers;

namespace Challenges.Part_2.Level_25;

public class PackingInventoryChallenge() : Challenge("Packing Inventory")
{
    public override void Run(object[]? parameters = null)
    {
        Pack pack = new(10, 15, 30);

        string? input = string.Empty;

        while (input != "q")
        {
            Console.WriteLine($"Pack your pack! (Or exit by entering 'q'.");
            Console.WriteLine($"Current pack status, number of items: {pack.CurrentItemCount}, weight: {pack.CurrentWeight}, volume: {pack.CurrentVolume}.");

            input = InputHelper.GetRequiredInput(new List<string>()
            {
                nameof(Arrow),
                nameof(Bow),
                nameof(Rope),
                nameof(Water),
                nameof(Rations),
                nameof(Sword),
            });

            bool addedToPack = input switch
            {
                nameof(Arrow) => pack.Add(new Arrow()),
                nameof(Bow) => pack.Add(new Bow()),
                nameof(Rope) => pack.Add(new Rope()),
                nameof(Water) => pack.Add(new Water()),
                nameof(Rations) => pack.Add(new Rations()),
                nameof(Sword) => pack.Add(new Sword()),
                _ => false
            };

            Console.Clear();

            if (addedToPack)
            {
                Console.WriteLine($"You added {input!.ToLower()} to your pack.");
            }
            else
            {
                Console.WriteLine($"{input!.ToLower()} did not fit in your pack.");
            }

            Console.WriteLine();
        }
    }
}

public class Pack(int maxItems, float maxWeight, float maxVolume)
{
    private readonly List<InventoryItem> _items = [];

    public int MaxItems { get; } = maxItems;
    public float MaxWeight { get; } = maxWeight;
    public float MaxVolume { get; } = maxVolume;
    public int CurrentItemCount => _items.Count;
    public float CurrentWeight => _items.Select(x => x.Weight).Sum();
    public float CurrentVolume => _items.Select(x => x.Volume).Sum();

    public bool Add(InventoryItem item)
    {
        if (CurrentItemCount > MaxItems || CurrentWeight > MaxWeight || CurrentVolume > MaxVolume)
        {
            return false;
        }

        _items.Add(item);

        return true;    
    }
}

public class InventoryItem(float weight, float volume)
{
    public float Weight { get; } = weight;
    public float Volume { get; } = volume;
}

public class Arrow() : InventoryItem(0.1f, 0.05f);
public class Bow() : InventoryItem(1, 4);
public class Rope() : InventoryItem(1, 1.5f);
public class Water() : InventoryItem(2, 3);
public class Rations() : InventoryItem(1, 1.5f);
public class Sword() : InventoryItem(5, 3);
