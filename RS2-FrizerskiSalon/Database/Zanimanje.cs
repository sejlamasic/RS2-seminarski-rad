using System;
using System.Collections.Generic;

namespace RS2_FrizerskiSalon.Database;

public partial class Zanimanje
{
#nullable enable
    public int ZanimanjeId { get; set; }

    public string? Naziv { get; set; }

    public virtual ICollection<Uposlenik> Uposleniks { get; set; } = new List<Uposlenik>();
}
