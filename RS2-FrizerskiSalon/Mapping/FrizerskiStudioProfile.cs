using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrizerskiSalon.Modal.Requests;

namespace RS2_FrizerskiSalon.Mapping
{
    public class FrizerskiStudioProfile : Profile
    {
        public FrizerskiStudioProfile()
        {
            CreateMap<Database.Klijent, FrizerskiSalon.Modal.Klijent>().ReverseMap();
            CreateMap<Database.Klijent, KlijentInsertRequest>().ReverseMap();
            CreateMap<Database.Uposlenik, FrizerskiSalon.Modal.Uposlenik>().ReverseMap();
            CreateMap<Database.Uposlenik, UposlenikInsertRequest>().ReverseMap();
            CreateMap<Database.Spol, FrizerskiSalon.Modal.Spol>().ReverseMap();
            CreateMap<Database.Zanimanje, FrizerskiSalon.Modal.Zanimanje>().ReverseMap();
            CreateMap<Database.TipProizvodum, FrizerskiSalon.Modal.TipProizvodum>().ReverseMap();
            CreateMap<Database.Proizvod, FrizerskiSalon.Modal.Proizvod>().ReverseMap();
            CreateMap<Database.Proizvod, ProizvodInsertRequest>().ReverseMap();
            CreateMap<Database.Izvjestaj, FrizerskiSalon.Modal.Izvjestaj>().ReverseMap();
            CreateMap<Database.Izvjestaj, IzvjestajInsertRequest>().ReverseMap();
            CreateMap<Database.Obavijest, FrizerskiSalon.Modal.Obavijest>().ReverseMap();
            CreateMap<Database.Obavijest, ObavijestInsertRequest>().ReverseMap();
            CreateMap<Database.Obavijest, ObavijestUpdateRequest>().ReverseMap();
            CreateMap<Database.TipTermina, FrizerskiSalon.Modal.TipTermina>().ReverseMap();
            CreateMap<Database.StavkePortfolium, FrizerskiSalon.Modal.StavkePortfolium>().ReverseMap();
            CreateMap<Database.StavkePortfolium, StavkePortfoliumInsertRequest>().ReverseMap();
            CreateMap<Database.Termin, FrizerskiSalon.Modal.Termin>().ReverseMap();
            CreateMap<Database.Termin, TerminInsertRequest>().ReverseMap();
            CreateMap<Database.Termin, TerminUpdateRequest>().ReverseMap();
            CreateMap<Database.Portfolio, FrizerskiSalon.Modal.Portfolio>().ReverseMap();
            CreateMap<Database.Portfolio, PortfolioInsertRequest>().ReverseMap();
            CreateMap<Database.StavkeNarudzbe, FrizerskiSalon.Modal.StavkeNarudzbe>().ReverseMap();
            CreateMap<Database.StavkeNarudzbe, StavkeNarudzbeInsertRequest>().ReverseMap();
            CreateMap<Database.StavkeNarudzbe, StavkeNarudzbeUpdateRequest>().ReverseMap();
            CreateMap<Database.Narudzba, FrizerskiSalon.Modal.Narudzba>().ReverseMap();
            CreateMap<Database.Narudzba, NarudzbaInsertRequest>().ReverseMap();
        }
    }
}
