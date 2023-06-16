using System;
using System.Collections.Generic;

namespace RS2_FrizerskiSalon.Database;

public partial class Uposlenik
{
    #nullable enable
    public int UposlenikId { get; set; }

    public int? ZanimanjeId { get; set; }

    public int? SpolId { get; set; }

    public string? Ime { get; set; }

    public string? Prezime { get; set; }

    public string? Email { get; set; }

    public string? Telefon { get; set; }

    public string? KorisnickoIme { get; set; }

    public string? LozinkaHash { get; set; }

    public string? LozinkaSalt { get; set; }

    public byte[]? Slika { get; set; }

    public virtual ICollection<Izvjestaj> Izvjestajs { get; set; } = new List<Izvjestaj>();

    public virtual ICollection<Obavijest> Obavijests { get; set; } = new List<Obavijest>();

    public virtual Portfolio? Portfolio { get; set; }

    public virtual Spol? Spol { get; set; }

    public virtual ICollection<Termin> Termins { get; set; } = new List<Termin>();

    public virtual Zanimanje? Zanimanje { get; set; }
}
