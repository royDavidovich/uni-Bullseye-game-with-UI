using System;

namespace BullsEyeUI
{
    internal static class Program
    {
        public static void Main()
        {
            FormStart startForm = new FormStart();
            if (startForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MainForm mainForm = new MainForm(startForm.NumOfRounds);
                mainForm.ShowDialog();
            }
        }
    }
}