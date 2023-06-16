using System.ComponentModel.DataAnnotations;

namespace FrizerskiSalon.Modal.Requests
{
    public class PortfolioInsertRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Obavezno polje")]
        [MaxLength(100, ErrorMessage = "Maksimalna dužina ovog polja je 100 znakova")]
        public string Opis { get; set; }
        public int? Uposlenikid { get; set; }
    }
}
