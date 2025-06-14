namespace Ex05.Logic
{
    public struct GuessAttempt
    {
        public GuessCombination GuessCombination { get; }
        public GuessFeedback GuessFeedback { get; }

        public GuessAttempt(GuessCombination i_GuessCombination, GuessFeedback i_GuessFeedback)
        {
            GuessCombination = i_GuessCombination;
            GuessFeedback = i_GuessFeedback;
        }
    }
}