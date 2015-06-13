using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Classes;

namespace DataAccessLayer.Manager
{
    class SqlDB : Bridge
    {

        private string _connexionString;

        private string ConnexionString
        {
            get { return _connexionString; }
            set { _connexionString = value; }
        }

        public SqlDB()
        {
            ConnexionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Nicolas\Documents\Visual Studio 2013\Projects\QuidditchWorldCup\QuidditchDB.mdf;Integrated Security=True;Connect Timeout=30";
        }

        public ICollection<ICoupe> GetCoupes()
        {
            DataTable results = new DataTable();
            ICollection<ICoupe> coupes = new List<ICoupe>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Coupe", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    coupes.Add(new Coupe(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1)));
                }
            }
            return coupes;
        }

        private ICoupe GetCoupe(int idCoupe)
        {
            DataTable results = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                String request = "SELECT * FROM Coupe WHERE Id = " + idCoupe;
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    return new Coupe(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1));
                }
            }
            return null;
        }

        public ICollection<IMatch> GetMatchs()
        {
            DataTable results = new DataTable();
            ICollection<IMatch> matchs = new List<IMatch>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Match", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    matchs.Add(new Match(sqlDataReader.GetInt32(0), sqlDataReader.GetDateTime(1), GetCoupe(sqlDataReader.GetInt32(2)), GetEquipe(sqlDataReader.GetInt32(3)), GetEquipe(sqlDataReader.GetInt32(4)), Convert.ToDouble(sqlDataReader.GetDecimal(5)), GetStade(sqlDataReader.GetInt32(6)), GetArbitre(sqlDataReader.GetInt32(7)), sqlDataReader.GetInt32(8), sqlDataReader.GetInt32(9)));
                }
            }
            return matchs;
        }
        
        private IMatch GetMatch(int idMatch)
        {
            DataTable results = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                String request = "SELECT * FROM Match WHERE Id = " + idMatch;
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    return new Match(sqlDataReader.GetInt32(0), sqlDataReader.GetDateTime(1), GetCoupe(sqlDataReader.GetInt32(2)), GetEquipe(sqlDataReader.GetInt32(3)), GetEquipe(sqlDataReader.GetInt32(4)), Convert.ToDouble(sqlDataReader.GetDecimal(5)), GetStade(sqlDataReader.GetInt32(6)), GetArbitre(sqlDataReader.GetInt32(7)), sqlDataReader.GetInt32(8), sqlDataReader.GetInt32(9));
                }
            }
            return null;
        }

        public ICollection<IEquipe> GetEquipes()
        {
            DataTable results = new DataTable();
            ICollection<IEquipe> equipes = new List<IEquipe>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Equipe", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    equipes.Add(new Equipe(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), GetJoueusrByTeam(sqlDataReader.GetInt32(0))));
                }
            }
            return equipes;
        }

        private IEquipe GetEquipe(int idEquipe)
        {
            DataTable results = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                String request = "SELECT * FROM Equipe WHERE Id = " + idEquipe;
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    return new Equipe(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), GetJoueusrByTeam(sqlDataReader.GetInt32(0)));
                }
            }
            return null;
        }

        public ICollection<IJoueur> GetJoueurs()
        {
            DataTable results = new DataTable();
            ICollection<IJoueur> joueurs = new List<IJoueur>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Joueur", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    joueurs.Add(new Joueur(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetDateTime(3), sqlDataReader.GetString(4), GetPosteJoueur(sqlDataReader.GetByte(5)), Convert.ToBoolean(sqlDataReader.GetByte(6))));
                }
            }
            return joueurs;
        }

        private ICollection<IJoueur> GetJoueusrByTeam(int idEquipe)
        {
            DataTable results = new DataTable();
            ICollection<IJoueur> joueurs = new List<IJoueur>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                String request = "SELECT * FROM Joueur WHERE IdEquipe = " + idEquipe;
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    joueurs.Add(new Joueur(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetDateTime(3), sqlDataReader.GetString(4), GetPosteJoueur(sqlDataReader.GetByte(5)), Convert.ToBoolean(sqlDataReader.GetByte(6))));
                }
            }
            return joueurs;
        }

        private IJoueur GetJoueur(int idJoueur)
        {
            DataTable results = new DataTable(); 
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                String request = "SELECT * FROM Joueur WHERE Id = " + idJoueur;
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    return new Joueur(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetDateTime(3), sqlDataReader.GetString(4), GetPosteJoueur(sqlDataReader.GetByte(5)), Convert.ToBoolean(sqlDataReader.GetByte(6)));
                }
            }
            return null;
        }

        private PosteJoueur GetPosteJoueur(int idPoste)
        {
            return (PosteJoueur)idPoste;
        }

        public ICollection<IStade> GetStades()
        {
            DataTable results = new DataTable();
            ICollection<IStade> stades = new List<IStade>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Stade", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    stades.Add(new Stade(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetString(3), sqlDataReader.GetInt32(4)));
                }
            }
            return stades;
        }

        private IStade GetStade(int idStade)
        {
            DataTable results = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                String request = "SELECT * FROM Stade WHERE Id = " + idStade;
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    return new Stade(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetString(3), sqlDataReader.GetInt32(4));
                }
            }
            return null;
        }

        public ICollection<IReservation> GetReservations()
        {
            DataTable results = new DataTable();
            ICollection<IReservation> reservations = new List<IReservation>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Reservation", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    reservations.Add(new Reservation(sqlDataReader.GetInt32(0), GetMatch(sqlDataReader.GetInt32(1)), sqlDataReader.GetInt32(2), GetSpectateur(sqlDataReader.GetInt32(3))));
                }
            }
            return reservations;
        }
        
        private IReservation GetReservation(int idReservation)
        {
            DataTable results = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                String request = "SELECT * FROM Reservation WHERE Id = " + idReservation;
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    return new Reservation(sqlDataReader.GetInt32(0), GetMatch(sqlDataReader.GetInt32(1)), sqlDataReader.GetInt32(2), GetSpectateur(sqlDataReader.GetInt32(3)));
                }
            }
            return null;
        }

        public ICollection<IArbitre> GetArbitres()
        {
            DataTable results = new DataTable();
            ICollection<IArbitre> arbitres = new List<IArbitre>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Arbitre", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    arbitres.Add(new Arbitre(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetDateTime(3), sqlDataReader.GetString(4)));
                }
            }
            return arbitres;
        }

        private IArbitre GetArbitre(int idArbitre)
        {
            DataTable results = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                String request = "SELECT * FROM Arbitre WHERE Id = " + idArbitre;
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    return new Arbitre(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetDateTime(3), sqlDataReader.GetString(4));
                }
            }
            return null;
        }

        public ICollection<ISpectateur> GetSpectateurs()
        {
            DataTable results = new DataTable();
            ICollection<ISpectateur> spectateurs = new List<ISpectateur>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Spectateur", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    spectateurs.Add(new Spectateur(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetDateTime(3), sqlDataReader.GetString(4), sqlDataReader.GetString(5), sqlDataReader.GetString(6)));
                }
            }
            return spectateurs;
        }

        private ISpectateur GetSpectateur(int idSpectateur)
        {
            DataTable results = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                String request = "SELECT * FROM Spectateur WHERE Id = " + idSpectateur;
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    return new Spectateur(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetDateTime(3), sqlDataReader.GetString(4), sqlDataReader.GetString(5), sqlDataReader.GetString(6));
                }
            }
            return null;
        }
    }
}
