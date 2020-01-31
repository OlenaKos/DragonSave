using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSave
{
    interface IActions
    {
        void UseThrowCardCombination(Game game, Gamer gamer, int CardID); //corrsponds changeButton
        void UseMotherMotherCombination(Game game, Gamer gamer); //corresponds mmButton
        void UseNestMotherFatherCombination(Game game, Gamer gamer); //corresponds to mfnButton
        void UseFatherFatherCombination(Game game, Gamer gamer); //corresponds
        void UseVillainCombination(Game game, Gamer gamer); //corresponds villainButton
    }
}
