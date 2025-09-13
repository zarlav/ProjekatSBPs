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
using System.Xml.Linq;
using static ProjekatSBP.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjekatSBP.Forme
{
    public partial class FilijaleForm : Form
    {
        public FilijaleForm()
        {
            InitializeComponent();
        }
        private void FilijaleForm_Load(object sender, EventArgs e)
        {
            popuniTabelu();
            using (var s = DataLayer.GetSession())
            {
                var banke = s.Query<Entiteti.Banka>().ToList();
                comboBox1.DataSource = banke;
                comboBox1.DisplayMember = "Naziv";
                comboBox1.ValueMember = "Id";
            }

        }
        public void popuniTabelu()
        {
            List<DTOs.FilijalaPregled> listaFIlijala = DTOmanager.vratiFilijale();
            dataGridView4.DataSource = new BindingList<DTOs.FilijalaPregled>(listaFIlijala);
        }
        private List<RadnoVreme> radnaVremena = new List<RadnoVreme>();
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
        private void cmdDodajFilijalu_Click(object sender, EventArgs e)
        {
                if (!proveriUnos(textBox1) || !proveriUnosComboBox(comboBox1))
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                    return;
                }
                int redniBr = (int)numericUpDown4.Value;
                int bankaId = ((Banka)comboBox1.SelectedItem).Id;
                DTOs.FilijalaBasic f = new DTOs.FilijalaBasic
                {
                    Adresa = textBox1.Text,
                    RedniBrUBanci = redniBr,
                    Telefoni = listBox1.Items.Cast<string>().ToList(),
                    BankaId = bankaId,
                    RadnaVremena = radnaVremena.Select(rv => new DTOs.RadnoVremeBasic
                    {
                        DanUNedelji = rv.Dan,
                        VremePocetka = rv.PocetnoVreme,
                        VremeZavrsetka = rv.ZavrsnoVreme
                    }).ToList()
                };
                DTOmanager.dodajFilijalu(f);
                MessageBox.Show("Filijala je uspešno dodata!");
            popuniTabelu();
        }

        private void cmdPrikaziFilijale_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali filijalu za prikaz!");
                return;
            }
            int id = (int)dataGridView4.SelectedRows[0].Cells["Id"].Value;
            DTOs.FilijalaBasic filijala = DTOmanager.vratiFilijalu(id);
            string telefoni = string.Join(", ", filijala.Telefoni);
            string radnaVremena = string.Join("\n", filijala.RadnaVremena
            .Select(rv => $"{rv.DanUNedelji}: {rv.VremePocetka:hh\\:mm} - {rv.VremeZavrsetka:hh\\:mm}"));
            MessageBox.Show("Redni broj u banci: "+filijala.RedniBrUBanci+"\n"+"Adresa: "+ filijala.Adresa+ "\n"+"Banka id:"+filijala.BankaId + "\n"+ "Radna vremena:"+ radnaVremena+"\n" + "Brojevi telefona:" + telefoni);
        }

        private void cmdAzurirajFilijalu_Click(object sender, EventArgs e)
        {
            if (!proveriUnos(textBox1) || !proveriUnosComboBox(comboBox1))
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
                return;
            }

            if (dataGridView4.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali filijalu za izmenu!");
                return;
            }
            int id = (int)dataGridView4.SelectedRows[0].Cells["Id"].Value;
            DTOs.FilijalaBasic f = new DTOs.FilijalaBasic
            {
                Id = id,
                Adresa = textBox1.Text,
                RedniBrUBanci = (int)numericUpDown4.Value,
                BankaId = ((BankaPregled)comboBox1.SelectedItem).Id,
                Telefoni = listBox1.Items.Cast<string>().ToList(),
                RadnaVremena = radnaVremena.Select(rv => new DTOs.RadnoVremeBasic
                {
                    DanUNedelji = rv.Dan,
                    VremePocetka = rv.PocetnoVreme,
                    VremeZavrsetka = rv.ZavrsnoVreme
                }).ToList()
            };
            DTOmanager.azurirajFilijalu(f);

            MessageBox.Show("Filijala je uspesno azurirana!");

        }

        private void cmdObrisiFilijalu_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali filijalu za brisanje!");
                return;
            }
            int id = (int)dataGridView4.SelectedRows[0].Cells["Id"].Value;
            DTOmanager.obrisiFilijalu(id);
            MessageBox.Show("Filijala je uspesno obrisana!");
            popuniTabelu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems != null)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Niste izabrali broj telefona za brisanje!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox4.SelectedItems != null)
            {
                listBox4.Items.Remove(listBox4.SelectedItem);
            }
            else
            {
                MessageBox.Show("Niste izabrali radno vreme za brisanje!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Filijala f = new Filijala();
            if (Dani.SelectedItem != null)
            {
                string dan = Dani.SelectedItem.ToString();
                foreach (var item in listBox4.Items)
                {
                    if (item.ToString().StartsWith(dan.ToString()))
                    {
                        MessageBox.Show("Ovaj dan je vec dodat!");
                        return;
                    }
                }
                RadnoVreme rv = new RadnoVreme()
                {
                    Dan = Dani.SelectedItem.ToString(),
                    Filijala = f,
                    PocetnoVreme = dateTimePicker6.Value.ToShortTimeString(),
                    ZavrsnoVreme = dateTimePicker7.Value.ToShortTimeString()
                };
                radnaVremena.Add(rv);
                listBox4.Items.Add($"{rv.Dan} | {rv.PocetnoVreme} - {rv.ZavrsnoVreme}");
            }
            else
            {
                MessageBox.Show("Molimo izaberite dan.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string brojevi = textBox11.Text.Trim();
            if (!string.IsNullOrEmpty(brojevi))
            {
                listBox1.Items.Add(brojevi);
                textBox11.Clear();
                textBox11.Focus();
            }
            else
            {
                MessageBox.Show("Molimo unesite broj telefona.");
            }
        }
    }
}
