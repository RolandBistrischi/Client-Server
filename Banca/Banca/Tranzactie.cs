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

        private void button1_Click( object sender, EventArgs e )
        {

        }
    }
}
