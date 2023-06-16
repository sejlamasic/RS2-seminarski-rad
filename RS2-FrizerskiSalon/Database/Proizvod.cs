using System;
using System.Collections.Generic;

namespace RS2_FrizerskiSalon.Database;

public partial class Proizvod
{
    public int ProizvodId { get; set; }

    public int? TipProizvodaId { get; set; }
#nullable enable
    public decimal? Cijena { get; set; }
#nullable enable
    public string? Opis { get; set; }
#nullable enable
    public string? Naziv { get; set; }

    public byte[]? Slika { get; set; }

    public virtual ICollection<StavkeNarudzbe> StavkeNarudzbes { get; set; } = new List<StavkeNarudzbe>();

    public virtual TipProizvodum? TipProizvoda { get; set; }
}
