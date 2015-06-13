using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using BusinessLayer;

namespace QuidditchWorldCup.Tests
{
    class Test
    {
        public static void testDALAccess(CoupeManager coupeManager) {
            Console.WriteLine("Coupes :");
            ICollection<ICoupe> coupes = coupeManager.GetCoupes();
            foreach (ICoupe coupe in coupes)
            {
                Console.WriteLine(coupe);
            }
            Console.WriteLine("");
            Console.WriteLine("Matchs :");
            ICollection<IMatch> matchs = coupeManager.GetMatchs();
            foreach (IMatch match in matchs)
            {
                Console.WriteLine(match);
            }
            Console.WriteLine("");
            Console.WriteLine("Equipes :");
            ICollection<IEquipe> equipes = coupeManager.GetEquipes();
            foreach (IEquipe equipe in equipes)
            {
                Console.WriteLine(equipe);
            }
            Console.WriteLine("");
            Console.WriteLine("Joueurs :");
            ICollection<IJoueur> joueurs = coupeManager.GetJoueurs();
            foreach (IJoueur joueur in joueurs)
            {
                Console.WriteLine(joueur);
            }
            Console.WriteLine("");
            Console.WriteLine("Stades :");
            ICollection<IStade> stades = coupeManager.GetStades();
            foreach (IStade stade in stades)
            {
                Console.WriteLine(stade);
            }
            Console.WriteLine("");
            Console.WriteLine("Reservations :");
            ICollection<IReservation> reservations = coupeManager.GetReservations();
            foreach (IReservation reservation in reservations)
            {
                Console.WriteLine(reservation);
            }
            Console.WriteLine("");
            Console.WriteLine("Arbitres :");
            ICollection<IArbitre> arbitres = coupeManager.GetArbitres();
            foreach (IArbitre arbitre in arbitres)
            {
                Console.WriteLine(arbitre);
            }
            Console.WriteLine("");
            Console.WriteLine("Spectateurs :");
            ICollection<ISpectateur> spectateurs = coupeManager.GetSpectateurs();
            foreach (ISpectateur spectateur in spectateurs)
            {
                Console.WriteLine(spectateur);
            }
        }
    }
}
