﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Manager
{
    public interface Bridge
    {
        ICollection<ICoupe> GetCoupes();
        ICollection<IMatch> GetMatchs();
        ICollection<IEquipe> GetEquipes();
        ICollection<IJoueur> GetJoueurs();
        ICollection<IStade> GetStades();
        ICollection<IReservation> GetReservations();
        ICollection<IArbitre> GetArbitres();
        ICollection<ISpectateur> GetSpectateurs();
        void UpdateMatch(ICollection<IMatch> matchs);
        void AddReservation(int id, int idMatch, int place, int idSpectateur);
        void DeleteReservation(IReservation reservation);
        void EditReservation(int id, int place);
    }
}
