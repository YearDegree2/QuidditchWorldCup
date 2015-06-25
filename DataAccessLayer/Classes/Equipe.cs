using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Classes
{
    public class Equipe : IEquipe
    {
        private int _id;
        private string _nom;
        private string _pays;
        private ICollection<IJoueur> _joueurs;

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

        public string Pays
        {
            get { return _pays; }
            set { _pays = value; }
        }

        public ICollection<IJoueur> Joueurs
        {
            get { return _joueurs; }
            set { _joueurs = value; }
        }

        public Equipe() : this(0, "inconnu", "inconnu", new List<IJoueur>()) { }

        public Equipe(int id, string nom, string pays, ICollection<IJoueur> joueurs)
        {
            Id = id;
            Joueurs = new List<IJoueur>();
            Nom = nom;
            Pays = pays;
            if (joueurs != null)
                Joueurs = joueurs;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj as Equipe == null) return false;
            Equipe equipe = (Equipe)obj;
            return Id.Equals(equipe.Id);
        }

        public override string ToString()
        {
            return String.Format("Equipe : {0} ({1})", Nom, Pays);
        }
    }
}
