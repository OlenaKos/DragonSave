using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSave
{
    class Deck
    {
        public static int amountVillain = 4;
        public static int amountDragon = 14;
        public static int amountEgg = 14;
        public static int amountMother = 15;
        public static int amountFather = 15;
        public static int amountNest = 12;
        public List<Card> deck { get; set; }
        public Deck() 
        {
            List<Card> deckTemp = new List<Card> { };
            for (int i = 0; i < amountVillain; i++)
            {
                deckTemp.Add(new Villain());
            }
            for (int i = 0; i < amountNest; i++)
            {
                deckTemp.Add(new Nest());
            }
            for (int i = 0; i < amountMother; i++)
            {
                deckTemp.Add(new Mother());
            }
            for (int i = 0; i < amountFather; i++)
            {
                deckTemp.Add(new Father());
            }
            deck = new List<Card> { };
            Random random = new Random();
            while (deckTemp.Count > 0)
	            {
                    int randomCardID = random.Next(0, deckTemp.Count);
                    deck.Add(deckTemp[randomCardID]);
                    deckTemp.RemoveAt(randomCardID);
	            }

            //GamerController

        }
    }
}
