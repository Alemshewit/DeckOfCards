using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckofCards
{
    class Deck
    {
        public List<Card> Cards { get; set; }
        public List<Card> DealtCards { get; set; }
        public Deck()
        {
            //Empty list of cards to build on
            this.Cards = new List<Card>();
            //Track dealt cards here
            this.DealtCards = new List<Card>();

            //Card suits
            for (int s = 1; s <= 4; s++)
            {
                //Card rank
                for (int r = 2; r <= 14; r++)
                {
                    //create a new card and add it to the card list.
                    this.Cards.Add(new Card((Rank)r, (Suit)s));
                }
            }
        }

        //"Fisher-Yates shuffle" from stackoverflow
        public void Shuffle()
        {
            Random shuffle = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                int k = shuffle.Next(i, Cards.Count);
                Card tmp = Cards[k];
                Cards[k] = Cards[i];
                Cards[i] = tmp;
            }
        }

        //Print the cards
        public void PrintDeck()
        {
            Console.WriteLine(string.Join("\n", this.Cards.Select(x => x.GetCardString())));
        }

        //Deal a certain number of cards
        public List<Card> Deal(int numCards)
        {
            List<Card> hand = new List<Card>();
            for (int i = 0; i < numCards; i++)
            {
                //Add last card to hand
                hand.Add(Cards.Last());
                //Add to drawn deck
                DealtCards.Add(Cards.Last());
                //Remove from other deck
                Cards.Remove(Cards.Last());
            }
            return hand;
        }     
    }
}
