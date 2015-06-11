using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Classes
{
    class Stade : IStade
    {
        private int _id;
        private string _nom;
        private string _adresse;
        private string _ville;
        private int _nombrePlaces;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }

        public string Ville
        {
            get { return _ville; }
            set { _ville = value; }
        }

        public int NombrePlaces
        {
            get { return _nombrePlaces; }
            set { _nombrePlaces = value; }
        }

        public Stade() : this(0, "inconnu", "inconnu", "inconnu", 0) { }

        public Stade(int id, string nom, string adresse, string ville, int nombrePlaces)
        {
            Id = id;
            Nom = nom;
            Adresse = adresse;
            Ville = ville;
            NombrePlaces = nombrePlaces;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj as Stade == null) return false;
            Stade stade = (Stade)obj;
            return Id.Equals(stade.Id);
        }

        public override string ToString()
        {
            return String.Format("{0} ({1} places) : {2}", Nom, NombrePlaces, Ville);
        }
    }
}
