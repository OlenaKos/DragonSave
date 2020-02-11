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
using System.Windows.Shapes;

namespace DragonSave
{
    /// <summary>
    /// Логика взаимодействия для SelectGamer.xaml
    /// </summary>
    public partial class SelectGamerWindow : Window
    {
        public static int iGamer;
        public SelectGamerWindow()
        {
            InitializeComponent();
        }        
        
        private void btnOKGamer_click(object sender, RoutedEventArgs e)
        {
            if (btnGamer2.IsChecked == true || btnGamer3.IsChecked == true || btnGamer4.IsChecked == true)
            {
                iGamer = (btnGamer2.IsChecked == true) ? 1 : (btnGamer3.IsChecked == true) ? 2 : 3;
                this.Close();
            }
            else
                MessageBox.Show("Select player");            
        }

        public static int Select()
        {
            return iGamer; 
        }
    }
}
