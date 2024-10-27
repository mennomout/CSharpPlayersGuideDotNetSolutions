using Helpers;

namespace Challenges.Part_2.Level_24;

public class ThePasswordValidatorChallenge() : Challenge("The Password Validator")
{
    public override void Run(object[]? parameters = null)
    {
        PasswordValidatorOptions options = new()
        {
            MinLenght = 6,
            MaxLenght = 13,
            DisallowedCharacters = ['T', '&'],
            Checks = [
                (string password) => password.Any(x => char.IsUpper(x)),
                (string password) => password.Any(x => char.IsLower(x)),
                (string password) => password.Any(x => char.IsDigit(x)),
                ]
        };

        PasswordValidator validator = new(options);

        do
        {
            Console.Write("Please enter a password to validate: ");
            validator.Password = InputHelper.GetInputOrDefault<string>();
        } while (!validator.IsValidPassword);

        Console.WriteLine($"Password '{validator.Password}' is a valid password.");
    }
}
