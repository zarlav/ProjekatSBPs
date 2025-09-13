using NHibernate;
using FluentNHibernate.Cfg;
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
    public partial class TransakcijeForm : Form
    {
        public TransakcijeForm()
        {
            InitializeComponent();
        }
        private void TransakcijeForm_Load(object sender, EventArgs e)
        {
            popuniTabelu();
            using (var s = DataLayer.GetSession())
            {
                var kartice = s.Query<Kartica>().ToList();
                comboBox5.DataSource = kartice;
                comboBox5.DisplayMember = "BrojKartice";
                comboBox5.ValueMember = "KarticaId";

                var uredjaji = s.Query<Uredjaj>().ToList();
                comboBox6.DataSource = uredjaji;
                comboBox6.DisplayMember = "Adresa";
                comboBox6.ValueMember = "Id";
            }
        }
        public void popuniTabelu()
        {
            List<DTOs.TransakcijaPregled> listaTransakcija = DTOmanager.vratiSveTransakcije();
            dataGridView7.DataSource = new BindingList<DTOs.TransakcijaPregled>(listaTransakcija);
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

        private void cmdDodajTransakciju_Click(object sender, EventArgs e)
        {
            if (!proveriUnos(textBox8) && !proveriUnosComboBox(comboBox4, comboBox5, comboBox6))
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
                return;
            }
            DTOs.TransakcijaBasic o = new DTOs.TransakcijaBasic
            {
                Iznos = (decimal)numericUpDown9.Value,
                Valuta = textBox8.Text,
                DatumVreme = dateTimePicker5.Value,
                Vrsta = (VrstaTransakcije)Enum.Parse(typeof(VrstaTransakcije), comboBox4.SelectedItem.ToString()),
                UredjajId = ((Uredjaj)comboBox6.SelectedItem).Id,
                KarticaId = ((Kartica)comboBox5.SelectedItem).KarticaId
            };
            DTOmanager.dodajTransakciju(o);
            MessageBox.Show("Transakcija dodata!");
            popuniTabelu();
        }

        private void cmdPrikaziTransakcije_Click(object sender, EventArgs e)
        {
            if (dataGridView7.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali transakciju za prikaz!");
                return;
            }
            int id = (int)dataGridView7.SelectedRows[0].Cells["Id"].Value;
            DTOs.TransakcijaBasic transakcija = DTOmanager.vratiTransakciju(id);
            MessageBox.Show("Id: " + transakcija.Id + "\nIznos: " + transakcija.Iznos +  " \nValuta: " + transakcija.Valuta  + "\nVreme izvrsenja: " + transakcija.DatumVreme + "\n Uredjaj: "+ transakcija.UredjajId);
        }

        private void cmdAzurirajTransakciju_Click(object sender, EventArgs e)
        {
                if (!proveriUnos(textBox8) || !proveriUnosComboBox(comboBox4, comboBox5, comboBox6))
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                    return;
                }
                if (dataGridView7.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Niste izabrali transakciju za izmenu!");
                    return;
                }
                    int id = (int)dataGridView7.SelectedRows[0].Cells["Id"].Value;
                    DTOs.TransakcijaBasic transakcija = new DTOs.TransakcijaBasic();
                    transakcija.Id = id;
                    transakcija.KarticaId = ((Kartica)comboBox5.SelectedItem).KarticaId;
                    transakcija.UredjajId = ((Uredjaj)comboBox6.SelectedItem).Id;
                    transakcija.Iznos = (decimal)numericUpDown9.Value;
                    transakcija.Valuta = textBox8.Text;
                    transakcija.DatumVreme = dateTimePicker5.Value;
                    transakcija.Vrsta = (VrstaTransakcije)Enum.Parse(typeof(VrstaTransakcije), comboBox4.SelectedItem.ToString());
                    DTOmanager.azurirajTransakciju(transakcija);
                    MessageBox.Show("Transakcija je uspesno azurirana!"); 
                    popuniTabelu();
        }

        private void cmdObrisiTransakciju_Click(object sender, EventArgs e)
        {
            if (dataGridView7.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali transakciju za brisanje!");
                return;
            }
            int id = (int)dataGridView7.SelectedRows[0].Cells["Id"].Value;
            DTOmanager.obrisiTransakciju(id);
            MessageBox.Show("Transakcija je uspesno obrisana!");
            popuniTabelu();
        }
    }
}
