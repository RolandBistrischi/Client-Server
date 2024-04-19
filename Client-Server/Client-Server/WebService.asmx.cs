using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Services;

namespace Client_Server
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        private readonly string connectionString = "Data Source=DESKTOP-6ICN792;Initial Catalog = BancaDatabase; Integrated Security = True";
        [WebMethod]
        public void AdugareUser( decimal sold, string iban, string nume, string prenume,
        string cnp, string telefon, DateTime data_creare, int id_valuta )
        {
            if (id_valuta < 0)
                return;

            string query = @"INSERT INTO Useri (sold, iban, nume, prenume, cnp, telefon, data_creare, id_valuta)
                    VALUES (@Sold, @IBAN, @Nume, @Prenume, @CNP, @Telefon, @DataCreare, @IDValuta)";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Sold", sold);
                        command.Parameters.AddWithValue("@IBAN", iban.Trim());
                        command.Parameters.AddWithValue("@Nume", nume.Trim());
                        command.Parameters.AddWithValue("@Prenume", prenume.Trim());
                        command.Parameters.AddWithValue("@CNP", cnp.Trim());
                        command.Parameters.AddWithValue("@Telefon", telefon.Trim());
                        command.Parameters.AddWithValue("@DataCreare", data_creare);
                        command.Parameters.AddWithValue("@IDValuta", id_valuta);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Utilizatorul a fost adăugat în baza de date.");
                        }
                        else
                        {
                            Console.WriteLine("Nu s-a putut adăuga utilizatorul în baza de date.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o excepție: " + ex.Message);
            }
        }

        [WebMethod]
        public void ModificaUser( int id_user, string nume, string prenume, string telefon )
        {
            string query = @"UPDATE Useri 
                     SET nume = @Nume, 
                         prenume = @Prenume, 
                         telefon = @Telefon 
                     WHERE id_user = @IDUser";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nume", nume.Trim());
                        command.Parameters.AddWithValue("@Prenume", prenume.Trim());
                        command.Parameters.AddWithValue("@Telefon", telefon.Trim());
                        command.Parameters.AddWithValue("@IDUser", id_user);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Datele utilizatorului au fost actualizate în baza de date.");
                        }
                        else
                        {
                            Console.WriteLine("Nu s-au găsit înregistrări pentru utilizatorul cu ID-ul specificat.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o excepție: " + ex.Message);
            }
        }

        [WebMethod]
        public Utilizator CautareUser( string cnp )
        {
            string query = @"SELECT id_user, nume, prenume, telefon, cnp FROM Useri WHERE cnp = @CNP";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CNP", cnp.Trim());
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            Utilizator utilizator = new Utilizator
                            {
                                IdUser = Convert.ToInt32(reader ["id_user"]),
                                Nume = reader ["nume"].ToString(),
                                Prenume = reader ["prenume"].ToString(),
                                Telefon = reader ["telefon"].ToString(),
                                Cnp = reader ["cnp"].ToString()
                            };

                            // Returnează obiectul Utilizator
                            return utilizator;
                        }
                        else
                        {
                            Console.WriteLine("Nu s-au găsit înregistrări pentru utilizatorul căutat.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o excepție: " + ex.Message);
            }

            return null;
        }

        [WebMethod]
        public void AdugareValuta( string cod_valutar, string denumire, string simbol,
            string tara, double curs_de_schimb )
        {
            string query = @"INSERT INTO Valute (cod_valutar, denumire, simbol, tara, curs_de_schimb)
                     VALUES (@CodValutar, @Denumire, @Simbol, @Tara, @CursDeSchimb)";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CodValutar", cod_valutar.Trim());
                        command.Parameters.AddWithValue("@Denumire", denumire.Trim());
                        command.Parameters.AddWithValue("@Simbol", simbol.Trim());
                        command.Parameters.AddWithValue("@Tara", tara.Trim());
                        command.Parameters.AddWithValue("@CursDeSchimb", curs_de_schimb);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Valuta a fost adăugată în baza de date.");
                        }
                        else
                        {
                            Console.WriteLine("Nu s-a putut adăuga valuta în baza de date.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o excepție: " + ex.Message);
            }
        }


        [WebMethod]
        public int CautareValuta( string denumire, string simbol )
        {
            string query = @"SELECT id_valuta FROM Valute  WHERE 
                     denumire = @Denumire 
                     AND simbol = @Simbol ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Denumire", denumire.Trim());
                        command.Parameters.AddWithValue("@Simbol", simbol.Trim());

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            int idvaluta = Convert.ToInt32(result);
                            Console.WriteLine("Valuta a fost găsita în baza de date. ID-ul valutei: " + idvaluta);
                            return idvaluta;
                        }
                        else
                        {
                            Console.WriteLine("Nu s-au găsit înregistrări pentru valuta căutată.");
                        }
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o excepție: " + ex.Message);
                return -1;
            }
        }

        [WebMethod]
        public List<string> ToateValutele()
        {
            List<string> valute = new List<string>();
            string query = @"SELECT denumire, simbol FROM Valute";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string valutaInfo = reader ["Denumire"] + " ( " + reader ["Simbol"] + " )";

                            valute.Add(valutaInfo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o eroare la extragerea valutelor: " + ex.Message);
            }

            return valute;
        }

    }
}
