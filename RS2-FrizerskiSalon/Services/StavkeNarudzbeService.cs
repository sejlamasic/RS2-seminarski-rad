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
    public class StavkeNarudzbeService : BaseCRUDService<FrizerskiSalon.Modal.StavkeNarudzbe, StavkeNarudzbe, StavkeNarudzbeSearchObject, StavkeNarudzbeInsertRequest, StavkeNarudzbeUpdateRequest>, IStavkeNarudzbeService
    {
        public StavkeNarudzbeService(FrizerskiStudioRsiiContext context, IMapper mapper)
            :base(context, mapper)
        {
        }

        public override IList<FrizerskiSalon.Modal.StavkeNarudzbe> Get(StavkeNarudzbeSearchObject search = null)
        {
            var entity = _context.Set<StavkeNarudzbe>().AsQueryable();
            if (search?.NarudzbaId.HasValue == true)
            {
                entity = entity.Where(x => x.NarudzbaId == search.NarudzbaId);
            }
            if (search?.ProizvodId.HasValue == true)
            {
                entity = entity.Where(x => x.ProizvodId == search.ProizvodId);
            }
            if (search?.KlijentId.HasValue == true)
            {
                entity = entity.Where(x => x.Narudzba.KlijentId == search.KlijentId);
            }
            var result = entity/*.Include(x => x.Narudzba).Include(x => x.Narudzba.Klijent)*/.ToList();
            return _mapper.Map<IList<FrizerskiSalon.Modal.StavkeNarudzbe>>(result);
        }

        public override FrizerskiSalon.Modal.StavkeNarudzbe Insert(StavkeNarudzbeInsertRequest request)
        {
            var entity = _mapper.Map<Database.StavkeNarudzbe>(request);

            decimal? updateUkupniIznos = 0;
            var naruceniProizvod = _context.Proizvods.Find(request.ProizvodId);
            var narudzba = _context.Narudzbas.Find(entity.NarudzbaId);

            bool proizvodVecNarucen = _context.StavkeNarudzbes.Where(x => x.NarudzbaId == request.NarudzbaId && x.ProizvodId == request.ProizvodId).Any();
            if(!proizvodVecNarucen)
            {
                _context.Set<Database.StavkeNarudzbe>().Add(entity);
                _context.SaveChanges();
                updateUkupniIznos = naruceniProizvod.Cijena * request.Kolicina;
                narudzba.UkupniIznos += updateUkupniIznos;
                _context.SaveChanges();
                return _mapper.Map<FrizerskiSalon.Modal.StavkeNarudzbe>(entity);
            }
            else
            {
                var stavka = _context.StavkeNarudzbes.Where(x => x.ProizvodId == request.ProizvodId && x.NarudzbaId == request.NarudzbaId).FirstOrDefault();
                stavka.Kolicina += request.Kolicina;
                updateUkupniIznos = naruceniProizvod.Cijena * request.Kolicina;
                narudzba.UkupniIznos += updateUkupniIznos;
                _context.SaveChanges();
            }
            return _mapper.Map<FrizerskiSalon.Modal.StavkeNarudzbe>(entity);
        }

        public override bool Delete(int id)
        {
            if (id != 0)
            {
                var stavka = _context.StavkeNarudzbes.Find(id);
                var proizvod = _context.Proizvods.Find(stavka.ProizvodId);
                var narudzba = _context.Narudzbas.Find(stavka.NarudzbaId);
                var umanjiUkupniIznos = proizvod.Cijena * stavka.Kolicina;
                narudzba.UkupniIznos -= umanjiUkupniIznos;
                _context.Remove(stavka);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
