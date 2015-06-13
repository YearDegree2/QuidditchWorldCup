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
            foreach (ICoupe coupe in coupeManager.GetCoupes())
            {
                Console.WriteLine(coupe);
            }
            Console.WriteLine("");
            Console.WriteLine("Matchs :");
            foreach (IMatch match in coupeManager.GetMatchs())
            {
                Console.WriteLine(match);
            }
            Console.WriteLine("");
            Console.WriteLine("Equipes :");
            foreach (IEquipe equipe in coupeManager.GetEquipes())
            {
                Console.WriteLine(equipe);
            }
            Console.WriteLine("");
            Console.WriteLine("Joueurs :");
            foreach (IJoueur joueur in coupeManager.GetJoueurs())
            {
                Console.WriteLine(joueur);
            }
            Console.WriteLine("");
            Console.WriteLine("Stades :");
            foreach (IStade stade in coupeManager.GetStades())
            {
                Console.WriteLine(stade);
            }
            Console.WriteLine("");
            Console.WriteLine("Reservations :");
            foreach (IReservation reservation in coupeManager.GetReservations())
            {
                Console.WriteLine(reservation);
            }
            Console.WriteLine("");
            Console.WriteLine("Arbitres :");
            foreach (IArbitre arbitre in coupeManager.GetArbitres())
            {
                Console.WriteLine(arbitre);
            }
            Console.WriteLine("");
            Console.WriteLine("Spectateurs :");
            foreach (ISpectateur spectateur in coupeManager.GetSpectateurs())
            {
                Console.WriteLine(spectateur);
            }
        }
    }
}
