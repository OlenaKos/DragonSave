using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSave
{

    class Game
    {
        public static int MoveCounter = 0;
        public static bool isGameRunning = true;
        public static int CurrentGamer { set; get; }
        public List<Gamer> Gamers { get; set; }
        public Deck MainDeck { set; get; }

        public Controller controller { get; set; }

        public Game(int GamersCount, Controller control)
        {
            MainDeck = new Deck();
            CurrentGamer = 0;
            Gamers = new List<Gamer> { };
            Gamers.Add(new RealGamer());
            for (int i = 1; i < GamersCount; i++)
            {
                Gamers.Add(new Bot());
            }
            controller = control;
            controller.gameController.GiveCardsToGamers(this, MainDeck);
            controller.gamerController.CheckPossibleCombinations(Gamers[0]);
            

        }

    }
}
