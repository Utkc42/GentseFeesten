using Domein;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistentie
{
    public class EvenementRepository : IEvenementRepository
    {
        private string _connectionString;

        public EvenementRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Evenement> GeefAlleEvenementen()
        {
            List<Evenement> output = new List<Evenement>();

            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Evenementen;";

            using (SqlCommand cmd = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    cmd.CommandText = query;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string id = (string)reader["id"];
                        DateTime eindDatum = (DateTime)reader["einddatum"];
                        DateTime startDatum = (DateTime)reader["startdatum"];
                        string kinderEvenementenString = (string)reader["kinder_evenement"];
                        string[] kinderEvenementen = kinderEvenementenString.Split(',');
                        string idParent = (string)reader["id_parent"];
                        string beschrijving = (string)reader["beschrijving"];
                        string naam = (string)reader["naam"];
                        int prijs = (int)reader["prijs"];



                        Evenement e = new Evenement(id, eindDatum, startDatum, kinderEvenementen, idParent, beschrijving, naam, prijs);
                        output.Add(e);

                    }

                    return output;

                }
                catch (Exception ex)
                {

                    throw new EvenementRepositoryException("EvenementRepository - GeefAlleEvenementen", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }



        public List<Evenement> GeefBijEvenementen(Evenement parent)
        {
            List<Evenement> output = new List<Evenement>();

            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Evenementen where id_parent = @parentid;";

            using (SqlCommand cmd = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    cmd.CommandText = query;

                    cmd.Parameters.AddWithValue("@parentid", parent.Id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string id = (string)reader["id"];
                        DateTime eindDatum = (DateTime)reader["einddatum"];
                        DateTime startDatum = (DateTime)reader["startdatum"];
                        string kinderEvenementenString = (string)reader["kinder_evenement"];
                        string[] kinderEvenementen = kinderEvenementenString.Split(',');
                        string idParent = (string)reader["id_parent"];
                        string beschrijving = (string)reader["beschrijving"];
                        string naam = (string)reader["naam"];
                        int prijs = (int)reader["prijs"];



                        Evenement e = new Evenement(id, eindDatum, startDatum, kinderEvenementen, idParent, beschrijving, naam, prijs);
                        output.Add(e);

                    }

                    return output;

                }
                catch (Exception ex)
                {

                    throw new EvenementRepositoryException("EvenementRepository - GeefBijEvenementen", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<Evenement> GeefTopLevelEvenementen()
        {
            List<Evenement> output = new List<Evenement>();

            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Evenementen where id_parent IS NULL;";

            using (SqlCommand cmd = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    cmd.CommandText = query;


                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string id;
                        DateTime? eindDatum;
                        DateTime? startDatum;
                        string kinderEvenementenString;
                        string idParent;
                        string beschrijving;
                        string naam;
                        int? prijs;

                        id = (string)reader["id"];
                        if (!(reader["einddatum"] is DBNull))
                        {
                            eindDatum = (DateTime)reader["einddatum"];

                        }
                        else
                        {
                            eindDatum = null;
                        }

                        if (!(reader["startdatum"] is DBNull))
                        {
                            startDatum = (DateTime)reader["startdatum"];


                        }
                        else
                        {
                            startDatum = null;
                        }

                        if (!(reader["kinder_evenement"] is DBNull))
                        {
                            kinderEvenementenString = (string)reader["kinder_evenement"];
    

                        }
                        else
                        {
                            kinderEvenementenString = null;
                        }

                        if (!(reader["id_parent"] is DBNull))
                        {
                            idParent = (string)reader["id_parent"];


                        }
                        else
                        {
                            idParent = null;
                        }

                        string[] kinderEvenementen = kinderEvenementenString.Split(',');
                        if (!(reader["beschrijving"] is DBNull))
                        {
                            beschrijving = (string)reader["beschrijving"];


                        }
                        else
                        {
                            beschrijving = null;
                        }

                        naam = (string)reader["naam"];
                        if (!(reader["prijs"] is DBNull))
                        {
                            prijs = (int)reader["prijs"];
                        }
                        else
                        {
                            prijs = null;
                        }



                        Evenement e = new Evenement(id, eindDatum, startDatum, kinderEvenementen, idParent, beschrijving, naam, prijs);
                        output.Add(e);

                    }

                    return output;

                }
                catch (Exception ex)
                {

                    throw new EvenementRepositoryException("EvenementRepository - GeefTopLevelEvenementen", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void VerwijderEvenement(Evenement evenement)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "DELETE FROM Evenementen WHERE id = @id;";

            using (SqlCommand cmd = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@id", evenement.Id);

                    cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {

                    throw new EvenementRepositoryException("EvenementRepository - VerwijderEvenement", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void VoegEvenementToe(Evenement evenement)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            string query = "INSERT INTO Evenementen(id,einddatum,startdatum,kinder_evenement,id_parent,beschrijving,naam,prijs) VALUES (@id, @einddatum, @startdatum, @kinder_evenement, @id_parent, @beschrijving, @naam, @prijs);";

            using (SqlCommand cmd = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@id", evenement.Id);
                    cmd.Parameters.AddWithValue("@einddatum", evenement.EindDatum);
                    cmd.Parameters.AddWithValue("@startdatum", evenement.StartDatum);
                    string kinderEvenementenString = String.Join(",", evenement.kinderEvenementenIds.ToArray());
                    cmd.Parameters.AddWithValue("@kinder_evenement", kinderEvenementenString);
                    cmd.Parameters.AddWithValue("@id_parent", evenement.ParentId);
                    cmd.Parameters.AddWithValue("@beschrijving", evenement.Beschrijving);
                    cmd.Parameters.AddWithValue("@naam", evenement.Naam);
                    cmd.Parameters.AddWithValue("@prijs", evenement.Prijs);

                    cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {

                    throw new EvenementRepositoryException("EvenementRepository - VoegEvenementToe", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
