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

namespace ProjekatSBP.Forme
{
    public partial class KarticeForm : Form
    {
        public KarticeForm()
        {
            InitializeComponent();
        }
        private void KarticeForm_Load(object sender, EventArgs e)
        {
            popuniTabelu();
            using (var s = DataLayer.GetSession())
            {
                var racuni = s.Query<Racun>().ToList();
                comboBox2.DataSource = racuni;
                comboBox2.DisplayMember = "RacunId";
                comboBox2.ValueMember = "RacunId";
            }
        }
        public void popuniTabelu()
        {
            List<DTOs.KarticaPregled> listaKartica = DTOmanager.vratiSveKArtice();
            var kreditne = listaKartica.OfType<DTOs.KreditnaKarticaPregled>().ToList();
            var debitne = listaKartica.OfType<DTOs.DebitnaKarticaPregled>().ToList();

            dataGridView8.DataSource = new BindingList<DTOs.KreditnaKarticaPregled>(kreditne);
            dataGridView6.DataSource = new BindingList<DTOs.DebitnaKarticaPregled>(debitne);
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
        private void cmdDodajKreditnuKarticu_Click(object sender, EventArgs e)
        {
            if (!proveriUnos(textBox6) || !proveriUnosComboBox(comboBox2))
            {
                MessageBox.Show("Sva polja su obavezna!");
                return;
            }
            DTOs.KarticaBasic k = null;
            if (radioButton2.Checked)
            {
                DTOs.KreditnaKarticaBasic kk = new DTOs.KreditnaKarticaBasic() {
                    BrojKartice = textBox6.Text,
                    DnevniLimit = numericUpDown5.Value,
                    Racun = ((Racun)comboBox2.Items[comboBox2.SelectedIndex]).RacunId,
                    DatumIzdavanja = dateTimePicker4.Value,
                    DatumIsteka = dateTimePicker3.Value,
                    MaxPeriodOtplate = (int)numericUpDown7.Value,
                    MesecniLimit = numericUpDown8.Value
                };
                k = kk;
            }
            else if (radioButton1.Checked)
            {
                DTOs.DebitnaKarticaBasic dk = new DTOs.DebitnaKarticaBasic() { 
                BrojKartice = textBox6.Text,
                DnevniLimit = numericUpDown5.Value,
                Racun = ((Racun)comboBox2.Items[comboBox2.SelectedIndex]).RacunId,
                DatumIzdavanja = dateTimePicker4.Value,
                DatumIsteka = dateTimePicker3.Value,
                DnevniLimitZaPodizanje = (int)numericUpDown6.Value
            };
                k = dk;
            }
            DTOmanager.dodajKarticu(k);
            popuniTabelu();
            MessageBox.Show("Kartica je uspesno dodata!");
        }

        private void cmdPrikaziKarticu_Click(object sender, EventArgs e)
        {
            int id;
            if(dataGridView6.SelectedRows.Count == 0 && dataGridView8.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali karticu za prikaz!");
                return;
            }
            else if (dataGridView6.SelectedRows.Count > 0)
            {
                id = (int)dataGridView6.SelectedRows[0].Cells["KarticaId"].Value;
                DTOs.KarticaBasic kartica = DTOmanager.vratiKarticu(id);
                if(kartica is DTOs.DebitnaKarticaBasic)
                {
                    MessageBox.Show("Dnevni limit za podizanje: " + ((DTOs.DebitnaKarticaBasic)kartica).DnevniLimitZaPodizanje+ "\nId racun kome pripada kartica: " + kartica.Racun);
                }
                else 
                {
                    MessageBox.Show("Izabrana kartica nije debitna!");
                }
            }
            else if (dataGridView8.SelectedRows.Count > 0)
            {
                id = (int)dataGridView8.SelectedRows[0].Cells["KarticaId"].Value;
                DTOs.KarticaBasic kartica = DTOmanager.vratiKarticu(id);
                if(kartica is DTOs.KreditnaKarticaBasic)
                {
                    MessageBox.Show("Mesecni limit: " + ((DTOs.KreditnaKarticaBasic)kartica).MesecniLimit + "\nMaksimalni period otplate: " + ((DTOs.KreditnaKarticaBasic)kartica).MaxPeriodOtplate + "\n Id racuna kome pripada kartica: " + kartica.Racun);
                }
                else
                {
                    MessageBox.Show("Izabrana kartica nije kreditna!");
                }
            }
        }

        private void cmdAzurirajKarticu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!proveriUnos(textBox6) || !proveriUnosComboBox(comboBox2))
                {
                    MessageBox.Show("Sva polja su obavezna!");
                    return;
                }

                DTOs.KarticaBasic k = null;

                if (radioButton1.Checked && dataGridView6.SelectedRows.Count == 1)
                {
                    int id = (int)dataGridView6.SelectedRows[0].Cells["KarticaId"].Value;

                    DTOs.DebitnaKarticaBasic dk = new DTOs.DebitnaKarticaBasic();
                    dk.KarticaId = id;
                    dk.BrojKartice = textBox6.Text;
                    dk.DatumIzdavanja = dateTimePicker4.Value;
                    dk.DatumIsteka = dateTimePicker3.Value;
                    dk.Racun = ((Racun)comboBox2.SelectedItem).RacunId;
                    dk.DnevniLimit = (decimal)numericUpDown5.Value;
                    dk.DnevniLimitZaPodizanje = (decimal)numericUpDown6.Value;
                    k = dk;
                }
                else if (radioButton2.Checked && dataGridView8.SelectedRows.Count == 1)
                {
                    int id = (int)dataGridView8.SelectedRows[0].Cells["KarticaId"].Value;

                    DTOs.KreditnaKarticaBasic kk = new DTOs.KreditnaKarticaBasic();
                    kk.KarticaId = id;
                    kk.BrojKartice = textBox6.Text;
                    kk.DatumIzdavanja = dateTimePicker4.Value;
                    kk.DatumIsteka = dateTimePicker3.Value;
                    kk.Racun = ((Racun)comboBox2.SelectedItem).RacunId;
                    kk.DnevniLimit = (decimal)numericUpDown5.Value;
                    kk.MaxPeriodOtplate = (int)numericUpDown7.Value;
                    kk.MesecniLimit = (decimal)numericUpDown8.Value;
                    k = kk;
                }
                else
                {
                    MessageBox.Show("Niste izabrali tip kartice ili red u tabeli!");
                    return;
                }
                DTOmanager.azurirajKarticu(k);
                MessageBox.Show("Kartica je uspesno azurirana!");
                popuniTabelu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }

        private void cmdObrisiKarticu_Click(object sender, EventArgs e)
        {
            if (dataGridView6.SelectedRows.Count == 0 && dataGridView8.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali karticu za brisanje!");
                return;
            }
            if(dataGridView6.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView6.SelectedRows[0].Cells["KarticaId"].Value;
                DTOmanager.obrisiKarticu(id);
                MessageBox.Show("Kartica je uspesno obrisana!");
            }
            else if(dataGridView8.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView8.SelectedRows[0].Cells["KarticaId"].Value;
                DTOmanager.obrisiKarticu(id);
                MessageBox.Show("Kartica je uspesno obrisana!");
            }
            popuniTabelu();
        }
    }
}
