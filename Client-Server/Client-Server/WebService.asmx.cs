using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using ExchangeRate_API;

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

        //private readonly Timer _timer;
        private API_Obj valuteActualizate;
        private List<Valute> valuteExistente;


        public WebService()
        {
        }

        [WebMethod]
        public bool AdugareUser( Utilizator utilizator )
        {
            if (utilizator == null || utilizator.IdValuta < 0)
                return false;
            if (CautareUser(utilizator.Cnp) != null)
                return false;

            string query = @"INSERT INTO Useri (sold, iban, nume, prenume, cnp, telefon, data_creare, id_valuta)
                    VALUES (@Sold, @IBAN, @Nume, @Prenume, @CNP, @Telefon, @DataCreare, @IDValuta)";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Sold", utilizator.Sold);
                        command.Parameters.AddWithValue("@IBAN", utilizator.Iban.Trim());
                        command.Parameters.AddWithValue("@Nume", utilizator.Nume.Trim());
                        command.Parameters.AddWithValue("@Prenume", utilizator.Prenume.Trim());
                        command.Parameters.AddWithValue("@CNP", utilizator.Cnp.Trim());
                        command.Parameters.AddWithValue("@Telefon", utilizator.Telefon.Trim());
                        command.Parameters.AddWithValue("@DataCreare", utilizator.DataCreare);
                        command.Parameters.AddWithValue("@IDValuta", utilizator.IdValuta);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Utilizatorul a fost adăugat în baza de date.");
                            return true;
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
            return false;
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
            if (string.IsNullOrWhiteSpace(cnp))
                return null;

            Utilizator utilizator = null;
            string query = @"SELECT id_user, nume, prenume, telefon, cnp, sold, iban, id_valuta FROM Useri WHERE cnp = @CNP";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CNP", cnp.Trim());
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                utilizator = new Utilizator()
                                {
                                    IdUser = Convert.ToInt32(reader ["id_user"]),
                                    Nume = reader ["nume"].ToString(),
                                    Prenume = reader ["prenume"].ToString(),
                                    Telefon = reader ["telefon"].ToString(),
                                    Cnp = reader ["cnp"].ToString(),
                                    Iban = reader ["iban"].ToString(),
                                    Sold = Convert.ToDecimal(reader ["sold"]),
                                    IdValuta = Convert.ToInt32(reader ["id_valuta"]),
                                };
                            }
                            else
                            {
                                Console.WriteLine("Nu s-au găsit înregistrări pentru utilizatorul căutat.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o excepție: " + ex.Message);
            }

            return utilizator;
        }

        [WebMethod]
        public void AdugareValuta( Valute valuta )
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
                        command.Parameters.AddWithValue("@CodValutar", valuta.CodValutar.Trim());
                        command.Parameters.AddWithValue("@Denumire", valuta.Denumire.Trim());
                        command.Parameters.AddWithValue("@Simbol", valuta.Simbol.Trim());
                        command.Parameters.AddWithValue("@Tara", valuta.Tara.Trim());
                        command.Parameters.AddWithValue("@CursDeSchimb", valuta.CursdeSchimb);

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
        public bool IsIBANinDataBase( string iban )
        {
            if (string.IsNullOrWhiteSpace(iban))
                return false;

            string query = "SELECT COUNT(1) FROM Useri WHERE iban = @IBAN";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IBAN", iban.Trim());
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o excepție: " + ex.Message);
                return false;
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

        [WebMethod]
        public int GetUserIdbyIban( string iban )
        {
            if (string.IsNullOrWhiteSpace(iban.Trim()))
                return -1;

            string query = "SELECT id_user FROM Useri WHERE iban = @IBAN";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IBAN", iban.Trim());
                        int id = Convert.ToInt32(command.ExecuteScalar());

                        return id;
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
        public Utilizator GetUtilizatorByIban( string iban )
        {
            if (string.IsNullOrWhiteSpace(iban.Trim()))
                return null;

            string query = "SELECT * FROM Useri WHERE iban = @IBAN";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IBAN", iban.Trim());

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Utilizator utilizator = new Utilizator
                                {
                                    IdUser = Convert.ToInt32(reader ["id_user"]),
                                    Sold = reader ["sold"] != DBNull.Value ? Convert.ToDecimal(reader ["sold"]) : 0,
                                    Iban = iban,
                                    Nume = reader ["nume"].ToString(),
                                    Prenume = reader ["prenume"].ToString(),
                                    Cnp = reader ["cnp"].ToString(),
                                    Telefon = reader ["telefon"].ToString(),
                                    DataCreare = Convert.ToDateTime(reader ["data_creare"]),
                                    IdValuta = Convert.ToInt32(reader ["id_valuta"]),
                                };

                                return utilizator;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o excepție: " + ex.Message);
                return null;
            }
            return null;
        }

        [WebMethod]
        public bool Tranzactie( Utilizator utilizator, string iban, decimal pret )
        {
            Utilizator utilizator_destinatie = GetUtilizatorByIban(iban);

            if (utilizator == null || utilizator_destinatie == null)
                return false;

            if (utilizator.IdUser <= 0 || utilizator_destinatie.IdUser <= 0)
                return false;

            if (utilizator.Sold < pret || pret <= 0)
                return false;

            try
            {

                // Obține rata de schimb valutar între valuta utilizatorului sursă și valuta utilizatorului destinatar
                decimal rataDeSchimb = GetExchangeRate(utilizator.IdValuta, utilizator_destinatie.IdValuta);
                if (rataDeSchimb <= 0)
                {
                    return false;
                }

                // Calculează echivalentul sumei trimise în valuta utilizatorului destinatar
                decimal sumaInValutaDestinatar = pret * rataDeSchimb;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string insertQuery = "INSERT INTO Tranzactii (Id_user_sursa, Id_user_destinatie, Id_valuta, suma, data_tranzactie, stare_tranzactie) VALUES (@id_user_sursa, @id_user_destinatie, @id_valuta, @suma, GETDATE(), 'In curs')";
                            using (SqlCommand command = new SqlCommand(insertQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@id_user_sursa", utilizator.IdUser);
                                command.Parameters.AddWithValue("@id_user_destinatie", utilizator_destinatie.IdUser);
                                command.Parameters.AddWithValue("@id_valuta", utilizator_destinatie.IdValuta);
                                command.Parameters.AddWithValue("@suma", sumaInValutaDestinatar);
                                command.ExecuteNonQuery();
                            }

                            // Actualizează soldul utilizatorului sursă
                            decimal newSoldSursa = utilizator.Sold - pret;
                            string updateQuerySursa = "UPDATE Useri SET sold = @sold WHERE id_user = @id";
                            using (SqlCommand command = new SqlCommand(updateQuerySursa, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@sold", newSoldSursa);
                                command.Parameters.AddWithValue("@id", utilizator.IdUser);
                                command.ExecuteNonQuery();
                            }

                            // Actualizează soldul utilizatorului destinatar
                            string updateQueryDestinatie = "UPDATE Useri SET sold = sold + @suma WHERE id_user = @id";
                            using (SqlCommand command = new SqlCommand(updateQueryDestinatie, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@suma", sumaInValutaDestinatar);
                                command.Parameters.AddWithValue("@id", utilizator_destinatie.IdUser);
                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return false;
        }

        [WebMethod]
        public decimal GetExchangeRate( int idValuta1, int idValuta2 )
        {
            try
            {
                decimal cursValuta1 = GetCursValutarById(idValuta1);
                decimal cursValuta2 = GetCursValutarById(idValuta2);

                if (cursValuta1 <= 0 || cursValuta2 <= 0)
                    throw new Exception("Cursul valutar pentru una dintre valute nu a fost găsit.");

                return cursValuta1 / cursValuta2;
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o excepție: " + ex.Message);
                return -1;
            }
        }
        private decimal GetCursValutarById( int idValuta )
        {
            string query = "SELECT curs_de_schimb FROM Valute WHERE id_valuta = @IdValuta";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdValuta", idValuta);
                        object result = command.ExecuteScalar();
                        if (result != null && decimal.TryParse(result.ToString(), out decimal cursValutar))
                        {
                            return cursValutar;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o excepție: " + ex.Message);
                return -1;
            }
        }


        private string GetConnectionString()
        {
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            string computerName = Environment.MachineName;

            foreach (ConnectionStringSettings connectionString in connectionStrings)
            {
                // Verifică dacă connection string-ul conține numele calculatorului
                if (connectionString.ConnectionString.Contains(computerName))
                {
                    // Aici ai găsit connection string-ul potrivit pentru calculatorul curent
                    //Console.WriteLine(connectionString.ConnectionString);
                    return connectionString.ConnectionString;

                    // Poți folosi connectionName și connectionValue aici în funcție de necesități
                    // De exemplu, poți utiliza connectionValue pentru a crea o conexiune la baza de date
                    // break; // Ieși din iterație după ce ai găsit connection string-ul potrivit
                }
            }

            //  return ConfigurationManager.ConnectionStrings [connectionName].ConnectionString;
            throw new Exception("Nu s-a găsit niciun connection string potrivit pentru acest calculator.");
        }



        [WebMethod]
        public decimal GetValoareValuta( string denumire )
        {
            if (string.IsNullOrWhiteSpace(denumire))
                return -1;

            string query = "SELECT curs_de_schimb FROM Valute WHERE denumire = @Denumire";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Denumire", denumire.Trim());

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            decimal cursDeSchimb = Convert.ToDecimal(result);
                            return cursDeSchimb;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o excepție: " + ex.Message);
            }

            return -1;
        }

        [WebMethod]
        public void ActualizareCursValutar()
        {
            valuteActualizate = Rates.Import();
            if (valuteExistente == null)
                valuteExistente = ObtineValuteExistente();

            Dictionary<string, double> valuteList = valuteActualizate.GetConversionRate();

            if (valuteList == null || valuteExistente == null)
                throw new Exception("Nu am putut obtine valutele.");

            List<Valute> actualizare = new List<Valute>();

            foreach (KeyValuePair<string, double> valuta in valuteList)
            {
                Valute valutaExistenta = valuteExistente.Find(v => v.CodValutar == valuta.Key);

                if (valutaExistenta != null && valutaExistenta.CursdeSchimb != valuta.Value)
                {
                    valutaExistenta.CursdeSchimb = valuta.Value;
                    actualizare.Add(valutaExistenta);
                }
            }
            if (actualizare.Count == 0)
                return;
            UpdateCursValutar(actualizare);
        }

        private void UpdateCursValutar( string codValutar, double cursDeSchimb )
        {
            string query = "UPDATE Valute SET curs_de_schimb = @CursDeSchimb WHERE cod_valutar = @CodValutar";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CursDeSchimb", cursDeSchimb);
                        command.Parameters.AddWithValue("@CodValutar", codValutar.Trim());

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o excepție: " + ex.Message);
            }
        }
        private void UpdateCursValutar( List<Valute> actualizare )
        {
            string query = "UPDATE Valute SET curs_de_schimb = @CursDeSchimb WHERE cod_valutar = @CodValutar";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (Valute valuta in actualizare)
                        {
                            using (SqlCommand command = new SqlCommand(query, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@CursDeSchimb", valuta.CursdeSchimb);
                                command.Parameters.AddWithValue("@CodValutar", valuta.CodValutar);
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            valuteExistente = actualizare;
        }

        [WebMethod]
        public List<Valute> ObtineValuteExistente()
        {
            List<Valute> valute = new List<Valute>();
            string query = "SELECT * FROM Valute";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                valute.Add(new Valute
                                {
                                    IdValuta = Convert.ToInt32(reader ["id_valuta"]),
                                    CodValutar = reader ["cod_valutar"].ToString(),
                                    Denumire = reader ["denumire"].ToString(),
                                    Simbol = reader ["simbol"].ToString(),
                                    Tara = reader ["tara"].ToString(),
                                    CursdeSchimb = Convert.ToDouble(reader ["curs_de_schimb"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o excepție: " + ex.Message);
            }

            return valute;
        }

        [WebMethod]
        public bool UpdateValoareValuta( string cod_valutar, decimal nouaValoare )
        {
            if (string.IsNullOrWhiteSpace(cod_valutar) || nouaValoare <= 0)
            {
                return false;
            }

            string query = "UPDATE Valute SET curs_de_schimb = @NouaValoare WHERE cod_valutar = @Denumire";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NouaValoare", nouaValoare);
                        command.Parameters.AddWithValue("@Denumire", cod_valutar.Trim());

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Valoarea valutei a fost actualizată cu succes.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Nu s-au găsit înregistrări pentru valuta specificată.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o excepție: " + ex.Message);
            }

            return false;
        }


    }
}
