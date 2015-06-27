using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Manager
{
    class DALManager : IDALManager
    {
        private Bridge _bridge;
        private ICollection<ICoupe> _coupes;
        private ICollection<IMatch> _matchs;
        private ICollection<IEquipe> _equipes;
        private ICollection<IJoueur> _joueurs;
        private ICollection<IStade> _stades;
        private ICollection<IReservation> _reservations;
        private ICollection<IArbitre> _arbitres;
        private ICollection<ISpectateur> _spectateurs;

        public Bridge Bridge
        {
            get { return _bridge; }
            set { _bridge = value; }
        }

        public ICollection<ICoupe> Coupes
        {
            get { return _coupes; }
            set { _coupes = value; }
        }

        public ICollection<IMatch> Matchs
        {
            get { return _matchs; }
            set { _matchs = value; }
        }

        public ICollection<IEquipe> Equipes
        {
            get { return _equipes; }
            set { _equipes = value; }
        }

        public ICollection<IJoueur> Joueurs
        {
            get { return _joueurs; }
            set { _joueurs = value; }
        }

        public ICollection<IStade> Stades
        {
            get { return _stades; }
            set { _stades = value; }
        }

        public ICollection<IReservation> Reservations
        {
            get { return _reservations; }
            set { _reservations = value; }
        }

        public ICollection<IArbitre> Arbitres
        {
            get { return _arbitres; }
            set { _arbitres = value; }
        }

        public ICollection<ISpectateur> Spectateurs
        {
            get { return _spectateurs; }
            set { _spectateurs = value; }
        }

        public void UpdateMatchs(ICollection<IMatch> matchs)
        {
            Bridge.UpdateMatch(matchs);
        }

        public void AddReservation(int id, int idMatch, int place, int idSpectateur)
        {
            Bridge.AddReservation(id, idMatch, place, idSpectateur);
        }

        public void DeleteReservation(IReservation reservation)
        {
            Bridge.DeleteReservation(reservation);
        }

        public DALManager()
        {
            Bridge = new SqlDB();
            Coupes = Bridge.GetCoupes();
            Matchs = Bridge.GetMatchs();
            Equipes = Bridge.GetEquipes();
            Joueurs = Bridge.GetJoueurs();
            Stades = Bridge.GetStades();
            Reservations = Bridge.GetReservations();
            Arbitres = Bridge.GetArbitres();
            Spectateurs = Bridge.GetSpectateurs();
        }
    }
}
