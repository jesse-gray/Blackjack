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
    public partial class betScreenGUI : Form
    {
        //Declare new forms
        public static GameScreenForm gameScreenForm = new GameScreenForm();

        public betScreenGUI()
        {
            InitializeComponent();

            bankTotal.Text = "Bank - $100";
            this.ControlBox = false; //Disables the close button.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void newGameBtn_Click(object sender, EventArgs e)
        {
            //Open new window form (bet screen) and hide current form.
            gameScreenForm.Show();   //Show new form
            this.Hide();    //Hide current form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Go back to main menu
            Program.mainMenu.Show();
            this.Hide();
        }

        private void betScreenGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
