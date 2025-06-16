using System.Collections.Generic;

namespace Ex05.Logic
{
    public class FeedbackGenerator
    {
        public static GuessFeedback CreateFeedback(GuessCombination i_UserGuess, GuessCombination i_SecretWord)
        {
            List<GuessCombination.eGuessCollectionOptions> secretList =
                new List<GuessCombination.eGuessCollectionOptions>(i_SecretWord.UserGuess);
            List<GuessCombination.eGuessCollectionOptions> guessList =
                new List<GuessCombination.eGuessCollectionOptions>(i_UserGuess.UserGuess);
            List<GuessFeedback.eFeedbackOfGuessType> feedback = new List<GuessFeedback.eFeedbackOfGuessType>();
            int pegCount = 0;

            for(int i = 0; i < guessList.Count; i++)
            {
                if(guessList[i] == secretList[i])
                {
                    // Exact–place pass
                    feedback.Add(GuessFeedback.eFeedbackOfGuessType.ExactPlace);
                    pegCount++;
                }
                else if (secretList.Contains(guessList[i]))
                {
                    // Wrong–place pass
                    feedback.Add(GuessFeedback.eFeedbackOfGuessType.WrongPlace);
                    pegCount++;
                }
            }

            // The rest
            while(SecretWordGenerator.k_SecretWordLength - pegCount > 0)
            {
                feedback.Add(GuessFeedback.eFeedbackOfGuessType.NotInGuess);
                pegCount++;
            }

            return new GuessFeedback(feedback.ToArray());
        }
    }
}