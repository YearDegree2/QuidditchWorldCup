using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Classes
{
    class Match : IMatch
    {
        private int _id;
        private DateTime _date;
        private ICoupe _coupe;
        private IEquipe _equipeDomicile;
        private IEquipe _equipeVisiteur;
        private double _prix;
        private IStade _stade;
        private IArbitre _arbitre;
        private int _scoreEquipeDomicile;
        private int _scoreEquipeVisiteur;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public ICoupe Coupe
        {
            get { return _coupe; }
            set { _coupe = value; }
        }

        public IEquipe EquipeDomicile
        {
            get { return _equipeDomicile; }
            set { _equipeDomicile = value; }
        }

        public IEquipe EquipeVisiteur
        {
            get { return _equipeVisiteur; }
            set { _equipeVisiteur = value; }
        }

        public double Prix
        {
            get { return _prix; }
            set { _prix = value; }
        }

        public IStade Stade
        {
            get { return _stade; }
            set { _stade = value; }
        }

        public IArbitre Arbitre
        {
            get { return _arbitre; }
            set { _arbitre = value; }
        }

        public int ScoreEquipeDomicile
        {
            get { return _scoreEquipeDomicile; }
            set { _scoreEquipeDomicile = value; }
        }

        public int ScoreEquipeVisiteur
        {
            get { return _scoreEquipeVisiteur; }
            set { _scoreEquipeVisiteur = value; }
        }

        public Match() : this(0, DateTime.MinValue, new Coupe(), new Equipe(), new Equipe(), 0, new Stade(), new Arbitre(), -1, -1) { }

        public Match(int id, DateTime date, ICoupe coupe, IEquipe equipeDomicile, IEquipe equipeVisiteur, double prix, IStade stade, IArbitre arbitre, int scoreEquipeDomicile, int scoreEquipeVisiteur)
        {
            Id = id;
            Date = date;
            Coupe = coupe;
            EquipeDomicile = equipeDomicile;
            EquipeVisiteur = equipeVisiteur;
            Prix = prix;
            Stade = stade;
            Arbitre = arbitre;
            ScoreEquipeDomicile = scoreEquipeDomicile;
            ScoreEquipeVisiteur = scoreEquipeVisiteur;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj as Match == null) return false;
            Match match = (Match)obj;
            return Id.Equals(match.Id);
        }

        public override string ToString()
        {
            return String.Format("{0} ({1}) : {2} {3} - {4} {5}", Coupe, Date, EquipeDomicile, ScoreEquipeDomicile, ScoreEquipeVisiteur, EquipeVisiteur);
        }
    }
}
