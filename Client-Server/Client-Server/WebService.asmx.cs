using System;
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
                        command.Parameters.AddWithValue("@IBAN", iban);
                        command.Parameters.AddWithValue("@Nume", nume);
                        command.Parameters.AddWithValue("@Prenume", prenume);
                        command.Parameters.AddWithValue("@CNP", cnp);
                        command.Parameters.AddWithValue("@Telefon", telefon);
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
            string query = @"UPDATE User 
                     SET nume = @Nume, 
                         prenume = @Prenume, 
                         telefon = @Telefon, 
                     WHERE id_user = @IDUser";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nume", nume);
                        command.Parameters.AddWithValue("@Prenume", prenume);
                        command.Parameters.AddWithValue("@Telefon", telefon);
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
        public int CautareUser( string iban, string nume, string prenume, string cnp )
        {
            string query = @"SELECT id_user FROM User 
                     WHERE iban = @IBAN 
                     OR nume = @Nume 
                     OR prenume = @Prenume 
                     OR cnp = @CNP";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IBAN", iban);
                        command.Parameters.AddWithValue("@Nume", nume);
                        command.Parameters.AddWithValue("@Prenume", prenume);
                        command.Parameters.AddWithValue("@CNP", cnp);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            int idUser = Convert.ToInt32(result);
                            Console.WriteLine("Utilizatorul a fost găsit în baza de date. ID-ul utilizatorului: " + idUser);
                            return idUser;
                        }
                        else
                        {
                            Console.WriteLine("Nu s-au găsit înregistrări pentru utilizatorul căutat.");
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
                        command.Parameters.AddWithValue("@CodValutar", cod_valutar);
                        command.Parameters.AddWithValue("@Denumire", denumire);
                        command.Parameters.AddWithValue("@Simbol", simbol);
                        command.Parameters.AddWithValue("@Tara", tara);
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
        public int CautareValuta( string cod_valutar, string denumire, string simbol, string tara )
        {
            string query = @"SELECT id_valuta FROM Valute 
                     WHERE cod_valutar = @CodValutar 
                     OR denumire = @Denumire 
                     OR simbol = @Simbol 
                     OR tara = @Tara";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CodValutar", cod_valutar);
                        command.Parameters.AddWithValue("@Denumire", denumire);
                        command.Parameters.AddWithValue("@Simbol", simbol);
                        command.Parameters.AddWithValue("@Tara", tara);

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

    }
}
