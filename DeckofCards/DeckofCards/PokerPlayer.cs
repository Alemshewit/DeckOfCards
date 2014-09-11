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

        //2 distinct sets with 1 being 4
        public bool HasFourOfAKind()
        {
            if (this.Cards.Select(x => x.Rank).Distinct().Count() == 2)
            {
                IEnumerable<IGrouping<Rank, Card>> group = this.Cards.GroupBy(x => x.Rank);
                return group.Any(x => x.Count() == 4);
            }
            else return false;
        }
        public bool HasFullHouse()
        {
            if (this.Cards.Select(x => x.Rank).Distinct().Count() == 2)
            {
                IEnumerable<IGrouping<Rank, Card>> group = this.Cards.GroupBy(x => x.Rank);
                return group.Any(x => x.Count() == 3);
            }
            else return false;
        }

        public bool HasFlush()
        {
            return this.Cards.Select(x => x.Suit).Distinct().Count() == 1;
        }

        public bool HasStraight()
        {
            if (this.Cards.Select(x => x.Rank).Distinct().OrderBy(x => x).Last() - this.Cards.Select(x => x.Rank).Distinct().OrderBy(x => x).First() == 4)
            {
                return true;
            }
            else return false;
        }

        public bool HasThreeOfAKind()
        {
            //Grouping
            IEnumerable<IGrouping<Rank, Card>> group = this.Cards.GroupBy(x => x.Rank);
            return group.Any(x => x.Count() == 3);
        }

        public bool HasTwoPair()
        {
            return this.Cards.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count() == 2;
        }

        public bool HasPair()
        {
            return this.Cards.Select(x => x.Rank).Distinct().Count() == 4;
        }
       
        public void HasHighCard()
        {
            if (HasPair() == false && HasTwoPair() == false && HasThreeOfAKind() == false && HasStraight() == false && HasFlush() == false && HasFullHouse() == false
                && HasFourOfAKind() == false && HasStraightFlush() == false && HasRoyalFlush() == false)
            {
                Console.WriteLine("High card of: " + this.Cards.Select(x => x.Rank).OrderBy(x => x).Last().ToString());
            }
        }
    }
}
