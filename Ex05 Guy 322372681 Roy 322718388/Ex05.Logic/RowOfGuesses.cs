namespace Logic
{
    public struct RowOfGuesses
    {
        public Guess UserGuess { get; }
        public FeedbackOfGuess Feedback { get; }

        public RowOfGuesses(Guess i_UserGuess, FeedbackOfGuess i_Feedback)
        {
            UserGuess = i_UserGuess;
            Feedback = i_Feedback;
        }
    }
}