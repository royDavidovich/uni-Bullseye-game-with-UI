using System.Linq;
using System.Windows.Forms;
using Ex05.Logic;

namespace Ex05.UI
{
    public partial class BoolPgia : Form
    {
        private readonly ChancesSelectionForm r_ChancesSelectionForm;
        private readonly GameData m_NewGameData;
        private GuessRow m_SecretRow;

        public BoolPgia(ChancesSelectionForm i_ChancesSelectionForm)
        {
            r_ChancesSelectionForm = i_ChancesSelectionForm;
            m_NewGameData = new GameData(r_ChancesSelectionForm.NumberOfChances);
            InitializeComponent();
            addGuessRows(r_ChancesSelectionForm.NumberOfChances);
        }

        private void addGuessRows(int i_NumberOfChances)
        {
            const int k_RowHeight = 50;
            const int k_SecretRowTop = 10;
            const int k_ExtraSpaceAfterSecretRow = 10;

            m_SecretRow = new GuessRow(0);
            m_SecretRow.Left = 10;
            m_SecretRow.Top = k_SecretRowTop;
            this.Controls.Add(m_SecretRow);

            for (int i = 0; i < i_NumberOfChances; i++)
            {
                GuessRow guessRow = new GuessRow(i + 1);
                
                guessRow.Left = 10;
                guessRow.Top = k_SecretRowTop + k_RowHeight + k_ExtraSpaceAfterSecretRow + (i * k_RowHeight);
                this.Controls.Add(guessRow);
                if (i > 0)
                {
                    guessRow.Enabled = false;
                }

                guessRow.RowSubmitted += onRowSubmission;
            }
        }

        private void onRowSubmission(GuessRow i_SubmittedRow)
        {
            handleRowSubmitted(i_SubmittedRow);
        }

        private void handleRowSubmitted(GuessRow i_SubmittedRow)
        {
            GuessCombination userGuess = i_SubmittedRow.GetUserGuessCombination();
            GuessFeedback feedback = FeedbackGenerator.CreateFeedback(userGuess, m_NewGameData.SecretWordCombination);
            int exact = feedback.m_FeedbackOfGuessTypes.Count(i_FeedbackOfGuessType => i_FeedbackOfGuessType == GuessFeedback.eFeedbackOfGuessType.ExactPlace);
            int partial = feedback.m_FeedbackOfGuessTypes.Count(i_FeedbackOfGuessType => i_FeedbackOfGuessType == GuessFeedback.eFeedbackOfGuessType.WrongPlace);

            i_SubmittedRow.SetFeedback(exact, partial);
            m_NewGameData.RemainingNumberOfGuesses--;
            if (exact == SecretWordGenerator.k_SecretWordLength)
            {
                //Victory
                endGame(true);
            }
            else if (m_NewGameData.RemainingNumberOfGuesses <= 0)
            {
                //Lose
                endGame(false);
            }
            else
            {
                enableNextGuessRowAfter(i_SubmittedRow);
            }
        }

        private void enableNextGuessRowAfter(GuessRow i_CurrentRow)
        {
            bool found = false;

            foreach (Control control in this.Controls)
            {
                if (control is GuessRow currentRow)
                {
                    if (found)
                    {
                        currentRow.Enabled = true;
                        return;
                    }

                    if (currentRow == i_CurrentRow)
                    {
                        found = true;
                    }
                }
            }
        }

        private void endGame(bool i_UserWon)
        {
            m_SecretRow.SetColorsFromGuess(m_NewGameData.SecretWordCombination);
            string message = i_UserWon ? "Congratulations! You guessed the word!" : "No more guesses left. You lost!";

            MessageBox.Show(message, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            foreach (Control control in this.Controls)
            {
                if (control is GuessRow row)
                {
                    row.Enabled = false;
                }
            }
        }
    }
}