using System;
using System.Collections.Generic;
using System.Text;

namespace FrizerskiSalon.Modal
{
    public class Zanimanje
    {
        public int ZanimanjeId { get; set; }
        public string Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
