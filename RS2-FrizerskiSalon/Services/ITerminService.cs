using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;

namespace RS2_FrizerskiSalon.Services
{
    public interface ITerminService : ICRUDService<FrizerskiSalon.Modal.Termin, TerminSearchObject, TerminInsertRequest, TerminUpdateRequest>
    {
        public bool SetPaid(int id);
    }
}
