using System;
using System.Collections.Generic;
using System.Text;

namespace FrizerskiSalon.Modal.Requests
{
    public class TerminUpdateRequest
    {
        public float Cijena { get; set; }
        public bool? IsOdobren { get; set; }
        public bool? IsPlacen { get; set; }
        public bool? IsOtkazan { get; set; }
        public string Komentar { get; set; }
    }
}
