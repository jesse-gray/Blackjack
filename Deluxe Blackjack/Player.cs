using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deluxe_Blackjack
{
    class Player
    {
        //Properties
        private Card[] hand;
        private int playerTotal;
        private int totalCards;

        //Constructors
        public Player()
        {
            hand = new Card[5];     //Array of cards makes up the hand
            playerTotal = 0;        //Score of all of the cards in the hand
            totalCards = 0;         //Number of cards in the hand
        }

        //Methods
        //Adds a card to the players hand
        public void add(Card toAdd)
        {
            if (totalCards < 5)
            {
                hand[totalCards] = toAdd;
                totalCards++;
            }
            updateTotal();      //Total must be kept up to date
        }

        //Updates the total value of the cards in the players hand
        public void updateTotal()
        {
            playerTotal = 0;
            for (int index = 0; index < totalCards; index++)
            {
                playerTotal += hand[index].getValue();
            }
        }

        //Setters and getters
        public void setHand(Card[] hand)
        {
            this.hand = hand;
        }

        public Card[] getHand()
        {
            return hand;
        }

        public void setPlayerTotal(int playerTotal)
        {
            this.playerTotal = playerTotal;
        }

        public int getPlayerTotal()
        {
            return playerTotal;
        }

        public void setTotalCards(int totalCards)
        {
            this.totalCards = totalCards;
        }

        public int getTotalCards()
        {
            return totalCards;
        }
    }
}
