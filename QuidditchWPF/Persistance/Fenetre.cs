using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuidditchWPF.Persistance
{
    [Serializable]
    public class Fenetre
    {
        private string _name;

        /// <summary>
        /// Position X de la fenetre dans l'ecran.
        /// </summary>
        private double _posX;

        /// <summary>
        /// Position Y de la fenetre dans l'ecran.
        /// </summary>
        private double _posY;

        /// <summary>
        /// Hauteur de la fenetre.
        /// </summary>
        private double _hauteur;

        /// <summary>
        /// Largeur de la fenetre.
        /// </summary>
        private double _largeur;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double PosX
        {
            get { return _posX; }
            set { _posX = value; }
        }

        public double PosY
        {
            get { return _posY; }
            set { _posY = value; }
        }

        public double Hauteur
        {
            get { return _hauteur; }
            set { _hauteur = value; }
        }

        public double Largeur
        {
            get { return _largeur; }
            set { _largeur = value; }
        }

        public Fenetre() : this("New window", 50d, 50d, 300d, 300d) { }

        public Fenetre(string name, double posX, double posY, double hauteur, double largeur)
        {
            Name = name;
            PosX = posX;
            PosY = posY;
            Hauteur = hauteur;
            Largeur = largeur;
        }
    }
}
