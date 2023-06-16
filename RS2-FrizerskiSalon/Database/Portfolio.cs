using System;
using System.Collections.Generic;

namespace RS2_FrizerskiSalon.Database;

public partial class Portfolio
{
    public int PortfolioId { get; set; }
#nullable enable
    public string? Opis { get; set; }

    public int? UposlenikId { get; set; }

    public virtual ICollection<StavkePortfolium> StavkePortfolia { get; set; } = new List<StavkePortfolium>();

    public virtual Uposlenik? Uposlenik { get; set; }
}
