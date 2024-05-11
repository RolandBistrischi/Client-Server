using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Banca
{
    public partial class FormUser : Form
    {
        ServiceReference.Utilizator utilizator_curent = null;
        private Tranzactie formTranzactie = null;

        public FormUser()
        {
            InitializeComponent();
            panelValute.Hide();
            AfisareValute();
        }
        public FormUser( ServiceReference.Utilizator utilizator )
        {
            InitializeComponent();
            utilizator_curent = utilizator;
            panelValute.Hide();
            AfisareValute();
        }
        private void FormUser_FormClosed( object sender, FormClosedEventArgs e )
        {
            Application.Exit();
        }
        private void Form2_Load( object sender, EventArgs e )
        {
            buttonCautadupaCNP.Hide();
            LoadUser(utilizator_curent);
        }
        public void LoadUser( ServiceReference.Utilizator utilizator )
        {
            if (utilizator == null || utilizator.IdUser <= 0)
            {
                MessageBox.Show("Nu aveti autorizatie.");
                Application.Exit();
                return;
            }
            utilizator_curent = utilizator;
            CentreazaPanel(panelUser);
            CentreazaPanel(panelValute);
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
            textBoxCNP.ReadOnly = false;
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

        private void tranzactieToolStripMenuItem_Click( object sender, EventArgs e )
        {
            CloseCurrentFormAndOpenNewFormAsync(utilizator_curent);
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

                ServiceReference.Utilizator utilizator = new ServiceReference.Utilizator
                {
                    IdUser = -1,
                    Nume = nume,
                    Prenume = prenume,
                    Telefon = tel,
                    Cnp = cnp,
                    Sold = sold,
                    Iban = RandomIban(),
                    DataCreare = data,
                    IdValuta = id_valuta
                };
                client.AdugareUser(utilizator);
                MessageBox.Show("Utilizator adaugat.");
                return;
            }

            if (buttonAdaugaUser.Text == "Modifica User" && utilizator_curent != null)
            {
                ServiceReference.WebServiceSoapClient client = new ServiceReference.WebServiceSoapClient();
                client.ModificaUser(utilizator_curent.IdUser, nume, prenume, tel);
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
            ServiceReference.Valute valute = new ServiceReference.Valute
            {
                IdValuta = -1,
                CodValutar = cod_valuta,
                Denumire = denumire,
                Simbol = simbol,
                Tara = tara,
                CursdeSchimb = curs_baza
            };

            client.AdugareValuta(valute);
            MessageBox.Show("Valuta adaugata cu succes");
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
            utilizator_curent = client.CautareUser(cnp);

            if (utilizator_curent == null)
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
            textBoxNume.Text = utilizator_curent.Nume;
            textBoxPrenume.Text = utilizator_curent.Prenume;
            textBoxCNP.Text = utilizator_curent.Cnp;
            textBoxTelefon.Text = utilizator_curent.Telefon;
            textBoxCNP.ReadOnly = true;
        }





        private void CentreazaPanel( Panel panel )
        {
            int extraHeight = menuStrip1.Height + 50;
            MinimumSize = new Size(panel.Width + 50, panel.Height + extraHeight);
            Size = new Size(panel.Width + 50, panel.Height + 50);

            panel.Anchor = AnchorStyles.None;
            panel.Dock = DockStyle.None;

            // Dimensionează fereastra la dimensiunea panelului și plasează panelul în colțul stânga-sus
            Size = panel.Size;
            panel.Location = new Point(0, menuStrip1.Height);
            MinimumSize = new Size(panel.Width+50, panel.Height + extraHeight);
        }


        private void ToateTextBoxurileledinPanelGoale( Panel panel )
        {
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
            }
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

            return stringBuilder.ToString() + DateTime.Now.ToString();
        }

        private void CloseCurrentFormAndOpenNewFormAsync( ServiceReference.Utilizator utilizator )
        {
            Hide();
            ToateTextBoxurileledinPanelGoale(panelUser);
            ToateTextBoxurileledinPanelGoale(panelValute);
            if (utilizator.IdUser <= 0)
            {
                MessageBox.Show("Eroare la Login!");
                return;
            }

            if (formTranzactie == null)
            {
                formTranzactie = new Tranzactie(utilizator)
                {
                    MinimumSize = new Size(520 , 500 )
                };
                formTranzactie.Size = formTranzactie.MinimumSize;
                formTranzactie.FormClosed += ( sender, e ) => { formTranzactie = null; }; // Resetare referință când formularul este închis
            }

            formTranzactie.Visible = true;

            if (Application.OpenForms ["FormUser"] != null)
            {
                Application.OpenForms ["FormUser"].Hide();
            }

            formTranzactie.Show();
            formTranzactie.Focus();
        }

    }
}
