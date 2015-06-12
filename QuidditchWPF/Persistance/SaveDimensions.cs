using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using System.IO;

namespace QuidditchWPF.Persistance
{
    [Serializable]
    public class SaveDimensions
    {
        private List<Fenetre> _listWindows;
        private static SaveDimensions instance;

        public List<Fenetre> ListWindows
        {
            get { return _listWindows; }
            set { _listWindows = value; }
        }

        private SaveDimensions()
        {
            ListWindows = new List<Fenetre>();
        }

        public static SaveDimensions GetInstance()
        {
            if (instance == null)
            {
                instance = new SaveDimensions();
            }
            return instance;
        }

        public void saveDimensionsWindow(Window window)
        {
            if (window != null)
            {
                if (SaveDimensions.GetInstance().GetFenetreByName(window.Title) != null)
                {
                    Fenetre currentFenetre = GetFenetreByName(window.Title);

                    currentFenetre.PosX = window.Left;
                    currentFenetre.PosY = window.Top;
                    currentFenetre.Hauteur = window.Height;
                    currentFenetre.Largeur = window.Width;
                }
                else
                {
                    ListWindows.Add(new Fenetre(window.Title, window.Left, window.Top, window.Height, window.Width));
                }
            }
        }

        /// <summary>
        /// Permet de charger les dimensions et position d'une fenetre dans la liste des fenetres de l'application.
        /// </summary>
        /// <param name="window">La fenetre a sauvegarder.</param>
        public void loadDimensionsWindow(Window window)
        {
            if (SaveDimensions.GetInstance().GetFenetreByName(window.Title) != null)
            {
                Fenetre currentFenetre = GetFenetreByName(window.Title);

                window.Left = currentFenetre.PosX;
                window.Top = currentFenetre.PosY;
                window.Height = currentFenetre.Hauteur;
                window.Width = currentFenetre.Largeur;
            }
        }

        /// <summary>
        /// Permet de serializer l'ensemble des fenetres.
        /// </summary>
        public void SaveFenetresProperties()
        {
            string path = "../../Save/Windows/SerializationWindow.xml";
            XmlSerializer writer = new XmlSerializer(typeof(SaveDimensions));
            StreamWriter file = new StreamWriter(path);
            writer.Serialize(file, this);
            file.Close();
        }

        /// <summary>
        /// Permet de deserializer l'ensemble des fenetres.
        /// </summary>
        public void LoadFenetresProperties()
        {
            string path = "../../Save/Windows/SerializationWindow.xml";
            if (File.Exists(path))
            {
                XmlSerializer reader = new XmlSerializer(typeof(SaveDimensions));
                StreamReader file = new StreamReader(path);
                SaveDimensions tmp = (SaveDimensions)reader.Deserialize(file);
                GetInstance().ListWindows = tmp.ListWindows;

                file.Close();
            }
        }

        /// <summary>
        /// Permet de rechercher une fenetre dans la liste des fenetres de l'application par son nom.
        /// </summary>
        /// <param name="name">Le nom de la fenetre a rechercher.</param>
        /// <returns>La fenetre a rechercher.</returns>
        public Fenetre GetFenetreByName(String name)
        {
            foreach (Fenetre fenetre in ListWindows)
            {
                if (fenetre.Name.Equals(name))
                {
                    return fenetre;
                }
            }
            return null;
        }
    }
}
