namespace Challenges.Part_2.Level_24;

public class Card
{
    public Card(CardColorEnum color, CardRankEnum rank)
    {
        Color = color;
        Rank = rank;
    }

    public CardColorEnum Color { get; set; }
    public CardRankEnum Rank { get; set; }
    public bool IsRank => (int)Rank > 9;
}
