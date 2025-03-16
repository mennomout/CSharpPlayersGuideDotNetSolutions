using Challenges;
using Helpers;
using System.Reflection;

namespace CSharpPlayersGuideDotNetBook;

public class Book
{
    private static readonly IEnumerable<Type>? _levels = Assembly.GetAssembly(typeof(BaseLevel))?.GetTypes().Where(static x => x.BaseType == typeof(BaseLevel));
    public static List<BaseLevel?>? Levels => _levels?.Select(x => (BaseLevel?)Assembly.GetAssembly(typeof(BaseLevel))?.CreateInstance(x.FullName ?? string.Empty))?.OrderBy(x => x?.Id).ToList();

    public void Open(string challengeName = "")
    {
        string? input = string.Empty;

        do
        {
            try
            {
                Challenge? challenge = null;

                // This if/else allows for a challenge to be executed directly for faster debugging / testing.
                if (string.IsNullOrWhiteSpace(challengeName))
                {
                    DisplayChallenges();
                    Console.WriteLine("Enter the name of the challenge you would like to see the answer to or type 'quit' to close the program.");

                    input = InputHelper.GetInputOrDefault<string>();
                    challenge = GetChallenge(input);
                }
                else
                {
                    challenge = GetChallenge(challengeName);
                }

                if (challenge != null)
                {
                    Console.Clear();
                    challenge.Run();
                    ConsoleKey? key = null;

                    while (key != ConsoleKey.Q)
                    {
                        Console.ResetColor();
                        Console.WriteLine($"Thank you for playing {challenge.Name}, press 't' to try again or 'q' to quit to the challenge overview.");
                        key = InputHelper.GetProvidedOptionsChoiceFromEnum<ConsoleKey>([ConsoleKey.T, ConsoleKey.Q]);
                        Console.Clear();

                        if (key != ConsoleKey.Q)
                        {
                            challenge.Run();
                        }
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
        return Levels?.SelectMany(x => x.Challenges)?.FirstOrDefault(x => x.Name.Equals(input, StringComparison.OrdinalIgnoreCase));
    }

    public void DisplayChallenges()
    {
        Console.WriteLine("Welcome to the C# Players Guide answers by Neowise");
        Console.WriteLine("What Level would you like to open?");

        foreach (var level in Levels ?? [])
        {
            if (level != null)
            {
                Console.WriteLine($"\t{level.Id}. {level.Name}");

                foreach (var challenge in level.Challenges)
                {
                    Console.WriteLine($"\t\t*{challenge.Name}");
                }
            }
        }
    }
}
