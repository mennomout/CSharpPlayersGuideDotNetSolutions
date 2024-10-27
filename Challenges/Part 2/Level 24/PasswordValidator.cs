namespace Challenges.Part_2.Level_24;

public class PasswordValidator
{
    public PasswordValidator(PasswordValidatorOptions options, string password = null)
    {
        Password = password;
        Options = options;
    }

    public string? Password { get; set; }
    public PasswordValidatorOptions Options { get; set; }
    public bool IsValidPassword => !string.IsNullOrWhiteSpace(Password) &&
                                    Password.Length > Options.MinLenght &&
                                    Password.Length < Options.MaxLenght &&
                                    !Password.Any(x => Options.DisallowedCharacters.Contains(x)) &&
                                    Options.Checks.All(x => x.Invoke(Password));
}
