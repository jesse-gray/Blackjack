using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deluxe_Blackjack
{
    class Card
    {
        //Properties
        private int suit;           //(0)Hearts, (1)Diamonds, (2)Spades, (3)Clubs
        private string rank;        //Ace to King
        private int value;          //Value of cards (all face cards are 10)
        private Image faceImage;    //Front picture
        private Image backImage;    //Back picture (cardback)

        //Constructors
        public Card(int suit, string rank, int value, Image faceImage, Image backImage)
        {
            this.suit = suit;
            this.rank = rank;
            this.value = value;
            this.faceImage = faceImage;
            this.backImage = backImage;
        }

        //Methods
        //Getters and setters
        public void setSuit(int suit)
        {
            this.suit = suit;
        }

        public int getSuit()
        {
            return this.suit;
        }

        public void setRank(string rank)
        {
            this.rank = rank;
        }

        public string getRank()
        {
            return this.rank;
        }

        public void setValue(int value)
        {
            this.value = value;
        }

        public int getValue()
        {
            return this.value;
        }

        public void setFaceImage(Image faceImage)
        {
            this.faceImage = faceImage;
        }

        public Image getFaceImage()
        {
            return this.faceImage;
        }

        public void setBackImage(Image backImage)
        {
            this.backImage = backImage;
        }

        public Image getBackImage()
        {
            return this.backImage;
        }
    }
}
