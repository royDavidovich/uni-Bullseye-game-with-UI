using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Logic;

namespace BullsEyeUI
{
    public class MainForm : Form
    {
        private const int k_ButtonSize = 30;
        private const int k_ResultSize = 15;
        private const int k_Spacing = 10;
        private const int k_RowHeight = 50;
        private const int k_StartX = 20;
        private const int k_StartY = 60;

        private readonly List<GuessRow> m_GuessRows = new List<GuessRow>();
        private readonly Button[] m_SecretButtons = new Button[4];
        private GameData m_GameData;
        private int m_CurrentRowIndex = 0;

        public MainForm(int i_NumOfRounds)
        {
            initializeForm();
            startGame(i_NumOfRounds);
        }

        private void initializeForm()
        {
            this.Text = "Bool Pgia";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void startGame(int i_NumOfRounds)
        {
            m_GameData = new GameData(generateSecretWord(), i_NumOfRounds);
            m_GuessRows.Clear();
            m_CurrentRowIndex = 0;

            addSecretRow();

            for (int i = 0; i < i_NumOfRounds; i++)
            {
                Point rowLocation = new Point(k_StartX, k_StartY + i * k_RowHeight);
                GuessRow row = new GuessRow(rowLocation, Color.White);
                row.GuessSubmitted += guessRow_GuessSubmitted;
                row.SetEnabled(i == 0);

                foreach (Control control in row.Controls)
                {
                    this.Controls.Add(control);
                }

                m_GuessRows.Add(row);
            }

            int formWidth = k_StartX + (k_ButtonSize + k_Spacing) * 4 + k_Spacing + k_ButtonSize + k_Spacing + (k_ResultSize + 5) * 4;
            int formHeight = k_StartY + (i_NumOfRounds * k_RowHeight) + 10;

            this.ClientSize = new Size(formWidth, formHeight);
        }

        private void addSecretRow()
        {
            int x = k_StartX;
            int y = k_StartY - k_RowHeight;

            for (int i = 0; i < 4; i++)
            {
                Button secretButton = new Button();
                secretButton.Size = new Size(k_ButtonSize, k_ButtonSize);
                secretButton.BackColor = Color.Black;
                secretButton.Enabled = false;
                secretButton.Location = new Point(x, y);
                m_SecretButtons[i] = secretButton;

                this.Controls.Add(secretButton);
                x += k_ButtonSize + k_Spacing;
            }
        }

        private void guessRow_GuessSubmitted(object sender, Color[] i_SelectedColors)
        {
            Guess userGuess = convertColorsToGuess(i_SelectedColors);
            FeedbackOfGuess feedback = GuessComparer.Compare(userGuess, m_GameData.SecretWord);
            m_GameData.AddGuessAndFeedback(userGuess, feedback);

            GuessRow currentRow = m_GuessRows[m_CurrentRowIndex];
            int hits = 0;
            int partials = 0;

            foreach (var type in feedback.m_FeedbackOfGuessTypes)
            {
                if (type == FeedbackOfGuess.eFeedbackOfGuessType.ExactPlace)
                {
                    hits++;
                }
                else if (type == FeedbackOfGuess.eFeedbackOfGuessType.WrongPlace)
                {
                    partials++;
                }
            }

            currentRow.SetResult(hits, partials);

            if (hits == 4 || ++m_CurrentRowIndex == m_GameData.r_MaxUserGuesses)
            {
                revealSecret();
                return;
            }

            m_GuessRows[m_CurrentRowIndex].SetEnabled(true);
        }

        private void revealSecret()
        {
            Color[] secretColors = convertGuessToColors(m_GameData.SecretWord);
            for (int i = 0; i < 4; i++)
            {
                m_SecretButtons[i].BackColor = secretColors[i];
            }
        }

        private Guess generateSecretWord()
        {
            string secret = SecretWordGenerator.GenerateSecretWord();
            List<Guess.eGuessCollectionOptions> letters = new List<Guess.eGuessCollectionOptions>();
            foreach (char ch in secret)
            {
                letters.Add((Guess.eGuessCollectionOptions)Enum.Parse(typeof(Guess.eGuessCollectionOptions), ch.ToString()));
            }

            return new Guess(letters);
        }

        private Guess convertColorsToGuess(Color[] i_Colors)
        {
            Color[] colorBank = new Color[]
            {
                Color.Magenta, Color.Red, Color.Lime, Color.Cyan,
                Color.Blue, Color.Yellow, Color.Brown, Color.White
            };

            List<Guess.eGuessCollectionOptions> guess = new List<Guess.eGuessCollectionOptions>();

            foreach (Color color in i_Colors)
            {
                int index = Array.IndexOf(colorBank, color);
                guess.Add((Guess.eGuessCollectionOptions)index);
            }

            return new Guess(guess);
        }

        private Color[] convertGuessToColors(Guess i_Guess)
        {
            Color[] colorBank = new Color[]
            {
                Color.Magenta, Color.Red, Color.Lime, Color.Cyan,
                Color.Blue, Color.Yellow, Color.Brown, Color.White
            };

            Color[] result = new Color[i_Guess.userGuess.Count];
            for (int i = 0; i < i_Guess.userGuess.Count; i++)
            {
                result[i] = colorBank[(int)i_Guess.userGuess[i]];
            }

            return result;
        }
    }
}
