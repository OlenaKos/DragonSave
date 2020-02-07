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
        Controller controller;
        Game game;
        public static Uri myUri;
        
        Person person = new Person();
        public MainWindow()
        {    
            InitializeComponent();
            

            LD1.Content = 0;
            ED1.Content = 0;          
            LD2.Content = 0;
            ED2.Content = 0;
            LD3.Content = 0;
            ED3.Content = 0;
            LD4.Content = 0;
            ED4.Content = 0;
        }

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

        public void MakeAlertImpossibleCombination()
        {
            ImpossibleCombinationAlert alert = new ImpossibleCombinationAlert();
            if (alert.ShowDialog() == true)
                alert.Close();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            controller = new Controller();
            
            int gamersAmount = (btnFour.IsChecked == true) ? 4 : (btnThree.IsChecked == true) ? 3 : 2;
            game = controller.StartGame(gamersAmount);

            foreach (var gamer in game.Gamers)
            {
                DrawCards(gamer);
            }

            ShowActionCards();
            DisplayPossibleCombination(game.Gamers[Game.CurrentGamer]);
        }
        private void endButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ShowActionCards()
        {
            //Show action cards
            mmButton.Visibility =  Visibility.Visible;
            nmfButton.Visibility = Visibility.Visible;
            ffButton.Visibility = Visibility.Visible;
            villainButton.Visibility = Visibility.Visible;

            //Show information about current gamer
            lbCurrentGamer.Visibility = Visibility.Visible;
            lbCurrentGamerAmount.Visibility = Visibility.Visible;
            lbCurrentGamerAmount.Content = Game.CurrentGamer;
            lbDesiredGamersAmt.Visibility = Visibility.Hidden;
            btnFour.Visibility = Visibility.Hidden;
            btnThree.Visibility = Visibility.Hidden;
            btnTwo.Visibility = Visibility.Hidden;

            //Show EndGame
            startButton.Visibility = Visibility.Hidden;
            endButton.Visibility = Visibility.Visible;
        }

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

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            controller.gamerController.UseThrowCardCombination(game, game.Gamers[0], 2);
        }
        private void mmButton_Click(object sender, RoutedEventArgs e)
        {
            controller.gamerController.UseMotherMotherCombination(game, game.Gamers[0]);
            controller.gameController.PerformStep(game);

            DisplayPossibleCombination(game.Gamers[Game.CurrentGamer]);
            
        }

        private void DisplayPossibleCombination(Gamer gamer)
        {
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

        private void nmfButton_Click(object sender, RoutedEventArgs e)
        {
            controller.gamerController.UseNestMotherFatherCombination(game, game.Gamers[0]);
        }
        private void ffButton_Click(object sender, RoutedEventArgs e)
        {
            controller.gamerController.UseFatherFatherCombination(game, game.Gamers[0]);
        }
        private void villainButton_Click(object sender, RoutedEventArgs e)
        {
            controller.gamerController.UseVillainCombination(game, game.Gamers[0]);
        }        

        private void btnRegister_Click_1(object sender, RoutedEventArgs e)
        {
            

            if (txtLogin.Text == "" || txtPassword.Text == "")
            {
                btnRegister.IsEnabled = false;
                MessageBox.Show("Written all fields");
                txtLogin.Text += "";
                txtPassword.Text += "";  
            }
            else if(txtLogin.Text != "" || txtPassword.Text != "")
            {                
                btnRegister.IsEnabled = true;
                person.login = txtLogin.Text;
                person.password = txtPassword.Text;
                switch (PasswordStrengthCheker.GetPasswordStrength(person.password))
                {
                    case 1:
                    case 2:
                    case 3:
                        MessageBox.Show("Is not good password");
                        break;
                    case 4:
                        MessageBox.Show("Is good password");
                        break;
                    case 5:
                        MessageBox.Show("Is very good password");
                        break;
                }

                Person.WritenFile(person);
                gridLoginPassword.Visibility = Visibility.Hidden;
                gridGame.Visibility = Visibility.Visible;
            }
            
        }
    }

}
