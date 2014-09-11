using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckofCards
{
    class Program
    {
        static void Main(string[] args)
        {
            PokerPlayer player = new PokerPlayer();
            if (player.HasPair() == true)
            {
                Console.WriteLine("PAIR");
            }
            if (player.HasTwoPair() == true)
            {
                Console.WriteLine("TWO PAIR");
            }
            if (player.HasThreeOfAKind() == true)
            {
                Console.WriteLine("THREE OF A KIND");
            }
            if (player.HasStraight() == true)
            {
                Console.WriteLine("STRAIGHT");
            }
            if (player.HasFullHouse() == true)
            {
                Console.WriteLine("FULL HOUSE");
            }
            if (player.HasRoyalFlush() == true)
            {
                Console.WriteLine("ROYAL FLUSH. HOW DID YOU DO THAT?");
            }
            if (player.HasFourOfAKind() == true)
            {
                Console.WriteLine("FOUR OF A KIND");
            }
            if (player.HasStraightFlush() == true)
            {
                Console.WriteLine("STRAIGHT FLUSH");
            }
            player.HasHighCard();

            //deck.PrintDeck();
          
            Console.ReadKey();
        }
    }
}
