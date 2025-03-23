using Helpers;

namespace Challenges.Part_2.Level_31;

public class TheFountainOfObjectsBossBattle() : Challenge("The Fountain of Objects Game")
{
    public override void Run(object[]? parameters = null)
    {
        Console.WriteLine("What size do you want the dungeon to be?");
        var size = InputHelper.GetChoiceFromEnum<SizeEnum>();

        FountainGame fountainGame = new(size);
        fountainGame.Run();
    }
}
