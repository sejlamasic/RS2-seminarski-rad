using System;
using System.Collections.Generic;
using System.Text;

namespace FrizerskiSalon.Modal.Requests
{
    public class IzvjestajInsertRequest
    {
        public int? UposlenikId { get; set; }
        public bool? Mjesecni { get; set; }
        public bool? Godisnji { get; set; }
        public bool? OdPocetka { get; set; }
        public bool? zaJednogUposlenog { get; set; }
        public bool? zaSveUposlene { get; set; }

    }
}
