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

            // Permet de tester toutes les listes pour voir qu'elles marchent et ne sont pas vides, a appeler juste quand on teste
            //Test.testDALAccess(coupeManager);
            
            ICollection<ICoupe> coupes = coupeManager.GetCoupes();
            IEnumerable<IMatch> matchsOrd = coupeManager.GetMatchsByDateOrd();
            IEnumerable<IStade> stades = coupeManager.GetStadesMinOneMatch();
            IEnumerable<IJoueur> attrapeursMinOneMatchPlayed = coupeManager.GetAttrapeursMinOneMatchPlayed();
            IEnumerable<IJoueur> gardiensMoins17Ans = coupeManager.GetGardiensMoins17Ans();
            IEnumerable<IMatch> matchs = coupeManager.GetMatchs();
            int nbPlacesRestantes = coupeManager.GetNbPlacesRestantes(matchs.First());
            
            Console.WriteLine("Coupes : ");
            foreach (ICoupe coupe in coupes)
            {
                Console.WriteLine(coupe);
            }
            Console.WriteLine("");
            Console.WriteLine("Matchs ordonnés par date : ");
            foreach (IMatch match in matchsOrd)
            {
                Console.WriteLine(match);
            }
            Console.WriteLine("");
            Console.WriteLine("Stades ou au moins un match a ete programmé : ");
            foreach (IStade stade in stades)
            {
                Console.WriteLine(stade);
            }
            Console.WriteLine("");
            Console.WriteLine("Attrapeurs ayant joué au moins un match : ");
            foreach (IJoueur attrapeur in attrapeursMinOneMatchPlayed)
            {
                Console.WriteLine(attrapeur);
            }
            Console.WriteLine("");
            Console.WriteLine("Gardiens de moins de 17 ans : ");
            foreach (IJoueur gardien in gardiensMoins17Ans)
            {
                Console.WriteLine(gardien);
            }
            Console.WriteLine("");
            Console.WriteLine("Nombre de places restantes pour le match avec l'id le plus petit");
            Console.WriteLine(String.Format("{0} places restantes", nbPlacesRestantes));
        
            Console.ReadLine();
        }
    }
}
