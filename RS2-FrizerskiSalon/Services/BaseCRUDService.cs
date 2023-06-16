using AutoMapper;
using RS2_FrizerskiSalon.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_FrizerskiSalon.Services
{
    public class BaseCRUDService<T, TDb, TSearch, TInsert, TUpdate> : BaseReadService<T, TDb, TSearch>, ICRUDService<T, TSearch, TInsert, TUpdate> where T: class where TDb: class where TSearch: class where TInsert: class where TUpdate: class
    {
        public BaseCRUDService(FrizerskiStudioRsiiContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public virtual T Insert(TInsert request)
        {
            var entity = _mapper.Map<TDb>(request);
            _context.Set<TDb>().Add(entity);
            _context.SaveChanges();
            return _mapper.Map<T>(entity);
        }

        public virtual T Update(int id, TUpdate request)
        {
            var entity = _context.Set<TDb>().Find(id);
            //_context.Set<TDb>().Attach(entity);
            //_context.Set<TDb>().Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<T>(entity);
        }
        public virtual bool Delete(int id)
        {
            var entity = _context.Set<TDb>().Find(id);
            if (entity != null)
            {
                _context.Set<TDb>().Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
