﻿using System;
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

        public ICollection<ICoupe> GetAllCoupes()
        {
            return Methods.GetCoupes(DalProxy.Manager.Coupes);
        }

        public ICollection<IMatch> GetAllMatchs()
        {
            return Methods.GetMatchs(DalProxy.Manager.Matchs);
        }

        public ICollection<IEquipe> GetAllEquipes()
        {
            return Methods.GetEquipes(DalProxy.Manager.Equipes);
        }

        public ICollection<IStade> GetAllStades()
        {
            return Methods.GetStades(DalProxy.Manager.Stades);
        }

        public ICollection<IArbitre> GetAllArbitres()
        {
            return Methods.GetArbitres(DalProxy.Manager.Arbitres);
        }

        public IEnumerable<IMatch> GetMatchsByDateOrd()
        {
            ICollection<IMatch> matchs = Methods.GetMatchs(DalProxy.Manager.Matchs);
            IEnumerable<IMatch> matchsOrd = matchs.Select(x => x).OrderBy(y => y.Date).ToList();
            /*from x in matchs orderby x.Date select x*/
            return matchsOrd;
        }

        public IEnumerable<IStade> GetStadesMinOneMatch()
        {
            ICollection<IMatch> matchs = Methods.GetMatchs(DalProxy.Manager.Matchs);
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
            ICollection<IMatch> matchs = Methods.GetMatchs(DalProxy.Manager.Matchs);
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
            ICollection<IJoueur> joueurs = Methods.GetJoueurs(DalProxy.Manager.Joueurs);
            IEnumerable<IJoueur> gardiens = joueurs.Select(x => x).Where(y => DateTime.Now.Year - y.DateNaissance.Year < 17)
                                                   .Where(z => z.Poste == PosteJoueur.Gardien).Distinct().ToList();
            /*(from x in joueurs where ((DateTime.Now.Year - x.DateNaissance.Year) < 17) && PosteJoueur.Gardien == x.Poste select x).Distinct()*/
            return gardiens;
        }

        public int GetNbPlacesRestantes(IMatch match)
        {
            int nbPlacesMax = match.Stade.NombrePlaces;
            ICollection<IReservation> reservations = new List<IReservation>();
            foreach (DataAccessLayer.Interfaces.IReservation reservation in DalProxy.Manager.Reservations)
            {
                reservations.Add(Methods.GetReservation(reservation));
            }
            int placesUsed = 0;
            foreach (IReservation reservation in reservations)
            {
                placesUsed++;
            }
            return nbPlacesMax - placesUsed;
        }
    }
}