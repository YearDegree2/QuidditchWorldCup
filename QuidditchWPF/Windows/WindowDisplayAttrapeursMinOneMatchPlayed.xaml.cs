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
    /// Logique d'interaction pour WindowDisplayAttrapeursMinOneMatchPlayed.xaml
    /// </summary>
    public partial class WindowDisplayAttrapeursMinOneMatchPlayed : Window
    {
        public WindowDisplayAttrapeursMinOneMatchPlayed()
        {
            InitializeComponent();
        }

        private void listAttrapeurs_Loaded(object sender, RoutedEventArgs e)
        {
            CoupeManager coupeManager = new CoupeManager();
            this.listAttrapeurs.ItemsSource = coupeManager.GetAttrapeursMinOneMatchPlayed();
        }
    }
}
