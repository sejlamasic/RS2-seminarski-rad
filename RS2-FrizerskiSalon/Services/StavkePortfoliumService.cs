using AutoMapper;
using RS2_FrizerskiSalon.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;

namespace RS2_FrizerskiSalon.Services
{
    public class StavkePortfoliumService : BaseCRUDService<FrizerskiSalon.Modal.StavkePortfolium, StavkePortfolium, StavkePortfoliumSearchObject, StavkePortfoliumInsertRequest, StavkePortfoliumInsertRequest>, IStavkePortfoliumService
    {
        public StavkePortfoliumService(FrizerskiStudioRsiiContext context, IMapper mapper)
            :base(context, mapper)
        {

        }

        public override IList<FrizerskiSalon.Modal.StavkePortfolium> Get(StavkePortfoliumSearchObject search = null)
        {
            var entity = _context.Set<StavkePortfolium>().AsQueryable();
            if (search?.PortfolioId.HasValue == true)
            {
                entity = entity.Where(x => x.PortfolioId == search.PortfolioId);
            }
            var result = entity.ToList();
            return _mapper.Map<IList<FrizerskiSalon.Modal.StavkePortfolium>>(result);
        }
    }
}
