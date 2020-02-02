using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSave
{
    class GameController
    {

        public void GiveCardsToGamers(List<Gamer> gamers, Deck deck)
        {
            int AmountCardsToGive = 4;
            foreach (var gamer in gamers)
            {
                for (int i = 0; i < AmountCardsToGive; i++)
                {
                    gamer.GamerCards.Add(deck.deck[0]);
                    deck.deck.RemoveAt(0);
                }
            }
        }

        public void DrawCards(Gamer gamer)
        {
            
        }

        public void PerformStep(Game game)
        {
            //Move counter of current gamer forvard
            Game.CurrentGamer += 1;
            if (Game.CurrentGamer > game.Gamers.Count - 1)
            {
                Game.CurrentGamer = 0;
            }
        }


    }
}
