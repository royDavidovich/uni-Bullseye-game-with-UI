using System.Collections.Generic;

namespace Ex05.Logic
{
    public class GameData
    {   
        public readonly int r_MaxUserGuesses;
        public int RemainingNumberOfGuesses { get; set; }

        public GuessCombination SecretWordCombination { get; private set; }
        public GuessCombination UserGuessCombination { get; set; }
        public GuessesHistory GuessesHistory { get; set; }

        public GameData(int i_MaxUserGuesses)
        {
            SecretWordCombination = SecretWordGenerator.GenerateSecretWord();
            GuessesHistory = new GuessesHistory();
            r_MaxUserGuesses = i_MaxUserGuesses;
            RemainingNumberOfGuesses = i_MaxUserGuesses;
        }

        public void AddGuessAndFeedback(GuessCombination i_GuessCombination, GuessFeedback i_GuessFeedback)
        {
            GuessesHistory.AddGuessAttempt(i_GuessCombination, i_GuessFeedback);
        }
    }
}