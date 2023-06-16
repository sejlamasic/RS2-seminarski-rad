using System;
using System.Collections.Generic;

namespace RS2_FrizerskiSalon.Database;

public partial class Spol
{
#nullable enable
    public int SpolId { get; set; }

    public string? Naziv { get; set; }

    public virtual ICollection<Klijent> Klijents { get; set; } = new List<Klijent>();

    public virtual ICollection<Uposlenik> Uposleniks { get; set; } = new List<Uposlenik>();
}
