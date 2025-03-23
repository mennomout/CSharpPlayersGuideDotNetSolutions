namespace Challenges.Part_2.Level_24._15_Puzzle;

public class FifteenPuzzle
{
    public int Xaxis { get; private set; }
    public int YAxis { get; private set; }

    public FifteenPuzzle(int?[] numbers, int xAxis, int yAxis)
    {
        if (xAxis * yAxis != numbers.Count())
        {
            throw new ArgumentException("The size of the array does not match the size of the grid.");
        }

        if (!numbers.Any(x => x == null) || numbers.Where(x => x == null).Count() > 1)
        {
            throw new ArgumentException("You should provide one null value in your array, this is the empty square");
        }    

        Numbers = numbers;
        Xaxis = xAxis;
        YAxis = yAxis;
    }

    public int?[] Numbers { get; private set; } = [];
    public int EmptySquareIndex => Numbers.ToList().IndexOf(null);
    public bool IsSolved => Numbers == Numbers.OrderBy(x => x).ToArray();

    public bool Move(int number)
    {
        var legalSquares = GetLegalSquaresToMove();

        if (legalSquares.Contains(number))
        {
            int numberIndex = Numbers.ToList().IndexOf(number);
            Numbers[EmptySquareIndex] = number;
            Numbers[numberIndex] = null;

            return true;
        }

        return false;
    }

    private int?[] GetLegalSquaresToMove()
    {
        var numbersList = Numbers.ToList();
        int emptySquareIndex = EmptySquareIndex;
        int emptySquareIndexYaxis = emptySquareIndex / YAxis;
        int emptySquareIndexXaxis = emptySquareIndex % Xaxis;


        List<int?> legalSquares = new();

        for (int i = 0; i < Numbers.Length; i++)
        {
            var numberPosition = GetNumberPosition(i);
            bool isAboveOrBelow = false;
            bool isLeftOrRight = false;

            if (numberPosition.X == emptySquareIndexXaxis + 1 && emptySquareIndexXaxis + 1 < Xaxis && numberPosition.Y == emptySquareIndexYaxis)
            {
                Console.WriteLine($"{Numbers[i]} its to the right");
                isLeftOrRight = true;
            }
            else if (numberPosition.X == emptySquareIndexXaxis - 1 && emptySquareIndexXaxis - 1 >= 0 && numberPosition.Y == emptySquareIndexYaxis)
            {
                Console.WriteLine($"{Numbers[i]} its to the left");
                isLeftOrRight = true;
            }    
            else if (numberPosition.Y == emptySquareIndexYaxis + 1 && emptySquareIndexYaxis + 1 < YAxis && numberPosition.X == emptySquareIndexXaxis)
            {
                Console.WriteLine($"{Numbers[i]} its above");
                isAboveOrBelow = true;
            }
            else if (numberPosition.Y == emptySquareIndexYaxis - 1 && emptySquareIndexYaxis - 1 >= 0 && numberPosition.X == emptySquareIndexXaxis)
            {
                Console.WriteLine($"{Numbers[i]} its below");
                isAboveOrBelow = true;
            }

            if (isLeftOrRight || isAboveOrBelow)
                legalSquares.Add(Numbers[i]);
        }

        return legalSquares.ToArray();
    }

    private (int X, int Y) GetNumberPosition(int? number)
    {
        if (number is null)
            Console.WriteLine("number is null");
        return number == null ? (0,0) : ((int)number % Xaxis, (int)number / YAxis);
    }
}
