
using Microsoft.EntityFrameworkCore;
using RS2_FrizerskiSalon.Database;

namespace RS2_FrizerskiSalon.Extensions;

public static class DbContextExtensions
{
    public static void MigrateAndSeedDatabase(this FrizerskiStudioRsiiContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        context.Database.Migrate();

        if (context.Spols.Any())
        {
            return;
        }

        // Spol
        var spol1 = new Spol()
        {
            Naziv = "Muški"
        };
        var spol2 = new Spol()
        {
            Naziv = "Ženski"
        };
        var spol3 = new Spol()
        {
            Naziv = "Ostalo"
        };
        context.Spols.Add(spol1);
        context.Spols.Add(spol2);
        context.Spols.Add(spol3);

        // Zanimanje
        var frizer1 = new Zanimanje { Naziv = "Frizer za šišanje" };
        var frizer2 = new Zanimanje { Naziv = "Frizer za stiliziranje kose" };
        var frizer3 = new Zanimanje { Naziv = "Frizer za farbanje" };
        var frizer4 = new Zanimanje { Naziv ="Frizer za pramenove" };

        context.Zanimanjes.Add(frizer1);
        context.Zanimanjes.Add(frizer2);
        context.Zanimanjes.Add(frizer3);
        context.Zanimanjes.Add(frizer4);
   

        // Klijent
        var klijent1 = new Klijent
        {
            Spol = spol1,
            Ime = "Marshall",
            Prezime = "Eriksen",
            DatumRodjenja = new DateTime(1978, 1, 1),
            Email = "marshmallow@hotmail.com",
            Telefon = "061/001-000",
            KorisnickoIme = "marshmallow",
            LozinkaHash = "wiBMBKZIL6tsB0jtGCoRCmRT080=",
            LozinkaSalt = "9eyQRkv+NFWoZRbiVUwZzg=="
        };
        var klijent2 = new Klijent
        {
            Spol = spol2,
            Ime = "Lily",
            Prezime = "Aldrin",
            DatumRodjenja = new DateTime(1978, 3, 22),
            Email = "lilypad@hotmail.com",
            Telefon = "061/010-000",
            KorisnickoIme = "lilypad",
            LozinkaHash = "h9QKWWSdvAEzd8dwrea2YeASomg=",
            LozinkaSalt = "kYXzrFUT8dvKituo+QNnbQ=="
        };
        var klijent3 = new Klijent
        {
            Spol = spol1,
            Ime = "Barney",
            Prezime = "Stinson",
            DatumRodjenja = new DateTime(1976, 1, 1),
            Email = "swarley@hotmail.com",
            Telefon = "061/011-000",
            KorisnickoIme = "swarley",
            LozinkaHash = "tx9mV5Xnn5bnLekS/sLBx/h/Y+E=",
            LozinkaSalt = "1L551vtAGTF0OW4FLoZ/NA=="
        };
        var klijent4 = new Klijent
        {
            Spol = spol2,
            Ime = "Robin",
            Prezime = "Scherbatsky",
            DatumRodjenja = new DateTime(1980, 7, 23),
            Email = "sparkles@hotmail.com",
            Telefon = "061/100-000",
            KorisnickoIme = "robinSparkles",
            LozinkaHash = "bHQkzpdH+bE/1NV6yaxetvg3nEA=",
            LozinkaSalt = "m7DU/TW/NvIq5poLUC3IiQ=="
        };
        var klijent5 = new Klijent
        {
            Spol = spol1,
            Ime = "Ted",
            Prezime = "Mosby",
            DatumRodjenja = new DateTime(1978, 4, 25),
            Email = "t-mose@hotmail.com",
            Telefon = "061/101-000",
            KorisnickoIme = "schmosby",
            LozinkaHash = "mQ9xtEI3VFrAtrztvKHp9H+fY+A=",
            LozinkaSalt = "n9chNa53Sf/pKGJsfOAk8g=="
        };
        var klijent6 = new Klijent
        {
            Spol = spol2,
            Ime = "Barbara",
            Prezime = "Palvin",
            DatumRodjenja = new DateTime(1993, 10, 8),
            Email = "barbara@example.com",
            Telefon = "061/111-000",
            KorisnickoIme = "bpalvin",
            LozinkaHash = "R7knzsxms9o/wXl4Qazcx2vwWWs=",
            LozinkaSalt = "8x7q5F5s2Wjn4AKrJUjWJg=="
        };
        var klijent7 = new Klijent
        {
            Spol = spol1,
            Ime = "Testni",
            Prezime = "Klijent",
            DatumRodjenja = new DateTime(2000, 6, 26),
            Email = "mobile@edu.fit.ba",
            Telefon = "031/123-321",
            KorisnickoIme = "mobile",
            LozinkaHash = "rnFGSbqjUTOPWP+6+xVo65A6CRE=",
            LozinkaSalt = "tM8ZaCgldR+nc7ChawJ8og=="
        };
        var klijent8 = new Klijent
        {
            Spol = spol2,
            Ime = "Edina",
            Prezime = "Kamenjas",
            DatumRodjenja = new DateTime(1999, 8, 13),
            Email = "edina@gmail.com",
            Telefon = "033/456-789",
            KorisnickoIme = "edinna2",
            LozinkaHash = "J6MN9JFKO7nyttHu+RmADA+m/EU=",
            LozinkaSalt = "Ln7NA0dSPKuwlmvV4JhbMg=="
        };
        context.Klijents.Add(klijent1);
        context.Klijents.Add(klijent2);
        context.Klijents.Add(klijent3);
        context.Klijents.Add(klijent4);
        context.Klijents.Add(klijent5);
        context.Klijents.Add(klijent6);
        context.Klijents.Add(klijent7);
        context.Klijents.Add(klijent8);

        // Tip proizvoda
        var tipProizvoda1 = new TipProizvodum
        {
            Naziv = "Češalj"
        };
        var tipProizvoda2 = new TipProizvodum
        {
            Naziv = "Proizvodi za čišćenje četki"
        };
        var tipProizvoda3 = new TipProizvodum
        {
            Naziv = "Proizvodi za njegu kose"
        };
        var tipProizvoda1002 = new TipProizvodum
        {
            Naziv = "Šampon"
        };
        var tipProizvoda1003 = new TipProizvodum
        {
            Naziv = "Regenerator"
        };
        var tipProizvoda1004 = new TipProizvodum
        {
            Naziv = "Maska za kosu"
        };
        var tipProizvoda1005 = new TipProizvodum
        {
            Naziv = "Farba"
        };
        context.TipProizvoda.Add(tipProizvoda1);
        context.TipProizvoda.Add(tipProizvoda2);
        context.TipProizvoda.Add(tipProizvoda3);
        context.TipProizvoda.Add(tipProizvoda1002);
        context.TipProizvoda.Add(tipProizvoda1003);
        context.TipProizvoda.Add(tipProizvoda1004);
        context.TipProizvoda.Add(tipProizvoda1005);

        var proizvod2 = new Proizvod
        {
            TipProizvoda = tipProizvoda2,
            Cijena = 10.00m,
            Opis = "Opis proizvoda ovdje.",
            Naziv = "Čistač četki",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x75, 0x73, 0x65, 0x72, 0x5C, 0x44, 0x65, 0x73, 0x6B, 0x74, 0x6F, 0x70, 0x5C, 0x69, 0x6D, 0x61, 0x67, 0x65, 0x73, 0x2E, 0x70, 0x6E, 0x67 }
        };
        var proizvod4 = new Proizvod
        {
            TipProizvoda = tipProizvoda2,
            Cijena = 15.00m,
            Opis = "Lorem ipsum dolor sit amet, consectetur",
            Naziv = "Sredstvo za uklanjanje farbe",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x75, 0x73, 0x65, 0x72, 0x5C, 0x50, 0x69, 0x63, 0x74, 0x75, 0x72, 0x65, 0x73, 0x5C, 0x43, 0x61, 0x6D, 0x65, 0x72, 0x61, 0x20, 0x52, 0x6F, 0x6C, 0x6C, 0x5C, 0x57, 0x49, 0x4E, 0x5F, 0x32, 0x30, 0x32, 0x31, 0x30, 0x37, 0x30, 0x35, 0x5F, 0x31, 0x32, 0x5F, 0x31, 0x36, 0x5F, 0x34, 0x31, 0x5F, 0x50, 0x72, 0x6F, 0x2E, 0x6A, 0x70, 0x67 }
        };
        var proizvod5 = new Proizvod
        {
            TipProizvoda = tipProizvoda1003,
            Cijena = 50.00m,
            Opis = "Najbolji regeneratori za kosu",
            Naziv = "Regenerator za kosu Kerastase",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x64, 0x65, 0x73, 0x6B, 0x74, 0x6F, 0x70, 0x5C, 0x69, 0x6D, 0x61, 0x67, 0x65, 0x73, 0x2E, 0x70, 0x6E, 0x67 }
        };
        var proizvod6 = new Proizvod
        {
            TipProizvoda = tipProizvoda1002,
            Cijena = 2.00m,
            Opis = "Najbolji šamponi za svaki tip kose",
            Naziv = "Šampon za kosu Kerastase",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x64, 0x65, 0x73, 0x6B, 0x74, 0x6F, 0x70, 0x5C, 0x69, 0x6D, 0x61, 0x67, 0x65, 0x73, 0x2E, 0x70, 0x6E, 0x67 }
        };
        var proizvod7 = new Proizvod
        {
            TipProizvoda = tipProizvoda1005,
            Cijena = 2.00m,
            Opis = "Farba za plavuše",
            Naziv = "Farba za kosu F12345",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x64, 0x65, 0x73, 0x6B, 0x74, 0x6F, 0x70, 0x5C, 0x69, 0x6D, 0x61, 0x67, 0x65, 0x73, 0x2E, 0x70, 0x6E, 0x67 }
        };
        var proizvod8 = new Proizvod
        {
            TipProizvoda = tipProizvoda1,
            Cijena = 5.00m,
            Opis = "Češalj za mokru kosu",
            Naziv = "Macadamia četka za kosu",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x64, 0x65, 0x73, 0x6B, 0x74, 0x6F, 0x70, 0x5C, 0x69, 0x6D, 0x61, 0x67, 0x65, 0x73, 0x2E, 0x70, 0x6E, 0x67 }
        };
        var proizvod10 = new Proizvod
        {
            TipProizvoda = tipProizvoda1,
            Cijena = 3.00m,
            Opis = "Najkvalitetnija četka za kosu",
            Naziv = "Tangle teezer",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x64, 0x65, 0x73, 0x6B, 0x74, 0x6F, 0x70, 0x5C, 0x69, 0x6D, 0x61, 0x67, 0x65, 0x73, 0x5C, 0x75, 0x32, 0x2E, 0x6A, 0x70, 0x67 }
        };
        var proizvod11 = new Proizvod
        {
            TipProizvoda = tipProizvoda1003,
            Cijena = 7.00m,
            Opis = "Najpogodniji za oštećenu,suhu kosu",
            Naziv = "Regenerator za kosu syoss",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x64, 0x65, 0x73, 0x6B, 0x74, 0x6F, 0x70, 0x5C, 0x69, 0x6D, 0x61, 0x67, 0x65, 0x73, 0x5C, 0x65, 0x33, 0x2E, 0x6A, 0x70, 0x67 }
        };
        var proizvod12 = new Proizvod
        {
            TipProizvoda = tipProizvoda1003,
            Cijena = 3.00m,
            Opis = "Najpogodniji za tanku kosu",
            Naziv = "Regenerator Elseve",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x64, 0x65, 0x73, 0x6B, 0x74, 0x6F, 0x70, 0x5C, 0x69, 0x6D, 0x61, 0x67, 0x65, 0x73, 0x5C, 0x75, 0x31, 0x2E, 0x6A, 0x70, 0x67 }
        };
        var proizvod13 = new Proizvod
        {
            TipProizvoda = tipProizvoda1004,
            Cijena = 23.00m,
            Opis = "Najkvalitetnije maske za kosu",
            Naziv = "Maska za kosu Kerastase ",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x64, 0x65, 0x73, 0x6B, 0x74, 0x6F, 0x70, 0x5C, 0x69, 0x6D, 0x61, 0x67, 0x65, 0x73, 0x5C, 0x6F, 0x32, 0x2E, 0x6A, 0x70, 0x67 }
        };
        var proizvod14 = new Proizvod
        {
            TipProizvoda = tipProizvoda1004,
            Cijena = 6.00m,
            Opis = "Dostupno s promjerima od 6 mm do 12 mm.",
            Naziv = "Proizvod 11",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x64, 0x65, 0x73, 0x6B, 0x74, 0x6F, 0x70, 0x5C, 0x69, 0x6D, 0x61, 0x67, 0x65, 0x73, 0x5C, 0x6F, 0x31, 0x2E, 0x6A, 0x70, 0x67 }
        };
        var proizvod15 = new Proizvod
        {
            TipProizvoda = tipProizvoda1005,
            Cijena = 3.00m,
            Opis = "Dostupne različite opcije boja.",
            Naziv = "Proizvod 12",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x64, 0x65, 0x73, 0x6B, 0x74, 0x6F, 0x70, 0x5C, 0x69, 0x6D, 0x61, 0x67, 0x65, 0x73, 0x5C, 0x6A, 0x32, 0x2E, 0x6A, 0x70, 0x67 }
        };
        var proizvod16 = new Proizvod
        {
            TipProizvoda = tipProizvoda3,
            Cijena = 31.00m,
            Opis = "Umirujući balzam za njegu svježih tetova",
            Naziv = "Proizvod 13",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x64, 0x65, 0x73, 0x6B, 0x74, 0x6F, 0x70, 0x5C, 0x69, 0x6D, 0x61, 0x67, 0x65, 0x73, 0x5C, 0x74, 0x33, 0x2E, 0x6A, 0x70, 0x67 }
        };
        context.Proizvods.AddRange(proizvod2, proizvod4, proizvod5, proizvod6, proizvod7, proizvod8, proizvod10, proizvod11, proizvod12, proizvod13, proizvod14, proizvod15, proizvod16);

        // Tip Termina
        var tipTermina1 = new TipTermina
        {
            Naziv = "Šišanje"
        };
        var tipTermina2 = new TipTermina
        {
            Naziv = "Farbanje"
        };
        var tipTermina3 = new TipTermina { Naziv = "Brijanje" };

        context.TipTerminas.Add(tipTermina1);
        context.TipTerminas.Add(tipTermina2);
        context.TipTerminas.Add(tipTermina3);
        // Termin
        // Dodaj termine, mrsko mi se peglati oko ID-eva (koristi objekte umjesto ID
        // e.g umjesto SpolId = 1, koristi Spol = spol1,

        // Narudzba
        var narudzba1 = new Narudzba
        {
            Klijent = klijent7,
            Datum = new DateTime(2022, 8, 31),
            UkupniIznos = 27.00m,
            IsIsporucena = true,
            IsPlacena = true
        };
        var narudzba2 = new Narudzba
        {
            Klijent = klijent7,
            Datum = new DateTime(2022, 8, 31),
            UkupniIznos = 50.00m,
            IsIsporucena = true,
            IsPlacena = true
        };
        var narudzba3 = new Narudzba
        {
            Klijent = klijent7,
            Datum = new DateTime(2022, 8, 31),
            UkupniIznos = 11.00m,
            IsIsporucena = true,
            IsPlacena = true
        };
        var narudzba4 = new Narudzba
        {
            Klijent = klijent7,
            Datum = new DateTime(2022, 8, 31),
            UkupniIznos = 7.00m,
            IsIsporucena = true,
            IsPlacena = true
        };
        var narudzba5 = new Narudzba
        {
            Klijent = klijent7,
            Datum = new DateTime(2022, 8, 31),
            UkupniIznos = 12.00m,
            IsIsporucena = true,
            IsPlacena = true
        };
        var narudzba6 = new Narudzba
        {
            Klijent = klijent7,
            Datum = new DateTime(2022, 8, 31),
            UkupniIznos = 15.00m,
            IsIsporucena = true,
            IsPlacena = true
        };
        var narudzba7 = new Narudzba
        {
            Klijent = klijent2,
            Datum = new DateTime(2022, 8, 31),
            UkupniIznos = 2.00m,
            IsIsporucena = true,
            IsPlacena = true
        };
        var narudzba8 = new Narudzba
        {
            Klijent = klijent2,
            Datum = new DateTime(2022, 8, 31),
            UkupniIznos = 4.00m,
            IsIsporucena = false,
            IsPlacena = false
        };
        var narudzba9 = new Narudzba
        {
            Klijent = klijent7,
            Datum = new DateTime(2022, 9, 1),
            UkupniIznos = 22.00m,
            IsIsporucena = false,
            IsPlacena = false
        };
        var narudzba10 = new Narudzba
        {
            Klijent = klijent8,
            Datum = new DateTime(2022, 9, 1),
            UkupniIznos = 87.00m,
            IsIsporucena = false,
            IsPlacena = true
        };
        var narudzba11 = new Narudzba
        {
            Klijent = klijent5,
            Datum = new DateTime(2022, 9, 1),
            UkupniIznos = 56.00m,
            IsIsporucena = false,
            IsPlacena = false
        };
        var narudzba12 = new Narudzba
        {
            Klijent = klijent3,
            Datum = new DateTime(2022, 9, 1),
            UkupniIznos = 65.00m,
            IsIsporucena = false,
            IsPlacena = true
        };
        var narudzba13 = new Narudzba
        {
            Klijent = klijent1,
            Datum = new DateTime(2022, 9, 1),
            UkupniIznos = 85.00m,
            IsIsporucena = false,
            IsPlacena = false
        };
        var narudzba14 = new Narudzba
        {
            Klijent = klijent8,
            Datum = new DateTime(2022, 9, 1),
            UkupniIznos = 0.00m,
            IsIsporucena = false,
            IsPlacena = false
        };
        var narudzba15 = new Narudzba
        {
            Klijent = klijent3,
            Datum = new DateTime(2022, 9, 1),
            UkupniIznos = 0.00m,
            IsIsporucena = false,
            IsPlacena = false
        };
        context.Narudzbas.AddRange(narudzba1, narudzba2, narudzba3, narudzba4, narudzba5, narudzba6, narudzba7, narudzba8, narudzba9, narudzba10, narudzba11, narudzba12, narudzba13, narudzba14, narudzba15);

        // Narudzba Stavka
        var stavkeNarudzbe = new List<StavkeNarudzbe>
        {
            new StavkeNarudzbe
            {
                Narudzba = narudzba1,
                Proizvod = proizvod8,
                Kolicina = 2
            },
            // Add the remaining StavkeNarudzbe instances here...
        };
        context.StavkeNarudzbes.AddRange(stavkeNarudzbe);

        // Uposlenik
        var uposlenik1 = new Uposlenik
        {
            Zanimanje = frizer1,
            Spol = spol2,
            Ime = "Sophie",
            Prezime = "Hatter",
            Email = "sophie@gmail.com",
            Telefon = "061/000-001",
            KorisnickoIme = "sophie",
            LozinkaHash = "eW/XAZ/W8lBk40ONYTeyD/QEsEw=",
            LozinkaSalt = "VLT5DbwMnQuiq2x0r58I5g==",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x75, 0x73, 0x65, 0x72, 0x5C, 0x50, 0x69, 0x63, 0x74, 0x75, 0x72, 0x65, 0x73, 0x5C, 0x43, 0x61, 0x6D, 0x65, 0x72, 0x61, 0x20, 0x52, 0x6F, 0x6C, 0x6C, 0x5C, 0x57, 0x49, 0x4E, 0x5F, 0x32, 0x30, 0x32, 0x31, 0x30, 0x32, 0x31, 0x31, 0x5F, 0x31, 0x36, 0x5F, 0x34, 0x35, 0x5F, 0x35, 0x36, 0x5F, 0x50, 0x72, 0x6F, 0x2E, 0x6A, 0x70, 0x67 }
        };
        var uposlenik2 = new Uposlenik
        {
            Zanimanje = frizer2,
            Spol = spol1,
            Ime = "Howl",
            Prezime = "Jenkins",
            Email = "howl@gmail.com",
            Telefon = "061/000-010",
            KorisnickoIme = "howl",
            LozinkaHash = "eW/XAZ/W8lBk40ONYTeyD/QEsEw=",
            LozinkaSalt = "VLT5DbwMnQuiq2x0r58I5g==",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x75, 0x73, 0x65, 0x72, 0x5C, 0x50, 0x69, 0x63, 0x74, 0x75, 0x72, 0x65, 0x73, 0x5C, 0x43, 0x61, 0x6D, 0x65, 0x72, 0x61, 0x20, 0x52, 0x6F, 0x6C, 0x6C, 0x5C, 0x57, 0x49, 0x4E, 0x5F, 0x32, 0x30, 0x32, 0x31, 0x30, 0x32, 0x31, 0x31, 0x5F, 0x31, 0x36, 0x5F, 0x34, 0x35, 0x5F, 0x35, 0x36, 0x5F, 0x50, 0x72, 0x6F, 0x2E, 0x6A, 0x70, 0x67 }
        };
        var uposlenik3 = new Uposlenik
        {
            Zanimanje = frizer3,
            Spol = spol1,
            Ime = "Ashitaka",
            Prezime = "Leap",
            Email = "ashitaka@gmail.com",
            Telefon = "061/000-011",
            KorisnickoIme = "ashitaka",
            LozinkaHash = "eW/XAZ/W8lBk40ONYTeyD/QEsEw=",
            LozinkaSalt = "VLT5DbwMnQuiq2x0r58I5g==",
            Slika = new byte[] { 0x43, 0x61, 0x6D, 0x65, 0x72, 0x61, 0x20, 0x52, 0x6F, 0x6C, 0x6C, 0x5C, 0x57, 0x49, 0x4E, 0x5F, 0x32, 0x30, 0x32, 0x31, 0x30, 0x32, 0x31, 0x31, 0x5F, 0x31, 0x36, 0x5F, 0x34, 0x35, 0x5F, 0x35, 0x36, 0x5F, 0x50, 0x72, 0x6F, 0x2E, 0x6A, 0x70, 0x67 },
        };
        var uposlenik4 = new Uposlenik
        {
            Zanimanje = frizer4,
            Spol = spol2,
            Ime = "San",
            Prezime = "Mononoke",
            Email = "san@gmail.com",
            Telefon = "061/000-100",
            KorisnickoIme = "san",
            LozinkaHash = "eW/XAZ/W8lBk40ONYTeyD/QEsEw=",
            LozinkaSalt = "VLT5DbwMnQuiq2x0r58I5g==",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x75, 0x73, 0x65, 0x72, 0x5C, 0x50, 0x69, 0x63, 0x74, 0x75, 0x72, 0x65, 0x73, 0x5C, 0x43, 0x61, 0x6D, 0x65, 0x72, 0x61, 0x20, 0x52, 0x6F, 0x6C, 0x6C, 0x5C, 0x57, 0x49, 0x4E, 0x5F, 0x32, 0x30, 0x32, 0x31, 0x30, 0x32, 0x31, 0x31, 0x5F, 0x31, 0x36, 0x5F, 0x34, 0x35, 0x5F, 0x35, 0x36, 0x5F, 0x50, 0x72, 0x6F, 0x2E, 0x6A, 0x70, 0x67 }
        };
        var uposlenik5 = new Uposlenik
        {
            Zanimanje = frizer2,
            Spol = spol1,
            Ime = "Nigihayami",
            Prezime = "Kohakunushi",
            Email = "haku@gmail.com",
            Telefon = "061/000-101",
            KorisnickoIme = "haku",
            LozinkaHash = "eW/XAZ/W8lBk40ONYTeyD/QEsEw=",
            LozinkaSalt = "VLT5DbwMnQuiq2x0r58I5g==",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x75, 0x73, 0x65, 0x72, 0x5C, 0x50, 0x69, 0x63, 0x74, 0x75, 0x72, 0x65, 0x73, 0x5C, 0x43, 0x61, 0x6D, 0x65, 0x72, 0x61, 0x20, 0x52, 0x6F, 0x6C, 0x6C, 0x5C, 0x57, 0x49, 0x4E, 0x5F, 0x32, 0x30, 0x32, 0x31, 0x30, 0x32, 0x31, 0x31, 0x5F, 0x31, 0x36, 0x5F, 0x34, 0x35, 0x5F, 0x35, 0x36, 0x5F, 0x50, 0x72, 0x6F, 0x2E, 0x6A, 0x70, 0x67 }
        };
        var uposlenik7 = new Uposlenik
        {
            Zanimanje = frizer3,
            Spol = spol1,
            Ime = "Nigihayami",
            Prezime = "Kohakunushi",
            Email = "haku@gmail.com",
            Telefon = "061/000-101",
            KorisnickoIme = "haku",
            LozinkaHash = "eW/XAZ/W8lBk40ONYTeyD/QEsEw=",
            LozinkaSalt = "VLT5DbwMnQuiq2x0r58I5g==",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x50, 0x69, 0x63, 0x74, 0x75, 0x72, 0x65, 0x73, 0x5C, 0x43, 0x61, 0x6D, 0x65, 0x72, 0x61, 0x20, 0x52, 0x6F, 0x6C, 0x6C, 0x5C, 0x57, 0x49, 0x4E, 0x5F, 0x32, 0x30, 0x32, 0x31, 0x30, 0x32, 0x31, 0x35, 0x5F, 0x31, 0x36, 0x5F, 0x34, 0x35, 0x5F, 0x35, 0x36, 0x5F, 0x50, 0x72, 0x6F, 0x2E, 0x6A, 0x70, 0x67 }
        };
        var uposlenik8 = new Uposlenik
        {
            Zanimanje = frizer4,
            Spol = spol2,
            Ime = "Chihiro",
            Prezime = "Sen",
            Email = "chihiro@gmail.com",
            Telefon = "061/000-110",
            KorisnickoIme = "chihiro",
            LozinkaHash = "eW/XAZ/W8lBk40ONYTeyD/QEsEw=",
            LozinkaSalt = "VLT5DbwMnQuiq2x0r58I5g==",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x50, 0x69, 0x63, 0x74, 0x75, 0x72, 0x65, 0x73, 0x5C, 0x43, 0x61, 0x6D, 0x65, 0x72, 0x61, 0x20, 0x52, 0x6F, 0x6C, 0x6C, 0x5C, 0x57, 0x49, 0x4E, 0x5F, 0x32, 0x30, 0x32, 0x31, 0x30, 0x32, 0x31, 0x35, 0x5F, 0x31, 0x36, 0x5F, 0x34, 0x35, 0x5F, 0x35, 0x36, 0x5F, 0x50, 0x72, 0x6F, 0x2E, 0x6A, 0x70, 0x67 }
        };
        var uposlenik9 = new Uposlenik
        {
            Zanimanje = frizer1,
            Spol = spol2,
            Ime = "Testni",
            Prezime = "Uposlenik",
            Email = "desktop@edu.fit.ba",
            Telefon = "031/016-004",
            KorisnickoIme = "desktop",
            LozinkaHash = "DsaptxZCKGhqhBWmhC3Jkdh+7PA=",
            LozinkaSalt = "BYqTw0kS0w+iAZj1Xys6Sw==",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x75, 0x73, 0x65, 0x72, 0x5C, 0x50, 0x69, 0x63, 0x74, 0x75, 0x72, 0x65, 0x73, 0x5C, 0x44, 0x65, 0x73, 0x6B, 0x74, 0x6F, 0x70, 0x5C, 0x52, 0x53, 0x32, 0x2D, 0x73, 0x65, 0x6D, 0x69, 0x6E, 0x61, 0x72, 0x73, 0x6B, 0x69, 0x2D, 0x74, 0x61, 0x74, 0x74, 0x6F, 0x6F, 0x73, 0x74, 0x75, 0x64, 0x69, 0x6F, 0x5C, 0x52, 0x53, 0x32, 0x2D, 0x73, 0x65, 0x6D, 0x69, 0x6E, 0x61, 0x72, 0x73, 0x6B, 0x69, 0x2D, 0x74, 0x61, 0x74, 0x74, 0x6F, 0x6F, 0x73, 0x74, 0x75, 0x64, 0x69, 0x6F, 0x5C, 0x77, 0x77, 0x77, 0x72, 0x6F, 0x6F, 0x74, 0x5C, 0x69, 0x6D, 0x61, 0x67, 0x65, 0x73, 0x5C, 0x67, 0x72, 0x61, 0x64, 0x2E, 0x6A, 0x70, 0x67 }
        };
        // Nedostaju Emina i Azra
        context.Uposleniks.AddRange(uposlenik1, uposlenik2, uposlenik3, uposlenik4, uposlenik5, uposlenik7, uposlenik8, uposlenik9);

        // Izvjestaj
        var izvjestaji = new List<Izvjestaj>
        {
            new Izvjestaj
            {
                Uposlenik = uposlenik1,
                Datum = new DateTime(2022, 2, 2),
                Detalji = "Do datuma 02/02/2022 16:42:30 ste imali 7 termina, od kojih je 0 otkazano."
            },
            new Izvjestaj
            {
                Uposlenik = uposlenik1,
                Datum = new DateTime(2022, 5, 27),
                Detalji = "Od početka rada do datuma 27/05/2022 12:14:10 svi uposlenici su imali ukupno 10 termina, od kojih je 1 otkazano."
            },
            new Izvjestaj
            {
                Uposlenik = uposlenik1,
                Datum = new DateTime(2022, 5, 27),
                Detalji = "Od početka rada do datuma 27/05/2022 12:14:55 Vi ste imali 0 termina, od kojih je 0 otkazano."
            },
            new Izvjestaj
            {
                Uposlenik = uposlenik1,
                Datum = new DateTime(2022, 5, 27),
                Detalji = "Od početka rada do datuma 27/05/2022 12:18:03 Vi ste imali 10 termina, od kojih je 2 otkazano."
            },
            new Izvjestaj
            {
                Uposlenik = uposlenik1,
                Datum = new DateTime(2022, 5, 27),
                Detalji = "Od početka rada do datuma 27/05/2022 12:18:08 svi uposlenici su imali ukupno 12 termina, od kojih je 0 otkazano."
            },
            new Izvjestaj
            {
                Uposlenik = uposlenik1,
                Datum = new DateTime(2022, 5, 27),
                Detalji = "Od početka ovog mjeseca do datuma 27/05/2022 17:14:16 Vi ste imali 1 termina, od kojih je 0 otkazano."
            },
            new Izvjestaj
            {
                Uposlenik = uposlenik1,
                Datum = new DateTime(2022, 5, 27),
                Detalji = "Od početka ove godine do datuma 27/05/2022 22:12:19 Vi ste imali 2 termina, od kojih je 1 otkazano."
            },
            new Izvjestaj
            {
                Uposlenik = uposlenik2,
                Datum = new DateTime(2023, 8, 12),
                Detalji = "Od početka ove godine do datuma 08/31/2022 19:12:47 Vi ste imali 3 termina, od kojih je 3 otkazano."
            },
            new Izvjestaj
            {
                Uposlenik = uposlenik2,
                Datum = new DateTime(2022, 8, 31),
                Detalji = "Od početka rada do datuma 08/31/2022 19:13:16 svi uposlenici su imali ukupno 9 termina, od kojih je 7 otkazano."
            }
        };
        context.Izvjestajs.AddRange(izvjestaji);

        // Obavijest
        var obavijest1 = new Obavijest
        {
            Uposlenik = uposlenik1,
            Datum = new DateTime(2022, 5, 27),
            Naslov = "Provjera datuma",
            Sadrzaj = "Testiram datum Update radiii"
        };
        var obavijest2 = new Obavijest
        {
            Uposlenik = uposlenik1,
            Datum = new DateTime(2022, 5, 27),
            Naslov = "Test",
            Sadrzaj = "Pažnja pažnja obavještavamo vas da..."
        };
        var obavijest3 = new Obavijest
        {
            Uposlenik = uposlenik1,
            Datum = new DateTime(2022, 5, 27),
            Naslov = "Lorem ipsum",
            Sadrzaj = "Tekst obavijesti"
        };
        var obavijest4 = new Obavijest
        {
            Uposlenik = uposlenik3,
            Datum = new DateTime(2022, 7, 6),
            Naslov = "Obavijest1",
            Sadrzaj = "Tekst obavijesti"
        };
        var obavijest5 = new Obavijest
        {
            Uposlenik = uposlenik3,
            Datum = new DateTime(2022, 8, 31),
            Naslov = "Debugging",
            Sadrzaj = "Let's debug. All okay!"
        };
        var obavijest6 = new Obavijest
        {
            Uposlenik = uposlenik3,
            Datum = new DateTime(2022, 8, 31),
            Naslov = "Obavijest2",
            Sadrzaj = "Okej, sve radi."
        };
        var obavijest7 = new Obavijest
        {
            Uposlenik = uposlenik2,
            Datum = new DateTime(2022, 9, 1),
            Naslov = "Godišnji odmor",
            Sadrzaj = "Poštovani, obavještavamo vas da studio neće raditi od 01.09. do 14.09. zbog kolektivnog godišnjeg odmora."
        };
        var obavijest8 = new Obavijest
        {
            Uposlenik = uposlenik2,
            Datum = new DateTime(2022, 9, 1),
            Naslov = "Walk-in day",
            Sadrzaj = "16.09. u našem studiju će se održati walk in day. Klijenti mogu doći bez zakazanog termina."
        };
        context.Obavijests.AddRange(obavijest1, obavijest2, obavijest3, obavijest4, obavijest5, obavijest6, obavijest7, obavijest8);

        // Portfolio
        var portfolio1 = new Portfolio
        {
            Opis = "Lorem ipsum portfolio opis",
            Uposlenik = uposlenik1
        };
        var portfolio2 = new Portfolio
        {
            Opis = "Samo da provjerim neštoo",
            Uposlenik = uposlenik3
        };
        var portfolio3 = new Portfolio
        {
            Opis = "Portfolio ovog korisnika.",
            Uposlenik = uposlenik2
        };
        var portfolio4 = new Portfolio
        {
            Opis = "Dobrodošli! Ovo je moj portfolio.",
            Uposlenik = uposlenik4
        };
        var portfolio5 = new Portfolio
        {
            Opis = "Nadam se da radi :)",
            Uposlenik = uposlenik5
        };
        var portfolio6 = new Portfolio
        {
            Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut",
            Uposlenik = uposlenik7
        };
        var portfolio7 = new Portfolio
        {
            Opis = "Uposlenik radi pretežno custom made dizajne s fokusom na cvijetnim i prirodnim motivima...",
            Uposlenik = uposlenik8
        };
        var portfolio8 = new Portfolio
        {
            Opis = "*opis rada ovdje*",
            Uposlenik = uposlenik9
        };
        context.Portfolios.AddRange(portfolio1, portfolio2, portfolio3, portfolio4, portfolio5, portfolio6, portfolio7, portfolio8);

        // Portfolio Stavka
        context.StavkePortfolia.Add(new StavkePortfolium
        {
            Portfolio = portfolio2,
            Datum = new DateTime(2022, 5, 25),
            Opis = "Asd",
            Slika = new byte[] { 0x43, 0x3A, 0x5C, 0x55, 0x73, 0x65, 0x72, 0x73, 0x5C, 0x75, 0x73, 0x65, 0x72, 0x5C, 0x50, 0x69, 0x63, 0x74, 0x75, 0x72, 0x65, 0x73, 0x5C, 0x43, 0x61, 0x6D, 0x65, 0x72, 0x61, 0x20, 0x52, 0x6F, 0x6C, 0x6C, 0x5C, 0x57, 0x49, 0x4E, 0x5F, 0x32, 0x30, 0x32, 0x31, 0x30, 0x32, 0x31, 0x31, 0x35, 0x5F, 0x31, 0x36, 0x5F, 0x34, 0x35, 0x5F, 0x35, 0x36, 0x5F, 0x50, 0x72, 0x6F, 0x2E, 0x6A, 0x70, 0x67 }
        });
        // Add the rest
        context.StavkePortfolia.AddRange();


        context.SaveChanges();
    }
}