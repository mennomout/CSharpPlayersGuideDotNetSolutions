using Challenges.Part_2.Level_24._15_Puzzle;
using Challenges.Part_2.Level_24.Hangman;
using Challenges.Part_2.Level_24.Rock_Paper_Scissors;
using Challenges.Part_2.Level_24.Tic_Tac_Toe;

namespace Challenges.Part_2.Level_24;

public class Level24() : BaseLevel(24, "The Catacombs of the Class", [
    new ThePointChallenge(),
    new TheColorChallenge(),
    new TheCardChallenge(),
    new TheLockedDoorChallenge(),
    new ThePasswordValidatorChallenge(),
    new RockPaperScissorsChallange(),
    new FifteenPuzzleChallenge(),
    new HangmanChallenge(),
    new TicTacToeChallenge()])
{
}
