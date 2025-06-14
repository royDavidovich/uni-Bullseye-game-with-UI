using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Logic;

namespace BullsEyeUI
{
    public class FormMain : Form
    {
        private const int k_ButtonSize = 30;
        private const int k_GuessRowsSpacing = 50;

        private readonly Button m_NumOfGuessesButton = new Button();
        private readonly Button m_StartButton = new Button();
        private readonly List<GuessRow> m_GuessRows = new List<GuessRow>();

        private int m_NumOfGuesses = 4;
        private int m_CurrentRowIndex = 0;

        private GameData m_GameData;

        public FormMain()
        {
            initializeForm();
            initializeTopButtons();
        }

        private void initializeForm()
        {
            this.Text = "BullsEye Game";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(600, 600);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void initializeTopButtons()
        {
            m_NumOfGuessesButton.Text = m_NumOfGuesses.ToString();
            m_NumOfGuessesButton.Size = new Size(k_ButtonSize * 2, k_ButtonSize);
            m_NumOfGuessesButton.Location = new Point(20, 20);
            m_NumOfGuessesButton.Click += numOfGuessesButton_Click;
            this.Controls.Add(m_NumOfGuessesButton);

            m_StartButton.Text = "Start";
            m_StartButton.Size = new Size(k_ButtonSize * 2, k_ButtonSize);
            m_StartButton.Location = new Point(80, 20);
            m_StartButton.Click += startButton_Click;
            this.Controls.Add(m_StartButton);
        }

        private void numOfGuessesButton_Click(object sender, EventArgs e)
        {
            m_NumOfGuesses = m_NumOfGuesses == 10 ? 4 : m_NumOfGuesses + 1;
            m_NumOfGuessesButton.Text = m_NumOfGuesses.ToString();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            m_GuessRows.Clear();
            m_CurrentRowIndex = 0;

            initializeTopButtons();

            string secretAsString = SecretWordGenerator.GenerateSecretWord();
            List<Guess.eGuessCollectionOptions> secretList = new List<Guess.eGuessCollectionOptions>();

            foreach (char letter in secretAsString)
            {
                secretList.Add((Guess.eGuessCollectionOptions)Enum.Parse(typeof(Guess.eGuessCollectionOptions), letter.ToString()));
            }

            Guess secretGuess = new Guess(secretList);
            m_GameData = new GameData(secretGuess, m_NumOfGuesses);

            for (int i = 0; i < m_NumOfGuesses; i++)
            {
                GuessRow guessRow = new GuessRow(new Point(20, 80 + i * k_GuessRowsSpacing));
                guessRow.GuessSubmitted += guessRow_GuessSubmitted;

                foreach (Control ctrl in guessRow.Controls)
                {
                    this.Controls.Add(ctrl);
                }

                guessRow.SetEnabled(i == 0);
                m_GuessRows.Add(guessRow);
            }
        }

        private void guessRow_GuessSubmitted(object sender, Color[] i_SelectedColors)
        {
            GuessRow currentRow = sender as GuessRow;

            Guess currentGuess = convertColorsToGuess(i_SelectedColors);
            FeedbackOfGuess feedback = GuessComparer.Compare(currentGuess, m_GameData.SecretWord);

            m_GameData.AddGuessAndFeedback(currentGuess, feedback);
            setResultToRow(currentRow, feedback);

            m_CurrentRowIndex++;

            bool isAllExact = true;
            foreach (FeedbackOfGuess.eFeedbackOfGuessType type in feedback.m_FeedbackOfGuessTypes)
            {
                if (type != FeedbackOfGuess.eFeedbackOfGuessType.ExactPlace)
                {
                    isAllExact = false;
                }
            }

            if (isAllExact || m_CurrentRowIndex >= m_NumOfGuesses)
            {
                endGame();
            }
            else
            {
                m_GuessRows[m_CurrentRowIndex].SetEnabled(true);
            }
        }

        private Guess convertColorsToGuess(Color[] i_Colors)
        {
            List<Guess.eGuessCollectionOptions> guessList = new List<Guess.eGuessCollectionOptions>();

            foreach (Color color in i_Colors)
            {
                guessList.Add(convertColorToEnum(color));
            }

            return new Guess(guessList);
        }

        private Guess.eGuessCollectionOptions convertColorToEnum(Color i_Color)
        {
            if (i_Color == Color.Red) return Guess.eGuessCollectionOptions.A;
            if (i_Color == Color.Green) return Guess.eGuessCollectionOptions.B;
            if (i_Color == Color.Blue) return Guess.eGuessCollectionOptions.C;
            if (i_Color == Color.Yellow) return Guess.eGuessCollectionOptions.D;
            if (i_Color == Color.Purple) return Guess.eGuessCollectionOptions.E;
            if (i_Color == Color.Orange) return Guess.eGuessCollectionOptions.F;
            if (i_Color == Color.Brown) return Guess.eGuessCollectionOptions.G;
            if (i_Color == Color.Pink) return Guess.eGuessCollectionOptions.H;

            throw new ArgumentException("Unsupported color");
        }

        private void setResultToRow(GuessRow i_Row, FeedbackOfGuess i_Feedback)
        {
            int exact = 0;
            int partial = 0;

            foreach (FeedbackOfGuess.eFeedbackOfGuessType feedbackType in i_Feedback.m_FeedbackOfGuessTypes)
            {
                if (feedbackType == FeedbackOfGuess.eFeedbackOfGuessType.ExactPlace)
                {
                    exact++;
                }
                else if (feedbackType == FeedbackOfGuess.eFeedbackOfGuessType.WrongPlace)
                {
                    partial++;
                }
            }

            i_Row.SetResult(exact, partial);
        }

        private void endGame()
        {
            MessageBox.Show("Game Over!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}