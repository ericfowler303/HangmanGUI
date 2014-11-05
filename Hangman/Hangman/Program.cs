using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Random rng = new Random();
            // Fill the possible words
            List<string> possibleWords = new List<string>() { "apple", "orange", "grapes" };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start the program with a randomly guessed word
            Application.Run(new Hangman(possibleWords.ElementAt(rng.Next(possibleWords.Count))));
        }
    }
}
