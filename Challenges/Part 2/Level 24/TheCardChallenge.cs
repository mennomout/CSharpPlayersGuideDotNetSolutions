namespace Challenges.Part_2.Level_24;

public class TheCardChallenge() : Challenge("The Card")
{
    public override void Run(object[]? parameters = null)
    {
        for (int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 14; j++)
            {

                Card card = new((CardColorEnum)i, (CardRankEnum)j);
                Console.WriteLine($"The {card.Color} {card.Rank}");
            }
        }

        Console.WriteLine("Cards can only be four colors. For such a small list of options an enum is perfect. We don't need 255 * 255 * 255 color options.");
    }
}
