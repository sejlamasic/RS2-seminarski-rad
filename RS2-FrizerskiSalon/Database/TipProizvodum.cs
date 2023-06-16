using System;
using System.Collections.Generic;

namespace RS2_FrizerskiSalon.Database;

public partial class TipProizvodum
{
#nullable enable
    public int TipProizvodaId { get; set; }

    public string? Naziv { get; set; }

    public virtual ICollection<Proizvod> Proizvods { get; set; } = new List<Proizvod>();
}
