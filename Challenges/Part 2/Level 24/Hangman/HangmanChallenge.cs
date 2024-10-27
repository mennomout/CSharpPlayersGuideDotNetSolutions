using Helpers;

namespace Challenges.Part_2.Level_24.Hangman;

public class HangmanChallenge() : Challenge("Hangman")
{
    private List<char> _guesses = [];
    private string _randomWord = string.Empty;
    private int _lives = 5;

    public override void Run(object[]? parameters = null)
    {
        List<string> words = ["hello", "world", "players", "guide"];
        _randomWord = words[new Random().Next(words.Count)];

        while (_randomWord.Any(x => !_guesses.Contains(x) && _lives > 0))
        {
            Console.Write("Enter a letter to guess: ");
            char guess = char.ToLower(InputHelper.GetInputOrDefault<char>());

            if (_guesses.Contains(guess))
            {
                Console.WriteLine("You already guessed that character. Try another.");
            }
            else if (!_randomWord.Contains(guess))
            {
                _lives--;
            }

            _guesses.Add(guess);

            RenderBoard(guess);
        }

        if (_lives > 0)
        {
            Console.WriteLine($"You found the word! It was: {_randomWord}");
        }
        else
        {
            Console.WriteLine($"You failed to find the word! It was: {_randomWord}");
        }
    }

    private void RenderBoard(char currentGuess)
    {
        Console.Write("Word: ");

        foreach (var letter in _randomWord.ToList())
        {
            if (_guesses.Contains(letter))
            {
                Console.Write(letter);
            }
            else
            {
                Console.Write("_");
            }
        }

        Console.Write($" | Lives: {_lives} | ");
        Console.Write($"Incorrect: ");

        foreach (var guess in _guesses)
        {
            if (!_randomWord.Contains(guess))
            {
                Console.Write(guess);
            }
        }

        Console.WriteLine($" | Guess: {currentGuess}");
    }
}
