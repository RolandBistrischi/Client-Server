using System;

namespace Client_Server
{
    public class Tranzactii
    {
        public int IdTranzactie
        {
            get; set;
        }
        public int IdUserSursa
        {
            get; set;
        }
        public int IdUserDestinatie
        {
            get; set;
        }
        public int IdValuta
        {
            get; set;
        }
        public decimal Suma
        {
            get; set;
        }
        public DateTime DataTranzactie
        {
            get; set;
        }
        public string StareTranzactie
        {
            get; set;
        }
        
        public Tranzactii()
        {
        }
        public Tranzactii( int id_tranzactie, int id_user_sursa, int id_user_destinatie, int id_valuta,
            decimal suma, DateTime data_tranzactie, string stare_tranzactie )
        {
            IdTranzactie = id_tranzactie;
            IdUserSursa = id_user_sursa;
            IdUserDestinatie = id_user_destinatie;
            IdValuta = id_valuta;
            Suma = suma;
            DataTranzactie = data_tranzactie;
            StareTranzactie = stare_tranzactie;
        }
    }
}