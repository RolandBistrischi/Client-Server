using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace CurrencyUpdater
{
    class Program
    {
        private static readonly string connectionString = "Data Source=DESKTOP-6ICN792;Initial Catalog=BancaDatabase;Integrated Security=True";
        private static readonly string apiEndpoint = "https://api.exchangeratesapi.io/latest"; // Înlocuiește cu endpoint-ul API-ului tău

        static async Task Main(string[] args)
        {
            await UpdateCurrencyRates();
        }

        public static async Task UpdateCurrencyRates()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiEndpoint);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject data = JObject.Parse(responseBody);

                    string baseCurrency = data["base"].ToString();
                    JObject rates = (JObject)data["rates"];

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        foreach (var rate in rates)
                        {
                            string currency = rate.Key;
                            decimal exchangeRate = rate.Value.ToObject<decimal>();

                            string query = @"
                                IF EXISTS (SELECT 1 FROM Valute WHERE cod_valutar = @CodValutar)
                                BEGIN
                                    UPDATE Valute SET curs_de_schimb = @CursDeSchimb WHERE cod_valutar = @CodValutar
                                END
                                ELSE
                                BEGIN
                                    INSERT INTO Valute (cod_valutar, curs_de_schimb) VALUES (@CodValutar, @CursDeSchimb)
                                END";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@CodValutar", currency);
                                command.Parameters.AddWithValue("@CursDeSchimb", exchangeRate);
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    Console.WriteLine("Cursurile valutare au fost actualizate cu succes.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A apărut o eroare la actualizarea cursurilor valutare: " + ex.Message);
            }
        }
    }
}
