using Challenges;
using Challenges.Part_1.Level_10;
using Challenges.Part_1.Level_11;
using Challenges.Part_1.Level_12;
using Challenges.Part_1.Level_13;
using Challenges.Part_1.Level_14;
using Challenges.Part_1.Level_8;
using Challenges.Part_1.Level_9;
using Challenges.Part_2.Level_15;
using Challenges.Part_2.Level_16;
using Challenges.Part_2.Level_17;
using Challenges.Part_2.Level_18;
using Challenges.Part_2.Level_19;
using Challenges.Part_2.Level_20;
using Challenges.Part_2.Level_21;
using Challenges.Part_2.Level_22;
using Challenges.Part_2.Level_23;
using Challenges.Part_2.Level_24;
using ChallengesPart1Level1;
using ChallengesPart1Level2;
using ChallengesPart1Level3;
using ChallengesPart1Level4;
using ChallengesPart1Level5;
using ChallengesPart1Level6;
using ChallengesPart1Level7;
using Helpers;

namespace CSharpPlayersGuideDotNetBook;

public class Book
{
    public List<BaseLevel> Levels { get; set; } = [
        new Level1(),
        new Level2(),
        new Level3(),
        new Level4(),
        new Level5(),
        new Level6(),
        new Level7(),
        new Level8(),
        new Level9(),
        new Level10(),
        new Level11(),
        new Level12(),
        new Level13(),
        new Level14(),
        new Level15(),
        new Level16(),
        new Level17(),
        new Level18(),
        new Level19(),
        new Level20(),
        new Level21(),
        new Level22(),
        new Level23(),
        new Level24()];

    public void Open()
    {
        string? input = string.Empty;

        do
        {
            try
            {
                DisplayChallenges();
                Console.WriteLine("Enter the name of the challenge you would like to see the answer to or type 'quit' to close the program.");

                input = InputHelper.GetInputOrDefault<string>();
                Challenge? challenge = GetChallenge(input);

                if (challenge != null)
                {
                    Console.Clear();
                    challenge.Run();
                    ConsoleKey? key = null;

                    while (key != ConsoleKey.Q)
                    {
                        Console.WriteLine($"Thank you for playing {challenge.Name}, press 't' to try again or 'q' to quit to the challenge overview.");
                        key = InputHelper.GetProvidedOptionsChoiceFromEnum<ConsoleKey>([ConsoleKey.T, ConsoleKey.Q]);
                        Console.Clear();
                        challenge.Run();
                    }
                }
                else
                {
                    Console.WriteLine("No challenge with that name was found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                Console.WriteLine("Program went BOOM. Check above exception message for more info. Press any key to continue.");
                Console.ReadKey(); 
            }

            Console.Clear();
            Console.ResetColor();  

        } while (input != "quit");
   }

    private Challenge? GetChallenge(string input)
    {
        return Levels.SelectMany(x => x.Challenges)?.FirstOrDefault(x => x.Name.Equals(input, StringComparison.OrdinalIgnoreCase));
    }

    public void DisplayChallenges()
    {
        Console.WriteLine("Welcome to the C# Players Guide answers by Neowise");
        Console.WriteLine("What Level would you like to open?");
        
        foreach (var level in Levels)
        {
            Console.WriteLine($"\t{level.Id}. {level.Name}");    

            foreach (var challenge in level.Challenges)
            {
                Console.WriteLine($"\t\t*{challenge.Name}");
            }
        }
    }
}
