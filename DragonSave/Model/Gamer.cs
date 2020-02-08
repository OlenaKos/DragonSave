using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSave
{

    class Gamer
    {
        public static string[] Names = new string[] { "James Bond", "Harry Potter", "Sara O'Connor", "Chuck Norris" };
        public static int gamerCounter = 0;
        public int GamerID { get; set; }
        public string Name { get; set; }

        public static List<string> GamerCardControls = new List<string> { "Card11", "Card12", "Card13", "Card14" };
        public List<Card> GamerCards { set; get; }
        public List<Card> GamerEggs { get; set; }
        public List<Card> GamerDragons { get; set; }

        public List<Combinations> GamerPossibleComb { get; set; }
        public Gamer()
        {
            GamerID = gamerCounter;
            Name = GetGamerName();
            GamerEggs = new List<Card> { };
            GamerDragons = new List<Card> { };
            GamerCards = new List<Card> { };
            GamerPossibleComb = new List<Combinations>() { };
        }

        private string GetGamerName()
        {
            string Name = Names[gamerCounter];
            gamerCounter++;
            if (gamerCounter > Names.Length - 1)
                gamerCounter = 0;
            return Name;
        }

        public List<Card> GetCardFromDeck(Gamer gamer, Deck cardDeck, int cardCount)
        {
            List<Card> cards = new List<Card> { };
            for (int i = 0; i < cardCount; i++)
            {
                cards.Add(cardDeck.deck[0]);
                cardDeck.deck.RemoveAt(0);
            }

            return cards;
        }

    }
}