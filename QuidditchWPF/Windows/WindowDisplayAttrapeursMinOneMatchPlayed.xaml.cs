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
using QuidditchWPF.Persistance;

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

        private void Window_Closed(object sender, EventArgs e)
        {
            SaveDimensions.GetInstance().saveDimensionsWindow(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SaveDimensions.GetInstance().loadDimensionsWindow(this);
        }
    }
}
