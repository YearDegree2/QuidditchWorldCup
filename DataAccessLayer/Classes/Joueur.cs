using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Classes
{
    public enum PosteJoueur { None, Poursuiveur, Batteur, Gardien, Attrapeur };

    public class Joueur : IJoueur
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private DateTime _dateNaissance;
        private string _numero;
        private PosteJoueur _poste;
        private bool _capitaine;

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

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public PosteJoueur Poste
        {
            get { return _poste; }
            set { _poste = value; }
        }

        public bool Capitaine
        {
            get { return _capitaine; }
            set { _capitaine = value; }
        }

        public Joueur() : this(0, "Doe", "John", DateTime.MinValue, "0", PosteJoueur.None, false) { }

        public Joueur(int id, string nom, string prenom, DateTime dateNaissance, string numero, PosteJoueur poste, bool capitaine)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Numero = numero;
            Poste = poste;
            Capitaine = capitaine;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj as Joueur == null) return false;
            Joueur joueur = (Joueur)obj;
            return Id.Equals(joueur.Id);
        }

        public override string ToString()
        {
            return String.Format("{0} {1} ({2}) : {3}", Prenom, Nom, DateNaissance, Poste);
        }
    }
}
