using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Manager
{
    public interface IDALManager
    {
        System.Collections.Generic.ICollection<ICoupe> Coupes { get; }
        System.Collections.Generic.ICollection<IMatch> Matchs { get; }
        System.Collections.Generic.ICollection<IEquipe> Equipes { get; }
        System.Collections.Generic.ICollection<IJoueur> Joueurs { get; }
        System.Collections.Generic.ICollection<IStade> Stades { get; }
        System.Collections.Generic.ICollection<IReservation> Reservations { get; }
        System.Collections.Generic.ICollection<IArbitre> Arbitres { get; }
        System.Collections.Generic.ICollection<ISpectateur> Spectateurs { get; }
    }
}
