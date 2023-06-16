using System;
using System.Collections.Generic;

namespace RS2_FrizerskiSalon.Database;

public partial class Klijent
{
    
    public int KlijentId { get; set; }
    #nullable enable
    public int? SpolId { get; set; }
    #nullable enable
    public string? Ime { get; set; }
#nullable enable
    public string? Prezime { get; set; }

    public DateTime? DatumRodjenja { get; set; }
#nullable enable
    public string? Email { get; set; }
#nullable enable
    public string? Telefon { get; set; }
#nullable enable
    public string? KorisnickoIme { get; set; }
#nullable enable
    public string? LozinkaHash { get; set; }
#nullable enable
    public string? LozinkaSalt { get; set; }

    public virtual ICollection<Narudzba> Narudzbas { get; set; } = new List<Narudzba>();
#nullable enable
    public virtual Spol? Spol { get; set; }

    public virtual ICollection<Termin> Termins { get; set; } = new List<Termin>();
}
