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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjekatSBP.Forme
{
    public partial class RacuniForm : Form
    {
        public RacuniForm()
        {
            InitializeComponent();
        }
        private void RacuniForm_Load(object sender, EventArgs e)
        {
            popuniTabelu();
            using (var s = DataLayer.GetSession())
            {
                var banke = s.Query<Entiteti.Banka>().ToList();
                comboBox7.DataSource = banke;
                comboBox7.DisplayMember = "Naziv";
                comboBox7.ValueMember = "Id";

                var klijenti = s.Query<Klijent>().ToList();
                comboBox8.DataSource = klijenti;
                comboBox8.DisplayMember = "id";
                comboBox8.ValueMember = "id";
            }
        }
        public void popuniTabelu()
        {
            List<DTOs.RacunPregled> listaRacuna = DTOmanager.vratiSveRacune();
            dataGridView9.DataSource = new BindingList<DTOs.RacunPregled>(listaRacuna);
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
        private void cmdDodajRacun_Click(object sender, EventArgs e)
        {
                if (!proveriUnos(textBox7) || !proveriUnosComboBox(comboBox7, comboBox8, comboBox9))
                {
                    MessageBox.Show("Sva polja su obavezna!");
                    return;
                }
                DTOs.RacunBasic o = new DTOs.RacunBasic
                {
                    BankaId = (int)comboBox7.SelectedValue,
                    KlijentId = (int)comboBox8.SelectedValue,
                    Valuta = textBox7.Text,
                    Status = (StatusRacuna)Enum.Parse(typeof(StatusRacuna), comboBox9.SelectedItem.ToString()),
                    DatumOtvaranja = dateTimePicker8.Value,
                    Saldo = (decimal)numericUpDown10.Value
                };
                DTOmanager.dodajRacun(o);
                MessageBox.Show("Racun je uspešno dodat!");
                popuniTabelu();
        }

        private void cmdPrikaziRacune_Click(object sender, EventArgs e)
        {
            if(dataGridView9.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali racun za prikaz!");
                return;
            }
            int id = (int)dataGridView9.SelectedRows[0].Cells["RacunId"].Value; ;
            DTOs.RacunBasic racun = DTOmanager.vratiRacun(id);
            MessageBox.Show("Id banke kojoj pripada racun: "+ racun.BankaId + "\n Valuta: "+ racun.Valuta+"\n Status: " + racun.Status + "\n Saldo: "+ racun.Saldo + "\n Datum otvaranja: "+ racun.DatumOtvaranja+ "\n Id klijent kome pripada racun: " + racun.KlijentId);
        }

        private void cmdAzurirajRacun_Click(object sender, EventArgs e)
        {
                if (!proveriUnos(textBox7) || !proveriUnosComboBox(comboBox7, comboBox8, comboBox9))
                {
                    MessageBox.Show("Sva polja su obavezna!");
                    return;
                }
                if (dataGridView9.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Niste izabrali racun za izmenu!");
                    return;
                }
                int id = (int)dataGridView9.SelectedRows[0].Cells["Racunid"].Value;
                DTOs.RacunBasic racun = new DTOs.RacunBasic();
                racun.RacunId = id;
                racun.BankaId = (int)comboBox7.SelectedValue;
                racun.Valuta = textBox7.Text;
                racun.KlijentId = (int)comboBox8.SelectedValue;
                racun.DatumOtvaranja = dateTimePicker8.Value;
                racun.Saldo = (decimal)numericUpDown10.Value;
                racun.Status = (StatusRacuna)Enum.Parse(typeof(StatusRacuna), comboBox9.SelectedItem.ToString());
                DTOmanager.azurirajRacun(racun);
                MessageBox.Show("Racun je uspesno azuriran!");
                popuniTabelu();
        }

        private void cmdObrisiRacun_Click(object sender, EventArgs e)
        {
            if (dataGridView9.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali racun za brisanje!");
                return;
            }
            int id = (int)dataGridView9.SelectedRows[0].Cells["Racunid"].Value;
            DTOmanager.obrisiRacun(id);
            MessageBox.Show("Racun je uspesno obrisan!");
            popuniTabelu();
        }
    }
}
