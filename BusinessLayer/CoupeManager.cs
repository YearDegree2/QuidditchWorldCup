using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Manager;
using BusinessLayer.Interfaces;
using BusinessLayer.Classes;

namespace BusinessLayer
{
    public class CoupeManager
    {
        private DALProxy _dalProxy;

        public DALProxy DalProxy
        {
            get { return _dalProxy; }
            set { _dalProxy = value; }
        }

        public CoupeManager()
        {
            DalProxy = new DALProxy();
        }

        public IEnumerable<IMatch> GetMatchsByDateOrd()
        {
            ICollection<IMatch> matchs = GetMatchs();
            IEnumerable<IMatch> matchsOrd = matchs.Select(x => x).OrderBy(y => y.Date).ToList();
            /*from x in matchs orderby x.Date select x*/
            return matchsOrd;
        }

        public IEnumerable<IStade> GetStadesMinOneMatch()
        {
            ICollection<IMatch> matchs = GetMatchs();
            ICollection<IStade> stades = new List<IStade>();
            foreach (IMatch match in matchs)
            {
                stades.Add(match.Stade);
            }
            IEnumerable<IStade> stadesJoues = stades.Select(x => x).Distinct().ToList();
            /*(from x in stades select x).Distinct()*/
            return stadesJoues;
        }

        public IEnumerable<IJoueur> GetAttrapeursMinOneMatchPlayed()
        {
            ICollection<IMatch> matchs = GetMatchs();
            ICollection<IEquipe> equipes = new List<IEquipe>();
            foreach (IMatch match in matchs)
            {
                equipes.Add(match.EquipeDomicile);
                equipes.Add(match.EquipeVisiteur);
            }
            ICollection<IJoueur> joueurs = new List<IJoueur>();
            foreach (IEquipe equipe in equipes)
            {
                foreach (IJoueur joueur in equipe.Joueurs)
                {
                    joueurs.Add(joueur);
                }
            }
            IEnumerable<IJoueur> attrapeurs = joueurs.Select(x => x).Where(y => y.Poste == PosteJoueur.Attrapeur).Distinct().ToList();
            /*(from x in joueurs where PosteJoueur.Attrapeur == x.Poste select x).Distinct()*/
            return attrapeurs;
        }

        public IEnumerable<IJoueur> GetGardiensMoins17Ans()
        {
            ICollection<IJoueur> joueurs = GetJoueurs();
            IEnumerable<IJoueur> gardiens = joueurs.Select(x => x).Where(y => DateTime.Now.Year - y.DateNaissance.Year < 17)
                                                   .Where(z => z.Poste == PosteJoueur.Gardien).Distinct().ToList();
            /*(from x in joueurs where ((DateTime.Now.Year - x.DateNaissance.Year) < 17) && PosteJoueur.Gardien == x.Poste select x).Distinct()*/
            return gardiens;
        }

        public int GetNbPlacesRestantes(IMatch match)
        {
            int nbPlacesMax = match.Stade.NombrePlaces;
            ICollection<IReservation> reservations = GetReservations();
            int placesUsed = 0;
            foreach (IReservation reservation in reservations)
            {
                placesUsed++;
            }
            return nbPlacesMax - placesUsed;
        }

        // Methodes pour recuperer les elements de la DataAccessLayer
        public ICollection<ICoupe> GetCoupes()
        {
            return Methods.GetCoupes(DalProxy.Manager.Coupes);
        }

        public ICollection<IMatch> GetMatchs()
        {
            return Methods.GetMatchs(DalProxy.Manager.Matchs);
        }

        public IMatch GetMatch(int idMatch)
        {
            ICollection<IMatch> matchs = GetMatchs();
            return matchs.Select(x => x).Where(y => y.Id == idMatch).First();
        }

        public ICollection<IEquipe> GetEquipes()
        {
            return Methods.GetEquipes(DalProxy.Manager.Equipes);
        }

        public ICollection<IJoueur> GetJoueurs()
        {
            return Methods.GetJoueurs(DalProxy.Manager.Joueurs);
        }

        public ICollection<IStade> GetStades()
        {
            return Methods.GetStades(DalProxy.Manager.Stades);
        }

        public ICollection<IReservation> GetReservations()
        {
            return Methods.GetReservations(DalProxy.Manager.Reservations);
        }

        public IEnumerable<IReservation> GetReservations(int idMatch)
        {
            ICollection<IReservation> reservations = GetReservations();
            return reservations.Select(x => x).Where(y => y.Match.Id == idMatch).ToList();
        }

        public IReservation GetReservation(int idReservation)
        {
            ICollection<IReservation> reservations = GetReservations();
            return reservations.Select(x => x).Where(y => y.Id == idReservation).First();
        }

        public ICollection<IArbitre> GetArbitres()
        {
            return Methods.GetArbitres(DalProxy.Manager.Arbitres);
        }

        public ICollection<ISpectateur> GetSpectateurs()
        {
            return Methods.GetSpectateurs(DalProxy.Manager.Spectateurs);
        }

        public void UpdateMatchs(ICollection<IMatch> matchs)
        {
            DalProxy.Manager.UpdateMatchs(Methods.GetMatchsDal(matchs));
        }

        public void AddReservation(int id, int idMatch, int place, int idSpectateur)
        {
            DalProxy.Manager.AddReservation(id, idMatch, place, idSpectateur);
        }

        public void DeleteReservation(int idReservation)
        {
            IReservation reservation = GetReservation(idReservation);
            DalProxy.Manager.DeleteReservation(Methods.GetReservation(reservation));
        }

        public int GetNewIdForReservation()
        {
            ICollection<IReservation> reservations = GetReservations();
            return reservations.Last().Id + 1;
        }
    }
}
