using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Hangman : Form
    {
        private string word = string.Empty; // The game word to be used the entire time
        private List<string> userGuesses = new List<string>(); // Place to store the previous guesses
        private int numGuesses = 7; // Guesses that the user has left

        public Hangman(string gameWord)
        {
            // Get all of the components ready
            InitializeComponent();

            // Initalize the game
            InitGame(gameWord);
        }
        private void InitGame(string randomWord)
        {
            // Set the game text initially
            lblGameText.Text = "Welcome to Hangman!";
            // Set the word that's passed in
            word = randomWord;

            // Update the text box for the game before the user starts
            UpdateTextBox();

        }
        /// <summary>
        /// Function to handle the ENTER key being pressed inside of the textbox
        /// </summary>
        /// <param name="sender">the object that is sending the key</param>
        /// <param name="e">KeyEvent</param>
        private void txtGuess_KeyDown(object sender, KeyEventArgs e)
        {
            // Filter when the user hit's the ENTER key inside of the textbox to check the guess
            if (e.KeyCode == Keys.Enter)
            {
                CheckGuess(txtGuess.Text);
                // Clear the previous guess from the text box
                txtGuess.Text = string.Empty;
                // Update the hangman based on the number of guesses remaining

            }

            
        }

        /// <summary>
        /// The main logic to check a guess and update the display
        /// </summary>
        private void CheckGuess(string userGuessInput)
        {
            // Check that the input is a valid letter character first
            if (ValidInput(userGuessInput))
            {
                if (userGuessInput.Length > 1)
                { // Full answer guess
                    if (userGuessInput == word) 
                    { // winner
                    }
                    else
                    {
                        // bad guess
                        numGuesses--;
                    }
                }
                else
                { // Singular letter guess

                    // Add the letter guess to the list userGuesses
                    userGuesses.Add(userGuessInput);
                    // After checking the guess update the textbox
                    UpdateTextBox();
                }
            }
            else
            {
                // When the input isn't valid
                MessageBox.Show("Invalid input!");
                txtGuess.Clear();
            }
        }

        /// <summary>
        /// Update the text box so the user knows their current play status
        /// </summary>
        /// <param name="guessesSoFar">List of user guesses so far</param>
        private void UpdateTextBox()
        {
            // Create the string to add to the textbox
            StringBuilder tempString = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                string currentLetter = word[i].ToString().ToLower();
                if(userGuesses.Contains(currentLetter))
                {
                    // Append a previous correct guess to the output
                    tempString.Append(word[i] + " ");
                }
                else
                {
                    // This index of the word has never been guessed correctly
                    // Fill it's space with an underscore
                    tempString.Append("_ ");
                }
            }

            // Update the textbox text value to reflect the new status of the game
            txtGameText.Text = tempString.ToString();
            txtGameText.Refresh();
        }
        /// <summary>
        /// Check that the user is only typing in letters, not special characters or numbers
        /// </summary>
        /// <param name="userInput">input to be checked</param>
        /// <returns>true if valid</returns>
        private bool ValidInput(string userInput)
        {
            // Go over each character individually
            foreach (char letter in userInput)
            {
                if (!("abcdefghijklmnopqrstuvwxyz".Contains(letter.ToString().ToLower())))
                { // a bad character input
                    return false;
                }
            }
            // Must be good input
            return true;
        }

    }
}
