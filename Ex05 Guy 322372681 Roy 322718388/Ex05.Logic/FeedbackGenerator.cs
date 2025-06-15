using System.Collections.Generic;
using System.Linq;

namespace Ex05.Logic
{
    public class FeedbackGenerator
    {
        public static GuessFeedback CreateFeedback(GuessCombination i_UserGuess, GuessCombination i_SecretWord)
        {
            List<GuessFeedback.eFeedbackOfGuessType> feedback = new List<GuessFeedback.eFeedbackOfGuessType>();
            List<GuessCombination.eGuessCollectionOptions> secret = new List<GuessCombination.eGuessCollectionOptions>(i_SecretWord.UserGuess);
            List<GuessCombination.eGuessCollectionOptions> guess = new List<GuessCombination.eGuessCollectionOptions>(i_UserGuess.UserGuess);

            // Exact matches
            for (int i = 0; i < guess.Count; i++)
            {
                if (guess[i] == secret[i])
                {
                    feedback.Add(GuessFeedback.eFeedbackOfGuessType.ExactPlace);
                    guess[i] = secret[i] = default; // Mark as used
                }
            }

            // Partial matches
            for (int i = 0; i < guess.Count; i++)
            {
                if (!Equals(guess[i], default) && secret.Contains(guess[i]))
                {
                    feedback.Add(GuessFeedback.eFeedbackOfGuessType.WrongPlace);
                    secret[secret.IndexOf(guess[i])] = default; // Mark as used
                }
            }

            // Fill the rest with NotInGuess
            while (feedback.Count < SecretWordGenerator.k_SecretWordLength)
            {
                feedback.Add(GuessFeedback.eFeedbackOfGuessType.NotInGuess);
            }

            return new GuessFeedback(feedback.ToArray());
        }
    }
}