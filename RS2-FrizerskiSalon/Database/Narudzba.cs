using System;
using System.Collections.Generic;

namespace RS2_FrizerskiSalon.Database;

public partial class Narudzba
{
    public int NarudzbaId { get; set; }

    public int? KlijentId { get; set; }

    public DateTime? Datum { get; set; }

    public decimal? UkupniIznos { get; set; }

    public bool? IsIsporucena { get; set; }
#nullable enable
    public bool? IsPlacena { get; set; }

    public virtual Klijent? Klijent { get; set; }

    public virtual ICollection<StavkeNarudzbe> StavkeNarudzbes { get; set; } = new List<StavkeNarudzbe>();
}
