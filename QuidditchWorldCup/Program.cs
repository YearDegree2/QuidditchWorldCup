using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using BusinessLayer;
using QuidditchWorldCup.Tests;

namespace QuidditchWorldCup
{
    class Program
    {
        static void Main(string[] args)
        {
            CoupeManager coupeManager = new CoupeManager();

            Test.testDALAccess(coupeManager);
            
            
            
            /*ICollection<ICoupe> coupes = coupeManager.GetAllCoupes();
            /*IEnumerable<IMatch> matchsOrd = coupeManager.GetMatchsByDateOrd();
            IEnumerable<IStade> stades = coupeManager.GetStadesMinOneMatch();
            IEnumerable<IJoueur> attrapeursMinOneMatchPlayed = coupeManager.GetAttrapeursMinOneMatchPlayed();
            IEnumerable<IJoueur> gardiensMoins17Ans = coupeManager.GetGardiensMoins17Ans();
            int nbPlacesRestant = coupeManager.GetNbPlacesRestantes(matchsOrd.First());
            Console.WriteLine("Coupes : ");
            foreach (ICoupe coupe in coupes)
            {
                Console.WriteLine(coupe);
            }
            Console.WriteLine();
           /* Console.WriteLine("Matchs ordonnés par date : ");
            foreach (IMatch match in matchsOrd)
            {
                Console.WriteLine(match);
            } Console.WriteLine();
            Console.WriteLine("Stades ou au moins un match a ete programmé : ");
            foreach (IStade stade in stades)
            {
                Console.WriteLine(stade);
            }
            Console.WriteLine();
            Console.WriteLine("Attrapeurs ayant joué au moins un match : ");
            foreach (IJoueur attrapeur in attrapeursMinOneMatchPlayed)
            {
                Console.WriteLine(attrapeur);
            }
            Console.WriteLine();
            Console.WriteLine("Gardiens de moins de 17 ans : ");
            foreach (IJoueur gardien in gardiensMoins17Ans)
            {
                Console.WriteLine(gardien);
            }
            Console.WriteLine();
            Console.WriteLine("Nombre de places restantes pour le match Gryffondor - Serpentard du 02/01/2015");
            Console.WriteLine(String.Format("{0} places restantes", nbPlacesRestant));*/



            
            

            Console.ReadLine();
        }
    }
}
