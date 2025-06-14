using System;
using System.Drawing;
using System.Windows.Forms;

namespace BullsEyeUI
{
    public class ColorPickerForm : Form
    {
        private readonly Color[] r_Colors = new Color[]
        {
            Color.Magenta,
            Color.Red,
            Color.Lime,
            Color.Cyan,
            Color.Blue,
            Color.Yellow,
            Color.Brown,
            Color.White
        };

        private const int k_ButtonSize = 50;
        private const int k_Padding = 10;

        public Color SelectedColor { get; private set; }

        public ColorPickerForm()
        {
            initializeForm();
        }

        private void initializeForm()
        {
            this.Text = "Pick A Color:";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = SystemColors.Control;
            this.ClientSize = new Size((k_ButtonSize + k_Padding) * 4 + k_Padding, (k_ButtonSize + k_Padding) * 2 + k_Padding);

            int x = k_Padding;
            int y = k_Padding;

            for (int i = 0; i < r_Colors.Length; i++)
            {
                Button colorButton = new Button();
                colorButton.Size = new Size(k_ButtonSize, k_ButtonSize);
                colorButton.BackColor = r_Colors[i];
                colorButton.FlatStyle = FlatStyle.Flat;
                colorButton.FlatAppearance.BorderColor = Color.Black;
                colorButton.Location = new Point(x, y);
                colorButton.Click += colorButton_Click;

                this.Controls.Add(colorButton);

                x += k_ButtonSize + k_Padding;

                if ((i + 1) % 4 == 0)
                {
                    x = k_Padding;
                    y += k_ButtonSize + k_Padding;
                }
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