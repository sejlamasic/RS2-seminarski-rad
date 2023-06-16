using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RS2_FrizerskiSalon.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;
using RS2_FrizerskiSalon.Services;

namespace RS2_FrizerskiSalon.Services
{
    public class IzvjestajService : BaseCRUDService<FrizerskiSalon.Modal.Izvjestaj, Izvjestaj, IzvjestajSearchObject, IzvjestajInsertRequest, object>, IIzvjestajService
    {
        public IzvjestajService(FrizerskiStudioRsiiContext context, IMapper mapper)
            :base(context, mapper)
        {
        }

        public override IList<FrizerskiSalon.Modal.Izvjestaj> Get(IzvjestajSearchObject search = null)
        {
            var entity = _context.Set<Izvjestaj>().AsQueryable();
            if (search?.UposlenikId.HasValue == true)
            {
                entity = entity.Where(x => x.UposlenikId == search.UposlenikId);
            }
            if (search?.Datum != null)
            {
                entity = entity.Where(x => x.Datum == search.Datum);
            }
            entity.Include(x => x.Uposlenik).ThenInclude(x => x.Zanimanje);
            var result = entity.OrderByDescending(x => x.Datum).ToList();
            return _mapper.Map<IList<FrizerskiSalon.Modal.Izvjestaj>>(result);
        }

        public override FrizerskiSalon.Modal.Izvjestaj Insert(IzvjestajInsertRequest request)
        {
            var novi = new Izvjestaj()
            {
                UposlenikId = request.UposlenikId,
                Datum = DateTime.Now
            };
            int sviTermini = 0, otkazaniTermini = 0;
            if (request.zaJednogUposlenog == true)
            {
                if (request.Mjesecni == true)
                {
                    var danasnjiDatum = DateTime.Now;
                    sviTermini = _context.Termins.Where(x => x.UposlenikId == request.UposlenikId && x.Datum.Value.Month == danasnjiDatum.Month).Count();
                    otkazaniTermini = _context.Termins.Where(x => x.UposlenikId == request.UposlenikId && x.IsOtkazan == true && x.Datum.Value.Month == danasnjiDatum.Month).Count();
                    novi.Detalji = $"Od početka ovog mjeseca do datuma {novi.Datum} Vi ste imali {sviTermini} termina, od kojih je {otkazaniTermini} otkazano.";
                }
                else if (request.Godisnji == true)
                {
                    var danasnjiDatum = DateTime.Now;
                    sviTermini = _context.Termins.Where(x => x.UposlenikId == request.UposlenikId && x.Datum.Value.Year == danasnjiDatum.Year).Count();
                    otkazaniTermini = _context.Termins.Where(x => x.UposlenikId == request.UposlenikId && x.IsOtkazan == true && x.Datum.Value.Year == danasnjiDatum.Year).Count();
                    novi.Detalji = $"Od početka ove godine do datuma {novi.Datum} Vi ste imali {sviTermini} termina, od kojih je {otkazaniTermini} otkazano.";
                }
                else
                {
                    //ako je request.OdPocetka==true ili nista nije odabrano
                    sviTermini = _context.Termins.Where(x => x.UposlenikId == request.UposlenikId).Count();
                    otkazaniTermini = _context.Termins.Where(x => x.UposlenikId == request.UposlenikId && x.IsOtkazan == true).Count();
                    novi.Detalji = $"Od početka rada do datuma {novi.Datum} Vi ste imali {sviTermini} termina, od kojih je {otkazaniTermini} otkazano.";
                }
            }
            else //ovo vraca izvjestaj za sve uposlenike, a ne samo za trenutno logiranog
            {
                if (request.Mjesecni == true)
                {
                    var danasnjiDatum = DateTime.Now;
                    sviTermini = _context.Termins.Where(x => x.Datum.Value.Month == danasnjiDatum.Month).Count();
                    otkazaniTermini = _context.Termins.Where(x => x.IsOtkazan == true && x.Datum.Value.Month == danasnjiDatum.Month).Count();
                    novi.Detalji = $"Od početka ovog mjeseca do datuma {novi.Datum} svi uposlenici su imali ukupno {sviTermini} termina, od kojih je {otkazaniTermini} otkazano.";
                }
                else if (request.Godisnji == true)
                {
                    var danasnjiDatum = DateTime.Now;
                    sviTermini = _context.Termins.Where(x => x.Datum.Value.Year == danasnjiDatum.Year).Count();
                    otkazaniTermini = _context.Termins.Where(x => x.IsOtkazan == true && x.Datum.Value.Year == danasnjiDatum.Year).Count();
                    novi.Detalji = $"Od početka ove godine do datuma {novi.Datum} svi uposlenici su imali ukupno {sviTermini} termina, od kojih je {otkazaniTermini} otkazano.";
                }
                else
                {
                    sviTermini = _context.Termins.Count();
                    otkazaniTermini = _context.Termins.Where(x => x.IsOtkazan == true).Count();
                    novi.Detalji = $"Od početka rada do datuma {novi.Datum} svi uposlenici su imali ukupno {sviTermini} termina, od kojih je {otkazaniTermini} otkazano.";
                }
            }
            _context.Izvjestajs.Add(novi);
            _context.SaveChanges();
            return _mapper.Map<FrizerskiSalon.Modal.Izvjestaj>(novi);
        }

        public override FrizerskiSalon.Modal.Izvjestaj Update(int id, object request)
        {
            //nije moguce mijenjati izvjestaje
            var entity = _context.Izvjestajs.Find(id);
            return _mapper.Map<FrizerskiSalon.Modal.Izvjestaj>(entity);
        }
    }
}
