using System;
using System.Collections.Generic;
using System.Text;

namespace FrizerskiSalon.Modal
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public string Opis { get; set; }
        public int? Uposlenikid { get; set; }
        public virtual Uposlenik Uposlenik { get; set; }
        public virtual ICollection<StavkePortfolium> StavkePortfolia { get; set; }
    }
}
