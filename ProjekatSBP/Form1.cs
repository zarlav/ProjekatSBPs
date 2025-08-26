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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace ProjekatSBP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        private List<RadnoVreme> radnaVremena = new List<RadnoVreme>();
        private void Form1_Load(object sender, EventArgs e)
        {
            using (var s = DataLayer.GetSession())
            {
                var banke = s.Query<Entiteti.Banka>().ToList();

                ListaBanakaCB.DataSource = banke;
                ListaBanakaCB.DisplayMember = "Naziv";
                ListaBanakaCB.ValueMember = "Id";
                comboBox1.DataSource = banke;
                comboBox1.DisplayMember = "Naziv";
                comboBox1.ValueMember = "Id";
                comboBox7.DataSource = banke;
                comboBox7.DisplayMember = "Naziv";
                comboBox7.ValueMember = "Id";

                var filijale = s.Query<Filijala>().ToList();
                listaFilijalaCB.DataSource = filijale;
                listaFilijalaCB.DisplayMember = "Adresa";
                listaFilijalaCB.ValueMember = "Id";

                var uredjaji = s.Query<Uredjaj>().ToList();
                comboBox6.DataSource = uredjaji;
                comboBox6.DisplayMember = "Adresa";
                comboBox6.ValueMember = "Id";

                var kartice = s.Query<Kartica>().ToList();
                comboBox5.DataSource = kartice;
                comboBox5.DisplayMember = "BrojKartice";
                comboBox5.ValueMember = "KarticaId";

                var racuni = s.Query<Racun>().ToList();
                comboBox2.DataSource = racuni;
                comboBox2.DisplayMember = "RacunId";
                comboBox2.ValueMember = "RacunId";

                var klijenti = s.Query<Klijent>().ToList();
                comboBox8.DataSource = klijenti;
                comboBox8.DisplayMember = "id";
                comboBox8.ValueMember = "id";

            }
            StatusRadaCB.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

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
            var grupa4 = new Control[]
            {
                textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, listBox6, listBox7 
            };
            var grupa5 = new Control[]
            { 
                textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, listBox5 
            };
            var grupa6 = new Control[] 
            {
                textBox27, textBox28, textBox29, textBox30, textBox31, textBox32, listBox8, listBox9
            };
            foreach (var ctrl in grupa1.Concat(grupa2).Concat(grupa3)
                                       .Concat(grupa4).Concat(grupa5).Concat(grupa6))
                ctrl.Visible = false;

            switch (rbr)
            {
                case 1: foreach (var ctrl in grupa1) ctrl.Visible = true; break;
                case 2: foreach (var ctrl in grupa2) ctrl.Visible = true; break;
                case 3: foreach (var ctrl in grupa3) ctrl.Visible = true; break;
                case 4: foreach (var ctrl in grupa4) ctrl.Visible = true; break;
                case 5: foreach (var ctrl in grupa5) ctrl.Visible = true; break;
                case 6: foreach (var ctrl in grupa6) ctrl.Visible = true; break;
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
        private void rbFizLice_CheckedChanged(object sender, EventArgs e)
        {
            omoguciKomande(5);
        }

        private void rbPravnoLice_CheckedChanged(object sender, EventArgs e)
        {
            omoguciKomande(4);
        }

        private void rbOrganizacija_CheckedChanged(object sender, EventArgs e)
        {
            omoguciKomande(6);
        }
        private void cmdDodajUredjaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (!proveriUnos(AdresaUredjajaTB, ProizvodjacUredjajaTB, KomentarTB) || !proveriUnosComboBox(listaFilijalaCB, ListaBanakaCB, StatusRadaCB))
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                    return;
                }
                ISession s = DataLayer.GetSession();
                Uredjaj u = new Uredjaj();
                if (rbBankomat.Checked)
                {
                    Bankomat b = new Bankomat()
                    {
                        Adresa = AdresaUredjajaTB.Text,
                        Proizvodjac = ProizvodjacUredjajaTB.Text,
                        Komentar = KomentarTB.Text,
                        Status = (StatusRada)Enum.Parse(typeof(StatusRada), StatusRadaCB.SelectedItem.ToString()),
                        DatumInstalacije = dateTimePicker2.Value,
                        DatumServisa = dateTimePicker1.Value,
                        GeogrSirina = (double)numericUpDown3.Value,
                        GeogrDuzina = (double)numericUpDown2.Value,
                        PripadaBanci = (Banka)ListaBanakaCB.SelectedItem,
                        Filijale = new List<Filijala>
                        { 
                            (Filijala)listaFilijalaCB.SelectedItem
                        },
                        MaxIznos = (int)numericUpDown11.Value
                    };
                    u = b;
                    s.Save(u);
                    foreach (string item in listBox10.Items)
                    {
                        string[] parts = item.Split('-');
                        int vrednost = Convert.ToInt32(parts[0].Trim().Split(' ')[0]);
                        int brojKomada = Convert.ToInt32(parts[1].Trim().Split(' ')[0]);

                        Apoen apoen = s.Query<Apoen>().FirstOrDefault(a => a.Vrednost == vrednost);
                        if (apoen == null)
                        {
                            apoen = new Apoen { Vrednost = vrednost };
                            s.Save(apoen);
                        }
                        BrojNovcanicaUBankomat bn = new BrojNovcanicaUBankomat
                        {
                            BrojKomada = brojKomada,
                            Uredjaj = u,
                            Apoen = apoen
                        };
                        b.brojNovcanica.Add(bn);
                    }
                    s.SaveOrUpdate(u);
                    s.Flush();
                }
                else if (rbUplatniAutomat.Checked)
                {
                    u = new UplatniAutomat()
                    {
                        Adresa = AdresaUredjajaTB.Text,
                        Proizvodjac = ProizvodjacUredjajaTB.Text,
                        Komentar = KomentarTB.Text,
                        Status = (StatusRada)Enum.Parse(typeof(StatusRada), StatusRadaCB.SelectedItem.ToString()),
                        DatumInstalacije = dateTimePicker2.Value,
                        DatumServisa = dateTimePicker1.Value,
                        GeogrSirina = (double)numericUpDown3.Value,
                        GeogrDuzina = (double)numericUpDown2.Value,
                        PripadaBanci = (Banka)ListaBanakaCB.SelectedItem,
                        ValidatorZaPapirniNovac = checkBox3.Checked,
                        PodrzaneVrsteUplate = checkedListBox1.CheckedItems.Cast<string>().Select(i => new VrstaUplate { Naziv = i.ToString() }).ToList()
                    };
                }
                else if (rbMultKiosk.Checked)
                {
                    u = new MultiFunkKiosk()
                    {
                        Adresa = AdresaUredjajaTB.Text,
                        Proizvodjac = ProizvodjacUredjajaTB.Text,
                        Komentar = KomentarTB.Text,
                        Status = (StatusRada)Enum.Parse(typeof(StatusRada), StatusRadaCB.SelectedItem.ToString()),
                        DatumInstalacije = dateTimePicker2.Value,
                        DatumServisa = dateTimePicker1.Value,
                        GeogrSirina = (double)numericUpDown3.Value,
                        GeogrDuzina = (double)numericUpDown2.Value,
                        PripadaBanci = (Banka)ListaBanakaCB.SelectedItem,
                        PrisustvoSkenera = checkBox1.Checked,
                        PrisustvoStampaca = checkBox2.Checked,
                        PodrzaniServis = checkedListBox2.CheckedItems.Cast<string>().Select(i => new Servis { Naziv = i.ToString() }).ToList()
                    };
                }
                else
                {
                    MessageBox.Show("Niste izabrali tip uredjaja!");
                    return;
                }
                s.SaveOrUpdate(u);
                s.Flush();
                s.Close();
                MessageBox.Show("Uredjaj je uspesno dodat!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdPrikazUredjaja_Click(object sender, EventArgs e)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var bankomati = s.Query<Bankomat>()
                        .Select(b => new
                        {
                            UredjajId = b.Id,
                            Tip = "Bankomat",
                            b.Adresa,
                            b.Status,
                            b.Proizvodjac,
                            b.MaxIznos,
                            b.GeogrDuzina,
                            b.GeogrSirina,
                            b.Komentar,
                            b.DatumInstalacije,
                            b.DatumServisa,
                            Banka = b.PripadaBanci.Naziv,
                            Filijala = string.Join(", ", b.Filijale.Select(f => f.Adresa))
                        })
                        .ToList();
                    var bankomatiSaNovcanicama = bankomati.Select(b =>
                    {
                        var novcanice = s.Query<BrojNovcanicaUBankomat>()
                            .Where(bn => bn.Uredjaj.Id == b.UredjajId)
                            .Select(bn => $"{bn.Apoen.Vrednost} x {bn.BrojKomada}")
                            .ToList();

                        return new
                        {
                            b.UredjajId,
                            b.Tip,
                            b.Adresa,
                            b.Status,
                            b.Proizvodjac,
                            b.MaxIznos,
                            b.GeogrDuzina,
                            b.GeogrSirina,
                            b.Komentar,
                            b.DatumInstalacije,
                            b.DatumServisa,
                            b.Banka,
                            b.Filijala,
                            BrojNovcanica = string.Join(", ", novcanice)
                        };
                    }).ToList();

                    dataGridView1.DataSource = bankomatiSaNovcanicama;
                    var automati = s.Query<UplatniAutomat>()
                        .Select(a => new
                        {
                            a.Id,
                            Tip = "Uplatni automat",
                            a.Adresa,
                            a.Status,
                            a.Proizvodjac,
                            a.ValidatorZaPapirniNovac,
                            a.GeogrDuzina,
                            a.GeogrSirina,
                            a.Komentar,
                            a.DatumInstalacije,
                            a.DatumServisa,
                            Banka = a.PripadaBanci.Naziv,
                            Filijala = string.Join(", ", a.Filijale.Select(f => f.Adresa))
                        })
                        .ToList();

                    var automatiSaUplatama = automati.Select(a =>
                    {
                        var vrste = s.Query<VrstaUplate>()
                            .Where(v => v.UplatniAutomati.Any(ua => ua.Id == a.Id))
                            .Select(v => v.Naziv)
                            .ToList();

                        return new
                        {
                            a.Id,
                            a.Tip,
                            a.Adresa,
                            a.Status,
                            a.Proizvodjac,
                            a.ValidatorZaPapirniNovac,
                            a.GeogrDuzina,
                            a.GeogrSirina,
                            a.Komentar,
                            a.DatumInstalacije,
                            a.DatumServisa,
                            a.Banka,
                            a.Filijala,
                            PodrzaneVrsteUplate = string.Join(", ", vrste)
                        };
                    }).ToList();

                    dataGridView2.DataSource = automatiSaUplatama;
                    var kiosci = s.Query<MultiFunkKiosk>()
                        .Select(k => new
                        {
                            k.Id,
                            Tip = "Multifunkcionalni kiosk",
                            k.Adresa,
                            k.Status,
                            k.Proizvodjac,
                            k.PrisustvoSkenera,
                            k.PrisustvoStampaca,
                            k.GeogrDuzina,
                            k.GeogrSirina,
                            k.Komentar,
                            k.DatumInstalacije,
                            k.DatumServisa,
                            Banka = k.PripadaBanci.Naziv,
                            Filijala = string.Join(", ", k.Filijale.Select(f => f.Adresa))
                        })
                        .ToList();

                    var kiosciSaServisima = kiosci.Select(k =>
                    {
                        var servisi = s.Query<Servis>()
                            .Where(ps => ps.MultiKiosci.Any(ki => ki.Id == k.Id))
                            .Select(ps => ps.Naziv)
                            .ToList();

                        return new
                        {
                            k.Id,
                            k.Tip,
                            k.Adresa,
                            k.Status,
                            k.Proizvodjac,
                            k.PrisustvoSkenera,
                            k.PrisustvoStampaca,
                            k.GeogrDuzina,
                            k.GeogrSirina,
                            k.Komentar,
                            k.DatumInstalacije,
                            k.DatumServisa,
                            k.Banka,
                            k.Filijala,
                            Servisi = string.Join(", ", servisi)
                        };
                    }).ToList();

                    dataGridView3.DataSource = kiosciSaServisima;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdAzurirajUredjaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (!proveriUnos(AdresaUredjajaTB, ProizvodjacUredjajaTB, KomentarTB) || !proveriUnosComboBox(listaFilijalaCB, ListaBanakaCB, StatusRadaCB))
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                    return;
                }
                using (ISession s = DataLayer.GetSession())
                using (ITransaction tx = s.BeginTransaction())
                {
                    if (dataGridView1.SelectedRows.Count > 0 && rbBankomat.Checked)
                    {
                        int id = (int)dataGridView1.SelectedRows[0].Cells["UredjajId"].Value;
                        Bankomat b = s.Get<Bankomat>(id);

                        if (b != null)
                        {
                            b.Adresa = AdresaUredjajaTB.Text;
                            b.Proizvodjac = ProizvodjacUredjajaTB.Text;
                            b.Komentar = KomentarTB.Text;
                            b.Status = (StatusRada)Enum.Parse(typeof(StatusRada), StatusRadaCB.SelectedItem.ToString());
                            b.DatumInstalacije = dateTimePicker1.Value;
                            b.DatumServisa = dateTimePicker2.Value;
                            b.GeogrSirina = (float)numericUpDown2.Value;
                            b.GeogrDuzina = (float)numericUpDown3.Value;

                            var banka = (Banka)ListaBanakaCB.SelectedItem;
                            b.PripadaBanci = s.Merge(banka);

                            var filijala = (Filijala)listaFilijalaCB.SelectedItem;
                            if (!b.Filijale.Any(f => f.Id == filijala.Id))
                            {
                                b.Filijale.Add(s.Merge(filijala));
                            }

                            b.MaxIznos = (float)numericUpDown1.Value;

                            Apoen apoen = new Apoen()
                            {
                                Vrednost = Convert.ToInt32(comboBox3.SelectedItem)
                            };
                            s.Save(apoen);

                            BrojNovcanicaUBankomat broj = new BrojNovcanicaUBankomat()
                            {
                                BrojKomada = (int)numericUpDown1.Value,
                                Uredjaj = b,
                                Apoen = apoen
                            };
                            s.Save(broj);

                            s.Update(b);
                            tx.Commit();
                        }
                    }
                    else if (dataGridView2.SelectedRows.Count > 0 && rbUplatniAutomat.Checked)
                    {
                        int id = (int)dataGridView2.SelectedRows[0].Cells["Id"].Value;
                        UplatniAutomat a = s.Get<UplatniAutomat>(id);

                        if (a != null)
                        {
                            a.Adresa = AdresaUredjajaTB.Text;
                            a.Proizvodjac = ProizvodjacUredjajaTB.Text;
                            a.Komentar = KomentarTB.Text;
                            a.Status = (StatusRada)Enum.Parse(typeof(StatusRada), StatusRadaCB.SelectedItem.ToString());
                            a.DatumInstalacije = dateTimePicker1.Value;
                            a.DatumServisa = dateTimePicker2.Value;
                            a.GeogrSirina = (float)numericUpDown2.Value;
                            a.GeogrDuzina = (float)numericUpDown3.Value;

                            var banka = (Banka)ListaBanakaCB.SelectedItem;
                            a.PripadaBanci = s.Merge(banka);

                            var filijala = (Filijala)listaFilijalaCB.SelectedItem;
                            if (!a.Filijale.Any(f => f.Id == filijala.Id))
                            {
                                a.Filijale.Add(s.Merge(filijala));
                            }

                            a.ValidatorZaPapirniNovac = checkBox3.Checked;

                            s.Update(a);
                            tx.Commit();
                        }
                    }
                    else if (dataGridView3.SelectedRows.Count > 0 && rbMultKiosk.Checked)
                    {
                        int id = (int)dataGridView3.SelectedRows[0].Cells["Id"].Value;
                        MultiFunkKiosk k = s.Get<MultiFunkKiosk>(id);

                        if (k != null)
                        {
                            k.Adresa = AdresaUredjajaTB.Text;
                            k.Proizvodjac = ProizvodjacUredjajaTB.Text;
                            k.Komentar = KomentarTB.Text;
                            k.Status = (StatusRada)Enum.Parse(typeof(StatusRada), StatusRadaCB.SelectedItem.ToString());
                            k.DatumInstalacije = dateTimePicker1.Value;
                            k.DatumServisa = dateTimePicker2.Value;
                            k.GeogrSirina = (float)numericUpDown2.Value;
                            k.GeogrDuzina = (float)numericUpDown3.Value;

                            var banka = (Banka)ListaBanakaCB.SelectedItem;
                            k.PripadaBanci = s.Merge(banka);

                            var filijala = (Filijala)listaFilijalaCB.SelectedItem;
                            if (!k.Filijale.Any(f => f.Id == filijala.Id))
                            {
                                k.Filijale.Add(s.Merge(filijala));
                            }

                            k.PrisustvoSkenera = checkBox1.Checked;
                            k.PrisustvoStampaca = checkBox2.Checked;

                            s.Update(k);
                            tx.Commit();
                            MessageBox.Show("Uredjaj je uspesno azuriran!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Niste izabrali uredjaj za izmenu!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdObrisiUredjaj_Click(object sender, EventArgs e)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                using (ITransaction tx = s.BeginTransaction())
                {
                    Uredjaj uredjaj = null;
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        int id = (int)dataGridView1.SelectedRows[0].Cells["UredjajId"].Value;
                        uredjaj = s.Get<Bankomat>(id);
                    }
                    else if (dataGridView2.SelectedRows.Count == 1)
                    {
                        int id = (int)dataGridView2.SelectedRows[0].Cells["id"].Value;
                        uredjaj = s.Get<UplatniAutomat>(id);
                    }
                    else if (dataGridView3.SelectedRows.Count == 1)
                    {
                        int id = (int)dataGridView3.SelectedRows[0].Cells["id"].Value;
                        uredjaj = s.Get<MultiFunkKiosk>(id);
                    }
                    else
                    {
                        MessageBox.Show("Niste izabrali uredjaj za brisanje!");
                        return;
                    }
                    if (uredjaj == null)
                    {
                        MessageBox.Show("Uredjaj nije pronadjen!");
                        return;
                    }
                    s.Delete(uredjaj);
                    tx.Commit();

                    MessageBox.Show("Uredjaj je uspešno obrisan!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }
        private void cmdDodajBanku_Click(object sender, EventArgs e)
        {
            try
            {
                if (!proveriUnos(textBox2, textBox3, textBox4))
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                    return;
                }
                ISession s = DataLayer.GetSession();
                Banka b = new Banka();
                b.Naziv = textBox3.Text;
                b.Adresa = textBox2.Text;
                b.WebAdresa = textBox4.Text;
                foreach (var item in listBox2.Items)
                {
                    b.Telefoni.Add(item.ToString());
                }
                foreach (var item in listBox3.Items)
                {
                    b.EmailAdrese.Add(item.ToString());
                }
                s.SaveOrUpdate(b);
                s.Flush();
                s.Close();
                MessageBox.Show("Banka je uspesno dodata!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdPrikazBanke_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                var banke = new BindingList<Banka>(s.Query<Banka>().ToList())
                    .Select(b => new
                    {
                        b.Id,
                        b.Naziv,
                        b.Adresa,
                        b.WebAdresa,
                        Telefoni = string.Join(", ", b.Telefoni),
                        EmailAdrese = string.Join(", ", b.EmailAdrese)
                    }).ToList();
                dataGridView5.DataSource = banke;
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdAzurirajBanku_Click(object sender, EventArgs e)
        {
            try
            {
                if (!proveriUnos(textBox2, textBox3, textBox4))
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                    return;
                }
                using (ISession s = DataLayer.GetSession())
                using (ITransaction tx = s.BeginTransaction())
                {
                    if (dataGridView5.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Niste izabrali banku za izmenu!");
                        return;
                    }
                    int id = (int)dataGridView5.SelectedRows[0].Cells["Id"].Value;
                    Banka b = s.Get<Banka>(id);

                    if (b != null)
                    {
                        b.Naziv = textBox3.Text;
                        b.Adresa = textBox2.Text;
                        b.WebAdresa = textBox4.Text;
                        b.Telefoni.Clear();
                        foreach (var item in listBox2.Items)
                            b.Telefoni.Add(item.ToString());
                        b.EmailAdrese.Clear();
                        foreach (var item in listBox3.Items)
                            b.EmailAdrese.Add(item.ToString());

                        s.Update(b);
                        tx.Commit();
                        MessageBox.Show("Banka je uspesno azurirana!");
                    }
                    else
                    {
                        MessageBox.Show("Banka ne postoji!");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdObrisiBanku_Click(object sender, EventArgs e)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                using (ITransaction tx = s.BeginTransaction())
                {
                    if (dataGridView5.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Niste izabrali banku za brisanje!");
                        return;
                    }
                    int id = (int)dataGridView5.SelectedRows[0].Cells["Id"].Value;
                    Banka b = s.Get<Banka>(id);
                    if (b == null)
                    {
                        MessageBox.Show("Banka nije pronadjena!");
                        return;
                    }
                    s.Delete(b);
                    tx.Commit();
                    MessageBox.Show("Banka je obrisana!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodajFilijalu_Click(object sender, EventArgs e)
        {
            try
            {
                if(!proveriUnos(textBox1) || !proveriUnosComboBox(comboBox1))
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                    return;
                }
                int redniBr = (int)numericUpDown4.Value;
                int bankaId = ((Banka)comboBox1.SelectedItem).Id;

                using (ISession s = DataLayer.GetSession())
                using (ITransaction tx = s.BeginTransaction())
                {
                    bool postoji = s.Query<Filijala>()
                        .Any(f1 => f1.RedniBrUBanci == redniBr && f1.SastojiSeOd.Id == bankaId);

                    if (postoji)
                    {
                        MessageBox.Show($"Redni broj {redniBr} u ovoj banci već postoji!");
                        return;
                    }

                    Banka banka = s.Get<Banka>(bankaId);
                    if (banka == null)
                    {
                        MessageBox.Show("Odabrana banka ne postoji!");
                        return;
                    }

                    Filijala f = new Filijala
                    {
                        Adresa = textBox1.Text,
                        RedniBrUBanci = redniBr,
                        SastojiSeOd = banka,
                        Telefoni = listBox1.Items.Cast<string>().ToList()
                    };
                    foreach (var rv in radnaVremena)
                    {
                        f.RadnaVremena.Add(new RadnoVreme
                        {
                            Dan = rv.Dan,
                            PocetnoVreme = rv.PocetnoVreme,
                            ZavrsnoVreme = rv.ZavrsnoVreme,
                            Filijala = f
                        });
                    }
                    s.Save(f);
                    tx.Commit();

                    MessageBox.Show("Filijala je uspešno dodata!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdPrikaziFilijale_Click(object sender, EventArgs e)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var filijale = s.Query<Filijala>()
                        .Fetch(f => f.RadnaVremena)
                        .ToList()
                        .Select(f => new
                        {
                            f.Id,
                            f.Adresa,
                            f.RedniBrUBanci,
                            Banka = f.SastojiSeOd.Naziv,
                            Telefoni = string.Join(", ", f.Telefoni),
                            RadnoVreme = string.Join("; ", f.RadnaVremena.Select(rv =>
                            {
                              return $"{rv.Dan}: {rv.PocetnoVreme} - {rv.ZavrsnoVreme}";
                            }))
                        })
                        .ToList();

                    dataGridView4.DataSource = filijale;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdAzurirajFilijalu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!proveriUnos(textBox1) || !proveriUnosComboBox(comboBox1))
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                    return;
                }
                using (ISession s = DataLayer.GetSession())
                using (ITransaction tx = s.BeginTransaction())
                {
                    if (dataGridView4.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Niste izabrali filijalu za izmenu!");
                        return;
                    }

                    int id = (int)dataGridView4.SelectedRows[0].Cells["Id"].Value;
                    Filijala f = s.Get<Filijala>(id);
                    if (f == null)
                    {
                        MessageBox.Show("Filijala ne postoji!");
                        return;
                    }
                    f.Adresa = textBox1.Text;
                    f.RedniBrUBanci = (int)numericUpDown4.Value;
                    f.SastojiSeOd = (Banka)comboBox1.SelectedItem;
                    f.Telefoni.Clear();
                    foreach (var item in listBox1.Items)
                        f.Telefoni.Add(item.ToString());
                    foreach (var oldRv in f.RadnaVremena.ToList())
                        s.Delete(oldRv);

                    foreach (var oldRv in f.RadnaVremena.ToList())
                    {
                        f.RadnaVremena.Remove(oldRv); 
                        s.Delete(oldRv);               
                    }
                    foreach (var rv in radnaVremena)
                    {
                        var dbRv = new RadnoVreme()
                        {
                            Dan = rv.Dan,
                            Filijala = f,
                            PocetnoVreme = rv.PocetnoVreme,
                            ZavrsnoVreme = rv.ZavrsnoVreme
                        };
                        s.Save(dbRv);
                    }

                    s.Update(f);
                    tx.Commit();

                    MessageBox.Show("Filijala je azurirana!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
            }

        }

        private void cmdObrisiFilijalu_Click(object sender, EventArgs e)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                using (ITransaction tx = s.BeginTransaction())
                {
                    if (dataGridView4.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Niste izabrali filijalu za brisanje!");
                        return;
                    }
                    int id = (int)dataGridView4.SelectedRows[0].Cells["Id"].Value;
                    Filijala f = s.Get<Filijala>(id);
                    if (f == null)
                    {
                        MessageBox.Show("Filijala nije pronadjena!");
                        return;
                    }
                    s.Delete(f);
                    tx.Commit();
                    MessageBox.Show("Filijala je obrisana!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdDodajTransakciju_Click(object sender, EventArgs e)
        {
            try
            {
                if (!proveriUnos(textBox8) && !proveriUnosComboBox(comboBox4, comboBox5, comboBox6))
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                    return;
                }
                ISession s = DataLayer.GetSession();
                Transakcija t = new Transakcija();
                t.Iznos = (decimal)numericUpDown9.Value;
                t.Valuta = textBox8.Text;
                t.DatumVreme = dateTimePicker5.Value;
                if(comboBox4.SelectedItem != null)
                    t.Vrsta = (VrstaTransakcije)Enum.Parse(typeof(VrstaTransakcije), comboBox4.SelectedItem.ToString());
                t.Uredjaj = (Uredjaj)comboBox6.SelectedItem;
                t.Kartica = (Kartica)comboBox5.SelectedItem;
                s.SaveOrUpdate(t);
                s.Flush();
                s.Close();
                MessageBox.Show("Transakcija dodata!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdPrikaziTransakcije_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                var transakcije = s.Query<Transakcija>()
                    .Select(t => new
                    {
                        t.TransakcijaId,
                        t.Iznos,
                        t.Valuta,
                        DatumVreme = t.DatumVreme.ToString("dd.MM.yyyy HH:mm"),
                        Uredjaj = t.Uredjaj.Adresa,
                        Kartica = t.Kartica.BrojKartice,
                        Vrsta = t.Vrsta.ToString()
                    }).ToList();

                dataGridView7.DataSource = transakcije;
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdAzurirajTransakciju_Click(object sender, EventArgs e)
        {
            try
            {
                if (!proveriUnos(textBox8) || !proveriUnosComboBox(comboBox4, comboBox5, comboBox6))
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                    return;
                }
                using (ISession s = DataLayer.GetSession())
                using (ITransaction tx = s.BeginTransaction())
                {
                    if (dataGridView7.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Niste izabrali transakciju za izmenu!");
                        return;
                    }
                    int id = (int)dataGridView7.SelectedRows[0].Cells["TransakcijaId"].Value;
                    Transakcija t = s.Get<Transakcija>(id);

                    if (t != null)
                    {
                        t.Valuta = textBox8.Text;
                        t.DatumVreme = dateTimePicker5.Value;
                        t.Iznos = (decimal)numericUpDown9.Value;
                        t.Uredjaj = (Uredjaj)comboBox6.SelectedItem;
                        t.Kartica = (Kartica)comboBox5.SelectedItem;
                        if (comboBox4.SelectedItem != null)
                            t.Vrsta = (VrstaTransakcije)Enum.Parse(typeof(VrstaTransakcije), comboBox4.SelectedItem.ToString());
                        s.Update(t);
                        tx.Commit();
                        MessageBox.Show("Transakcija je uspesno azurirana!");
                    }
                    else
                    {
                        MessageBox.Show("Transakcija ne postoji!");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdObrisiTransakciju_Click(object sender, EventArgs e)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                using (ITransaction tx = s.BeginTransaction())
                {
                    if (dataGridView7.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Niste izabrali transakciju za brisanje!");
                        return;
                    }
                    int id = (int)dataGridView7.SelectedRows[0].Cells["TransakcijaId"].Value;
                    Transakcija t = s.Get<Transakcija>(id);
                    if (t == null)
                    {
                        MessageBox.Show("Transakcija nije pronadjena!");
                        return;
                    }
                    s.Delete(t);
                    tx.Commit();
                    MessageBox.Show("Transakcija je uspesno obrisana!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdDodajKorisnika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Klijent k = new Klijent();
                if (rbPravnoLice.Checked)
                {
                    if (!proveriUnos(textBox19, textBox20, textBox21, textBox22, textBox23, textBox24) || int.TryParse(textBox23.Text, out _))
                    {
                        MessageBox.Show("Sva polja moraju biti popunjena!");
                        return;
                    }
                    k = new PravnoLice()
                    {
                        kontaktOsoba = textBox21.Text,
                        adresa = textBox19.Text,
                        firma = textBox20.Text,
                        delatnost = textBox22.Text,
                        pib = int.Parse(textBox23.Text),
                        maticniBr = textBox24.Text,
                        Telefoni = listBox6.Items.Cast<string>().ToList(),
                        EmailAdrese = listBox7.Items.Cast<string>().ToList()
                    };
                    k.tip = Klijent.TipKlijenta.pravno;
                }
                else if (rbFizLice.Checked)
                {
                    if (!proveriUnos(textBox13, textBox14, textBox15, textBox16, textBox17))
                    {
                        MessageBox.Show("Sva polja moraju biti popunjena!");
                        return;
                    }
                    k = new FizickoLice()
                    {
                        licnoIme = textBox15.Text,
                        prezime = textBox16.Text,
                        imeRoditelja = textBox14.Text,
                        brLicneKarte = textBox12.Text,
                        mestoIzdavanja = textBox13.Text,
                        jmbg = textBox17.Text,
                        Telefoni = listBox5.Items.Cast<string>().ToList()
                    };
                    k.tip = Klijent.TipKlijenta.fizicko;
                }
                else if (rbOrganizacija.Checked)
                {
                    if (!proveriUnos(textBox27, textBox28, textBox29, textBox30))
                    {
                        MessageBox.Show("Sva polja moraju biti popunjena!");
                        return;
                    }
                    k = new Organizacija()
                    {
                        adresa = textBox27.Text,
                        osnivac = textBox29.Text,
                        tipOrganizacije = textBox28.Text,
                        registar = textBox30.Text,
                        Telefoni = listBox9.Items.Cast<string>().ToList(),
                        EmailAdrese = listBox8.Items.Cast<string>().ToList()
                    };
                    k.tip = Klijent.TipKlijenta.organizacija;
                }
                else
                {
                    MessageBox.Show("Niste izabrali tip klijenta!");
                    return;
                }
                s.SaveOrUpdate(k);
                s.Flush();
                s.Close();
                MessageBox.Show("Klijent je uspesno dodat!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdPrikaziKorisnike_Click(object sender, EventArgs e)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var fizicka = s.Query<FizickoLice>()
                        .ToList();
                    foreach (var fl in fizicka)
                    {
                        NHibernateUtil.Initialize(fl.Telefoni);
                    }

                    var fizickaRezultat = fizicka.Select(fl => new
                    {
                        fl.id,
                        fl.licnoIme,
                        fl.prezime,
                        fl.imeRoditelja,
                        fl.brLicneKarte,
                        fl.mestoIzdavanja,
                        fl.jmbg,
                        Telefoni = string.Join(", ", fl.Telefoni)
                    }).ToList();

                    dataGridView10.DataSource = fizickaRezultat;

                    var pravna = s.Query<PravnoLice>()
                        .ToList();

                    foreach (var pl in pravna)
                    {
                        NHibernateUtil.Initialize(pl.Telefoni);
                        NHibernateUtil.Initialize(pl.EmailAdrese);
                    }

                    var pravnaRezultat = pravna.Select(pl => new
                    {
                        pl.id,
                        pl.firma,
                        pl.delatnost,
                        pl.pib,
                        pl.maticniBr,
                        pl.kontaktOsoba,
                        pl.adresa,
                        Telefoni = string.Join(", ", pl.Telefoni),
                        Emailovi = string.Join(", ", pl.EmailAdrese)
                    }).ToList();

                    dataGridView11.DataSource = pravnaRezultat;

                    var organizacije = s.Query<Organizacija>()
                        .ToList();

                    foreach (var o in organizacije)
                    {
                        NHibernateUtil.Initialize(o.Telefoni);
                        NHibernateUtil.Initialize(o.EmailAdrese);
                    }
                    var organizacijeRezultat = organizacije.Select(o => new
                    {
                        o.id,
                        o.adresa,
                        o.osnivac,
                        o.tip,
                        o.registar,
                        Telefoni = string.Join(", ", o.Telefoni),
                        Emailovi = string.Join(", ", o.EmailAdrese)
                    }).ToList();

                    dataGridView12.DataSource = organizacijeRezultat;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdAzurirajKlijenta_Click(object sender, EventArgs e)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                using (ITransaction tx = s.BeginTransaction())
                {
                    if (dataGridView11.SelectedRows.Count > 0 && rbPravnoLice.Checked)
                    {
                        if (!proveriUnos(textBox19, textBox20, textBox21, textBox22, textBox23, textBox24) || int.TryParse(textBox23.Text, out _))
                        {
                            MessageBox.Show("Sva polja moraju biti popunjena!");
                            return;
                        }
                        int id = (int)dataGridView11.SelectedRows[0].Cells["Id"].Value;
                        PravnoLice pl = s.Get<PravnoLice>(id);
                        if (pl != null)
                        {
                            pl.kontaktOsoba = textBox21.Text;
                            pl.adresa = textBox19.Text;
                            pl.firma = textBox20.Text;
                            pl.delatnost = textBox22.Text;
                            pl.pib = int.Parse(textBox23.Text);
                            pl.maticniBr = textBox24.Text;
                            pl.Telefoni = listBox6.Items.Cast<string>().ToList();
                            pl.EmailAdrese = listBox7.Items.Cast<string>().ToList();
                            pl.tip = Klijent.TipKlijenta.pravno;
                            s.Update(pl);
                            tx.Commit();
                            MessageBox.Show("Klijent je uspešno ažuriran!");
                        }
                        else
                        {
                            MessageBox.Show("Niste izabrali tip klijenta (pravno lice)!");
                            return;
                        }
                    }
                    else if (dataGridView10.SelectedRows.Count > 0 && rbFizLice.Checked)
                    {
                        if (!proveriUnos(textBox13, textBox14, textBox15, textBox16, textBox17))
                        {
                            MessageBox.Show("Sva polja moraju biti popunjena!");
                            return;
                        }
                        int id = (int)dataGridView10.SelectedRows[0].Cells["Id"].Value;
                        FizickoLice fl = s.Get<FizickoLice>(id);
                        if (fl != null)
                        {
                            fl.licnoIme = textBox15.Text;
                            fl.prezime = textBox16.Text;
                            fl.imeRoditelja = textBox14.Text;
                            fl.brLicneKarte = textBox12.Text;
                            fl.mestoIzdavanja = textBox13.Text;
                            fl.jmbg = textBox17.Text;
                            fl.Telefoni = listBox5.Items.Cast<string>().ToList();
                            fl.tip = Klijent.TipKlijenta.fizicko;
                            s.Update(fl);
                            tx.Commit();
                            MessageBox.Show("Klijent je uspešno ažuriran!");
                        }
                        else
                        {
                            MessageBox.Show("Niste izabrali tip klijenta (fizicko lice)!");
                            return;
                        }
                    }
                    else if (dataGridView12.SelectedRows.Count > 0 && rbOrganizacija.Checked)
                    {
                        if (!proveriUnos(textBox27, textBox28, textBox29, textBox30))
                        {
                            MessageBox.Show("Sva polja moraju biti popunjena!");
                            return;
                        }
                        int id = (int)dataGridView12.SelectedRows[0].Cells["Id"].Value;
                        Organizacija o = s.Get<Organizacija>(id);
                        if (rbOrganizacija.Checked)
                        {
                            o.adresa = textBox27.Text;
                            o.osnivac = textBox29.Text;
                            o.tipOrganizacije = textBox28.Text;
                            o.registar = textBox30.Text;
                            o.Telefoni = listBox9.Items.Cast<string>().ToList();
                            o.EmailAdrese = listBox8.Items.Cast<string>().ToList();
                            o.tip = Klijent.TipKlijenta.organizacija;
                            s.Update(o);
                            tx.Commit();
                            MessageBox.Show("Klijent je uspešno ažuriran!");
                        }
                        else
                        {
                            MessageBox.Show("Niste izabrali tip klijenta! (organizacija)");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Niste izabrali klijenta za izmenu!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdObrisiKlijenta_Click(object sender, EventArgs e)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                using (ITransaction tx = s.BeginTransaction())
                {
                    Klijent klijent = null;
                    if (dataGridView11.SelectedRows.Count == 1)
                    {
                        int id = (int)dataGridView11.SelectedRows[0].Cells["id"].Value;
                        klijent = s.Get<PravnoLice>(id);
                    }
                    else if (dataGridView10.SelectedRows.Count == 1)
                    {
                        int id = (int)dataGridView10.SelectedRows[0].Cells["id"].Value;
                        klijent = s.Get<FizickoLice>(id);
                    }
                    else if (dataGridView12.SelectedRows.Count == 1)
                    {
                        int id = (int)dataGridView12.SelectedRows[0].Cells["id"].Value;
                        klijent = s.Get<Organizacija>(id);
                    }
                    else
                    {
                        MessageBox.Show("Niste izabrali klijenta za brisanje!");
                        return;
                    }
                    if (klijent == null)
                    {
                        MessageBox.Show("Klijent nije pronadjen!");
                        return;
                    }
                    s.Delete(klijent);
                    tx.Commit();
                    MessageBox.Show("Klijent je uspešno obrisan!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void cmdDodajRacun_Click(object sender, EventArgs e)
        {
            try
            {
                if (!proveriUnos(textBox7) || !proveriUnosComboBox(comboBox7, comboBox8, comboBox9))
                {
                    MessageBox.Show("Sva polja su obavezna!");
                    return;
                }
                ISession s = DataLayer.GetSession();
                Racun r = new Racun();
                r.Banka = (Banka)comboBox7.SelectedItem;
                r.Valuta = textBox7.Text;
                r.Klijent = (Klijent)comboBox8.SelectedItem;
                r.DatumOtvaranja = dateTimePicker8.Value;
                r.Saldo = (decimal)numericUpDown10.Value;
                if(comboBox9.SelectedItem != null)
                    r.Status = (StatusRacuna)Enum.Parse(typeof(StatusRacuna), comboBox9.SelectedItem.ToString());
                s.SaveOrUpdate(r);
                s.Flush();
                MessageBox.Show("Racun je uspešno dodat!");
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdPrikaziRacune_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();
            var racuni = s.Query<Racun>()
                .Select(r => new
                {
                    r.RacunId,
                    Banka = r.Banka.Naziv,
                    Klijent = r.Klijent is FizickoLice
                         ? ((FizickoLice)r.Klijent).licnoIme + " " + ((FizickoLice)r.Klijent).prezime
                         : ((PravnoLice)r.Klijent).kontaktOsoba,
                    r.Valuta,
                    r.DatumOtvaranja,
                    r.Saldo,
                    Status = r.Status.ToString()
                }).ToList();
            dataGridView9.DataSource = racuni;
        }
        private void cmdAzurirajRacun_Click(object sender, EventArgs e)
        {
            try
            {
                if (!proveriUnos(textBox7) || !proveriUnosComboBox(comboBox7, comboBox8, comboBox9))
                {
                    MessageBox.Show("Sva polja su obavezna!");
                    return;
                }
                using (ISession s = DataLayer.GetSession())
                using (ITransaction tx = s.BeginTransaction())
                {
                    if (dataGridView9.SelectedRows.Count != 1)
                    {
                        MessageBox.Show("Niste izabrali racun za izmenu!");
                        return;
                    }
                    int id = -1;
                    if (dataGridView9.SelectedRows.Count == 1)
                    {
                        id = (int)dataGridView9.SelectedRows[0].Cells["Racunid"].Value;
                        Racun racun = s.Get<Racun>(id);
                        racun.Banka = (Banka)comboBox7.SelectedItem;
                        racun.Valuta = textBox7.Text;
                        racun.Klijent = (Klijent)comboBox8.SelectedItem;
                        racun.DatumOtvaranja = dateTimePicker8.Value;
                        racun.Saldo = (decimal)numericUpDown10.Value;
                        racun.Status = (StatusRacuna)Enum.Parse(typeof(StatusRacuna), comboBox9.SelectedItem.ToString());
                        s.Update(racun);
                        tx.Commit();
                    }
                    else
                    {
                        MessageBox.Show("Racun ne postoji!");
                    }
                }
                MessageBox.Show("Racun je uspešno azuriran!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdObrisiRacun_Click(object sender, EventArgs e)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                using (ITransaction tx = s.BeginTransaction())
                {
                    if (dataGridView9.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Niste izabrali racun za brisanje!");
                        return;
                    }
                    int id = (int)dataGridView9.SelectedRows[0].Cells["RacunId"].Value;
                    Racun r = s.Get<Racun>(id);
                    if (r == null)
                    {
                        MessageBox.Show("Racun nije pronadjena!");
                        return;
                    }
                    s.Delete(r);
                    tx.Commit();
                    MessageBox.Show("Racun je uspesno obrisan!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdDodajKreditnuKarticu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!proveriUnos(textBox6) || !proveriUnosComboBox(comboBox2))
                {
                    MessageBox.Show("Sva polja su obavezna!");
                    return;
                }
                ISession s = DataLayer.GetSession();
                Kartica k = new Kartica();
                if (radioButton2.Checked)
                {
                    KreditnaKartica kk = new KreditnaKartica();
                    kk.BrojKartice = textBox6.Text;
                    kk.DnevniLimit = numericUpDown5.Value;
                    kk.Racun = (Racun)comboBox2.Items[comboBox2.SelectedIndex];
                    kk.DatumIzdavanja = dateTimePicker4.Value;
                    kk.DatumIsteka = dateTimePicker3.Value;
                    kk.MaxPeriodOtplate = (int)numericUpDown7.Value;
                    kk.MesecniLimit = numericUpDown8.Value;
                    k = kk;
                }
                else if (radioButton1.Checked)
                {
                    DebitnaKartica dk = new DebitnaKartica();
                    dk.BrojKartice = textBox6.Text;
                    dk.DnevniLimit = numericUpDown5.Value;
                    dk.Racun = (Racun)comboBox2.Items[comboBox2.SelectedIndex];
                    dk.DatumIzdavanja = dateTimePicker4.Value;
                    dk.DatumIsteka = dateTimePicker3.Value;
                    dk.DnevniLimitZaPodizanje = (int)numericUpDown6.Value;
                    k = dk;
                }
                s.SaveOrUpdate(k);
                s.Flush();
                s.Close();
                MessageBox.Show("Kartica je uspešno dodata!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdPrikaziKarticu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                var debitne = s.Query<DebitnaKartica>()
                    .Select(k => new
                    {
                        k.KarticaId,
                        k.BrojKartice,
                        k.DatumIzdavanja,
                        k.DatumIsteka,
                        k.DnevniLimit,
                        k.Racun.RacunId,
                        k.DnevniLimitZaPodizanje
                    }).ToList();
                dataGridView6.DataSource = debitne;
                var kreditne = s.Query<KreditnaKartica>()
                    .Select(k => new
                    {
                        k.KarticaId,
                        k.BrojKartice,
                        k.DatumIzdavanja,
                        k.DatumIsteka,
                        k.DnevniLimit,
                        k.Racun.RacunId,
                        k.MaxPeriodOtplate,
                        k.MesecniLimit
                    }).ToList();
                dataGridView8.DataSource = kreditne;
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                using (ISession s = DataLayer.GetSession())
                using (ITransaction tx = s.BeginTransaction())
                {
                    Kartica k = null;
                    if (dataGridView6.SelectedRows.Count == 1)
                    {
                        int id = (int)dataGridView6.SelectedRows[0].Cells["KarticaId"].Value;
                        DebitnaKartica dk = s.Load<DebitnaKartica>(id);
                        if (radioButton1.Checked)
                        {
                            dk.BrojKartice = textBox6.Text;
                            dk.DatumIzdavanja = dateTimePicker4.Value;
                            dk.DatumIsteka = dateTimePicker3.Value;
                            dk.Racun = (Racun)comboBox2.SelectedItem;
                            dk.DnevniLimit = (decimal)numericUpDown5.Value;
                            dk.DnevniLimitZaPodizanje = (decimal)numericUpDown6.Value;
                            k = dk;
                        }
                        else
                        {
                            MessageBox.Show("Niste izabrali tip kartice (debitna)!");
                            return;
                        }
                    }
                    else if (dataGridView8.SelectedRows.Count == 1)
                    {
                        if (radioButton2.Checked)
                        {
                            int id = (int)dataGridView8.SelectedRows[0].Cells["KarticaId"].Value;
                            KreditnaKartica kk = s.Load<KreditnaKartica>(id);
                            kk.BrojKartice = textBox6.Text;
                            kk.DatumIzdavanja = dateTimePicker4.Value;
                            kk.DatumIsteka = dateTimePicker3.Value;
                            kk.Racun = (Racun)comboBox2.SelectedItem;
                            kk.DnevniLimit = (decimal)numericUpDown5.Value;
                            kk.MaxPeriodOtplate = (int)numericUpDown7.Value;
                            kk.MesecniLimit = (decimal)numericUpDown8.Value;
                            k = kk;
                        }
                        else
                        {
                            MessageBox.Show("Niste izabrali tip kartice (kreditna)!");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kartica nije pronadjena!");
                        return;
                    }
                    s.Update(k);
                    tx.Commit();
                    MessageBox.Show("Kartica je uspesno azurirana!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdObrisiKarticu_Click(object sender, EventArgs e)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                using (ITransaction tx = s.BeginTransaction())
                {
                    Kartica kartica = null;
                    if (dataGridView6.SelectedRows.Count == 1)
                    {
                        int id = (int)dataGridView6.SelectedRows[0].Cells["KarticaId"].Value;
                        kartica = s.Get<DebitnaKartica>(id);
                    }
                    else if (dataGridView8.SelectedRows.Count == 1)
                    {
                        int id = (int)dataGridView8.SelectedRows[0].Cells["KarticaId"].Value;
                        kartica = s.Get<KreditnaKartica>(id);
                    }
                    else
                    {
                        MessageBox.Show("Niste izabrali karticu za brisanje!");
                        return;
                    }
                    if (kartica == null)
                    {
                        MessageBox.Show("Kartica nije pronadjena!");
                        return;
                    }
                    s.Delete(kartica);
                    tx.Commit();
                    MessageBox.Show("Kartica je uspesno obrisana!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            string brojevi = textBox11.Text.Trim();
            if (!string.IsNullOrEmpty(brojevi))
            {
                listBox1.Items.Add(brojevi);
                textBox11.Clear();
                textBox11.Focus();
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
    }
}


