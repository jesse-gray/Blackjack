using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deluxe_Blackjack
{
    static class Program
    {
        //Declare global variables
        public static mainMenuGUI mainMenu;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainMenu = new mainMenuGUI();
            Application.Run(mainMenu);
        }
    }
}