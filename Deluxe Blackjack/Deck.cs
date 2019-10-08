using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Deluxe_Blackjack
{
    class Deck
    {
        //Properties
        private Card[] deck;        //Array of cards make up the deck
        private int topCardIndex;   //Next card to be drawn

        //Constructors
        public Deck()
        {
            string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            string[] suits = { "H", "D", "S", "C" };
            int position = 0;

            //Builds new deck
            //Creates 6 'Standard decks' (52 cards)
            deck = new Card[312];
            for (int deckNumber = 0; deckNumber < 6; deckNumber++)
            {
                //Each of the four suits
                for (int suitNumber = 0; suitNumber < 4; suitNumber++)
                {
                    //Each of the thirteen ranks
                    for (int rankNumber = 0; rankNumber < 13; rankNumber++)
                    {
                        //Set the filename of the image based on the above information
                        string imageName = "Deluxe_Blackjack.Cards." + ranks[rankNumber] + suits[suitNumber] + ".jpg";

                        //Load the image
                        Assembly myAssembly = Assembly.GetExecutingAssembly();
                        Stream myStream = myAssembly.GetManifestResourceStream(imageName);
                        Bitmap bmp = new Bitmap(myStream);

                        //Determine the value of the card
                        int value;
                        if (rankNumber == 0)
                        {
                            value = 11;
                        }
                        else if (rankNumber > 0 && rankNumber < 9)
                        {
                            value = rankNumber + 1;
                        }
                        else
                        {
                            value = 10;
                        }
                        //Create the card and add it to deck
                        Card newCard = new Card(suitNumber, ranks[rankNumber], value, bmp, Properties.Resources.blue_back);
                        deck[position] = newCard;
                        position++;
                    }
                }
            }
            topCardIndex = 0;
        }

        //Methods
        //Shuffles the deck and resets the top card (to 0)
        public void shuffleDeck()
        {
            Random rand = new Random();

            //Takes each card and randomly swaps it with another in the array
            for (int first = topCardIndex; first < (deck.Count() - topCardIndex); first++)
            {
                //Randomly select a second card
                int second = rand.Next(deck.Count() - topCardIndex);
                //Swap the cards
                Card temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            }
            topCardIndex = 0;
        }

        //Draws a card from the deck and increases the top card
        public Card drawCard()
        {
            Card drawCard = deck[topCardIndex];
            //Makes sure all aces have 11 value to start with (in case it has been changed and shuffled back in)
            if (drawCard.getRank() == "A")
            {
                drawCard.setValue(11);
            }
            topCardIndex++;
            //If deck gets too small, shuffles it again
            if (deck.Length - topCardIndex < 26)
            {
                shuffleDeck();
            }
            return drawCard;
        }

        //Getters and setters
        public void setDeck(Card[] deck)
        {
            this.deck = deck;
        }

        public Card[] getDeck()
        {
            return deck;
        }

        public void setTopCardIndex(int topCardIndex)
        {
            this.topCardIndex = topCardIndex;
        }

        public int getTopCardIndex()
        {
            return topCardIndex;
        }
    }
}
