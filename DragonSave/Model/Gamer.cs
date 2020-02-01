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
        public bool IsDefenced { get; set; }

        public static List<string> GamerCardControls = new List<string> { "Card11", "Card12", "Card13", "Card14" };
        public List<Card> GamerCards { set; get; }
        public List<Card> GamerEggs { get; set; }
        public List<Card> GamerDragons { get; set; }
        public Gamer()
        {
            GamerID = gamerCounter;
            Name = GetGamerName();
            GamerEggs = new List<Card> { };
            GamerDragons = new List<Card> { };
            GamerCards = new List<Card> { };
        }

        private string GetGamerName()
        {
            string Name = Names[gamerCounter];
            gamerCounter++;
            if (gamerCounter > 3)
                gamerCounter = 0;
            return Name;
        }


    }
}
