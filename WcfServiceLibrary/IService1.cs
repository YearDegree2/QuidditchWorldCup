using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessLayer.Interfaces;

namespace WcfServiceLibrary
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        ICollection<CompositeType> GetMatchs();
    }

    // Utilisez un contrat de données (comme illustré dans l'exemple ci-dessous) pour ajouter des types composites aux opérations de service.
    // Vous pouvez ajouter des fichiers XSD au projet. Une fois le projet généré, vous pouvez utiliser directement les types de données qui y sont définis, avec l'espace de noms "WcfServiceLibrary.ContractType".
    [DataContract]
    public class CompositeType
    {
        int id;
        DateTime date;
        string coupe;
        string equipeDomicile;
        string equipeVisiteur;
        double prix;
        string stade;
        string arbitre;
        int scoreEquipeDomicile;
        int scoreEquipeVisiteur;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [DataMember]
        public string Coupe
        {
            get { return coupe; }
            set { coupe = value; }
        }

        [DataMember]
        public string EquipeDomicile
        {
            get { return equipeDomicile; }
            set { equipeDomicile = value; }
        }

        [DataMember]
        public string EquipeVisiteur
        {
            get { return equipeVisiteur; }
            set { equipeVisiteur = value; }
        }

        [DataMember]
        public double Prix
        {
            get { return prix; }
            set { prix = value; }
        }

        [DataMember]
        public string Stade
        {
            get { return stade; }
            set { stade = value; }
        }

        [DataMember]
        public string Arbitre
        {
            get { return arbitre; }
            set { arbitre = value; }
        }

        [DataMember]
        public int ScoreEquipeDomicile
        {
            get { return scoreEquipeDomicile; }
            set { scoreEquipeDomicile = value; }
        }

        [DataMember]
        public int ScoreEquipeVisiteur
        {
            get { return scoreEquipeVisiteur; }
            set { scoreEquipeVisiteur = value; }
        }

        public override string ToString()
        {
            return String.Format("{0} ({1}) : {2} {3} - {4} {5}", Coupe, Date, EquipeDomicile, ScoreEquipeDomicile, ScoreEquipeVisiteur, EquipeVisiteur);
        }
    }
}
