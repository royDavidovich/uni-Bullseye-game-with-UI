using System.Collections.Generic;

namespace Logic
{
    public static class GuessComparer
    {
        public static FeedbackOfGuess Compare(Guess i_UserGuess, Guess i_SecretWord)
        {
            int length = i_UserGuess.userGuess.Count;
            FeedbackOfGuess.eFeedbackOfGuessType[] feedbackArray = new FeedbackOfGuess.eFeedbackOfGuessType[length];

            bool[] secretMatched = new bool[length];
            bool[] guessMatched = new bool[length];

            for (int i = 0; i < length; i++)
            {
                if (i_UserGuess.userGuess[i] == i_SecretWord.userGuess[i])
                {
                    feedbackArray[i] = FeedbackOfGuess.eFeedbackOfGuessType.ExactPlace;
                    secretMatched[i] = true;
                    guessMatched[i] = true;
                }
            }

            for (int i = 0; i < length; i++)
            {
                if (!guessMatched[i])
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (!secretMatched[j] &&
                            i_UserGuess.userGuess[i] == i_SecretWord.userGuess[j])
                        {
                            feedbackArray[i] = FeedbackOfGuess.eFeedbackOfGuessType.WrongPlace;
                            secretMatched[j] = true;
                            guessMatched[i] = true;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < length; i++)
            {
                if (!guessMatched[i])
                {
                    feedbackArray[i] = FeedbackOfGuess.eFeedbackOfGuessType.NotInGuess;
                }
            }

            return new FeedbackOfGuess(feedbackArray);
        }
    }
}
