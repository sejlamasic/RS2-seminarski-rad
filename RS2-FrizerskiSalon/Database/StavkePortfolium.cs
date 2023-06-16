using System;
using System.Collections.Generic;

namespace RS2_FrizerskiSalon.Database;

public partial class StavkePortfolium
{
    public int StavkaPortfoliaId { get; set; }
#nullable enable
    public int? PortfolioId { get; set; }
#nullable enable
    public DateTime? Datum { get; set; }
#nullable enable
    public string? Opis { get; set; }
#nullable enable
    public byte[]? Slika { get; set; }
#nullable enable
    public virtual Portfolio? Portfolio { get; set; }
}
