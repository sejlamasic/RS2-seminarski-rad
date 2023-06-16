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
    public class PortfolioService : BaseCRUDService<FrizerskiSalon.Modal.Portfolio, Portfolio, PortfolioSearchObject, PortfolioInsertRequest, PortfolioInsertRequest>, IPortfolioService
    {
        public PortfolioService(FrizerskiStudioRsiiContext context, IMapper mapper)
            :base(context, mapper)
        {
        }

        public override IList<FrizerskiSalon.Modal.Portfolio> Get(PortfolioSearchObject search = null)
        {
            var entity = _context.Set<Portfolio>().AsQueryable();
            if (search?.UposlenikId.HasValue == true)
            {
                entity = entity.Where(x => x.UposlenikId == search.UposlenikId);
            }
            var result = entity.Include(x => x.Uposlenik).ToList();
            return _mapper.Map<IList<FrizerskiSalon.Modal.Portfolio>>(result);
        }
        public override bool Delete(int id)
        {
            if (id != 0)
            {
                var stavkePortfolia = _context.StavkePortfolia.Where(x => x.PortfolioId == id).ToList();
                foreach(var x in stavkePortfolia)
                {
                    _context.Remove(x);
                }
                _context.SaveChanges();
                var portfolio = _context.Portfolios.Find(id);
                _context.Remove(portfolio);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
