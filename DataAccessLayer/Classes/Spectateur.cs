using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Classes
{
    class Spectateur : ISpectateur
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private DateTime _dateNaissance;
        private string _adresse;
        private string _ville;
        private string _email;

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

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public Spectateur() : this(0, "Doe", "John", DateTime.MinValue, "inconnu", "inconnu", "inconnu") { }

        public Spectateur(int id, string nom, string prenom, DateTime dateNaissance, string adresse, string ville, string email)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Adresse = adresse;
            Ville = ville;
            Email = email;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj as Spectateur == null) return false;
            Spectateur spectateur = (Spectateur)obj;
            return Id.Equals(spectateur.Id);
        }
    }
}
