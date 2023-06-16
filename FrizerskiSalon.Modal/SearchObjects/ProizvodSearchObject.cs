using System;
using System.Collections.Generic;
using System.Text;

namespace FrizerskiSalon.Modal.SearchObjects
{
    public class ProizvodSearchObject
    {
        public string Naziv { get; set; }
        public int? TipProizvodaId { get; set; }
        public decimal? Cijena { get; set; }
        //public bool? IncludeTipProizvoda { get; set; }
        //public string[] IncludeList { get; set; }

    }
}
