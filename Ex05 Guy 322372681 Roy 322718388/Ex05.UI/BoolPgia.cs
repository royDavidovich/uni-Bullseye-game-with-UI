using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05.Logic;

namespace Ex05.UI
{
    public partial class BoolPgia : Form
    {
        private readonly ChancesSelectionForm r_ChancesSelectionForm = new ChancesSelectionForm();

        public BoolPgia()
        {
            r_ChancesSelectionForm.ShowDialog();
            if (ensureMaxChancesChosen())
            {
                Ex05.Logic.GameData newGame = new GameData(r_ChancesSelectionForm.NumberOfChances);
                InitializeComponent();
                addGuessRows(r_ChancesSelectionForm.NumberOfChances);
            }
        }

        private bool m_IsMaxChancesChosen = false;

        private bool ensureMaxChancesChosen()
        {
            if(!m_IsMaxChancesChosen)
            {
                if (r_ChancesSelectionForm.ClosedByStart)
                {
                    m_IsMaxChancesChosen = true;
                }
            }

            return m_IsMaxChancesChosen;
        }

        private void addGuessRows(int i_NumberOfChances)
        {
            const int k_RowHeight = 50;
            const int k_SecretRowTop = 10;
            const int k_ExtraSpaceAfterSecretRow = 10;

            GuessRow secretRow = new GuessRow(0);
            secretRow.Left = 10;
            secretRow.Top = k_SecretRowTop;
            this.Controls.Add(secretRow);

            for (int i = 0; i < i_NumberOfChances; i++)
            {
                GuessRow guessRow = new GuessRow(i + 1);
                
                guessRow.Left = 10;
                guessRow.Top = k_SecretRowTop + k_RowHeight + k_ExtraSpaceAfterSecretRow
                               + (i * k_RowHeight);
                this.Controls.Add(guessRow);
                if (i > 0)
                {
                    guessRow.Enabled = false;
                }

                guessRow.RowSubmitted += handleRowSubmitted;
            }
        }

        private void handleRowSubmitted(GuessRow i_SubmittedRow)
        {
            int index = this.Controls.GetChildIndex(i_SubmittedRow);

            if (index + 1 < this.Controls.Count)
            {
                Control nextRow = this.Controls[index + 1];

                if (nextRow is GuessRow)
                {
                    nextRow.Enabled = true;
                }
            }
        }

        private void BoolPgia_Load(object sender, EventArgs e)
        {

        }
    }
}