using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSave
{
    class GamerController : IActions
    {
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

        private int DefineRequiredCardID(Card card, Gamer gamer)
        {
            int RequiredCardID = -1;
            for (int i = 0; i < gamer.GamerCards.Count; i++)
            {
                if (gamer.GamerCards[i].GetType() == typeof(Card))
                {
                    RequiredCardID = i;
                    break;
                }
            }
            return RequiredCardID;
        }

        public void UseThrowCardCombination(Game game, Gamer gamer, int CardID) //corresponds changeButton
        {
            game.MainDeck.deck.Add(gamer.GamerCards[CardID]);
            gamer.GamerCards.RemoveAt(CardID);
            gamer.GamerCards.Add(game.MainDeck.deck[0]);
            game.MainDeck.deck.RemoveAt(0);
        }

        public void UseMotherMotherCombination(Game game, Gamer gamer)  //corresponds mmButton
        {
            Mother mother = new Mother();
            int IDMother = DefineRequiredCardID(mother, gamer);
            UseThrowCardCombination(game, gamer, IDMother);
            IDMother = DefineRequiredCardID(mother, gamer);
            UseThrowCardCombination(game, gamer, IDMother);
        }

        public void UseNestMotherFatherCombination(Game game, Gamer gamer) //corresponds mfnButton
        {
            Mother mother = new Mother();
            Father father = new Father();
            Nest nest = new Nest();
            int IDMother = DefineRequiredCardID(mother, gamer);
            UseThrowCardCombination(game, gamer, IDMother);
            int IDFather = DefineRequiredCardID(mother, gamer);
            UseThrowCardCombination(game, gamer, IDMother);
            int IDNest = DefineRequiredCardID(mother, gamer);
            UseThrowCardCombination(game, gamer, IDMother);
        }

        public void UseFatherFatherCombination(Game game, Gamer gamer) //corresponds ffButton
        {
         
            Father father = new Father();
            Nest nest = new Nest();

        }

        public void UseVillainCombination(Game game, Gamer gamer) // corresponds villainButton
        {
            throw new NotImplementedException();
        }

        public bool IsMotherMotherCombinationAllowed(Gamer gamer)
        {
            bool res = false;
            int motherCounter = 0;
            foreach (var card in gamer.GamerCards)
            {
                if (card is Mother)
                {
                    motherCounter++; 
                }
            }

            if (motherCounter >= 2)
            {
                res = true;
            }

            return res;
        }
    }
}
