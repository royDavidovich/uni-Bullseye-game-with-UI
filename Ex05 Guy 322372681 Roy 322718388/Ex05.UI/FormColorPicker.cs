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
    public partial class FormColorPicker : Form
    {
        private readonly Color[] r_AllowedColors =
            {
                Color.Red,
                Color.Blue,
                Color.Green,
                Color.Yellow,
                Color.Orange,
                Color.Purple,
                Color.Brown,
                Color.Pink
            };

        public Color? SelectedColor { get; private set; } = null;

        public FormColorPicker(Color[] i_UsedColors)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;

            for (int i = 0; i < r_AllowedColors.Length; i++)
            {
                Button buttonColor = new Button();
                buttonColor.Name = $"buttonColor{i}";
                buttonColor.Width = 40;
                buttonColor.Height = 40;
                buttonColor.BackColor = r_AllowedColors[i];
                buttonColor.Left = 10 + (i % 4) * 50;
                buttonColor.Top = 10 + (i / 4) * 50;

                if (Array.Exists(i_UsedColors, i_Color => i_Color == r_AllowedColors[i]))
                {
                    buttonColor.Enabled = false;
                }

                buttonColor.Click += buttonColor_Click;
                this.Controls.Add(buttonColor);
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                SelectedColor = clickedButton.BackColor;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void FormColorPicker_Load(object sender, EventArgs e)
        {

        }
    }
}
