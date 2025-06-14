using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.Width = 350;

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
            // TODO: open color picker, set button color, disable duplicate colors
            // After setting colors, check if all buttons are selected, then:
            if (isAllButtonsColored())
            {
                m_ButtonSubmit.Enabled = true;
            }
        }

        private bool isAllButtonsColored()
        {
            return m_ButtonsGuess.All(i_Btn => i_Btn.BackColor != Color.Black);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            m_ButtonSubmit.Enabled = false;
            RowSubmitted?.Invoke(this);
        }
    }
}