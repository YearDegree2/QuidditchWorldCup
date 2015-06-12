using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;

namespace QuidditchWPF.ViewModel
{
    class ViewModelMatch : ViewModelBase
    {
        // Model encapsulé dans le ViewModel
        private IMatch _match;
        private ICollection<ICoupe> _coupes;
        private ICollection<IEquipe> _equipes;
        private ICollection<IStade> _stades;
        private ICollection<IArbitre> _arbitres;

        public IMatch Match
        {
            get { return _match; }
            private set { _match = value; }
        }

        public ViewModelMatch(IMatch matchModel, ICollection<ICoupe> coupes, ICollection<IEquipe> equipes, ICollection<IStade> stades, ICollection<IArbitre> arbitres)
        {
            Match = matchModel;
            Coupes = coupes;
            Equipes = equipes;
            Stades = stades;
            Arbitres = arbitres;
        }

        #region "Propriétés accessibles, mappables par la View"

        public ICoupe Coupe
        {
            get { return Match.Coupe; }
            set
            {
                if (value == Match.Coupe) return;
                Match.Coupe = value;
                base.OnPropertyChanged("Coupe");
            }
        }

        public ICollection<ICoupe> Coupes
        {
            get { return _coupes; }
            set
            {
                if (value == _coupes) return;
                _coupes = value;
                base.OnPropertyChanged("Coupes");
            }
        }

        public DateTime Date
        {
            get { return Match.Date; }
            set
            {
                if (value == Match.Date) return;
                Match.Date = value;
                base.OnPropertyChanged("Date");
                base.OnPropertyChanged("DateFormat");
            }
        }

        public string DateFormat
        {
            get { return Date.ToShortDateString(); }
        }

        public ICollection<IEquipe> Equipes
        {
            get { return _equipes; }
            set
            {
                if (value == _equipes) return;
                _equipes = value;
                base.OnPropertyChanged("Equipes");
            }
        }

        public IEquipe EquipeDomicile
        {
            get { return Match.EquipeDomicile; }
            set
            {
                if (value == Match.EquipeDomicile) return;
                Match.EquipeDomicile = value;
                base.OnPropertyChanged("EquipeDomicile");
                base.OnPropertyChanged("EquipeDomicileNom");
            }
        }

        public string EquipeDomicileNom
        {
            get { return Match.EquipeDomicile.Nom; }
            set
            {
                if (value == Match.EquipeDomicile.Nom) return;
                Match.EquipeDomicile.Nom = value;
                base.OnPropertyChanged("EquipeDomicileNom");
            }
        }

        public IEquipe EquipeVisiteur
        {
            get { return Match.EquipeVisiteur; }
            set
            {
                if (value == Match.EquipeVisiteur) return;
                Match.EquipeVisiteur = value;
                base.OnPropertyChanged("EquipeVisiteur");
                base.OnPropertyChanged("EquipeVisiteurNom");
            }
        }

        public string EquipeVisiteurNom
        {
            get { return Match.EquipeVisiteur.Nom; }
            set
            {
                if (value == Match.EquipeVisiteur.Nom) return;
                Match.EquipeVisiteur.Nom = value;
                base.OnPropertyChanged("EquipeVisiteurNom");
            }
        }

        public double Prix
        {
            get { return Match.Prix; }
            set
            {
                if (value == Match.Prix) return;
                Match.Prix = value;
                base.OnPropertyChanged("EquipeVisiteurNom");
            }
        }

        public ICollection<IStade> Stades
        {
            get { return _stades; }
            set
            {
                if (value == _stades) return;
                _stades = value;
                base.OnPropertyChanged("Equipes");
            }
        }

        public IStade Stade
        {
            get { return Match.Stade; }
            set
            {
                if (value == Match.Stade) return;
                Match.Stade = value;
                base.OnPropertyChanged("Stade");
            }
        }

        public ICollection<IArbitre> Arbitres
        {
            get { return _arbitres; }
            set
            {
                if (value == _arbitres) return;
                _arbitres = value;
                base.OnPropertyChanged("Arbitres");
            }
        }

        public IArbitre Arbitre
        {
            get { return Match.Arbitre; }
            set
            {
                if (value == Match.Arbitre) return;
                Match.Arbitre = value;
                base.OnPropertyChanged("Arbitre");
            }
        }

        public int ScoreEquipeDomicile
        {
            get { return Match.ScoreEquipeDomicile; }
            set
            {
                if (value == Match.ScoreEquipeDomicile) return;
                Match.ScoreEquipeDomicile = value;
                base.OnPropertyChanged("ScoreEquipeDomicile");
            }
        }

        public int ScoreEquipeVisiteur
        {
            get { return Match.ScoreEquipeVisiteur; }
            set
            {
                if (value == Match.ScoreEquipeVisiteur) return;
                Match.ScoreEquipeVisiteur = value;
                base.OnPropertyChanged("ScoreEquipeVisiteur");
            }
        }

        #endregion
    }
}
