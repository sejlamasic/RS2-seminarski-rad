using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_FrizerskiSalon.Services
{
    public interface IReadService<T, TSearch> where T: class where TSearch: class
    {
        IList<T> Get(TSearch search = null);
        public T GetById(int id);
    }
}
