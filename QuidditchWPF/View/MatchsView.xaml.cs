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
using BusinessLayer;
using BusinessLayer.Interfaces;
using QuidditchWPF.ViewModel;

namespace QuidditchWPF.View
{
    /// <summary>
    /// Logique d'interaction pour MatchsView.xaml
    /// </summary>
    public partial class MatchsView : UserControl
    {
        public MatchsView()
        {
            InitializeComponent();
        }

        private void lvMatchs_Loaded(object sender, RoutedEventArgs e)
        {
            CoupeManager manager = new CoupeManager();
            ViewModelMatchs matchs = new ViewModelMatchs(manager.GetMatchs(), manager.GetCoupes(), manager.GetEquipes(), manager.GetStades(), manager.GetArbitres());
            this.DataContext = matchs;
        }
    }
}
