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
            //Card31.Source = game.Gamers[0].GamerCards[0].ImgSource;
            //ImageSource =
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
