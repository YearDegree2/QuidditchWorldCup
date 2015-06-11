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
using BusinessLayer.Interfaces;

namespace QuidditchWPF.Windows
{
    /// <summary>
    /// Logique d'interaction pour WindowDisplayNbPlacesRestantesMatch02012015.xaml
    /// </summary>
    public partial class WindowDisplayNbPlacesRestantesMatch02012015 : Window
    {
        public WindowDisplayNbPlacesRestantesMatch02012015()
        {
            InitializeComponent();
        }

        private void nbPlacesRestantes_Loaded(object sender, RoutedEventArgs e)
        {
            CoupeManager coupeManager = new CoupeManager();
            IEnumerable<IMatch> matchsOrd = coupeManager.GetMatchsByDateOrd();
            this.nbPlacesRestantes.Text = coupeManager.GetNbPlacesRestantes(matchsOrd.First()) + " places restantes";
        }
    }
}
