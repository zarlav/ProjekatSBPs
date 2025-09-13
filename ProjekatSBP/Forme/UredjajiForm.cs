using FluentNHibernate.Cfg;
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

namespace ProjekatSBP
{
    public partial class UredjajiForm : Form
    {
        public UredjajiForm()
        {
            InitializeComponent();
        }
        private void UredjajiForm_Load(object sender, EventArgs e)
        {
            popuniTabelu();
            using (var s = DataLayer.GetSession())
            {
                var banke = s.Query<Entiteti.Banka>().ToList();
                ListaBanakaCB.DataSource = banke;
                ListaBanakaCB.DisplayMember = "Naziv";
                ListaBanakaCB.ValueMember = "Id";

                var filijale = s.Query<Filijala>().ToList();
                listaFilijalaCB.DataSource = filijale;
                listaFilijalaCB.DisplayMember = "Adresa";
                listaFilijalaCB.ValueMember = "Id";
            }
            StatusRadaCB.SelectedIndex = 0;
        }
        public void popuniTabelu()
        {
            List<DTOs.UredjajPregled> listaUredjaja = DTOmanager.vratiSveUredjaje();
            var bankomati = listaUredjaja.OfType<BankomatPregled>().ToList();
            var kiosci = listaUredjaja.OfType<MultifunkcionalniUredjajPregled>().ToList();
            var uplatni = listaUredjaja.OfType<UplatniAutomatPregled>().ToList();

            dataGridView1.DataSource = new BindingList<BankomatPregled>(bankomati);
            dataGridView2.DataSource = new BindingList<UplatniAutomatPregled>(uplatni);
            dataGridView3.DataSource = new BindingList<MultifunkcionalniUredjajPregled>(kiosci);
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
                numericUpDown11, comboBox3, numericUpDown1
            };
            var grupa2 = new Control[]
            {
                checkBox1, checkBox2, checkedListBox2
            };
            var grupa3 = new Control[]
            {
                checkBox3, checkedListBox1
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
        private void rbBankomat_CheckedChanged(object sender, EventArgs e)
        {
            omoguciKomande(1);
        }
        private void rbMultKiosk_CheckedChanged(object sender, EventArgs e)
        {
            omoguciKomande(2);
        }
        private void rbUplatniAutomat_CheckedChanged(object sender, EventArgs e)
        {
            omoguciKomande(3);
        }
        private void cmdDodajUredjaj_Click(object sender, EventArgs e)
        {
            if (!proveriUnos(AdresaUredjajaTB, ProizvodjacUredjajaTB, KomentarTB) ||
                !proveriUnosComboBox(listaFilijalaCB, ListaBanakaCB, StatusRadaCB))
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
                return;
            }

            DTOs.UredjajBasic uredjaj = null;
            if (rbBankomat.Checked)
            {
                DTOs.BankomatBasic b = new DTOs.BankomatBasic()
                {
                    Adresa = AdresaUredjajaTB.Text,
                    Proizvodjac = ProizvodjacUredjajaTB.Text,
                    Komentar = KomentarTB.Text,
                    Status = (StatusRada)Enum.Parse(typeof(StatusRada), StatusRadaCB.SelectedItem.ToString()),
                    DatumInstalacije = dateTimePicker2.Value,
                    DatumServisa = dateTimePicker1.Value,
                    GeogrSirina = (double)numericUpDown3.Value,
                    GeogrDuzina = (double)numericUpDown2.Value,
                    BankaId = ((Banka)ListaBanakaCB.SelectedItem).Id,
                    Filijale = new List<int> { ((Filijala)listaFilijalaCB.SelectedItem).Id },
                    brojNovcanica = new List<DTOs.BrojNovcanicaBasic>()
                };

                foreach (string item in listBox10.Items)
                {
                    string[] parts = item.Split('-');
                    int tip = Convert.ToInt32(parts[0].Trim().Split(' ')[0]);
                    int brojKomada = Convert.ToInt32(parts[1].Trim().Split(' ')[0]);

                    DTOs.ApoenBasic apoen = new DTOs.ApoenBasic()
                    {
                        NominalnaVrednost = tip,
                        Kolicina = brojKomada
                    };

                    DTOs.BrojNovcanicaBasic bn = new DTOs.BrojNovcanicaBasic()
                    {
                        BrojKomada = brojKomada,
                        ApoenId = apoen.Id,
                        VrednostApoena = apoen.NominalnaVrednost
                    };

                    b.brojNovcanica.Add(bn);
                }

                uredjaj = b;
            }
            else if (rbUplatniAutomat.Checked)
            {
                DTOs.UplatniAutomatBasic ua = new DTOs.UplatniAutomatBasic()
                {
                    Adresa = AdresaUredjajaTB.Text,
                    Proizvodjac = ProizvodjacUredjajaTB.Text,
                    Komentar = KomentarTB.Text,
                    Status = (StatusRada)Enum.Parse(typeof(StatusRada), StatusRadaCB.SelectedItem.ToString()),
                    DatumInstalacije = dateTimePicker2.Value,
                    DatumServisa = dateTimePicker1.Value,
                    GeogrSirina = (double)numericUpDown3.Value,
                    GeogrDuzina = (double)numericUpDown2.Value,
                    BankaId = ((Banka)ListaBanakaCB.SelectedItem).Id,
                    Filijale = new List<int> { ((Filijala)listaFilijalaCB.SelectedItem).Id },
                    ValidatorZaPapirniNovac = checkBox3.Checked,
                    PodrzaneVrsteUplate = checkedListBox1.CheckedItems.Cast<string>().ToList()
                };

                uredjaj = ua;
            }
            else if (rbMultKiosk.Checked)
            {
                DTOs.MultifunkcionalniUredjajBasic mk = new DTOs.MultifunkcionalniUredjajBasic()
                {
                    Adresa = AdresaUredjajaTB.Text,
                    Proizvodjac = ProizvodjacUredjajaTB.Text,
                    Komentar = KomentarTB.Text,
                    Status = (StatusRada)Enum.Parse(typeof(StatusRada), StatusRadaCB.SelectedItem.ToString()),
                    DatumInstalacije = dateTimePicker2.Value,
                    DatumServisa = dateTimePicker1.Value,
                    GeogrSirina = (double)numericUpDown3.Value,
                    GeogrDuzina = (double)numericUpDown2.Value,
                    BankaId = ((Banka)ListaBanakaCB.SelectedItem).Id,
                    Filijale = new List<int> { ((Filijala)listaFilijalaCB.SelectedItem).Id },
                    PrisustvoSkenera = checkBox1.Checked,
                    PrisustvoStampaca = checkBox2.Checked,
                    PodrzaniServis = checkedListBox1.CheckedItems.Cast<string>().ToList()
                };

                uredjaj = mk;
            }
            else
            {
                MessageBox.Show("Niste izabrali tip uredjaja!");
                return;
            }
            DTOmanager.dodajUredjaj(uredjaj);

            MessageBox.Show("Uredjaj je uspesno dodat!");
            popuniTabelu();
        }


        private void cmdPrikazUredjaja_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 && dataGridView2.SelectedRows.Count == 0 && dataGridView3.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali uredjaj za prikaz!");
                return;
            }
            else if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["id"].Value;
                DTOs.UredjajBasic uredjaj = DTOmanager.vratiUredjaj(id);
                if(uredjaj is  DTOs.BankomatBasic bankomat)
                {
                    string novcanice = string.Join(", ",
                     bankomat.brojNovcanica.Select(bn => $"{bn.VrednostApoena} x {bn.BrojKomada}"));
                    MessageBox.Show("Maksimalni iznos: " + bankomat.MaxIznos + "Broj novcanica: " + novcanice);
                }
                else
                {
                    MessageBox.Show("Nepoznat tip [bankomat]");
                }
            }
            else if( dataGridView2.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView2.SelectedRows[0].Cells["id"].Value;
                DTOs.UredjajBasic uredjaj = DTOmanager.vratiUredjaj(id);
                if (uredjaj is DTOs.UplatniAutomatBasic ua)
                {
                    string vrste = string.Join(", ", ua.PodrzaneVrsteUplate);
                    MessageBox.Show("Podrzane vrste uplata: " + vrste + "\nValidator za papirni novac: " + ua.ValidatorZaPapirniNovac);
                }
                else
                {
                    MessageBox.Show("Nepoznat tip [UA]");
                }
            }
            else if(dataGridView3.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView3.SelectedRows[0].Cells["id"].Value;
                DTOs.UredjajBasic uredjaj = DTOmanager.vratiUredjaj(id);
                if (uredjaj is DTOs.MultifunkcionalniUredjajBasic mk)
                {
                    string servisi = mk.PodrzaniServis != null
                        ? string.Join(", ", mk.PodrzaniServis)
                        : "Nema podrzanih servisa!";
                    MessageBox.Show("Podrzani servisi: " + servisi + "\nPrisustvo skenera: " + mk.PrisustvoSkenera + "\n Prisustvno stampaca: " + mk.PrisustvoStampaca);
                }
                else
                {
                    MessageBox.Show("Nepoznat tip [MK]");
                }
            }
        }

        private void cmdObrisiUredjaj_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0 && dataGridView2.SelectedRows.Count == 0 && dataGridView3.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali uredjaj za brisanje!");
                return;
            }
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                DTOmanager.obrisiUredjaj(id);
            }
            else if(dataGridView2.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView2.SelectedRows[0].Cells["Id"].Value;
                DTOmanager.obrisiUredjaj(id);
            }
            else if(dataGridView3.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView3.SelectedRows[0].Cells["Id"].Value;
                DTOmanager.obrisiUredjaj(id);
            }
            popuniTabelu();
            MessageBox.Show("Uredjaj je uspesno obrisan!");
        }

        private void cmdAzurirajUredjaj_Click(object sender, EventArgs e)
        {
            if (!proveriUnos(AdresaUredjajaTB, ProizvodjacUredjajaTB, KomentarTB) ||
                !proveriUnosComboBox(listaFilijalaCB, ListaBanakaCB, StatusRadaCB))
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
                return;
            }

            DTOs.UredjajBasic uredjaj = null;
            if (rbBankomat.Checked && dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                DTOs.BankomatBasic bankomat = new DTOs.BankomatBasic();
                bankomat.Id = id;
                bankomat.Adresa = AdresaUredjajaTB.Text;
                bankomat.Proizvodjac = ProizvodjacUredjajaTB.Text;
                bankomat.Komentar = KomentarTB.Text;
                bankomat.Status = (StatusRada)Enum.Parse(typeof(StatusRada), StatusRadaCB.SelectedItem.ToString());
                bankomat.DatumInstalacije = dateTimePicker2.Value;
                bankomat.DatumServisa = dateTimePicker1.Value;
                bankomat.GeogrSirina = (double)numericUpDown3.Value;
                bankomat.GeogrDuzina = (double)numericUpDown2.Value;
                bankomat.BankaId = ((Banka)ListaBanakaCB.SelectedItem).Id;
                bankomat.Filijale = new List<int> { ((Filijala)listaFilijalaCB.SelectedItem).Id };
                bankomat.brojNovcanica = new List<DTOs.BrojNovcanicaBasic>();

                foreach (string item in listBox10.Items)
                {
                    string[] parts = item.Split('-');
                    int tip = Convert.ToInt32(parts[0].Trim().Split(' ')[0]);
                    int brojKomada = Convert.ToInt32(parts[1].Trim().Split(' ')[0]);

                    DTOs.ApoenBasic apoen = new DTOs.ApoenBasic()
                    {
                        NominalnaVrednost = tip,
                        Kolicina = brojKomada
                    };

                    DTOs.BrojNovcanicaBasic bn = new DTOs.BrojNovcanicaBasic()
                    {
                        BrojKomada = brojKomada,
                        ApoenId = apoen.Id,
                        VrednostApoena = apoen.NominalnaVrednost
                    };

                    bankomat.brojNovcanica.Add(bn);
                }

                uredjaj = bankomat;
            }
            else if (rbUplatniAutomat.Checked && dataGridView2.SelectedRows.Count>0)
            {
                int id = (int)dataGridView2.SelectedRows[0].Cells["Id"].Value;
                DTOs.UplatniAutomatBasic ua = new DTOs.UplatniAutomatBasic();
                ua.Id = id;
                ua.Adresa = AdresaUredjajaTB.Text;
                ua.Proizvodjac = ProizvodjacUredjajaTB.Text;
                ua.Komentar = KomentarTB.Text;
                ua.Status = (StatusRada)Enum.Parse(typeof(StatusRada), StatusRadaCB.SelectedItem.ToString());
                ua.DatumInstalacije = dateTimePicker2.Value;
                ua.DatumServisa = dateTimePicker1.Value;
                ua.GeogrSirina = (double)numericUpDown3.Value;
                ua.GeogrDuzina = (double)numericUpDown2.Value;
                ua.BankaId = ((Banka)ListaBanakaCB.SelectedItem).Id;
                ua.Filijale = new List<int> { ((Filijala)listaFilijalaCB.SelectedItem).Id };
                ua.ValidatorZaPapirniNovac = checkBox3.Checked;
                ua.PodrzaneVrsteUplate = checkedListBox1.CheckedItems.Cast<string>().ToList();

                uredjaj = ua;
            }
            else if (rbMultKiosk.Checked && dataGridView3.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView3.SelectedRows[0].Cells["Id"].Value;
                DTOs.MultifunkcionalniUredjajBasic mk = new DTOs.MultifunkcionalniUredjajBasic();
                mk.Id = id;
                mk.Adresa = AdresaUredjajaTB.Text;
                mk.Proizvodjac = ProizvodjacUredjajaTB.Text;
                mk.Komentar = KomentarTB.Text;
                mk.Status = (StatusRada)Enum.Parse(typeof(StatusRada), StatusRadaCB.SelectedItem.ToString());
                mk.DatumInstalacije = dateTimePicker2.Value;
                mk.DatumServisa = dateTimePicker1.Value;
                mk.GeogrSirina = (double)numericUpDown3.Value;
                mk.GeogrDuzina = (double)numericUpDown2.Value;
                mk.BankaId = ((Banka)ListaBanakaCB.SelectedItem).Id;
                mk.Filijale = new List<int> { ((Filijala)listaFilijalaCB.SelectedItem).Id };
                mk.PrisustvoSkenera = checkBox1.Checked;
                mk.PrisustvoStampaca = checkBox2.Checked;
                mk.PodrzaniServis = checkedListBox1.CheckedItems.Cast<string>().ToList();
                uredjaj = mk;
            }
            else
            {
                MessageBox.Show("Niste izabrali tip uredjaja!");
                return;
            }
            DTOmanager.azurirajUredjaj(uredjaj);

            MessageBox.Show("Uredjaj je uspesno azuriran!");
            popuniTabelu();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Izaberite apoen!");
                return;
            }
            int vrednost = Convert.ToInt32(comboBox3.SelectedItem);
            int brojKomada = (int)numericUpDown1.Value;
            foreach (var item in listBox10.Items)
            {
                if (item.ToString().StartsWith(vrednost.ToString() + " RSD"))
                {
                    MessageBox.Show("Ovaj apoen je vec dodat!");
                    return;
                }
            }
            listBox10.Items.Add($"{vrednost} RSD - {brojKomada} kom");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox10.SelectedItem != null)
            {
                listBox10.Items.Remove(listBox10.SelectedItem);
            }
            else
            {
                MessageBox.Show("Niste izabrali apoen za brisanje!");
            }
        }
    }
}
