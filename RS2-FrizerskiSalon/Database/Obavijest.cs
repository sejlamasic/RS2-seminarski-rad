using System;
using System.Collections.Generic;

namespace RS2_FrizerskiSalon.Database;

public partial class Obavijest
{
    public int ObavijestId { get; set; }

    public int? UposlenikId { get; set; }

    public DateTime? Datum { get; set; }
    #nullable enable
    public string? Naslov { get; set; }

    public string? Sadrzaj { get; set; }

    public virtual Uposlenik? Uposlenik { get; set; }
}
