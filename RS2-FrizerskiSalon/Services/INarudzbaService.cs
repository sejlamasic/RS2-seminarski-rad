using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;

namespace RS2_FrizerskiSalon.Services
{
    public interface INarudzbaService : ICRUDService<FrizerskiSalon.Modal.Narudzba, NarudzbaSearchObject, NarudzbaInsertRequest, NarudzbaInsertRequest>
    {
        public bool SetPaid(int id);
        public int AktivnaNarudzba(int id);
    }
}
