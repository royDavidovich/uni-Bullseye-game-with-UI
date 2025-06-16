using System.Collections.Generic;

namespace Ex05.Logic
{
    public class GuessesHistory
    {
        public List<GuessAttempt> UserGuessAttempts { get; } = new List<GuessAttempt>();

        public void AddGuessAttempt(GuessCombination i_GuessCombination, GuessFeedback i_GuessFeedback)
        {
            UserGuessAttempts.Add(new GuessAttempt(i_GuessCombination, i_GuessFeedback));
        }
    }
}