using ProjekatSBP.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjekatSBP.DTOs;
using static ProjekatSBP.Entiteti.Klijent;

namespace ProjekatSBP
{
    public class DTOs
    {
        #region banka
        public class BankaPregled
        {
            public virtual int Id { get; set; }
            public virtual string Naziv { get; set; }
            public virtual string Adresa { get; set; }
            public virtual string WebAdresa { get; set; }
            public BankaPregled()
            {
            }
            public BankaPregled(int id, string naziv, string adresa, string webadresa)
            {
                this.Id = id;
                this.Naziv = naziv;
                this.Adresa = adresa;
                this.WebAdresa = webadresa;
            }
        }
        public class BankaBasic
        {
            public virtual int Id { get; set; }
            public virtual string Naziv { get; set; }
            public virtual string Adresa { get; set; }
            public virtual string WebAdresa { get; set; }
            public virtual IList<string> Telefoni { get; set; } = new List<string>();
            public virtual IList<string> EmailAdrese { get; set; } = new List<string>();
            public virtual IList<Uredjaj> Uredjaji { get; set; }
            public virtual IList<Filijala> Filijale { get; set; }
            public BankaBasic()
            {
                Telefoni = new List<string>();
                EmailAdrese = new List<string>();
                Uredjaji = new List<Uredjaj>();
                Filijale = new List<Filijala>();
            }
            public BankaBasic(int id, string naziv, string adresa)
            {
                this.Id = id;
                this.Naziv = naziv;
                this.Adresa = adresa;
            }
            public BankaBasic(int id, string naziv, string adresa, string webadresa,
                      IList<string> telefoni, IList<string> emailAdrese)
            {
                this.Id = id;
                this.Naziv = naziv;
                this.Adresa = adresa;
                this.WebAdresa = webadresa;
                this.Telefoni = telefoni ?? new List<string>();
                this.EmailAdrese = emailAdrese ?? new List<string>();
                this.Uredjaji = new List<Uredjaj>();
                this.Filijale = new List<Filijala>();
            }
        }
        #endregion


        #region filijala
        public class FilijalaPregled
        {
            public virtual int Id { get; set; }
            public virtual int RedniBrUBanci { get; set; }
            public virtual string Adresa { get; set; }
            public FilijalaPregled()
            {
            }
            public FilijalaPregled(int id, int rednibr, string adresa)
            {
                this.Id = id;
                this.RedniBrUBanci = rednibr;
                this.Adresa = adresa;
            }
        }
        public class FilijalaBasic
        {
            public virtual int Id { get; set; }
            public virtual int RedniBrUBanci { get; set; }
            public virtual string Adresa { get; set; }
            public virtual int BankaId { get; set; }
            public virtual IList<UredjajBasic> Uredjaji { get; set; } = new List<UredjajBasic>();
            public virtual IList<string> Telefoni { get; set; } =  new List<string>();
            public virtual IList<RadnoVremeBasic> RadnaVremena { get; set; } = new List<RadnoVremeBasic>();
            public FilijalaBasic()
            {
                Uredjaji = new List<UredjajBasic>();
                Telefoni = new List<string>();
                RadnaVremena = new List<RadnoVremeBasic>();
            }
            public FilijalaBasic(int id, int rednibr, string adresa, int bankaId)
            {
                this.Id = id;
                this.RedniBrUBanci = rednibr;
                this.Adresa = adresa;
            }
            public FilijalaBasic(int id, int rednibr, string adresa, int bankaId, IList<RadnoVremeBasic> radnavremena)
            {
                this.Id = id;
                this.RedniBrUBanci = rednibr;
                this.Adresa = adresa;
                this.RadnaVremena = radnavremena;
            }
        }
        #endregion
        #region radnovreme
        public class RadnoVremePregled
        {
            public virtual int Id { get; set; }
            public virtual string DanUNedelji { get; set; }
            public virtual TimeSpan VremePocetka { get; set; }
            public virtual TimeSpan VremeZavrsetka { get; set; }
            public RadnoVremePregled()
            {
            }
            public RadnoVremePregled(int id, string danunedelji, TimeSpan vremepocetka, TimeSpan vremezavrsetka)
            {
                this.Id = id;
                this.DanUNedelji = danunedelji;
                this.VremePocetka = vremepocetka;
                this.VremeZavrsetka = vremezavrsetka;
            }
        }
        public class RadnoVremeBasic
        {
            public virtual int Id { get; set; }
            public virtual string DanUNedelji { get; set; }
            public virtual string VremePocetka { get; set; }
            public virtual string VremeZavrsetka { get; set; }
            public virtual FilijalaBasic Filijala { get; set; }
            public RadnoVremeBasic()
            {
            }
            public RadnoVremeBasic(string danunedelji, string vremepocetka, string vremezavrsetka)
            {
                this.DanUNedelji = danunedelji;
                this.VremePocetka = vremepocetka;
                this.VremeZavrsetka = vremezavrsetka;
            }
        }
        #endregion
        #region uredjaj
        public class UredjajPregled
        {
            public virtual int Id { get; set; }
            public virtual String Adresa { get; set; }
            public virtual string Proizvodjac { get; set; }
            public virtual string Komentar { get; set; }
            public virtual StatusRada Status { get; set; }
            public virtual DateTime DatumInstalacije { get; set; }
            public virtual DateTime? DatumServisa { get; set; }
            public virtual double GeogrSirina { get; set; }
            public virtual double GeogrDuzina { get; set; }
            public UredjajPregled()
            {
            }
            public UredjajPregled(int id, string adresa, string proizvodjac, string komentar, StatusRada status, DateTime datumInstalacije, DateTime? datumServisa, double geogrSirina, double geogrDuzina)
            {
                this.Id = id;
                this.Adresa = adresa;
                this.Proizvodjac = proizvodjac;
                this.Komentar = komentar;
                this.Status = status;
                this.DatumInstalacije = datumInstalacije;
                this.DatumServisa = datumServisa;
                this.GeogrDuzina = geogrDuzina;
                this.GeogrSirina = geogrSirina;
            }
        }
        public class UredjajBasic
        {
            public virtual int Id { get; set; }
            public virtual String Adresa { get; set; }
            public virtual string Proizvodjac { get; set; }
            public virtual string Komentar { get; set; }
            public virtual StatusRada Status { get; set; }
            public virtual DateTime DatumInstalacije { get; set; }
            public virtual DateTime? DatumServisa { get; set; }
            public virtual double GeogrSirina { get; set; }
            public virtual double GeogrDuzina { get; set; }
            public virtual int BankaId { get; set; }
            public virtual IList<int> Filijale { get; set; }
            public UredjajBasic()
            {
            }
            public UredjajBasic(int id, string adresa, string proizvodjac, string komentar, StatusRada status, DateTime datumInstalacije, DateTime? datumServisa, double geogrSirina, double geogrDuzina, IList<int> filijalaId, int bankaId)
            {
                this.Id = id;
                this.Adresa = adresa;
                this.Proizvodjac = proizvodjac;
                this.Komentar = komentar;
                this.Status = status;
                this.DatumInstalacije = datumInstalacije;
                this.DatumServisa = datumServisa;
                this.Filijale = filijalaId;
                BankaId = bankaId;
            }
        }
        #endregion
        #region bankomat
        public class BankomatPregled : UredjajPregled
        {
            public BankomatPregled()
            {
            }
            public BankomatPregled(int id, string adresa, string proizvodjac, string komentar, StatusRada status, DateTime datumInstalacije, DateTime? datumServisa, double geogrSirina, double geogrDuzina)
                : base(id,adresa,proizvodjac,komentar, status,datumInstalacije,datumServisa,geogrSirina,geogrDuzina)
            {
            }
        }
        public class BankomatBasic : UredjajBasic
        {
            public virtual double MaxIznos { get; set; }
            public virtual IList<BrojNovcanicaBasic> brojNovcanica { get; set; } = new List<BrojNovcanicaBasic>();
            public BankomatBasic()
            {
            }
            public BankomatBasic(int id, string adresa, string proizvodjac, string komentar, StatusRada status, DateTime datumInstalacije, DateTime? datumServisa, double geogrSirina, double geogrDuzina, IList<int> filijalaId,int bankaid, double maxIznos, IList<BrojNovcanicaBasic> brojNovcanica)
               : base(id, adresa, proizvodjac, komentar, status, datumInstalacije, datumServisa, geogrSirina, geogrDuzina, filijalaId, bankaid)
            {
                this.MaxIznos = maxIznos;
                this.brojNovcanica = brojNovcanica;
            }
        }
        #endregion
        #region apoen
        public class ApoenPregled
        {
            public virtual int Id { get; set; }
            public virtual int NominalnaVrednost { get; set; }
            public virtual int Kolicina { get; set; }
            public ApoenPregled()
            {
            }
            public ApoenPregled(int id, int nominalnavrednost, int kolicina)
            {
                this.Id = id;
                this.NominalnaVrednost = nominalnavrednost;
                this.Kolicina = kolicina;
            }
        }
        public class ApoenBasic
        {
            public virtual int Id { get; set; }
            public virtual int NominalnaVrednost { get; set; }
            public virtual int Kolicina { get; set; }
            public virtual BankomatBasic Bankomat { get; set; }
            public ApoenBasic()
            {
            }
            public ApoenBasic(int id, int nominalnavrednost, int kolicina)
            {
                this.Id = id;
                this.NominalnaVrednost = nominalnavrednost;
                this.Kolicina = kolicina;
            }
        }
        #endregion
        #region brojnovcanicaubankomat
        public class BrojNovcanicaUBankomatPregled
        {
            public int UredjajId { get; set; }
            public int ApoenId { get; set; }
            public int VrednostApoena { get; set; }
            public int BrojKomada { get; set; }

            public BrojNovcanicaUBankomatPregled() { }

            public BrojNovcanicaUBankomatPregled(int uredjajId, int apoenId, int vrednostApoena, int brojKomada)
            {
                UredjajId = uredjajId;
                ApoenId = apoenId;
                VrednostApoena = vrednostApoena;
                BrojKomada = brojKomada;
            }
        }
        public class BrojNovcanicaBasic
        {
            public int BrojKomada { get; set; }
            public UredjajBasic Uredjaj { get; set; }

            public int VrednostApoena { get; set; }
            public int ApoenId { get; set; }

            public BrojNovcanicaBasic() { }

            public BrojNovcanicaBasic(int brojKomada, UredjajBasic uredjaj, int apoen, int vrednostApoena)
            {
                BrojKomada = brojKomada;
                Uredjaj = uredjaj;
                ApoenId = apoen;
                VrednostApoena = vrednostApoena;
            }
        }
        #endregion
        #region uplatniautomat
        public class UplatniAutomatPregled : UredjajPregled
        {

            public UplatniAutomatPregled()
            {
            }
            public UplatniAutomatPregled(int id, string adresa, string proizvodjac, string komentar, StatusRada status, DateTime datumInstalacije, DateTime? datumServisa, double geogrSirina, double geogrDuzina)
               : base(id, adresa, proizvodjac, komentar, status, datumInstalacije, datumServisa, geogrSirina, geogrDuzina)
            {
            }
        }
        public class UplatniAutomatBasic : UredjajBasic
        {
            public virtual bool ValidatorZaPapirniNovac { get; set; }
            public virtual ICollection<string> PodrzaneVrsteUplate { get; set; } = new List<string>();
            public UplatniAutomatBasic()
            {
            }
            public UplatniAutomatBasic(int id, string adresa, string proizvodjac, string komentar, StatusRada status, DateTime datumInstalacije, DateTime? datumServisa, double geogrSirina, double geogrDuzina, IList<int> filijalaId,int bankaid, bool validator, ICollection<string> podrzaneVrste, IList<int>FilijalaId)
              : base(id, adresa, proizvodjac, komentar, status, datumInstalacije, datumServisa, geogrSirina, geogrDuzina, filijalaId, bankaid)
            {
                this.ValidatorZaPapirniNovac = validator;
                this.PodrzaneVrsteUplate = podrzaneVrste;
            }
        }
        #endregion
        #region multifunkcionalniuredjaj
        public class MultifunkcionalniUredjajPregled : UredjajPregled
        {
            public virtual ICollection<string> PodrzaniServis { get; set; }
            public MultifunkcionalniUredjajPregled()
            {
            }
            public MultifunkcionalniUredjajPregled(int id, string adresa, string proizvodjac, string komentar, StatusRada status, DateTime datumInstalacije, DateTime? datumServisa, double geogrSirina, double geogrDuzina)
              : base(id, adresa, proizvodjac, komentar, status, datumInstalacije, datumServisa, geogrSirina, geogrDuzina)
            {

            }
        }
        public class MultifunkcionalniUredjajBasic : UredjajBasic
        {
            public virtual bool PrisustvoSkenera { get; set; }
            public virtual bool PrisustvoStampaca { get; set; }
            public virtual ICollection<string> PodrzaniServis { get; set; }
            public MultifunkcionalniUredjajBasic()
            {
            }
            public MultifunkcionalniUredjajBasic(int id, string adresa, string proizvodjac, string komentar, StatusRada status, DateTime datumInstalacije, DateTime? datumServisa, double geogrSirina, double geogrDuzina, IList<int> FilijalaID,int bankaid, bool prisustvoSkenera, bool prisustvoStampaca, ICollection<Servis> PodrzaniServis)
            : base(id, adresa, proizvodjac, komentar, status, datumInstalacije, datumServisa, geogrSirina, geogrDuzina, FilijalaID, bankaid)
            {
                this.PrisustvoStampaca = prisustvoSkenera;
                this.PrisustvoSkenera = prisustvoSkenera;
                this.PodrzaniServis = PodrzaniServis?.Select(s => s.Naziv)?.ToList() ?? new List<string>();
            }
        }
        #endregion
        #region vrstauplate
        public class VrstaUplatePregled
        {
            public virtual int Id { get; set; }
            public virtual string Naziv { get; set; }
            public VrstaUplatePregled()
            {
            }
            public VrstaUplatePregled(int id, string naziv)
            {
                this.Id = id;
                this.Naziv = naziv;
            }
        }
        public class VrstaUplateBasic
        {
            public virtual int Id { get; set; }
            public virtual string Naziv { get; set; }
            public virtual IList<UplatniAutomatBasic> UplatniAutomati { get; set; }
            public VrstaUplateBasic()
            {
                UplatniAutomati = new List<UplatniAutomatBasic>();
            }
            public VrstaUplateBasic(int id, string naziv)
            {
                this.Id = id;
                this.Naziv = naziv;
            }
        }
        #endregion
        #region racun
        public class RacunPregled
        {
            public virtual int RacunId { get; set; }
            public virtual string Valuta { get; set; }
            public virtual DateTime DatumOtvaranja { get; set; }
            public virtual decimal Saldo { get; set; }
            public virtual StatusRacuna Status { get; set; }
            public RacunPregled()
            {
            }
            public RacunPregled(int id, string valuta, decimal saldo, StatusRacuna status, DateTime datumOtvaranja)
            {
                this.RacunId = id;
                this.Valuta = valuta;
                this.Saldo = saldo;
                this.Status = status;
                this.DatumOtvaranja = datumOtvaranja;
            }
        }
        public class RacunBasic
        {
            public virtual int RacunId { get; set; }
            public virtual int BankaId { get; set; }
            public virtual int KlijentId { get; set; }
            public virtual string Valuta { get; set; }
            public virtual DateTime DatumOtvaranja { get; set; }
            public virtual decimal Saldo { get; set; }
            public virtual StatusRacuna Status { get; set; }
            public virtual IList<int> Kartice { get; set; } 
            public RacunBasic()
            {
                Kartice = new List<int>();
            }
            public RacunBasic(int id)
            {
                this.RacunId = id;
            }
            public RacunBasic(int id, decimal stanje, string valuta,DateTime datumOtvaranja, IList<int> kartice, int klijentId, int bankaId)
            {
                this.RacunId = id;
                this.Saldo = stanje;
                this.Valuta = valuta;
                this.DatumOtvaranja = datumOtvaranja;
                this.BankaId = bankaId;
                this.KlijentId = klijentId;
                this.Kartice = kartice ?? new List<int>();
            }
        }
        #endregion
        #region kartica
        public class KarticaPregled
        {
            public virtual int KarticaId { get; set; }
            public virtual decimal DnevniLimit { get; set; }
            public virtual string BrojKartice { get; set; }
            public virtual DateTime DatumIzdavanja { get; set; }
            public virtual DateTime DatumIsteka { get; set; }

            public KarticaPregled()
            {
            }
            public KarticaPregled(int id, string brojkartice, decimal dnevnilimit, DateTime datumizdavanja, DateTime datumIsteka)
            {
                this.KarticaId = id;
                this.BrojKartice = brojkartice;
                this.DnevniLimit = dnevnilimit;
                this.DatumIzdavanja = datumizdavanja;
                this.DatumIsteka = datumIsteka;
            }
        }
        public class KarticaBasic
        {
            public virtual int KarticaId { get; set; }
            public virtual decimal DnevniLimit { get; set; }
            public virtual string BrojKartice { get; set; }
            public virtual DateTime DatumIzdavanja { get; set; }
            public virtual DateTime DatumIsteka { get; set; }
            public virtual int Racun { get; set; }
            public virtual IList<TransakcijaBasic> Transakcije { get; set; }
            public KarticaBasic()
            {
                Transakcije = new List<TransakcijaBasic>();
            }
            public KarticaBasic(int id)
            {
                this.KarticaId = id;
            }
            public KarticaBasic(int id, string brojKartice)
            {
                this.KarticaId = id;
                this.BrojKartice = brojKartice;
            }
            public KarticaBasic(int id, string brojKartice, DateTime datumIzdavanja, DateTime datumIsteka, decimal dnevniLimit, int racun, IList<TransakcijaBasic> transakcije)
            {
                this.KarticaId = id;
                this.BrojKartice = brojKartice;
                this.DatumIzdavanja = datumIzdavanja;
                this.DatumIsteka = datumIsteka;
                this.DnevniLimit = dnevniLimit;
                this.Racun = racun;
                this.Transakcije = transakcije ?? new List<TransakcijaBasic>();
            }
        }
        #endregion
        #region kreditnakartica
        public class KreditnaKarticaPregled : KarticaPregled
        {
            public KreditnaKarticaPregled()
            {
            }
            public KreditnaKarticaPregled(int id, string brojkartice, decimal dnevnilimit, DateTime datumizdavanja, DateTime datumIsteka)
                : base(id, brojkartice, dnevnilimit, datumizdavanja, datumIsteka)
            {
            }
        }
        public class KreditnaKarticaBasic : KarticaBasic
        {
            public virtual int MaxPeriodOtplate { get; set; }
            public virtual decimal MesecniLimit { get; set; }
            public KreditnaKarticaBasic()
            {
            }
            public KreditnaKarticaBasic(int id, string brojKartice, DateTime datumIzdavanja, DateTime datumIsteka, decimal dnevniLimit, int racun, IList<TransakcijaBasic> transakcije, int maxPeriodOtplate, decimal mesecniLimit)
                : base(id, brojKartice, datumIzdavanja, datumIsteka, dnevniLimit, racun, transakcije)
            {
                this.MaxPeriodOtplate = maxPeriodOtplate;
                this.MesecniLimit = mesecniLimit;
            }
        }
        #endregion
        #region debitnakartica
        public class DebitnaKarticaPregled : KarticaPregled
        {
            public DebitnaKarticaPregled()
            {
            }
            public DebitnaKarticaPregled(int id, string brojkartice, DateTime datumizdavanja, DateTime datumIsteka, decimal dnevniLimit)
                : base(id, brojkartice, dnevniLimit, datumizdavanja, datumIsteka)
            {
            }
        }
        public class DebitnaKarticaBasic : KarticaBasic
        {
            public virtual decimal DnevniLimitZaPodizanje { get; set; }
            public DebitnaKarticaBasic()
            {
            }
            public DebitnaKarticaBasic(int id, string brojKartice, DateTime datumIzdavanja, DateTime datumIsteka, decimal dnevniLimit, int racun, IList<TransakcijaBasic> transakcije, decimal dnevniLimitZaPodizanje)
                : base(id, brojKartice, datumIzdavanja, datumIsteka, dnevniLimit, racun, transakcije)
            {
                this.DnevniLimitZaPodizanje = dnevniLimitZaPodizanje;
            }
        }
        #endregion
        #region transakcija
        public class TransakcijaPregled
        {
            public virtual int Id { get; set; }
            public virtual decimal Iznos { get; set; }
            public virtual string Valuta { get; set; }
            public virtual VrstaTransakcije Vrsta { get; set; }
            public virtual DateTime DatumVreme { get; set; }

            public TransakcijaPregled()
            {
            }

            public TransakcijaPregled(int id, decimal iznos, string valuta, VrstaTransakcije vrsta, DateTime datumVreme)
            {
                this.Id = id;
                this.Iznos = iznos;
                this.Valuta = valuta;
                this.Vrsta = vrsta;
                this.DatumVreme = datumVreme;
            }
        }
        public class TransakcijaBasic
        {
            public virtual int Id { get; set; }
            public virtual decimal Iznos { get; set; }
            public virtual string Valuta { get; set; }
            public virtual VrstaTransakcije Vrsta { get; set; }
            public virtual DateTime DatumVreme { get; set; }
            public virtual int KarticaId { get; set; }
            public virtual int UredjajId { get; set; }

            public TransakcijaBasic()
            {
            }

            public TransakcijaBasic(int id, decimal iznos, string valuta, VrstaTransakcije vrsta, DateTime datumVreme, int kartica, int uredjaj)
            {
                this.Id = id;
                this.Iznos = iznos;
                this.Valuta = valuta;
                this.Vrsta = vrsta;
                this.DatumVreme = datumVreme;
                this.KarticaId = kartica;
                this.UredjajId = uredjaj;
            }
        }
        #endregion
        #region klijent
        public class KlijentPregled
        {
            public virtual int Id { get; set; }
            public virtual TipKlijenta Tip { get; set; }
            public KlijentPregled() { }

            public KlijentPregled(int id, TipKlijenta tip)
            {
                Id = id;
                Tip = tip;
            }
        }

        public class KlijentBasic
        {
            public virtual int Id { get; set; }
            public virtual TipKlijenta Tip { get; set; }
            public virtual IList<RacunBasic> Racuni { get; set; }

            public KlijentBasic()
            {
                Racuni = new List<RacunBasic>();
            }
            public KlijentBasic(int id, TipKlijenta tip )
            {
                this.Id = id;
                this.Tip = tip;
            }

            public KlijentBasic(int id, TipKlijenta tip, IList<RacunBasic> racuni)
            {
                Id = id;
                Tip = tip;
                Racuni = racuni ?? new List<RacunBasic>();
            }
        }
        #endregion
        #region fizickolice
        public class FizickoLicePregled : KlijentPregled
        {
            public virtual string mestoIzdavanja { get; set; }
            public virtual string prezime { get; set; }
            public virtual string imeRoditelja { get; set; }
            public virtual string licnoIme { get; set; }
            public FizickoLicePregled()
            {
            }
            public FizickoLicePregled(int id, TipKlijenta tip, string mestoIzdavanja, string prezime, string imeRoditelja, string licnoIme)
                : base(id, tip)
            {
                this.mestoIzdavanja = mestoIzdavanja;
                this.prezime = prezime;
                this.imeRoditelja = imeRoditelja;
                this.licnoIme = licnoIme;
            }
        }
        public class FizickoLiceBasic : KlijentBasic
        {
            public virtual string brLicneKarte { get; set; }
            public virtual string mestoIzdavanja { get; set; }
            public virtual string jmbg { get; set; }
            public virtual IList<string> Telefoni { get; set; } = new List<string>();
            public virtual string prezime { get; set; }
            public virtual string imeRoditelja { get; set; }
            public virtual string licnoIme { get; set; }
            public FizickoLiceBasic()
            {
            }
            public FizickoLiceBasic(int id, TipKlijenta tip, IList<RacunBasic> racuni,  string brLicneKarte, string mestoIzdavanja, string jmbg, string prezime, string imeRoditelja, string licnoIme)
                : base(id,tip, racuni)
            {
                this.brLicneKarte = brLicneKarte;
                this.mestoIzdavanja = mestoIzdavanja;
                this.jmbg = jmbg;
                this.prezime = prezime;
                this.imeRoditelja = imeRoditelja;
                this.licnoIme = licnoIme;
            }
        }
        #endregion
        #region pravnolice
        public class PravnoLicePregled : KlijentPregled
        {
            public virtual string adresa { get; set; }
            public virtual string firma { get; set; }
            public virtual string delatnost { get; set; }
            public virtual string kontaktOsoba { get; set; }
            public PravnoLicePregled()
            {
            }
            public PravnoLicePregled(int id, TipKlijenta tip,  string adresa, string firma, string delatnost, string kontaktOsoba)
                : base(id, tip)
            {
                this.adresa = adresa;
                this.firma = firma;
                this.delatnost = delatnost;
                this.kontaktOsoba = kontaktOsoba;
            }
        }
        public class PravnoLiceBasic : KlijentBasic
        {
            public virtual string maticniBr { get; set; }
            public virtual string adresa { get; set; }
            public virtual string firma { get; set; }
            public virtual string delatnost { get; set; }
            public virtual IList<string> Telefoni { get; set; } = new List<string>();
            public virtual IList<string> EmailAdrese { get; set; } = new List<string>();
            public virtual string kontaktOsoba { get; set; }
            public virtual int pib { get; set; }
            public PravnoLiceBasic()
            {
            }
            public PravnoLiceBasic(int id, TipKlijenta tip, IList<RacunBasic> racuni, string maticniBr, string adresa, string firma, string delatnost, string kontaktOsoba, int pib, IList<string> telefoni, IList<string> emailAdrese)
                : base(id, tip, racuni)
            {
                this.maticniBr = maticniBr;
                this.adresa = adresa;
                this.firma = firma;
                this.delatnost = delatnost;
                this.Telefoni = telefoni ?? new List<string>();
                this.EmailAdrese = emailAdrese ?? new List<string>();
                this.kontaktOsoba = kontaktOsoba;
                this.pib = pib;
            }
        }
        #endregion
        #region organizacija
        public class OrganizacijaPregled : KlijentPregled
        {
            public virtual string tipOrganizacije { get; set; }
            public virtual string osnivac { get; set; }
            public virtual string adresa { get; set; }
            public virtual string registar { get; set; }
            public OrganizacijaPregled()
            {
            }
            public OrganizacijaPregled(int id, TipKlijenta tip, string tipOrganizacije, string osnivac, string adresa, string registar)
                : base(id, tip)
            {
                this.tipOrganizacije = tipOrganizacije;
                this.osnivac = osnivac;
                this.adresa = adresa;
                this.registar = registar;
            }
        }
        public class OrganizacijaBasic : KlijentBasic
        {
            public virtual string tipOrganizacije { get; set; }
            public virtual string osnivac { get; set; }
            public virtual string adresa { get; set; }
            public virtual string registar { get; set; }
            public virtual IList<string> Telefoni { get; set; } = new List<string>();
            public virtual IList<string> EmailAdrese { get; set; } = new List<string>();
            public OrganizacijaBasic()
            {
            }
            public OrganizacijaBasic(int id, TipKlijenta tip, IList<RacunBasic> racuni, string tipOrganizacije, string osnivac, string adresa, string registar, IList<string> Telefoni, IList<string> EmailAdrese)
                : base(id, tip, racuni)
            {
                this.tipOrganizacije = tipOrganizacije;
                this.osnivac = osnivac;
                this.adresa = adresa;
                this.registar = registar;
                this.Telefoni = Telefoni ?? new List<string>();
                this.EmailAdrese = EmailAdrese ?? new List<string>();
            }
        }
        #endregion
    }
}
