using AutoMapper;
using RS2_FrizerskiSalon.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_FrizerskiSalon.Services
{
    public class BaseReadService<T, TDb, TSearch> : IReadService<T, TSearch> where T : class where TDb : class where TSearch : class
    {
        protected FrizerskiStudioRsiiContext _context { get; set; }
        protected readonly IMapper _mapper;
        public BaseReadService(FrizerskiStudioRsiiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public virtual IList<T> Get(TSearch search = null)
        {
            var entity = _context.Set<TDb>();
            var list = entity.ToList();
            return _mapper.Map<IList<T>>(list);
        }

        public virtual T GetById(int id)
        {
            var set = _context.Set<TDb>();
            var entity = set.Find(id);
            return _mapper.Map<T>(entity);
        }
    }
}
