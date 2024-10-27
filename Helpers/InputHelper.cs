using System.Globalization;

namespace Helpers;

public static class InputHelper
{
    public static T? GetRequiredInput<T>(IEnumerable<T> options, bool displayOptions = true) where T : IParsable<T>
    {
        ArgumentNullException.ThrowIfNull(options);

        if (displayOptions)
        {
            foreach (var option in options)
            {
                Console.WriteLine(option);
            }
        }

        string? input = GetInputOrDefault<string>();

        if (T.TryParse(input, null, out T? result))
        {
            if (options.Any(x => x.Equals(result)))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Your input was valid but does not match any of the provided options. Try again:");
                return GetRequiredInput<T>(options);
            }
        }

        Console.WriteLine("The input was invalid. Please make sure to format you input so it can be parsed. Try again:");

        return GetRequiredInput<T>(options);
    }
    
    public static T GetProvidedOptionsChoiceFromEnum<T>(IEnumerable<T> options) where T : struct, Enum
    {
        ArgumentNullException.ThrowIfNull(options);

        T choice = GetChoiceFromEnum<T>(false);

        if (options.Any(x => x.Equals(choice)))
        {
            return choice;
        }

        return GetProvidedOptionsChoiceFromEnum<T>(options);
    }

    public static T GetChoiceFromEnum<T>(bool printOptions = true) where T : struct, Enum
    {
        var options = Enum.GetNames(typeof(T));

        if (printOptions)
        {
            Console.WriteLine("Choose one of the following options:");

            foreach (var option in options)
            {
                Console.WriteLine(option);
            }
        }

        string? choice = GetInputOrDefault<string>("Enter your choice");

        if (Enum.TryParse(choice, true, out T result))
        {
            return result;
        }
        else
        {
            Console.WriteLine("That was not a valid choice.");
            
            return GetChoiceFromEnum<T>();
        }
    }

    public static int GetNumberInRange(string message, int min, int max)
    {
        int number = GetInputOrDefault<int>(message);

        while (number < min || number > max) number = GetNumberInRange($"That number is not within the correct range ({min} - {max}), try again.", min, max);

        return number;
    }

    public static T? GetInputOrDefault<T>(string message) where T : IParsable<T>
    {
        Console.Write($"{message}: ");

        return GetInputOrDefault<T>();
    }

    public static T? GetInputOrDefault<T>() where T : IParsable<T>
    {
        string? input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input) && T.TryParse(input, null, out T? result))
        {
            return result == null ? default : result;
        }

        return default;
    }
}
