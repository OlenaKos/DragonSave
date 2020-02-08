﻿using System;
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
        public static int Winner { set; get; }
        public List<Gamer> Gamers { get; set; }
        public Deck MainDeck { set; get; }

        public delegate bool PossibleCombDelegate(Gamer gamer);

        public Game(int GamersCount)
        {
            MainDeck = new Deck();
            CurrentGamer = 0;
            Gamers = new List<Gamer> { };
            Gamers.Add(new RealGamer());
            for (int i = 1; i < GamersCount; i++)
            {
                Gamers.Add(new Bot());
            }
            GiveCardsToGamers(MainDeck);
            UpdatePossibleCombinations(Gamers[0]);       
        }

        public void GiveCardsToGamers(Deck deck)
        {
            int AmountCardsToGive = 4;
            foreach (var gamer in Gamers)
            {
                for (int i = 0; i < AmountCardsToGive; i++)
                {
                    gamer.GamerCards.Add(deck.deck[0]);
                    deck.deck.RemoveAt(0);
                }
            }
        }

        public void PerformStep()
        {
            //winner exist checking
            isGameRunning = isWinnerExist();
            if (isGameRunning != true)
            {
                //Move counter of current gamer forvard
                CurrentGamer += 1;
                if (CurrentGamer > Gamers.Count - 1)
                {
                    CurrentGamer = 0;
                }

                //Generate list of possible combinations
                UpdatePossibleCombinations(Gamers[CurrentGamer]);
            }
            else
            {
                // Hooray we have a winner

            }
            

        }

        private bool isWinnerExist()
        {
            bool res = false;
            foreach (var gamer in Gamers)
            {
                if (gamer.GamerDragons.Count == 3)
                {
                    res = true;
                }
            }

            return res;
        }

        public void UseThrowCardCombination(int CardID) //corresponds changeButton
        {
            MainDeck.deck.Add(Gamers[CurrentGamer].GamerCards[CardID]);
            Gamers[CurrentGamer].GamerCards.RemoveAt(CardID);
            Gamers[CurrentGamer].GamerCards.Add(MainDeck.deck[0]);
            MainDeck.deck.RemoveAt(0);
        }

        public void UseMotherMotherCombination()  //corresponds mmButton
        {
            Mother mother = new Mother();
            int IDMother = Gamers[CurrentGamer].GamerCards.IndexOf(mother);
            UseThrowCardCombination(IDMother);
            IDMother = Gamers[CurrentGamer].GamerCards.IndexOf(mother);
            UseThrowCardCombination(IDMother);
        }

        public void UseNestMotherFatherCombination() //corresponds mfnButton
        {

            //throw cards
            int IDMother = DefineCardIDByType("DragonSave.Mother");
            UseThrowCardCombination(IDMother);
            int IDFather = DefineCardIDByType("DragonSave.Father");
            UseThrowCardCombination(IDFather);
            int IDNest = DefineCardIDByType("DragonSave.Nest");
            UseThrowCardCombination(IDNest);

            //add egg
            Gamers[CurrentGamer].GamerEggs.Add(new Egg());
        }

        private int DefineCardIDByType(string type)
        {
            int res = -1;
            for (int i = 0; i < Gamers[CurrentGamer].GamerCards.Count; i++)
            {
                if (Gamers[CurrentGamer].GamerCards[i].GetType().ToString() == type)
                {
                    res = i;
                    break;
                }
            }
            return res;
        }

        public void UseFatherFatherCombination() //corresponds ffButton
        {
            Father father = new Father();
            int IDFather = Gamers[Game.CurrentGamer].GamerCards.IndexOf(father);
            UseThrowCardCombination(IDFather);
            IDFather = Gamers[Game.CurrentGamer].GamerCards.IndexOf(father);
            UseThrowCardCombination(IDFather);
        }

        public void UseVillainCombination() // corresponds villainButton
        {
            throw new NotImplementedException();
        }

        public void UpdatePossibleCombinations(Gamer gamer)
        {
            List<Combinations> allComb = new List<Combinations>() { Combinations.FatherFather,
                Combinations.MotherFatherNest, Combinations.MotherMother,
                Combinations.Villain };

            foreach (var comb in allComb)
            {
                if (IsPossibleCombination(gamer, comb) == true)
                {
                    gamer.GamerPossibleComb.Add(comb);
                }
            }

        }

        private bool IsPossibleCombination(Gamer gamer, Combinations comb)
        {
            PossibleCombDelegate IsPossibleComb = IsFatherFatherCombinationAllowed;

            switch (comb)
            {
                case Combinations.FatherFather:
                    {
                        IsPossibleComb = IsFatherFatherCombinationAllowed;
                        break;
                    }

                case Combinations.MotherFatherNest:
                    {
                        IsPossibleComb = IsMotherFatherNestCombinationAllowed;
                        break;
                    }

                case Combinations.MotherMother:
                    {
                        IsPossibleComb = IsMotherMotherCombinationAllowed;
                        break;
                    }
                case Combinations.Villain:
                    {
                        IsPossibleComb = IsVillainCombinationAllowed;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return IsPossibleComb(gamer);
        }

        public bool IsMotherMotherCombinationAllowed(Gamer gamer)
        {
            bool res = false;
            int motherCounter = 0;

            if (gamer.GamerEggs.Count > 0) //Check if gamer has eggs
            {
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
            }

            return res;
        }

        public bool IsFatherFatherCombinationAllowed(Gamer gamer)
        {
            bool res = false;
            int fatherCounter = 0;
            foreach (var card in gamer.GamerCards)
            {
                if (card is Father)
                {
                    fatherCounter++;
                }
            }

            if (fatherCounter >= 2)
            {
                res = true;
            }

            return res;
        }

        public bool IsMotherFatherNestCombinationAllowed(Gamer gamer)
        {
            bool res = false;
            int motherCounter = 0;
            int fatherCounter = 0;
            int nestCounter = 0;
            foreach (var card in gamer.GamerCards)
            {
                if (card is Father)
                {
                    fatherCounter++;
                }
                if (card is Mother)
                {
                    motherCounter++;
                }
                if (card is Nest)
                {
                    nestCounter++;
                }
            }

            if ((fatherCounter >= 1) && (motherCounter >= 1) && (nestCounter >= 1))
            {
                res = true;
            }

            return res;
        }

        public bool IsVillainCombinationAllowed(Gamer gamer)
        {
            bool res = false;
            int villainCounter = 0;
            bool isOtherGamerHasEggs = false;

            // check is anyone has eggs
            for (int i = 0; i < Gamers.Count; i++)
            {
                if (i != CurrentGamer)
                {
                    if (Gamers[i].GamerEggs.Count > 0)
                    {
                        isOtherGamerHasEggs = true;
                        break;
                    }
                }
            }

            if (isOtherGamerHasEggs)
            {
                //check if villain card presented
                foreach (var card in gamer.GamerCards)
                {
                    if (card is Villain)
                    {
                        villainCounter++;
                    }
                }

                if (villainCounter >= 1)
                {
                    res = true;
                }
            }
            

            return res;
        }
    }
}
