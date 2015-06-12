using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using BusinessLayer.Interfaces;
using BusinessLayer.Classes;

namespace QuidditchWPF.ViewModel
{
    class ViewModelMatchs : ViewModelBase
    {
        // Event destiné à réclamer la fermeture du conteneur;
        public event EventHandler<EventArgs> CloseNotified;
        protected void OnCloseNotified(EventArgs e)
        {
            this.CloseNotified(this, e);
        }

        // Model encapsulé dans le ViewModel
        private ObservableCollection<ViewModelMatch> _matchs;

        private ICollection<ICoupe> _coupes;
        private ICollection<IEquipe> _equipes;
        private ICollection<IStade> _stades;
        private ICollection<IArbitre> _arbitres;
        private ViewModelMatch _selectedItem;

        public ObservableCollection<ViewModelMatch> Matchs
        {
            get { return _matchs; }
            private set
            {
                _matchs = value;
                OnPropertyChanged("Matchs");
            }
        }

        public ICollection<ICoupe> Coupes
        {
            get { return _coupes; }
            set { _coupes = value; }
        }

        public ICollection<IEquipe> Equipes
        {
            get { return _equipes; }
            set { _equipes = value; }
        }

        public ICollection<IStade> Stades
        {
            get { return _stades; }
            set { _stades = value; }
        }

        public ICollection<IArbitre> Arbitres
        {
            get { return _arbitres; }
            set { _arbitres = value; }
        }

        public ViewModelMatch SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public ViewModelMatchs(ICollection<IMatch> matchModel, ICollection<ICoupe> coupes, ICollection<IEquipe> equipes, ICollection<IStade> stades, ICollection<IArbitre> arbitres)
        {
            Coupes = coupes;
            Equipes = equipes;
            Stades = stades;
            Arbitres = arbitres;
            Matchs = new ObservableCollection<ViewModelMatch>();
            foreach (IMatch m in matchModel)
            {
                Matchs.Add(new ViewModelMatch(m, coupes, equipes, stades, arbitres));
            }
        }

        #region "Commandes du formulaire"

        // Commande Add
        private RelayCommand _addCommand;
        public System.Windows.Input.ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(
                        () => this.Add(),
                        () => this.CanAdd()
                        );
                }
                return _addCommand;
            }
        }

        private bool CanAdd()
        {
            return true;
        }

        private void Add()
        {
            IMatch m = new Match();
            this.SelectedItem = new ViewModelMatch(m, Coupes, Equipes, Stades, Arbitres);

            Matchs.Add(this.SelectedItem);
        }

        // Commande Remove
        private RelayCommand _removeCommand;
        public System.Windows.Input.ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new RelayCommand(
                        () => this.Remove(),
                        () => this.CanRemove()
                        );
                }
                return _removeCommand;
            }
        }

        private bool CanRemove()
        {
            return (this.SelectedItem != null);
        }

        private void Remove()
        {
            if (this.SelectedItem != null) Matchs.Remove(this.SelectedItem);
        }

        #endregion
    }
}
