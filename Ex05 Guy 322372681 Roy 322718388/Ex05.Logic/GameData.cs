namespace Logic
{
    public class GameData
    {   
        public readonly int r_MaxUserGuesses;
        public int RemainingNumberOfGuesses { get; set; }
        public Guess SecretWord { get; set; }
        public HistoryOfGuesses HistoryOfGuesses { get; set; }

        public GameData(Guess i_SecretWord, int i_MaxUserGuesses)
        {
            SecretWord = i_SecretWord;
            HistoryOfGuesses = new HistoryOfGuesses();
            r_MaxUserGuesses = i_MaxUserGuesses;
            RemainingNumberOfGuesses = i_MaxUserGuesses;
        }

        public void AddGuessAndFeedback(Guess i_Guess, FeedbackOfGuess i_Feedback)
        {
            HistoryOfGuesses.AddNewRow(i_Guess, i_Feedback);
        }
    }
}