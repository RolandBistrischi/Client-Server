namespace Client_Server
{
    public class Valute
    {
        public int IdValuta
        {
            get; set;
        }
        public string CodValutar
        {
            get; set;
        }
        public string Denumire
        {
            get; set;
        }
        public string Simbol
        {
            get; set;
        }
        public string Tara
        {
            get; set;
        }
        public double CursdeSchimb
        {
            get; set;
        }


        public Valute()
        {
        }
        public Valute( int id_valuta, string cod_valutar, string denumire, string simbol,
            string tara, double curs_de_schimb )
        {
            IdValuta = id_valuta;
            CodValutar = cod_valutar;
            Denumire = denumire;
            Simbol = simbol;
            Tara = tara;
            CursdeSchimb = curs_de_schimb;
        }

    }
}