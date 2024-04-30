using System;

namespace Client_Server
{
    public class Utilizator
    {
        public int IdUser
        {
            get; set;
        }
        public string Nume
        {
            get; set;
        }
        public string Prenume
        {
            get; set;
        }
        public string Telefon
        {
            get; set;
        }
        public string Cnp
        {
            get; set;
        }
        public decimal Sold
        {
            get; set;
        }
        public string Iban
        {
            get; set;
        }
        public DateTime DataCreare
        {
            get; set;
        }
        public int IdValuta
        {
            get; set;
        }

        public Utilizator()
        {
        }
        public Utilizator( int Iduser, string nume, string prenume, string tel, string cnp,
            decimal sold, string iban, DateTime data_creare, int id_valuta )
        {
            IdUser = Iduser;
            Nume = nume;
            Prenume = prenume;
            Telefon = tel;
            Cnp = cnp;
            Sold = sold;
            Iban = iban;
            DataCreare = data_creare;
            IdValuta = id_valuta;
        }

    }
}