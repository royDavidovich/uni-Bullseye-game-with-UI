using System;
using System.Drawing;
using System.Windows.Forms;

namespace BullsEyeUI
{
    public class ColorPickerForm : Form
    {
        private readonly Color[] r_Colors = new Color[]
        {
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.Yellow,
            Color.Purple,
            Color.Orange,
            Color.Brown,
            Color.Pink
        };

        private const int k_ButtonSize = 40;
        private const int k_Padding = 10;

        public Color SelectedColor { get; private set; }

        public ColorPickerForm()
        {
            initializeForm();
        }

        private void initializeForm()
        {
            this.Text = "Pick a color";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size((k_ButtonSize + k_Padding) * r_Colors.Length + k_Padding, k_ButtonSize + 2 * k_Padding);

            int x = k_Padding;

            foreach (Color color in r_Colors)
            {
                Button colorButton = new Button();
                colorButton.Size = new Size(k_ButtonSize, k_ButtonSize);
                colorButton.BackColor = color;
                colorButton.Location = new Point(x, k_Padding);
                colorButton.Click += colorButton_Click;

                this.Controls.Add(colorButton);

                x += k_ButtonSize + k_Padding;
            }
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            this.SelectedColor = clickedButton.BackColor;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
