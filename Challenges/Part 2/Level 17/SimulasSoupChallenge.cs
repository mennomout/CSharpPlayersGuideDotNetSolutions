using Helpers;

namespace Challenges.Part_2.Level_17;

public class SimulasSoupChallenge() : Challenge("Simula's Soup")
{
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("Choose and build your own food:");

        (Food, MainIngredient, Seasoning) food = new(
            InputHelper.GetChoiceFromEnum<Food>(),
            InputHelper.GetChoiceFromEnum<MainIngredient>(),
            InputHelper.GetChoiceFromEnum<Seasoning>());

        Console.WriteLine($"Enjoy your {food.Item3} {food.Item2} {food.Item1}!");
    }
}
