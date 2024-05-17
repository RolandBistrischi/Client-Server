using System;
using System.Drawing;
using System.Windows.Forms;

namespace Banca
{
    public partial class Tranzactie : Form
    {
        ServiceReference.Utilizator utilizator_curent = null;

        public Tranzactie()
        {
            InitializeComponent();
        }
        public Tranzactie( ServiceReference.Utilizator utilizator )
        {
            InitializeComponent();
            utilizator_curent = utilizator;
        }
        private void Tranzactie_Load( object sender, EventArgs e )
        {
            if (utilizator_curent == null || utilizator_curent.IdUser <= 0)
            {
                MessageBox.Show("Nu aveti autorizatie.");
                Application.Exit();
                return;
            }
            CentreazaPanel(panelTranzactie);
        }

        private void Tranzactie_FormClosed( object sender, FormClosedEventArgs e )
        {
            if (Application.OpenForms ["FormUser"] != null)
            {
                Application.OpenForms ["FormUser"].Show();
            }
        }

        private void buttonTranzactie_Click( object sender, EventArgs e )
        {
            DialogResult result = MessageBox.Show(
             "Ești sigur că vrei să faci tranzactia?",
             "Confirmare",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question
             );

            if (result == DialogResult.No)
            {
                return;
            }

            string iban = textBoxIBAN.Text.Trim();

            if (!decimal.TryParse(textBoxSuma.Text.Trim(), out decimal sold) || sold < 0)
            {
                MessageBox.Show("Introduceți un sold valid.");
                return;
            }

            if (sold > utilizator_curent.Sold)
            {
                MessageBox.Show("Aveti prea putini bani in cont.");
                return;
            }

            ServiceReference.WebServiceSoapClient client = new ServiceReference.WebServiceSoapClient();
            if (!client.IsIBANinDataBase(iban))
            {
                MessageBox.Show("Acest IBAN nu exista in baza de date.");
            }

            if (result == DialogResult.No)//(client.tranzactie())
            {
                MessageBox.Show("S-a putut efectua tranzactia.");

            }
            else
            {
                MessageBox.Show("Nu s-a putut efectua tranzactia.");
            }

        }




        private void CentreazaPanel( Panel panel )
        {
            MinimumSize = new Size(panel.Width + 50, panel.Height + 50);
            Size = new Size(panel.Width + 50, panel.Height + 50);

            panel.Anchor = AnchorStyles.None;
            panel.Dock = DockStyle.None;
            Size = panel.Size;
            panel.Location = new Point(0, 0);
            MinimumSize = new Size(panel.Width, panel.Height);
        }


    }
}
