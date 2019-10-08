using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deluxe_Blackjack
{
    public partial class mainMenuGUI : Form
    {
        //Declare new variables
        public static HighScoreForm scoreScreen = new HighScoreForm();
        public static GameScreenForm gameScreen = new GameScreenForm();
        //public static string[] highScores = new string[10];

        public mainMenuGUI()
        {
            InitializeComponent();
            //Load highscores on initialise
            loadHighScores();
            updateHighScores(-1);
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Open new window form (game screen) and hide current form.
            gameScreen.Show();   //Show new form
            gameScreen.hitBtn.Tag = "BetPhase"; //Set display to 'Bet Screen'
            gameScreen.showDisplay();
            this.Hide();    //Hide current form
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Open new window form (high score screen) and hide current form.
            scoreScreen.Show();   //Show new form
            this.Hide();    //Hide current form

        }

        private void rulesBtn_Click(object sender, EventArgs e)
        {
            //Pop up message displaying game rules
            string title = "Game Rules";
            string message = "The goal in blackjack is to get a score as close to 21 as posible, if you go over 21, you lose." +
                "\nYou can choose to 'Hit' to draw another card or 'Stay' if you are happy with your score and end your turn." +
                "\nOnce your turn is over the dealer has a turn, after which, your scores are compared." +
                "\nWhoever has the highest score wins." +
                "\n\nBetting:" +
                "\nYou start with $100 and can bet as much as you want each hand." +
                "\nIf you win a hand you get double your bet, if you lose you get nothing back. In the case of a tie, you recieve your bet back." +
                "\n\nSpecial Circumstances:" +
                "\nBlackjack - If you get 21 on your first 2 cards you instantly win double your bet, plus another half of the bet." +
                "\n5 Card Trick - If you manage to get 5 cards without your score going over 21, you instantly win and get double your bet back." +
                "\n\nOther:" +
                "\nAll cards have the value of their face (2=2, 3=3 etc) with the following exceptions:" +
                "\nJ, Q and K have a value of 10." +
                "\nAce has a value of both 1 and 11 (if you go over 21 with and ace, you get a second chance).";

            //Call message box
            MessageBox.Show(message, title);
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            //Save scores and quit program
            saveHighScores();
            Application.Exit();
        }

        //Declare highScores arrays
        string[] names = new string[10];
        int[] scores = new int[10];

        //Loads high scores from a text file and stores them in arrays 
        public void loadHighScores()
        {
            //Open new stream toi read from file
            //StreamReader sr = new StreamReader("../../highScores.txt");
            StreamReader sr = new StreamReader("../../test.txt");
            //Read from file
            string line = "";
            int lineNumber = 0;
            while ((line = sr.ReadLine()) != null)
            {
                string[] lineComponents = line.Split(':');
                names[lineNumber] = lineComponents[0];
                scores[lineNumber] = Convert.ToInt32(lineComponents[1]);
                lineNumber++;
            }
            //Close stream
            sr.Close();
        }

        //Sorts high score list and updates the High Score page
        //Returns whether the score is in the top 10 or not
        public bool updateHighScores(int playerScore)
        {
            bool isAHighScore = false;

            //Sort scores 
            //Checks against top 10 list starting at the highest score
            for (int index = 0; index < scores.Length; index++)
            {
                //Checks if new score is higher than the one in the top 10
                if (playerScore > scores[index])
                {
                    //It removes the lowest score in the top 10, and replaces it with the 9th, which is replaced with the 8th etc
                    //Stops this cycle when it gets to the right position and instead replaces it with the new high score
                    for (int j = 9; j > index; j--)
                    {
                        scores[j] = scores[j - 1];
                        names[j] = names[j - 1];
                    }
                    scores[index] = playerScore;
                    names[index] = nameInput();
                    isAHighScore = true;
                    //Breaks out of loop to prevent multiple instances of the same score being saved 
                    break;
                }
            }

            //Display high scores on scoreScreen
            for (int i = 0; i < 10; i++)
            {
                scoreScreen.scoreBoxes[i].Text = names[i] + " - $" + Convert.ToString(scores[i]);
            }

            //Saves to file after every new entry
            saveHighScores();

            //Returns confirmation that it is in top 10
            return isAHighScore;
        }

        //Saves high scores to text file
        //Used whenever high scores are updated or the game is closed
        public void saveHighScores()
        {
            //Open new stream to write to text file
            //StreamWriter sw = new StreamWriter("../../highScores.txt");
            StreamWriter sw = new StreamWriter("../../test.txt");
            //Write to filestring scoreString = "";
            string scoreString = "";
            for (int i = 0; i < scores.Length; i++)
            {
                scoreString += names[i] + ":" + scores[i] + Environment.NewLine;
            }
            sw.Write(scoreString);
            //Close stream
            sw.Close();
        }

        //This takes the new high score and formats it to be stored in the array
        //Needs to be in this format for I/O
        public static string nameInput()
        {
            //New dialog window asking for name input
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "New High Score",
                StartPosition = FormStartPosition.CenterScreen,
                ControlBox = false
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Width = 200, Height = 35, Text = "Congratulations! New high score.\nPlease input name:" };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
            Button confirmation = new Button() { Text = "Ok", Left = 115, Width = 70, Top = 70, DialogResult = DialogResult.OK };
            //On button click, name is entered
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            //Makes sure it doenst enter an empty string
            if (textBox.Text == "")
            {
                textBox.Text = "Default";
            }

            //Returns the correct name and score format
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        //Loads high scores from a text file and stores them in an array 
        //(in the format '[Name] - $[Score]')
        //public void loadHighScores()
        //{
        //    //Open new stream toi read from file
        //    StreamReader sr = new StreamReader("../../highScores.txt");
        //    //Read from file
        //    string line = "";
        //    int lineNumber = 1;
        //    while ((line = sr.ReadLine()) != null)
        //    {
        //        highScores[lineNumber - 1] = line;
        //        lineNumber++;
        //    }
        //    //Close stream
        //    sr.Close();
        //}

        //Saves high scores to text file
        //Used whenever high scores are updated or the game is closed
        //public void saveHighScores()
        //{
        //    //Open new stream to write to text file
        //    StreamWriter sw = new StreamWriter("../../highScores.txt");
        //    //Write to file
        //    string toSave = string.Join("\n", highScores);
        //    sw.Write(toSave);
        //    //Close stream
        //    sw.Close();
        //}

        ////Sorts high score list and updates the High Score page
        ////Returns whether the score is in the top 10 or not
        //public bool updateHighScores(int playerScore)
        //{
        //    bool isAHighScore = false;

        //    //Sort scores 
        //    //Checks against top 10 list starting at the highest score
        //    for (int index = 0; index < highScores.Length; index++)
        //    {
        //        //Isolates the score (integer) from the string in the high score array
        //        int highScore = Convert.ToInt32(highScores[index].Substring(highScores[index].IndexOf("$") + 1));
        //        //Checks if new score is higher than the one in the top 10
        //        if (playerScore > highScore)
        //        {
        //            //It removes the lowest score in the top 10, and replaces it with the 9th, which is replaced with the 8th etc
        //            //Stops this cycle when it gets to the right position and instead replaces it with the new high score
        //            for (int j = 9; j > index; j--)
        //            {
        //                highScores[j] = highScores[j - 1];
        //            }
        //            highScores[index] = nameScoreFormatter(playerScore);
        //            isAHighScore = true;
        //            //Breaks out of loop to prevent multiple instances of the same score being saved 
        //            break;
        //        }
        //    }

        //    //Display high scores on scoreScreen
        //    for (int i = 0; i < 10; i++)
        //    {
        //        scoreScreen.scoreBoxes[i].Text = highScores[i];
        //    }

        //    //Saves to file after every new entry
        //    saveHighScores();

        //    //Returns confirmation that it is in top 10
        //    return isAHighScore;
        //}

        ////This takes the new high score and formats it to be stored in the array
        ////Needs to be in this format for I/O
        //public static string nameScoreFormatter(int score)
        //{
        //    //New dialog window asking for name input
        //    Form prompt = new Form()
        //    {
        //        Width = 300,
        //        Height = 150,
        //        FormBorderStyle = FormBorderStyle.FixedDialog,
        //        Text = "New High Score",
        //        StartPosition = FormStartPosition.CenterScreen,
        //        ControlBox = false
        //    };
        //    Label textLabel = new Label() { Left = 50, Top = 20, Width = 200,Height = 35, Text = "Congratulations! New high score.\nPlease input name:"};
        //    TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
        //    Button confirmation = new Button() { Text = "Ok", Left = 115, Width = 70, Top = 70, DialogResult = DialogResult.OK };
        //    //On button click, name is entered
        //    confirmation.Click += (sender, e) => {prompt.Close(); };
        //    prompt.Controls.Add(textBox);
        //    prompt.Controls.Add(confirmation);
        //    prompt.Controls.Add(textLabel);
        //    prompt.AcceptButton = confirmation;

        //    //Makes sure it doenst enter an empty string
        //    if (textBox.Text == "")
        //    {
        //        textBox.Text = "Default";
        //    }

        //    //Returns the correct name and score format
        //    return prompt.ShowDialog() == DialogResult.OK ? textBox.Text + " - $" + score : "";
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
