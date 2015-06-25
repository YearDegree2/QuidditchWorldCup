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
using QuidditchWPF.Persistance;
using BusinessLayer;
using BusinessLayer.Interfaces;
using QuidditchWPF.ViewModel;

namespace QuidditchWPF.Windows
{
    /// <summary>
    /// Logique d'interaction pour WindowDisplayGestionMatchs.xaml
    /// </summary>
    public partial class WindowDisplayGestionMatchs : Window
    {
        public WindowDisplayGestionMatchs()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveDimensions.GetInstance().saveDimensionsWindow(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SaveDimensions.GetInstance().loadDimensionsWindow(this);

            CoupeManager manager = new CoupeManager();
            ICollection<IMatch> matchs = manager.GetMatchs();
            ICollection<ICoupe> coupes = manager.GetCoupes();
            ICollection<IEquipe> equipes = manager.GetEquipes();
            ICollection<IStade> stades = manager.GetStades();
            ICollection<IArbitre> arbitres = manager.GetArbitres();

            ViewModelMatchs vmm = new ViewModelMatchs(matchs, coupes, equipes, stades, arbitres);
            vmm.CloseNotified += CloseNotified;
            matchsWork.DataContext = vmm;
        }

        private void CloseNotified(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ViewModelMatchs vmm = null;

            vmm = (ViewModelMatchs)matchsWork.DataContext;
            CoupeManager manager = new CoupeManager();
            ICollection<IMatch> matchs = new List<IMatch>();
            foreach (ViewModelMatch m in vmm.Matchs)
            {
                matchs.Add(m.Match);
            }
            manager.UpdateMatchs(matchs);
            if (vmm != null) vmm.CloseNotified -= CloseNotified;
        }
    }
}
