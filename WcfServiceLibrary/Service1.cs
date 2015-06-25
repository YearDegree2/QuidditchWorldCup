using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessLayer.Interfaces;
using BusinessLayer;

namespace WcfServiceLibrary
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        public ICollection<CompositeType> GetMatchs()
        {
            CoupeManager manager = new CoupeManager();
            ICollection<IMatch> matchs = manager.GetMatchs();
            ICollection<CompositeType> types = new List<CompositeType>();
            foreach (IMatch match in matchs)
            {
                CompositeType type = new CompositeType();
                type.Id = match.Id;
                type.Date = match.Date;
                type.Coupe = String.Format("Coupe du monde {0}", match.Coupe.Year);
                type.EquipeDomicile = match.EquipeDomicile.Nom;
                type.EquipeVisiteur = match.EquipeVisiteur.Nom;
                type.Prix = match.Prix;
                type.Stade = match.Stade.Nom;
                type.Arbitre = match.Arbitre.Prenom + " " + match.Arbitre.Nom;
                type.ScoreEquipeDomicile = match.ScoreEquipeDomicile;
                type.ScoreEquipeVisiteur = match.ScoreEquipeVisiteur;
                types.Add(type);
            }
            return types;
        }
    }
}
