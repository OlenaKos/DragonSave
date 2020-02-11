using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace DragonSave
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        Game game;
        public Uri myUri;
        public static Person person;
        public MainWindow()
        {
            InitializeComponent();
        }

        //main buttons click
        private void startButton_Click(object sender, RoutedEventArgs e)
        {

            //start game
            int gamersAmount = (btnFour.IsChecked == true) ? 4 : (btnThree.IsChecked == true) ? 3 : 2;
            game = new Game(gamersAmount);

            //draw
            foreach (var gamer in game.Gamers)
            {
                DrawCards(gamer);
            }
            DrawDeck();
            DrawGamerInformation();
            DrawEndGame();
            DrawPossibleCombination(game.Gamers[Game.CurrentGamer]);
        }
        private void endButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            person = new Person();

            if (txtLogin.Text == "")
            {
                MessageBox.Show("Enter a login please");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Enter a password please");
            }
            else
            {
                person.login = txtLogin.Text;
                person.password = txtPassword.Text;
                Person.WritenFile(person);
                gridLoginPassword.Visibility = Visibility.Hidden;
                gridGame.Visibility = Visibility.Visible;
            }

        }

        //button clicks
        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            //throw one card
            game.UseThrowCardCombination(0, game.Gamers[Game.CurrentGamer]);
            game.PerformStep();

            DrawStep();
        }
        private void mmButton_Click(object sender, RoutedEventArgs e)
        {
            game.UseMotherMotherCombination();
            game.PerformStep();

            DrawStep();
        }
        private void nmfButton_Click(object sender, RoutedEventArgs e)
        {
            game.UseNestMotherFatherCombination();
            game.PerformStep();

            DrawStep();

        }
        private void ffButton_Click(object sender, RoutedEventArgs e)
        {
            game.UseFatherFatherCombination();
            game.PerformStep();

            DrawStep();
        }
        private void villainButton_Click(object sender, RoutedEventArgs e)
        {
            gridPickPlayer.Visibility = Visibility.Visible;
            btnGamer0.Visibility = Visibility.Hidden;
            btnGamer1.Visibility = Visibility.Hidden;
            btnGamer2.Visibility = Visibility.Hidden;
            btnGamer3.Visibility = Visibility.Hidden;

            //display possible victims
            for (int i = 0; i < game.Gamers.Count; i++)
            {
                if (i != Game.CurrentGamer)
                {
                    DisplayVictim(game.Gamers[i]);
                }
            }
        }
        private void btnVictimOK_Click(object sender, RoutedEventArgs e)
        {
            List<RadioButton> rbVictims = new List<RadioButton>() { btnGamer0, btnGamer1, btnGamer2, btnGamer3 };

            for (int i = 0; i < rbVictims.Count; i++)
            {
                if (rbVictims[i].IsChecked == true)
                {
                    game.Victim = i;
                    break;
                }
            }

            game.UseVillainCombination();
            game.PerformStep();

            //disable grid
            gridPickPlayer.Visibility = Visibility.Hidden;
            

            DrawStep();

            //show message about father-father combination implemented
            lbGameMessages.Content = "Your victim used a father combination.";
            lbGameMessages.Visibility = Visibility.Visible;
        }

        private void DisplayVictim(Gamer gamer)
        {
            switch (gamer.GamerID)
            {
                case 0:
                    {
                        if (gamer.GamerEggs.Count > 0)
                        {
                            btnGamer0.Visibility = Visibility.Visible;
                        }
                        else 
                        {
                            btnGamer0.Visibility = Visibility.Hidden;
                        }
                        break;
                    }
                case 1:
                    {
                        if (gamer.GamerEggs.Count > 0)
                        {
                            btnGamer1.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            btnGamer1.Visibility = Visibility.Hidden;
                        }
                        break;
                    }
                case 2:
                    {

                        if (gamer.GamerEggs.Count > 0)
                        {
                            btnGamer2.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            btnGamer2.Visibility = Visibility.Hidden;
                        }
                        break;

                    }
                case 3:
                    {
                        if (gamer.GamerEggs.Count > 0)
                        {
                            btnGamer3.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            btnGamer3.Visibility = Visibility.Hidden;
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        //extra button clicks
        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            RulesWindow s = new RulesWindow();
            if (s.ShowDialog() == true)
                s.Close();
        }
        private void Dev_Click(object sender, RoutedEventArgs e)
        {
            Developers s = new Developers();
            if (s.ShowDialog() == true)
                s.Close();
        }

        //drawing
        private void DrawCards(Gamer gamer)
        {
            switch (gamer.GamerID)
            {
                case 0:
                    {

                        myUri = new Uri(@game.Gamers[0].GamerCards[0].ImgSource, UriKind.RelativeOrAbsolute);
                        Card11.Source = new BitmapImage(myUri);
                        myUri = new Uri(@game.Gamers[0].GamerCards[1].ImgSource, UriKind.RelativeOrAbsolute);
                        Card12.Source = new BitmapImage(myUri);
                        myUri = new Uri(@game.Gamers[0].GamerCards[2].ImgSource, UriKind.RelativeOrAbsolute);
                        Card13.Source = new BitmapImage(myUri);
                        myUri = new Uri(@game.Gamers[0].GamerCards[3].ImgSource, UriKind.RelativeOrAbsolute);
                        Card14.Source = new BitmapImage(myUri);
                        break;
                    }
                case 1:
                    {
                        myUri = new Uri(@game.Gamers[1].GamerCards[0].ImgSource, UriKind.RelativeOrAbsolute);
                        Card21.Source = new BitmapImage(myUri);
                        myUri = new Uri(@game.Gamers[1].GamerCards[1].ImgSource, UriKind.RelativeOrAbsolute);
                        Card22.Source = new BitmapImage(myUri);
                        myUri = new Uri(@game.Gamers[1].GamerCards[2].ImgSource, UriKind.RelativeOrAbsolute);
                        Card23.Source = new BitmapImage(myUri);
                        myUri = new Uri(@game.Gamers[1].GamerCards[3].ImgSource, UriKind.RelativeOrAbsolute);
                        Card24.Source = new BitmapImage(myUri);
                        break;
                    }
                case 2:
                    {
                        myUri = new Uri(@game.Gamers[2].GamerCards[0].ImgSource, UriKind.RelativeOrAbsolute);
                        Card31.Source = new BitmapImage(myUri);
                        myUri = new Uri(@game.Gamers[2].GamerCards[1].ImgSource, UriKind.RelativeOrAbsolute);
                        Card32.Source = new BitmapImage(myUri);
                        myUri = new Uri(@game.Gamers[2].GamerCards[2].ImgSource, UriKind.RelativeOrAbsolute);
                        Card33.Source = new BitmapImage(myUri);
                        myUri = new Uri(@game.Gamers[2].GamerCards[3].ImgSource, UriKind.RelativeOrAbsolute);
                        Card34.Source = new BitmapImage(myUri);
                        break;

                    }
                case 3:
                    {
                        myUri = new Uri(@game.Gamers[3].GamerCards[0].ImgSource, UriKind.RelativeOrAbsolute);
                        Card41.Source = new BitmapImage(myUri);
                        myUri = new Uri(@game.Gamers[3].GamerCards[1].ImgSource, UriKind.RelativeOrAbsolute);
                        Card42.Source = new BitmapImage(myUri);
                        myUri = new Uri(@game.Gamers[3].GamerCards[2].ImgSource, UriKind.RelativeOrAbsolute);
                        Card43.Source = new BitmapImage(myUri);
                        myUri = new Uri(@game.Gamers[3].GamerCards[3].ImgSource, UriKind.RelativeOrAbsolute);
                        Card44.Source = new BitmapImage(myUri);
                        break;
                    }
                default:
                    break;
            }
        }
        private void DrawDeck()
        {
            DeckCards.Visibility = Visibility.Visible;
        }
        private void DrawMarkOnCards(Gamer gamer, double opacityValue)
        {
            switch (gamer.GamerID)
            {
                case 0:
                    {

                        Card11.Opacity = opacityValue;
                        Card12.Opacity = opacityValue;
                        Card13.Opacity = opacityValue;
                        Card14.Opacity = opacityValue;
                        break;
                    }
                case 1:
                    {
                        Card21.Opacity = opacityValue;
                        Card22.Opacity = opacityValue;
                        Card23.Opacity = opacityValue;
                        Card24.Opacity = opacityValue;
                        break;
                    }
                case 2:
                    {
                        Card31.Opacity = opacityValue;
                        Card32.Opacity = opacityValue;
                        Card33.Opacity = opacityValue;
                        Card34.Opacity = opacityValue;
                        break;

                    }
                case 3:
                    {
                        Card41.Opacity = opacityValue;
                        Card42.Opacity = opacityValue;
                        Card43.Opacity = opacityValue;
                        Card44.Opacity = opacityValue;
                        break;
                    }
                default:
                    break;
            }
        }
        private void DrawMarkOnEggDragonCards(Gamer gamer, double opacityValue)
        {
            switch (gamer.GamerID)
            {
                case 0:
                    {
                        D1.Opacity = opacityValue;
                        LD1.Opacity = opacityValue;
                        E1.Opacity = opacityValue;
                        ED1.Opacity = opacityValue;
                        break;
                    }
                case 1:
                    {
                        D2.Opacity = opacityValue;
                        LD2.Opacity = opacityValue;
                        E2.Opacity = opacityValue;
                        ED2.Opacity = opacityValue;
                        break;
                    }
                case 2:
                    {
                        D3.Opacity = opacityValue;
                        LD3.Opacity = opacityValue;
                        E3.Opacity = opacityValue;
                        ED3.Opacity = opacityValue;

                        break;

                    }
                case 3:
                    {
                        D4.Opacity = opacityValue;
                        LD4.Opacity = opacityValue;
                        E4.Opacity = opacityValue;
                        ED4.Opacity = opacityValue;
                        break;
                    }
                default:
                    break;
            }
        }
        private void DrawEndGame()
        {
            //Show EndGame
            startButton.Visibility = Visibility.Hidden;
            endButton.Visibility = Visibility.Visible;
        }
        private void DrawGamerInformation()
        {
            //Current gamer
            //Draw information about current gamer
            DrawCurrentGamerInfo();

            //Drawing possible gamer combinations
            DrawPossibleCombination(game.Gamers[Game.CurrentGamer]);

            //Common part
            //Draw Gamers cards
            foreach (var gamer in game.Gamers)
            {
                DrawCards(gamer);
            }

            //Draw Gamers eggs and dragons
            foreach (var gamer in game.Gamers)
            {
                DrawEggsDragonsCards(gamer);
            }

            //disable cards of all gamers except of current
            for (int i = 0; i < game.Gamers.Count; i++)
            {
                if (i == Game.CurrentGamer)
                {
                    DrawMarkOnCards(game.Gamers[Game.CurrentGamer], 1);//enabling current gamer cards
                }
                else
                {
                    DrawMarkOnCards(game.Gamers[i], 0.7); //disabling all other gamers
                }
            }

            //disable game message if presented
            lbGameMessages.Visibility = Visibility.Hidden;

        }
        private void DrawCurrentGamerInfo()
        {
            //Draw information about current gamer
            lbCurrentGamer.Visibility = Visibility.Visible;
            lbCurrentGamerAmount.Visibility = Visibility.Visible;
            lbCurrentGamerAmount.Content = $"{Game.CurrentGamer} {game.Gamers[Game.CurrentGamer].Name}";
            lbDesiredGamersAmt.Visibility = Visibility.Hidden;
            btnFour.Visibility = Visibility.Hidden;
            btnThree.Visibility = Visibility.Hidden;
            btnTwo.Visibility = Visibility.Hidden;
        }
        private void DrawEggsDragonsCards(Gamer gamer)
        {
            switch (gamer.GamerID)
            {
                case 0:
                    {
                        if (game.Gamers[0].GamerDragons.Count > 0)
                        {
                            D1.Visibility = Visibility.Visible;
                            LD1.Visibility = Visibility.Visible;
                            LD1.Content = game.Gamers[0].GamerDragons.Count;
                        }
                        else
                        {
                            D1.Visibility = Visibility.Hidden;
                            LD1.Visibility = Visibility.Hidden;
                        }
                        if (game.Gamers[0].GamerEggs.Count > 0)
                        {
                            E1.Visibility = Visibility.Visible;
                            ED1.Visibility = Visibility.Visible;
                            ED1.Content = game.Gamers[0].GamerEggs.Count;
                        }
                        else
                        {
                            E1.Visibility = Visibility.Hidden;
                            ED1.Visibility = Visibility.Hidden;
                        }


                        break;
                    }
                case 1:
                    {
                        if (game.Gamers[1].GamerDragons.Count > 0)
                        {
                            D2.Visibility = Visibility.Visible;
                            LD2.Visibility = Visibility.Visible;
                            LD2.Content = game.Gamers[1].GamerDragons.Count;
                        }
                        else
                        {
                            D2.Visibility = Visibility.Hidden;
                            LD2.Visibility = Visibility.Hidden;
                        }

                        if (game.Gamers[1].GamerEggs.Count > 0)
                        {
                            E2.Visibility = Visibility.Visible;
                            ED2.Visibility = Visibility.Visible;
                            ED2.Content = game.Gamers[1].GamerEggs.Count;
                        }
                        else
                        {
                            E2.Visibility = Visibility.Hidden;
                            ED2.Visibility = Visibility.Hidden;
                        }
                        break;
                    }
                case 2:
                    {
                        if (game.Gamers[2].GamerDragons.Count > 0)
                        {
                            D3.Visibility = Visibility.Visible;
                            LD3.Visibility = Visibility.Visible;
                            LD3.Content = game.Gamers[2].GamerDragons.Count;
                        }
                        else
                        {
                            D3.Visibility = Visibility.Hidden;
                            LD3.Visibility = Visibility.Hidden;
                        }

                        if (game.Gamers[2].GamerEggs.Count > 0)
                        {
                            E3.Visibility = Visibility.Visible;
                            ED3.Visibility = Visibility.Visible;
                            ED3.Content = game.Gamers[2].GamerEggs.Count;
                        }
                        else
                        {
                            E3.Visibility = Visibility.Hidden;
                            ED3.Visibility = Visibility.Hidden;
                        }

                        break;

                    }
                case 3:
                    {
                        if (game.Gamers[3].GamerDragons.Count > 0)
                        {
                            D4.Visibility = Visibility.Visible;
                            LD4.Visibility = Visibility.Visible;
                            LD4.Content = game.Gamers[3].GamerDragons.Count;
                        }
                        else
                        {
                            D4.Visibility = Visibility.Hidden;
                            LD4.Visibility = Visibility.Hidden;
                        }

                        if (game.Gamers[3].GamerEggs.Count > 0)
                        {
                            E4.Visibility = Visibility.Visible;
                            ED4.Visibility = Visibility.Visible;
                            ED4.Content = game.Gamers[3].GamerEggs.Count;
                        }
                        else
                        {
                            E4.Visibility = Visibility.Hidden;
                            ED4.Visibility = Visibility.Hidden;
                        }
                        break;
                    }
                default:
                    break;
            }
        }
        private void DrawPossibleCombination(Gamer gamer)
        {
            changeButton.Visibility = Visibility.Visible;
            ffButton.Visibility = Visibility.Hidden;
            nmfButton.Visibility = Visibility.Hidden;
            mmButton.Visibility = Visibility.Hidden;
            villainButton.Visibility = Visibility.Hidden;
            //if (gamer.GamerPossibleComb.Contains(Combinations.FatherFather) == true)
            //{
            //    ffButton.Visibility = Visibility.Visible;
            //}
            if (gamer.GamerPossibleComb.Contains(Combinations.MotherFatherNest) == true)
            {
                nmfButton.Visibility = Visibility.Visible;
            }
            if (gamer.GamerPossibleComb.Contains(Combinations.MotherMother) == true)
            {
                mmButton.Visibility = Visibility.Visible;
            }
            if (gamer.GamerPossibleComb.Contains(Combinations.Villain) == true)
            {
                villainButton.Visibility = Visibility.Visible;
            }

        }
        private void DrawWinner()
        {
            //disable cards of all gamers including of current
            for (int i = 0; i < game.Gamers.Count; i++)
            {
                DrawMarkOnCards(game.Gamers[i], 0.7);
            }

            //Disable egg and dragon cards for all gamers
            for (int i = 0; i < game.Gamers.Count; i++)
            {
                DrawMarkOnEggDragonCards(game.Gamers[i], 0.7);
            }

            //disable possible combinations
            changeButton.Visibility = Visibility.Hidden;
            ffButton.Visibility = Visibility.Hidden;
            nmfButton.Visibility = Visibility.Hidden;
            mmButton.Visibility = Visibility.Hidden;
            villainButton.Visibility = Visibility.Hidden;

            //enter winning message
            lbGameMessages.Content = $"Congratulations! We have a winner: ";
            lbGameMessages.Visibility = Visibility.Visible;
            lbGameWinner.Content = $"{game.Gamers[Game.Winner].Name}";
            lbGameWinner.Visibility = Visibility.Visible;
        }
        private void DrawStep()
        {
            if (Game.isGameRunning == true)
            {
                DrawGamerInformation();
            }
            else
            {
                DrawWinner();
            }
        }


    }

}
