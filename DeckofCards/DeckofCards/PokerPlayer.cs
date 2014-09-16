using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckofCards
{
    enum HandRank
    {
        high,
        pair,
        twoPair,
        three,
        straight,
        flush,
        fullHouse,
        four,
        straightFlush,
        royal
    }

    class PokerPlayer
    {
        public List<Card> Cards {get; set;}

        public PokerPlayer()
        {
            //New deck of cards to deal to player
            this.Cards = new List<Card>();
            Deck deck = new Deck();
            //Shuffle for random draw
            deck.Shuffle();
            //Deal 5 cards
            this.Cards = deck.Deal(5);
            Console.WriteLine(string.Join("\n", this.Cards.Select(x => x.GetCardString())));
        }
        //Check for straight + flush + last card of Ace
        public bool HasRoyalFlush()
        {
            if ((this.Cards.Select(x => x.Rank).Distinct().OrderBy(x => x).Last() - this.Cards.Select(x => x.Rank).Distinct().OrderBy(x => x).First() == 4) && 
                (this.Cards.Select(x => x.Suit).Distinct().Count() == 1) && (this.Cards.Select(x => x.Rank).OrderBy(x => x).Last() == Rank.Ace))
            {
                return true;
            }
            else return false;
        }

        //Check for straight & flush
        public bool HasStraightFlush()
        {
            if ((this.Cards.Select(x => x.Rank).Distinct().OrderBy(x => x).Last() - this.Cards.Select(x => x.Rank).Distinct().OrderBy(x => x).First() == 4) && (this.Cards.Select(x => x.Suit).Distinct().Count() == 1))
            {
             return true;
            }
            else return false;
        }

        //2 distinct ranks with 1 containing 4 values
        public bool HasFourOfAKind()
        {
            if (this.Cards.Select(x => x.Rank).Distinct().Count() == 2)
            {
                IEnumerable<IGrouping<Rank, Card>> group = this.Cards.GroupBy(x => x.Rank);
                return group.Any(x => x.Count() == 4);
            }
            else return false;
        }
        
        //2 distinct ranks with one containing 3 values
        public bool HasFullHouse()
        {
            if (this.Cards.Select(x => x.Rank).Distinct().Count() == 2)
            {
                IEnumerable<IGrouping<Rank, Card>> group = this.Cards.GroupBy(x => x.Rank);
                return group.Any(x => x.Count() == 3);
            }
            else return false;
        }

        //Checks for 1 distinct suit
        public bool HasFlush()
        {
            return this.Cards.Select(x => x.Suit).Distinct().Count() == 1;
        }

        //Takes distinct cards, orders them, subtracts the value of the highest and lowest to see if it equals 4
        //It will only ever equal four if the cards are in order
        public bool HasStraight()
        {
            if (this.Cards.Select(x => x.Rank).Distinct().OrderBy(x => x).Last() - this.Cards.Select(x => x.Rank).Distinct().OrderBy(x => x).First() == 4)
            {
                return true;
            }
            else return false;
        }

        //Group and check to see if any of the groups have a count of 3
        public bool HasThreeOfAKind()
        {
            IEnumerable<IGrouping<Rank, Card>> group = this.Cards.GroupBy(x => x.Rank);
            return group.Any(x => x.Count() == 3);
        }

        //2 groups with 2 values (cards)
        public bool HasTwoPair()
        {
            return this.Cards.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count() == 2;
        }

        //4 distinct values = 1 value is the same => 1 pair
        public bool HasPair()
        {
            return this.Cards.Select(x => x.Rank).Distinct().Count() == 4;
        }
       
       //If all other bools return false, the player has a high card
        public void HasHighCard()
        {
            if (HasPair() == false && HasTwoPair() == false && HasThreeOfAKind() == false && HasStraight() == false && HasFlush() == false && HasFullHouse() == false
                && HasFourOfAKind() == false && HasStraightFlush() == false)
            {
                Console.WriteLine("High card of: " + this.Cards.Select(x => x.Rank).OrderBy(x => x).Last().ToString());
            }
        }
    }
}
