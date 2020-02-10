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
        public SelectGamerWindow()
        {
            InitializeComponent();
        }

        private void btnOKGamer_click(object sender, RoutedEventArgs e)
        {
            int iGamer = (btnGamer2.IsChecked == true) ? 1 : (btnGamer3.IsChecked == true)? 2 : 3;
            
        }
    }
}
