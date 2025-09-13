using NHibernate;
using NHibernate.Linq;
using ProjekatSBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static ProjekatSBP.DTOs;
using static ProjekatSBP.Entiteti.Klijent;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
namespace ProjekatSBP
{
    public class DTOmanager
    {
        #region banka
        public static List<DTOs.BankaPregled> vratiBanke()
        {
            List<DTOs.BankaPregled> banke = new List<DTOs.BankaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Banka> sveBanke = from o in s.Query<Banka>()
                                              select o;
                foreach (Banka o in sveBanke)
                {
                    banke.Add(new DTOs.BankaPregled(o.Id, o.Naziv, o.Adresa, o.WebAdresa));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return banke;
        }
        public static void dodajBanku(DTOs.BankaBasic b)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Banka o = new Banka();

                o.Naziv = b.Naziv;
                o.Adresa = b.Adresa;
                o.WebAdresa = b.WebAdresa;
                o.EmailAdrese = b.EmailAdrese.ToList();
                o.Telefoni = b.Telefoni.ToList();

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static DTOs.BankaBasic azurirajBanku(DTOs.BankaBasic b)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Banka o = s.Load<Banka>(b.Id);
                o.Naziv = b.Naziv;
                o.Adresa = b.Adresa;
                o.WebAdresa = b.WebAdresa;
                o.EmailAdrese = b.EmailAdrese.ToList();
                o.Telefoni = b.Telefoni.ToList();
                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return b;
        }
        public static DTOs.BankaBasic vratiBanku(int id)
        {
            DTOs.BankaBasic b = new DTOs.BankaBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Banka o = s.Load<Banka>(id);
                b = new DTOs.BankaBasic(o.Id, o.Naziv, o.Adresa, o.WebAdresa, o.Telefoni.ToList(), o.EmailAdrese.ToList());
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return b;
        }
        public static void obrisiBanku(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Banka o = s.Load<Banka>(id);
                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region filijala
        public static void dodajFilijalu(DTOs.FilijalaBasic f)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Filijala o = new Filijala();
                o.Adresa = f.Adresa;
                o.RedniBrUBanci = f.RedniBrUBanci;
                o.SastojiSeOd = s.Load<Banka>(f.BankaId);
                o.Telefoni = f.Telefoni.ToList();
                o.RadnaVremena = new List<Entiteti.RadnoVreme>();
                foreach (var rv in f.RadnaVremena)
                {
                    Entiteti.RadnoVreme novoRv = new Entiteti.RadnoVreme();
                    novoRv.Dan = rv.DanUNedelji;
                    novoRv.PocetnoVreme = rv.VremePocetka;
                    novoRv.ZavrsnoVreme = rv.VremeZavrsetka;
                    novoRv.Filijala = o;
                    o.RadnaVremena.Add(novoRv);
                }
                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static DTOs.FilijalaBasic azurirajFilijalu(DTOs.FilijalaBasic f)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Filijala o = s.Load<Filijala>(f.Id);
                o.Adresa = f.Adresa;
                o.RedniBrUBanci = f.RedniBrUBanci;
                o.SastojiSeOd = s.Load<Banka>(f.BankaId);
                o.Telefoni = f.Telefoni.ToList();
                o.RadnaVremena.Clear();
                foreach (var rv in f.RadnaVremena)
                {
                    Entiteti.RadnoVreme novoRv = new Entiteti.RadnoVreme();
                    novoRv.Dan = rv.DanUNedelji;
                    novoRv.PocetnoVreme = rv.VremePocetka;
                    novoRv.ZavrsnoVreme = rv.VremeZavrsetka;
                    novoRv.Filijala = o;
                    o.RadnaVremena.Add(novoRv);
                }
                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return f;
        }
        public static DTOs.FilijalaBasic vratiFilijalu(int id)
        {
            DTOs.FilijalaBasic f = new DTOs.FilijalaBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Filijala o = s.Load<Filijala>(id);
                f = new DTOs.FilijalaBasic(o.Id, o.RedniBrUBanci, o.Adresa, o.SastojiSeOd.Id);
                foreach (var tel in o.Telefoni)
                    f.Telefoni.Add(tel);
                foreach (var rv in o.RadnaVremena)
                    f.RadnaVremena.Add(new DTOs.RadnoVremeBasic(rv.Dan, rv.PocetnoVreme, rv.ZavrsnoVreme));
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return f;
        }
        public static void obrisiFilijalu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Filijala o = s.Load<Filijala>(id);
                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static List<DTOs.FilijalaPregled> vratiFilijale()
        {
            List<DTOs.FilijalaPregled> filijale = new List<DTOs.FilijalaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Filijala> sveFilijale = from o in s.Query<Filijala>()
                                                    select o;
                foreach (Filijala o in sveFilijale)
                {
                    filijale.Add(new DTOs.FilijalaPregled(o.Id, o.RedniBrUBanci, o.Adresa));
                }
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return filijale;
        }
        #endregion
        #region kartice
        public static void dodajKarticu(DTOs.KarticaBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Kartica o = new Kartica();
                if (k is DTOs.DebitnaKarticaBasic debitna)
                {
                    var dk = new DebitnaKartica
                    {
                        BrojKartice = debitna.BrojKartice,
                        DatumIzdavanja = debitna.DatumIzdavanja,
                        DatumIsteka = debitna.DatumIsteka,
                        DnevniLimit = debitna.DnevniLimit,
                        Racun = s.Load<Racun>(debitna.Racun),
                        DnevniLimitZaPodizanje = debitna.DnevniLimitZaPodizanje
                    };
                    s.SaveOrUpdate(dk);
                }
                else if (k is DTOs.KreditnaKarticaBasic kreditna)
                {
                    var kk = new KreditnaKartica
                    {
                        BrojKartice = kreditna.BrojKartice,
                        DatumIzdavanja = kreditna.DatumIzdavanja,
                        DatumIsteka = kreditna.DatumIsteka,
                        DnevniLimit = kreditna.DnevniLimit,
                        Racun = s.Load<Racun>(kreditna.Racun),
                        MaxPeriodOtplate = kreditna.MaxPeriodOtplate,
                        MesecniLimit = kreditna.MesecniLimit
                    };
                    s.SaveOrUpdate(kk);
                }
                s.Flush();
                s.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static DTOs.KarticaBasic azurirajKarticu(DTOs.KarticaBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                var o = s.Get<Kartica>(k.KarticaId);
                if (o is DebitnaKartica dk && k is DTOs.DebitnaKarticaBasic debitna)
                {
                    dk.BrojKartice = debitna.BrojKartice;
                    dk.DatumIzdavanja = debitna.DatumIzdavanja;
                    dk.DatumIsteka = debitna.DatumIsteka;
                    dk.DnevniLimit = debitna.DnevniLimit;
                    dk.Racun = s.Load<Racun>(debitna.Racun);
                    dk.DnevniLimitZaPodizanje = debitna.DnevniLimitZaPodizanje;
                    o = dk;
                }
                else if (o is KreditnaKartica kk && k is DTOs.KreditnaKarticaBasic kreditna)
                {
                        kk.BrojKartice = kreditna.BrojKartice;
                        kk.DatumIzdavanja = kreditna.DatumIzdavanja;
                        kk.DatumIsteka = kreditna.DatumIsteka;
                        kk.DnevniLimit = kreditna.DnevniLimit;
                        kk.Racun = s.Load<Racun>(kreditna.Racun);
                        kk.MaxPeriodOtplate = kreditna.MaxPeriodOtplate;
                        kk.MesecniLimit = kreditna.MesecniLimit;
                        o = kk;
                }
                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return k;
        }
        public static void obrisiKarticu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Kartica o = s.Load<Kartica>(id);
                s.Delete(o);
                s.Flush();
                s.Close();

            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
        }
        public static DTOs.KarticaBasic vratiKarticu(int id)
        {
            ISession s = null;
            try
            {
                s = DataLayer.GetSession();

                Kartica o = s.Get<Kartica>(id);

                DTOs.RacunBasic rb = new DTOs.RacunBasic(o.Racun.RacunId);

                IList<DTOs.TransakcijaBasic> transakcije = new List<DTOs.TransakcijaBasic>();
                foreach (var t in o.Transakcije)
                {
                    transakcije.Add(new DTOs.TransakcijaBasic(
                        t.TransakcijaId,
                        t.Iznos,
                        t.Valuta,
                        t.Vrsta,
                        t.DatumVreme,
                        t.Kartica.KarticaId,
                        t.Uredjaj.Id
                    ));
                }

                if (o is DebitnaKartica dk)
                {
                    return new DTOs.DebitnaKarticaBasic(
                        dk.KarticaId,
                        dk.BrojKartice,
                        dk.DatumIzdavanja,
                        dk.DatumIsteka,
                        dk.DnevniLimit,
                        dk.Racun.RacunId,
                        transakcije,
                        dk.DnevniLimitZaPodizanje
                    );
                }
                else if (o is KreditnaKartica kk)
                {
                    return new DTOs.KreditnaKarticaBasic(
                        kk.KarticaId,
                        kk.BrojKartice,
                        kk.DatumIzdavanja,
                        kk.DatumIsteka,
                        kk.DnevniLimit,
                        kk.Racun.RacunId,
                        transakcije,
                        kk.MaxPeriodOtplate,
                        kk.MesecniLimit
                    );
                }

                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                if (s != null)
                    s.Close();
            }
        }
        public static List<KarticaPregled> vratiSveKArtice()
        {
            List<KarticaPregled> kartice = new List<KarticaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IEnumerable<Kartica> sveKartice = from o in s.Query<Kartica>()
                                                  select o;

                foreach (Kartica k in sveKartice)
                {
                    if (k is KreditnaKartica kk)
                    {
                        kartice.Add(new KreditnaKarticaPregled(kk.KarticaId, kk.BrojKartice, kk.DnevniLimit, kk.DatumIzdavanja, kk.DatumIsteka));
                    }
                    else if (k is DebitnaKartica dk)
                    {
                        kartice.Add(new DebitnaKarticaPregled(dk.KarticaId, dk.BrojKartice, dk.DatumIzdavanja, dk.DatumIsteka, dk.DnevniLimit));
                    }
                }
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return kartice;
        }
        #endregion
        #region transakcija
        public static void dodajTransakciju(DTOs.TransakcijaBasic t)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Transakcija o = new Transakcija();
                o.Iznos = t.Iznos;
                o.Valuta = t.Valuta;
                o.DatumVreme = t.DatumVreme;
                o.Vrsta = t.Vrsta;
                o.Kartica = s.Load<Kartica>(t.KarticaId);
                o.Uredjaj = s.Load<Uredjaj>(t.UredjajId);

                s.Save(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static DTOs.TransakcijaBasic azurirajTransakciju(DTOs.TransakcijaBasic t)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Transakcija o = s.Load<Transakcija>(t.Id);
                o.Iznos = t.Iznos;
                o.Valuta = t.Valuta;
                o.DatumVreme = t.DatumVreme;
                o.Vrsta = t.Vrsta;
                o.Kartica = s.Load<Kartica>(t.KarticaId);
                o.Uredjaj = s.Load<Uredjaj>(t.UredjajId);
                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return t;
        }
        public static void obrisiTransakciju(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Transakcija o = s.Load<Transakcija>(id);
                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static DTOs.TransakcijaBasic vratiTransakciju(int id)
        {
            DTOs.TransakcijaBasic t = new DTOs.TransakcijaBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Transakcija o = s.Load<Transakcija>(id);
                t = new DTOs.TransakcijaBasic(o.TransakcijaId, o.Iznos, o.Valuta, o.Vrsta, o.DatumVreme, o.Kartica.KarticaId, o.Uredjaj.Id);
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return t;
        }
        public static List<DTOs.TransakcijaPregled> vratiSveTransakcije()
        {
            List<DTOs.TransakcijaPregled> transakcije = new List<DTOs.TransakcijaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Transakcija> sveTransakcije = from o in s.Query<Transakcija>()
                                                                            select o;

                foreach (Transakcija t in sveTransakcije)
                {
                    transakcije.Add(new DTOs.TransakcijaPregled(t.TransakcijaId, t.Iznos, t.Valuta, t.Vrsta, t.DatumVreme));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return transakcije;
        }
        #endregion
        #region klijenti
        public static void dodajKlijenta(DTOs.KlijentBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Klijent o = new Klijent();

                if (k is DTOs.FizickoLiceBasic fl)
                {
                    var postoji = s.Query<FizickoLice>()
                  .Any(x => x.jmbg == fl.jmbg);
                    if (postoji)
                    {
                        throw new Exception($"Fizicko lice sa JMBG: {fl.jmbg} postoji!");
                    }
                    var fizickoLice = new FizickoLice
                    {
                        tip = TipKlijenta.fizicko,
                        brLicneKarte = fl.brLicneKarte,
                        mestoIzdavanja = fl.mestoIzdavanja,
                        jmbg = fl.jmbg,
                        prezime = fl.prezime,
                        imeRoditelja = fl.imeRoditelja,
                        licnoIme = fl.licnoIme,
                        Telefoni = fl.Telefoni.ToList()
                    };
                    s.Save(fizickoLice);
                }
                else if (k is DTOs.PravnoLiceBasic pl)
                {
                    var postoji = s.Query<PravnoLice>()
                    .Any(x => x.maticniBr == pl.maticniBr);
                    if (postoji)
                    {
                        throw new Exception($"Pravno lice sa maticnim brojem: {pl.maticniBr} postoji!");
                    }
                    var pravnoLice = new PravnoLice
                    {
                        tip = TipKlijenta.pravno,
                        maticniBr = pl.maticniBr,
                        adresa = pl.adresa,
                        firma = pl.firma,
                        delatnost = pl.delatnost,
                        pib = pl.pib,
                        kontaktOsoba = pl.kontaktOsoba,
                        Telefoni = pl.Telefoni.ToList(),
                        EmailAdrese = pl.EmailAdrese.ToList()
                    };
                    s.Save(pravnoLice);
                }
                else if(k is DTOs.OrganizacijaBasic og)
                {
                    var postoji = s.Query<Organizacija>()
                    .Any(x => x.registar == og.registar);
                    if (postoji)
                    {
                        throw new Exception($"Organizacija sa registrom: {og.registar} postoji!");
                    }
                    var organizacija = new Organizacija
                    {
                        tip = TipKlijenta.organizacija,
                        tipOrganizacije = og.tipOrganizacije,
                        osnivac = og.osnivac,
                        adresa = og.adresa,
                        registar = og.registar,
                        Telefoni = og.Telefoni.ToList(),
                        EmailAdrese = og.EmailAdrese.ToList()
                    };
                    s.Save(organizacija);
                }
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        public static KlijentBasic azurirajKlijenta(DTOs.KlijentBasic k)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                var o = s.Get<Klijent>(k.Id);
                if (o is PravnoLice pl && k is DTOs.PravnoLiceBasic pravnoLice)
                {
                    pl.maticniBr = pravnoLice.maticniBr;
                    pl.adresa = pravnoLice.adresa;
                    pl.firma = pravnoLice.firma;
                    pl.delatnost = pravnoLice.delatnost;
                    pl.pib = pravnoLice.pib;
                    pl.kontaktOsoba = pravnoLice.kontaktOsoba;
                    pl.Telefoni = pravnoLice.Telefoni.ToList();
                    pl.EmailAdrese = pravnoLice.EmailAdrese.ToList();
                }
                else if (o is FizickoLice fl && k is DTOs.FizickoLiceBasic fizickoLice)
                {
                    fl.brLicneKarte = fizickoLice.brLicneKarte;
                    fl.mestoIzdavanja = fizickoLice.mestoIzdavanja;
                    fl.jmbg = fizickoLice.jmbg;
                    fl.prezime = fizickoLice.prezime;
                    fl.imeRoditelja = fizickoLice.imeRoditelja;
                    fl.licnoIme = fizickoLice.licnoIme;
                    fl.Telefoni = fizickoLice.Telefoni.ToList();
                }
                else if(o is Organizacija og && k is DTOs.OrganizacijaBasic organizacija)
                {
                    og.tipOrganizacije = organizacija.tipOrganizacije;
                    og.osnivac = organizacija.osnivac;
                    og.adresa = organizacija.adresa;
                    og.registar = organizacija.registar;
                    og.Telefoni = organizacija.Telefoni.ToList();
                    og.EmailAdrese = organizacija.EmailAdrese.ToList();
                }
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return k;
        }
        public static void obrisiKlijenta(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Klijent o = s.Load<Klijent>(id);
                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
        }
        public static DTOs.KlijentBasic vratiKlijenta(int id)
        {
            DTOs.KlijentBasic kb = new DTOs.KlijentBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Klijent o = s.Get<Klijent>(id);
                if (o is PravnoLice pl)
                {
                    return new PravnoLiceBasic
                    {
                        Id = pl.id,
                        Tip = pl.tip,
                        maticniBr = pl.maticniBr,
                        adresa = pl.adresa,
                        firma = pl.firma,
                        delatnost = pl.delatnost,
                        pib = pl.pib,
                        kontaktOsoba = pl.kontaktOsoba,
                        Telefoni = pl.Telefoni.ToList(),
                        EmailAdrese = pl.EmailAdrese.ToList()
                    };
                }
                else if (o is FizickoLice fl)
                {
                    return new FizickoLiceBasic
                    {
                        Id = fl.id,
                        Tip = fl.tip,
                        brLicneKarte = fl.brLicneKarte,
                        mestoIzdavanja = fl.mestoIzdavanja,
                        jmbg = fl.jmbg,
                        prezime = fl.prezime,
                        imeRoditelja = fl.imeRoditelja,
                        licnoIme = fl.licnoIme,
                        Telefoni = fl.Telefoni.ToList()
                    };
                }
                else if (o is Organizacija og)
                {
                    return new OrganizacijaBasic
                    {
                        Id = og.id,
                        Tip = og.tip,
                        tipOrganizacije = og.tipOrganizacije,
                        osnivac = og.osnivac,
                        adresa = og.adresa,
                        registar = og.registar,
                        Telefoni = og.Telefoni.ToList(),
                        EmailAdrese = og.EmailAdrese.ToList()
                    };
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return kb;
        }
            
        public static List<KlijentPregled> vratiSveKlijente()
        {
            List<KlijentPregled> klijenti = new List<KlijentPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Klijent> sviKlijenti = from o in s.Query<Klijent>()
                                                                            select o;

                foreach (Klijent k in sviKlijenti)
                {
                    if (k is FizickoLice fl)
                    {
                        klijenti.Add(new FizickoLicePregled(fl.id, fl.tip, fl.mestoIzdavanja, fl.prezime, fl.imeRoditelja, fl.licnoIme));
                    }
                    else if (k is PravnoLice pl)
                    {
                        klijenti.Add(new PravnoLicePregled(pl.id, pl.tip, pl.adresa, pl.firma, pl.delatnost, pl.kontaktOsoba));
                    }
                    else if (k is Organizacija og)
                    {
                        klijenti.Add(new OrganizacijaPregled(og.id, og.tip, og.tipOrganizacije, og.osnivac, og.adresa, og.registar));
                    }
                        
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

            return klijenti;
        }
        #endregion
        #region racun
        public static void dodajRacun(RacunBasic r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Racun o = new Racun();

                o.Valuta = r.Valuta;
                o.Saldo = r.Saldo;
                o.DatumOtvaranja = r.DatumOtvaranja;
                o.Banka = s.Load<Banka>(r.BankaId);
                o.RacunId = r.RacunId;
                o.Klijent = s.Load<Klijent>(r.KlijentId);
                o.Status = r.Status;

                s.Save(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static RacunBasic azurirajRacun(RacunBasic r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Racun o = s.Load<Racun>(r.RacunId);

                o.Valuta = r.Valuta;
                o.Saldo = r.Saldo;
                o.DatumOtvaranja = r.DatumOtvaranja;
                o.Banka = s.Load<Banka>(r.BankaId);
                o.RacunId = r.RacunId;
                o.Klijent = s.Load<Klijent>(r.KlijentId);
                o.Status = r.Status;

                s.Update(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

            return r;
        }
        public static void obrisiRacun(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Racun o = s.Load<Racun>(id);
                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static DTOs.RacunBasic vratiRacun(int id)
        {
            DTOs.RacunBasic r = new DTOs.RacunBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Racun o = s.Load<Racun>(id);
                IList<int> karticeId = o.Kartice.Select(k => k.KarticaId).ToList();
                r = new DTOs.RacunBasic(o.RacunId, o.Saldo, o.Valuta, o.DatumOtvaranja, karticeId, o.Klijent.id, o.Banka.Id);
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return r;
        }
        public static List<RacunPregled> vratiSveRacune()
        {
            List<RacunPregled> racuni = new List<RacunPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Racun> sviRacuni = from o in s.Query<Racun>()
                                                          select o;

                foreach (Racun r in sviRacuni)
                {
                    racuni.Add(new DTOs.RacunPregled(r.RacunId, r.Valuta, r.Saldo, r.Status, r.DatumOtvaranja));
                }

                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return racuni;
        }
        #endregion
        #region uredjaj
        public static void dodajUredjaj(UredjajBasic u)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Uredjaj o = new Uredjaj();

                if (u is BankomatBasic ba)
                {
                    var bankomat = new Bankomat
                    {
                        Proizvodjac = ba.Proizvodjac,
                        Adresa = ba.Adresa,
                        Komentar = ba.Komentar,
                        Status = ba.Status,
                        DatumInstalacije = ba.DatumInstalacije,
                        DatumServisa = ba.DatumServisa,
                        PripadaBanci = s.Load<Banka>(ba.BankaId),
                        Filijale = ba.Filijale.Select(f => s.Load<Filijala>(f)).ToList(),
                        GeogrDuzina = ba.GeogrDuzina,
                        GeogrSirina = ba.GeogrSirina,
                        MaxIznos = ba.MaxIznos
                    };
                    s.Update(bankomat);
                }

                else if (u is UplatniAutomatBasic ua)
                {
                    var uplatniAutomat = new UplatniAutomat
                    {
                        Proizvodjac = ua.Proizvodjac,
                        Adresa = ua.Adresa,
                        Komentar = ua.Komentar,
                        Status = ua.Status,
                        DatumInstalacije = ua.DatumInstalacije,
                        DatumServisa = ua.DatumServisa,
                        PripadaBanci = s.Load<Banka>(ua.BankaId),
                        Filijale = ua.Filijale.Select(f => s.Load<Filijala>(f)).ToList(),
                        GeogrDuzina = ua.GeogrDuzina,
                        GeogrSirina = ua.GeogrSirina,
                        ValidatorZaPapirniNovac = ua.ValidatorZaPapirniNovac
                    };
                    s.Save(uplatniAutomat);
                }
                else if (u is MultifunkcionalniUredjajBasic mk)
                {
                    var multifkKiosk = new MultiFunkKiosk
                    {
                        Proizvodjac = mk.Proizvodjac,
                        Adresa = mk.Adresa,
                        Komentar = mk.Komentar,
                        Status = mk.Status,
                        DatumInstalacije = mk.DatumInstalacije,
                        DatumServisa = mk.DatumServisa,
                        PripadaBanci = s.Load<Banka>(mk.BankaId),
                        Filijale = mk.Filijale.Select(f => s.Load<Filijala>(f)).ToList(),
                        GeogrDuzina = mk.GeogrDuzina,
                        GeogrSirina = mk.GeogrSirina,
                        PrisustvoSkenera = mk.PrisustvoSkenera,
                        PrisustvoStampaca = mk.PrisustvoStampaca
                    };
                    s.Save(multifkKiosk);
                }
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        public static UredjajBasic azurirajUredjaj(UredjajBasic u)
        {
            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    var o = s.Get<Uredjaj>(u.Id);

                    if (o is Bankomat ba && u is BankomatBasic bankomat)
                    {
                        ba.Proizvodjac = bankomat.Proizvodjac;
                        ba.Adresa = bankomat.Adresa;
                        ba.Komentar = bankomat.Komentar;
                        ba.Status = bankomat.Status;
                        ba.DatumInstalacije = bankomat.DatumInstalacije;
                        ba.DatumServisa = bankomat.DatumServisa;
                        ba.GeogrDuzina = bankomat.GeogrDuzina;
                        ba.GeogrSirina = bankomat.GeogrSirina;
                        ba.MaxIznos = bankomat.MaxIznos;

                        ba.Filijale.Clear();
                        foreach (var f in bankomat.Filijale)
                        {
                            ba.Filijale.Add(s.Load<Filijala>(f));
                        }
                        ba.brojNovcanica.Clear();

                        foreach (var bn in bankomat.brojNovcanica)
                        {
                            var stavka = new BrojNovcanicaUBankomat
                            {
                                Apoen = s.Load<Apoen>(bn.ApoenId),
                                BrojKomada = bn.BrojKomada,
                                Uredjaj = ba
                            };
                            var attached = s.Merge(stavka);

                            ba.brojNovcanica.Add(attached);
                        }
                    }
                    else if (o is UplatniAutomat ua && u is UplatniAutomatBasic uplatniAutomat)
                    {
                        ua.Proizvodjac = uplatniAutomat.Proizvodjac;
                        ua.Adresa = uplatniAutomat.Adresa;
                        ua.Komentar = uplatniAutomat.Komentar;
                        ua.Status = uplatniAutomat.Status;
                        ua.DatumInstalacije = uplatniAutomat.DatumInstalacije;
                        ua.DatumServisa = uplatniAutomat.DatumServisa;
                        ua.Filijale.Clear();
                        foreach (var f in uplatniAutomat.Filijale)
                        {
                            ua.Filijale.Add(s.Load<Filijala>(f));
                        }
                        ua.GeogrDuzina = uplatniAutomat.GeogrDuzina;
                        ua.GeogrSirina = uplatniAutomat.GeogrSirina;
                        ua.ValidatorZaPapirniNovac = uplatniAutomat.ValidatorZaPapirniNovac;
                    }
                    else if (o is MultiFunkKiosk mk && u is MultifunkcionalniUredjajBasic multiKiosk)
                    {
                        mk.Proizvodjac = multiKiosk.Proizvodjac;
                        mk.Adresa = multiKiosk.Adresa;
                        mk.Komentar = multiKiosk.Komentar;
                        mk.Status = multiKiosk.Status;
                        mk.DatumInstalacije = multiKiosk.DatumInstalacije;
                        mk.DatumServisa = multiKiosk.DatumServisa;
                        mk.Filijale.Clear();
                        foreach (var f in multiKiosk.Filijale)
                        {
                            mk.Filijale.Add(s.Load<Filijala>(f));
                        }
                        mk.GeogrDuzina = multiKiosk.GeogrDuzina;
                        mk.GeogrSirina = multiKiosk.GeogrSirina;
                        mk.PrisustvoSkenera = multiKiosk.PrisustvoSkenera;
                        mk.PrisustvoStampaca = multiKiosk.PrisustvoStampaca;
                    }
                    s.Flush();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return u;
        }

        public static void obrisiUredjaj(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Uredjaj o = s.Load<Uredjaj>(id);
                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            { MessageBox.Show(e.Message); }
        }
        public static UredjajBasic vratiUredjaj(int id)
        {
            UredjajBasic ub = new UredjajBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Uredjaj o = s.Get<Uredjaj>(id);
                if (o is Bankomat b)
                {
                    return new BankomatBasic
                    {
                        Id = b.Id,
                        Proizvodjac = b.Proizvodjac,
                        Adresa = b.Adresa,
                        Komentar = b.Komentar,
                        Status = b.Status,
                        DatumInstalacije = b.DatumInstalacije,
                        DatumServisa = b.DatumServisa,
                        GeogrDuzina = b.GeogrDuzina,
                        GeogrSirina = b.GeogrSirina,
                        MaxIznos = b.MaxIznos,
                        Filijale = b.Filijale.Select(f => f.Id).ToList(),
                        brojNovcanica = b.brojNovcanica
                            .Select(bn => new BrojNovcanicaBasic
                            {
                                ApoenId = bn.Apoen.ApoenID,
                                BrojKomada = bn.BrojKomada
                            })
                            .ToList()
                    };
                }
                else if (o is UplatniAutomat ua)
                {
                    return new UplatniAutomatBasic
                    {
                        Id = ua.Id,
                        Proizvodjac = ua.Proizvodjac,
                        Adresa = ua.Adresa,
                        Komentar = ua.Komentar,
                        Status = ua.Status,
                        DatumInstalacije = ua.DatumInstalacije,
                        DatumServisa = ua.DatumServisa,
                        GeogrDuzina = ua.GeogrDuzina,
                        GeogrSirina = ua.GeogrSirina,
                        ValidatorZaPapirniNovac = ua.ValidatorZaPapirniNovac,
                        Filijale = ua.Filijale.Select(f => f.Id).ToList()
                    };
                }
                else if (o is MultiFunkKiosk mk)
                {
                    return new MultifunkcionalniUredjajBasic
                    {
                        Id = mk.Id,
                        Proizvodjac = mk.Proizvodjac,
                        Adresa = mk.Adresa,
                        Komentar = mk.Komentar,
                        Status = mk.Status,
                        DatumInstalacije = mk.DatumInstalacije,
                        DatumServisa = mk.DatumServisa,
                        GeogrDuzina = mk.GeogrDuzina,
                        GeogrSirina = mk.GeogrSirina,
                        PrisustvoSkenera = mk.PrisustvoSkenera,
                        PrisustvoStampaca = mk.PrisustvoStampaca,
                        Filijale = mk.Filijale.Select(f => f.Id).ToList()
                    };
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return ub;
        }
        public static List<UredjajPregled> vratiSveUredjaje()
        {
            List<UredjajPregled> uredjaji = new List<UredjajPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Uredjaj> sviUredjaji = from o in s.Query<Uredjaj>()
                                                   select o;

                foreach (Uredjaj u in sviUredjaji)
                {
                    if (u is Bankomat ba)
                    {
                        uredjaji.Add(new BankomatPregled(ba.Id, ba.Adresa, ba.Proizvodjac, ba.Komentar, ba.Status, ba.DatumInstalacije, ba.DatumServisa, ba.GeogrSirina, ba.GeogrDuzina));
                    }
                    else if (u is MultiFunkKiosk pl)
                    {
                        uredjaji.Add(new MultifunkcionalniUredjajPregled(pl.Id, pl.Adresa, pl.Proizvodjac, pl.Komentar, pl.Status, pl.DatumInstalacije, pl.DatumServisa, pl.GeogrSirina, pl.GeogrDuzina));
                    }
                    else if (u is UplatniAutomat ua)
                    {
                        uredjaji.Add(new UplatniAutomatPregled(ua.Id, ua.Adresa, ua.Proizvodjac, ua.Komentar, ua.Status, ua.DatumInstalacije, ua.DatumServisa, ua.GeogrSirina, ua.GeogrDuzina));
                    }

                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

            return uredjaji;
        }
        #endregion
    }
}
