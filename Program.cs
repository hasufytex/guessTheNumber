using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guessTheNumber
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                // Create an instance of the Menu form
                Menu menuForm = new Menu();

                // Show the Menu form
                Application.Run(menuForm);

                // Check if the menu form needs to open the game form
                if (menuForm.NeedsToOpenGame)
                {
                    // Create and show the Game form
                    Game gameForm = new Game(menuForm.SelectedDifficulty);
                    Application.Run(gameForm);
                }
                else
                {
                    // If the menu form was closed by the user (not by opening the game form), exit the application
                    if (menuForm.ClosedByUser)
                    {
                        break;
                    }
                }
            }
        }
    }
}
