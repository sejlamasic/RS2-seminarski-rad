using System;
using System.Collections.Generic;

namespace RS2_FrizerskiSalon.Database;

public partial class Izvjestaj
{
    public int IzvjestajId { get; set; }

    public int? UposlenikId { get; set; }

    public DateTime? Datum { get; set; }
    #nullable enable
    public string? Detalji { get; set; }

    public virtual Uposlenik? Uposlenik { get; set; }
}
