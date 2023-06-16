using System;
using System.Collections.Generic;

namespace RS2_FrizerskiSalon.Database;

public partial class StavkeNarudzbe
{
    public int StavkeNarudzbeId { get; set; }
#nullable enable
    public int? NarudzbaId { get; set; }
#nullable enable
    public int? ProizvodId { get; set; }
#nullable enable
    public int? Kolicina { get; set; }
#nullable enable
    public virtual Narudzba? Narudzba { get; set; }
#nullable enable
    public virtual Proizvod? Proizvod { get; set; }
}
