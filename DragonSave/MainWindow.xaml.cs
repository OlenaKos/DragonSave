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
        public static Uri myUri;
        Person person = new Person();
        public MainWindow()
        {    
            InitializeComponent();
            


        }

        //main buttons click
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            //fill content eggs and dragons             
            LD1.Content = 0;
            ED1.Content = 0;
            LD2.Content = 0;
            ED2.Content = 0;
            LD3.Content = 0;
            ED3.Content = 0;
            LD4.Content = 0;
            ED4.Content = 0;



            int gamersAmount = (btnFour.IsChecked == true) ? 4 : (btnThree.IsChecked == true) ? 3 : 2;
            game = new Game(gamersAmount);

            //draw
            foreach (var gamer in game.Gamers)
            {
                DrawCards(gamer);
            }

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

            if (txtLogin.Text == "" || txtPassword.Text == "")
            {
                btnRegister.IsEnabled = false;
                MessageBox.Show("Written all fields");
                txtLogin.Text += "";
                txtPassword.Text += "";
            }
            else if (txtLogin.Text != "" || txtPassword.Text != "")
            {
                btnRegister.IsEnabled = true;
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
            game.UseThrowCardCombination(0);
            DrawGamerInformation();

            game.PerformStep();
            DrawGamerInformation();
        }
        private void mmButton_Click(object sender, RoutedEventArgs e)
        {
            game.UseMotherMotherCombination();
            DrawGamerInformation();
            
            game.PerformStep();
            DrawGamerInformation();

        }
        private void nmfButton_Click(object sender, RoutedEventArgs e)
        {
            game.UseNestMotherFatherCombination();
            DrawGamerInformation();

            game.PerformStep();
            DrawGamerInformation();
        }
        private void ffButton_Click(object sender, RoutedEventArgs e)
        {
            game.UseFatherFatherCombination();
            DrawGamerInformation();

            game.PerformStep();
            DrawGamerInformation();
        }
        private void villainButton_Click(object sender, RoutedEventArgs e)
        {
            game.UseVillainCombination();
            DrawGamerInformation();

            game.PerformStep();
            DrawGamerInformation();
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
        private void DrawEndGame()
        {
            //Show EndGame
            startButton.Visibility = Visibility.Hidden;
            endButton.Visibility = Visibility.Visible;
        }
        private void DrawGamerInformation()
        {
            //Draw information about current gamer
            DrawCurrentGamerInfo();

            //Drawing possible gamer combinations
            DrawPossibleCombination(game.Gamers[Game.CurrentGamer]);

            //Draw Gamer cards
            DrawCards(game.Gamers[Game.CurrentGamer]);

            //Draw Gamer eggs and dragons
            DrawEggsDragonsCards(game.Gamers[Game.CurrentGamer]);
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

                        //myUri = new Uri(@game.Gamers[0].GamerCards[0].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card11.Source = new BitmapImage(myUri);
                        //myUri = new Uri(@game.Gamers[0].GamerCards[1].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card12.Source = new BitmapImage(myUri);
                        //myUri = new Uri(@game.Gamers[0].GamerCards[2].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card13.Source = new BitmapImage(myUri);
                        //myUri = new Uri(@game.Gamers[0].GamerCards[3].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card14.Source = new BitmapImage(myUri);
                        LD1.Content = game.Gamers[0].GamerDragons.Count;
                        ED1.Content = game.Gamers[0].GamerEggs.Count;

                        break;
                    }
                case 1:
                    {
                        //myUri = new Uri(@game.Gamers[1].GamerCards[0].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card21.Source = new BitmapImage(myUri);
                        //myUri = new Uri(@game.Gamers[1].GamerCards[1].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card22.Source = new BitmapImage(myUri);
                        //myUri = new Uri(@game.Gamers[1].GamerCards[2].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card23.Source = new BitmapImage(myUri);
                        //myUri = new Uri(@game.Gamers[1].GamerCards[3].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card24.Source = new BitmapImage(myUri);
                        LD2.Content = game.Gamers[1].GamerDragons.Count;
                        ED2.Content = game.Gamers[1].GamerEggs.Count;
                        break;
                    }
                case 2:
                    {
                        //myUri = new Uri(@game.Gamers[2].GamerCards[0].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card31.Source = new BitmapImage(myUri);
                        //myUri = new Uri(@game.Gamers[2].GamerCards[1].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card32.Source = new BitmapImage(myUri);
                        //myUri = new Uri(@game.Gamers[2].GamerCards[2].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card33.Source = new BitmapImage(myUri);
                        //myUri = new Uri(@game.Gamers[2].GamerCards[3].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card34.Source = new BitmapImage(myUri);
                        LD3.Content = game.Gamers[2].GamerDragons.Count;
                        ED3.Content = game.Gamers[2].GamerEggs.Count;
                        break;

                    }
                case 3:
                    {
                        //myUri = new Uri(@game.Gamers[3].GamerCards[0].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card41.Source = new BitmapImage(myUri);
                        //myUri = new Uri(@game.Gamers[3].GamerCards[1].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card42.Source = new BitmapImage(myUri);
                        //myUri = new Uri(@game.Gamers[3].GamerCards[2].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card43.Source = new BitmapImage(myUri);
                        //myUri = new Uri(@game.Gamers[3].GamerCards[3].ImgSource, UriKind.RelativeOrAbsolute);
                        //Card44.Source = new BitmapImage(myUri);
                        LD4.Content = game.Gamers[3].GamerDragons.Count;
                        ED4.Content = game.Gamers[3].GamerEggs.Count;
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
            if (gamer.GamerPossibleComb.Contains(Combinations.FatherFather) == true)
            {
                ffButton.Visibility = Visibility.Visible;
            }
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

        //alerts
        public void MakeAlertImpossibleCombination()
        {
            ImpossibleCombinationAlert alert = new ImpossibleCombinationAlert();
            if (alert.ShowDialog() == true)
                alert.Close();
        }
    }

}
