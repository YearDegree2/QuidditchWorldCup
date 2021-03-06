﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using BusinessLayer.Classes;

namespace BusinessLayer
{
    class Methods
    {
        public static ICollection<ICoupe> GetCoupes(ICollection<DataAccessLayer.Interfaces.ICoupe> coupesDAL)
        {
            ICollection<ICoupe> coupes = new List<ICoupe>();
            foreach (DataAccessLayer.Interfaces.ICoupe coupe in coupesDAL)
            {
                coupes.Add(GetCoupe(coupe));
            }
            return coupes;
        }

        public static ICoupe GetCoupe(DataAccessLayer.Interfaces.ICoupe coupe)
        {
            return new Coupe(coupe.Id, coupe.Year);
        }

        public static DataAccessLayer.Interfaces.ICoupe GetCoupe(ICoupe coupe)
        {
            return new DataAccessLayer.Classes.Coupe(coupe.Id, coupe.Year);
        }

        public static ICollection<IMatch> GetMatchs(ICollection<DataAccessLayer.Interfaces.IMatch> matchsDAL)
        {
            ICollection<IMatch> matchs = new List<IMatch>();
            foreach (DataAccessLayer.Interfaces.IMatch match in matchsDAL)
            {
                matchs.Add(GetMatch(match));
            }
            return matchs;
        }

        public static IMatch GetMatch(DataAccessLayer.Interfaces.IMatch match)
        {
            return new Match(match.Id, match.Date, GetCoupe(match.Coupe), GetEquipe(match.EquipeDomicile), GetEquipe(match.EquipeVisiteur), match.Prix, GetStade(match.Stade), GetArbitre(match.Arbitre), match.ScoreEquipeDomicile, match.ScoreEquipeVisiteur);
        }

        public static DataAccessLayer.Interfaces.IMatch GetMatch(IMatch match)
        {
            return new DataAccessLayer.Classes.Match(match.Id, match.Date, GetCoupe(match.Coupe), GetEquipe(match.EquipeDomicile), GetEquipe(match.EquipeVisiteur), match.Prix, GetStade(match.Stade), GetArbitre(match.Arbitre), match.ScoreEquipeDomicile, match.ScoreEquipeVisiteur);
        }

        public static ICollection<DataAccessLayer.Interfaces.IMatch> GetMatchsDal(ICollection<IMatch> matchs)
        {
            ICollection<DataAccessLayer.Interfaces.IMatch> matchsDAL = new List<DataAccessLayer.Interfaces.IMatch>();
            foreach (IMatch match in matchs)
            {
                matchsDAL.Add(new DataAccessLayer.Classes.Match(match.Id, match.Date, GetCoupe(match.Coupe), GetEquipe(match.EquipeDomicile), GetEquipe(match.EquipeVisiteur), match.Prix, GetStade(match.Stade), GetArbitre(match.Arbitre), match.ScoreEquipeDomicile, match.ScoreEquipeVisiteur));
            }
            return matchsDAL;
        }

        public static ICollection<IEquipe> GetEquipes(ICollection<DataAccessLayer.Interfaces.IEquipe> equipesDAL)
        {
            ICollection<IEquipe> equipes = new List<IEquipe>();
            foreach (DataAccessLayer.Interfaces.IEquipe equipe in equipesDAL)
            {
                equipes.Add(GetEquipe(equipe));
            }
            return equipes;
        }

        public static IEquipe GetEquipe(DataAccessLayer.Interfaces.IEquipe equipe)
        {
            return new Equipe(equipe.Id, equipe.Nom, equipe.Pays, GetJoueurs(equipe.Joueurs));
        }

        public static DataAccessLayer.Interfaces.IEquipe GetEquipe(IEquipe equipe)
        {
            return new DataAccessLayer.Classes.Equipe(equipe.Id, equipe.Nom, equipe.Pays, GetJoueurs(equipe.Joueurs));
        }

        public static ICollection<IJoueur> GetJoueurs(ICollection<DataAccessLayer.Interfaces.IJoueur> joueursDAL)
        {
            ICollection<IJoueur> joueurs = new List<IJoueur>();
            foreach (DataAccessLayer.Interfaces.IJoueur joueur in joueursDAL)
            {
                joueurs.Add(GetJoueur(joueur));
            }
            return joueurs;
        }

        public static ICollection<DataAccessLayer.Interfaces.IJoueur> GetJoueurs(ICollection<IJoueur> joueurs)
        {
            ICollection<DataAccessLayer.Interfaces.IJoueur> joueursDal = new List<DataAccessLayer.Interfaces.IJoueur>();
            foreach (IJoueur joueur in joueurs)
            {
                joueursDal.Add(GetJoueur(joueur));
            }
            return joueursDal;
        }

        public static IJoueur GetJoueur(DataAccessLayer.Interfaces.IJoueur joueur)
        {
            return new Joueur(joueur.Id, joueur.Nom, joueur.Prenom, joueur.DateNaissance, joueur.Numero, (PosteJoueur)joueur.Poste, joueur.Capitaine);
        }

        public static DataAccessLayer.Interfaces.IJoueur GetJoueur(IJoueur joueur)
        {
            return new DataAccessLayer.Classes.Joueur(joueur.Id, joueur.Nom, joueur.Prenom, joueur.DateNaissance, joueur.Numero, (DataAccessLayer.Classes.PosteJoueur)joueur.Poste, joueur.Capitaine);
        }

        public static ICollection<IStade> GetStades(ICollection<DataAccessLayer.Interfaces.IStade> stadesDAL)
        {
            ICollection<IStade> stades = new List<IStade>();
            foreach (DataAccessLayer.Interfaces.IStade stade in stadesDAL)
            {
                stades.Add(GetStade(stade));
            }
            return stades;
        }

        public static IStade GetStade(DataAccessLayer.Interfaces.IStade stade)
        {
            return new Stade(stade.Id, stade.Nom, stade.Adresse, stade.Ville, stade.NombrePlaces);
        }

        public static DataAccessLayer.Interfaces.IStade GetStade(IStade stade)
        {
            return new DataAccessLayer.Classes.Stade(stade.Id, stade.Nom, stade.Adresse, stade.Ville, stade.NombrePlaces);
        }

        public static ICollection<IReservation> GetReservations(ICollection<DataAccessLayer.Interfaces.IReservation> reservationsDAL)
        {
            ICollection<IReservation> reservations = new List<IReservation>();
            foreach (DataAccessLayer.Interfaces.IReservation reservation in reservationsDAL)
            {
                reservations.Add(GetReservation(reservation));
            }
            return reservations;
        }

        public static IReservation GetReservation(DataAccessLayer.Interfaces.IReservation reservation)
        {
            return new Reservation(reservation.Id, GetMatch(reservation.Match), reservation.Place, GetSpectateur(reservation.Spectateur));
        }

        public static DataAccessLayer.Interfaces.IReservation GetReservation(IReservation reservation)
        {
            return new DataAccessLayer.Classes.Reservation(reservation.Id, GetMatch(reservation.Match), reservation.Place, GetSpectateur(reservation.Spectateur));
        }

        public static ICollection<IArbitre> GetArbitres(ICollection<DataAccessLayer.Interfaces.IArbitre> arbitresDAL)
        {
            ICollection<IArbitre> arbitres = new List<IArbitre>();
            foreach (DataAccessLayer.Interfaces.IArbitre arbitre in arbitresDAL)
            {
                arbitres.Add(GetArbitre(arbitre));
            }
            return arbitres;
        }

        public static IArbitre GetArbitre(DataAccessLayer.Interfaces.IArbitre arbitre)
        {
            return new Arbitre(arbitre.Id, arbitre.Nom, arbitre.Prenom, arbitre.DateNaissance, arbitre.NumeroPoliceAssuranceVie);
        }

        public static DataAccessLayer.Interfaces.IArbitre GetArbitre(IArbitre arbitre)
        {
            return new DataAccessLayer.Classes.Arbitre(arbitre.Id, arbitre.Nom, arbitre.Prenom, arbitre.DateNaissance, arbitre.NumeroPoliceAssuranceVie);
        }

        public static ICollection<ISpectateur> GetSpectateurs(ICollection<DataAccessLayer.Interfaces.ISpectateur> spectateursDAL)
        {
            ICollection<ISpectateur> spectateurs = new List<ISpectateur>();
            foreach (DataAccessLayer.Interfaces.ISpectateur spectateur in spectateursDAL)
            {
                spectateurs.Add(GetSpectateur(spectateur));
            }
            return spectateurs;
        }

        public static ISpectateur GetSpectateur(DataAccessLayer.Interfaces.ISpectateur spectateur)
        {
            return new Spectateur(spectateur.Id, spectateur.Nom, spectateur.Prenom, spectateur.DateNaissance, spectateur.Adresse, spectateur.Ville, spectateur.Email);
        }

        public static DataAccessLayer.Interfaces.ISpectateur GetSpectateur(ISpectateur spectateur)
        {
            return new DataAccessLayer.Classes.Spectateur(spectateur.Id, spectateur.Nom, spectateur.Prenom, spectateur.DateNaissance, spectateur.Adresse, spectateur.Ville, spectateur.Email);
        }
    }
}
