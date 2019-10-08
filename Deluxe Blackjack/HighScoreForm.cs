using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deluxe_Blackjack
{
    public partial class HighScoreForm : Form
    {
        //Declare global variables
        public Label[] scoreBoxes;

        public HighScoreForm()
        {
            InitializeComponent();
            this.ControlBox = false; //Disables the close button.
            scoreBoxes = new Label[10] {highScore1, highScore2, highScore3, highScore4, highScore5, highScore6, highScore7, highScore8, highScore9, highScore10};
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            //Check how we got to this page and go back there
            if ((string)returnBtn.Tag == "toGameScreen")
            {
                //Go Back to game
                mainMenuGUI.gameScreen.Show();
                returnBtn.Tag = "toMainMenu";
                mainMenuGUI.gameScreen.resumeBtn.Visible = false;
                mainMenuGUI.gameScreen.highScoresBtn.Visible = false;
                mainMenuGUI.gameScreen.stopBtn.Visible = false;
                this.Hide();
            }
            else if ((string)returnBtn.Tag == "toMainMenu")
            {
                //Go back to main menu
                Program.mainMenu.Show();
                this.Hide();
            }
        }

        private void HighScoreForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
