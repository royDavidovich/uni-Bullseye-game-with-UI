using System.Diagnostics.Eventing.Reader;

namespace Ex05.Logic
{
    public class GuessFeedback
    {
        public enum eFeedbackOfGuessType
        {
            ExactPlace,
            WrongPlace,
            NotInGuess
        }
        public eFeedbackOfGuessType[] m_FeedbackOfGuessTypes;

        public GuessFeedback(eFeedbackOfGuessType[] i_FeedbackOfGuessTypes)
        {
            m_FeedbackOfGuessTypes = i_FeedbackOfGuessTypes;
        }
    }
}