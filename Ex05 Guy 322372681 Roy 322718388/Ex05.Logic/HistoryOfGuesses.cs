using System.Collections.Generic;

namespace Logic
{
    public class HistoryOfGuesses
    {
        public List<RowOfGuesses> RowOfGuesses { get; } = new List<RowOfGuesses>();

        public void AddNewRow(Guess i_Guess, FeedbackOfGuess i_Feedback)
        {
            RowOfGuesses.Add(new RowOfGuesses(i_Guess, i_Feedback));
        }
    }
}