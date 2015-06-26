using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer.Manager;
using System.Collections.Generic;
using DataAccessLayer.Interfaces;

namespace UnitTestDatabase
{
    [TestClass]
    public class UnitTestDB
    {
        [TestMethod]
        public void TestCoupes()
        {
            DALProxy proxy = new DALProxy();
            ICollection<ICoupe> coupes = proxy.Manager.Coupes;
            Assert.IsNotNull(coupes);
        }

        [TestMethod]
        public void TestMatchs()
        {
            DALProxy proxy = new DALProxy();
            ICollection<IMatch> matchs = proxy.Manager.Matchs;
            Assert.IsNotNull(matchs);
        }

        [TestMethod]
        public void TestEquipes()
        {
            DALProxy proxy = new DALProxy();
            ICollection<IEquipe> equipes = proxy.Manager.Equipes;
            Assert.IsNotNull(equipes);
        }

        [TestMethod]
        public void TestJoueurs()
        {
            DALProxy proxy = new DALProxy();
            ICollection<IJoueur> joueurs = proxy.Manager.Joueurs;
            Assert.IsNotNull(joueurs);
        }

        [TestMethod]
        public void TestStades()
        {
            DALProxy proxy = new DALProxy();
            ICollection<IStade> stades = proxy.Manager.Stades;
            Assert.IsNotNull(stades);
        }

        [TestMethod]
        public void TestReseervations()
        {
            DALProxy proxy = new DALProxy();
            ICollection<IReservation> reservations = proxy.Manager.Reservations;
            Assert.IsNotNull(reservations);
        }

        [TestMethod]
        public void TestArbitres()
        {
            DALProxy proxy = new DALProxy();
            ICollection<IArbitre> arbitres = proxy.Manager.Arbitres;
            Assert.IsNotNull(arbitres);
        }

        [TestMethod]
        public void TestSpectateurs()
        {
            DALProxy proxy = new DALProxy();
            ICollection<ISpectateur> spectateurs = proxy.Manager.Spectateurs;
            Assert.IsNotNull(spectateurs);
        }
    }
}
