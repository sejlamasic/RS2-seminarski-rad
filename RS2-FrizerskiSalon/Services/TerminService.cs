using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RS2_FrizerskiSalon.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;

namespace RS2_FrizerskiSalon.Services
{
    public class TerminService : BaseCRUDService<FrizerskiSalon.Modal.Termin, Termin, TerminSearchObject, TerminInsertRequest, TerminUpdateRequest>, ITerminService
    {
        public TerminService(FrizerskiStudioRsiiContext context, IMapper mapper)
            :base(context, mapper)
        {
            /*var neplaceniTermini = _context.Termins.Where(x => x.Datum <= DateTime.Now.AddDays(3) && x.IsPlacen == false && x.IsOtkazan == false);
            //var neplaceniTermini = _context.Termins.Where(x => ((TimeSpan)(x.Datum - DateTime.Now)).TotalDays < 3 && x.IsPlacen == false);
            foreach(var x in neplaceniTermini)
            {
                x.IsOtkazan = true;
                x.IsOdobren = false;
                x.Komentar = "Automatski otkazan jer termin nije bio uplaćen, a do termina je ostalo manje od 3 dana";
            }
            _context.SaveChanges();*/
        }

        public override IList<FrizerskiSalon.Modal.Termin> Get(TerminSearchObject search = null)
        {
            var entity = _context.Set<Termin>().AsQueryable();
            if(search?.IsOdobren == false)
            {
                entity = entity.Where(x => x.IsOdobren == search.IsOdobren);
            }
            if (search?.IsPlacen == true)
            {
                entity = entity.Where(x => x.IsPlacen == search.IsPlacen);
            }
            if (search?.IsOtkazan == true)
            {
                entity = entity.Where(x => x.IsOtkazan == search.IsOtkazan);
            }
            if (search?.Datum != null)
            {
                entity = entity.Where(x => x.Datum == search.Datum);
            }
            if (search?.UposlenikId.HasValue == true)
            {
                entity = entity.Where(x => x.UposlenikId == search.UposlenikId);
            }
            if (search?.KlijentId.HasValue == true)
            {
                entity = entity.Where(x => x.KlijentId == search.KlijentId);
            }
            if (search?.NadolazeciTermini == true)
            {
                entity = entity.Where(x => x.Datum > DateTime.Now);
            }
            var result = entity.Include(x => x.Klijent)
                .Include(x => x.Uposlenik)
                .Include(x => x.TipTermina)
                .OrderBy(x => x.Datum).ToList();
            return _mapper.Map<IList<FrizerskiSalon.Modal.Termin>>(result);
        }

        public override FrizerskiSalon.Modal.Termin GetById(int id)
        {
            var entity = _context.Termins.Include(x => x.Klijent)
                .Include(x => x.TipTermina)
                .Where(x => x.TerminId == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<FrizerskiSalon.Modal.Termin>(entity);
        }


        public bool SetPaid(int id)
        {
            var entity = _context.Termins.Find(id);
            entity.IsPlacen = true;
            _context.SaveChanges();
            return true;
        }

        public override FrizerskiSalon.Modal.Termin Insert(TerminInsertRequest request)
        {
            var entity = _mapper.Map<Termin>(request);
            entity.Cijena = 0;
            entity.Komentar = "";
            _context.Termins.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<FrizerskiSalon.Modal.Termin>(entity);
        }

    }
}
