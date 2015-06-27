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

        private int GetIdCoupe(ICoupe coupe)
        {
            return coupe.Id;
        }

        public ICollection<IMatch> GetMatchs()
        {
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

        private int GetIdMatch(IMatch match)
        {
            return match.Id;
        }

        public ICollection<IEquipe> GetEquipes()
        {
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

        private int GetIdEquipe(IEquipe equipe)
        {
            return equipe.Id;
        }

        public ICollection<IJoueur> GetJoueurs()
        {
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

        private int GetIdJoueur(IJoueur joueur)
        {
            return joueur.Id;
        }

        private PosteJoueur GetPosteJoueur(int idPoste)
        {
            return (PosteJoueur)idPoste;
        }

        public ICollection<IStade> GetStades()
        {
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

        private int GetIdStade(IStade stade)
        {
            return stade.Id;
        }

        public ICollection<IReservation> GetReservations()
        {
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

        private int GetIdReservation(IReservation reservation)
        {
            return reservation.Id;
        }

        public ICollection<IArbitre> GetArbitres()
        {
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

        private int GetIdArbitre(IArbitre arbitre)
        {
            return arbitre.Id;
        }

        public ICollection<ISpectateur> GetSpectateurs()
        {
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

        private int GetIdSpectateur(ISpectateur spectateur)
        {
            return spectateur.Id;
        }

        // Manque suppression des lignes
        public void UpdateMatch(ICollection<IMatch> matchs)
        {
            ICollection<int> alreadyPut = new List<int>();
            DataTable database = SelectByDataAdapter("SELECT * FROM Match");
            foreach (IMatch match in matchs) {
                DataRow[] row = database.Select("Id = '" + match.Id + "'");
                if (row != null && !alreadyPut.Contains(match.Id) )
                {
                    row[0]["Date"] = match.Date;
                    row[0]["IdCoupe"] = GetIdCoupe(match.Coupe);
                    row[0]["IdEquipeDomicile"] = GetIdEquipe(match.EquipeDomicile);
                    row[0]["IdEquipeVisiteur"] = GetIdEquipe(match.EquipeVisiteur);
                    row[0]["Prix"] = match.Prix;
                    row[0]["IdStade"] = GetIdStade(match.Stade);
                    row[0]["IdArbitre"] = GetIdArbitre(match.Arbitre);
                    row[0]["ScoreEquipeDomicile"] = match.ScoreEquipeDomicile;
                    row[0]["ScoreEquipeVisiteur"] = match.ScoreEquipeVisiteur;
                    alreadyPut.Add(match.Id);
                }
                else
                {
                    DataRow rowAdd = database.NewRow();
                    int id = alreadyPut.Max() + 1;
                    alreadyPut.Add(id);
                    rowAdd["Id"] = id;
                    rowAdd["Date"] = match.Date;
                    rowAdd["IdCoupe"] = GetIdCoupe(match.Coupe);
                    rowAdd["IdEquipeDomicile"] = GetIdEquipe(match.EquipeDomicile);
                    rowAdd["IdEquipeVisiteur"] = GetIdEquipe(match.EquipeVisiteur);
                    rowAdd["Prix"] = match.Prix;
                    rowAdd["IdStade"] = GetIdStade(match.Stade);
                    rowAdd["IdArbitre"] = GetIdArbitre(match.Arbitre);
                    rowAdd["ScoreEquipeDomicile"] = match.ScoreEquipeDomicile;
                    rowAdd["ScoreEquipeVisiteur"] = match.ScoreEquipeVisiteur;
                    database.Rows.Add(rowAdd);
                }
            }
            int res = UpdateByCommandBuilder("SELECT * FROM Match", database);
        }

        public void AddReservation(int id, int idMatch, int place, int idSpectateur)
        {
            DataTable database = SelectByDataAdapter("SELECT * FROM Reservation");
            DataRow row = database.NewRow();
            row["Id"] = id;
            row["IdMatch"] = idMatch;
            row["Place"] = place;
            row["IdSpectateur"] = idSpectateur;
            database.Rows.Add(row);
            int res = UpdateByCommandBuilder("SELECT * FROM Reservation", database);
        }

        public void DeleteReservation(IReservation reservation)
        {
            DataTable database = SelectByDataAdapter("SELECT * FROM Reservation");
            DataRow[] rowToSuppress = database.Select("Id = '" + reservation.Id + "'");
            rowToSuppress[0].Delete();
            int res = UpdateByCommandBuilder("SELECT * FROM Reservation", database);
        }

        private DataTable SelectByDataAdapter(string request)
        {
            DataTable results = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(results);
            }
            return results;
        }

        private int UpdateByCommandBuilder(string request, DataTable matchs)
        {
            int result = 0;
            using (SqlConnection sqlConnection = new SqlConnection(ConnexionString))
            {
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                SqlCommandBuilder sqlCommandBuider = new SqlCommandBuilder(sqlDataAdapter);
                sqlDataAdapter.UpdateCommand = sqlCommandBuider.GetUpdateCommand();
                sqlDataAdapter.InsertCommand = sqlCommandBuider.GetInsertCommand();
                sqlDataAdapter.DeleteCommand = sqlCommandBuider.GetDeleteCommand();
                sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                result = sqlDataAdapter.Update(matchs);
            }
            return result;
        }
    }
}
