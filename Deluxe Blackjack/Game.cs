using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deluxe_Blackjack
{
    class Game
    {
        //Properties
        private Deck deck;              //Game deck
        private Player user;            //Human controlled player
        private Player CPU;             //Human controlled player
        private int bank;               //Users current score
        private int bet;                //Bet of the current hand
        private double betMultiplier;   //Determined by hand outcome
        private bool gameStatus;        //Is it a new game or current

        //Constructors
        public Game()
        {
            deck = new Deck();
            user = new Player();
            CPU = new Player();
            bank = 100;
            bet = 0;
            betMultiplier = 0;
            gameStatus = false;
        }

        //Methods
        //Places a bet before the hand starts
        public bool placeBet(int newBet)
        {
            //Bet must be over 0
            if (newBet <= 0)
            {
                MessageBox.Show("Bet size must be more than 0.", "Bet too small");
                return false;
            }
            //Bet cannot be larger than what the polayer has in total
            else if (newBet > bank)
            {
                MessageBox.Show("Bet size cannot exceed bank.", "Bank exceeded");
                return false;
            }
            //If bet is okay, it is placed
            else
            {
                bet = newBet;
                bank -= bet;
                return true;
            }
        }

        //The opening action of the hand, both players draw 2 cards
        public void deal()
        {
            user.add(deck.drawCard());
            user.add(deck.drawCard());
            CPU.add(deck.drawCard());
            CPU.add(deck.drawCard());
            //If player gets blackjack (21), the game immediately moves on to the resolution with a dealer turn
            if (user.getPlayerTotal() == 21)
            {
                mainMenuGUI.gameScreen.showCards("user");
                handResolution();
            }
        }

        //Hand reset after the round, ready for another
        public void resetHand()
        {
            user = new Player();
            CPU = new Player();
            mainMenuGUI.gameScreen.hitBtn.Tag = "BetPhase";     //Game phase changed
            mainMenuGUI.gameScreen.showDisplay();
        }

        //This runs through the dealers turn
        public void dealerTurn()
        {
            System.Threading.Thread.Sleep(1000);    //Waits 1 second to simulate drawing a card
            //Flips the dealers first card face-up
            mainMenuGUI.gameScreen.cpuCard1.Image = CPU.getHand()[0].getFaceImage();
            mainMenuGUI.gameScreen.cpuTotalLabel.Text = "Dealer Total\n" + CPU.getPlayerTotal();
            mainMenuGUI.gameScreen.cpuCard1.Update();
            mainMenuGUI.gameScreen.cpuTotalLabel.Update();
            //Dealer must keep 'hitting' until it reaches 17 total score
            while (CPU.getPlayerTotal() < 17)
            {
                CPU.add(deck.drawCard());
                //If score goes over 21, checks to see if there is an ace than can be counted as 1 score (instead of 11)
                if (CPU.getPlayerTotal() > 21)
                {
                    for (int index = 0; index < CPU.getTotalCards(); index++)
                    {
                        if (CPU.getHand()[index].getRank() == "A" && CPU.getHand()[index].getValue() == 11)
                        {
                            CPU.getHand()[index].setValue(1);
                            break;
                        }
                    }
                }
                //Updates relevant information
                System.Threading.Thread.Sleep(1000);
                mainMenuGUI.gameScreen.showCards("cpu");
                CPU.updateTotal();
                mainMenuGUI.gameScreen.cpuTotalLabel.Text = "Dealer Total\n" + CPU.getPlayerTotal();
                mainMenuGUI.gameScreen.cpuTotalLabel.Update();
            }
            //Once dealers hand is complete, the hand resolution happens
            System.Threading.Thread.Sleep(1000);
            handResolution();
        }

        //Checks the outcome of the game
        public void handResolution()
        {
            //Declare variables
            string message = "";
            string title = "";
            //If user has blackjack
            if (user.getTotalCards() == 2 && user.getPlayerTotal() == 21)
            {
                message = "You have blackjack! You win!";
                title = "Winner winner, chicken dinner";
                betMultiplier = 2.5;
            }
            //If user has 5 card trick
            else if (user.getTotalCards() == 5 && user.getPlayerTotal() < 21)
            {
                message = "You have 5 card trick! You win!";
                title = "You win";
                betMultiplier = 2;
            }
            //If both players dont bust but the user has the higher score
            else if ((user.getPlayerTotal() <= 21) && (user.getPlayerTotal() > CPU.getPlayerTotal()) && (CPU.getPlayerTotal() <= 21))
            {
                message = "You have a better score than the dealer! You win!";
                title = "You win";
                betMultiplier = 2;
            }
            //If both players dont bust but the dealer has the higher score
            else if ((user.getPlayerTotal() <= 21) && (user.getPlayerTotal() < CPU.getPlayerTotal()) && (CPU.getPlayerTotal() <= 21))
            {
                message = "Dealer has a better score than you! You lose!";
                title = "You lose";
                betMultiplier = 0;
            }
            //If the dealer goes bust
            else if ((user.getPlayerTotal() <= 21) && (CPU.getPlayerTotal() > 21))
            {
                message = "Dealer has gone bust! You win!";
                title = "You win";
                betMultiplier = 2;
            }
            //If both players have the same score
            else if ((user.getPlayerTotal() <= 21) && (user.getPlayerTotal() == CPU.getPlayerTotal()))
            {
                message = "You have the same score as the dealer! Tied game!";
                title = "Push";
                betMultiplier = 1;

            }
            //If the user goes bust
            else if (user.getPlayerTotal() > 21)
            {
                message = "You have gone bust! You lose!";
                title = "Bust";
                betMultiplier = 0;
            }
            //Bank uodated based on bet and outcome
            bank += (int)(bet * betMultiplier);
            mainMenuGUI.gameScreen.hitBtn.Tag = "BetPhase";
            MessageBox.Show(message, title);

            //If player still has money in the bank, otherwise game over
            if (bank > 0)
            {
                resetHand();
            }
            else
            {
                endGame();
            }

        }

        //When the game is over (user runs out of money or walks away)
        public void endGame()
        {
            MessageBox.Show("Game Over!\nFinal Score: " + bank, "Game Over");       //Game result displayed to user
            //Checks and updates high scores
            if (Program.mainMenu.updateHighScores(bank))
            {
                mainMenuGUI.scoreScreen.Show();     //Opens high score screen if a high score
            }
            else
            {
                Program.mainMenu.Show();        //Opens main menu if not a high score
            }
            //Resets everything back to the start of the game
            gameStatus = false;
            deck.shuffleDeck();
            bank = 100;
            resetHand();
            mainMenuGUI.gameScreen.Hide();
            mainMenuGUI.gameScreen.stayBtn.Visible = false;
        }

        //Setters and getters
        public void setDeck(Deck deck)
        {
            this.deck = deck;
        }

        public Deck getDeck()
        {
            return deck;
        }

        public void setUser(Player user)
        {
            this.user = user;
        }

        public Player getUser()
        {
            return user;
        }

        public void setCPU(Player CPU)
        {
            this.CPU = CPU;
        }

        public Player getCPU()
        {
            return CPU;
        }

        public void setBank(int bank)
        {
            this.bank = bank;
        }

        public int getBank()
        {
            return bank;
        }

        public void setBet(int bet)
        {
            this.bet = bet;
        }

        public int getBet()
        {
            return bet;
        }

        public void setBetMultiplier(double betMultiplier)
        {
            this.betMultiplier = betMultiplier;
        }

        public double getBetMultiplier()
        {
            return betMultiplier;
        }

        public void setGameStatus(bool gameStatus)
        {
            this.gameStatus = gameStatus;
        }

        public bool getGameStatus()
        {
            return gameStatus;
        }
    }
}
