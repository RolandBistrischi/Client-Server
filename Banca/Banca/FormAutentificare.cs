using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Banca
{
    public partial class FormAutentificare : Form
    {
        ServiceReference.Utilizator utilizator_curent;
        private FormUser formUser = null;// Form nou

        public FormAutentificare()
        {
            InitializeComponent();
        }
        private void Form1_Load( object sender, EventArgs e )
        {
            ToateTextBoxurileledinPanelGoale(panelLogin);
            ToateObicteledinPanelVisible(panelLogin, true);
            panelSignUp.Hide();
            MinimumSize = new Size(panelLogin.Width + 50, panelLogin.Height + 50);
            Size = new Size(panelLogin.Width + 50, panelLogin.Height + 50);

            panelLogin.Anchor = AnchorStyles.None; // Debifează orice ancorare existentă pentru panel menu
            panelLogin.Dock = DockStyle.None; // Dezactivează orice ancorare existentă pentru panel menu
            Size = panelLogin.Size;
            panelLogin.Location = new Point(0, 0);
            MinimumSize = new Size(panelLogin.Width, panelLogin.Height);
            butonuldeBack();
        }

        private void buttonLogin_Click( object sender, EventArgs e )
        {
            string nume = FormatName(textBoxNumeLogin.Text);
            string prenume = FormatName(textBoxPrenumeLogin.Text);
            string cnp = textBoxCNPLogin.Text.Trim();
            if (string.IsNullOrEmpty(cnp))
            {
                MessageBox.Show("Introduceti cnp");
                return;
            }
            if (string.IsNullOrEmpty(nume) || string.IsNullOrEmpty(prenume))
            {
                MessageBox.Show("Introduceți numele si prenumele.");
                return;
            }

            ServiceReference.WebServiceSoapClient client = new ServiceReference.WebServiceSoapClient();
            ServiceReference.Utilizator utilizator = new ServiceReference.Utilizator
            {
                IdUser = -1,
                Nume = nume,
                Prenume = prenume,
                Cnp = cnp,
            };
            utilizator_curent = client.CautareUser(cnp);
            if (utilizator_curent != null)
            {
                CloseCurrentFormAndOpenNewFormAsync(utilizator_curent);
                ToateTextBoxurileledinPanelGoale(panelLogin);
                return;
            }
            else
            {
                MessageBox.Show("Eroare la Login");
            }
        }
        private void buttonSignUppanelLogin_Click( object sender, EventArgs e )
        {
            AfisareValute();
            panelLogin.Hide();
            panelSignUp.Show();
            panelSignUp.Anchor = AnchorStyles.None;
            panelSignUp.Dock = DockStyle.None;
            MinimumSize = new Size(panelSignUp.Width + 50, panelSignUp.Height + 50);
            Size = new Size(panelSignUp.Width + 50, panelSignUp.Height + 50);
            FormBorderStyle = FormBorderStyle.Sizable;
            panelSignUp.Location = new Point(0, 0);
            ToateObicteledinPanelVisible(panelSignUp, true);
            ToateTextBoxurileledinPanelGoale(panelLogin);
        }
        private void buttonBack_Click( object sender, EventArgs e )
        {
            butonuldeBack();
            Size = new Size(panelLogin.Width + 50, panelLogin.Height + 50);
            ToateTextBoxurileledinPanelGoale(panelSignUp);
        }
        private void buttonSignUppanelSignUp_Click( object sender, EventArgs e )
        {
            string nume = FormatName(textBoxNumeSignUp.Text);
            string prenume = FormatName(textBoxPrenumeSignUp.Text);
            string cnp = textBoxCNPSignUp.Text.Trim();
            string tel = textBoxTelefonSignUp.Text;
            string denumireValuta = null;
            string simbolValuta = null;
            if (string.IsNullOrEmpty(cnp))
            {
                MessageBox.Show("Introduceti cnp");
                return;
            }

            if (string.IsNullOrEmpty(nume) || string.IsNullOrEmpty(prenume) ||
                string.IsNullOrEmpty(cnp) || IsValidTelefon(tel))
            {
                MessageBox.Show("Introduceți date.");
                return;
            }

            if (string.IsNullOrEmpty(textBoxSoldSignUp.Text))
            {
                MessageBox.Show("Introduceți sold.");
                return;
            }

            if (!decimal.TryParse(textBoxSoldSignUp.Text.Trim(), out decimal sold))
            {
                MessageBox.Show("Introduceți un sold valid.");
                return;
            }
            if (listBoxValuteSignUp.SelectedIndex == -1)
            {
                MessageBox.Show("Selectați o valută.");
                return;
            }

            string Valuta = listBoxValuteSignUp.SelectedItem.ToString();
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
            if (client.AdugareUser(utilizator))
            {
                utilizator_curent = utilizator;
                CloseCurrentFormAndOpenNewFormAsync(utilizator);
                return;
            }
            else
                MessageBox.Show("Eroare la adugarea utilizatorului sau aveti deja cont.");
        }



        private void AfisareValute()
        {
            listBoxValuteSignUp.Items.Clear();
            ServiceReference.WebServiceSoapClient client = new ServiceReference.WebServiceSoapClient();
            List<string> valute = client.ToateValutele();
            foreach (string a in valute)
            {
                listBoxValuteSignUp.Items.Add(a);
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
        private string FormatName( string input )
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }
            input.Trim();
            // Păstrează prima literă mare și restul caractere mici
            string formattedText = input.Substring(0, 1).ToUpper() + input.Substring(1).ToLowerInvariant();
            return formattedText;
        }
        private bool IsValidTelefon( string telefon )
        {
            if (string.IsNullOrEmpty(telefon))
                return false;
            telefon.Trim();

            // Expresie regulată pentru validarea formatului numărului de telefon
            string pattern = @"^\d{10}$";

            // Verifică dacă numărul de telefon respectă formatul
            return Regex.IsMatch(telefon, pattern);
        }
        private void ToateObicteledinPanelVisible( Panel panel, bool vis )
        {
            foreach (Control control in panel.Controls)
            {
                control.Visible = vis;
            }
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
        private void butonuldeBack()
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            panelLogin.Show();
            panelSignUp.Hide();
            MinimumSize = new Size(panelLogin.Width + 50, panelLogin.Height + 50);
        }


        private void CloseCurrentFormAndOpenNewFormAsync( ServiceReference.Utilizator utilizator )
        {
            Hide();
            ToateTextBoxurileledinPanelGoale(panelSignUp);
            butonuldeBack();
            if (utilizator.IdUser <= 0)
            {
                MessageBox.Show("Eroare la Login!");
                return;
            }

            if (formUser == null)
            {
                formUser = new FormUser(utilizator)
                {
                    MinimumSize = new Size(520 * 2, 138 * 4)
                };
                formUser.Size = formUser.MinimumSize;
                formUser.FormClosed += ( sender, e ) => { formUser = null; }; // Resetare referință când formularul este închis
            }

            if (!formUser.Visible)
            {
                formUser.Visible = true;

                if (Application.OpenForms ["FormAutentificare"] != null)
                {
                    Application.OpenForms ["FormAutentificare"].Hide();
                }
            }
            formUser.LoadUser(utilizator);
            formUser.Show();
            formUser.Focus();
        }


    }
}
