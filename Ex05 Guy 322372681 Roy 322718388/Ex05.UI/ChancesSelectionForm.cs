using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.UI
{
    public partial class ChancesSelectionForm : Form
    {
        public int NumberOfChances { get; set; } = 4;
        public bool ClosedByStart { get; private set; } = false;

        public ChancesSelectionForm()
        {
            InitializeComponent();
        }

        private void buttonNumberOfChances_Click(object sender, EventArgs e)
        {
            NumberOfChances++;
            if (NumberOfChances > 10)
            {
                NumberOfChances = 4;
            }

            (sender as Button).Text = $"Number of chances: {NumberOfChances}";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ClosedByStart = true;
            this.Close();
        }

        private void ChancesSelectionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
