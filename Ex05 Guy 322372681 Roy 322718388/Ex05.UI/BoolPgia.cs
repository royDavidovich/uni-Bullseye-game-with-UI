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
        public BoolPgia()
        {
            if(ensureMaxChancesChosen())
            {
                //Ex05.Logic.GameData newGame = new GameData();
                InitializeComponent();
            }
        }

        private bool m_MaxChancesChosen = false;

        private bool ensureMaxChancesChosen()
        {
            if(!m_MaxChancesChosen)
            {
                ChancesSelectionForm chancesSelectionForm = new ChancesSelectionForm();

                chancesSelectionForm.ShowDialog();
                if (chancesSelectionForm.ClosedByStart)
                {
                    m_MaxChancesChosen = true;
                }

            }

            return m_MaxChancesChosen;
        }

        private void BoolPgia_Load(object sender, EventArgs e)
        {

        }
    }
}
