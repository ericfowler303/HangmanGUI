using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Hangman
{
    public partial class Hangman : Form
    {
        private string word = string.Empty; // The game word to be used the entire time
        private List<string> userGuesses; // Place to store the previous guesses
        private int numGuesses; // Guesses that the user has left
        private bool win = false;

        public Hangman()
        {
            // Get all of the GUI components ready
            InitializeComponent();

            // Initalize the game
            InitGame();
        }

        private void InitGame()
        {
            // Center game on the screen
            this.CenterToScreen();

            // Pick a new random word
            Random rng = new Random();
            // Fill the possible words
            List<string> possibleWords = new List<string>() { "apple", "orange", "grapes", "mango", "pineapple", "steak", "kiwi" };
            // Pick the random word for this game
            word = possibleWords.ElementAt(rng.Next(possibleWords.Count));

            // Set the game text initially
            lblGameText.Text = "Welcome to Hangman!";

            // reset variables for new game
            win = false;
            userGuesses = new List<string>();
            numGuesses = 9;


            // Update the GUI elements before the game starts
            UpdateTextBox();
            UpdateHangmanImage();

        }
        /// <summary>
        /// Function to handle the ENTER key being pressed inside of the textbox
        /// </summary>
        /// <param name="sender">the object that is sending the key</param>
        /// <param name="e">KeyEvent</param>
        private void txtGuess_KeyDown(object sender, KeyEventArgs e)
        {
            // Filter when the user hit's the ENTER key inside of the textbox to check the guess
            // Only check new guesses when the user is still playing
            if (e.KeyCode == Keys.Enter && !win)
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
                // Full answer guess
                if (userGuessInput.Length > 1)
                { 
                    if (userGuessInput == word) 
                    { // winner
                        win = true;
                        UpdateTextBox();
                        UpdateGameText();

                    }
                    else
                    {
                        // bad guess
                        BadGuessSound();
                        numGuesses--;
                        UpdateGameText();
                    }
                }
                else
                { // Singular letter guess

                    // Check to see if the guess was in the word
                    if(!(word.ToLower().Contains(userGuessInput.ToLower())))
                    { // bad guess
                        if (!(userGuesses.Contains(userGuessInput.ToLower())))
                        { // Newly bad guess
                            numGuesses--;
                        }
                        BadGuessSound();
                    } // else good guess

                    // Add the letter guess to the list userGuesses
                    userGuesses.Add(userGuessInput.ToLower());

                    // If the correct guess is the final letter in the answer, set win to true
                    StringBuilder tempString = new StringBuilder();
                    for (int i = 0; i < word.Length; i++)
                    {
                        string currentLetter = word[i].ToString().ToLower();
                        if (userGuesses.Contains(currentLetter))
                        {
                            // Append a previous correct guess to the output
                            tempString.Append(word[i]);
                        }
                    } // Check for final word match
                    if (tempString.ToString().ToLower() == word.ToLower()) { win = true; }

                    // After checking the guess update the textbox
                    UpdateTextBox();
                    // Also, update the display text
                    UpdateGameText();
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
        /// Update the display text to reflect the number of guesses and other messages to the user
        /// </summary>
        private void UpdateGameText()
        {
            if (win)
            {// Display Winning Text
                lblGameText.Text = "Winner Winner Chicken Dinner!";
                UpdateHangmanImage();
                // Ask if they want to play again
                PlayAgain();

            }
            else if (numGuesses == 0)
            {
                // Total FAIL
                lblGameText.Text = "FAIL";
                UpdateHangmanImage();
                // Play buzzer sound on wrong guess
                Stream str = this.GetType().Assembly.GetManifestResourceStream("Hangman.ThePriceIsRight-LoserHorns.wav");
                SoundPlayer snd = new SoundPlayer(str);
                snd.Play();

                // Ask if they want to play again
                PlayAgain();

            }
            else
            {
                lblGameText.Text = "Number of Guesses Left: " + numGuesses;
                UpdateHangmanImage();
            }
        }
        /// <summary>
        /// A function to ask the player if they want to play again after a win or loss
        /// </summary>
        private void PlayAgain()
        {
            DialogResult questionResult = MessageBox.Show("Do you want to play again?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (questionResult == DialogResult.Yes)
            {
                // Restart the Game
                InitGame();
            }
            else { Application.Exit(); } // Quit
        }
        /// <summary>
        /// Update the image of the Hangman depending on the number of guesses left
        /// or if the user has won the game.
        /// </summary>
        private void UpdateHangmanImage()
        {
            if (win && numGuesses > 0)
            {
                // Winning Hangman Image
                picHangman.Image = Image.FromStream(this.GetType().Assembly.GetManifestResourceStream("Hangman.hangman9.png"));
            }
            else
            {
                // Display Hangman based on number of guesses remaining
                string hangmanImageName = "Hangman.hangman" + numGuesses + ".png";
                picHangman.Image = Image.FromStream(this.GetType().Assembly.GetManifestResourceStream(hangmanImageName));
            }
        }
        /// <summary>
        /// Update the text box so the user knows their current play status
        /// </summary>
        private void UpdateTextBox()
        {
            // Create the string to add to the textbox
            StringBuilder tempString = new StringBuilder();
            if (!win)
            {
                
                for (int i = 0; i < word.Length; i++)
                {
                    string currentLetter = word[i].ToString().ToLower();
                    if (userGuesses.Contains(currentLetter))
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
            }
            else { txtGameText.Text = word; } // Winner get's full word reveal
            // Refresh the content after changing it
            txtGameText.Refresh();
        }
        private void BadGuessSound()
        {
            // Play buzzer sound on wrong guess
            Stream str = this.GetType().Assembly.GetManifestResourceStream("Hangman.FamilyFeud-Buzzer3.wav");
            SoundPlayer snd = new SoundPlayer(str);
            snd.Play();
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
