using NHibernate;
using ProjekatSBP.Entiteti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjekatSBP.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ProjekatSBP.Forme
{
    public partial class KlijentiForm : Form
    {
        public KlijentiForm()
        {
            InitializeComponent();
        }
        private void KlijentiForm_Load(object sender, EventArgs e)
        {
            popuniTabelu();
        }
        public void popuniTabelu()
        {
            List<DTOs.KlijentPregled> listaKlijenata = DTOmanager.vratiSveKlijente();
            var fizicko = listaKlijenata.OfType<FizickoLicePregled>().ToList();
            var pravno = listaKlijenata.OfType<PravnoLicePregled>().ToList();
            var organizacija = listaKlijenata.OfType<OrganizacijaPregled>().ToList();

            dataGridView10.DataSource = new BindingList<FizickoLicePregled>(fizicko);
            dataGridView11.DataSource = new BindingList<PravnoLicePregled>(pravno);
            dataGridView12.DataSource = new BindingList<OrganizacijaPregled>(organizacija);
        }
        public static bool proveriUnos(params System.Windows.Forms.TextBox[] boxes)
        {
            foreach (var tb in boxes)
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                    return false;
            }
            return true;
        }
        public static bool proveriUnosComboBox(params System.Windows.Forms.ComboBox[] boxes)
        {
            foreach (var cb in boxes)
            {
                if (cb.SelectedItem == null)
                    return false;
            }
            return true;
        }
        private void omoguciKomande(int rbr)
        {
            var grupa1 = new Control[]
            {
                textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, listBox6, listBox7
            };
            var grupa2 = new Control[]
            {
                textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, listBox5
            };
            var grupa3 = new Control[]
            {
                textBox27, textBox28, textBox29, textBox30, textBox31, textBox32, listBox8, listBox9
            };
            foreach (var ctrl in grupa1.Concat(grupa2).Concat(grupa3))
                ctrl.Visible = false;

            switch (rbr)
            {
                case 1: foreach (var ctrl in grupa1) ctrl.Visible = true; break;
                case 2: foreach (var ctrl in grupa2) ctrl.Visible = true; break;
                case 3: foreach (var ctrl in grupa3) ctrl.Visible = true; break;
            }
        }
        private void rbFizLice_CheckedChanged(object sender, EventArgs e)
        {
            omoguciKomande(2);
        }

        private void rbPravnoLice_CheckedChanged(object sender, EventArgs e)
        {
            omoguciKomande(1);
        }

        private void rbOrganizacija_CheckedChanged(object sender, EventArgs e)
        {
            omoguciKomande(3);
        }
        private void cmdDodajKorisnika_Click(object sender, EventArgs e)
        {

                DTOs.KlijentBasic k = null;
                if (rbPravnoLice.Checked)
                {
                if (!proveriUnos(textBox19, textBox20, textBox21, textBox22, textBox23, textBox24))
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                    return;
                }
                DTOs.PravnoLiceBasic pl = new DTOs.PravnoLiceBasic()
                    {   
                        Tip = Klijent.TipKlijenta.pravno,
                        kontaktOsoba = textBox21.Text,
                        adresa = textBox19.Text,
                        firma = textBox20.Text,
                        delatnost = textBox22.Text,
                        pib = int.Parse(textBox23.Text),
                        maticniBr = textBox24.Text,
                        Telefoni = listBox6.Items.Cast<string>().ToList(),
                        EmailAdrese = listBox7.Items.Cast<string>().ToList()
                    };
                    k = pl; 
                }
                else if (rbFizLice.Checked)
                {
                    if (!proveriUnos(textBox13, textBox14, textBox15, textBox16, textBox17))
                    {
                        MessageBox.Show("Sva polja moraju biti popunjena!");
                        return;
                    }
                    DTOs.FizickoLiceBasic fl = new DTOs.FizickoLiceBasic()
                    {
                        Tip = Klijent.TipKlijenta.fizicko,
                        licnoIme = textBox15.Text,
                        prezime = textBox16.Text,
                        imeRoditelja = textBox14.Text,
                        brLicneKarte = textBox12.Text,
                        mestoIzdavanja = textBox13.Text,
                        jmbg = textBox17.Text,
                        Telefoni = listBox5.Items.Cast<string>().ToList()
                    };
                k = fl; ;
                }
                else if (rbOrganizacija.Checked)
                {
                    if (!proveriUnos(textBox27, textBox28, textBox29, textBox30))
                    {
                        MessageBox.Show("Sva polja moraju biti popunjena!");
                        return;
                    }
                    DTOs.OrganizacijaBasic o = new DTOs.OrganizacijaBasic()
                    {
                        Tip = Klijent.TipKlijenta.organizacija,
                        adresa = textBox27.Text,
                        osnivac = textBox29.Text,
                        tipOrganizacije = textBox28.Text,
                        registar = textBox30.Text,
                        Telefoni = listBox9.Items.Cast<string>().ToList(),
                        EmailAdrese = listBox8.Items.Cast<string>().ToList()
                    };
                k = o;
                }
                else
                {
                    MessageBox.Show("Niste izabrali tip klijenta!");
                    return;
            }
                DTOmanager.dodajKlijenta(k);
                popuniTabelu();
                MessageBox.Show("Klijent je uspesno dodat!");

        }

        private void cmdPrikaziKorisnike_Click(object sender, EventArgs e)
        {
            if(dataGridView10.SelectedRows.Count == 0 && dataGridView11.SelectedRows.Count == 0 && dataGridView12.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali klijenta za prikaz!");
                return;
            }
            else if(dataGridView10.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView10.SelectedRows[0].Cells["Id"].Value;
                DTOs.KlijentBasic klijent = DTOmanager.vratiKlijenta(id);
                if(klijent is DTOs.FizickoLiceBasic fl)
                {
                    string telefoni = string.Join(", ", fl.Telefoni);
                    MessageBox.Show("Broj licne karte: "+ fl.brLicneKarte+"\nJmbg: "+fl.jmbg+"\nTelefoni:" + telefoni);
                }
            }
            else if(dataGridView11.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView11.SelectedRows[0].Cells["Id"].Value;
                DTOs.KlijentBasic klijent = DTOmanager.vratiKlijenta(id);
                if(klijent is DTOs.PravnoLiceBasic pl)
                {
                    string telefoni = string.Join(", ", pl.Telefoni);
                    string email = string.Join(", ", pl.EmailAdrese);
                    MessageBox.Show("Maticni broj:"+pl.maticniBr+"\nPib:"+pl.pib+"\nTelefoni: " + telefoni + "\nEmail adrese: " + email);
                }
            }
            else if(dataGridView12.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView12.SelectedRows[0].Cells["Id"].Value;
                DTOs.KlijentBasic klijent = DTOmanager.vratiKlijenta(id);
                if (klijent is DTOs.OrganizacijaBasic o)
                {
                    string telefoni = string.Join(", ", o.Telefoni);
                    string email = string.Join(", ", o.EmailAdrese);
                    MessageBox.Show("Telefoni: " + telefoni + "\nEmail adrese: " + email);
                }
            }
        }

        private void cmdAzurirajKlijenta_Click(object sender, EventArgs e)
        {
            DTOs.KlijentBasic k = null;
            if (rbPravnoLice.Checked && dataGridView11.SelectedRows.Count > 0)
            {
                if (!proveriUnos(textBox19, textBox20, textBox21, textBox22, textBox23, textBox24) )
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                    return;
                }
                int id = (int)dataGridView11.SelectedRows[0].Cells["Id"].Value;
                DTOs.PravnoLiceBasic pravno = new DTOs.PravnoLiceBasic();
                pravno.Id = id;
                pravno.adresa = textBox19.Text;
                pravno.firma = textBox20.Text;
                pravno.kontaktOsoba = textBox21.Text;
                pravno.delatnost = textBox22.Text;
                pravno.pib = int.Parse(textBox23.Text);
                pravno.maticniBr = textBox24.Text;
                pravno.Telefoni = listBox6.Items.Cast<string>().ToList();
                pravno.EmailAdrese = listBox7.Items.Cast<string>().ToList();
                k = pravno;
            }
            else if (rbFizLice.Checked && dataGridView10.SelectedRows.Count > 0)
            {
                if (!proveriUnos(textBox12, textBox13, textBox14, textBox15, textBox16, textBox17))
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                    return;
                }
                DTOs.FizickoLiceBasic fl = new DTOs.FizickoLiceBasic();
                int id = (int)dataGridView10.SelectedRows[0].Cells["Id"].Value;
                fl.Id = id;
                fl.licnoIme = textBox15.Text;
                fl.prezime = textBox16.Text;
                fl.imeRoditelja = textBox14.Text;
                fl.brLicneKarte = textBox12.Text;
                fl.mestoIzdavanja = textBox13.Text;
                fl.jmbg = textBox17.Text;
                fl.Telefoni = listBox5.Items.Cast<string>().ToList();
                k = fl; ;
            }
            else if (rbOrganizacija.Checked && dataGridView12.SelectedRows.Count > 0)
            {
                if (!proveriUnos(textBox27, textBox28, textBox29, textBox30))
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                    return;
                }
                DTOs.OrganizacijaBasic o = new DTOs.OrganizacijaBasic();
                int id = (int)dataGridView12.SelectedRows[0].Cells["Id"].Value;
                o.Id = id;
                o.adresa = textBox27.Text;
                o.osnivac = textBox29.Text;
                o.tipOrganizacije = textBox28.Text;
                o.registar = textBox30.Text;
                o.Telefoni = listBox9.Items.Cast<string>().ToList();
                o.EmailAdrese = listBox8.Items.Cast<string>().ToList();
                k = o;
            }
            else
            {
                MessageBox.Show("Niste izabrali tip klijenta!");
                return;
            }
            DTOmanager.azurirajKlijenta(k);
            popuniTabelu();
            MessageBox.Show("Klijent je uspesno azuriran!");
        }

        private void cmdObrisiKlijenta_Click(object sender, EventArgs e)
        {
            if(dataGridView10.SelectedRows.Count == 0 && dataGridView11.SelectedRows.Count == 0 && dataGridView12.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali klijenta za brisanje!");
                return;
            }
            else if(dataGridView10.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView10.SelectedRows[0].Cells["Id"].Value;
                DTOmanager.obrisiKlijenta(id);
                popuniTabelu();
                MessageBox.Show("Klijent je uspešno obrisan!");
            }
            else if(dataGridView11.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView11.SelectedRows[0].Cells["Id"].Value;
                DTOmanager.obrisiKlijenta(id);
                popuniTabelu();
                MessageBox.Show("Klijent je uspešno obrisan!");
            }
            else if(dataGridView12.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView12.SelectedRows[0].Cells["Id"].Value;
                DTOmanager.obrisiKlijenta(id);
                popuniTabelu();
                MessageBox.Show("Klijent je uspešno obrisan!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string brojevi = textBox18.Text.Trim();
            if (!string.IsNullOrEmpty(brojevi))
            {
                listBox5.Items.Add(brojevi);
                textBox18.Clear();
                textBox18.Focus();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string brojevi = textBox25.Text.Trim();
            if (!string.IsNullOrEmpty(brojevi))
            {
                listBox6.Items.Add(brojevi);
                textBox25.Clear();
                textBox25.Focus();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string email = textBox26.Text.Trim();
            if (!string.IsNullOrEmpty(email))
            {
                listBox7.Items.Add(email);
                textBox26.Clear();
                textBox26.Focus();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string telefoni = textBox32.Text.Trim();
            if (!string.IsNullOrEmpty(telefoni))
            {
                listBox9.Items.Add(telefoni);
                textBox32.Clear();
                textBox32.Focus();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string email = textBox31.Text.Trim();
            if (!string.IsNullOrEmpty(email))
            {
                listBox8.Items.Add(email);
                textBox31.Clear();
                textBox31.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox5.SelectedItem != null)
            {
                listBox5.Items.Remove(listBox5.SelectedItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(listBox6.SelectedItems != null)
            {
                listBox6.Items.Remove(listBox6.SelectedItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox6.SelectedItem != null)
            {
                listBox7.Items.Remove(listBox7.SelectedItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox9.SelectedItem != null)
            {
                listBox9.Items.Remove(listBox9.SelectedItem);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(listBox8.SelectedItem != null)
            {
                listBox8.Items.Remove(listBox8.SelectedItem);
            }
        }
    }
}
