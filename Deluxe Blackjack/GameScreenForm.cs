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
    public partial class GameScreenForm : Form
    {
        //Declare new variables
        Game newGame = new Game();
        PictureBox[][] cardBoxes;

        public GameScreenForm()
        {
            InitializeComponent();
            newGame.getDeck().shuffleDeck();    //Shuffles deck on load
            this.ControlBox = false;    //Disables the close button.
            cardBoxes = new PictureBox[2][]
            {
                new PictureBox[5]{playerCard1, playerCard2, playerCard3, playerCard4, playerCard5},
                new PictureBox[5]{cpuCard1, cpuCard2, cpuCard3, cpuCard4, cpuCard5}
            };
        }

        private void GameScreenForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //If the 'Deal'/'Hit' button is clicked
        private void dealBtn_Click(object sender, EventArgs e)
        {
            //Checks to see whan phase it is in, so the correct information can be displayed
            if ((string)hitBtn.Tag == "BetPhase")
            {
                //Place bet based on user input
                try
                {
                    if (newGame.placeBet(Convert.ToInt32(betInput.Text)))
                    {
                        //Checks to see if it is the first bet of the game
                        if (newGame.getGameStatus() ==  false)
                        {
                            //Cannot 'Walk Away' on first bet
                            newGame.setGameStatus(true);
                            stayBtn.Visible = true;
                        }
                        hitBtn.Tag = "GamePhase";   //Changes phase
                        hitBtn.Text = "Hit";
                        showDisplay();  //Chhnages the display
                        newGame.deal();
                        //Updates display
                        showCards("user");
                        playerTotalLabel.Text = "Player Total\n" + newGame.getUser().getPlayerTotal();
                        cpuTotalLabel.Text = "Dealer Total\n" + newGame.getCPU().getHand()[1].getValue();
                    }
                    //If bet size is invalid, bet is not placed and text field is reset
                    else
                    {
                        betInput.Text = "";
                    }
                }
                catch (Exception)
                {
                    //In case of non-integer input etc
                    MessageBox.Show("Invalid input.", "Invalid input");
                    betInput.Text = "";
                }
            }
            else
            {
                //User draws card
                newGame.getUser().add(newGame.getDeck().drawCard());
                if (newGame.getUser().getPlayerTotal() > 21)
                {
                    //If user is going bust (over 21), checks to see if they Have any Aces that can have thier value counted as 1 instead of 11
                    for(int index = 0; index < newGame.getUser().getTotalCards(); index++)
                    {
                        if(newGame.getUser().getHand()[index].getRank() == "A" && newGame.getUser().getHand()[index].getValue() == 11)
                        {
                            newGame.getUser().getHand()[index].setValue(1);
                            break;
                        }
                    }
                }
                //Updates all info
                newGame.getUser().updateTotal();
                showCards("user");
                playerTotalLabel.Text = "Player Total\n" + newGame.getUser().getPlayerTotal();
                System.Threading.Thread.Sleep(1);
                //If hand needs to be resolved without a dealer trun, goes straight to hand resolution (player blackjack, 5 card trick or bust)
                if (newGame.getUser().getTotalCards() == 5 || newGame.getUser().getPlayerTotal() > 21)
                {
                    newGame.handResolution();
                }
                else if (newGame.getUser().getPlayerTotal() == 21)
                {
                    newGame.dealerTurn();
                }
            }

        }

        //If the 'Walk Away'/'Stay' button is clicked
        private void stayBtn_Click(object sender, EventArgs e)
        {
            //Checks to see whan phase it is in, so the correct information can be displayed
            if ((string)hitBtn.Tag == "BetPhase")
            {
                //User 'Walks Away' and game ends
                newGame.endGame();
            }
            else
            {
                //User finishes thier turn and passes it on to dealers turn
                MessageBox.Show("Turn over, dealers turn.", "Turn over");
                newGame.dealerTurn();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Updates the screen with all relevant information/buttons/labels etc depending on the Phase
        public void showDisplay()
        {
            //If in bet phase show bet-relevant info only
            if((string)hitBtn.Tag == "BetPhase")
            {
                hitBtn.Text = "Deal";
                stayBtn.Text = "Walk Away";
                betChips.Visible = false;
                betAmount.Visible = false;
                cpuTotalLabel.Visible = false;
                playerTotalLabel.Visible = false;
                betTitle.Visible = true;
                betInput.Visible = true;
                betInput.Text = "";
            }
            //If in game phase show game-relevant info only
            else
            {
                hitBtn.Text = "Hit";
                stayBtn.Text = "Stay";
                betAmount.Text = "Bet: $" + newGame.getBet();
                betChips.Visible = true;
                betAmount.Visible = true;
                cpuTotalLabel.Visible = true;
                playerTotalLabel.Visible = true;
                betTitle.Visible = false;
                betInput.Visible = false;
            }
            //Always hide all cards (will be revealed as game progresses) and show updated bank
            bankAmount.Text = "Bank: $" + newGame.getBank();
            foreach (PictureBox[] array in cardBoxes)
            {
                foreach (PictureBox cardBox in array)
                {
                    cardBox.Visible = false;
                }

            }
        }

        //Shows cards as they are added to each players hands
        public void showCards(string player)
        {
            for (int i = 0; i < newGame.getUser().getTotalCards(); i++)
            {
                cardBoxes[0][i].Visible = true;
                cardBoxes[0][i].Image = newGame.getUser().getHand()[i].getFaceImage();
                cardBoxes[0][i].Update();
            }

            for (int i = 0; i < newGame.getCPU().getTotalCards(); i++)
            {
                cardBoxes[1][i].Visible = true;
                if (i == 0 && player == "user")
                {
                    cardBoxes[1][i].Image = newGame.getCPU().getHand()[i].getBackImage();
                    cardBoxes[1][i].Update();
                }
                else
                {
                    cardBoxes[1][i].Image = newGame.getCPU().getHand()[i].getFaceImage();
                    cardBoxes[1][i].Update();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (resumeBtn.Visible)
            {
                resumeBtn.Visible = false;
                highScoresBtn.Visible = false;
                stopBtn.Visible = false;
            }
            else
            {
                resumeBtn.Visible = true;
                highScoresBtn.Visible = true;
                stopBtn.Visible = true;
            }
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            resumeBtn.Visible = false;
            highScoresBtn.Visible = false;
            stopBtn.Visible = false;
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            newGame.endGame();
        }

        private void highScoresBtn_Click(object sender, EventArgs e)
        {
            mainMenuGUI.scoreScreen.Show();
            mainMenuGUI.scoreScreen.returnBtn.Tag = "toGameScreen";
            this.Hide();
        }
    }
}
