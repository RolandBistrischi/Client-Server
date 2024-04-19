using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Banca
{
    public partial class Form1 : Form
    {
        ServiceReference.Utilizator util;

        public Form1()
        {
            InitializeComponent();
            panelValute.Hide();
            AfisareValute();

        }
        private void Form1_Load( object sender, EventArgs e )
        {
            buttonCautadupaCNP.Hide();
        }
        private void valuteToolStripMenuItem_Click( object sender, EventArgs e )
        {
            panelValute.Show();
            panelUser.Hide();
        }

        private void userToolStripMenuItem_Click( object sender, EventArgs e )
        {
            panelUser.Show();
            panelValute.Hide();
            AfisareValute();
            buttonAdaugaUser.Text = "Adauga User";
            foreach (Control c in panelUser.Controls)
            {
                c.Show();
            }
            buttonCautadupaCNP.Hide();
        }
        private void modificaToolStripMenuItem_Click( object sender, EventArgs e )
        {
            panelUser.Show();
            panelValute.Hide();
            buttonAdaugaUser.Text = "Modifica User";
            foreach (Control c in panelUser.Controls)
            {
                c.Hide();
            }
            buttonCautadupaCNP.Show();
            labelCNP.Show();
            textBoxCNP.Show();

        }
        private void buttonAdaugaUser_Click( object sender, EventArgs e )
        {
            string nume = textBoxNume.Text.Trim();
            string prenume = textBoxPrenume.Text.Trim();
            string cnp = textBoxCNP.Text.Trim();
            string tel = textBoxTelefon.Text.Trim();
            string denumireValuta = null;
            string simbolValuta = null;
            if (string.IsNullOrEmpty(cnp))
            {
                MessageBox.Show("Introduceti cnp");
                return;
            }

            if (buttonAdaugaUser.Text == "Adauga User")
            {
                if (string.IsNullOrEmpty(nume) || string.IsNullOrEmpty(prenume) ||
                    string.IsNullOrEmpty(cnp) || string.IsNullOrEmpty(tel))
                {
                    MessageBox.Show("Introduceți date.");
                    return;
                }
                if (string.IsNullOrEmpty(textBoxSold.Text))
                {
                    MessageBox.Show("Introduceți sold.");
                    return;
                }

                if (!decimal.TryParse(textBoxSold.Text.Trim(), out decimal sold))
                {
                    MessageBox.Show("Introduceți un sold valid.");
                    return;
                }
                if (listBoxValute.SelectedIndex == -1)
                {
                    MessageBox.Show("Selectați o valută.");
                    return;
                }

                string Valuta = listBoxValute.SelectedItem.ToString();
                denumireValuta = Valuta.Substring(0, Valuta.IndexOf('('));
                simbolValuta = Valuta.Substring(Valuta.IndexOf('(') + 1, Valuta.IndexOf(')') - Valuta.IndexOf('(') - 1).Trim();

                DateTime data = DateTime.Now;
                ServiceReference.WebServiceSoapClient client = new ServiceReference.WebServiceSoapClient();
                int id_valuta = client.CautareValuta(denumireValuta, simbolValuta);
                client.AdugareUser(sold, RandomIban(), nume, prenume, cnp, tel, data, id_valuta);
                MessageBox.Show("Utilizator adaugat.");
                return;
            }

            if (buttonAdaugaUser.Text == "Modifica User" && util != null)
            {
                ServiceReference.WebServiceSoapClient client = new ServiceReference.WebServiceSoapClient();
                client.ModificaUser(util.IdUser, nume, prenume, tel);
                MessageBox.Show("Utilizator modificat cu succes.");
            }

        }

        private void buttonAdaugaValuta_Click( object sender, EventArgs e )
        {
            string cod_valuta = textBoxCod.Text.Trim();
            string denumire = textBoxDenumire.Text.Trim();
            string simbol = textBoxSimbol.Text.Trim();
            string tara = textBoxTara.Text.Trim();
            double curs_baza;

            if (string.IsNullOrEmpty(cod_valuta) || string.IsNullOrEmpty(denumire) ||
              string.IsNullOrEmpty(tara) || string.IsNullOrEmpty(simbol) ||
              string.IsNullOrEmpty(textBoxCursBaza.Text.Trim()) || !double.TryParse(textBoxCursBaza.Text.Trim(), out curs_baza) || curs_baza == 0)
            {
                MessageBox.Show("Introduceți toate datele, inclusiv un curs de bază valid diferit de zero.");
                return;
            }
            ServiceReference.WebServiceSoapClient client = new ServiceReference.WebServiceSoapClient();
            client.AdugareValuta(cod_valuta, denumire, simbol, tara, curs_baza);

            MessageBox.Show("Valuta adaugata cu succes");
        }



        private void AfisareValute()
        {
            listBoxValute.Items.Clear();
            ServiceReference.WebServiceSoapClient client = new ServiceReference.WebServiceSoapClient();
            List<string> valute = client.ToateValutele();
            foreach (string a in valute)
            {
                listBoxValute.Items.Add(a);
            }
        }

        private string RandomIban()
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 15; i++)
            {
                int index = random.Next(characters.Length);
                stringBuilder.Append(characters [index]);
            }

            return stringBuilder.ToString();
        }

        private void buttonCautadupaCNP_Click( object sender, EventArgs e )
        {
            string cnp = textBoxCNP.Text.Trim();

            if (string.IsNullOrEmpty(cnp))
            {
                MessageBox.Show("Pentru a putea cauta un utilizator trebuie introdus un cnp.");
                return;
            }

            ServiceReference.WebServiceSoapClient client = new ServiceReference.WebServiceSoapClient();
            util = client.CautareUser(cnp);

            if (util == null)
            {
                MessageBox.Show("Nu s-a gasit utilizatorul");
                return;
            }

            foreach (Control c in panelUser.Controls)
            {
                c.Show();
            }
            listBoxValute.Hide();
            labelSold.Hide();
            textBoxSold.Hide();

            buttonAdaugaUser.Show();
            textBoxNume.Text = util.Nume;
            textBoxPrenume.Text = util.Prenume;
            textBoxCNP.Text = util.Cnp;
            textBoxTelefon.Text = util.Telefon;
        }
    }
}
