 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSave
{
    class Controller
    {
        public GameController gameController { get; set; }
        public GamerController gamerController { get; set; }
        public Controller()
        {
            gameController = new GameController();
            gamerController = new GamerController();
        }
        public Game StartGame(int gamersCount)
        {
            Game game = new Game(gamersCount, this.gameController);
            return game;
        }
    }
}
