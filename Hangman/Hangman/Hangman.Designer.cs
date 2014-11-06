﻿namespace Hangman
{
    partial class Hangman
    {
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
            this.grpHangman = new System.Windows.Forms.GroupBox();
            this.lblDisplayText = new System.Windows.Forms.Label();
            this.txtGuess = new System.Windows.Forms.TextBox();
            this.lblGameText = new System.Windows.Forms.Label();
            this.txtGameText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // grpHangman
            // 
            this.grpHangman.Location = new System.Drawing.Point(258, 12);
            this.grpHangman.Name = "grpHangman";
            this.grpHangman.Size = new System.Drawing.Size(278, 273);
            this.grpHangman.TabIndex = 0;
            this.grpHangman.TabStop = false;
            // 
            // lblDisplayText
            // 
            this.lblDisplayText.AutoSize = true;
            this.lblDisplayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayText.Location = new System.Drawing.Point(10, 346);
            this.lblDisplayText.Name = "lblDisplayText";
            this.lblDisplayText.Size = new System.Drawing.Size(319, 25);
            this.lblDisplayText.TabIndex = 1;
            this.lblDisplayText.Text = "Guess a letter or the entire word";
            this.lblDisplayText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtGuess
            // 
            this.txtGuess.Location = new System.Drawing.Point(335, 351);
            this.txtGuess.Name = "txtGuess";
            this.txtGuess.Size = new System.Drawing.Size(172, 20);
            this.txtGuess.TabIndex = 2;
            this.txtGuess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGuess_KeyDown);
            // 
            // lblGameText
            // 
            this.lblGameText.AutoSize = true;
            this.lblGameText.Location = new System.Drawing.Point(30, 33);
            this.lblGameText.Name = "lblGameText";
            this.lblGameText.Size = new System.Drawing.Size(0, 13);
            this.lblGameText.TabIndex = 3;
            // 
            // txtGameText
            // 
            this.txtGameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGameText.Location = new System.Drawing.Point(15, 291);
            this.txtGameText.Name = "txtGameText";
            this.txtGameText.ReadOnly = true;
            this.txtGameText.Size = new System.Drawing.Size(521, 38);
            this.txtGameText.TabIndex = 4;
            this.txtGameText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Hangman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 390);
            this.Controls.Add(this.txtGameText);
            this.Controls.Add(this.lblGameText);
            this.Controls.Add(this.txtGuess);
            this.Controls.Add(this.lblDisplayText);
            this.Controls.Add(this.grpHangman);
            this.Name = "Hangman";
            this.Text = "Hangman";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpHangman;
        private System.Windows.Forms.Label lblDisplayText;
        private System.Windows.Forms.TextBox txtGuess;
        private System.Windows.Forms.Label lblGameText;
        private System.Windows.Forms.TextBox txtGameText;
    }
}
