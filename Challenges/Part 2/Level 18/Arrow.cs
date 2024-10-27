namespace Challenges.Part_2.Level_18;

public class Arrow
{
    public Arrowhead Arrowhead { get; set; }
    public Fletching Fletching { get; set; }
    public float Lenght { get; set; }

    public float GetCost()
    {
        float cost = 0;

        cost += Arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            _ => 5
        };

        cost += Fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            _ => 3
        };

        return cost += Lenght * 0.05f;
    }
}
