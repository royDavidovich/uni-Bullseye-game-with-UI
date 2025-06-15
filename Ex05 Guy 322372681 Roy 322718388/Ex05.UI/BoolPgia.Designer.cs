using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.UI
{
    partial class BoolPgia
    {
        private const int k_RowHeight = 40;
        private const int k_RowSpacing = 10;
        private const int k_ExtraSpacingAfterSecret = 20;
        private const int k_InitialTopMargin = 10;
        private const int k_BottomMargin = 10;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BoolPgia
            // 

            int numberOfGuessRows = r_ChancesSelectionForm.NumberOfChances;
            int totalRows = numberOfGuessRows + 1; // +1 for the secret row

            int calculatedHeight = k_InitialTopMargin + k_RowHeight + // secret row
                                   k_ExtraSpacingAfterSecret + (numberOfGuessRows * (k_RowHeight + k_RowSpacing))
                                   + k_BottomMargin;

            this.ClientSize = new Size(285, calculatedHeight);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "BoolPgia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BoolPgia";
            this.TopMost = false;
            this.ResumeLayout(false);

        }

        #endregion
    }
}