using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BullsEyeUI
{
    public class GuessRow
    {
        private const int k_NumOfButtons = 4;
        private const int k_ButtonSize = 30;
        private const int k_ResultSize = 15;

        private readonly Button[] m_ColorButtons = new Button[k_NumOfButtons];
        private readonly Button[] m_ResultButtons = new Button[k_NumOfButtons];
        private readonly Button m_SubmitButton = new Button();
        private readonly List<Control> m_AllControls = new List<Control>();

        public event EventHandler<Color[]> GuessSubmitted;

        public IEnumerable<Control> Controls => m_AllControls;

        public GuessRow(Point i_StartLocation, Color i_DefaultColor)
        {
            createRow(i_StartLocation, i_DefaultColor);
        }

        private void createRow(Point i_StartLocation, Color i_DefaultColor)
        {
            int x = i_StartLocation.X;
            int y = i_StartLocation.Y;

            Color initialDisplayColor = i_DefaultColor == Color.White
                ? Color.FromArgb(240, 240, 240)
                : i_DefaultColor;

            for (int i = 0; i < k_NumOfButtons; i++)
            {
                Button colorButton = new Button();
                colorButton.Width = k_ButtonSize;
                colorButton.Height = k_ButtonSize;
                colorButton.BackColor = initialDisplayColor;
                colorButton.Location = new Point(x, y);
                colorButton.Click += colorButton_Click;

                m_ColorButtons[i] = colorButton;
                m_AllControls.Add(colorButton);

                x += k_ButtonSize + 10;
            }

            m_SubmitButton.Width = k_ButtonSize;
            m_SubmitButton.Height = k_ButtonSize;
            m_SubmitButton.Text = ">";
            m_SubmitButton.Enabled = false;
            m_SubmitButton.Location = new Point(x, y);
            m_SubmitButton.Click += submitButton_Click;

            m_AllControls.Add(m_SubmitButton);
            x += k_ButtonSize + 10;

            for (int i = 0; i < k_NumOfButtons; i++)
            {
                Button resultButton = new Button();
                resultButton.Width = k_ResultSize;
                resultButton.Height = k_ResultSize;
                resultButton.Enabled = false;
                resultButton.Location = new Point(x, y + (i % 2 == 0 ? 0 : k_ResultSize));
                m_ResultButtons[i] = resultButton;
                m_AllControls.Add(resultButton);

                x += k_ResultSize + 5;
            }
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            using (ColorPickerForm picker = new ColorPickerForm())
            {
                if (picker.ShowDialog() == DialogResult.OK)
                {
                    if (isColorAlreadyChosen(picker.SelectedColor))
                    {
                        MessageBox.Show("This color was already chosen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    clickedButton.BackColor = picker.SelectedColor;
                    m_SubmitButton.Enabled = isAllColored();
                }
            }
        }

        private bool isColorAlreadyChosen(Color i_Color)
        {
            foreach (Button button in m_ColorButtons)
            {
                if (button.BackColor == i_Color)
                {
                    return true;
                }
            }

            return false;
        }

        private bool isAllColored()
        {
            foreach (Button button in m_ColorButtons)
            {
                if (button.BackColor.ToArgb() == Color.FromArgb(240, 240, 240).ToArgb())
                {
                    return false;
                }
            }

            return true;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Color[] selectedColors = new Color[k_NumOfButtons];

            for (int i = 0; i < k_NumOfButtons; i++)
            {
                selectedColors[i] = m_ColorButtons[i].BackColor;
                m_ColorButtons[i].Enabled = false;
            }

            m_SubmitButton.Enabled = false;
            OnGuessSubmitted(selectedColors);
        }

        protected virtual void OnGuessSubmitted(Color[] i_SelectedColors)
        {
            GuessSubmitted?.Invoke(this, i_SelectedColors);
        }

        public void SetResult(int i_NumOfHits, int i_NumOfColorOnly)
        {
            int index = 0;

            for (int i = 0; i < i_NumOfHits; i++)
            {
                m_ResultButtons[index++].BackColor = Color.Black;
            }

            for (int i = 0; i < i_NumOfColorOnly; i++)
            {
                m_ResultButtons[index++].BackColor = Color.Yellow;
            }
        }

        public void SetEnabled(bool i_IsEnabled)
        {
            foreach (Button button in m_ColorButtons)
            {
                bool isUnchosen = button.BackColor.ToArgb() == Color.FromArgb(240, 240, 240).ToArgb();
                button.Enabled = i_IsEnabled && isUnchosen;
            }

            m_SubmitButton.Enabled = i_IsEnabled && isAllColored();
        }
    }
}
