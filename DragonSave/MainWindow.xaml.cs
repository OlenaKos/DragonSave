using System;
using System.Collections.Generic;
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
        public MainWindow()
        {

            InitializeComponent();
            controller = new Controller();
            mmButton.Content = "Мама+Мама=\nМалыш (при наличии яйца)";
            nmfButton.Content = "Мама+Папа+Гнездо=\nЯйцо";
            ffButton.Content = "Папа+Папа=\nЗлодюжка (при нападении)";
            villainButton.Content = "Злодюжка=\nСворовать яйцо";

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

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            int gamersAmount = (btnFour.IsChecked == true) ? 4 : (btnThree.IsChecked == true) ? 3 : 2;
            game = controller.StartGame(gamersAmount);


            foreach (var gamer in game.Gamers)
            {
                DrawCards(gamer);
            }


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

    }

}
