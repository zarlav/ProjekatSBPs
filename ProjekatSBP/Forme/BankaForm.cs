using NHibernate;
using NHibernate.Linq;
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

namespace ProjekatSBP.Forme
{
    public partial class BankaForm : Form
    {
        public BankaForm()
        {
            InitializeComponent();
        }

        private void BankaForm_Load(object sender, EventArgs e)
        {
            popuniTabelu();
        }
        public int brojBanaka = 0;
        public static bool proveriUnos(params System.Windows.Forms.TextBox[] boxes)
        {
            foreach (var tb in boxes)
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                    return false;
            }
            return true;
        }
        public void popuniTabelu()
        {
            List<DTOs.BankaPregled> listaBanaka = DTOmanager.vratiBanke();
            dataGridView5.DataSource = new BindingList<DTOs.BankaPregled>(listaBanaka);
            this.brojBanaka = listaBanaka.Count;
        }

        private void cmdDodajBanku_Click(object sender, EventArgs e)
        {
                if (!proveriUnos(textBox2, textBox3, textBox4))
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                    return;
                }
               DTOs.BankaBasic o = new DTOs.BankaBasic
                {
                    Naziv = textBox3.Text,
                    Adresa = textBox2.Text,
                    WebAdresa = textBox4.Text,
                   Telefoni = listBox2.Items.Cast<string>().ToList(),
                   EmailAdrese = listBox3.Items.Cast<string>().ToList()
               };
                DTOmanager.dodajBanku(o);
                MessageBox.Show("Banka je uspesno dodata!");
                popuniTabelu();
        }

        private void cmdPrikazBanke_Click(object sender, EventArgs e)
        {
            if(dataGridView5.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali banku za prikaz!");
                return;
            }
            int id = (int)dataGridView5.SelectedRows[0].Cells["Id"].Value;
            DTOs.BankaBasic banka = DTOmanager.vratiBanku(id);
            MessageBox.Show("Naziv: " + banka.Naziv + "\nAdresa: " + banka.Adresa + "\nWeb adresa: " + banka.WebAdresa +
                "\nTelefoni: " + string.Join(", ", banka.Telefoni) + "\nEmail adrese: " + string.Join(", ", banka.EmailAdrese));
        }

        private void cmdAzurirajBanku_Click(object sender, EventArgs e)
        {
            if (!proveriUnos(textBox2, textBox3, textBox4))
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
                return;
            }
                if (dataGridView5.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Niste izabrali banku za izmenu!");
                    return;
                }
                int id = (int)dataGridView5.SelectedRows[0].Cells["Id"].Value;
                DTOs.BankaBasic banka = new DTOs.BankaBasic();
                banka.Id = id;
                banka.Naziv = textBox3.Text;
                banka.Adresa = textBox2.Text;
                banka.WebAdresa = textBox4.Text;
                banka.Telefoni.Clear();
                foreach (var item in listBox2.Items)
                    banka.Telefoni.Add(item.ToString());
                banka.EmailAdrese.Clear();
                foreach (var item in listBox3.Items)
                    banka.EmailAdrese.Add(item.ToString());
                DTOmanager.azurirajBanku(banka);
                MessageBox.Show("Banka je uspesno azurirana!");
        }

        private void cmdObrisiBanku_Click(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali banku za brisanje!");
                return;
            }
            int id = (int)dataGridView5.SelectedRows[0].Cells["Id"].Value;
            DTOmanager.obrisiBanku(id);
            MessageBox.Show("Banka je uspesno obrisana!");
            popuniTabelu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string broj = textBox9.Text.Trim();
            if (!string.IsNullOrEmpty(broj))
            {
                listBox2.Items.Add(broj);
                textBox9.Clear();
                textBox9.Focus();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = textBox10.Text.Trim();
            if (!string.IsNullOrEmpty(email))
            {
                listBox3.Items.Add(email);
                textBox10.Clear();
                textBox10.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(listBox2.SelectedItem != null)
            {
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox3.SelectedItem != null)
            {
                listBox3.Items.Remove(listBox3.SelectedItem);
            }
        }
    }
}
