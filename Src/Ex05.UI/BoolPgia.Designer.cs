using System;
using System.Drawing;
using System.Resources;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoolPgia));
            this.SuspendLayout();
            // 
            // BoolPgia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            int numberOfGuessRows = r_ChancesSelectionForm.NumberOfChances;
            int totalRows = numberOfGuessRows + 1; // +1 for the secret row

            int calculatedHeight = k_InitialTopMargin + k_RowHeight + // secret row
                                   k_ExtraSpacingAfterSecret + (numberOfGuessRows * (k_RowHeight + k_RowSpacing))
                                   + k_BottomMargin;

            this.ClientSize = new Size(285, calculatedHeight);
            
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BoolPgia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BoolPgia";
            this.ResumeLayout(false);

        }

        #endregion
    }
}