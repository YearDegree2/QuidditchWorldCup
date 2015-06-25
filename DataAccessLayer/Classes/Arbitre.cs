using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Classes
{
    public class Arbitre : IArbitre
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private DateTime _dateNaissance;
        private string _numeroPoliceAssuranceVie;

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

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public DateTime DateNaissance
        {
            get { return _dateNaissance; }
            set { _dateNaissance = value; }
        }

        public string NumeroPoliceAssuranceVie
        {
            get { return _numeroPoliceAssuranceVie; }
            set { _numeroPoliceAssuranceVie = value; }
        }

        public Arbitre() : this(0, "Doe", "John", DateTime.MinValue, "000") { }

        public Arbitre(int id, string nom, string prenom, DateTime dateNaissance, string numeroPoliceAssuranceVie)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            NumeroPoliceAssuranceVie = numeroPoliceAssuranceVie;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj as Arbitre == null) return false;
            Arbitre arbitre = (Arbitre)obj;
            return Id.Equals(arbitre.Id);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", Prenom, Nom);
        }
    }
}
