using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Classes;

namespace DataAccessLayer.Manager
{
    class StubDALManager : IDALManager
    {
        private ICollection<ICoupe> _coupes;
        private ICollection<IMatch> _matchs;
        private ICollection<IEquipe> _equipes;
        private ICollection<IJoueur> _joueurs;
        private ICollection<IStade> _stades;
        private ICollection<IReservation> _reservations;
        private ICollection<IArbitre> _arbitres;

        public ICollection<ICoupe> Coupes
        {
            get { return _coupes; }
            private set { _coupes = value; }
        }

        public ICollection<IMatch> Matchs
        {
            get { return _matchs; }
            private set { _matchs = value; }
        }

        public ICollection<IEquipe> Equipes
        {
            get { return _equipes; }
            private set { _equipes = value; }
        }

        public ICollection<IJoueur> Joueurs
        {
            get { return _joueurs; }
            private set { _joueurs = value; }
        }

        public ICollection<IStade> Stades
        {
            get { return _stades; }
            private set { _stades = value; }
        }

        public ICollection<IReservation> Reservations
        {
            get { return _reservations; }
            private set { _reservations = value; }
        }

        public ICollection<IArbitre> Arbitres
        {
            get { return _arbitres; }
            private set { _arbitres = value; }
        }


        public StubDALManager()
        {
            Coupes = new List<ICoupe>();
            Matchs = new List<IMatch>();
            Equipes = new List<IEquipe>();
            Joueurs = new List<IJoueur>();
            Stades = new List<IStade>();
            Reservations = new List<IReservation>();
            Arbitres = new List<IArbitre>();

            createData();
        }

        private void createData()
        {
            IJoueur j1 = new Joueur(1, "Potter", "Harry", new DateTime(2014, 1, 18), "01", PosteJoueur.Gardien, false);
            IJoueur j2 = new Joueur(2, "Weasley", "Ronald", new DateTime(2004, 1, 18), "02", PosteJoueur.Poursuiveur, false);
            IJoueur j3 = new Joueur(3, "Granger", "Hermione", new DateTime(1114, 1, 18), "03", PosteJoueur.Poursuiveur, true);
            IJoueur j4 = new Joueur(4, "Dumbledore", "Albus", new DateTime(2014, 1, 18), "04", PosteJoueur.Poursuiveur, false);
            IJoueur j5 = new Joueur(5, "Rogue", "Severus", new DateTime(2014, 1, 18), "05", PosteJoueur.Batteur, false);
            IJoueur j6 = new Joueur(6, "McGonagall", "Minerva", new DateTime(2014, 1, 18), "06", PosteJoueur.Batteur, false);
            IJoueur j7 = new Joueur(7, "Jedusor", "Tom", new DateTime(2014, 1, 18), "07", PosteJoueur.Attrapeur, false);
            IJoueur j8 = new Joueur(8, "Malfoy", "Draco", new DateTime(2014, 1, 18), "07", PosteJoueur.Attrapeur, false);
            IJoueur j9 = new Joueur(9, "Krum", "Viktor", new DateTime(1914, 1, 18), "01", PosteJoueur.Gardien, false);
            IJoueur j10 = new Joueur(10, "Weasley", "George", new DateTime(2014, 1, 18), "05", PosteJoueur.Batteur, false);
            IJoueur j11 = new Joueur(11, "Weasley", "Ginny", new DateTime(2014, 1, 18), "03", PosteJoueur.Poursuiveur, false);

            Joueurs.Add(j1);
            Joueurs.Add(j2);
            Joueurs.Add(j3);
            Joueurs.Add(j4);
            Joueurs.Add(j5);
            Joueurs.Add(j6);
            Joueurs.Add(j7);
            Joueurs.Add(j8);
            Joueurs.Add(j9);
            Joueurs.Add(j10);
            Joueurs.Add(j11);

            ICollection<IJoueur> equipeDom = new List<IJoueur>();
            ICollection<IJoueur> equipeVis = new List<IJoueur>();
            equipeDom.Add(j1);
            equipeDom.Add(j2);
            equipeDom.Add(j3);
            equipeDom.Add(j4);
            equipeDom.Add(j5);
            equipeDom.Add(j6);
            equipeDom.Add(j7);
            equipeVis.Add(j8);
            equipeVis.Add(j9);
            equipeVis.Add(j10);
            equipeVis.Add(j11);
            IEquipe equipe1 = new Equipe(1, "Gryffondor", "Angleterre", equipeDom);
            IEquipe equipe2 = new Equipe(2, "Serpentard", "Allemagne", equipeVis);
            Equipes.Add(equipe1);
            Equipes.Add(equipe2);

            IStade stade1 = new Stade(1, "Stade olympique", "Rue du sport", "Rome", 250);
            IStade stade2 = new Stade(2, "Stade de France", "Avenue sans nom", "Paris", 150);
            Stades.Add(stade1);
            Stades.Add(stade2);

            ICoupe coupeLast = new Coupe(1, "2014");
            ICoupe coupe = new Coupe(2, "2015");
            Coupes.Add(coupeLast);
            Coupes.Add(coupe);

            IArbitre arbitre = new Arbitre(1, "Bibine", "Germaine", new DateTime(1014, 1, 18), "156");
            Arbitres.Add(arbitre);

            IMatch match1 = new Match(1, new DateTime(2015, 1, 13), coupe, equipe1, equipe2, 15.45, stade1, arbitre, 300, 260);
            IMatch match2 = new Match(2, new DateTime(2015, 2, 18), coupe, equipe2, equipe1, 1500, stade2, arbitre, 450, 780);
            IMatch match3 = new Match(3, new DateTime(2015, 1, 2), coupe, equipe1, equipe2, 2400, stade1, arbitre, 700, 710);

            Matchs.Add(match1);
            Matchs.Add(match2);
            Matchs.Add(match3);

            Reservations.Add(new Reservation(1, match3, 1, new Spectateur(1, "Jean", "Claude", new DateTime(1995, 4, 21), "rue jean", "Paris", "fs.fd@fdfd.ds")));
            Reservations.Add(new Reservation(2, match3, 10, new Spectateur(2, "Jean", "Claude", new DateTime(1995, 4, 21), "rue jean", "Paris", "fs.fd@fdfd.ds")));
            Reservations.Add(new Reservation(3, match3, 100, new Spectateur(3, "Jean", "Claude", new DateTime(1995, 4, 21), "rue jean", "Paris", "fs.fd@fdfd.ds")));
            Reservations.Add(new Reservation(4, match3, 2, new Spectateur(4, "Jean", "Claude", new DateTime(1995, 4, 21), "rue jean", "Paris", "fs.fd@fdfd.ds")));
            Reservations.Add(new Reservation(5, match3, 20, new Spectateur(5, "Jean", "Claude", new DateTime(1995, 4, 21), "rue jean", "Paris", "fs.fd@fdfd.ds")));
            Reservations.Add(new Reservation(6, match3, 12, new Spectateur(6, "Jean", "Claude", new DateTime(1995, 4, 21), "rue jean", "Paris", "fs.fd@fdfd.ds")));
            Reservations.Add(new Reservation(7, match3, 19, new Spectateur(7, "Jean", "Claude", new DateTime(1995, 4, 21), "rue jean", "Paris", "fs.fd@fdfd.ds")));
        }
    }
}
