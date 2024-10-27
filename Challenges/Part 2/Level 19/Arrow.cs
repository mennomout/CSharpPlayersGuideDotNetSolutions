using Helpers;

namespace Challenges.Part_2.Level_19;

public class Arrow
{
    public Arrow(Arrowhead arrowhead, Fletching fletching, float lenght)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Lenght = lenght;
    }

    public Arrow()
    {
        Arrowhead = InputHelper.GetChoiceFromEnum<Arrowhead>();
        Fletching = InputHelper.GetChoiceFromEnum<Fletching>();
        Lenght = InputHelper.GetNumberInRange("Please enter the lenght of the arrow shaft.", 60, 100);
    }

    public Arrowhead Arrowhead { get; private set; }
    public Fletching Fletching { get; private set; }
    public float Lenght { get; private set; }

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

    public static Arrow GetEliteArrow() => new(Arrowhead.Steel, Fletching.Plastic, 95f);
    public static Arrow GetBeginnerArrow() => new(Arrowhead.Wood, Fletching.GooseFeathers, 75f);
    public static Arrow GetMarksmanArrow() => new(Arrowhead.Steel, Fletching.GooseFeathers, 65f);
}
