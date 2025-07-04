﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ex05.Logic;

namespace Ex05.UI
{
    public class GuessRow : UserControl
    {
        private const int k_NumOfButtonsInRow = Ex05.Logic.SecretWordGenerator.k_SecretWordLength;
        private Button[] m_ButtonsGuess = new Button[k_NumOfButtonsInRow];
        private Button m_ButtonSubmit = new Button();
        private Button[] m_FeedbackIndicators = new Button[k_NumOfButtonsInRow];

        public event Action<GuessRow> RowSubmitted;

        public GuessRow(int i_RowIndex)
        {
            const int k_RowHeight = 50;
            bool isSecretRow = i_RowIndex == 0;
        
            this.Height = k_RowHeight;
            this.Width = 285;
            for(int i = 0; i < k_NumOfButtonsInRow; i++)
            {
                Button buttonGuess = new Button();

                buttonGuess.Width = 40;
                buttonGuess.Height = 40;
                buttonGuess.Left = i * 45;
                buttonGuess.Top = (k_RowHeight - buttonGuess.Height) / 2;
                if(!isSecretRow)
                {
                    buttonGuess.Click += buttonGuess_Click;
                }
                else
                {
                    buttonGuess.Enabled = false;
                    buttonGuess.BackColor = Color.Black;
                }

                this.Controls.Add(buttonGuess);
                m_ButtonsGuess[i] = buttonGuess;
            }

            if(!isSecretRow)
            {
                m_ButtonSubmit.Text = "-->";
                m_ButtonSubmit.Width = 40;
                m_ButtonSubmit.Height = 20;
                m_ButtonSubmit.Left = 180;
                m_ButtonSubmit.Top = (k_RowHeight - m_ButtonSubmit.Height) / 2;
                m_ButtonSubmit.Enabled = false;
                m_ButtonSubmit.Click += buttonSubmit_Click;
                this.Controls.Add(m_ButtonSubmit);

                // Feedback indicators
                for (int i = 0; i < k_NumOfButtonsInRow; i++)
                {
                    Button panelIndicator = new Button();

                    panelIndicator.Width = 15;
                    panelIndicator.Height = 15;
                    panelIndicator.Left = 230 + (i % 2) * 20;
                    panelIndicator.Top = 8 + (i / 2) * 20;
                    panelIndicator.Enabled = false;
                    this.Controls.Add(panelIndicator);
                    m_FeedbackIndicators[i] = panelIndicator;
                }
            }
        }

        private void buttonGuess_Click(object sender, EventArgs e)
        {
            Button buttonClicked = sender as Button;
            Color[] usedColors = m_ButtonsGuess.Where(btn => btn != buttonClicked).Select(btn => btn.BackColor)
                .Where(color => color != Color.Black).ToArray();
            FormColorPicker formColorPicker = new FormColorPicker(usedColors);
            
            formColorPicker.StartPosition = FormStartPosition.Manual;
            Point buttonScreenLocation = buttonClicked.PointToScreen(Point.Empty);

            formColorPicker.StartPosition = FormStartPosition.Manual;
            formColorPicker.Location = new Point(
                buttonScreenLocation.X - formColorPicker.Width + 1,
                buttonScreenLocation.Y + 30);
            if (formColorPicker.ShowDialog() == DialogResult.OK && formColorPicker.SelectedColor.HasValue)
            {
                buttonClicked.BackColor = formColorPicker.SelectedColor.Value;
                if (isAllButtonsColored())
                {
                    m_ButtonSubmit.Enabled = true;
                }
            }
        }

        private bool isAllButtonsColored()
        {
            return m_ButtonsGuess.All(i_Btn => i_Btn.BackColor != SystemColors.Control);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (!isAllButtonsColored())
            {
                MessageBox.Show("Please select a color for each button before submitting.", "Incomplete Guess", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            m_ButtonSubmit.Enabled = false;

            // Disable guess buttons after submission
            foreach (Button buttonGuess in m_ButtonsGuess)
            {
                buttonGuess.Enabled = false;
            }

            RowSubmitted?.Invoke(this);
        }

        public GuessCombination GetUserGuessCombination()
        {
            List<GuessCombination.eGuessCollectionOptions> userGuess =
                new List<GuessCombination.eGuessCollectionOptions>();

            foreach (Button button in m_ButtonsGuess)
            {
                userGuess.Add(UiToLogicBridge.GetFromUiToLogicIndex(button.BackColor));
            }

            return new GuessCombination(userGuess);
        }

        public void SetColorsFromGuess(GuessCombination i_Combination)
        {
            for (int i = 0; i < m_ButtonsGuess.Length; i++)
            {
                GuessCombination.eGuessCollectionOptions option = i_Combination.UserGuess[i];
                m_ButtonsGuess[i].BackColor = UiToLogicBridge.GetFromLogicToUiIndex(option);
            }
        }

        public void SetFeedback(int i_ExactMatches, int i_PartialMatches)
        {
            int feedbackIndex = 0;

            // set exact matches pegs (black)
            for (int i = 0; i < i_ExactMatches && feedbackIndex < m_FeedbackIndicators.Length; i++)
            {
                m_FeedbackIndicators[feedbackIndex].BackColor = Color.Black;
                feedbackIndex++;
            }

            // set partial matches pegs (yellow)
            for (int i = 0; i < i_PartialMatches && feedbackIndex < m_FeedbackIndicators.Length; i++)
            {
                m_FeedbackIndicators[feedbackIndex].BackColor = Color.Yellow;
                feedbackIndex++;
            }

            // The rest
            while (feedbackIndex < m_FeedbackIndicators.Length)
            {
                m_FeedbackIndicators[feedbackIndex].BackColor = SystemColors.Control;
                feedbackIndex++;
            }
        }
    }
}