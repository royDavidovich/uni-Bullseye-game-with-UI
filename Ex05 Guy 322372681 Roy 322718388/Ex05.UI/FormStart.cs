using System.Drawing;
using System.Windows.Forms;
using System;

namespace BullsEyeUI
{
    public class FormStart : Form
    {
        private readonly Button m_ButtonCounter = new Button();
        private readonly Button m_ButtonStart = new Button();

        public int NumOfRounds { get; private set; } = 4;

        public FormStart()
        {
            initializeForm();
        }

        private void initializeForm()
        {
            this.Text = "Bool Pgia";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ClientSize = new Size(250, 120);

            m_ButtonCounter.Text = "Number of chances: 4";
            m_ButtonCounter.Location = new Point(25, 20);
            m_ButtonCounter.Size = new Size(200, 30);
            m_ButtonCounter.Click += buttonCounter_Click;

            m_ButtonStart.Text = "Start";
            m_ButtonStart.Location = new Point(85, 65);
            m_ButtonStart.Size = new Size(75, 30);
            m_ButtonStart.DialogResult = DialogResult.OK;

            this.Controls.Add(m_ButtonCounter);
            this.Controls.Add(m_ButtonStart);
        }

        private void buttonCounter_Click(object sender, EventArgs e)
        {
            NumOfRounds++;
            if (NumOfRounds > 10)
            {
                NumOfRounds = 1;
            }

            m_ButtonCounter.Text = $"Number of chances: {NumOfRounds}";
        }
    }
}