using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckofCards
{
    public enum Rank
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public enum Suit
    {
        Spades = 1,
        Clubs,
        Diamonds,
        Hearts
    }

    class Card
    {
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public Card(Rank rank, Suit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public string GetCardString()
        {
            return this.Rank + " of " + this.Suit;
        }
    }
}
