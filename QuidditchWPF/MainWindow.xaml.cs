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
using QuidditchWPF.Windows;
using QuidditchWPF.Persistance;

namespace QuidditchWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClickGetMatchsByDateOrd(object sender, RoutedEventArgs e)
        {
            WindowDisplayMatchsByDateOrd window = new WindowDisplayMatchsByDateOrd();
            window.ShowDialog();
        }

        private void ButtonClickGetStadesMinOneMatch(object sender, RoutedEventArgs e)
        {
            WindowDisplayStadesMinOneMatch window = new WindowDisplayStadesMinOneMatch();
            window.ShowDialog();
        }

        private void ButtonClickGetAttrapeursMinOneMatchPlayed(object sender, RoutedEventArgs e)
        {
            WindowDisplayAttrapeursMinOneMatchPlayed window = new WindowDisplayAttrapeursMinOneMatchPlayed();
            window.ShowDialog();
        }

        private void ButtonClickGetGardiensMoins17Ans(object sender, RoutedEventArgs e)
        {
            WindowDisplayGardiensMoins17Ans window = new WindowDisplayGardiensMoins17Ans();
            window.ShowDialog();
        }

        private void ButtonClickGetNbPlacesRestantesMatch02012015(object sender, RoutedEventArgs e)
        {
            WindowDisplayNbPlacesRestantesMatch02012015 window = new WindowDisplayNbPlacesRestantesMatch02012015();
            window.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveDimensions.GetInstance().saveDimensionsWindow(this);
            SaveDimensions.GetInstance().SaveFenetresProperties();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SaveDimensions.GetInstance().LoadFenetresProperties();
            SaveDimensions.GetInstance().loadDimensionsWindow(this);
        }

        private void ButtonClickGestionEquipe(object sender, RoutedEventArgs e)
        {
            WindowDisplayGestionMatchs window = new WindowDisplayGestionMatchs();
            window.ShowDialog();
        }
    }
}
