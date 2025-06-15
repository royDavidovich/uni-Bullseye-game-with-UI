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
        public bool IsVictory { get; set; } = false;

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

        //public GuessFeedback SubmitGuess(GuessCombination i_UserGuess)
        //{
        //    GuessFeedback feedback = FeedbackGenerator.CreateFeedback(i_UserGuess, SecretWordCombination);

        //    AddGuessAndFeedback(i_UserGuess, feedback);
        //    RemainingNumberOfGuesses--;

        //    if (feedback.ExactMatches == SecretWordCombination.UserGuess.Count)
        //    {
        //        IsVictory = true;
        //    }

        //    return feedback;
        //}

    }
}