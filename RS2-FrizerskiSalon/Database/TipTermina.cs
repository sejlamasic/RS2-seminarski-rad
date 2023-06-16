using System;
using System.Collections.Generic;

namespace RS2_FrizerskiSalon.Database;

public partial class TipTermina
{
#nullable enable
    public int TipTerminaId { get; set; }

    public string? Naziv { get; set; }

    public virtual ICollection<Termin> Termins { get; set; } = new List<Termin>();
}
