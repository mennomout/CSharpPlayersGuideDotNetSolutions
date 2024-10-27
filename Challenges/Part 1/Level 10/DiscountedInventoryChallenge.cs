using Helpers;

namespace Challenges.Part_1.Level_10;

public class DiscountedInventoryChallenge() : Challenge("Discounted Inventory")
{
    private List<string> _premiumCustomers = ["Neowise", "Santa", "RB", "Bernie"];

    public override void Run(object[]? parameters = null)
    {
        var storeItems = new List<string>()
        {
            "Rope",
            "Torches",
            "Climbing Equipment",
            "Clean Water",
            "Machete",
            "Canoe",
            "Food Supplies"
        };

        Console.Write("Hello, what is your name? ");
        string? name = InputHelper.GetInputOrDefault<string>();
        bool isPremiumCustomer = _premiumCustomers.Any(x => x.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (isPremiumCustomer)
        {
            Console.WriteLine($"Ah welcome {name}! You can buy items at a discounted price (50% discount).");
        }

        Console.WriteLine("The following items are available:");

        for (int i = 0; i < storeItems.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {storeItems[i]}");
        }

        Console.Write("What number do you want to see the price of? ");
        string choice = storeItems[InputHelper.GetInputOrDefault<int>() - 1];
        int value = choice switch
        {
            "Rope" => 10,
            "Torch" => 16,
            "Climbing Equipment" => 24,
            "Clean Water" => 2,
            "Machete" => 20,
            "Canoe" => 200,
            "Food" => 2,
            _ => 0
        };

        Console.WriteLine($"{choice} costs {(isPremiumCustomer ? value / 2 : value)} gold.");
    }
}
