using Domein;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistentie
{
    public class PlannerRepository : IPlannerRepository
    {

        private string _connectionString;

        public PlannerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Planner> GeefAllePlanningen(int idVanGebruiker)
        {
            List<Planner> output = new List<Planner>();

            SqlConnection connection = new SqlConnection(_connectionString);
            
            string query = "SELECT * FROM Planning WHERE gebruiker_id = @getal;";

            using (SqlCommand cmd = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@getal", idVanGebruiker);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        int gebruikerId = (int)reader["gebruiker_id"];
                        string evenementId = (string)reader["evenement_id"];

                        Planner p = new Planner(id, gebruikerId, evenementId);
                        output.Add(p);

                    }

                    return output;

                }
                catch (Exception exception)
                {

                    throw new PlannerRepositoryException("PlannerRepository - GeefAllePlanningen", exception);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void VoegPlanning(Planner pr)
        {

            SqlConnection connection = new SqlConnection(_connectionString);

            string query = "insert into Planning(gebruiker_id, evenement_id) values(@gebruiker_id, @evenement_id);";

            using (SqlCommand cmd = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@gebruiker_id", pr.GebruikerId);
                    cmd.Parameters.AddWithValue("@evenement_id", pr.EvenementId);

                    cmd.ExecuteNonQuery();
                    
                }
                catch (Exception exception)
                {

                    throw new PlannerRepositoryException("PlannerRepository - GeefAllePlanningen", exception);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void VerwijderPlanning(Planner pr)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "DELETE FROM Planning WHERE id = @id;";

            using (SqlCommand cmd = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@id", pr.Id);

                    cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {

                    throw new PlannerRepositoryException("PlanneRepository - VerwijderPlanning", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
