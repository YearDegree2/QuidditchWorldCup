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
using BusinessLayer;

namespace QuidditchWPF.Windows
{
    /// <summary>
    /// Logique d'interaction pour WindowDisplayMatchsByDateOrd.xaml
    /// </summary>
    public partial class WindowDisplayMatchsByDateOrd : Window
    {
        public WindowDisplayMatchsByDateOrd()
        {
            InitializeComponent();
        }

        private void listMatchs_Loaded(object sender, RoutedEventArgs e)
        {
            CoupeManager coupeManager = new CoupeManager();
            this.listMatchs.ItemsSource = coupeManager.GetMatchsByDateOrd();
        }
    }
}
