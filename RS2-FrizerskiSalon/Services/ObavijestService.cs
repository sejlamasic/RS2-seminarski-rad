using AutoMapper;
using Microsoft.EntityFrameworkCore;
using FrizerskiSalon.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;
using RS2_FrizerskiSalon.Database;

namespace RS2_FrizerskiSalon.Services
{
    public class ObavijestService : BaseCRUDService<FrizerskiSalon.Modal.Obavijest, Database.Obavijest, ObavijestSearchObject, ObavijestInsertRequest, ObavijestUpdateRequest>, IObavijestService
    {
        public ObavijestService(FrizerskiStudioRsiiContext context, IMapper mapper)
            :base(context, mapper)
        {
        }

        public override IList<FrizerskiSalon.Modal.Obavijest> Get(ObavijestSearchObject search = null)
        {
            var entity = _context.Set<Database.Obavijest>().AsQueryable();
            if (search?.UposlenikId.HasValue == true)
            {
                entity = entity.Where(x => x.UposlenikId == search.UposlenikId);
            }
            var result = entity.OrderByDescending(x => x.Datum).ToList();
            return _mapper.Map<IList<FrizerskiSalon.Modal.Obavijest>>(result);
        }
    }
}
