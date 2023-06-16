﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FrizerskiSalon.Modal.Requests
{
    public class ObavijestInsertRequest
    {
        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        [MinLength(3, ErrorMessage = "Minimalna dužina ovog polja je 3 znaka")]
        [MaxLength(50, ErrorMessage = "Maksimalna dužina ovog polja je 50 znakova")]
        public string Naslov { get; set; }
        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        [MinLength(3, ErrorMessage = "Minimalna dužina ovog polja je 3 znaka")]
        [MaxLength(500, ErrorMessage = "Maksimalna dužina ovog polja je 500 znakova")]
        public string Sadrzaj { get; set; }
        public int UposlenikId { get; set; }
        public DateTime Datum { get; set; }
    }
}
