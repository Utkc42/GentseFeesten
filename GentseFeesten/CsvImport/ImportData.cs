using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Domein;
namespace CsvImport
{
    public class ImportData
    {
       
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=LAPTOP-UMGHNHQ1\SQLEXPRESS;Initial Catalog=GentseFeestenA;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Evenementen (id, einddatum, startdatum, kinder_evenement, id_parent, beschrijving, naam, prijs) VALUES (@id, @einddatum, @startdatum, @kinder_evenement, @id_parent, @beschrijving, @naam, @prijs);";
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@id", SqlDbType.VarChar);
                    cmd.Parameters.Add("@einddatum", SqlDbType.DateTime2);
                    cmd.Parameters.Add("@startdatum", SqlDbType.DateTime2);
                    cmd.Parameters.Add("@kinder_evenement", SqlDbType.VarChar);
                    cmd.Parameters.Add("@id_parent", SqlDbType.VarChar);
                    cmd.Parameters.Add("@beschrijving", SqlDbType.VarChar);
                    cmd.Parameters.Add("@naam", SqlDbType.VarChar);
                    cmd.Parameters.Add("@prijs", SqlDbType.Int);

                    string bestand = @"C:\tmp\gentse_feesten_evenementen.csv";
                    using (StreamReader reader = new StreamReader(bestand))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            string[] values = line.Split(';');
                            string id = values[0];
                            DateTime? einddatum;
                            if (string.IsNullOrWhiteSpace(values[1]))
                            {
                                einddatum = null;
                            }
                            else
                            {
                                einddatum = DateTime.Parse(values[1]);
                            }
                            DateTime? startdatum;
                            if (string.IsNullOrWhiteSpace(values[2]))
                            {
                                startdatum = null;
                            }
                            else
                            {
                                startdatum = DateTime.Parse(values[2]);
                            }
                            string kinder_evenement = values[3];
                            string id_parent = values[4];
                            string beschrijving = values[5];
                            string naam = values[6];
                            int? prijs;
                            if (string.IsNullOrWhiteSpace(values[7]))
                            {
                                prijs = null;
                            }
                            else
                            {

                                prijs = int.Parse(values[7]);
                            }



                            cmd.Parameters["@id"].Value = id;

                            if (einddatum == null)
                            {
                                cmd.Parameters["@einddatum"].Value = DBNull.Value;
                            }
                            else
                            {
                                cmd.Parameters["@einddatum"].Value = einddatum;
                            }

                            if (startdatum == null)
                            {
                                cmd.Parameters["@startdatum"].Value = DBNull.Value;
                            }
                            else
                            {
                                cmd.Parameters["@startdatum"].Value = startdatum;
                            }

                            if (string.IsNullOrWhiteSpace(kinder_evenement))
                            {
                                cmd.Parameters["@kinder_evenement"].Value = DBNull.Value;
                            }
                            else
                            {
                                cmd.Parameters["@kinder_evenement"].Value = kinder_evenement;
                            }

                            if (string.IsNullOrWhiteSpace(id_parent))
                            {
                                cmd.Parameters["@id_parent"].Value = DBNull.Value;
                            }
                            else
                            {
                                cmd.Parameters["@id_parent"].Value = id_parent;
                            }

                            if (string.IsNullOrWhiteSpace(beschrijving))
                            {
                                cmd.Parameters["@beschrijving"].Value = DBNull.Value;
                            }
                            else
                            {
                                cmd.Parameters["@beschrijving"].Value = beschrijving;
                            }

                            if (string.IsNullOrWhiteSpace(naam))
                            {
                                cmd.Parameters["@naam"].Value = DBNull.Value;
                            }
                            else
                            {
                                cmd.Parameters["@naam"].Value = naam;
                            }

                            if (prijs == null)
                            {
                                cmd.Parameters["@prijs"].Value = DBNull.Value;
                            }
                            else
                            {
                                cmd.Parameters["@prijs"].Value = prijs;
                            }

                            cmd.ExecuteNonQuery();
                        }

                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Fout bij het importeren");
                    
                }
                finally
                {
                    conn.Close();

                }
            }

            Console.WriteLine("Import complete");
            Console.ReadLine();
        }
    }
}