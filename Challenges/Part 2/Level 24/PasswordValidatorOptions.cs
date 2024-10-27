namespace Challenges.Part_2.Level_24;

public struct PasswordValidatorOptions
{
    public PasswordValidatorOptions(int minLenght, int maxLenght, char[] disallowedCharacters, Func<string, bool>[] checks)
    {
        MinLenght = minLenght;
        MaxLenght = maxLenght;
        DisallowedCharacters = disallowedCharacters;
        Checks = checks;
    }

    public int MinLenght { get; set; }
    public int MaxLenght { get; set; }
    public char[] DisallowedCharacters { get; set; }
    public Func<string, bool>[] Checks { get; set; }
}
